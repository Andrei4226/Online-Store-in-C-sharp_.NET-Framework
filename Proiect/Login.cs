using System;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Proiect
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            tbUserName.AllowDrop = true;
            tbParola.AllowDrop = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string name = tbUserName.Text;
            string password = tbParola.Text;
            SQLiteConnection con = new SQLiteConnection("Data Source = E:\\Baze de date\\Database1.db");
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
            sQLiteCommand.CommandText = "SELECT * from User";

            sQLiteDataReader = sQLiteCommand.ExecuteReader();
            int ok = 1;
            while (sQLiteDataReader.Read())
            {
                if (sQLiteDataReader.GetString(0) == name && sQLiteDataReader.GetString(1) == password)
                {
                    MessageBox.Show("Conectare cu succes!");
                    Form1 form1 = new Form1();
                    form1.Show();
                    ok = 0;
                    break;
                }
            }
            if(ok == 1)
                {
                    MessageBox.Show("Nu s-a reusit conectarea!");
                }
            con.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbParola.Clear();
            tbUserName.Clear();
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            CreateAccount createAccount = new CreateAccount();
            createAccount.Show();
        }

        private void btnLogin_DragEnter(object sender, DragEventArgs e)
        {
         
        }

        private void tbUserName_DragEnter(object sender, DragEventArgs e)
        {
            //verifica dacă datele de tragerii sunt de tip txt
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                //se va realiza o copie prin tragere
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void tbUserName_DragDrop(object sender, DragEventArgs e)
        {
            // verifica daca datele de tragerii sunt de tip text
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                // obtine textul din sursa tragerii
                string draggedText = (string)e.Data.GetData(DataFormats.Text);

                // adauga textul 
                tbUserName.Text += draggedText;
            }
        }

        private void tbParola_DragEnter(object sender, DragEventArgs e)
        {
            // verifica daca datele de tragerii sunt de tip txt
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                //se va realiza o copie prin tragere
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void tbParola_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                // obtine textul din sursa tragerii
                string draggedText = (string)e.Data.GetData(DataFormats.Text);

                // Adauga textul
                tbParola.Text += draggedText;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Meniu meniu = new Meniu();
            meniu.Show();
        }
    }
}
