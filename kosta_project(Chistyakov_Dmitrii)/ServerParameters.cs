using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace kosta_project_Chistyakov_Dmitrii_
{
    public partial class ServerParameters : Form
    {
        public ServerParameters()
        {
            InitializeComponent();
            textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckEnter);
            textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckEnter);
        }
        private void CheckEnter(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MainProgram program = new MainProgram();
            program.DataSourceMain = textBox1.Text;
            program.InitialCatalogMain = textBox2.Text;
            try
            {
                string connStr = $"Data Source={program.DataSourceMain};Initial Catalog={program.InitialCatalogMain};Integrated Security=true;";

                SqlConnection myConnection = new SqlConnection(connStr);

                myConnection.Open();

                myConnection.Close();

                Hide();
                program.ShowDialog();
                Close();
            }
            catch
            {
                DialogResult error = MessageBox.Show(
        "Соединение не было установлено. Проверьте правильность введённых данных",
        "Ошибка соединения",
        MessageBoxButtons.OK,
        MessageBoxIcon.Information,
        MessageBoxDefaultButton.Button1,
        MessageBoxOptions.DefaultDesktopOnly);
            }
        }
    }
}
