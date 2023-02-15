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
    public partial class AdminForm : Form
    {
        static public Form1 prevForm;

        public AdminForm(Form1 givenPrevForm)
        {
            InitializeComponent();
            prevForm = givenPrevForm;
        }

        private void AddBookButton_Click(object sender, EventArgs e)
        {

            if(checkWhetherTextboxesAreEmpty())
            {
                Messages.displayMessageBox("Textboxes cannot be empty! Fill them up!");
                return;
            }


            if (!dbActionsBooks.addBook(textBoxTitle.Text, textBoxAuthor.Text, textBoxType.Text, long.Parse(textBoxPrice.Text),comboBoxCurrency.Text, int.Parse(textBoxPages.Text)))
            {
                Messages.displayMessageBox("You cannot add this book! Such a book exists");
                return;
            }

            Messages.displayMessageBox("You added book!");

            resetAllAddFields();

            AdminForm_Load(sender, e);

            return;

        }


        private void resetAllAddFields()
        {
            FrontendActions.resetTextBox(textBoxAuthor);
            FrontendActions.resetTextBox(textBoxTitle);
            FrontendActions.resetTextBox(textBoxType);
            FrontendActions.resetTextBox(textBoxPrice);
            FrontendActions.resetTextBox(textBoxPages);
            FrontendActions.resetCombobox(comboBoxCurrency);

        }

        private bool checkWhetherTextboxesAreEmpty()
        {
            if( textBoxTitle.Text.Length == 0 || textBoxAuthor.Text.Length == 0 || textBoxType.Text.Length == 0 || textBoxPrice.Text.Length == 0 || comboBoxCurrency.Text.Length == 0 || textBoxPages.Text.Length == 0 )
            {
                return true;
            }

            return false;
        }


        private void RefreshAndAddToComboBoxUsers()
        {
            comboBoxUsers.Items.Clear();

            foreach (var user in dbActionsBooks.getAllUsers())
            {
                comboBoxUsers.Items.Add(user);
            }

        }


        private void updateEditTextBoxesAfterChoosing()
        {

            var bookProperties = FrontendActions.getChoosedBookProperties(listBoxBooksToEdit);


            string Author = bookProperties[1].Trim();
            string Type = bookProperties[2].Trim();
            string Price = bookProperties[3].Trim();
            string Currency = bookProperties[4].Trim();
            string NumberOfPages = bookProperties[5].Trim();

            textBoxChangeAuthor.Text = Author;
            textBoxChangeType.Text = Type;
            textBoxChangePrice.Text = Price;
            textBoxChangeCurrency.Text = Currency;
            textBoxChangePages.Text = NumberOfPages;
        }



        private void AdminForm_Load(object sender, EventArgs e)
        {

            FrontendActions.RefreshAndAddToListBoxAllBooks(listBoxBooksToRemove);
            FrontendActions.RefreshAndAddToListBoxAllBooks(listBoxBooksToEdit);
            FrontendActions.RefreshAndAddToListViewAllBooks(listViewAllBooks);
            RefreshAndAddToComboBoxUsers();

            string[] availableCurrencies = CurrencyExchangeOperations.getAllAvailableCurrencies();
            FrontendActions.RefreshAndAddToComboBox(comboBoxCurrency, availableCurrencies);

        }

        private void RemoveBookButton_Click(object sender, EventArgs e)
        {

            var bookProperties = FrontendActions.getChoosedBookProperties(listBoxBooksToRemove);

            string titleOfBookToRemove = bookProperties[0].Trim();
            string authorOfBookToRemove = bookProperties[1].Trim();
            
            if(!dbActionsBooks.removeBook(titleOfBookToRemove,authorOfBookToRemove))
            {
                Messages.displayMessageBox("Failer during removing book! ");
                return;
            }

            Messages.displayMessageBox("You removed book successfully!");


            AdminForm_Load(sender,e);

        }

        private void listBoxBooksToEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateEditTextBoxesAfterChoosing();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (listBoxBooksToEdit.SelectedIndex > -1)
            {
                // TODO check for empties textboxes

                var bookProperties = FrontendActions.getChoosedBookProperties(listBoxBooksToEdit);
                var titleToUdate = bookProperties[0].Trim();

                string newAuthor = textBoxChangeAuthor.Text.Trim();
                string newType = textBoxChangeType.Text.Trim();
                string newPrice = textBoxChangePrice.Text.Trim();
                string newCurrency = textBoxChangeCurrency.Text.Trim();
                string newNumberOfPages = textBoxChangePages.Text.Trim();


                if (!dbActionsBooks.updateBook(titleToUdate, newAuthor, newType, long.Parse(newPrice), newCurrency, int.Parse(newNumberOfPages)))
                {
                    Messages.displayMessageBox("Failure during updating book!");
                    return;
                }


                Messages.displayMessageBox("You successfully have updated book!");

                AdminForm_Load(sender, e);
            }
            else
            {
                Messages.displayMessageBox("You must choose book!");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string choosedUser = comboBoxUsers.SelectedItem.ToString().Trim();
            int IDOfChoosedUser = dbActions.getUserIDForLogin(choosedUser);

            var userHistory = dbActionsBooks.getUserHistoryOfBooks(IDOfChoosedUser);

            FrontendActions.RefreshAndAddToListView(listViewHistoryOfUser, userHistory);
        }

        private void AdminForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            prevForm.Close();
        }
    }
}
