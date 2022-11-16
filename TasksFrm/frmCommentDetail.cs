using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TasksFrm.Api;
using TasksFrm.Models;

namespace TasksFrm
{
    public partial class frmCommentDetail : Form
    {
        public frmCommentDetail()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (txbContent.Text != "")
            {
                Comment comment = new Comment();
                comment.userName = frmMain.logedUser.userName;
                comment.myTaskId = frmMain.selTask.id;
                comment.content = txbContent.Text;
                await ApiManager.CreateComment(comment);
                this.Close();
            }
        
        }
    }
}
