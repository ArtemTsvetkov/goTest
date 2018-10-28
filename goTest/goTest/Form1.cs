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
using goTest.SecurityComponent.Encryption.Realization;

namespace goTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            EncryptWorker a = new EncryptWorker();
            string en_text = a.encrypt("testiiiiiiiiiiii");
            string de_text = a.decrypt(en_text);
        }
    }
}
