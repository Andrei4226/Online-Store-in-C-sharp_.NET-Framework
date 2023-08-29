using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect
{
    public class Client : ICloneable,IComparable
    {
        private string nume;
        private string adresa;
        private string categorie;
        private int varsta;
        private string nrTelefon;
        private string gen;

        public Client()
        {
            nume = "";
            adresa = "";
            categorie = "";
            varsta = 0;
            nrTelefon = "";
            gen = "";
        }
        public Client(string nume, string adresa, string categorie, int varsta, string nrTelefon, string gen)
        {
            this.nume = nume;
            this.adresa = adresa;
            this.categorie = categorie;
            this.varsta = varsta;
            this.nrTelefon = nrTelefon;
            this.gen = gen;
        }
        public string Nume
        {
            get
            {
                return this.nume;
            }
            set
            {
                this.nume = value;
            }
        }
        public int Varsta
        {
            get { return this.varsta; }
            set { this.varsta = value; }
        }
        public string Adresa
        {
            get { return this.adresa; }
            set { this.adresa = value; }
        }
        public string Categorie
        {
            get { return this.categorie; }
            set
            {
                this.categorie = value;
            }
        }
        public string NrTelefon
        {
            get { return this.nrTelefon; }
            set
            {
                this.nrTelefon = value;
            }
        }
        public string Gen
        {
            get { return this.gen; }
            set
            {
                this.gen = value;
            }
        }
        public override string ToString()
        {
            return "Gen: " + this.gen + "."+ Environment.NewLine + "Clientul cu numele " + this.nume + " are varsta de " + this.varsta + " ani si este " + this.categorie + "." + Environment.NewLine +
               "Adresa: " + this.adresa + "." + Environment.NewLine + "Numar de telefon: " + this.nrTelefon + ".";
        }
        public object Clone()
        {
            return new Client
            {
                nume=this.nume,
                adresa=this.adresa,
                categorie=this.categorie,
                varsta=this.varsta,
                nrTelefon= this.nrTelefon,
                gen=this.gen
            };
        }
        public int CompareTo(object obj)
        {
            Client c = (Client)obj;
            if (this.varsta < c.varsta)
            {
                return -1;
            }
            else
            {
                if (this.varsta == c.varsta)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }

        }
        public static Client operator ++(Client c)
        {
            c.varsta++;
            return c;
        }
        public static Client operator--(Client c)
        {
            c.varsta--;
            return c;
        }
        public static bool operator <(Client c, int legal)
        {
            if (c.varsta < legal)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator >(Client c, int legal)
        {
            if (c.varsta > legal)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
