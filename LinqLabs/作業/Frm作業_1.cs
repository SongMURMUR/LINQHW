using LinqLabs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyHomeWork
{
    public partial class Frm作業_1 : Form
    {
        public Frm作業_1()
        {
            InitializeComponent();
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            //this.nwDataSet1.Products.Take(10);//Top 10 Skip(10)

            //Distinct()
        }

        private void btnlog_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] files = dir.GetFiles();

            var logFiles = from file in files
                           where file.Extension.Equals(".log", StringComparison.OrdinalIgnoreCase) //StringComparison.OrdinalIgnoreCase 不分大小寫
                           select file;


            this.dataGridView1.DataSource = logFiles.ToList();

        }

        private void btn2022_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] files = dir.GetFiles();

            DateTime thresholdDate = new DateTime(2022, 1, 1);

            var oldFiles = from file in files
                           where file.CreationTime < thresholdDate
                           select file;

            this.dataGridView1.DataSource = oldFiles.ToList();
        }

        private void btnlarge_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] files = dir.GetFiles();

            var largeFiles = from file in files
                             where file.Length > 10000
                             select file;

            this.dataGridView1.DataSource = largeFiles.ToList();
        }

        private void btnall_Click(object sender, EventArgs e)
        {
            this.ordersTableAdapter1.Fill(this.nwDataSet1.Orders);

            var q = from o in this.nwDataSet1.Orders
                    where !o.IsShippedDateNull()  //ShippedDate 有空值會爆錯 其他資料列也有空值 但可以從NullValue改成(Null)
                    select o;
                                                 

            this.dataGridView1.DataSource = q.ToList();

        }

        private void btnxyear_Click(object sender, EventArgs e)
        {

        }
    }
}
