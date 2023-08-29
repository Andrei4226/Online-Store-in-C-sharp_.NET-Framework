using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using System.Xml.Schema;

namespace Proiect
{
    internal class Magazin
    {
        private string denumire;
        private int numar;
        private string zona;
        private string tip;
        private string[] plata;
        private List<Raion> listaRaioane;

        public Magazin()
        {
            denumire = "";
            numar = 0;
            zona = "";
            tip = "";
            plata = null;
            listaRaioane = null;
        }
        public Magazin(string denumire, int numar, string zona, string tip, string[] plata, List<Raion> listaRaioane)
        {
            this.denumire = denumire;
            this.numar = numar;
            this.zona = zona;
            this.tip = tip;
            this.plata = new string[plata.Length];
            for(int i=0;i<plata.Length; i++)
            {
                this.plata[i] = plata[i];
            }
            this.listaRaioane = new List<Raion>();
            foreach(Raion raion in listaRaioane)
            {
                this.listaRaioane.Add(raion);
            }
        }
        public string Denumire
        {
            get { return this.denumire; }
            set { this.denumire = value; }
        }
        public int Numar
        {
            get {  return numar; }
            set
            {
                this.numar = value;
            }
        }
        public string Zona
        {
            get { return this.zona; }
            set
            {
                this.zona = value;
            }
        }
        public string Tip
        {
            get { return this.tip; }
            set { this.tip = value; }
        }
        public string[] Plata
        {
            get { return this.plata; }
            set { this.plata = value; }
        }
        public List<Raion> ListaRaioane
        {
            get { return this.listaRaioane; }
            set
            {
                this.listaRaioane= value;
            }
        }
        public override string ToString()
        {
            
            string mesaj = "Numele magazinului este " + this.denumire + " cu numarul " + this.numar + " si se afla in " + this.zona + "." + Environment.NewLine +
                           "Magazinul este de tip " + this.tip + " si are urmatoarele metode de plata: ";
            for(int i=0;i<this.plata.Length;i++)
            {
                mesaj = mesaj + this.plata[i].ToString() + " ";  
            }
            mesaj = mesaj +"."+ Environment.NewLine;
            if (this.ListaRaioane.Count != 0)
            {
                mesaj = mesaj + "Magazinul contine " + this.listaRaioane.Count() + " raioane: ";
                foreach (Raion raion in this.listaRaioane)
                {
                    mesaj = mesaj + raion.Denumire + " ";
                }
                return mesaj;
            }
            else
            {
                return mesaj;
            }

        }
        public string this[int index]
        {
            get
            {
                if (index >= 0 && index < plata.Length)
                {
                    return plata[index];
                }
                else
                {
                    throw new Exceptie();
                }

            }
            set
            {
                plata[index] = value;
            }
        }
       
        public static Magazin operator +(Magazin m, string notaPlataNoua)
        {
            string[] metodeNoi = new string[m.plata.Length + 1];
            for (int i = 0; i < m.plata.Length; i++)
            {
                metodeNoi[i] = m.plata[i];
            }
            metodeNoi[metodeNoi.Length - 1] = notaPlataNoua;
            m.plata = metodeNoi;
            return m;
        }
        public static Magazin operator-(Magazin m, Raion sters)
        {
            m.listaRaioane.Remove(sters);
            return m;
        }
    }
}
