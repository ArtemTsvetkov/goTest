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

namespace goTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GeneralConverter converter = new GeneralConverter();
            EncryptConfig conf = new EncryptConfig(new byte[]{0x7c,0x26,0xf0,0xc6,0x77,
                0xaa,0xba,0x6a,0x66,0x7b,0x56,0x0f,0x98,0x43,0xba,0x2d,0xbb,0x06,0x0a,0xef,
                0xad,0x32,0x88,0xb0,0x5d,0xfb,0xfe,0x98,0xa7,0xa7,0xa5,0x1a});
            EncryptWorker a = new EncryptWorker();
            a.setConfig(conf);
            string original = "Hellow, world!";
            string originalInEncript = a.encrypt(original);
            string originalInDecript = a.decrypt(originalInEncript);

            string originalRus = "Привет, мир!";
            string originalInEncriptRus = a.encrypt(originalRus);
            string originalInDecriptRus = a.decrypt(originalInEncriptRus);
            int test = 0;
        }
    }
}
