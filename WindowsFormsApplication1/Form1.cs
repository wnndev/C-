using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApplication1.Properties;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        string[] pathArray = new string[2000];
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            InitListView(listView1);
            this.listView1.View = View.Details;
            AddNode(treeView1);     
        }

       

        /// <summary>
        /// 显示时间的定时器事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Text = DateTime.Now.ToString();
        }

        /// <summary>
        /// 初始化预览窗口（listview）
        /// </summary>
        /// <param name="listView"></param>
        public void InitListView(ListView listView)
        {
            ColumnHeader hander1 = new ColumnHeader();
            hander1.Width = 80;
            hander1.Text = "图片";
            ColumnHeader hander2 = new ColumnHeader();
            hander2.Width = 100;
            hander2.Text = "文件名";
            ColumnHeader hander3 = new ColumnHeader();
            hander3.Width = 200;
            hander3.Text = "创建日期";
            listView.Columns.Add(hander1);
            listView.Columns.Add(hander2); 
            listView.Columns.Add(hander3);
            listView.GridLines = true;
            listView.FullRowSelect = true;
        }
        /// <summary>
        /// 树形控件添加盘符
        /// </summary>
        /// <param name="treeView"></param>
        public void AddNode(TreeView treeView)
        {
            treeView.BeginUpdate();
            TreeNode mainNode = new TreeNode("我的电脑");
            mainNode.Tag = "我的电脑";
            treeView.Nodes.Add(mainNode);
            
            foreach (string drive in Environment.GetLogicalDrives())
            {
                //实例化DriveInfo对象 命名空间System.IO  
                var dir = new DriveInfo(drive);
                switch (dir.DriveType)           //判断驱动器类型  
                {
                    case DriveType.Fixed:        //仅取固定磁盘盘符 Removable-U盘   
                        {
                            //Split仅获取盘符字母  
                            TreeNode tNode = new TreeNode(dir.Name.Split(':')[0]);
                            tNode.Name = dir.Name;
                            tNode.Tag = tNode.Name;
                            mainNode.Nodes.Add(tNode);                    //加载驱动节点  
                            tNode.Nodes.Add("");
                        }
                        break;
                }
            }
            treeView.EndUpdate();
        }
        private void directoryTree_AfterExpand(object sender, TreeViewEventArgs e)
        {
            e.Node.Expand();
        }

        /// <summary>  
        /// 在将要展开结点时发生 加载子结点  
        /// </summary>  
        private void directoryTree_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            Add(e.Node);
        }
        /// <summary>  
        /// 调用Add(TreeNode e)方法加载子目录  
        /// </summary>    
            
            public void Add(TreeNode e)
            {
                //try..catch异常处理  
                try
                {
                    //判断"我的电脑"Tag 上面加载的该结点没指定其路径  
                    if (e.Tag.ToString() != "我的电脑")
                    {
                        e.Nodes.Clear();                               //清除空节点再加载子节点  
                        TreeNode tNode = e;                            //获取选中\展开\折叠结点  
                        string path = tNode.Name;                      //路径    

                        //获取"我的文档"路径  
                        if (e.Tag.ToString() == "我的文档")
                        {
                            path = Environment.GetFolderPath           //获取计算机我的文档文件夹  
                                (Environment.SpecialFolder.MyDocuments);
                        }

                        //获取指定目录中的子目录名称并加载结点  
                        string[] dics = Directory.GetDirectories(path);
                        foreach (string dic in dics)
                        {
                            TreeNode subNode = new TreeNode(new DirectoryInfo(dic).Name); //实例化  
                            subNode.Name = new DirectoryInfo(dic).FullName;               //完整目录  
                            subNode.Tag = subNode.Name;
                        //imageList.Images.Add(System.Drawing.Icon.ExtractAssociatedIcon(dic).ToBitmap());
                        //treeView1.ImageList = imageList;
                            //subNode.ImageIndex= imageList.Images.Count-1;
                            tNode.Nodes.Add(subNode);
                            subNode.Nodes.Add("");                               //加载空节点 实现+号  
                        }
                    }
                }
                catch (Exception msg)
                {
                    MessageBox.Show(msg.Message);                   //异常处理  
                }
            }
        /// <summary>
        /// 确认treeview中的路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_ChosePath_Click(object sender, EventArgs e)
        {
            try
            {
                String[] files = System.IO.Directory.GetFiles(label_ChosePath.Text);
                ImageList imageList = new ImageList();
                imageList.ImageSize = new Size(80, 80);
                listView1.Items.Clear();
                
                int i = 0,picCount=0;
                //获取图像文件总个数
                foreach (string file in files)
                {
                    if (IsPicture(file))
                        picCount++;
                }
                progressBar_ShowPic.Maximum = picCount;
                //依次打开预览图放入listview中
                foreach (string file in files)
                {         
                    System.IO.FileInfo fi = new System.IO.FileInfo(file);
                    if (IsPicture(file))
                    {   try
                        {
                            Image image = Image.FromFile(file);
                            imageList.Images.Add(image.GetThumbnailImage(80, 80, null, IntPtr.Zero));
                            image.Dispose();
                        }
                        catch (Exception exc)
                        {
                            MessageBox.Show("有一张图无法预览：" + exc.Message,"图片预览错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            continue;
                        }
                        finally
                        {
                            ListViewItem lv = new ListViewItem();
                            lv.SubItems.Add(fi.Name);
                            lv.SubItems.Add(fi.CreationTime.ToString());
                            pathArray[i] = file; //pathArray存储图片的路径
                            lv.ImageIndex = i++;
                            listView1.Items.Add(lv);
                        }
                            
                            
                            if (i >= 2000) break;  
                            progressBar_ShowPic.Value = i;
                        
                    }
                }

                listView1.SmallImageList = imageList;
                     }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// listview选中，打开图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                //pathArray存储图片的路径
                pictureBox1.Image = Image.FromFile(pathArray[listView1.SelectedItems[0].Index]);
               
            }
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag.ToString() != "我的电脑")
            {
                label_ChosePath.Text = e.Node.Name;   
            }
        }
        /// <summary>
        /// 判断文件是否为图片的方法，用后缀判断
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool IsPicture(string fileName)
        {
            string strFilter = ".jpeg|.jpg|.png|.bmp|.pic|.tiff|.ico";
            char[] separtor = { '|' };
            string[] tempFileds = StringSplit(strFilter, separtor);
            System.IO.FileInfo fi = new System.IO.FileInfo(fileName);
            foreach (string str in tempFileds)
            {
                if (str.ToUpper() == fi.Extension.ToUpper()) { return true; }
            }
            return false;
        }
        // 通过字符串，分隔符返回string[]数组 
        public string[] StringSplit(string s, char[] separtor)
        {
            string[] tempFileds = s.Trim().Split(separtor); return tempFileds;
        }
        /// <summary>
        /// 双击打开form2看大图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            Form2 fm2 = new WindowsFormsApplication1.Form2();
            fm2.PicPath = pathArray[listView1.SelectedItems[0].Index];
            fm2.Show();
        }

        
    }
}
