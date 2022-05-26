using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Piškvorky
{
    public partial class f2 : Form
    {
        public f2()
        {
            InitializeComponent();
        }

        private void play_Click(object sender, EventArgs e)
        {
            tictactoe.setPlayerNames(p1.Text, p2.Text);

            this.Close();
        }
    }
}
