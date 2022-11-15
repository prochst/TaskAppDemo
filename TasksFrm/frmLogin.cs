using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using TasksFrm.Api;
using TasksFrm.Models;

namespace TasksFrm
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Validate User credentials, when match open main window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if(!CheckUserInput())
            { return; }

            try
            {
                var user = await ApiManager.VerifyUser(txbLoginName.Text, txbPassword.Text);
                if (user != null)
                {
                    frmMain.logedUser = user;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Login Failed!", "Error", MessageBoxButtons.OK ,MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnSignUp_Click(object sender, EventArgs e)
        {
            if (!CheckUserInput())
            { return; }

            try
            {
                var user = await ApiManager.RegisterUser(txbLoginName.Text, txbPassword.Text);
                if (user != null)
                {
                    MessageBox.Show("New user was registered", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmMain.logedUser = user;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Registration Failed! User exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private Boolean CheckUserInput()
        {
            if (txbLoginName.Text == "" || txbPassword.Text == "")
            {
                MessageBox.Show("Please provide UserName and Password", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            { return true; }
        }
    }
}
