using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registru_Winui
{
    public class Product
    {
        public int sku { get; set; }
        public string nume { get; set; }
        public string categorie { get; set; }
        public string unitate { get; set; }
        public float pret { get; set; }
        public float tva { get; set; }
    }

    public class Protocol_entry
    {
        [System.ComponentModel.Browsable(false)]
        public int ID { get; set; }

        [System.ComponentModel.DisplayName("NUME")]
        public string Beneficiar { get; set; }
        
        [System.ComponentModel.DisplayName("DATA")]
        public string Data { get; set; }

        [System.ComponentModel.DisplayName("PRODUS")]
        public string Produs { get; set; }

        [System.ComponentModel.DisplayName("CANTITATE")]
        public int Cantitate { get; set; }

        [System.ComponentModel.DisplayName("STATUS")]
        public string Status { get; set; }

        [System.ComponentModel.DisplayName("PRET")]
        public float Pret { get; set; }
    }
}
