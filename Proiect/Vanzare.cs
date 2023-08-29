using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect
{
    [Serializable]
    internal class Vanzare
    {
        private int id;
        private List<Produs> listaProduse;
        public string metodaPlata;
        
        public Vanzare()
        {
            id = 0;
            listaProduse = null;
            metodaPlata = null;
        }
        public Vanzare(int id, List<Produs>listaProduse, string metodaPlata)
        {
            this.id = id;
            this.listaProduse = new List<Produs>();
            foreach(Produs produs in listaProduse)
            {
                this.listaProduse.Add(produs);
            }
            if (metodaPlata != null)
            {
                this.metodaPlata = metodaPlata;
            }
        }
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public List<Produs> ListaProduse
        {
            get { return this.listaProduse; }
            set { this.listaProduse = value; }
        }
        public string MetodaPlata
        {
            get { return this.metodaPlata; }
            set
            {
                this.metodaPlata = value;
            }
        }
       
        public float calculeazaValoareaTotala()
        {
            float valoare = 0;
            foreach (Produs produs in this.listaProduse)
            {
                valoare = valoare + produs.Pret * produs.Cantitate;
            }
            return valoare;
        }
        public override string ToString()
        {
            string mesaj = "Vanzarea are id-ul: " + this.id + "." + Environment.NewLine +
                    "Vanzarea contine urmatoarele produse: " + Environment.NewLine;
            foreach (Produs produs in listaProduse)
            {
                mesaj = mesaj + produs.ToString() + Environment.NewLine;
            }
            mesaj = mesaj + "Tranzactia a fost realizata prin metoda de plata: " + this.metodaPlata + '.' + Environment.NewLine;
            mesaj = mesaj + "Valoarea totala este de: " + this.calculeazaValoareaTotala() + '.';
            return mesaj;
        }
    }
}
