using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDDEmployees
{
    class DALEmployee
    {

        public List<Employee> SelectEmpleados(Conector c1)
        {
            List<Employee> emps = new List<Employee>();
            Employee emp;

            try
            {
                c1.AbrirConexion();

                string sql = "SELECT * FROM employees";
                SqlCommand cmd = new SqlCommand(sql, c1.Conexion);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    emp = new Employee();
                    emp.Employee_id = (int)dr["employee_id"];
                    emp.First_name = (string)GestionarNulos(dr["first_name"]);
                    emp.Last_name = (string)GestionarNulos(dr["last_name"]);
                    emp.Email = (string)GestionarNulos(dr["email"]);
                    emp.Phone_number = (string)GestionarNulos(dr["phone_number"]);
                    emp.Hire_date = (DateTime)GestionarNulos(dr["hire_date"]);
                    emp.Fkjob_id = (int)GestionarNulos(dr["fkjob_id"]);
                    emp.Salary = (decimal)GestionarNulos(dr["salary"]);
                    emp.Fkmanager_id = (int?)GestionarNulos(dr["fkmanager_id"]);
                    emp.Fkdepartment_id = (int?)GestionarNulos(dr["fkdepartment_id"]);

                    emps.Add(emp);
                }

                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                c1.CerrarConexion();
            }

            return emps;
        }

        public object GestionarNulos(object valOriginal)
        {
            if (valOriginal == System.DBNull.Value)
                return null;
            else
                return valOriginal;
        }

        internal void Insert(Employee emp, Conector c1)
        {
            string query = "INSERT INTO employees " +
                "VALUES('" + emp.First_name + "', '" + emp.Last_name + "', '" + emp.Email + "' , '" + emp.Phone_number + "', '" + emp.Hire_date + "', '" + emp.Fkjob_id + "', '" + emp.Salary + "', '" + emp.Fkmanager_id + "', '" + emp.Fkdepartment_id + "');";

            try
            {
                SqlCommand comando = new SqlCommand(query, c1.Conexion);
                comando.ExecuteNonQuery();
                MessageBox.Show("Employee creado");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }

        internal void Update(Employee emp)
        {

        }

        internal void Delete(Employee emp)
        {

        }
    }

}
