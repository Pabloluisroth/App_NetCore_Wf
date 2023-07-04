using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SingleCrud
{
    public class PersonDatabaseConnection
    {
        private MySqlConnection connection;

        public PersonDatabaseConnection(string connectionString)
        {
            this.connection = new MySqlConnection(connectionString);
        }

        public void Insert(Person person)
        {       
            string query = string.Format("INSERT INTO person (" +
                " Num_Socio, "      +
                " Antiguedad, "     +
                " Tipo_Socio, "     +
                " Cuota, "          +
                " Cargo, "          +
                " Nombre,"          +
                " Apellido,"        +
                " Dni,"             +
                " Edad,"            +
                " Unidad_Familiar,"  +
                " Hereda_Sitio,"    +
                " Telef_Principal," +
                " Telef_Secundario,"+
                " email, "          +
                " Localidad, "      +
                " Direccion, "      +
                " ) " +
                "VALUES('{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}')",
                person.Num_Socio, 
                person.Seniority_Partner, 
                person.Type_Partner,
                person.Share,
                person.Post,
                person.First_Name, 
                person.Last_Name,
                person.Dni,
                person.Age, 
                person.Family_Unity,
                person.Hereda_Sitio,
                person.Telef_Primary, 
                person.Telef_Secondary, 
                person.Email, 
                person.Location, 
                person.Adress 
                );
            this.ExecuteNonQuery(query);
        }
        
        public void Update(Person person)
        {
            string query = string.Format("UPDATE person SET " +
                " NumSocio         = '{1}',"   +
                " Antiguedad       = '{2}',"   +
                " Tipo_Socio       = '{3}',"   +
                " Cuota            = '{4}',"   +
                " Cargo            = '{5}',"   +
                " Nombre           = '{6}',"   +
                " Apellido         = '{7}',"   +
                " Dni              = '{8}',"   +   
                " Edad             = '{9}',"   +
                " Unidad_Familiar  = '{10}',"  +
                " Hereda_Sitio     = '{11}',"  +
                " Telef_Principal  = '{12}',"  +
                " Telef_Secundario = '{13}',"  +
                " email            = '{14}',"  +
                " localidad        = '{15}',"  +
                " Direccion        = '{16}',"  +
                " WHERE Id         = '{0}'", 
                person.Num_Socio, 
                person.Seniority_Partner, 
                person.Type_Partner,
                person.Share,
                person.Post,
                person.First_Name, 
                person.Last_Name,
                person.Dni,
                person.Age, 
                person.Family_Unity,
                person.Hereda_Sitio,
                person.Telef_Primary, 
                person.Telef_Secondary, 
                person.Email, 
                person.Location,
                person.Adress);
            this.ExecuteNonQuery(query);
        }

        public void Delete(int id)
        {
            string query = string.Format("DELETE FROM person WHERE id={0}", id);
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

        public List<Person> GetAll()
        {
            var result = new List<Person>();
            try
            {
                var query = "Select * From person";
                this.connection.Open();
                var command = new MySqlCommand(query, this.connection);
                var dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    result.Add(new Person
                    {
                        Id = dataReader.GetInt32("Id"),
                        Num_Socio = dataReader.GetInt32("Num_Socio"),
                        Seniority_Partner = dataReader.GetInt32("Antiguedad"),
                        Type_Partner = dataReader.GetString("Tipo_Socio"),
                        Share = dataReader.GetInt32("Cuota"),
                        Post = dataReader.GetString("Cargo"),
                        First_Name = dataReader.GetString("Nombre"),
                        Last_Name = dataReader.GetString("Apellido"),
                        Dni = dataReader.GetInt32("Dni"),
                        Age = dataReader.GetInt32("Edad"),
                        Family_Unity = dataReader.GetInt32("Unidad_Familiar"),
                        Hereda_Sitio = dataReader.GetString("Hereda sitio"),                  
                        Telef_Primary = dataReader.GetInt32("Telef_Principal"),
                        Telef_Secondary = dataReader.GetInt32("Telef_Secundario"),
                        Email = dataReader.GetString("Email"),
                        Location = dataReader.GetString("Localidad"),
                        Adress = dataReader.GetString("Direccion")
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

        public List<Person> GetId() // Busqueda por ID
        {
            var result = new List<Person>();
            try
            {
                var query = "SELECT * FROM `person` WHERE `id` LIKE '%{0}%'";
                this.connection.Open();
                var command = new MySqlCommand(query, this.connection);
                var dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    result.Add(new Person
                    {
                        Id = dataReader.GetInt32("id"),
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

        public List<Person> GetNumSocio() // Busqueda por Numero de socio
        {
            var result = new List<Person>();
            try
            {
                var query = "SELECT * FROM `person` WHERE `Num_Socio` LIKE '%{0}%'";
                this.connection.Open();
                var command = new MySqlCommand(query, this.connection);
                var dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    result.Add(new Person
                    {
                        Num_Socio = dataReader.GetInt32("Num_Socio"),
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
     
        public List<Person> GetHereda_Sitio() // Busqueda por Persona que herda la plaza de socio
        {
            var result = new List<Person>();
            try
            {
                var query = "SELECT * FROM `person` WHERE `Hereda_Sitio` LIKE '%{0}%'"; 
                this.connection.Open();
                var command = new MySqlCommand(query, this.connection);
                var dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    result.Add(new Person
                    {
                        Hereda_Sitio = dataReader.GetString("Hereda_Sitio"),
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

        public List<Person> GetFirstName() // Busqueda por Nombre de socio
        {
            var result = new List<Person>();
            try
            {
                var query = "SELECT * FROM `person` WHERE `Nombre` LIKE '%{0}%'";
                this.connection.Open();
                var command = new MySqlCommand(query, this.connection);
                var dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    result.Add(new Person
                    {
                        First_Name = dataReader.GetString("Nombre"),
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

        public List<Person> GetEmail() // Busqueda por Email
        {
            var result = new List<Person>();
            try
            {
                var query = "SELECT * FROM `person` WHERE `Email` LIKE '%{0}%'";
                this.connection.Open();
                var command = new MySqlCommand(query, this.connection);
                var dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    result.Add(new Person
                    {
                        Email = dataReader.GetString("Email"),
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
