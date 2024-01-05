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

namespace Cursach
{
    public partial class log_in : Form
    {

        DataBase dataBase = new DataBase();

        public log_in()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void log_in_Load(object sender, EventArgs e)
        {
            textBox_password.PasswordChar = '*';
            pictureBox2.Visible = false;
            textBox_Login.MaxLength = 30;
            textBox_password.MaxLength = 8;
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            var loginUser = textBox_Login.Text;
            var passUser = textBox_password.Text;

            SqlDataAdapter adapter= new SqlDataAdapter();
            DataTable table = new DataTable();

            string querystring = $"seletc id_user, login_user, password_user from register where login_user = '{loginUser}' and password_user = '{passUser}'";

            SqlCommand command = new SqlCommand(querystring, dataBase.getSqlConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if(table.Rows.Count == 1 ) 
            {
                MessageBox.Show("Вы успешно зашли!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information );
                Form1 form1 = new Form1();
                this.Hide();
                form1.ShowDialog();
                this.Show();
            }
            else
                MessageBox.Show("Такого аккаунта не существует!", "Аккаунта не существует!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
