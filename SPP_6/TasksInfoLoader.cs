using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SPP_6
{
    public class TasksInfoLoader
    {
        

        public TasksInfoLoader()
        {
            ProcsInfos = new LinkedList<ProcessInfo>();
        }

        public LinkedList<ProcessInfo> ProcsInfos { get; set; }

        public void FillListWithInfo(ListView lView)
        {
            ListViewItem[] items = new ListViewItem[ProcsInfos.Count]; int i = 0;
            foreach(ProcessInfo info in ProcsInfos)
            {
                items[i] = CreateProcInfoItem(info);
                i++;
                //lView.Items.Add(CreateProcInfoItem(info));
            }
            if (lView.InvokeRequired)
            {
                lView.Invoke(new MethodInvoker(delegate
                {
                    AddRangeToListView(lView, items);
                }));
            } else
            {
                AddRangeToListView(lView, items);
            }
            //lView.Refresh();
        }

        private void AddRangeToListView(ListView lView, ListViewItem[] items)
        {
            lView.BeginUpdate();
            lView.Items.Clear();
            lView.Items.AddRange(items);
            lView.EndUpdate();
        }

        public void FillTotalSumInformation(TextBox procsNum, TextBox totalCPU, TextBox totalMemory)
        {
            ProcessInfo totalInfo = ProcsInfos.Last.Value;
            procsNum.Text = totalInfo.Pid;
            totalCPU.Text = totalInfo.CpuUsage;
            totalMemory.Text = totalInfo.Memory;
            ProcsInfos.RemoveLast();
        }

        private ListViewItem CreateProcInfoItem(ProcessInfo info)
        {
            ListViewItem listViewItem = new ListViewItem(info.GetAllInfo());

            return listViewItem;
        }

        [DllImport(@"f:\Coding\C#\SPP_6\Debug\TaskLister.dll", CallingConvention = CallingConvention.Cdecl)]
        unsafe static extern void* getProcInfoTable();

        public void UpdateInfos()
        {
            ProcsInfos.Clear();
            LoadInfosCollection(ProcsInfos);
        }

        public static unsafe void LoadInfosCollection(ICollection<ProcessInfo> infoList)
        {
            byte*** infos = (byte***)getProcInfoTable();
            int i;
            for (i = 0; infos[i][0] != null || infos[i][2] != null; i++)
            {
                infoList.Add(new ProcessInfo(infos[i]));
            }
            ProcessInfo totalInfo = new ProcessInfo(infos[i]);
            infoList.Add(totalInfo);
        }
    }
}
