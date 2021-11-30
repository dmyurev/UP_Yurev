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
    public partial class Form3 : Form
    {
        static string conStr = " Data Source = (localdb)\\MSSQLLocalDB;Initial Catalog = b1; Integrated Security = True";
        DataContext context = new DataContext(conStr);
        public Form1 mainForm;
        public Form3(Form1 form)
        {
            InitializeComponent();
            mainForm = form;
        }

        private void Add_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "b1DataSet.Service". При необходимости она может быть перемещена или удалена.
            this.serviceTableAdapter1.Fill(this.b1DataSet.Service);
            //// TODO: данная строка кода позволяет загрузить данные в таблицу "b1DataSet.Service". При необходимости она может быть перемещена или удалена.
            //this.serviceTableAdapter.Fill(this.b1DataSet.Service);

        }

        private void Cancel2_Click(object sender, EventArgs e)
        {
            Close();
            mainForm.Show();
        }

        private void Add2_Click(object sender, EventArgs e)
        {

            Service add = new Service();
            add.Title = ServiceTitleTB.Text;
            add.Cost = Convert.ToInt32(ServiceCostTB.Text);
            add.DurationInSeconds = Convert.ToInt32(ServiceDurationTB.Text);
            add.Description = ServiceDescriptionTB.Text;
            add.Discount= Convert.ToInt32(ServiceDiscountTB.Text);
            add.MainImagePath = Convert.ToString(PathCB.SelectedValue);
            context.GetTable<Service>().InsertOnSubmit(add);
            context.SubmitChanges();
            MessageBox.Show("Успешно!!");
            dataGridView1.DataSource = conStr.ToArray();
        }

        private void PathCB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
