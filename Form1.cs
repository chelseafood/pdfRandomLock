using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EY.Tax.TaxPDFHelper;
    
    
    
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string password=PDFHelper.MakeReadOnly("C:/Users/Chelsea/Documents/input1.pdf", "C:/Users/Chelsea/Documents/testfinalrandom1234.pdf");
            

        }
    }
}
