namespace BooksList.Forms
{
    partial class UserControlBook
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.tbComment = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvGenres = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.msGenres = new System.Windows.Forms.MenuStrip();
            this.tsmiGenreAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGenreDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvBundles = new System.Windows.Forms.DataGridView();
            this.colBundleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.msBundles = new System.Windows.Forms.MenuStrip();
            this.tsmiBundleAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBundleDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpBundles = new System.Windows.Forms.TabPage();
            this.tpGenres = new System.Windows.Forms.TabPage();
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.tsmiSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tbAuthor = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chbHave = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGenres)).BeginInit();
            this.msGenres.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBundles)).BeginInit();
            this.msBundles.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpBundles.SuspendLayout();
            this.tpGenres.SuspendLayout();
            this.msMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbName
            // 
            this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbName.Location = new System.Drawing.Point(15, 65);
            this.tbName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(253, 26);
            this.tbName.TabIndex = 1;
            this.tbName.TextChanged += new System.EventHandler(this.fieldValue_Changed);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Название";
            // 
            // cbStatus
            // 
            this.cbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Location = new System.Drawing.Point(15, 242);
            this.cbStatus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(253, 28);
            this.cbStatus.TabIndex = 4;
            this.cbStatus.SelectedIndexChanged += new System.EventHandler(this.fieldValue_Changed);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 215);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Статус";
            // 
            // dtpDate
            // 
            this.dtpDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDate.Location = new System.Drawing.Point(15, 181);
            this.dtpDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(253, 26);
            this.dtpDate.TabIndex = 3;
            this.dtpDate.ValueChanged += new System.EventHandler(this.fieldValue_Changed);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 156);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Дата";
            // 
            // tbComment
            // 
            this.tbComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbComment.Location = new System.Drawing.Point(15, 341);
            this.tbComment.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbComment.Multiline = true;
            this.tbComment.Name = "tbComment";
            this.tbComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbComment.Size = new System.Drawing.Size(253, 168);
            this.tbComment.TabIndex = 6;
            this.tbComment.TextChanged += new System.EventHandler(this.fieldValue_Changed);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 316);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Комментарий";
            // 
            // dgvGenres
            // 
            this.dgvGenres.AllowUserToAddRows = false;
            this.dgvGenres.AllowUserToDeleteRows = false;
            this.dgvGenres.AllowUserToResizeRows = false;
            this.dgvGenres.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvGenres.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGenres.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2});
            this.dgvGenres.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGenres.Location = new System.Drawing.Point(0, 34);
            this.dgvGenres.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvGenres.MultiSelect = false;
            this.dgvGenres.Name = "dgvGenres";
            this.dgvGenres.ReadOnly = true;
            this.dgvGenres.RowHeadersVisible = false;
            this.dgvGenres.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGenres.Size = new System.Drawing.Size(252, 253);
            this.dgvGenres.TabIndex = 21;
            this.dgvGenres.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGenres_CellContentDoubleClick);
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn2.HeaderText = "Жанр";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // msGenres
            // 
            this.msGenres.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.msGenres.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiGenreAdd,
            this.tsmiGenreDelete,
            this.toolStripMenuItem1});
            this.msGenres.Location = new System.Drawing.Point(0, 0);
            this.msGenres.Name = "msGenres";
            this.msGenres.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.msGenres.Size = new System.Drawing.Size(252, 34);
            this.msGenres.TabIndex = 20;
            this.msGenres.Text = "menuStrip1";
            // 
            // tsmiGenreAdd
            // 
            this.tsmiGenreAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmiGenreAdd.Image = global::BooksList.Properties.Resources.IconPlus;
            this.tsmiGenreAdd.Name = "tsmiGenreAdd";
            this.tsmiGenreAdd.Size = new System.Drawing.Size(36, 28);
            this.tsmiGenreAdd.Text = "Добавить";
            this.tsmiGenreAdd.Click += new System.EventHandler(this.tsmiGenreAdd_Click);
            // 
            // tsmiGenreDelete
            // 
            this.tsmiGenreDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmiGenreDelete.Image = global::BooksList.Properties.Resources.action_delete_sharp_thick;
            this.tsmiGenreDelete.Name = "tsmiGenreDelete";
            this.tsmiGenreDelete.Size = new System.Drawing.Size(36, 28);
            this.tsmiGenreDelete.Text = "Удалить";
            this.tsmiGenreDelete.Click += new System.EventHandler(this.tsmiGenreDelete_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(12, 28);
            // 
            // dgvBundles
            // 
            this.dgvBundles.AllowUserToAddRows = false;
            this.dgvBundles.AllowUserToDeleteRows = false;
            this.dgvBundles.AllowUserToResizeRows = false;
            this.dgvBundles.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvBundles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBundles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBundleName});
            this.dgvBundles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBundles.Location = new System.Drawing.Point(3, 37);
            this.dgvBundles.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvBundles.MultiSelect = false;
            this.dgvBundles.Name = "dgvBundles";
            this.dgvBundles.ReadOnly = true;
            this.dgvBundles.RowHeadersVisible = false;
            this.dgvBundles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBundles.Size = new System.Drawing.Size(246, 247);
            this.dgvBundles.TabIndex = 17;
            this.dgvBundles.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBundles_CellDoubleClick);
            // 
            // colBundleName
            // 
            this.colBundleName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colBundleName.DataPropertyName = "Bundle";
            this.colBundleName.HeaderText = "Набор";
            this.colBundleName.Name = "colBundleName";
            this.colBundleName.ReadOnly = true;
            // 
            // msBundles
            // 
            this.msBundles.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.msBundles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiBundleAdd,
            this.tsmiBundleDelete});
            this.msBundles.Location = new System.Drawing.Point(3, 3);
            this.msBundles.Name = "msBundles";
            this.msBundles.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.msBundles.Size = new System.Drawing.Size(246, 34);
            this.msBundles.TabIndex = 16;
            this.msBundles.Text = "menuStrip1";
            // 
            // tsmiBundleAdd
            // 
            this.tsmiBundleAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmiBundleAdd.Image = global::BooksList.Properties.Resources.IconPlus;
            this.tsmiBundleAdd.Name = "tsmiBundleAdd";
            this.tsmiBundleAdd.Size = new System.Drawing.Size(36, 28);
            this.tsmiBundleAdd.Text = "Добавить";
            this.tsmiBundleAdd.Click += new System.EventHandler(this.tsmiBundleAdd_Click);
            // 
            // tsmiBundleDelete
            // 
            this.tsmiBundleDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmiBundleDelete.Image = global::BooksList.Properties.Resources.action_delete_sharp_thick;
            this.tsmiBundleDelete.Name = "tsmiBundleDelete";
            this.tsmiBundleDelete.Size = new System.Drawing.Size(36, 28);
            this.tsmiBundleDelete.Text = "Удалить";
            this.tsmiBundleDelete.Click += new System.EventHandler(this.tsmiBundleDelete_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tpBundles);
            this.tabControl1.Controls.Add(this.tpGenres);
            this.tabControl1.Location = new System.Drawing.Point(15, 518);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(260, 320);
            this.tabControl1.TabIndex = 7;
            // 
            // tpBundles
            // 
            this.tpBundles.Controls.Add(this.dgvBundles);
            this.tpBundles.Controls.Add(this.msBundles);
            this.tpBundles.Location = new System.Drawing.Point(4, 29);
            this.tpBundles.Name = "tpBundles";
            this.tpBundles.Padding = new System.Windows.Forms.Padding(3);
            this.tpBundles.Size = new System.Drawing.Size(252, 287);
            this.tpBundles.TabIndex = 0;
            this.tpBundles.Text = "Наборы";
            this.tpBundles.UseVisualStyleBackColor = true;
            // 
            // tpGenres
            // 
            this.tpGenres.Controls.Add(this.dgvGenres);
            this.tpGenres.Controls.Add(this.msGenres);
            this.tpGenres.Location = new System.Drawing.Point(4, 29);
            this.tpGenres.Name = "tpGenres";
            this.tpGenres.Size = new System.Drawing.Size(252, 287);
            this.tpGenres.TabIndex = 2;
            this.tpGenres.Text = "Жанры";
            this.tpGenres.UseVisualStyleBackColor = true;
            // 
            // msMain
            // 
            this.msMain.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSave});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(275, 33);
            this.msMain.TabIndex = 19;
            this.msMain.Text = "menuStrip1";
            // 
            // tsmiSave
            // 
            this.tsmiSave.Image = global::BooksList.Properties.Resources.IconSave;
            this.tsmiSave.Name = "tsmiSave";
            this.tsmiSave.Size = new System.Drawing.Size(134, 29);
            this.tsmiSave.Text = "Сохранить";
            this.tsmiSave.Click += new System.EventHandler(this.btOk_Click);
            // 
            // tbAuthor
            // 
            this.tbAuthor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAuthor.Location = new System.Drawing.Point(15, 122);
            this.tbAuthor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbAuthor.Name = "tbAuthor";
            this.tbAuthor.Size = new System.Drawing.Size(253, 26);
            this.tbAuthor.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 98);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 20);
            this.label5.TabIndex = 21;
            this.label5.Text = "Автор";
            // 
            // chbHave
            // 
            this.chbHave.AutoSize = true;
            this.chbHave.Location = new System.Drawing.Point(15, 281);
            this.chbHave.Name = "chbHave";
            this.chbHave.Size = new System.Drawing.Size(114, 24);
            this.chbHave.TabIndex = 5;
            this.chbHave.Text = "В наличии";
            this.chbHave.UseVisualStyleBackColor = true;
            // 
            // UserControlBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chbHave);
            this.Controls.Add(this.tbAuthor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbComment);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.msMain);
            this.Name = "UserControlBook";
            this.Size = new System.Drawing.Size(275, 853);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGenres)).EndInit();
            this.msGenres.ResumeLayout(false);
            this.msGenres.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBundles)).EndInit();
            this.msBundles.ResumeLayout(false);
            this.msBundles.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tpBundles.ResumeLayout(false);
            this.tpBundles.PerformLayout();
            this.tpGenres.ResumeLayout(false);
            this.tpGenres.PerformLayout();
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbComment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip msBundles;
        private System.Windows.Forms.ToolStripMenuItem tsmiBundleAdd;
        private System.Windows.Forms.ToolStripMenuItem tsmiBundleDelete;
        private System.Windows.Forms.DataGridView dgvBundles;
        private System.Windows.Forms.MenuStrip msGenres;
        private System.Windows.Forms.ToolStripMenuItem tsmiGenreAdd;
        private System.Windows.Forms.ToolStripMenuItem tsmiGenreDelete;
        private System.Windows.Forms.DataGridView dgvGenres;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBundleName;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpBundles;
        private System.Windows.Forms.TabPage tpGenres;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiSave;
        private System.Windows.Forms.TextBox tbAuthor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chbHave;
    }
}
