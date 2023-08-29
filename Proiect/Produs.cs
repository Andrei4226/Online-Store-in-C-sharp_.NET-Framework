using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Proiect
{
    [Serializable]
    internal class Produs: ICalculValoare, ICloneable,IComparable
    {
        private string denumire;
        private float pret;
        private int cantitate;

        public Produs()
        {
            this.denumire = "";
            this.pret = 0;
            this.cantitate = 0;
        }
        public Produs(string denumire, float pret, int cantitate)
        {
            this.denumire = denumire;
            this.pret = pret;
            this.cantitate=cantitate;
        }
        public string Denumire
        {
            get
            {
                return this.denumire;
            }
            set
            {
                this.denumire = value;
            }
        }
        public float Pret
        {
            get
            {
                return this.pret;
            }
            set
            {
                this.pret = value;
            }
        }
        public int Cantitate
        {
            get
            {
                return this.cantitate;
            }
            set
            {
                this.cantitate = value;
            }
        }
        public float calculeazaValoare(int cantitate)
        {
            return cantitate * this.pret;
        }
        public override string ToString()
        {
            return "Produsul cu denumirea " + this.denumire + " are pretul de " + this.pret + " si cantitatea de " + this.cantitate + " buc.";
        }
        public object Clone()
        {
            return new Produs
            {
            denumire = this.denumire,
            cantitate = this.cantitate,
            pret = this.pret
            };
        }
        public int  CompareTo(object obj)
        {
            Produs p = (Produs)obj;
            if (this.pret < p.pret)
            {
                return -1;
            }
            else
            {
                if (this.pret == p.pret)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
        }
    }
}
