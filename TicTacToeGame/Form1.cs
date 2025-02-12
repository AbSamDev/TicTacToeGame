using System;
using System.Windows.Forms;

namespace TicTacToeGame
{
    public partial class Form1 : Form
    {
        int moveCount = 0; // Tracks moves for draw detection

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            moveCount++;

            // Assign X or O based on turn
            b.Text = (moveCount % 2 != 0) ? "X" : "O";
            b.Enabled = false; // Disable button after selection

            // Check victory
            if (CheckWinner())
            {
                string winner = (moveCount % 2 != 0) ? "X" : "O";
                MessageBox.Show($"{winner} Wins!", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RestartGame();
                return;
            }

            // Checking for a draw
            if (moveCount == 9)
            {
                MessageBox.Show("It's a Draw!", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RestartGame();
            }
        }

        private bool CheckWinner()
        {
            return (b1.Text != "" && b1.Text == b2.Text && b2.Text == b3.Text) ||
                   (b4.Text != "" && b4.Text == b5.Text && b5.Text == b6.Text) ||
                   (b7.Text != "" && b7.Text == b8.Text && b8.Text == b9.Text) ||
                   (b1.Text != "" && b1.Text == b4.Text && b4.Text == b7.Text) ||
                   (b2.Text != "" && b2.Text == b5.Text && b5.Text == b8.Text) ||
                   (b3.Text != "" && b3.Text == b6.Text && b6.Text == b9.Text) ||
                   (b1.Text != "" && b1.Text == b5.Text && b5.Text == b9.Text) ||
                   (b3.Text != "" && b3.Text == b5.Text && b5.Text == b7.Text);
        }

        private void RestartGame()
        {
            // Resetting all buttons
            b1.Text = b2.Text = b3.Text = b4.Text = b5.Text = b6.Text = b7.Text = b8.Text = b9.Text = "";
            b1.Enabled = b2.Enabled = b3.Enabled = b4.Enabled = b5.Enabled = b6.Enabled = b7.Enabled = b8.Enabled = b9.Enabled = true;

            moveCount = 0;
        }
    }
}
