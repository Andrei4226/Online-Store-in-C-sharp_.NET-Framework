using System;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Data.SQLite;
using System.Text.RegularExpressions;
using Proiect;

namespace Proiect
{
    public partial class CreateAccount : Form
    {
        int validare_parola;
        bool validare_mail;
        bool mail_trimis;
        int codUnique;
        public CreateAccount()
        {
            validare_parola = 0;
            codUnique = 0;
            validare_mail = false;
            mail_trimis = false;
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string usernameCreate = tbUsernameCreate.Text;
            string passwordCreate = tbPasswordCreate.Text;
            if(passwordCreate.Length != 8)
            {
                validare_parola = 1;
            }
            string emailCreate = tbEmailCreate.Text;
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
                if (sQLiteDataReader.GetString(0) == usernameCreate && sQLiteDataReader.GetString(2) == emailCreate)
                {
                    MessageBox.Show("Nu s-a reusit conectarea!");
                    ok = 0;
                    break;
                }
            }
            if (ok == 1 && validare_parola==1)
            {
                string inserare = "INSERT INTO User (Username, Password,Email) VALUES (@Parametru1, @Parametru2,@Parametru3)";
                using (SQLiteCommand command = new SQLiteCommand(inserare, con))
                {
                    command.Parameters.AddWithValue("@Parametru1", usernameCreate);
                    command.Parameters.AddWithValue("@Parametru2", passwordCreate);
                    command.Parameters.AddWithValue("@Parametru3", emailCreate);

                    command.ExecuteNonQuery();
                }
                MessageBox.Show("Contul s-a creat cu succes!");
            }
            else
            {
                MessageBox.Show("Nu s-a reusit crearea contului!");
            }
            con.Close();

        }

        private void btnSendValidation_Click(object sender, EventArgs e)
        {
            string email = tbEmailCreate.Text.Trim();
            string email_utilizator = tbEmailCreate.Text;

            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            Regex regex = new Regex(pattern);
           
            if (regex.IsMatch(email) == true)
            {
                MessageBox.Show("Adresa de mail este valida!");
            }
            else
            {
                MessageBox.Show("Adresa de mail nu este valida");
            }

            Random random = new Random();
            int code = random.Next(10000, 99999);
            codUnique = code;
            string codUniqueString = Convert.ToString(codUnique);

            string mailSend = email_utilizator;
            string sendPassword = tbPasswordCreate.Text;
            string subiect = "Validare adresa de email";
            string continut = $"Codul de verificare este: {codUnique}";

            string myadress = "robertandrei336@gmail.com";
            string fromPassword = "nqhdwokzpdhbzqgb";
            MailMessage message = new MailMessage();
            message.From = new MailAddress(myadress);
            message.Subject = subiect;
            message.To.Add(new MailAddress(email_utilizator));
            message.Body = "Cod: ";
            message.Body += codUniqueString;
            message.IsBodyHtml = true;

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(myadress, fromPassword),
                EnableSsl = true,
            };
            smtpClient.Send(message);
            mail_trimis = true;
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(mail_trimis==true)
            {
                string codPrimitString = tbCodPrimit.Text;
                int codPrimit = int.Parse(codPrimitString);
                if(codPrimit == codUnique)
                {
                    validare_mail= true;
                    MessageBox.Show("Adresa de mail a fost validata cu succes!");
                }
            }
        }

        private void btnMeniu_Click(object sender, EventArgs e)
        {
            Meniu meniu = new Meniu();
            meniu.Show();
        }
    }
}
