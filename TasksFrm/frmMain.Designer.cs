namespace TasksFrm
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblLogedUser = new System.Windows.Forms.Label();
            this.dgvTasks = new System.Windows.Forms.DataGridView();
            this.rtbDesc = new System.Windows.Forms.RichTextBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblComents = new System.Windows.Forms.Label();
            this.btnNewTask = new System.Windows.Forms.Button();
            this.btnDeleteTask = new System.Windows.Forms.Button();
            this.btnEditTask = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvComments = new System.Windows.Forms.DataGridView();
            this.lblTasks = new System.Windows.Forms.Label();
            this.panTaskBtn = new System.Windows.Forms.Panel();
            this.panCommBtn = new System.Windows.Forms.Panel();
            this.btnDeleteComment = new System.Windows.Forms.Button();
            this.btnAddComment = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComments)).BeginInit();
            this.panTaskBtn.SuspendLayout();
            this.panCommBtn.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblLogedUser
            // 
            this.lblLogedUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLogedUser.AutoSize = true;
            this.lblLogedUser.Location = new System.Drawing.Point(886, 27);
            this.lblLogedUser.Name = "lblLogedUser";
            this.lblLogedUser.Size = new System.Drawing.Size(77, 20);
            this.lblLogedUser.TabIndex = 0;
            this.lblLogedUser.Text = "logedUser";
            this.lblLogedUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblLogedUser.Click += new System.EventHandler(this.lblLogedUser_Click);
            // 
            // dgvTasks
            // 
            this.dgvTasks.AllowUserToAddRows = false;
            this.dgvTasks.AllowUserToDeleteRows = false;
            this.dgvTasks.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTasks.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvTasks.Location = new System.Drawing.Point(18, 78);
            this.dgvTasks.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvTasks.MultiSelect = false;
            this.dgvTasks.Name = "dgvTasks";
            this.dgvTasks.ReadOnly = true;
            this.dgvTasks.RowHeadersWidth = 51;
            this.tableLayoutPanel1.SetRowSpan(this.dgvTasks, 4);
            this.dgvTasks.RowTemplate.Height = 25;
            this.dgvTasks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTasks.Size = new System.Drawing.Size(283, 161);
            this.dgvTasks.TabIndex = 1;
            this.dgvTasks.SelectionChanged += new System.EventHandler(this.dgvTasks_SelectionChanged);
            // 
            // rtbDesc
            // 
            this.rtbDesc.Location = new System.Drawing.Point(410, 78);
            this.rtbDesc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtbDesc.Name = "rtbDesc";
            this.rtbDesc.ReadOnly = true;
            this.rtbDesc.Size = new System.Drawing.Size(326, 112);
            this.rtbDesc.TabIndex = 2;
            this.rtbDesc.Text = "";
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Location = new System.Drawing.Point(410, 54);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(114, 20);
            this.lblDesc.TabIndex = 5;
            this.lblDesc.Text = "Task description";
            // 
            // lblComents
            // 
            this.lblComents.AutoSize = true;
            this.lblComents.Location = new System.Drawing.Point(410, 243);
            this.lblComents.Name = "lblComents";
            this.lblComents.Size = new System.Drawing.Size(109, 20);
            this.lblComents.TabIndex = 6;
            this.lblComents.Text = "Task comments";
            // 
            // btnNewTask
            // 
            this.btnNewTask.Location = new System.Drawing.Point(3, 4);
            this.btnNewTask.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNewTask.Name = "btnNewTask";
            this.btnNewTask.Size = new System.Drawing.Size(86, 31);
            this.btnNewTask.TabIndex = 7;
            this.btnNewTask.Text = "New Task";
            this.btnNewTask.UseVisualStyleBackColor = true;
            this.btnNewTask.Click += new System.EventHandler(this.btnNewTask_Click);
            // 
            // btnDeleteTask
            // 
            this.btnDeleteTask.Location = new System.Drawing.Point(210, 4);
            this.btnDeleteTask.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDeleteTask.Name = "btnDeleteTask";
            this.btnDeleteTask.Size = new System.Drawing.Size(95, 31);
            this.btnDeleteTask.TabIndex = 7;
            this.btnDeleteTask.Text = "Delete Task";
            this.btnDeleteTask.UseVisualStyleBackColor = true;
            this.btnDeleteTask.Click += new System.EventHandler(this.btnDeleteTask_Click);
            // 
            // btnEditTask
            // 
            this.btnEditTask.Location = new System.Drawing.Point(105, 4);
            this.btnEditTask.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEditTask.Name = "btnEditTask";
            this.btnEditTask.Size = new System.Drawing.Size(86, 31);
            this.btnEditTask.TabIndex = 7;
            this.btnEditTask.Text = "Edit Task";
            this.btnEditTask.UseVisualStyleBackColor = true;
            this.btnEditTask.Click += new System.EventHandler(this.btnEditTask_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.Controls.Add(this.dgvComments, 3, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblDesc, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblComents, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblTasks, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.panTaskBtn, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.dgvTasks, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblLogedUser, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.rtbDesc, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.panCommBtn, 3, 7);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 169F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(982, 753);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // dgvComments
            // 
            this.dgvComments.AllowUserToAddRows = false;
            this.dgvComments.AllowUserToDeleteRows = false;
            this.dgvComments.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvComments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComments.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvComments.Location = new System.Drawing.Point(410, 267);
            this.dgvComments.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvComments.MultiSelect = false;
            this.dgvComments.Name = "dgvComments";
            this.dgvComments.ReadOnly = true;
            this.dgvComments.RowHeadersWidth = 51;
            this.dgvComments.RowTemplate.Height = 25;
            this.dgvComments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvComments.Size = new System.Drawing.Size(327, 113);
            this.dgvComments.TabIndex = 4;
            // 
            // lblTasks
            // 
            this.lblTasks.AutoSize = true;
            this.lblTasks.Location = new System.Drawing.Point(18, 54);
            this.lblTasks.Name = "lblTasks";
            this.lblTasks.Size = new System.Drawing.Size(42, 20);
            this.lblTasks.TabIndex = 6;
            this.lblTasks.Text = "Tasks";
            // 
            // panTaskBtn
            // 
            this.panTaskBtn.Controls.Add(this.btnNewTask);
            this.panTaskBtn.Controls.Add(this.btnDeleteTask);
            this.panTaskBtn.Controls.Add(this.btnEditTask);
            this.panTaskBtn.Location = new System.Drawing.Point(18, 679);
            this.panTaskBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panTaskBtn.Name = "panTaskBtn";
            this.panTaskBtn.Size = new System.Drawing.Size(310, 43);
            this.panTaskBtn.TabIndex = 8;
            // 
            // panCommBtn
            // 
            this.panCommBtn.Controls.Add(this.btnDeleteComment);
            this.panCommBtn.Controls.Add(this.btnAddComment);
            this.panCommBtn.Location = new System.Drawing.Point(410, 679);
            this.panCommBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panCommBtn.Name = "panCommBtn";
            this.panCommBtn.Size = new System.Drawing.Size(300, 43);
            this.panCommBtn.TabIndex = 9;
            // 
            // btnDeleteComment
            // 
            this.btnDeleteComment.Location = new System.Drawing.Point(135, 4);
            this.btnDeleteComment.Name = "btnDeleteComment";
            this.btnDeleteComment.Size = new System.Drawing.Size(130, 29);
            this.btnDeleteComment.TabIndex = 1;
            this.btnDeleteComment.Text = "Delete Comment";
            this.btnDeleteComment.UseVisualStyleBackColor = true;
            this.btnDeleteComment.Click += new System.EventHandler(this.btnDeleteComment_Click);
            // 
            // btnAddComment
            // 
            this.btnAddComment.Location = new System.Drawing.Point(3, 4);
            this.btnAddComment.Name = "btnAddComment";
            this.btnAddComment.Size = new System.Drawing.Size(120, 29);
            this.btnAddComment.TabIndex = 0;
            this.btnAddComment.Text = "Add Comment";
            this.btnAddComment.UseVisualStyleBackColor = true;
            this.btnAddComment.Click += new System.EventHandler(this.btnAddComment_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 753);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(860, 600);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tasks";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComments)).EndInit();
            this.panTaskBtn.ResumeLayout(false);
            this.panCommBtn.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblLogedUser;
        private DataGridView dgvTasks;
        private RichTextBox rtbDesc;
        private Label lblDesc;
        private Label lblComents;
        private Button btnNewTask;
        private Button btnDeleteTask;
        private Button btnEditTask;
        private TableLayoutPanel tableLayoutPanel1;
        private DataGridView dgvComments;
        private Label lblTasks;
        private Panel panTaskBtn;
        private Panel panCommBtn;
        private Button btnDeleteComment;
        private Button btnAddComment;
    }
}