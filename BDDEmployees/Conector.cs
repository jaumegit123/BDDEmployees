using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BDDEmployees
{
    class Conector
    {
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
        SqlConnection conexion;
        // SqlConnection conector = new SqlConnection("Data source = 46.183.116.173, 54321; Initial Catalog = JaumeEmpleados; Persist Security Info = true; User Id = sa; Password = 123456789");

        public Conector()
        {
            builder.DataSource = "46.183.116.173, 54321";
            builder.InitialCatalog = "JaumeEmpleados";
            builder.PersistSecurityInfo = true;
            builder.UserID = "sa";
            builder.Password = "123456789";

            conexion = new SqlConnection(builder.ConnectionString);
        }

        public SqlConnection Conexion { get => conexion; set => conexion = value; }

        public void AbrirConexion()
        {
            try
            {
                conexion.Open();
                // MessageBox.Show("Conectado a " + conexion.Database.ToString());
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        public void CerrarConexion()
        {
            conexion.Close();
            // MessageBox.Show("Conexión cerrada");
        }

    }
}
