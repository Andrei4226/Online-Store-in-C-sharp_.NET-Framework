using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect
{
    internal class Student:Client
    {
        private int idStudent;
        private int cnp;

        public Student():base()
        {
            idStudent = 0;
            cnp = 0;
        }
        public Student(int idStudent, int cnp, string denumire, string adresa, string categorie, int varsta, string nrTelefon, string gen):
            base(denumire,adresa,categorie,varsta,nrTelefon,gen)
        {
            this.idStudent = idStudent;
            this.cnp = cnp;
        }
        public int IdStudent
        {
            get { return this.idStudent; }
            set
            {
                this.idStudent = value;
            }
        }
        public int CNP
        {
            get { return this.cnp; }
            set { this.cnp = value; }
        }
        public override string ToString()
        {
            return base.ToString() + ". Acesta are id-ul de student: " + this.idStudent + " si CNP-ul: " + this.cnp + ".";
        }
    }
}
