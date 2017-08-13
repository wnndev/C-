namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.listView1 = new System.Windows.Forms.ListView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label_ChosePath = new System.Windows.Forms.Label();
            this.button_ChosePath = new System.Windows.Forms.Button();
            this.progressBar_ShowPic = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(217, 60);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(276, 312);
            this.listView1.TabIndex = 11;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(515, 60);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(318, 336);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 42);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(199, 354);
            this.treeView1.TabIndex = 14;
            this.treeView1.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.directoryTree_BeforeExpand);
            this.treeView1.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.directoryTree_AfterExpand);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // label_ChosePath
            // 
            this.label_ChosePath.AutoSize = true;
            this.label_ChosePath.Location = new System.Drawing.Point(217, 42);
            this.label_ChosePath.Name = "label_ChosePath";
            this.label_ChosePath.Size = new System.Drawing.Size(29, 12);
            this.label_ChosePath.TabIndex = 15;
            this.label_ChosePath.Text = "路径";
            // 
            // button_ChosePath
            // 
            this.button_ChosePath.Location = new System.Drawing.Point(435, 37);
            this.button_ChosePath.Name = "button_ChosePath";
            this.button_ChosePath.Size = new System.Drawing.Size(58, 23);
            this.button_ChosePath.TabIndex = 16;
            this.button_ChosePath.Text = "确定";
            this.button_ChosePath.UseVisualStyleBackColor = true;
            this.button_ChosePath.Click += new System.EventHandler(this.button_ChosePath_Click);
            // 
            // progressBar_ShowPic
            // 
            this.progressBar_ShowPic.Location = new System.Drawing.Point(217, 373);
            this.progressBar_ShowPic.Name = "progressBar_ShowPic";
            this.progressBar_ShowPic.Size = new System.Drawing.Size(276, 23);
            this.progressBar_ShowPic.TabIndex = 17;
            this.progressBar_ShowPic.Tag = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 418);
            this.Controls.Add(this.progressBar_ShowPic);
            this.Controls.Add(this.button_ChosePath);
            this.Controls.Add(this.label_ChosePath);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.listView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label_ChosePath;
        private System.Windows.Forms.Button button_ChosePath;
        private System.Windows.Forms.ProgressBar progressBar_ShowPic;
    }
}

