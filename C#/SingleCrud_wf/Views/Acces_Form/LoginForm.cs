using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Reflection;

namespace SingleCrud
{
    public partial class LoginForm : Form
    {
        MySqlConnection con = null;
        int i;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            con = new MySqlConnection("SERVER=localhost;DATABASE=singlecrud;UID=root;PASSWORD=Single");
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            RegisterForm fm = new RegisterForm();
            fm.ShowDialog();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            i = 0;
            con.Open();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from loginform where username='" + UsernameBox.Text + "' and password ='" + PasswordBox.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());

            if (i == 0)
            {
                MessageBox.Show("Nombre de usuario o contraseña incorrectos.");
                
            }
            else
            {

                this.Close();
                FormPrincipal fm = new FormPrincipal();// llamar a mi inicio del programa
                fm.Show();
            }
            con.Close();
            
        }

       
    }
}
