using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using TasksFrm.Api;
using TasksFrm.Models;

namespace TasksFrm
{
    public partial class frmMain : Form
    {
        public static User logedUser = new User();
        public static MyTask selTask = new MyTask();
        public List<MyTask>? myTasks = new List<MyTask>();
        public BindingSource bsMyTasks = new BindingSource();
        public string taskDesc = "";
        public static List<Comment>? taskComments = new List<Comment>();
        public static Comment selComment = new Comment();


        public frmMain()
        {
            InitializeComponent();
            setDataGrids();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //CheckLogin(); // jen pro vývoj, aby se nemuselo pøihlašovat 
            logedUser.userName = "admin"; // jen pro vývoj, aby se nemuselo pøihlašovat
            LoadData();
        }

        private void btnEditTask_Click(object sender, EventArgs e)
        {
            frmTaskDetail taskDetail = new frmTaskDetail();
            taskDetail.ShowDialog();
            // remove task from datasource if state is changed to "deleted"
            if (selTask.state == MyTask.MyTaskState.Deleted)
            {
                myTasks.RemoveAll(t => t.id == selTask.id);
                bsMyTasks.ResetBindings(false);
            }
            dgvTasks.Refresh();
            rtbDesc.Text = selTask.description;
            //RefreshForm(); ;
        }

        private void btnNewTask_Click(object sender, EventArgs e)
        {
            selTask = new MyTask { title = "", description = "", owner = logedUser.userName, state = MyTask.MyTaskState.New };
            frmTaskDetail taskDetail = new frmTaskDetail();
            taskDetail.ShowDialog();
            // add new task to datasource
            myTasks.Add(selTask);
            bsMyTasks.ResetBindings(false);
            dgvTasks.Refresh();
            rtbDesc.Text = selTask.description;
            // select created row in datagrid (last row)
            dgvTasks.Rows[dgvTasks.Rows.Count - 1].Selected = true;
            // scroll datagrid to end
            dgvTasks.FirstDisplayedScrollingRowIndex = dgvTasks.Rows.Count - 1;
        }

        private async void btnDeleteTask_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete task?", "Delete Task", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // remove task from datasource
                myTasks.Remove(selTask);
                frmMain.selTask = await ApiManager.DeleteTask(frmMain.selTask);
                bsMyTasks.ResetBindings(false);
                dgvTasks.Refresh();
            }
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

        private async void btnDeleteComment_Click(object sender, EventArgs e)
        {
            if (dgvComments.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Do you want to delete comment?", "Delete Comment", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Int32.Parse(dgvComments.SelectedRows[0].Cells["Id"].Value.ToString());
                    selComment = taskComments.Find(t => t.id == id);
                    await ApiManager.DeleteComment(selComment);
                    RefreshForm();
                }
            }
            else
                MessageBox.Show("You need select the comment you want delete!", "Select Comment", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnAddComment_Click(object sender, EventArgs e)
        {
            frmCommentDetail commentDetail = new frmCommentDetail();
            commentDetail.ShowDialog();
            RefreshForm();
        }

        private void dgvTasks_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTasks.SelectedRows.Count > 0)
            {
                int id = Int32.Parse(dgvTasks.SelectedRows[0].Cells["Id"].Value.ToString());
                selTask = myTasks.Find(t => t.id == id);
                RefreshForm();
            }
        }

        /// <summary>
        /// Initial load data from server
        /// </summary>
        private async void LoadData()
        {
            // Disable event handler for change selected tesk in datagrid during initial loading data
            dgvTasks.SelectionChanged -= new System.EventHandler(this.dgvTasks_SelectionChanged);

            if (logedUser.userName == "admin")
                myTasks = await ApiManager.GetTasks(true);
            else
                myTasks = await ApiManager.GetTasks();
            bsMyTasks.DataSource = myTasks;
            dgvTasks.DataSource = bsMyTasks;
            selTask = myTasks.First();

            RefreshForm();

            // Enabled handler again
            dgvTasks.SelectionChanged += new System.EventHandler(this.dgvTasks_SelectionChanged);

        }
        /// <summary>
        /// Show dialog for login
        /// </summary>
        private void CheckLogin()
        {
            if (logedUser.userName == "")
            {
                frmLogin login = new frmLogin();
                login.ShowDialog();
            }
            // if close dialog witout login, close application
            if (logedUser.userName == "")
                this.Close();

            lblLogedUser.Text = logedUser.userName;
        }

        /// <summary>
        /// Referesh conencted controls according selected task
        /// </summary>
        private async void RefreshForm()
        {
            rtbDesc.Text = selTask.description;
            taskComments = await ApiManager.GetComments4Taks(selTask.id);
            dgvComments.DataSource = taskComments;
            dgvComments.ClearSelection();
            TaskButnEnable();
        }
        /// <summary>
        /// Set buttons for edit and delete according loged user
        /// admin can edit everthing and can delete tasks and comments
        /// other user can edit only their tasks
        /// </summary>
        private void TaskButnEnable()
        {
            btnDeleteTask.Visible = (logedUser.userName == "admin");
            btnDeleteComment.Visible = (logedUser.userName == "admin");
            btnEditTask.Enabled = (selTask.owner == logedUser.userName || logedUser.userName == "admin");
        }
        /// <summary>
        /// Set columns and display properties for datadrids
        /// </summary>
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
            col3.DataPropertyName = "owner";
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
            //dgvComments.DefaultCellStyle.SelectionBackColor = Color.White;
            //dgvComments.DefaultCellStyle.SelectionForeColor = Color.Black;

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

            DataGridViewTextBoxColumn col14 = new DataGridViewTextBoxColumn();
            col14.Name = "Id";
            col14.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            col14.DataPropertyName = "id";
            col14.Visible = false;
            dgvComments.Columns.Add(col14);

            tableLayoutPanel1.Dock = DockStyle.Fill;
            dgvComments.Dock = DockStyle.Fill;
            dgvTasks.Dock = DockStyle.Fill;
            rtbDesc.Dock = DockStyle.Fill;
        }
    }
}