using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileBrowser
{
    public partial class Form1 : Form
    {
        private ImageList imageListSmall = new ImageList();

        public Form1()
        {
            InitializeComponent();

            TreeNode treeNode = new TreeNode();

            List<TreeNode> list = new List<TreeNode>();
            
            imageListSmall.Images.Add(Bitmap.FromFile(@"..\..\icons\FolderIcon.bmp"));
            imageListSmall.Images.Add(Bitmap.FromFile(@"..\..\icons\FileIcon.bmp"));
            this.treeView1.ImageList = imageListSmall;

            DirectoryInfo[] cDirs = new DirectoryInfo(@"d:\").GetDirectories();
            foreach (var dir in cDirs)
            {
                var node = new TreeNode();
                node.Name = dir.FullName;
                node.Text = dir.Name;
                node.ImageIndex = 0;
                list.Add(node);
            }

            treeNode = new TreeNode(@"D:\", list.ToArray());
            treeView1.Nodes.Add(treeNode);
        }

        private void treeView1_mouseClick(object sender, MouseEventArgs e)
        {
            this.listView1.Items.Clear();

            TreeNode node = treeView1.SelectedNode;

            List<ListViewItem> list = new List<ListViewItem>();

            DirectoryInfo[] cDirs = new DirectoryInfo(node.Name).GetDirectories();
            var files = new DirectoryInfo(node.Name).GetFiles();

            listView1.SmallImageList = imageListSmall;

            foreach (var dir in cDirs)
            {
                ListViewItem item = new ListViewItem();
                item.Name = dir.FullName;
                item.Text = dir.Name;
                item.ImageIndex = 0;
                list.Add(item);
            }

            foreach (var file in files)
            {
                ListViewItem item = new ListViewItem();
                item.Name = file.FullName;
                item.Text = file.Name;
                item.ImageIndex = 1;
                list.Add(item);
            }

            this.listView1.Items.AddRange(list.ToArray());
        }

        private void listView_MouseClick(object sender, MouseEventArgs e)
        {
            string selectedFile = this.listView1.SelectedItems[0].Text;
            string currentDir = this.listView1.SelectedItems[0].Name.Replace(selectedFile,"");
            string folderDir = this.listView1.SelectedItems[0].Name;
            
            if (File.Exists(Path.Combine(currentDir, selectedFile)))
            {
                try
                {
                    System.Diagnostics.Process.Start(currentDir + @"\" + selectedFile);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.StackTrace);
                }
            }
            else if (Directory.Exists(folderDir))
            {
                System.Diagnostics.Process.Start(folderDir);
            }
        }

    }
}
