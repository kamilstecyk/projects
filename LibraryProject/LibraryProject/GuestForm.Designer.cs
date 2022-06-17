
namespace LibraryProject
{
    partial class GuestForm
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
            this.listViewAllBooks = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(380, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(347, 43);
            this.label1.TabIndex = 13;
            this.label1.Text = "All available books";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listViewAllBooks
            // 
            this.listViewAllBooks.BackColor = System.Drawing.Color.White;
            this.listViewAllBooks.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listViewAllBooks.ForeColor = System.Drawing.Color.DarkOrange;
            this.listViewAllBooks.HideSelection = false;
            this.listViewAllBooks.Location = new System.Drawing.Point(90, 139);
            this.listViewAllBooks.Name = "listViewAllBooks";
            this.listViewAllBooks.Size = new System.Drawing.Size(965, 403);
            this.listViewAllBooks.TabIndex = 14;
            this.listViewAllBooks.UseCompatibleStateImageBehavior = false;
            this.listViewAllBooks.View = System.Windows.Forms.View.List;
            // 
            // GuestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.ClientSize = new System.Drawing.Size(1166, 602);
            this.Controls.Add(this.listViewAllBooks);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "GuestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GuestForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GuestForm_FormClosing);
            this.Load += new System.EventHandler(this.GuestForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listViewAllBooks;
    }
}