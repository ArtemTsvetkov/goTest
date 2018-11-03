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
using goTest.CommonComponents.DataConverters.Realization;
using goTest.CommonComponents.InitialyzerComponent;

namespace goTest
{
    public partial class Form1 : Form
    {
        private InitComponents iniComponents;

        public Form1()
        {
            InitializeComponent();
            //Init
            iniComponents = new InitComponents();
            Initialyzer init = new Initialyzer(iniComponents, this);
            init.init();
        }

        public TabControl tabControl1Elem
        {
            get { return tabControl1; }
        }

        public TextBox textBox2Elem
        {
            get { return textBox2Elem; }
        }
    }
}
