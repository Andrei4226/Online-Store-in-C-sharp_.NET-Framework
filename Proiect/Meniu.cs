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
    public partial class Meniu : Form
    {
        public static Meniu instance;
        public Meniu()
        {
            InitializeComponent();
            instance = this;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
        }

        private void btnApplication_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlExtension.Draggable(pictureBox2, true);
            ControlExtension.Draggable(pictureBox1, true);
        }
    }
}
