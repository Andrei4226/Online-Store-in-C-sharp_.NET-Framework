using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect
{
    public partial class Form2Binding : Form
    {
        public Form2Binding(List<Client> listaClienti)
        {
            InitializeComponent();
            BindingSource bs = new BindingSource();
            bs.DataSource = listaClienti;
            bindingNavigator1.BindingSource = bs;
            tbNume.DataBindings.Add(new Binding("Text", bs, "Nume", true));
            tbAdresa.DataBindings.Add(new Binding("Text", bs, "Adresa", true));
            tbCategorie.DataBindings.Add(new Binding("Text", bs, "Categorie", true));
            tbVarsta.DataBindings.Add(new Binding("Text", bs, "Varsta", true));
            tbTelefon.DataBindings.Add(new Binding("Text", bs, "NrTelefon", true));
            tbGen.DataBindings.Add(new Binding("Text", bs, "Gen", true));
        }

        private void tbNume_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2Binding_Load(object sender, EventArgs e)
        {

        }
    }
}
