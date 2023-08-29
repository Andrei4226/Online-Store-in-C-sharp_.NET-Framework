using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Proiect
{
    internal class Raion
    {
        private int numar;
        private string denumire;
        private int stocProduse;
        private List<Produs> listaProduse;
            
        public Raion()
        {
            numar = 0;
            denumire = "";
            stocProduse = 0;
            listaProduse = null;
        }
        public Raion(string denumire, int stocProduse, List<Produs> listaProduse,int numar)
        {
            this.denumire = denumire;
            this.numar = numar;
            this.stocProduse = stocProduse;
            this.listaProduse = new List<Produs>();
            foreach(Produs produs in listaProduse)
            {
                this.listaProduse.Add(produs);
            }
        }
        public string Denumire
        {
            get { return this.denumire; }
            set { this.denumire = value; }
        }
        public int StocProduse
        {
            get { return this.stocProduse; }
            set { this.stocProduse = value; }
        }
        public List<Produs> ListaProduse
        {
            get { return this.listaProduse; }
            set
            {
                this.listaProduse= value;
            }
        }
        public override string ToString()
        {

            string mesaj = "Denumire raion: " + this.denumire + "." + Environment.NewLine +
                "Numar raion: " + this.numar + "." + Environment.NewLine +
                "Stoc de produse maxim: " + this.stocProduse + "." + Environment.NewLine;
            if (this.listaProduse.Count > 0)
            {
                mesaj= mesaj+ "Raionul contine urmatoarele produse: ";
                foreach (Produs produs in listaProduse)
                {
                    mesaj = mesaj + produs.ToString() + Environment.NewLine;
                }
                return mesaj;
            }
            else
            {
                return mesaj;
            }
        }
        public static Raion operator +(Raion raion, Produs produs)
        {
            raion.listaProduse.Add(produs);
            return raion;
        }
        public int Numar
        {
            get { return this.numar; }
            set { this.numar = value; }
        }

    }
}
