using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BitCoinApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnGetRates_Click(object sender, EventArgs e)
        {
            if(currencyCombo.SelectedItem.ToString() == "EUR")
            {
                //muuta need nähtavaks, kui nuppu vajutatakse
                resultLabel.Visible = true;
                resultTextBox.Visible = true;
                //saab läbi meetodi code ja float väärtused
                BitCoinRates bitcoin = GetRates();
                //saada väärtus mis kasutaja sisestab, see on sõnes, seega teha int'iks, korrutada bitcoini väärtusega
                float result = Int32.Parse(amountOfCoinBox.Text) * bitcoin.bpi.EUR.rate_float;
                //teha tulemus kastis nähtavaks
                resultTextBox.Text = $"{result.ToString()} {bitcoin.bpi.EUR.code}";
            }
            else if(currencyCombo.SelectedItem.ToString() == "USD")
            {
                resultLabel.Visible = true;
                resultTextBox.Visible = true;

                BitCoinRates bitcoin = GetRates();
                //saada väärtus mis kasutaja sisestab, see on sõnes, seega teha int'iks, korrutada bitcoini väärtusega
                float result = Int32.Parse(amountOfCoinBox.Text) * bitcoin.bpi.USD.rate_float;
                //teha tulemus kastis nähtavaks
                resultTextBox.Text = $"{result.ToString()} {bitcoin.bpi.USD.code}";

            }
        }

        public static BitCoinRates GetRates()
        {
            //rakenduse aadress, mis väljastab andmeid
            string url = "https://api.coindesk.com/v1/bpi/currentprice.json";
            //kutsuda andmed välja http protokolli läbi (luua päring)
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            //kuhu salvestab andmed
            var webResponse = request.GetResponse();
            //teen ühenduse lahti?
            var webStream = webResponse.GetResponseStream();

            //objekt kuhu salvestada osa mida loeme maha
            BitCoinRates bitcoin;
            //ühenduse peab ka kindlalt sulgema
            using (var responseReader = new StreamReader(webStream))
            {
                var response = responseReader.ReadToEnd(); //loeme otsast lõpuni
                //väärtus
                bitcoin = JsonConvert.DeserializeObject<BitCoinRates>(response);

            }
            //tagastab väärtuse
            return bitcoin;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
