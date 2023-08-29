using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Xml;
using System.Drawing.Printing;


namespace Proiect
{
    public partial class Form1 : Form
    {
        int id;
        List<Magazin> listaMagazin = new List<Magazin> { };
        List<Raion> listaRaioane = new List<Raion>() { };
        List<Produs> listaProduse = new List<Produs> { };
        List<Client> listaClienti = new List<Client>() { };
        List<Produs> produseClient = new List<Produs>() { };
        List<Vanzare> listaVanzari = new List<Vanzare>() { };

        int magazinAles;
        public Form1()
        {
            id = 1;
            InitializeComponent();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            ControlExtension.Draggable(tbDenumireMagazin, true);
            ControlExtension.Draggable(tbNumarMagazin, true);
            ControlExtension.Draggable(tbZonaMagazin, true);
            ControlExtension.Draggable(tbTipMagazin, true);
            ControlExtension.Draggable(tbPlataMagazin, true);

            ControlExtension.Draggable(tbNumeRaion, true);
            ControlExtension.Draggable(tbStocProduseRaion, true);
            ControlExtension.Draggable(tbNumarMagazinRaion, true);
            ControlExtension.Draggable(tbRandRaion, true);
            
            ControlExtension.Draggable(tbNumeProdus, true);
            ControlExtension.Draggable(tbCantitateProdus, true);
            ControlExtension.Draggable(tbPretProdus, true);
            ControlExtension.Draggable(tbNumarRaionProdus, true);
            ControlExtension.Draggable(tbNumarMagazinProdus, true);

            ControlExtension.Draggable(tbGenClient, true);
            ControlExtension.Draggable(tbNumeClient, true);
            ControlExtension.Draggable(tbVarstaClient, true);
            ControlExtension.Draggable(tbCategorieClient, true);
            ControlExtension.Draggable(tbAdresaClient, true);
            ControlExtension.Draggable(tbTelefonClient, true);

            ControlExtension.Draggable(btnListaClienti, true);
            ControlExtension.Draggable(btnGolireClient, true);
            ControlExtension.Draggable(btnGolireMagazin, true);
            ControlExtension.Draggable(btnGolireCos, true);
            ControlExtension.Draggable(btnGolireVanzari, true);
           
            ControlExtension.Draggable(tbListaProduse, true);
            ControlExtension.Draggable(tbProdusDorit, true);
            ControlExtension.Draggable(tbCantitateCos, true);
            ControlExtension.Draggable(tbPretAfisare, true);
            ControlExtension.Draggable(tbCos, true);
            ControlExtension.Draggable(tbPlataDorita, true);
            ControlExtension.Draggable(tbVanzariEfectuate, true);

            ControlExtension.Draggable(pictureBox1, true);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdaugareMagazin_Click(object sender, EventArgs e)
        {
            string denumireMagazin = tbDenumireMagazin.Text;
            string numarMagazinString = tbNumarMagazin.Text;
            int numarMagazin = int.Parse(numarMagazinString);
            string zonaMagazin = tbZonaMagazin.Text;
            string tipMagazin = tbTipMagazin.Text;
            string[] metodePlataMagazin = tbPlataMagazin.Text.Split(',');

            // Verifica daca magazinul exista deja in lista
            bool magazinExista = false;
            foreach (Magazin mag in listaMagazin)
            {
                if (mag.Numar == numarMagazin)
                {
                    magazinExista = true;
                    break;
                }
            }

            if (!magazinExista)
            {
                if (numarMagazin > 0 && denumireMagazin.Length != 0 && zonaMagazin.Length != 0 && tipMagazin.Length != 0 && metodePlataMagazin.Length != 0)
                {
                    Magazin magazin = new Magazin(denumireMagazin, numarMagazin, zonaMagazin, tipMagazin, metodePlataMagazin, listaRaioane);

                    listaMagazin.Add(magazin);
                    MessageBox.Show(magazin.ToString());

                    SQLiteConnection conexiune = new SQLiteConnection("Data Source = E:\\Baze de date\\DatabaseMagazin.db");
                    try
                    {
                        conexiune.Open();
                    }
                    catch
                    {
                        Console.WriteLine("Eroare");
                    }

                    string inserare = "INSERT INTO Magazin (Denumire, ID,Zona,Tip) VALUES (@Parametru1, @Parametru2,@Parametru3,@Parametru4)";
                    using (SQLiteCommand command = new SQLiteCommand(inserare, conexiune))
                    {
                        command.Parameters.AddWithValue("@Parametru1", magazin.Denumire);
                        command.Parameters.AddWithValue("@Parametru2", magazin.Numar);
                        command.Parameters.AddWithValue("@Parametru3", magazin.Zona);
                        command.Parameters.AddWithValue("@Parametru4", magazin.Tip);

                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Magazinul a s-a adaugat cu succes in baza de date!");
                    conexiune.Close();

                    tbDenumireMagazin.Clear();
                    tbNumarMagazin.Clear();
                    tbZonaMagazin.Clear();
                    tbTipMagazin.Clear();
                    tbPlataMagazin.Clear();
                }
                else
                {
                    MessageBox.Show("Eroare!");
                }
            }
            else
            {
                MessageBox.Show("Magazinul exista deja");
            }

        }

        private void btnAdaugareProdus_Click(object sender, EventArgs e)
        {
            string numeProdus = tbNumeProdus.Text;
            string cantitateProdusString = tbCantitateProdus.Text;
            int cantitateProdus = int.Parse(cantitateProdusString);
            string pretProdusString = tbPretProdus.Text;
            int pretProdus = int.Parse(pretProdusString);
            string numarRaionString = tbNumarRaionProdus.Text;
            int numarRaionProdus = int.Parse(numarRaionString);
            string numarMagazinString = tbNumarMagazinProdus.Text;
            int numarMagazin = int.Parse(numarMagazinString);

            int suma = 0;
            //verificare existenta magazin
            bool magazinExista = false;
            Magazin ales = new Magazin();

            foreach (Magazin mag in listaMagazin)
            {
                if (mag.Numar == numarMagazin)
                {
                    ales = mag;
                    magazinExista = true;
                    break;
                }
            }

            //verificare existeta raion
            bool raionExista = false;
            Raion raionAles = new Raion();

            foreach (Raion raion in ales.ListaRaioane)
            {
                if (raion.Numar == numarRaionProdus)
                {
                    raionAles = raion;
                    raionExista = true;
                    break;
                }
            }
            if (magazinExista == true)
            {
                if (raionExista == true)
                {
                    if (cantitateProdus <= raionAles.StocProduse && suma <= raionAles.StocProduse)
                    {
                        if (numeProdus.Length != 0 && cantitateProdus>0 && pretProdus>0 && numarRaionProdus >0&& numarMagazin>0)
                        {
                            suma = suma + cantitateProdus;
                            Produs produs = new Produs(numeProdus, pretProdus, cantitateProdus);
                            raionAles.ListaProduse.Add(produs);
                            MessageBox.Show(produs.ToString());

                            SQLiteConnection conexiune = new SQLiteConnection("Data Source = E:\\Baze de date\\Produse.db");
                            try
                            {
                                conexiune.Open();
                            }
                            catch
                            {
                                Console.WriteLine("Eroare");
                            }

                            string inserare = "INSERT INTO Produse (Denumire,Pret,Cantitate) VALUES (@Parametru1, @Parametru2,@Parametru3)";
                            using (SQLiteCommand command = new SQLiteCommand(inserare, conexiune))
                            {
                                command.Parameters.AddWithValue("@Parametru1", produs.Denumire);
                                command.Parameters.AddWithValue("@Parametru2", produs.Pret);
                                command.Parameters.AddWithValue("@Parametru3", produs.Cantitate);

                                command.ExecuteNonQuery();
                            }
                            MessageBox.Show("Produsul s-a adaugat cu succes in baza de date!");
                            conexiune.Close();

                            tbNumeProdus.Clear();
                            tbCantitateProdus.Clear();
                            tbPretProdus.Clear();
                            tbNumarRaionProdus.Clear();
                            tbNumarMagazinProdus.Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Eliminati din cantitate pentru a putea fi cantitatea produsului adaugata in stoc.");
                    }

                }
                else
                {
                    MessageBox.Show("Nu exista acest raion.");
                }
            }
            else
            {
                MessageBox.Show("Nu exista acest magazin.");
            }
        }

        private void btnAdaugareRaion_Click(object sender, EventArgs e)
        {
            string denumireRaion = tbNumeRaion.Text;
            string stocRaionString = tbStocProduseRaion.Text;
            int stocRaion = int.Parse(stocRaionString);
            string numarMagazinString = tbNumarMagazinRaion.Text;
            int numarMagazin = int.Parse(numarMagazinString);
            string nrRaionString = tbRandRaion.Text;
            int nrRaion = int.Parse(nrRaionString);


            bool magazinExista = false;
            Magazin ales = new Magazin();

            foreach (Magazin mag in listaMagazin)
            {
                if (mag.Numar == numarMagazin)
                {
                    ales = mag;
                    magazinExista = true;
                    break;
                }
            }

            //verificare existenta raion
            bool raionExista = true;
            
            foreach (Raion raion in ales.ListaRaioane)
            {
                if (raion.Numar == nrRaion)
                {
                    raionExista = false;
                    break;
                }
            }

            if (magazinExista == true)
            {
                if (raionExista == true)
                {
                    if (denumireRaion.Length != 0 && stocRaion > 0 && numarMagazin > 0 && nrRaion > 0)
                    {
                        Raion raion = new Raion(denumireRaion, stocRaion, listaProduse, nrRaion);
                        ales.ListaRaioane.Add(raion);
                        MessageBox.Show(raion.ToString());

                        tbNumeRaion.Clear();
                        tbStocProduseRaion.Clear();
                        tbNumarMagazinRaion.Clear();
                        tbRandRaion.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Raionul exista deja in magazinul selectat.");
                }

            }
            else
            {
                MessageBox.Show("Nu exista acest magazin!");
            }

        }

        private void btnAdaugaClient_Click(object sender, EventArgs e)
        {
            string genClient = tbGenClient.Text;
            string numeClient = tbNumeClient.Text;
            string varstaClientString = tbVarstaClient.Text;
            int varstaClient = int.Parse(varstaClientString);
            string categorieClient = tbCategorieClient.Text;
            string adresaClient = tbAdresaClient.Text;
            string numarTelefonClient = tbTelefonClient.Text;
            if (genClient.Length != 0 && numeClient.Length!=0 && varstaClient > 0 && categorieClient.Length !=0 && adresaClient.Length!=0 && numarTelefonClient.Length!=0)
            {
                Client client = new Client(numeClient, adresaClient, categorieClient, varstaClient, numarTelefonClient, genClient);
                listaClienti.Add(client);
                MessageBox.Show(client.ToString());

                SQLiteConnection conexiune = new SQLiteConnection("Data Source = E:\\Baze de date\\Clienti.db");
                try
                {
                    conexiune.Open();
                }
                catch
                {
                    Console.WriteLine("Eroare");
                }

                string inserare = "INSERT INTO Clienti (Nume, Adresa, Categorie,Varsta,Telefon,Gen) VALUES (@Parametru1, @Parametru2,@Parametru3,@Parametru4,@Parametru5,@Parametru6)";
                using (SQLiteCommand command = new SQLiteCommand(inserare, conexiune))
                {
                    command.Parameters.AddWithValue("@Parametru1", client.Nume);
                    command.Parameters.AddWithValue("@Parametru2", client.Adresa);
                    command.Parameters.AddWithValue("@Parametru3", client.Categorie);
                    command.Parameters.AddWithValue("@Parametru4", client.Varsta);
                    command.Parameters.AddWithValue("@Parametru5", client.NrTelefon);
                    command.Parameters.AddWithValue("@Parametru6", client.Gen);

                    command.ExecuteNonQuery();
                }
                MessageBox.Show("Clientul s-a adaugat cu succes in baza de date!");
                conexiune.Close();

                tbGenClient.Clear();
                tbNumeClient.Clear();
                tbVarstaClient.Clear();
                tbCategorieClient.Clear();
                tbAdresaClient.Clear();
                tbTelefonClient.Clear();
            }
        }

        private void tbInformatiiClient_TextChanged(object sender, EventArgs e)
        {


        }

        private void tbNrMagazinDorit_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnMagazinAles_Click(object sender, EventArgs e)
        {
            tbListaProduse.Text = "";

            Magazin magazinDorit = new Magazin();
            bool verificare = false;
            

            foreach(Magazin magazin in listaMagazin)
            {
                if(magazinAles == magazin.Numar)
                {
                    verificare = true;
                    magazinDorit = magazin;
                    break;
                    
                }
            }
            
            if(verificare == true)
            {
               foreach (Raion raion in magazinDorit.ListaRaioane)
               {
                    tbListaProduse.Text += raion.ToString() + Environment.NewLine;
                   
               }
                tbListaProduse.Text = tbListaProduse.Text + "Metode de plata: ";
                for (int i = 0; i < magazinDorit.Plata.Length; i++)
                {
                    tbListaProduse.Text += magazinDorit.Plata[i] + " ";
                }
                tbListaProduse.Text += "." + Environment.NewLine;
            }
            
           
        }

        private void btnAdaugaProdus_Click(object sender, EventArgs e)
        {
            if (listaClienti.Count != 0)
            {
                string produsDorit = tbProdusDorit.Text;
                string produsDoritCantitateString = tbCantitateCos.Text;
                int produsDoritCantitate = int.Parse(produsDoritCantitateString);

                int suma = 0;
                foreach (Magazin magazin in listaMagazin)
                {
                    if (magazinAles == magazin.Numar)
                    {
                        foreach (Raion raion in magazin.ListaRaioane)
                        {
                            foreach (Produs produs in raion.ListaProduse)
                            {
                                if (produs.Denumire.Equals(produsDorit))
                                {
                                    if (suma <= produs.Cantitate && produsDoritCantitate <= produs.Cantitate)
                                    {
                                        suma = suma + produsDoritCantitate;
                                        Produs produsClient = new Produs(produs.Denumire, produs.Pret, produsDoritCantitate);
                                        produs.Cantitate = produs.Cantitate - produsDoritCantitate;
                                        produseClient.Add(produsClient);
                                        break;
                                    }
                                    else
                                    {
                                        MessageBox.Show("Cantitate invalida!");
                                    }
                                }
                            }
                        }
                        break;
                    }
                }
            }
        }

        private void btnVizualizeazaCos_Click(object sender, EventArgs e)
        {
            tbCos.Text = "";
            foreach (Produs produs in produseClient)
            {
                tbCos.Text += produs.ToString() + Environment.NewLine;
            }

        }

        private void btnCumpara_Click(object sender, EventArgs e)
        {
            string metoda = tbPlataDorita.Text;

            bool existena = false;
            Magazin ales = new Magazin();

            foreach(Magazin magazin in listaMagazin)
            {
                if(magazin.Numar == magazinAles)
                {
                    existena = true;
                    ales = magazin;
                    break;
                }
            }
            bool existena_plata = false;
            if (existena == true)
            {
                if (produseClient.Count == 0 || metoda != null)
                {
                    for(int i = 0; i < ales.Plata.Length; i++)
                    {
                        if (ales.Plata[i].Equals(metoda))
                        {
                            existena_plata = true;
                        }
                    }
                    if (existena_plata == true)
                    {
                        Vanzare vanzare = new Vanzare(id, produseClient, metoda);

                        SQLiteConnection conexiune = new SQLiteConnection("Data Source = E:\\Baze de date\\DatabaseVanzari.db");
                        try
                        {
                            conexiune.Open();
                        }
                        catch
                        {
                            Console.WriteLine("Eroare");
                        }

                        string inserare = "INSERT INTO Vanzari (ID, Valoare,Plata) VALUES (@Parametru1, @Parametru2,@Parametru3)";
                        using (SQLiteCommand command = new SQLiteCommand(inserare, conexiune))
                        {
                            command.Parameters.AddWithValue("@Parametru1", vanzare.Id);
                            command.Parameters.AddWithValue("@Parametru2", vanzare.calculeazaValoareaTotala());
                            command.Parameters.AddWithValue("@Parametru3", vanzare.MetodaPlata);

                            command.ExecuteNonQuery();
                        }
                        MessageBox.Show("Vanzarea s-a adaugat cu succes in baza de date!");
                        conexiune.Close();
                        listaVanzari.Add(vanzare);
                        id++;
                    }
                    else
                    {
                        MessageBox.Show("Metoda de plata invalida!");
                    }
                }
                else
                {
                    MessageBox.Show("Adaugati produse in cos si o metoda de plata valida!");
                }
            }
        }

        private void btnVizualizareVanzari_Click(object sender, EventArgs e)
        {
            tbVanzariEfectuate.Text = "";
            foreach(Vanzare vanzare in listaVanzari)
            {
                tbVanzariEfectuate.Text = tbVanzariEfectuate.Text + vanzare.ToString() + Environment.NewLine;
            }
        }

        private void tbVanzariEfectuate_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnListaClienti_Click(object sender, EventArgs e)
        {
            tbInformatiiClient.Clear();
            foreach(Client client in listaClienti)
            {
                tbInformatiiClient.Text += client.ToString() + Environment.NewLine;
            }
        }

        private void btnAplica_Click(object sender, EventArgs e)
        {
            string alesString = tbNrMagazinDorit.Text;
            int ales = int.Parse(alesString);
         
            
            bool magazinExista = false;
            foreach(Magazin magazin in listaMagazin)
            {
                if(magazin.Numar == ales)
                {
                    magazinExista = true;
                  
                    break;
                   
                }      
            }

            if(magazinExista == true)
            {
                magazinAles = ales;
               
            }
            else
            {
                MessageBox.Show("Magazinul nu exista.");
            }

        }

        private void tbPretAfisare_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbProdusDorit_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnVeziPret_Click(object sender, EventArgs e)
        {
            int suma = 0;
            string produsDorit = tbProdusDorit.Text;
            string cantitateProdusDoritString = tbCantitateCos.Text;
            int cantitateProdusDorit = int.Parse(cantitateProdusDoritString);
            foreach (Magazin magazin in listaMagazin)
            {
                if (magazinAles == magazin.Numar)
                {
                    int ok = 0;
                    foreach (Raion raion in magazin.ListaRaioane)
                    {
                        if (ok == 0)
                        {
                            foreach (Produs produs in raion.ListaProduse)
                            {
                                if (produs.Denumire.Equals(produsDorit))
                                { 
                                    if (cantitateProdusDorit <= produs.Cantitate && suma <= produs.Cantitate)
                                    {
                                        if (cantitateProdusDorit > 0)
                                        {
                                            ok = 1;
                                            suma = suma + cantitateProdusDorit;
                                            float pretAfisare = produs.calculeazaValoare(cantitateProdusDorit);
                                            tbPretAfisare.Text = Convert.ToString(pretAfisare);
                                            break;
                                        }
                                    }
                                    else
                                    {
                                            MessageBox.Show("Cantitate invalida!");
                                    }
                                }
                                
                            }
                        }
                        else
                        {
                            break;
                        }

                    }
                    break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbListaProduse.Clear();
        }

        private void btnGolireCos_Click(object sender, EventArgs e)
        {
            tbCos.Clear();
        }

        private void btnGolireVanzari_Click(object sender, EventArgs e)
        {
            tbVanzariEfectuate.Clear();
        }

        private void fisiereToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void salvareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "(*.txt)|*.txt";
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
               
                sw.WriteLine("Vanzari salvate: ");
                foreach(Vanzare i in listaVanzari)
                {
                    sw.WriteLine(i.ToString());
                    sw.WriteLine(Environment.NewLine);
                }
               
                sw.Close();
                
                tbVanzariEfectuate.Clear();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            tbInformatiiClient.Clear();
        }

        private void restaurareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "(*.txt)|*.txt)";
            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                tbVanzariEfectuate.Text = sr.ReadToEnd();
                sr.Close();
            }
        }

        private void salvareToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (listaVanzari.Count > 0)
            {
                FileStream fs = new FileStream("fisierVanzari.dat", FileMode.Create, FileAccess.Write);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, listaVanzari);
                fs.Close();
                tbVanzariEfectuate.Clear();
                MessageBox.Show("S-a salvat fisierul binar!");
            }
        }

        private void restaurareToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("fisierVanzari.dat", FileMode.Open, FileAccess.Read);
            BinaryFormatter bf = new BinaryFormatter();
            listaVanzari.Clear();
            listaVanzari = (List<Vanzare>)bf.Deserialize(fs);
            foreach (Vanzare i in listaVanzari)
            {
                tbVanzariEfectuate.Text = tbVanzariEfectuate.Text + i.ToString() + Environment.NewLine;
            }
            fs.Close();
        }

        private void restaurareToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            tbInformatiiClient.Clear();
            string filePath = "D:/Desktop/Facultate/Anul 2/Semestrul 2/Programarea aplicatiilor Windows/Proiect/fisier.xml";

            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(filePath);

                // accesati elementele si atributele din fisierul XML
                XmlNodeList clientNodes = xmlDocument.SelectNodes("//client");
                foreach (XmlNode clientNode in clientNodes)
                {
                    string gen = clientNode.SelectSingleNode("gen").InnerText;
                    string nume = clientNode.SelectSingleNode("nume").InnerText;
                    int varsta = Convert.ToInt32(clientNode.SelectSingleNode("varsta").InnerText);
                    string categorie = clientNode.SelectSingleNode("categorie").InnerText;
                    string adresa = clientNode.SelectSingleNode("adresa").InnerText;
                    string numarTelefon = clientNode.SelectSingleNode("telefon").InnerText;

                    
                    tbInformatiiClient.Text += "Gen: " + gen + "." + Environment.NewLine + "Clientul cu numele " + nume +
                        " are varsta de " + varsta + " ani si este " + categorie + "." + Environment.NewLine +
                        "Adresa: " + adresa + "." + Environment.NewLine + "Numar de telefon: " + numarTelefon + "." + Environment.NewLine;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("A aparut o eroare la citirea fișierului XML: " + ex.Message);
            }

        }

        private void salvareToolStripMenuItem2_Click(object sender, EventArgs e)
        {

           
            XmlDocument xmlDocument = new XmlDocument();

            // creare radacina
            XmlElement radacinaElement = xmlDocument.CreateElement("clienti");
            xmlDocument.AppendChild(radacinaElement);

            // iterarea prin lista de clienti si adaugarea fiecarui client ca nod 
            foreach (Client client in listaClienti)
            {
                // crearea elementului pentru client
                XmlElement clientElement = xmlDocument.CreateElement("client");

                // adaugarea atributelor pentru client (gen, nume, varsta, categorie)
                clientElement.SetAttribute("gen", client.Gen);
                clientElement.SetAttribute("nume", client.Nume);
                clientElement.SetAttribute("varsta", client.Varsta.ToString());
                clientElement.SetAttribute("categorie", client.Categorie);

                // crearea elementelor pentru adresa si nr tel
                XmlElement adresaElement = xmlDocument.CreateElement("adresa");
                adresaElement.InnerText = client.Adresa;
                clientElement.AppendChild(adresaElement);

                XmlElement numarTelefonElement = xmlDocument.CreateElement("telefon");
                numarTelefonElement.InnerText = client.NrTelefon;
                clientElement.AppendChild(numarTelefonElement);

                // adaugarea elementului client in rad
                radacinaElement.AppendChild(clientElement);
            }

            // salvarea documentului XML 
            xmlDocument.Save("D:/Desktop/Facultate/Anul 2/Semestrul 2/Programarea aplicatiilor Windows/Proiect/clienti.xml");
            tbInformatiiClient.Clear();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void imprimareVanzariToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbVanzariEfectuate.Text))
            {
                PrintDocument document = new PrintDocument();
                document.DocumentName = "VanzariImprimate";
                document.PrintPage += (s, ev) =>
                {
                    using (Font font = new Font("Arial", 12))
                    {
                        using (SolidBrush brush = new SolidBrush(Color.Black))
                        {
                            float y = ev.MarginBounds.Top;
                            string[] lines = tbVanzariEfectuate.Text.Split('\n');
                            foreach (string line in lines)
                            {
                                ev.Graphics.DrawString(line, font, brush, ev.MarginBounds.Left, y, new StringFormat());
                                y += font.GetHeight();
                            }
                        }
                    }
                };

                System.Windows.Forms.PrintDialog printDialog = new System.Windows.Forms.PrintDialog();
                printDialog.Document = document;
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    document.Print();
                }
            }
            else
            {
                MessageBox.Show("Adaugati si afisati vanzarile adaugate!");
            }

        }

        private void imprimareClientiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbInformatiiClient.Text))
            {
                PrintDocument document = new PrintDocument();
                document.DocumentName = "ClientiImprimati";
                document.PrintPage += (s, ev) =>
                {
                    using (Font font = new Font("Arial", 12))
                    {
                        using (SolidBrush brush = new SolidBrush(Color.Black))
                        {
                            float y = ev.MarginBounds.Top;
                            string[] lines = tbInformatiiClient.Text.Split('\n');
                            foreach (string line in lines)
                            {
                                ev.Graphics.DrawString(line, font, brush, ev.MarginBounds.Left, y, new StringFormat());
                                y += font.GetHeight();
                            }
                        }
                    }
                };

                System.Windows.Forms.PrintDialog printDialog = new System.Windows.Forms.PrintDialog();
                printDialog.Document = document;
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    document.Print();
                }
            }
            else
            {
                MessageBox.Show("Adaugati si afisati clientii adaugati!");
            }
        }

        private void creareContToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateAccount account = new CreateAccount();
            account.Show();
        }

        private void logareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login logare = new Login();
            logare.Show();
        }

        private void graficToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Grafic grafic = new Grafic();
            grafic.Show();
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //panel.Controls.Add(chart); // adaugă controlul grafic în panou
        }

        private void btnCopyClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(tbListaProduse.Text);
        }

        private void btnMeniu_Click(object sender, EventArgs e)
        {
            Meniu meniu = new Meniu();
            meniu.Show();
        }

        private void bindingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1Binding form1Binding = new Form1Binding();
            form1Binding.Show();
        }

        private void tbDenumireMagazin_KeyDown(object sender, KeyEventArgs e)
        {
        //    if (e.Control == true && e.KeyCode == Keys.S)
        //    {
        //        graficToolStripMenuItem.PerformClick();

        //    }
        //    if (e.Control == true && e.KeyCode == Keys.X)
        //    {
        //        this.Close();
        //    }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.S)
            {
                graficToolStripMenuItem.PerformClick();

            }
            if (e.Control == true && e.KeyCode == Keys.X)
            {
                this.Close();
            }
        }
    }
}

