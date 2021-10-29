using SOAP.Entities;
using SOAP.MnbServiceReference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace SOAP
{
    public partial class Form1 : Form
    {
        BindingList<RateData> Rates = new BindingList<RateData>();

        public Form1()
        {
            InitializeComponent();

            GetExchangeRates();

            dataGridView1.DataSource = Rates;
            ProcessXML(GetExchangeRates());
        }

        private string GetExchangeRates()
        {
            var mnbService = new MNBArfolyamServiceSoapClient();

            var request = new GetExchangeRatesRequestBody()
            {
                currencyNames = "EUR",
                startDate = "2020-01-01",
                endDate = "2020-06-30"
            };

            var response = mnbService.GetExchangeRates(request);

            var result = response.GetExchangeRatesResult;

            richTextBox1.AppendText(result);

            return result;
        }

        private void ProcessXML(string result)
        {
            var xml = new XmlDocument();

            xml.LoadXml(result);

            foreach(XmlElement item in xml.DocumentElement)
            {
                var rd = new RateData();
                rd.Date = DateTime.Parse(item.GetAttribute("date"));
                
                var childElement = (XmlElement)item.ChildNodes[0];
                rd.Currency = childElement.GetAttribute("curr");
                
                var unit = decimal.Parse(childElement.GetAttribute("unit"));
                var value = decimal.Parse(childElement.InnerText);
                if (unit != 0) rd.Value = value / unit;

                Rates.Add(rd);
            }
        }
    }
}
