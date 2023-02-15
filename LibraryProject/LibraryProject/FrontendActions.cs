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


        public static void RefreshAndAddToComboBox(ComboBox cmbx,string[] data)
        {
            cmbx.Items.Clear();

            foreach(var item in data)
            {
                cmbx.Items.Add(item);
            }

        }


        public static void resetCombobox(ComboBox cmbx)
        {
            cmbx.SelectedIndex = -1;
            cmbx.Text = "";
        }

        public static void resetTextBox(TextBox tx)
        {
            tx.Text = "";
        }

        public static string[,] getColumnsOfStringFilteredRecord(string[] records)
        {
            int tableLenght = records.Length;

            var columnsLenght = records[0].Split(';').Length;

            string[,] resultTable = new string[tableLenght, columnsLenght];


            for(int i=0;i<tableLenght;++i)
            {

                var columnsOfRecord = records[i].Split(';');

                for(int j=0;j<columnsLenght;++j)
                {
                    resultTable[i, j] = columnsOfRecord[j].Trim();
                }

            }

            return resultTable;
        }


        public static string[] getRecordsWithPriceInPLN(string[] records)
        {

            var tableWithSeparatedColumnsOfEachRecord = getColumnsOfStringFilteredRecord(records);

            int tableLenght = tableWithSeparatedColumnsOfEachRecord.GetLength(0);
            int colsLenght = tableWithSeparatedColumnsOfEachRecord.GetLength(1);  // columns are the same length of each record

            // columns appearance
            // title,author,type,price,currency

            Console.WriteLine(tableLenght + " - rows");
            Console.WriteLine(colsLenght + " - cols ");

            for(int i=0;i<tableLenght;++i)
            {

                double priceOfBook = double.Parse( tableWithSeparatedColumnsOfEachRecord[i, 3] );
                string currencyToChange = tableWithSeparatedColumnsOfEachRecord[i, 4];

                if(currencyToChange.Equals("PLN"))
                {
                    continue;
                }

                double newPriceInPLN = CurrencyExchangeOperations.getPriceInPLN(currencyToChange, priceOfBook);
                double roundedNewPrice = Math.Round(newPriceInPLN, 2, MidpointRounding.ToEven);

                tableWithSeparatedColumnsOfEachRecord[i, 4] = "PLN";  // we change currency
                tableWithSeparatedColumnsOfEachRecord[i, 3] = roundedNewPrice.ToString();

            }

            return buildRecords(tableWithSeparatedColumnsOfEachRecord,tableLenght,colsLenght);
        }


        public static string[] buildRecords(string[,] tableWithRecordsAndTheirColumns, int tableLenght, int colsLenght )
        {
            string[] resultTable = new string[tableWithRecordsAndTheirColumns.Length];

            for(int i=0;i<tableLenght;++i)
            {
                StringBuilder bookRecord = new StringBuilder();

               for(int j=0;j<colsLenght;++j)
                {
                   if(j == (colsLenght -1))
                    {
                        bookRecord.Append(tableWithRecordsAndTheirColumns[i, j]);
                    }
                   else
                    {
                        bookRecord.Append(tableWithRecordsAndTheirColumns[i, j] + " ; ");
                    }
                }

                resultTable[i] = bookRecord.ToString().Trim();

            }

            return resultTable;
        }


    }
}
