using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect
{
    public partial class Form1Binding : Form
    {
        List<Client> listaClienti = new List<Client>() { };
      
        public Form1Binding()
        {
            InitializeComponent();
            SQLiteConnection con = new SQLiteConnection("Data Source = E:\\Baze de date\\Clienti.db");
            try
            {
                con.Open();
            }
            catch
            {
                Console.WriteLine("DB con open error");
            }
            SQLiteDataReader sQLiteDataReader;
            SQLiteCommand sQLiteCommand = con.CreateCommand();
            sQLiteCommand.CommandText = "SELECT * from Clienti";

            sQLiteDataReader = sQLiteCommand.ExecuteReader();
            int ok = 1;
            while (sQLiteDataReader.Read())
            {

                string nume = sQLiteDataReader.GetString(0);
                string adresa = sQLiteDataReader.GetString(1);
                string categorie = sQLiteDataReader.GetString(2);
                int varsta = sQLiteDataReader.GetInt32(3);
                string telefon = sQLiteDataReader.GetString(4);
                string gen = sQLiteDataReader.GetString(5);
                Client c = new Client(nume, adresa, categorie, varsta, telefon, gen);
                listaClienti.Add(c);
                ok = 0;
            }
            if (ok == 1)
            {
                MessageBox.Show("Nu s-a reusit conectarea!");
            }
            con.Close();
            DataTable dt = new DataTable();
            dt.Columns.Add("Nume:");
            dt.Columns.Add("Adresa:");
            dt.Columns.Add("Categorie:");
            dt.Columns.Add("Varsta:");
            dt.Columns.Add("Telefon:");
            dt.Columns.Add("Gen:");
            dgvClienti.DataSource = listaClienti;

        }
        private void Form1Binding_Load(object sender, EventArgs e)
        {
        }

        private void btnPopuleaza_Click(object sender, EventArgs e)
        {
            lbClienti.DataSource = listaClienti;
            tbClienti.DataBindings.Add(new Binding("Text", listaClienti, ""));
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if(((Button)sender).Tag as string == "Prev")
            {
                BindingContext[listaClienti].Position -= 1;
            }
            else
            {
                BindingContext[listaClienti].Position += 1;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(((Button)sender).Tag as string == "Next")
            {
                BindingContext[listaClienti].Position += 1;
            }
            else
            {
                BindingContext[listaClienti].Position -= 1;
            }
        }

        private void btnAfisareDGV_Click(object sender, EventArgs e)
        {
            Client c = (Client)dgvClienti.CurrentRow.DataBoundItem;
            MessageBox.Show(c.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2Binding form2Binding = new Form2Binding(listaClienti);
            form2Binding.Show();
        }
    }
}
