using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace SPP_6
{
    public partial class TaskListerForm : Form
    {
        TasksInfoLoader loader;
        bool appWorking;
        public TaskListerForm()
        {
            InitializeComponent();
            loader = new TasksInfoLoader();
            appWorking = true;
            /*TimerCallback tm = new TimerCallback(UpdateInfo);
            System.Threading.Timer timer = new System.Threading.Timer(tm, loader, 0, 2000);*/
            Thread thread = new Thread(new ThreadStart(UpdateInfo));
            thread.Start();

        }

        private void UpdateInfo()
        {
            while (appWorking)
            {
                UpdateInfo(loader);
                Thread.Sleep(2000);
            }
        }
        private void UpdateInfo(object o)
        {
            TasksInfoLoader ldr = (TasksInfoLoader)o;
            ldr.UpdateInfos();
            this.Invoke(new MethodInvoker(delegate {
                ldr.FillTotalSumInformation(nProcessesTB, totalCPUUsageTB, totalMemoryTB);
                }
            ));
            ldr.FillListWithInfo(listView);
        }

        private void listView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            listView.ListViewItemSorter = new ListViewItemComparer(e.Column);
        }

        private void TaskListerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            appWorking = false;
        }

        private void taskListerNotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            //проверяем, какой кнопкой было произведено нажатие
            if (e.Button == MouseButtons.Left)//если левой кнопкой мыши
            {
                Show();
                WindowState = FormWindowState.Normal;
                ShowInTaskbar = true;
            }
        }

        private void TaskListerForm_Resize(object sender, EventArgs e)
        {
            if(WindowState == FormWindowState.Minimized)
            {
                ShowInTaskbar = false;
            }
        }
    }
}
