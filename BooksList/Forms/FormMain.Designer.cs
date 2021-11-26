namespace BooksList.Forms
{
    partial class FormMain
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.dgvGroups = new System.Windows.Forms.DataGridView();
            this.colBundleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.msGroups = new System.Windows.Forms.MenuStrip();
            this.tscbGroup = new System.Windows.Forms.ToolStripComboBox();
            this.dgvBooks = new System.Windows.Forms.DataGridView();
            this.colBookName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBookAuthor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBookDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBookHave = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colBookStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBookNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsGames = new System.Windows.Forms.ToolStrip();
            this.tssBookMove = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tstbFilter = new System.Windows.Forms.ToolStripTextBox();
            this.tscbSort = new System.Windows.Forms.ToolStripComboBox();
            this.ssGames = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslBooksCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslReadyBooksCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.pEmpty = new System.Windows.Forms.Panel();
            this.pLeft = new System.Windows.Forms.Panel();
            this.pRight = new System.Windows.Forms.Panel();
            this.tsbGameAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbGameEdit = new System.Windows.Forms.ToolStripButton();
            this.tsbGameDelete = new System.Windows.Forms.ToolStripButton();
            this.tsbBookUp = new System.Windows.Forms.ToolStripButton();
            this.tsbBookDown = new System.Windows.Forms.ToolStripButton();
            this.tsbBookNumber = new System.Windows.Forms.ToolStripButton();
            this.tsbBookStarted = new System.Windows.Forms.ToolStripButton();
            this.tslFilterIcon = new System.Windows.Forms.ToolStripLabel();
            this.tsbBuyList = new System.Windows.Forms.ToolStripButton();
            this.tsmiGroupAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGroupEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGroupDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.ucBook = new BooksList.Forms.UserControlBook();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroups)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.msGroups.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).BeginInit();
            this.tsGames.SuspendLayout();
            this.ssGames.SuspendLayout();
            this.pLeft.SuspendLayout();
            this.pRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvGroups
            // 
            this.dgvGroups.AllowUserToAddRows = false;
            this.dgvGroups.AllowUserToDeleteRows = false;
            this.dgvGroups.AllowUserToResizeRows = false;
            this.dgvGroups.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGroups.ColumnHeadersVisible = false;
            this.dgvGroups.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBundleName});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvGroups.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGroups.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvGroups.Location = new System.Drawing.Point(0, 39);
            this.dgvGroups.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvGroups.MultiSelect = false;
            this.dgvGroups.Name = "dgvGroups";
            this.dgvGroups.ReadOnly = true;
            this.dgvGroups.RowHeadersVisible = false;
            this.dgvGroups.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGroups.Size = new System.Drawing.Size(315, 848);
            this.dgvGroups.TabIndex = 1;
            this.dgvGroups.SelectionChanged += new System.EventHandler(this.dgvGroups_SelectionChanged);
            // 
            // colBundleName
            // 
            this.colBundleName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colBundleName.DataPropertyName = "Name";
            this.colBundleName.HeaderText = "Название";
            this.colBundleName.Name = "colBundleName";
            this.colBundleName.ReadOnly = true;
            // 
            // chart
            // 
            chartArea2.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea2);
            this.chart.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.chart.Location = new System.Drawing.Point(0, 887);
            this.chart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chart.Name = "chart";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Name = "Series1";
            this.chart.Series.Add(series2);
            this.chart.Size = new System.Drawing.Size(315, 305);
            this.chart.TabIndex = 2;
            this.chart.Click += new System.EventHandler(this.chart_Click);
            // 
            // msGroups
            // 
            this.msGroups.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.msGroups.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tscbGroup,
            this.tsmiGroupAdd,
            this.tsmiGroupEdit,
            this.tsmiGroupDelete});
            this.msGroups.Location = new System.Drawing.Point(0, 0);
            this.msGroups.Name = "msGroups";
            this.msGroups.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.msGroups.Size = new System.Drawing.Size(315, 39);
            this.msGroups.TabIndex = 0;
            this.msGroups.Text = "menuStrip1";
            // 
            // tscbGroup
            // 
            this.tscbGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscbGroup.Items.AddRange(new object[] {
            "Наборы",
            "Жанры"});
            this.tscbGroup.Name = "tscbGroup";
            this.tscbGroup.Size = new System.Drawing.Size(180, 33);
            this.tscbGroup.SelectedIndexChanged += new System.EventHandler(this.TscbGroup_SelectedIndexChanged);
            // 
            // dgvBooks
            // 
            this.dgvBooks.AllowUserToAddRows = false;
            this.dgvBooks.AllowUserToDeleteRows = false;
            this.dgvBooks.AllowUserToResizeRows = false;
            this.dgvBooks.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBooks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBookName,
            this.colBookAuthor,
            this.colBookDate,
            this.colBookHave,
            this.colBookStatus,
            this.colBookNumber});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBooks.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvBooks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBooks.Location = new System.Drawing.Point(315, 33);
            this.dgvBooks.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvBooks.MultiSelect = false;
            this.dgvBooks.Name = "dgvBooks";
            this.dgvBooks.ReadOnly = true;
            this.dgvBooks.RowHeadersVisible = false;
            this.dgvBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBooks.Size = new System.Drawing.Size(1177, 1129);
            this.dgvBooks.TabIndex = 0;
            this.dgvBooks.SelectionChanged += new System.EventHandler(this.dgvBooks_SelectionChanged);
            // 
            // colBookName
            // 
            this.colBookName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colBookName.DataPropertyName = "Name";
            this.colBookName.HeaderText = "Название";
            this.colBookName.Name = "colBookName";
            this.colBookName.ReadOnly = true;
            // 
            // colBookAuthor
            // 
            this.colBookAuthor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colBookAuthor.DataPropertyName = "Author";
            this.colBookAuthor.FillWeight = 50F;
            this.colBookAuthor.HeaderText = "Автор";
            this.colBookAuthor.Name = "colBookAuthor";
            this.colBookAuthor.ReadOnly = true;
            // 
            // colBookDate
            // 
            this.colBookDate.DataPropertyName = "Date";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colBookDate.DefaultCellStyle = dataGridViewCellStyle5;
            this.colBookDate.HeaderText = "Дата";
            this.colBookDate.Name = "colBookDate";
            this.colBookDate.ReadOnly = true;
            // 
            // colBookHave
            // 
            this.colBookHave.DataPropertyName = "Have";
            this.colBookHave.HeaderText = "В наличии";
            this.colBookHave.Name = "colBookHave";
            this.colBookHave.ReadOnly = true;
            this.colBookHave.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colBookHave.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colBookHave.Width = 65;
            // 
            // colBookStatus
            // 
            this.colBookStatus.DataPropertyName = "Status";
            this.colBookStatus.HeaderText = "Статус";
            this.colBookStatus.Name = "colBookStatus";
            this.colBookStatus.ReadOnly = true;
            this.colBookStatus.Width = 90;
            // 
            // colBookNumber
            // 
            this.colBookNumber.DataPropertyName = "Number";
            this.colBookNumber.HeaderText = "Номер";
            this.colBookNumber.Name = "colBookNumber";
            this.colBookNumber.ReadOnly = true;
            this.colBookNumber.Visible = false;
            this.colBookNumber.Width = 50;
            // 
            // tsGames
            // 
            this.tsGames.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsGames.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.tsGames.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbGameAdd,
            this.tsbGameEdit,
            this.tsbGameDelete,
            this.tssBookMove,
            this.tsbBookUp,
            this.tsbBookDown,
            this.tsbBookNumber,
            this.toolStripSeparator2,
            this.tsbBookStarted,
            this.tstbFilter,
            this.tslFilterIcon,
            this.tsbBuyList,
            this.tscbSort});
            this.tsGames.Location = new System.Drawing.Point(315, 0);
            this.tsGames.Name = "tsGames";
            this.tsGames.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.tsGames.Size = new System.Drawing.Size(1177, 33);
            this.tsGames.TabIndex = 3;
            this.tsGames.Text = "toolStrip1";
            // 
            // tssBookMove
            // 
            this.tssBookMove.Name = "tssBookMove";
            this.tssBookMove.Size = new System.Drawing.Size(6, 33);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 33);
            // 
            // tstbFilter
            // 
            this.tstbFilter.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tstbFilter.Name = "tstbFilter";
            this.tstbFilter.Size = new System.Drawing.Size(148, 33);
            this.tstbFilter.ToolTipText = "Фильтр";
            this.tstbFilter.TextChanged += new System.EventHandler(this.tstbFilter_TextChanged);
            // 
            // tscbSort
            // 
            this.tscbSort.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tscbSort.Items.AddRange(new object[] {
            "По дате",
            "По названию",
            "По автору"});
            this.tscbSort.Name = "tscbSort";
            this.tscbSort.Size = new System.Drawing.Size(121, 33);
            // 
            // ssGames
            // 
            this.ssGames.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.ssGames.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tsslBooksCount,
            this.toolStripStatusLabel2,
            this.tsslReadyBooksCount});
            this.ssGames.Location = new System.Drawing.Point(315, 1162);
            this.ssGames.Name = "ssGames";
            this.ssGames.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.ssGames.Size = new System.Drawing.Size(1177, 30);
            this.ssGames.SizingGrip = false;
            this.ssGames.TabIndex = 2;
            this.ssGames.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(61, 25);
            this.toolStripStatusLabel1.Text = "Всего:";
            // 
            // tsslBooksCount
            // 
            this.tsslBooksCount.Name = "tsslBooksCount";
            this.tsslBooksCount.Size = new System.Drawing.Size(0, 25);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(84, 25);
            this.toolStripStatusLabel2.Text = "Готовых:";
            // 
            // tsslReadyBooksCount
            // 
            this.tsslReadyBooksCount.Name = "tsslReadyBooksCount";
            this.tsslReadyBooksCount.Size = new System.Drawing.Size(0, 25);
            // 
            // pEmpty
            // 
            this.pEmpty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pEmpty.Location = new System.Drawing.Point(0, 0);
            this.pEmpty.Name = "pEmpty";
            this.pEmpty.Size = new System.Drawing.Size(364, 1192);
            this.pEmpty.TabIndex = 1;
            // 
            // pLeft
            // 
            this.pLeft.Controls.Add(this.dgvGroups);
            this.pLeft.Controls.Add(this.msGroups);
            this.pLeft.Controls.Add(this.chart);
            this.pLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pLeft.Location = new System.Drawing.Point(0, 0);
            this.pLeft.Name = "pLeft";
            this.pLeft.Size = new System.Drawing.Size(315, 1192);
            this.pLeft.TabIndex = 2;
            // 
            // pRight
            // 
            this.pRight.Controls.Add(this.ucBook);
            this.pRight.Controls.Add(this.pEmpty);
            this.pRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pRight.Location = new System.Drawing.Point(1492, 0);
            this.pRight.Name = "pRight";
            this.pRight.Size = new System.Drawing.Size(364, 1192);
            this.pRight.TabIndex = 3;
            // 
            // tsbGameAdd
            // 
            this.tsbGameAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbGameAdd.Image = global::BooksList.Properties.Resources.IconPlus;
            this.tsbGameAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGameAdd.Name = "tsbGameAdd";
            this.tsbGameAdd.Size = new System.Drawing.Size(28, 30);
            this.tsbGameAdd.Text = "Добавить";
            this.tsbGameAdd.Click += new System.EventHandler(this.tsbBookAdd_Click);
            // 
            // tsbGameEdit
            // 
            this.tsbGameEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbGameEdit.Image = global::BooksList.Properties.Resources.IconEdit;
            this.tsbGameEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGameEdit.Name = "tsbGameEdit";
            this.tsbGameEdit.Size = new System.Drawing.Size(28, 30);
            this.tsbGameEdit.Text = "Редактировать";
            this.tsbGameEdit.Visible = false;
            this.tsbGameEdit.Click += new System.EventHandler(this.tsbBookEdit_Click);
            // 
            // tsbGameDelete
            // 
            this.tsbGameDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbGameDelete.Image = global::BooksList.Properties.Resources.action_delete_sharp_thick;
            this.tsbGameDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGameDelete.Name = "tsbGameDelete";
            this.tsbGameDelete.Size = new System.Drawing.Size(28, 30);
            this.tsbGameDelete.Text = "Удалить";
            this.tsbGameDelete.Click += new System.EventHandler(this.tsbBookDelete_Click);
            // 
            // tsbBookUp
            // 
            this.tsbBookUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbBookUp.Image = global::BooksList.Properties.Resources.IconUp;
            this.tsbBookUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBookUp.Name = "tsbBookUp";
            this.tsbBookUp.Size = new System.Drawing.Size(28, 30);
            this.tsbBookUp.Text = "Вверх";
            this.tsbBookUp.Click += new System.EventHandler(this.tsbBookUp_Click);
            // 
            // tsbBookDown
            // 
            this.tsbBookDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbBookDown.Image = global::BooksList.Properties.Resources.IconDown;
            this.tsbBookDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBookDown.Name = "tsbBookDown";
            this.tsbBookDown.Size = new System.Drawing.Size(28, 30);
            this.tsbBookDown.Text = "Вниз";
            this.tsbBookDown.Click += new System.EventHandler(this.tsbBookDown_Click);
            // 
            // tsbBookNumber
            // 
            this.tsbBookNumber.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbBookNumber.Image = ((System.Drawing.Image)(resources.GetObject("tsbBookNumber.Image")));
            this.tsbBookNumber.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBookNumber.Name = "tsbBookNumber";
            this.tsbBookNumber.Size = new System.Drawing.Size(36, 30);
            this.tsbBookNumber.Text = "№";
            this.tsbBookNumber.Click += new System.EventHandler(this.tsbBookNumber_Click);
            // 
            // tsbBookStarted
            // 
            this.tsbBookStarted.CheckOnClick = true;
            this.tsbBookStarted.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbBookStarted.Image = global::BooksList.Properties.Resources.IconPlay;
            this.tsbBookStarted.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBookStarted.Name = "tsbBookStarted";
            this.tsbBookStarted.Size = new System.Drawing.Size(28, 30);
            this.tsbBookStarted.Text = "Начатые";
            this.tsbBookStarted.CheckedChanged += new System.EventHandler(this.tsbBookStarted_CheckedChanged);
            // 
            // tslFilterIcon
            // 
            this.tslFilterIcon.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tslFilterIcon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tslFilterIcon.Image = global::BooksList.Properties.Resources.IconFilter;
            this.tslFilterIcon.Name = "tslFilterIcon";
            this.tslFilterIcon.Size = new System.Drawing.Size(24, 30);
            this.tslFilterIcon.Text = "Фильтр";
            this.tslFilterIcon.ToolTipText = "Фильтр";
            // 
            // tsbBuyList
            // 
            this.tsbBuyList.CheckOnClick = true;
            this.tsbBuyList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbBuyList.Image = global::BooksList.Properties.Resources.IconCart;
            this.tsbBuyList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBuyList.Name = "tsbBuyList";
            this.tsbBuyList.Size = new System.Drawing.Size(28, 30);
            this.tsbBuyList.Text = "Ожидают покупки";
            this.tsbBuyList.CheckedChanged += new System.EventHandler(this.tsbBuyList_CheckedChanged);
            // 
            // tsmiGroupAdd
            // 
            this.tsmiGroupAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmiGroupAdd.Image = global::BooksList.Properties.Resources.IconPlus;
            this.tsmiGroupAdd.Name = "tsmiGroupAdd";
            this.tsmiGroupAdd.Size = new System.Drawing.Size(36, 33);
            this.tsmiGroupAdd.Text = "Добавить";
            this.tsmiGroupAdd.Click += new System.EventHandler(this.tsmiGroupAdd_Click);
            // 
            // tsmiGroupEdit
            // 
            this.tsmiGroupEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmiGroupEdit.Image = global::BooksList.Properties.Resources.IconEdit;
            this.tsmiGroupEdit.Name = "tsmiGroupEdit";
            this.tsmiGroupEdit.Size = new System.Drawing.Size(36, 33);
            this.tsmiGroupEdit.Text = "Редактировать";
            this.tsmiGroupEdit.Click += new System.EventHandler(this.tsmiGroupEdit_Click);
            // 
            // tsmiGroupDelete
            // 
            this.tsmiGroupDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmiGroupDelete.Image = global::BooksList.Properties.Resources.action_delete_sharp_thick;
            this.tsmiGroupDelete.Name = "tsmiGroupDelete";
            this.tsmiGroupDelete.Size = new System.Drawing.Size(36, 33);
            this.tsmiGroupDelete.Text = "Удалить";
            this.tsmiGroupDelete.Click += new System.EventHandler(this.tsmiGroupDelete_Click);
            // 
            // ucBook
            // 
            this.ucBook.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucBook.Location = new System.Drawing.Point(0, 0);
            this.ucBook.MinimumSize = new System.Drawing.Size(300, 0);
            this.ucBook.Name = "ucBook";
            this.ucBook.Size = new System.Drawing.Size(364, 1192);
            this.ucBook.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1856, 1192);
            this.Controls.Add(this.dgvBooks);
            this.Controls.Add(this.ssGames);
            this.Controls.Add(this.tsGames);
            this.Controls.Add(this.pRight);
            this.Controls.Add(this.pLeft);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msGroups;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormMain";
            this.Text = "Список книг";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroups)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.msGroups.ResumeLayout(false);
            this.msGroups.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).EndInit();
            this.tsGames.ResumeLayout(false);
            this.tsGames.PerformLayout();
            this.ssGames.ResumeLayout(false);
            this.ssGames.PerformLayout();
            this.pLeft.ResumeLayout(false);
            this.pLeft.PerformLayout();
            this.pRight.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvGroups;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBundleName;
        private System.Windows.Forms.MenuStrip msGroups;
        private System.Windows.Forms.ToolStripComboBox tscbGroup;
        private System.Windows.Forms.ToolStripMenuItem tsmiGroupAdd;
        private System.Windows.Forms.ToolStripMenuItem tsmiGroupEdit;
        private System.Windows.Forms.ToolStripMenuItem tsmiGroupDelete;
        private System.Windows.Forms.DataGridView dgvBooks;
        private System.Windows.Forms.StatusStrip ssGames;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsslBooksCount;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel tsslReadyBooksCount;
        private System.Windows.Forms.ToolStrip tsGames;
        private System.Windows.Forms.ToolStripButton tsbGameAdd;
        private System.Windows.Forms.ToolStripButton tsbGameEdit;
        private System.Windows.Forms.ToolStripButton tsbGameDelete;
        private System.Windows.Forms.ToolStripSeparator tssBookMove;
        private System.Windows.Forms.ToolStripButton tsbBookUp;
        private System.Windows.Forms.ToolStripButton tsbBookDown;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbBookStarted;
        private System.Windows.Forms.ToolStripTextBox tstbFilter;
        private System.Windows.Forms.ToolStripLabel tslFilterIcon;
        private System.Windows.Forms.ToolStripButton tsbBuyList;
        private System.Windows.Forms.Panel pEmpty;
        private UserControlBook ucBook;
        private System.Windows.Forms.Panel pLeft;
        private System.Windows.Forms.Panel pRight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBookName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBookAuthor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBookDate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colBookHave;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBookStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBookNumber;
        private System.Windows.Forms.ToolStripComboBox tscbSort;
        private System.Windows.Forms.ToolStripButton tsbBookNumber;
    }
}

