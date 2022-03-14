using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCoinApp
{
    public class BitCoinRates
    {
        public bpi bpi { get; set; }
    }

    public class bpi
    {
        public EUR EUR { get; set; }
        public USD USD {get;set;}
    }
    public class EUR
    {
        //tahame tõmmata välja paar omadust/rida json koodist, samamoodi kirjutatud mis jsonis!
        public string code { get; set; }
        public float rate_float { get; set; }
    }

    //dollarite jne jaoks eraldi klass lihtsalt
    public class USD
    {
        public string code { get; set; }
        public float rate_float { get; set; }
    }
}
