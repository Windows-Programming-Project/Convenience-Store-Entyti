using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Convenience_Store_Entyti
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
           // userControlCustomer1.Visible = false;
           // firstUserControlEmp1.BringToFront();
        }

        private void btEmpManagement_Click(object sender, EventArgs e)
        {
            //userControlCustomer1.Visible = true;
            //firstUserControlEmp1.Visible = false;
           // userControlCustomer1.BringToFront();
        }

        private void ptbShutDown_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
