using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryProject
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            int loggedUserID = dbActions.getLoggedUserID();

            string[] currentlyLeasingBooks = dbActionsBooks.getAllCurrentlyLeasingBooksForUser(loggedUserID);
            FrontendActions.RefreshAndAddToListBox(listBoxBooksToReturn, currentlyLeasingBooks);

            FrontendActions.RefreshAndAddToListView(listViewCurrentlyLeasedBooks, currentlyLeasingBooks);

            string[] historyOfUserLeases = dbActionsBooks.getUserHistoryOfBooks(loggedUserID);
            FrontendActions.RefreshAndAddToListView(listViewHistoryOfLeasedBooks, historyOfUserLeases);

            FrontendActions.RefreshAndAddToListBoxAllAvailableBooksToLease(listBoxBooksToLease);


        }

        private void LeaseBookButton_Click(object sender, EventArgs e)
        {
            int loggedUserID = dbActions.getLoggedUserID();

            var propertiesOfChoosedBook = FrontendActions.getChoosedBookProperties(listBoxBooksToLease);

            var titleOfChoosedBook = propertiesOfChoosedBook[0].Trim();
            var authorOfChoosedBook = propertiesOfChoosedBook[1].Trim();

            if(!dbActionsBooks.leaseBookForUser(loggedUserID, titleOfChoosedBook, authorOfChoosedBook))
            {
                Messages.displayMessageBox("You could not lease this book. Check if you are leasing 3 books, because it is max!");
                return;
            }

            Messages.displayMessageBox("You have successfully leased the book");

            MainForm_Load(sender, e);

        }

        private void listBoxBooksToReturn_SelectedIndexChanged(object sender, EventArgs e)
        {
            int loggedUserID = dbActions.getLoggedUserID();

            var propertiesOfChoosedBook = FrontendActions.getChoosedBookProperties(listBoxBooksToReturn);

            var titleOfChoosedBook = propertiesOfChoosedBook[0].Trim();
            var authorOfChoosedBook = propertiesOfChoosedBook[1].Trim();

            dateTimePickerToProlong.Value = dbActionsBooks.getLeaseEndDateOfLeasedBookForUser(loggedUserID, titleOfChoosedBook, authorOfChoosedBook);
        }

        private void prolongLeaseButton_Click(object sender, EventArgs e)
        {
            if(listBoxBooksToReturn.SelectedIndex > -1)
            {
                int loggedUserID = dbActions.getLoggedUserID();

                var propertiesOfChoosedBook = FrontendActions.getChoosedBookProperties(listBoxBooksToReturn);
                var titleOfChoosedBook = propertiesOfChoosedBook[0].Trim();
                var authorOfChoosedBook = propertiesOfChoosedBook[1].Trim();

                DateTime olderLeaseEndDate = dbActionsBooks.getLeaseEndDateOfLeasedBookForUser(loggedUserID, titleOfChoosedBook, authorOfChoosedBook);
                DateTime prolongedDate = dateTimePickerToProlong.Value;

                if( prolongedDate <= olderLeaseEndDate )
                {
                    Messages.displayMessageBox("You must choose date that is later in the future that the older one!");
                    return;
                }

                if (!dbActionsBooks.prolongLeaseOfBookForUser(loggedUserID, prolongedDate, titleOfChoosedBook, authorOfChoosedBook))
                {
                    Messages.displayMessageBox("Unfortunately you could not prolong this book!");
                    return;
                }

                Messages.displayMessageBox("You successfully prolonged choosed book to date: " + prolongedDate.ToLongDateString());

                MainForm_Load(sender, e);

            }
            else
            {
                Messages.displayMessageBox("You must choose book in order to prolong!");
            }
        }

        private void returnBookButton_Click_1(object sender, EventArgs e)
        {
            int loggedUserID = dbActions.getLoggedUserID();

            var propertiesOfChoosedBook = FrontendActions.getChoosedBookProperties(listBoxBooksToReturn);

            var titleOfChoosedBook = propertiesOfChoosedBook[0].Trim();
            var authorOfChoosedBook = propertiesOfChoosedBook[1].Trim();

            if (!dbActionsBooks.returnBookForUser(loggedUserID, titleOfChoosedBook, authorOfChoosedBook))
            {
                Messages.displayMessageBox("You could not return this book!");
                return;
            }

            Messages.displayMessageBox("You have successfully returned the book");

            MainForm_Load(sender, e);
        }
    }
}
