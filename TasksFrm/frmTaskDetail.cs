using TasksFrm.Api;
using TasksFrm.Models;

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
            // bind form controls to datasource - selected task in frmMain
            txbTitle.DataBindings.Add("Text", frmMain.selTask, "title", false, DataSourceUpdateMode.OnPropertyChanged);
            txbDescription.DataBindings.Add("Text", frmMain.selTask, "description", false, DataSourceUpdateMode.OnPropertyChanged);
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
            if (frmMain.selTask.id == 0)
                frmMain.selTask = await ApiManager.CreateTask(frmMain.selTask);
            else
                frmMain.selTask = await ApiManager.UpdateTask(frmMain.selTask);

            this.Close();
        }
    }
}
