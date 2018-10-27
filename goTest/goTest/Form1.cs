using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace goTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SQLiteConnection conn = new SQLiteConnection(@"Data Source=filename.db; Version=3;");
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {

                }
                SQLiteDataAdapter adapt = new SQLiteDataAdapter("select * from test", conn);
                DataSet ds = new DataSet();
                adapt.Fill(ds);
                int id = int.Parse(ds.Tables[0].Rows[0].ItemArray[0].ToString());
                string name = ds.Tables[0].Rows[0].ItemArray[1].ToString();
                int dfs = 0;
            }
            catch(Exception ex)
            {
                int fsf =0;
            }
        }
    }
}
