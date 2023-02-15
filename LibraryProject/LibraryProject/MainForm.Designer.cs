
namespace LibraryProject
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.LeaseBookButton = new System.Windows.Forms.Button();
            this.listBoxBooksToLease = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.dateTimePickerToProlong = new System.Windows.Forms.DateTimePicker();
            this.prolongLeaseButton = new System.Windows.Forms.Button();
            this.returnBookButton = new System.Windows.Forms.Button();
            this.listBoxBooksToReturn = new System.Windows.Forms.ListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.listViewCurrentlyLeasedBooks = new System.Windows.Forms.ListView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.listViewHistoryOfLeasedBooks = new System.Windows.Forms.ListView();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.linkLabelReset = new System.Windows.Forms.LinkLabel();
            this.filteredButton = new System.Windows.Forms.Button();
            this.listViewFilteredBooks = new System.Windows.Forms.ListView();
            this.label7 = new System.Windows.Forms.Label();
            this.radioButtonPLNCurrency = new System.Windows.Forms.RadioButton();
            this.radioButtonOriginalCurrency = new System.Windows.Forms.RadioButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.comboBoxFilterType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.comboBoxCurrencyFilter = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBoxToPrice = new System.Windows.Forms.TextBox();
            this.textBoxFromPrice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxAuthorFilter = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(418, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(347, 43);
            this.label1.TabIndex = 12;
            this.label1.Text = "Library Manager";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(56, 87);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1149, 507);
            this.tabControl1.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.LeaseBookButton);
            this.tabPage1.Controls.Add(this.listBoxBooksToLease);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1141, 481);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Lease book";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // LeaseBookButton
            // 
            this.LeaseBookButton.BackColor = System.Drawing.Color.DarkOrange;
            this.LeaseBookButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LeaseBookButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LeaseBookButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LeaseBookButton.ForeColor = System.Drawing.Color.White;
            this.LeaseBookButton.Location = new System.Drawing.Point(449, 417);
            this.LeaseBookButton.Name = "LeaseBookButton";
            this.LeaseBookButton.Size = new System.Drawing.Size(214, 37);
            this.LeaseBookButton.TabIndex = 9;
            this.LeaseBookButton.Text = "LEASE BOOK";
            this.LeaseBookButton.UseVisualStyleBackColor = false;
            this.LeaseBookButton.Click += new System.EventHandler(this.LeaseBookButton_Click);
            // 
            // listBoxBooksToLease
            // 
            this.listBoxBooksToLease.BackColor = System.Drawing.Color.DarkOrange;
            this.listBoxBooksToLease.ForeColor = System.Drawing.Color.White;
            this.listBoxBooksToLease.FormattingEnabled = true;
            this.listBoxBooksToLease.Location = new System.Drawing.Point(214, 53);
            this.listBoxBooksToLease.Name = "listBoxBooksToLease";
            this.listBoxBooksToLease.Size = new System.Drawing.Size(720, 329);
            this.listBoxBooksToLease.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.dateTimePickerToProlong);
            this.tabPage2.Controls.Add(this.prolongLeaseButton);
            this.tabPage2.Controls.Add(this.returnBookButton);
            this.tabPage2.Controls.Add(this.listBoxBooksToReturn);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1141, 481);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Return book";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(870, 226);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(199, 25);
            this.label8.TabIndex = 20;
            this.label8.Text = "Choose data for ending lease of book";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateTimePickerToProlong
            // 
            this.dateTimePickerToProlong.Location = new System.Drawing.Point(869, 264);
            this.dateTimePickerToProlong.Name = "dateTimePickerToProlong";
            this.dateTimePickerToProlong.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerToProlong.TabIndex = 19;
            // 
            // prolongLeaseButton
            // 
            this.prolongLeaseButton.BackColor = System.Drawing.Color.DarkOrange;
            this.prolongLeaseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.prolongLeaseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.prolongLeaseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.prolongLeaseButton.ForeColor = System.Drawing.Color.White;
            this.prolongLeaseButton.Location = new System.Drawing.Point(869, 306);
            this.prolongLeaseButton.Name = "prolongLeaseButton";
            this.prolongLeaseButton.Size = new System.Drawing.Size(200, 31);
            this.prolongLeaseButton.TabIndex = 18;
            this.prolongLeaseButton.Text = "PROLONG LEASE";
            this.prolongLeaseButton.UseVisualStyleBackColor = false;
            this.prolongLeaseButton.Click += new System.EventHandler(this.prolongLeaseButton_Click);
            // 
            // returnBookButton
            // 
            this.returnBookButton.BackColor = System.Drawing.Color.DarkOrange;
            this.returnBookButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.returnBookButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.returnBookButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.returnBookButton.ForeColor = System.Drawing.Color.White;
            this.returnBookButton.Location = new System.Drawing.Point(869, 77);
            this.returnBookButton.Name = "returnBookButton";
            this.returnBookButton.Size = new System.Drawing.Size(200, 31);
            this.returnBookButton.TabIndex = 17;
            this.returnBookButton.Text = "RETURN BOOK";
            this.returnBookButton.UseVisualStyleBackColor = false;
            this.returnBookButton.Click += new System.EventHandler(this.returnBookButton_Click_1);
            // 
            // listBoxBooksToReturn
            // 
            this.listBoxBooksToReturn.BackColor = System.Drawing.Color.DarkOrange;
            this.listBoxBooksToReturn.ForeColor = System.Drawing.Color.White;
            this.listBoxBooksToReturn.FormattingEnabled = true;
            this.listBoxBooksToReturn.Location = new System.Drawing.Point(23, 45);
            this.listBoxBooksToReturn.Name = "listBoxBooksToReturn";
            this.listBoxBooksToReturn.Size = new System.Drawing.Size(720, 329);
            this.listBoxBooksToReturn.TabIndex = 2;
            this.listBoxBooksToReturn.SelectedIndexChanged += new System.EventHandler(this.listBoxBooksToReturn_SelectedIndexChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.listViewCurrentlyLeasedBooks);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1141, 481);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Currently leased books";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // listViewCurrentlyLeasedBooks
            // 
            this.listViewCurrentlyLeasedBooks.BackColor = System.Drawing.Color.DarkOrange;
            this.listViewCurrentlyLeasedBooks.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listViewCurrentlyLeasedBooks.ForeColor = System.Drawing.Color.White;
            this.listViewCurrentlyLeasedBooks.HideSelection = false;
            this.listViewCurrentlyLeasedBooks.Location = new System.Drawing.Point(71, 67);
            this.listViewCurrentlyLeasedBooks.Name = "listViewCurrentlyLeasedBooks";
            this.listViewCurrentlyLeasedBooks.Size = new System.Drawing.Size(965, 331);
            this.listViewCurrentlyLeasedBooks.TabIndex = 1;
            this.listViewCurrentlyLeasedBooks.UseCompatibleStateImageBehavior = false;
            this.listViewCurrentlyLeasedBooks.View = System.Windows.Forms.View.List;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.listViewHistoryOfLeasedBooks);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1141, 481);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "History of leasing books";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // listViewHistoryOfLeasedBooks
            // 
            this.listViewHistoryOfLeasedBooks.BackColor = System.Drawing.Color.DarkOrange;
            this.listViewHistoryOfLeasedBooks.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listViewHistoryOfLeasedBooks.ForeColor = System.Drawing.Color.White;
            this.listViewHistoryOfLeasedBooks.HideSelection = false;
            this.listViewHistoryOfLeasedBooks.Location = new System.Drawing.Point(82, 71);
            this.listViewHistoryOfLeasedBooks.Name = "listViewHistoryOfLeasedBooks";
            this.listViewHistoryOfLeasedBooks.Size = new System.Drawing.Size(965, 331);
            this.listViewHistoryOfLeasedBooks.TabIndex = 2;
            this.listViewHistoryOfLeasedBooks.UseCompatibleStateImageBehavior = false;
            this.listViewHistoryOfLeasedBooks.View = System.Windows.Forms.View.List;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.linkLabelReset);
            this.tabPage5.Controls.Add(this.filteredButton);
            this.tabPage5.Controls.Add(this.listViewFilteredBooks);
            this.tabPage5.Controls.Add(this.label7);
            this.tabPage5.Controls.Add(this.radioButtonPLNCurrency);
            this.tabPage5.Controls.Add(this.radioButtonOriginalCurrency);
            this.tabPage5.Controls.Add(this.panel4);
            this.tabPage5.Controls.Add(this.panel3);
            this.tabPage5.Controls.Add(this.panel2);
            this.tabPage5.Controls.Add(this.panel1);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(1141, 481);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "All books";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // linkLabelReset
            // 
            this.linkLabelReset.AutoSize = true;
            this.linkLabelReset.Location = new System.Drawing.Point(254, 296);
            this.linkLabelReset.Name = "linkLabelReset";
            this.linkLabelReset.Size = new System.Drawing.Size(62, 13);
            this.linkLabelReset.TabIndex = 19;
            this.linkLabelReset.TabStop = true;
            this.linkLabelReset.Text = "Reset fields";
            this.linkLabelReset.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelReset_LinkClicked);
            // 
            // filteredButton
            // 
            this.filteredButton.BackColor = System.Drawing.Color.DarkOrange;
            this.filteredButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.filteredButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.filteredButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.filteredButton.ForeColor = System.Drawing.Color.White;
            this.filteredButton.Location = new System.Drawing.Point(72, 383);
            this.filteredButton.Name = "filteredButton";
            this.filteredButton.Size = new System.Drawing.Size(200, 31);
            this.filteredButton.TabIndex = 18;
            this.filteredButton.Text = "LOOK FOR BOOKS";
            this.filteredButton.UseVisualStyleBackColor = false;
            this.filteredButton.Click += new System.EventHandler(this.filteredButton_Click);
            // 
            // listViewFilteredBooks
            // 
            this.listViewFilteredBooks.BackColor = System.Drawing.Color.DarkOrange;
            this.listViewFilteredBooks.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listViewFilteredBooks.ForeColor = System.Drawing.Color.White;
            this.listViewFilteredBooks.HideSelection = false;
            this.listViewFilteredBooks.Location = new System.Drawing.Point(431, 42);
            this.listViewFilteredBooks.Name = "listViewFilteredBooks";
            this.listViewFilteredBooks.Size = new System.Drawing.Size(666, 239);
            this.listViewFilteredBooks.TabIndex = 7;
            this.listViewFilteredBooks.UseCompatibleStateImageBehavior = false;
            this.listViewFilteredBooks.View = System.Windows.Forms.View.List;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(17, 325);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 24);
            this.label7.TabIndex = 6;
            this.label7.Text = "Price in:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radioButtonPLNCurrency
            // 
            this.radioButtonPLNCurrency.AutoSize = true;
            this.radioButtonPLNCurrency.Location = new System.Drawing.Point(270, 329);
            this.radioButtonPLNCurrency.Name = "radioButtonPLNCurrency";
            this.radioButtonPLNCurrency.Size = new System.Drawing.Size(46, 17);
            this.radioButtonPLNCurrency.TabIndex = 5;
            this.radioButtonPLNCurrency.Text = "PLN";
            this.radioButtonPLNCurrency.UseVisualStyleBackColor = true;
            // 
            // radioButtonOriginalCurrency
            // 
            this.radioButtonOriginalCurrency.AutoSize = true;
            this.radioButtonOriginalCurrency.Checked = true;
            this.radioButtonOriginalCurrency.Location = new System.Drawing.Point(140, 329);
            this.radioButtonOriginalCurrency.Name = "radioButtonOriginalCurrency";
            this.radioButtonOriginalCurrency.Size = new System.Drawing.Size(105, 17);
            this.radioButtonOriginalCurrency.TabIndex = 4;
            this.radioButtonOriginalCurrency.TabStop = true;
            this.radioButtonOriginalCurrency.Text = "Original Currency";
            this.radioButtonOriginalCurrency.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.DarkOrange;
            this.panel4.Controls.Add(this.comboBoxFilterType);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Location = new System.Drawing.Point(40, 105);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(276, 42);
            this.panel4.TabIndex = 3;
            // 
            // comboBoxFilterType
            // 
            this.comboBoxFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFilterType.FormattingEnabled = true;
            this.comboBoxFilterType.Location = new System.Drawing.Point(137, 12);
            this.comboBoxFilterType.Name = "comboBoxFilterType";
            this.comboBoxFilterType.Size = new System.Drawing.Size(124, 21);
            this.comboBoxFilterType.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(16, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Type:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkOrange;
            this.panel3.Controls.Add(this.comboBoxCurrencyFilter);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Location = new System.Drawing.Point(40, 239);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(276, 42);
            this.panel3.TabIndex = 2;
            // 
            // comboBoxCurrencyFilter
            // 
            this.comboBoxCurrencyFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCurrencyFilter.FormattingEnabled = true;
            this.comboBoxCurrencyFilter.Location = new System.Drawing.Point(137, 12);
            this.comboBoxCurrencyFilter.Name = "comboBoxCurrencyFilter";
            this.comboBoxCurrencyFilter.Size = new System.Drawing.Size(124, 21);
            this.comboBoxCurrencyFilter.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(16, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Currency:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkOrange;
            this.panel2.Controls.Add(this.textBoxToPrice);
            this.panel2.Controls.Add(this.textBoxFromPrice);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(40, 173);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(276, 42);
            this.panel2.TabIndex = 1;
            // 
            // textBoxToPrice
            // 
            this.textBoxToPrice.Location = new System.Drawing.Point(208, 12);
            this.textBoxToPrice.Name = "textBoxToPrice";
            this.textBoxToPrice.Size = new System.Drawing.Size(53, 20);
            this.textBoxToPrice.TabIndex = 4;
            // 
            // textBoxFromPrice
            // 
            this.textBoxFromPrice.Location = new System.Drawing.Point(128, 12);
            this.textBoxFromPrice.Name = "textBoxFromPrice";
            this.textBoxFromPrice.Size = new System.Drawing.Size(53, 20);
            this.textBoxFromPrice.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(187, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "to";
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(16, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Price range:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkOrange;
            this.panel1.Controls.Add(this.comboBoxAuthorFilter);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(40, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(276, 42);
            this.panel1.TabIndex = 0;
            // 
            // comboBoxAuthorFilter
            // 
            this.comboBoxAuthorFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAuthorFilter.FormattingEnabled = true;
            this.comboBoxAuthorFilter.Location = new System.Drawing.Point(137, 12);
            this.comboBoxAuthorFilter.Name = "comboBoxAuthorFilter";
            this.comboBoxAuthorFilter.Size = new System.Drawing.Size(124, 21);
            this.comboBoxAuthorFilter.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(16, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Author:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.ClientSize = new System.Drawing.Size(1196, 606);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ListBox listBoxBooksToLease;
        private System.Windows.Forms.Button LeaseBookButton;
        private System.Windows.Forms.ListBox listBoxBooksToReturn;
        private System.Windows.Forms.ListView listViewCurrentlyLeasedBooks;
        private System.Windows.Forms.ListView listViewHistoryOfLeasedBooks;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton radioButtonPLNCurrency;
        private System.Windows.Forms.RadioButton radioButtonOriginalCurrency;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox comboBoxFilterType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox comboBoxCurrencyFilter;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBoxAuthorFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateTimePickerToProlong;
        private System.Windows.Forms.Button prolongLeaseButton;
        private System.Windows.Forms.Button returnBookButton;
        private System.Windows.Forms.ListView listViewFilteredBooks;
        private System.Windows.Forms.Button filteredButton;
        private System.Windows.Forms.LinkLabel linkLabelReset;
        private System.Windows.Forms.TextBox textBoxToPrice;
        private System.Windows.Forms.TextBox textBoxFromPrice;
    }
}