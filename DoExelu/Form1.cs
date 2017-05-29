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


namespace DoExelu
{
    public partial class Form1 : Form
    {
        private List<Data> dat;
        public Form1()
        {
            InitializeComponent();

            DataTable table = new DataTable();
            table.Columns.Add("ID",typeof(Int32));
            table.Columns.Add("Name");
            table.Columns.Add("CountryCode");
            table.Columns.Add("District");
            table.Columns.Add("Population",typeof(Int32));

            LoadData load = new LoadData();
            dat = load.getData();
            for (int i =0; i< dat.Count; i++)
            {
                DataRow row = table.NewRow();
                row["ID"] = Int32.Parse(dat[i].ID);
                row["Name"] = dat[i].name;
                row["CountryCode"] = dat[i].countryCode;
                row["District"] = dat[i].district;
                row["Population"] = Int32.Parse(dat[i].population);

                table.Rows.Add(row);
            }

            dataGridView1.DataSource = table;

            //vlakno
          /*  Thread t1 = new Thread(() => { Console.WriteLine("bezi vlakno t1"); Thread.Sleep(500); Console.WriteLine("bezi vlakno t1"); } );
            Thread t2 = new Thread(() => { Console.WriteLine("bezi vlakno t2"); Thread.Sleep(500); Console.WriteLine("bezi vlakno t2"); } );
            t1.Start();
            t2.Priority = ThreadPriority.Highest;
            t2.Start();
            t1.Join();
            t2.Join();*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sav = new SaveFileDialog();
            sav.Filter = "Excel |*.xls";
            sav.FileName = "cities.xls";
            DialogResult res =  sav.ShowDialog();
            if (res == DialogResult.OK)
            {
                new ExportData().export(dat,sav.FileName);
            }
           
        }
    }
}
