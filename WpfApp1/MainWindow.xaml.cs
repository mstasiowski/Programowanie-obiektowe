using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        record Rate(string Code, string Currency, double Bid, double Ask)
            Dictionary<string, string> Rates = new Dictionary<string, Rate>();
     

        class RateTable
        { 
            [JsonPropertyName("Table")]
            
            public string Table { get; set; }
            [JsonPropertyName("no")]

            public string Number { get; set; }
            [JsonPropertyName("tradingDate")]

            public DateTime TradingDate { get; set; }
            [JsonPropertyName("tradingDate")]
            public DateTime EffectiveDate { get; set; }
            [JsonPropertyName("EfectiveDate")]

        }


        private void DownloadDateJson()
        {
            client.Headers.Add("Accept", "application/json");
            string json = clien.DownloadString("http://api.nbp.pl/api/exchangerates/table/C");
            JsonSerializer.Deserialize<>
        }

        private void DownloadData()
        {
            WebClient client = new WebClient();
            client.Headers.Add("Content-Type", "application/xml");
            string xml = client.DownloadString("");
            XDocument doc = XDocument.Parse(xml);
            doc.Elements("ArrayOfExchangeRatesTable")
                .elements("ExchangeRatesTable")
                .elements("Rates")
                .elements("Rate")
                .Select(node => new Rate(
                    node.Element("Code").Value,
                    node.Element("Currency").Value,
                    double.Parse(node.Element("Bid").Value),
                    double.Parse(node.Element("Ask").Value)
                    )).toList();

            foreach(Rate r in list)
            {
                Rates.Add(r.Code, r);
            }
        }
        public MainWindow()
        {
            InitializeComponent();

            DownloadData();

            foreach(string code  in Rates.Keys)
            {
                
            }


            InputCurrencyCode.Items.Add("USD");
            InputCurrencyCode.Items.Add("PLN");
            InputCurrencyCode.Items.Add("EUR");

            ResultCurrencyCode.Items.Add("USD");
            ResultCurrencyCode.Items.Add("PLN");
            ResultCurrencyCode.Items.Add("EUR");

            InputCurrencyCode.SelectedIndex = 1;
            ResultCurrencyCode.SelectedIndex = 0;
        }

        private void CalcResult(object sender, RoutedEventArgs e)
        {
            //kod reagujący na klikniecie
            //obliczenie kwoty dla Result value

            //  ResultValue.Text = "10,0";

            string inputCode = (string)InputCurrencyCode.SelectedItem;
            string resultCode = (string)ResultCurrencyCode.SelectedItem;
            string amountStr = Inputvalue.Text;
            MessageBox.Show($"Wybrany kod wejściowy {inputCode}\n wybrany kod wyjściowy {resultCode}\n kwota {amountStr}");
        }

        private void NumberValidation(object sender, TextCompositionEventArgs e)
        {
            string s = e.Text;
            if(s.EndsWith(","))
            {
                s += "0";
            }
            e.Handled = !decimal.TryParse(s, out decimal value);
        }
    }
}
