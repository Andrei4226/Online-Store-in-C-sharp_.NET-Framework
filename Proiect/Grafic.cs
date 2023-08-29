using System;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;
using System.Windows.Forms.Integration;
using System.Data.SQLite;

namespace Proiect
{
    public partial class Grafic : Form
    {
        public Grafic()
        {
            InitializeComponent();
        }

        private void incarcaDateToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void afisareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LiveCharts.Wpf.CartesianChart chart = new LiveCharts.Wpf.CartesianChart();

            // conectare la BD
            using (SQLiteConnection connection = new SQLiteConnection("Data Source = E:\\Baze de date\\DatabaseVanzari.db"))
            {
                connection.Open();

                string sql = "SELECT Valoare FROM Vanzari";
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        // initializare serie
                        LineSeries series = new LineSeries
                        {
                            Title = "Valoare",
                            Values = new ChartValues<int>()
                        };

                        // adauga valorile extrase la seria de date
                        while (reader.Read())
                        {
                            int valoare = reader.GetInt32(0);
                            series.Values.Add(valoare);
                        }

                        // adauga seria de date la grafic
                        chart.Series.Add(series);
                    }
                }
            }

            chart.AxisX.Add(new Axis { Title = "ID Vanzare" });
            chart.AxisY.Add(new Axis { Title = "Valoare" });

            ElementHost elementHost = new ElementHost
            {
                Dock = DockStyle.Fill,
                Child = chart
            };

            Controls.Add(elementHost);

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void elementHost1_ChildChanged(object sender, ChildChangedEventArgs e)
        {

        }

        private void Grafic_Load(object sender, EventArgs e)
        {

        }
    }
}
