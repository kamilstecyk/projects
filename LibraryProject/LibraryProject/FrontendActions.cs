using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LibraryProject
{
    class FrontendActions
    {


        public static  void RefreshAndAddToListBoxAllBooks(ListBox lb)
        {
            lb.Items.Clear();

            foreach (var book in dbActionsBooks.getAllBooks())
            {
                lb.Items.Add(book);
            }
        }

        public static void RefreshAndAddToListBox(ListBox lb,string[] data)
        {
            lb.Items.Clear();

            foreach (var record in data)
            {
                lb.Items.Add(record);
            }
        }

        public static void RefreshAndAddToListBoxAllAvailableBooksToLease(ListBox lb)
        {
            lb.Items.Clear();

            foreach (var book in dbActionsBooks.getAllAvailableBooksToLease())
            {
                lb.Items.Add(book);
            }
        }


        public static void RefreshAndAddToListViewAllBooks(ListView lv)
        {
            lv.Items.Clear();

            foreach (var book in dbActionsBooks.getAllBooks())
            {
                lv.Items.Add(book);
            }
        }


        public static void RefreshAndAddToListView(ListView lv, string[] dataToAdd)
        {
            lv.Items.Clear();

            foreach (var record in dataToAdd)
            {
                lv.Items.Add(record);
            }
        }

      


        public static string[] getChoosedBookProperties(ListBox lb)
        {
            var selectedBook = lb.SelectedItem.ToString();
            var bookProperties = selectedBook.Split(';');
            return bookProperties;
        }


    }
}
