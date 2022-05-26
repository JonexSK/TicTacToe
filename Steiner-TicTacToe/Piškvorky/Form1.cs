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
    public partial class tictactoe : Form
    {
        bool turn = true; //true = X turn, false = Y turn
        int turn_count = 0;
        static String player1, player2;

        public tictactoe()
        {
            InitializeComponent();
        }

        public static void setPlayerNames(String n1, String n2)
        {
            player1 = n1;
            player2 = n2;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Made by Samuel Šteiner");
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
            {
                b.Text = "X";
            }
            else
            {
                b.Text = "O";
            }


            turn = !turn;
            b.Enabled = false;

            checkForWinner();

        }

        private void checkForWinner()
        {
            bool there_is_the_winner = false;

            //HORIZONTAL CHECKS

            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
            {
                there_is_the_winner = true;
            }

            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
            {
                there_is_the_winner = true;
            }

            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
            {
                there_is_the_winner = true;                
            }

            //VERTICAL CHECKS

            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
            {
                there_is_the_winner = true;
            }

            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
            {
                there_is_the_winner = true;
            }

            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
            {
                there_is_the_winner = true;
            }

            //DIAGONAL CHECKS

            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
            {
                there_is_the_winner = true;
            }

            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!C1.Enabled))
            {
                there_is_the_winner = true;
            }

            if (there_is_the_winner)
            {
                disableButtons();

                String winner = "";
                if (turn)
                {
                    winner = player2;
                    o_win_count.Text = (Int32.Parse(o_win_count.Text) + 1).ToString();
                }

                else
                {
                    winner = player1;
                    x_win_count.Text = (Int32.Parse(x_win_count.Text) + 1).ToString();
                }
                MessageBox.Show("Winner: " + winner);
              
                turn = true;
                turn_count = 0;


                foreach (Component c in Controls)
                {
                    try
                    {
                        Button b = (Button)c;
                        b.Enabled = true;
                        b.Text = "";
                    }
                    catch { }
                }              
            }

            else
            {
                if (turn_count == 9)
                {
                    there_is_the_winner = false;
                    draw_count.Text = (Int32.Parse(draw_count.Text) + 1).ToString();
                    MessageBox.Show("Tie!");
                }
            }
        }

        private void disableButtons()
        {
            try
            {
                foreach (Component c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }
            catch {}
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turn_count = 0;
            

            foreach (Component c in Controls)
            {
                try
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
                catch { }
            }
          
        }
        private void button_enter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if(turn)
            {
                b.Text = "X";
            }
            else
            {

                b.Text = "O";
            }
        }

        private void button_leave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if(b.Enabled)
            {
                b.Text = "";
            }
        }

        private void resetWinCountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            x_win_count.Text = "0";
            o_win_count.Text = "0";
            draw_count.Text = "0";
        }

        private void tictactoe_Load(object sender, EventArgs e)
        {
            f2 f2 = new f2();
            f2.ShowDialog();            
            label1.Text = player1;
            label3.Text = player2;
        }
    }
}
