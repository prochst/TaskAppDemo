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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TasksFrm
{
    public partial class frmTaskDetail : Form
    {
        public frmTaskDetail()
        {
            InitializeComponent();
        }

        private void frmTaskDetail_Load(object sender, EventArgs e)
        {
            txbTitle.DataBindings.Add("Text", frmMain.selTask, "title", false, DataSourceUpdateMode.OnPropertyChanged);
            txbDescription.DataBindings.Add("Text", frmMain.selTask, "description", false, DataSourceUpdateMode.OnPropertyChanged);
            //cmbState.DataBindings.Add("Text", frmMain.selTask, "state", false, DataSourceUpdateMode.OnPropertyChanged);
            cmbState.DataBindings.Add(new Binding("SelectedItem", frmMain.selTask, "state"));
            cmbState.DataSource = Enum.GetValues(typeof(MyTask.MyTaskState));
            cmbState.SelectedItem = frmMain.selTask.state;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            var response = await ApiManager.UpdateTask(frmMain.selTask);
            this.Close();
        }

        private void rtbDescription_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
