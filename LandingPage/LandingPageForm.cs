using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LandingPage
{
    public partial class LandingPageForm : Form
    {
        public LandingPageForm()
        {
            InitializeComponent();
        }

        private void LandingPageForm_Load(object sender, EventArgs e)
        {

        }

        private void LandingPageRegister_Click(object sender, EventArgs e)
        {
            //Redirect button to registrationpage 
            MessageBox.Show("Under development");
        }

        private void LandingPageLogin_Click(object sender, EventArgs e)
        {
            //Redirect button to registrationpage 

            System.LoginForm LoginForm = new Login.LoginForm();
            LoginForm.Tag = this;
            LoginForm.Show(this);
            Hide();
        }
    }
}
