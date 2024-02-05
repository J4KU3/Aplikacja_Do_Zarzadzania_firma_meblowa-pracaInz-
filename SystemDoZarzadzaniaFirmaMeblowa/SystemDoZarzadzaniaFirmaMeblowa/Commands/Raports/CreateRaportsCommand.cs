using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Drawing;
using System.Drawing.Printing;
using SystemDoZarzadzaniaFirmaMeblowa.Commands.BaseCommand;
using SystemDoZarzadzaniaFirmaMeblowa.Models;
using SystemDoZarzadzaniaFirmaMeblowa.ViewModels;
using System.Data;
using System.Diagnostics;

namespace SystemDoZarzadzaniaFirmaMeblowa.Commands.Raports
{
    public class CreateRaportsCommand:CommandBase
    {
        private readonly MainViewModel _mainviewModel;

        public CreateRaportsCommand(MainViewModel mainViewModel)
        {
            _mainviewModel = mainViewModel;
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            
               var selectedMonth = DateTime.UtcNow;
            
            var ordersForMonth = _mainviewModel.ListOfOrders
                .Where(order => order.OrderDate.HasValue && order.OrderDate.Value.Month == selectedMonth.Month);

            Print(selectedMonth, ordersForMonth);

        }
        public void Print(DateTime selectedDate, IEnumerable<OrdersModel> ordersForMonth)
        {
            // PLACEHOLDER MICROSOFT PRINT TO PDF
            // ORDERS MADE IN QUICK SUCCESSION MAY OVERWRITE THE .PDF PRINTOUTS ( WON'T FIX )
            // CHANGE TO REAL PRINTER IN FUTURE

            string fileNamePrefix = "Raport";
            string fileNameSuffix = DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss");
            

            // the directory to store the output.
            string directory = "./Raporty/";

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            

            var printDoc = new PrintDocument
            {
                PrinterSettings =
                {
                    // set the printer to 'Microsoft Print to PDF'
                    // change to real printer in future
                    PrinterName = "Microsoft Print to PDF",
                    PrintToFile = true,
                    PrintFileName = Path.Combine(directory, fileNamePrefix + fileNameSuffix + ".pdf")
                },
                PrintController = new StandardPrintController()
            };

            printDoc.PrintPage += (sender, args) => OnPrintPage(sender, args, selectedDate, ordersForMonth);
            printDoc.Print();
           
        }

        private void OnPrintPage(object sender, PrintPageEventArgs ev, DateTime selectedMonth, IEnumerable<OrdersModel> ordersForMonth)
        {
            System.Drawing.Font headingFont = new System.Drawing.Font("TimesNewRoman", 12, System.Drawing.FontStyle.Bold);
            System.Drawing.Font boldFont = new System.Drawing.Font("TimesNewRoman", 10, System.Drawing.FontStyle.Bold);
            System.Drawing.Font normalFont = new System.Drawing.Font("TimesNewRoman", 10, System.Drawing.FontStyle.Regular);

            string currency = "zł";

            float height = 50;  // Zwiększ wysokość początkową, aby uniknąć przycięcia na górze strony

            // Marginesy
            float leftMargin = ev.MarginBounds.Left;
            float topMargin = ev.MarginBounds.Top;
            float rightMargin = ev.MarginBounds.Right;
            float bottomMargin = ev.MarginBounds.Bottom;

            string line = "_________________________________________________________________________________________";

            //Logo firmy 
            var imagePath = "LogoRaport.jpg";


            if (File.Exists(imagePath))
            {
                Image logoImage = Image.FromFile(imagePath);
                
                ev.Graphics.DrawImage(logoImage, 128, 10);
                height += 30;
            }
            else
            {
                MessageBox.Show("Plik LogoRaport.jpg nie został znaleziony.");
            }



            height += 200;  // zwiększ wysokość, aby umieścić logo

            //Print Report Title
            DateTime dateTime = DateTime.UtcNow;
            ev.Graphics.DrawString($"Raport zamówień za {dateTime: MMMM yyyy}", headingFont, Brushes.Black, leftMargin, height, new StringFormat());
            height += 30;

            DataTable dt = new DataTable();
            dt.Columns.Add("Numer zamówienia");
            dt.Columns.Add("Data zamówienia");
            dt.Columns.Add("Produkt");
            dt.Columns.Add("Kolor");
            dt.Columns.Add("Cena");




            foreach (var order in ordersForMonth)
            {
                DataRow dr = dt.NewRow();
                dr[0] = order.OrderID;
                dr[1] = order.OrderDate.Value.ToString("dd.MM");
                dr[2] = order.ItemName;
                dr[3] = order.ItemColor;
                dr[4] = order.Price;

                dt.Rows.Add(dr);
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ev.Graphics.DrawString($"Data zamówienia: {dt.Rows[i][1]}", normalFont, Brushes.Black, leftMargin, height, new StringFormat());
                height += 15;  // Zwiększ wysokość, aby oddzielić poszczególne linie
                ev.Graphics.DrawString($"Numer zamówienia: {dt.Rows[i][0]}", normalFont, Brushes.Black, leftMargin, height, new StringFormat());
                height += 15;  // Zwiększ wysokość, aby oddzielić poszczególne linie
                ev.Graphics.DrawString($"Produkt: {dt.Rows[i][2]}", normalFont, Brushes.Black, leftMargin, height, new StringFormat());
                height += 15;
                ev.Graphics.DrawString($"Kolor: {dt.Rows[i][3]}", normalFont, Brushes.Black, leftMargin, height, new StringFormat());
                height += 15;
                ev.Graphics.DrawString($"Cena: {dt.Rows[i][4]} {currency}", normalFont, Brushes.Black, leftMargin, height, new StringFormat());
                height += 15;
                ev.Graphics.DrawString(line, normalFont, Brushes.Black, leftMargin, height, new StringFormat());
                height += 30;
            }

            // Sprawdź, czy są więcej strony do drukowania
            ev.HasMorePages = false; // Jeśli raport ma być jednostronicowy
            MessageBox.Show("Raport został stworzony");
        }

    }
}
