using System.Windows.Forms;
using TasksFrm.Api;
using TasksFrm.Models;

namespace TasksFrm
{
    public partial class frmMain : Form
    {
        public static User logedUser = new User ();
        public static MyTask selTask= new MyTask();
        public List<MyTask>? myTasks = new List<MyTask>();
        public string taskDesc = "";
        public static List<Comment>? taskComments = new List<Comment>();

        public frmMain()
        {
            InitializeComponent();
            setDataGrids();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //CheckLogin(); // jen pro vývoj, aby se nemuselo pøihlašovat 
            LoadData(); 
            logedUser.id = 2; // jen pro vývoj, aby se nemuselo pøihlašovat
        }

        private async void LoadData()
        {
            // Disable event handler for change selected tesk in datagrid during initial loading data
            dgvTasks.SelectionChanged -= new System.EventHandler(this.dgvTasks_SelectionChanged);

            myTasks = await ApiManager.GetTasks();
            dgvTasks.DataSource = myTasks;
            selTask = myTasks.First();

            RefreshForm();

            // Enabled handler again
            dgvTasks.SelectionChanged += new System.EventHandler(this.dgvTasks_SelectionChanged);

        }

        private void btnEditTask_Click(object sender, EventArgs e)
        {
            frmTaskDetail taskDetail = new frmTaskDetail();
            taskDetail.ShowDialog();
            dgvTasks.Refresh();
            rtbDesc.Text = selTask.description;
            //RefreshForm(); ;
        }

        private void lblLogedUser_Click(object sender, EventArgs e)
        {
            // dialog pro odhlášení
            if (MessageBox.Show("Do you want to Log Out", "Log Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                logedUser.userName = "";
                CheckLogin();
            }
        }

        private void dgvTasks_SelectionChanged(object sender, EventArgs e)
        {
            int id = Int32.Parse(dgvTasks.SelectedRows[0].Cells["Id"].Value.ToString());
            selTask = myTasks.Find(t => t.id == id);
            RefreshForm();
        }
        private void CheckLogin()
        {
            if (logedUser.userName == "")
            {
                frmLogin login = new frmLogin();
                login.ShowDialog();
            }
            if (logedUser.userName == "")
                this.Close();

            lblLogedUser.Text = logedUser.userName;
        }

        private async void RefreshForm()
        {
            rtbDesc.Text = selTask.description;
            taskComments = await ApiManager.GetComments4Taks(selTask.id);
            dgvComments.DataSource = taskComments;

            TaskButnEnable(selTask.owner.id == logedUser.id || logedUser.id == 1);
        }
        private void TaskButnEnable(Boolean enable)
        {
            btnDeleteTask.Enabled = enable;
            btnEditTask.Enabled = enable;
        }
        private void setDataGrids()
        {   
            
            dgvTasks.AutoGenerateColumns = false;
            dgvTasks.ColumnHeadersVisible = true;
            dgvTasks.EnableHeadersVisualStyles = false;
            dgvTasks.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dgvTasks.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.LightGray;
            dgvTasks.RowHeadersVisible = false;

            //Add Columns
            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            col1.Name = "Title";
            col1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            col1.DataPropertyName = "title";
            dgvTasks.Columns.Add(col1);

            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
            col2.Name = "State";
            col2.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            col2.DataPropertyName = "state";
            dgvTasks.Columns.Add(col2);

            DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn();
            col3.Name = "Owner";
            col3.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            col3.DataPropertyName = "ownerName";
            dgvTasks.Columns.Add(col3);

            DataGridViewTextBoxColumn col4 = new DataGridViewTextBoxColumn();
            col4.Name = "Id";
            col4.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            col4.DataPropertyName = "id";
            col4.Visible = false;
            dgvTasks.Columns.Add(col4);

            dgvComments.AutoGenerateColumns = false;
            dgvComments.ColumnHeadersVisible = true;
            dgvComments.EnableHeadersVisualStyles = false;
            dgvComments.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dgvComments.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.LightGray;
            dgvComments.RowHeadersVisible = false;
            //dgvComments.RowsDefaultCellStyle.SelectionBackColor = Color.White;
            dgvComments.DefaultCellStyle.SelectionBackColor = Color.White;
            dgvComments.DefaultCellStyle.SelectionForeColor = Color.Black;

            DataGridViewTextBoxColumn col11 = new DataGridViewTextBoxColumn();
            col11.Name = "Comment";
            col11.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            col11.DataPropertyName = "content";
            dgvComments.Columns.Add(col11);

            DataGridViewTextBoxColumn col12 = new DataGridViewTextBoxColumn();
            col12.Name = "User";
            col12.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            col12.DataPropertyName = "userName";
            dgvComments.Columns.Add(col12);

            DataGridViewTextBoxColumn col13 = new DataGridViewTextBoxColumn();
            col13.Name = "Created";
            col13.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            col13.DataPropertyName = "create";
            dgvComments.Columns.Add(col13);

            tableLayoutPanel1.Dock = DockStyle.Fill;
            dgvComments.Dock = DockStyle.Fill;
            dgvTasks.Dock = DockStyle.Fill;
            rtbDesc.Dock = DockStyle.Fill;
        }

    }
}