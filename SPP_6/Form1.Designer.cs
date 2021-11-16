
namespace SPP_6
{
    partial class TaskListerForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskListerForm));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.listView = new System.Windows.Forms.ListView();
            this.procName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.procPID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.procCPU = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.procMem = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.nProcessesTB = new System.Windows.Forms.TextBox();
            this.totalCPUUsageTB = new System.Windows.Forms.TextBox();
            this.totalMemoryTB = new System.Windows.Forms.TextBox();
            this.taskListerNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.listView);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.tableLayoutPanel);
            this.splitContainer.Size = new System.Drawing.Size(468, 450);
            this.splitContainer.SplitterDistance = 417;
            this.splitContainer.TabIndex = 0;
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.procName,
            this.procPID,
            this.procCPU,
            this.procMem});
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(0, 0);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(468, 417);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ColumnClick);
            // 
            // procName
            // 
            this.procName.Text = "Process Name";
            this.procName.Width = 227;
            // 
            // procPID
            // 
            this.procPID.Text = "Process PID";
            this.procPID.Width = 75;
            // 
            // procCPU
            // 
            this.procCPU.Text = "CPU Usage";
            this.procCPU.Width = 70;
            // 
            // procMem
            // 
            this.procMem.Text = "Memory Usage";
            this.procMem.Width = 89;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 4;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.70978F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.29022F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tableLayoutPanel.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.nProcessesTB, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.totalCPUUsageTB, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.totalMemoryTB, 3, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(468, 29);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nProcessesTB
            // 
            this.nProcessesTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nProcessesTB.Location = new System.Drawing.Point(228, 3);
            this.nProcessesTB.Name = "nProcessesTB";
            this.nProcessesTB.ReadOnly = true;
            this.nProcessesTB.Size = new System.Drawing.Size(66, 20);
            this.nProcessesTB.TabIndex = 1;
            this.nProcessesTB.Text = "0";
            this.nProcessesTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // totalCPUUsageTB
            // 
            this.totalCPUUsageTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.totalCPUUsageTB.Location = new System.Drawing.Point(300, 3);
            this.totalCPUUsageTB.Name = "totalCPUUsageTB";
            this.totalCPUUsageTB.ReadOnly = true;
            this.totalCPUUsageTB.Size = new System.Drawing.Size(72, 20);
            this.totalCPUUsageTB.TabIndex = 2;
            this.totalCPUUsageTB.Text = "0";
            this.totalCPUUsageTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // totalMemoryTB
            // 
            this.totalMemoryTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.totalMemoryTB.Location = new System.Drawing.Point(378, 3);
            this.totalMemoryTB.Name = "totalMemoryTB";
            this.totalMemoryTB.ReadOnly = true;
            this.totalMemoryTB.Size = new System.Drawing.Size(87, 20);
            this.totalMemoryTB.TabIndex = 3;
            this.totalMemoryTB.Text = "0";
            this.totalMemoryTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // taskListerNotifyIcon
            // 
            this.taskListerNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("taskListerNotifyIcon.Icon")));
            this.taskListerNotifyIcon.Text = "Task Lister";
            this.taskListerNotifyIcon.Visible = true;
            this.taskListerNotifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.taskListerNotifyIcon_MouseClick);
            // 
            // TaskListerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 450);
            this.Controls.Add(this.splitContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TaskListerForm";
            this.Text = "Task Lister";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TaskListerForm_FormClosing);
            this.Resize += new System.EventHandler(this.TaskListerForm_Resize);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nProcessesTB;
        private System.Windows.Forms.TextBox totalCPUUsageTB;
        private System.Windows.Forms.TextBox totalMemoryTB;
        private System.Windows.Forms.ColumnHeader procName;
        private System.Windows.Forms.ColumnHeader procPID;
        private System.Windows.Forms.ColumnHeader procCPU;
        private System.Windows.Forms.ColumnHeader procMem;
        private System.Windows.Forms.NotifyIcon taskListerNotifyIcon;
    }
}

