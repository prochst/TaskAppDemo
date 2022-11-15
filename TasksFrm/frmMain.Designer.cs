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
            this.btnNewComment = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvComments = new System.Windows.Forms.DataGridView();
            this.lblTasks = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComments)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblLogedUser
            // 
            this.lblLogedUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLogedUser.AutoSize = true;
            this.lblLogedUser.Location = new System.Drawing.Point(701, 20);
            this.lblLogedUser.Name = "lblLogedUser";
            this.lblLogedUser.Size = new System.Drawing.Size(60, 15);
            this.lblLogedUser.TabIndex = 0;
            this.lblLogedUser.Text = "logedUser";
            this.lblLogedUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblLogedUser.Click += new System.EventHandler(this.lblLogedUser_Click);
            // 
            // dgvTasks
            // 
            this.dgvTasks.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTasks.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvTasks.Location = new System.Drawing.Point(23, 58);
            this.dgvTasks.MultiSelect = false;
            this.dgvTasks.Name = "dgvTasks";
            this.dgvTasks.ReadOnly = true;
            this.tableLayoutPanel1.SetRowSpan(this.dgvTasks, 4);
            this.dgvTasks.RowTemplate.Height = 25;
            this.dgvTasks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTasks.Size = new System.Drawing.Size(356, 121);
            this.dgvTasks.TabIndex = 1;
            this.dgvTasks.SelectionChanged += new System.EventHandler(this.dgvTasks_SelectionChanged);
            // 
            // rtbDesc
            // 
            this.rtbDesc.Location = new System.Drawing.Point(405, 58);
            this.rtbDesc.Name = "rtbDesc";
            this.rtbDesc.Size = new System.Drawing.Size(286, 85);
            this.rtbDesc.TabIndex = 2;
            this.rtbDesc.Text = "";
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Location = new System.Drawing.Point(405, 40);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(91, 15);
            this.lblDesc.TabIndex = 5;
            this.lblDesc.Text = "Task description";
            // 
            // lblComents
            // 
            this.lblComents.AutoSize = true;
            this.lblComents.Location = new System.Drawing.Point(405, 182);
            this.lblComents.Name = "lblComents";
            this.lblComents.Size = new System.Drawing.Size(89, 15);
            this.lblComents.TabIndex = 6;
            this.lblComents.Text = "Task comments";
            // 
            // btnNewTask
            // 
            this.btnNewTask.Location = new System.Drawing.Point(3, 3);
            this.btnNewTask.Name = "btnNewTask";
            this.btnNewTask.Size = new System.Drawing.Size(75, 23);
            this.btnNewTask.TabIndex = 7;
            this.btnNewTask.Text = "New Task";
            this.btnNewTask.UseVisualStyleBackColor = true;
            // 
            // btnDeleteTask
            // 
            this.btnDeleteTask.Location = new System.Drawing.Point(199, 3);
            this.btnDeleteTask.Name = "btnDeleteTask";
            this.btnDeleteTask.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteTask.TabIndex = 7;
            this.btnDeleteTask.Text = "Delete Task";
            this.btnDeleteTask.UseVisualStyleBackColor = true;
            // 
            // btnEditTask
            // 
            this.btnEditTask.Location = new System.Drawing.Point(101, 3);
            this.btnEditTask.Name = "btnEditTask";
            this.btnEditTask.Size = new System.Drawing.Size(75, 23);
            this.btnEditTask.TabIndex = 7;
            this.btnEditTask.Text = "Edit Task";
            this.btnEditTask.UseVisualStyleBackColor = true;
            this.btnEditTask.Click += new System.EventHandler(this.btnEditTask_Click);
            // 
            // btnNewComment
            // 
            this.btnNewComment.Location = new System.Drawing.Point(405, 506);
            this.btnNewComment.Name = "btnNewComment";
            this.btnNewComment.Size = new System.Drawing.Size(109, 23);
            this.btnNewComment.TabIndex = 7;
            this.btnNewComment.Text = "New Comment";
            this.btnNewComment.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.dgvComments, 3, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblDesc, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnNewComment, 3, 7);
            this.tableLayoutPanel1.Controls.Add(this.lblComents, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblTasks, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.dgvTasks, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblLogedUser, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.rtbDesc, 3, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 127F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(784, 561);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // dgvComments
            // 
            this.dgvComments.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvComments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComments.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvComments.Location = new System.Drawing.Point(405, 200);
            this.dgvComments.MultiSelect = false;
            this.dgvComments.Name = "dgvComments";
            this.dgvComments.ReadOnly = true;
            this.dgvComments.RowTemplate.Height = 25;
            this.dgvComments.Size = new System.Drawing.Size(286, 85);
            this.dgvComments.TabIndex = 4;
            // 
            // lblTasks
            // 
            this.lblTasks.AutoSize = true;
            this.lblTasks.Location = new System.Drawing.Point(23, 40);
            this.lblTasks.Name = "lblTasks";
            this.lblTasks.Size = new System.Drawing.Size(34, 15);
            this.lblTasks.TabIndex = 6;
            this.lblTasks.Text = "Tasks";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnNewTask);
            this.panel1.Controls.Add(this.btnDeleteTask);
            this.panel1.Controls.Add(this.btnEditTask);
            this.panel1.Location = new System.Drawing.Point(23, 506);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(356, 32);
            this.panel1.TabIndex = 8;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tasks";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComments)).EndInit();
            this.panel1.ResumeLayout(false);
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
        private Button btnNewComment;
        private TableLayoutPanel tableLayoutPanel1;
        private DataGridView dgvComments;
        private Label lblTasks;
        private Panel panel1;
    }
}