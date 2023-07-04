using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SingleCrud
{
    public class ShareDatabaseConnection
    {
        private MySqlConnection connection;

        public ShareDatabaseConnection(string connectionString)
        {
            this.connection = new MySqlConnection(connectionString);
        }

        public void Insert(share share)
        {
            string query = string.Format("INSERT INTO share (" +
                "Enero, Febrero, Marzo, Arbil, Mayo, Junio, Julio, " +
                "Agosto, Septiembre, Octubre, Noviembre, Diciembre, Importe) " +
                "VALUES('{0}', '{1}', '{2}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}')",
                share.Enero,
                share.Febrero,
                share.Marzo,
                share.Abril,
                share.Mayo,
                share.Junio,
                share.Julio,
                share.Agosto,
                share.Septiembre,
                share.Octubre,
                share.Noviembre,
                share.Diciembre,
                share.Importe);
            this.ExecuteNonQuery(query);
        }

        public void Update(share share)
        {
            string query = string.Format("UPDATE share SET " +
                "Enero      = '{1}'," +
                "Febrero    = '{2}'," +
                "Marzo      = '{3}'," +
                "Arbil      = '{4}'," +
                "Mayo       = '{5}'," +
                "Junio      = '{6}'," +
                "Julio      = '{7}'," +
                "Agosto     = '{8}'," +
                "Septiembre = '{9}'," +
                "Octubre    = '{10}'," +
                "Noviembre  = '{11}'," +
                "Diciembre  = '{12}'," +
                "Importe    = '{13}'," +
                "WHERE id   = {0}",
                share.Enero,
                share.Febrero,
                share.Marzo,
                share.Abril,
                share.Mayo,
                share.Junio,
                share.Julio,
                share.Agosto,
                share.Septiembre,
                share.Octubre,
                share.Noviembre,
                share.Diciembre,
                share.Importe);
            this.ExecuteNonQuery(query);
        }

        public void Delete(int id)
        {
            string query = string.Format("DELETE FROM share WHERE id={0}", id);
            this.ExecuteNonQuery(query);
        }

        private void ExecuteNonQuery(string query)
        {
            try
            {
                this.connection.Open();
                var command = new MySqlCommand(query, this.connection);
                command.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        public List<share> GetAll()
        {
            var result = new List<share>();
            try
            {
                var query = "Select * From share";
                this.connection.Open();
                var command = new MySqlCommand(query, this.connection);
                var dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    result.Add(new share
                    {
                        Id = dataReader.GetInt32("id"),
                        Enero = dataReader.GetInt32("Enero"),
                        Febrero = dataReader.GetInt32("Febrero"),
                        Marzo = dataReader.GetInt32("Marzo"),
                        Abril = dataReader.GetInt32("Abril"),
                        Mayo = dataReader.GetInt32("Mayo"),
                        Junio = dataReader.GetInt32("Junio"),
                        Julio = dataReader.GetInt32("Julio"),
                        Agosto = dataReader.GetInt32("Febrero"),
                        Septiembre = dataReader.GetInt32("Marzo"),
                        Octubre = dataReader.GetInt32("Abril"),
                        Noviembre = dataReader.GetInt32("Mayo"),
                        Diciembre = dataReader.GetInt32("Junio"),
                        Importe = dataReader.GetInt32("Importe")
                    });
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                this.connection.Close();
            }
            return result;
        }

    }
}
