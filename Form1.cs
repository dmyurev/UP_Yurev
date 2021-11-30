using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.IO;
using System.Data.SqlClient;

namespace UP
{
    public partial class Form1 : Form
    {
        static string conStr = " Data Source = (localdb)\\MSSQLLocalDB;Initial Catalog = b1; Integrated Security = True";
        DataContext context = new DataContext(conStr);
        public Form1()
        {
            InitializeComponent();
           
            this.BackColor = Color.FromArgb(255, 255, 225);
            Table<Service> Service = context.GetTable<Service>();
            var services = Service.Select(s => s.MainImagePath);
            Dictionary<string, Image> images = new Dictionary<string, Image>();
            //foreach (var s in services)
            //{
            //    string path = $"{Environment.CurrentDirectory}\\{s.Remove(0,1)}";
            //    images[s] = Image.FromFile(path);
            //}
            //List<Service> allServices = Service.ToList();
            //foreach(var service in allServices)
            //{
            //    foreach(var image in images.Keys)
            //    {
            //        if(service.MainImagePath == image)
            //        {
            //            service.Image = images[image];
            //            continue;
            //        }
            //    }
            //}
            //dataGridView1.DataSource = allServices;
            TableGV.DataSource = Service.ToList();
        }

        public void администраторToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(this);
            f2.Show();
            Hide();
            
            button4.Visible = false;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            comboBox1.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Close();        
        }

        private void Add_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3(this);
            f3.Show();
            Hide();
            Table<Service> Service = context.GetTable<Service>();
            TableGV.DataSource = Service.ToList();
        }

        private void обычныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            comboBox1.Visible = false;
            button4.Visible = true;
            textBox1.Visible = false;
            textBox2.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
        }

        private void Del_Click(object sender, EventArgs e)
        {
            Service serv= context.GetTable<Service>().OrderByDescending(x => x.ID).FirstOrDefault();
            context.GetTable<Service>().DeleteOnSubmit(serv);
            context.SubmitChanges();
            MessageBox.Show("Успешно!!");
            //dataGridView1.DataSource = conStr.ToArray();
            Table<Service> Service = context.GetTable<Service>();
            TableGV.DataSource = Service.ToList();
        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4(this);
            f4.Show();
            Hide();
            Table<Service> Service = context.GetTable<Service>();
            TableGV.DataSource = Service.ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5(this);
            f5.Show();
            Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "b1DataSet.Service". При необходимости она может быть перемещена или удалена.
            this.serviceTableAdapter.Fill(this.b1DataSet.Service);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Service> services = null;
            switch (comboBox1.SelectedIndex)
            {
                case 0: services = context.GetTable<Service>().Where(x => x.Discount <= 0.05 && x.Discount > 0).ToList(); break;
                case 1: services = context.GetTable<Service>().Where(x => x.Discount <= 0.15 && x.Discount > 0.05).ToList(); break;
                case 2: services = context.GetTable<Service>().Where(x => x.Discount <= 0.3 && x.Discount > 0.15).ToList(); break;
                case 3: services = context.GetTable<Service>().Where(x => x.Discount <= 0.7 && x.Discount > 0.3).ToList(); break;
                case 4: services = context.GetTable<Service>().Where(x => x.Discount <= 1 && x.Discount > 0.7).ToList(); break;
                case 5: services = context.GetTable<Service>().Where(x => x.Discount <= 1 && x.Discount > 0).ToList(); break;

            }

            TableGV.DataSource = services;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string sql = "Select *From [Service] Where [Title] Like N'%" + textBox1.Text + "%' ";
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(conStr);
            SqlDataAdapter ad = new SqlDataAdapter(sql, con);
            ad.Fill(ds);
            TableGV.DataSource = ds.Tables[0];

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string sql = "Select *From [Service] Where [Description] Like N'%" + textBox2.Text + "%' ";
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(conStr);
            SqlDataAdapter ad = new SqlDataAdapter(sql, con);
            ad.Fill(ds);
            TableGV.DataSource = ds.Tables[0];
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
