using SingleCrud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SingleCrud
{
    public partial class AddForm : Form
    {
        private PersonDatabaseConnection personDatabaseConnection;
        public AddForm()
        {
            InitializeComponent();
        }

        private void AddForm_Load(object sender, EventArgs e)
        {
            this.personDatabaseConnection = new PersonDatabaseConnection("SERVER=localhost;DATABASE=singlecrud;UID=root;PASSWORD=Single");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if( !string.IsNullOrWhiteSpace(txtNumSocio.Text) && 
                !string.IsNullOrWhiteSpace(txtSeniorityPartner.Text) &&
                !string.IsNullOrWhiteSpace(txtTypePartner.Text) &&
                !string.IsNullOrWhiteSpace(txtShare.Text) &&
                !string.IsNullOrWhiteSpace(txtPost.Text) &&              
                !string.IsNullOrWhiteSpace(txtFirstName.Text) && 
                !string.IsNullOrWhiteSpace(txtLastName.Text) &&
                !string.IsNullOrWhiteSpace(txtDni.Text) &&
                !string.IsNullOrWhiteSpace(txtAge.Text) &&
                !string.IsNullOrWhiteSpace(txtFamilyUnity.Text) &&
                !string.IsNullOrWhiteSpace(txtHeredaSitio.Text) &&
                !string.IsNullOrWhiteSpace(txtTelefPrimary.Text) &&
                !string.IsNullOrWhiteSpace(txtTelefSecondary.Text) &&
                !string.IsNullOrWhiteSpace(txtEmail.Text) &&
                !string.IsNullOrWhiteSpace(txtLocation.Text) &&
                !string.IsNullOrWhiteSpace(txtAdress.Text)
              )
            {
                var person = new Person
                {
                    Num_Socio = Convert.ToInt32(txtNumSocio.Text),
                    Seniority_Partner = Convert.ToInt32(txtSeniorityPartner.Text),
                    Type_Partner = txtTypePartner.Text,
                    Share = Convert.ToInt32(txtShare.Text),
                    Post = txtPost.Text,
                    First_Name = txtFirstName.Text,
                    Last_Name = txtLastName.Text,
                    Dni = Convert.ToInt32(txtDni.Text),
                    Age = Convert.ToInt32(txtAge.Text),
                    Family_Unity = Convert.ToInt32(txtFamilyUnity.Text),
                    Hereda_Sitio = txtHeredaSitio.Text,
                    Telef_Primary = Convert.ToInt32(txtTelefPrimary.Text),
                    Telef_Secondary = Convert.ToInt32(txtTelefSecondary.Text),
                    Email = txtEmail.Text,
                    Location = txtLocation.Text,
                    Adress = txtAdress.Text,
                };
                this.personDatabaseConnection.Insert(person);
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid inputs.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtLocation_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtShare_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ScreenShotForm frm = new ScreenShotForm();
            frm.Show();//  
        }
    }
}
