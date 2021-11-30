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

namespace UP
{
    public partial class Form5 : Form
    {
        static string conStr = " Data Source = (localdb)\\MSSQLLocalDB;Initial Catalog = b1; Integrated Security = True";
        DataContext context = new DataContext(conStr);
        public Form1 mainForm;
        public Form5(Form1 form)
        {
            InitializeComponent();
            Table<ClientServ> clientser = context.GetTable<ClientServ>();
            dataGridView1.DataSource = clientser.ToList();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "b1DataSet3.Service". При необходимости она может быть перемещена или удалена.
            this.serviceTableAdapter.Fill(this.b1DataSet3.Service);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "b1DataSet3.Client". При необходимости она может быть перемещена или удалена.
            this.clientTableAdapter.Fill(this.b1DataSet3.Client);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "b1DataSet1.ClientService". При необходимости она может быть перемещена или удалена.
            this.clientServiceTableAdapter1.Fill(this.b1DataSet1.ClientService);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "b1DataSet2.ClientService". При необходимости она может быть перемещена или удалена.
            this.clientServiceTableAdapter.Fill(this.b1DataSet2.ClientService);


        }

        private void button4_Click(object sender, EventArgs e)
        {
            ClientServ NewUser = new ClientServ { ClientID = Convert.ToInt32(combobox1.SelectedValue), ServiceID = Convert.ToInt32(comboBox2.SelectedValue), StartTime = Convert.ToDateTime(dateTimePicker1.Value) };
            context.GetTable<ClientServ>().InsertOnSubmit(NewUser);
            context.SubmitChanges();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
            mainForm.Show();
        }
    }
}
