using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDDEmployees
{
    public partial class Form1 : Form
    {
        Conector c1 = new Conector();
        DALEmployee DalEmp = new DALEmployee();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            listView1.Clear();

            listView1.Columns.Add("id", 30, HorizontalAlignment.Center);
            listView1.Columns.Add("first_name", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("last_name", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("email", 200, HorizontalAlignment.Center);
            listView1.Columns.Add("phone_number", 120, HorizontalAlignment.Center);
            listView1.Columns.Add("hire_date", 90, HorizontalAlignment.Center);
            listView1.Columns.Add("fkjob_id", 50, HorizontalAlignment.Center);
            listView1.Columns.Add("salary", 80, HorizontalAlignment.Center);
            listView1.Columns.Add("fkmanager_id", 50, HorizontalAlignment.Center);
            listView1.Columns.Add("fkdepartment_id", 50, HorizontalAlignment.Center);

            c1.AbrirConexion();

            List<Employee> emps = DalEmp.SelectEmpleados(c1);

            for (int i = 0; i < emps.Count(); i++)
            {
                // Insertamos los datos
                ListViewItem fila = new ListViewItem(emps[i].Employee_id.ToString());
                fila.SubItems.Add(emps[i].First_name.ToString());
                fila.SubItems.Add(emps[i].Last_name.ToString());
                fila.SubItems.Add(emps[i].Email.ToString());
                if(emps[i].Phone_number == null)
                {
                    emps[i].Phone_number = "null";
                }
                fila.SubItems.Add(emps[i].Phone_number.ToString());
                fila.SubItems.Add(emps[i].Hire_date.ToString());
                fila.SubItems.Add(emps[i].Fkjob_id.ToString());
                fila.SubItems.Add(emps[i].Salary.ToString());
                fila.SubItems.Add(emps[i].Fkmanager_id.ToString());
                fila.SubItems.Add(emps[i].Fkdepartment_id.ToString());

                fila.Font = new Font(listView1.Columns[0].ListView.Font, FontStyle.Regular);
                listView1.Items.Add(fila);
            }

            c1.CerrarConexion();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            c1.AbrirConexion();
            DalEmp.Insert(new Employee(tbNombre.Text, tbApellido.Text, tbEmail.Text, tbPhone.Text, dateTimePicker1.Value, Int32.Parse(tbFkJob_id.Text), Int32.Parse(tbSalario.Text), Int32.Parse(tbFkManager_id.Text), Int32.Parse(tbFkDepartment_id.Text)), c1);
            c1.CerrarConexion();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

    }
}
