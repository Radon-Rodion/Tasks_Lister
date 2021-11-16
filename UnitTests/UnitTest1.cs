using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using SPP_6;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        LinkedList<ProcessInfo> infoList;

        [TestMethod]
        public void TestDll()
        {
            FillListWithInfos();
            Assert.IsTrue(infoList.Count > 0, "Nothing is returned!");
        }

        private void FillListWithInfos()
        {
            infoList = new LinkedList<ProcessInfo>();
            TasksInfoLoader.LoadInfosCollection(infoList);
        }

        [TestMethod]
        public void TestProcessesInfo()
        {
            if (infoList == null) FillListWithInfos(); //if first test not completed
            double totalCPU, totalMem;
            totalCPU = totalMem = 0;
            Assert.AreEqual<int>(System.Convert.ToInt32(infoList.Last.Value.Pid), infoList.Count - 1, "Returned invalid number of procs!");
            foreach(ProcessInfo info in infoList)
            {
                totalCPU += System.Convert.ToDouble(info.CpuUsage);
                totalMem += System.Convert.ToDouble(info.Memory);
            }
            totalCPU /= 2;
            totalMem /= 2;
            Assert.AreEqual(System.Convert.ToDouble(infoList.Last.Value.CpuUsage), totalCPU, 0.1, "Returned invalid CPU info!");
            Assert.AreEqual(System.Convert.ToDouble(infoList.Last.Value.Memory), totalMem, 0.1, "Returned invalid memory info!");

            Assert.AreEqual<string>("System", infoList.First.Value.Name, "Returned invalid first process name!");
            Assert.AreEqual<string>("4", infoList.First.Value.Pid.Trim(), "Returned invalid first process PID!");
        }

        [TestMethod]
        public void TestTasksInfoLoader()
        {
            ListView lView = new ListView();
            TextBox tbNProcs, tbTotalCPU, tbTotalMem;
            tbNProcs = new TextBox();
            tbTotalCPU = new TextBox();
            tbTotalMem = new TextBox();

            TasksInfoLoader loader = new TasksInfoLoader();
            loader.UpdateInfos();
            loader.FillListWithInfo(lView);
            loader.FillTotalSumInformation(tbNProcs, tbTotalCPU, tbTotalMem);
            Assert.AreEqual<int>(lView.Items.Count-1, System.Convert.ToInt32(tbNProcs.Text), "Set invalid number of procs!");

            double totalCPU, totalMem;
            totalCPU = totalMem = 0;
            foreach (ListViewItem item in lView.Items)
            {
                totalCPU += System.Convert.ToDouble(item.SubItems[2].Text);
                totalMem += System.Convert.ToDouble(item.SubItems[3].Text);
            }
            totalCPU /= 2;
            totalMem /= 2;
            Assert.AreEqual(System.Convert.ToDouble(tbTotalCPU.Text), totalCPU, 0.1, "Set invalid CPU info!");
            Assert.AreEqual(System.Convert.ToDouble(tbTotalMem.Text), totalMem, 0.1, "Set invalid memory info!");

            Assert.AreEqual<string>("System", lView.Items[0].Text, "Set invalid first process name!");
            Assert.AreEqual<string>("4", lView.Items[0].SubItems[1].Text.Trim(), "Set invalid first process PID!");
        }

        [TestMethod]
        public void TestListViewItemComparer()
        {
            ListView lView = new ListView();

            TasksInfoLoader loader = new TasksInfoLoader();
            loader.UpdateInfos();
            loader.FillListWithInfo(lView);

            lView.ListViewItemSorter = new ListViewItemComparer(0);
            foreach(ListViewItem item in lView.Items)
            {
                Assert.AreEqual<int>(String.Compare(item.Text, lView.Items[0].Text), lView.ListViewItemSorter.Compare(item, lView.Items[0]), "Invalid comparisson!");
            }
        }
    }
}
