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
    public partial class ShareForm : Form
    {
        private ShareDatabaseConnection shareDatabaseConnection;
        public ShareForm()
        {
            InitializeComponent();
        }

        private void ShareForm_Load(object sender, EventArgs e)
        {
            this.shareDatabaseConnection = new ShareDatabaseConnection("SERVER=localhost;DATABASE=singlecrud;UID=root;PASSWORD=Single");
            this.dataGridView1.DataSource = this.shareDatabaseConnection.GetAll();
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            txtEnero.ReadOnly = true;
            txtFebrero.ReadOnly = true;
            txtMarzo.ReadOnly = true;
            txtAbril.ReadOnly = true;
            txtMayo.ReadOnly = true;
            txtJunio.ReadOnly = true;
            txtJulio.ReadOnly = true;
            txtAgosto.ReadOnly = true;
            txtSeptiembre.ReadOnly = true;
            txtOctubre.ReadOnly = true;
            txtNoviembre.ReadOnly = true;
            txtDiciembre.ReadOnly = true;
            txtImporte.ReadOnly = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (btnUpdate.Text == "Update")
            {
                btnUpdate.Text = "Save";
                btnDelete.Visible = false;
                txtEnero.ReadOnly = true;
                txtFebrero.ReadOnly = true;
                txtMarzo.ReadOnly = true;
                txtAbril.ReadOnly = true;
                txtMayo.ReadOnly = true;
                txtJunio.ReadOnly = true;
                txtJulio.ReadOnly = true;
                txtAgosto.ReadOnly = true;
                txtSeptiembre.ReadOnly = true;
                txtOctubre.ReadOnly = true;
                txtNoviembre.ReadOnly = true;
                txtDiciembre.ReadOnly = true;
                txtImporte.ReadOnly = true;
            }
            else
            {
                var row = dataGridView1.SelectedRows[0];
                int importe = 0;
                if (int.TryParse(txtImporte.Text, out importe))
                {
                    var share = new share // nombre del esquema Bd
                    {
                        Id = int.Parse(row.Cells[0].Value.ToString()),// celda 0
                        Enero = int.Parse(row.Cells[1].Value.ToString()),
                        Febrero = int.Parse(row.Cells[2].Value.ToString()),
                        Marzo = int.Parse(row.Cells[3].Value.ToString()),
                        Abril = int.Parse(row.Cells[4].Value.ToString()),
                        Mayo = int.Parse(row.Cells[5].Value.ToString()),
                        Junio = int.Parse(row.Cells[6].Value.ToString()),
                        Julio = int.Parse(row.Cells[7].Value.ToString()),
                        Agosto = int.Parse(row.Cells[8].Value.ToString()),
                        Septiembre = int.Parse(row.Cells[9].Value.ToString()),
                        Octubre = int.Parse(row.Cells[10].Value.ToString()),
                        Noviembre = int.Parse(row.Cells[11].Value.ToString()),
                        Diciembre = int.Parse(row.Cells[12].Value.ToString()),
                        Importe = importe // celda 13
                    };
                    this.shareDatabaseConnection.Update(share);
                    btnUpdate.Text = "Update";
                    btnDelete.Visible = true;
                    txtEnero.ReadOnly = true;
                    txtFebrero.ReadOnly = true;
                    txtMarzo.ReadOnly = true;
                    txtAbril.ReadOnly = true;
                    txtMayo.ReadOnly = true;
                    txtJunio.ReadOnly = true;
                    txtJulio.ReadOnly = true;
                    txtAgosto.ReadOnly = true;
                    txtSeptiembre.ReadOnly = true;
                    txtOctubre.ReadOnly = true;
                    txtNoviembre.ReadOnly = true;
                    txtDiciembre.ReadOnly = true;
                    txtImporte.ReadOnly = true;
                    this.dataGridView1.DataSource = this.shareDatabaseConnection.GetAll();
                }
                else
                {
                    MessageBox.Show("Cuota invalida.");
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show
                (
                string.Format("Are you sure you want to remove {0} {1} {2} {3} {3} {4} {5} {6} {7} {8} {9} {10} {11} {12} {13}",
                txtEnero.Text,
                txtFebrero.Text,
                txtMarzo.Text,
                txtAbril.Text,
                txtMayo.Text,
                txtJunio.Text,
                txtJulio.Text,
                txtAgosto.Text,
                txtSeptiembre.Text,
                txtOctubre.Text,
                txtNoviembre.Text,
                txtDiciembre.Text,
                txtImporte.Text),
                "Remove Person",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
                );

            if (dialogResult == DialogResult.Yes)
            {
                var row = dataGridView1.SelectedRows[0];
                this.shareDatabaseConnection.Delete(int.Parse(row.Cells[0].Value.ToString()));
                this.dataGridView1.DataSource = this.shareDatabaseConnection.GetAll();
                txtEnero.Text = string.Empty;
                txtFebrero.Text = string.Empty;
                txtMarzo.Text = string.Empty;
                txtAbril.Text = string.Empty;
                txtMayo.Text = string.Empty;
                txtJunio.Text = string.Empty;
                txtJulio.Text = string.Empty;
                txtAgosto.Text = string.Empty;
                txtSeptiembre.Text = string.Empty;
                txtOctubre.Text = string.Empty;
                txtNoviembre.Text = string.Empty;
                txtDiciembre.Text = string.Empty;
                txtImporte.Text = string.Empty;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dataGridView1.SelectedRows[0];
            btnUpdate.Text = "Update";
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnDelete.Visible = true;
            txtEnero.ReadOnly = true;
            txtFebrero.ReadOnly = true;
            txtMarzo.ReadOnly = true;
            txtAbril.ReadOnly = true;
            txtMayo.ReadOnly = true;
            txtJunio.ReadOnly = true;
            txtJulio.ReadOnly = true;
            txtAgosto.ReadOnly = true;
            txtSeptiembre.ReadOnly = true;
            txtOctubre.ReadOnly = true;
            txtNoviembre.ReadOnly = true;
            txtDiciembre.ReadOnly = true;
            txtImporte.ReadOnly = true;

            txtEnero.Text = row.Cells[1].Value.ToString();
            txtFebrero.Text = row.Cells[2].Value.ToString();
            txtMarzo.Text = row.Cells[3].Value.ToString();
            txtAbril.Text = row.Cells[4].Value.ToString();
            txtMayo.Text = row.Cells[5].Value.ToString();
            txtJunio.Text = row.Cells[6].Value.ToString();
            txtJulio.Text = row.Cells[7].Value.ToString();
            txtAgosto.Text = row.Cells[8].Value.ToString();
            txtSeptiembre.Text = row.Cells[9].Value.ToString();
            txtOctubre.Text = row.Cells[10].Value.ToString();
            txtNoviembre.Text = row.Cells[11].Value.ToString();
            txtDiciembre.Text = row.Cells[12].Value.ToString();
            txtImporte.Text = row.Cells[13].Value.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int enero, febrero, marzo, abril, mayo, junio, julio, agosto, septiembre, octubre, noviembre, diciembre, importe = 0;

            if (!int.TryParse(txtEnero.Text, out enero) &&
                !int.TryParse(txtFebrero.Text, out febrero) &&
                !int.TryParse(txtMarzo.Text, out marzo) &&
                !int.TryParse(txtAbril.Text, out abril) &&
                !int.TryParse(txtMayo.Text, out mayo) &&
                !int.TryParse(txtJunio.Text, out junio) &&
                !int.TryParse(txtJulio.Text, out julio) &&
                !int.TryParse(txtAgosto.Text, out agosto) &&
                !int.TryParse(txtSeptiembre.Text, out septiembre) &&
                !int.TryParse(txtOctubre.Text, out octubre) &&
                !int.TryParse(txtNoviembre.Text, out noviembre) &&
                !int.TryParse(txtDiciembre.Text, out diciembre) &&
                !int.TryParse(txtImporte.Text, out importe))
            {
                var share = new share
                {
                    Enero = enero,
                    Febrero = febrero,
                    Marzo = marzo,
                    Abril = abril,
                    Mayo = mayo,
                    Junio = junio,
                    Julio = julio,
                    Agosto = agosto,
                    Septiembre = septiembre,
                    Octubre = octubre,
                    Noviembre = noviembre,
                    Diciembre = diciembre,
                    Importe = importe
                };
                this.shareDatabaseConnection.Insert(share);
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ScreenShotForm frm = new ScreenShotForm();
            frm.Show();//  
        }
    }
}
