using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace data_access_application
{
    public partial class Form1 : Form
    {

        Controller database;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            database = new Controller("Server = LAPTOP-1HMCDI96\\SQLEXPRESS;" +
                                      "Trusted_Connection = true;" +
                                      "Database = NorthWind;" +
                                      "User Instance = false;" +
                                      "Connection timeout = 30");
            MessageBox.Show("Connection info sent");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string count = database.getCustomerNumber();
            MessageBox.Show(count + " Users");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string result = database.getCustomerNames();
            MessageBox.Show(result);
        }
    }
}
