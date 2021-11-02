using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Author: Miguel Torres Perez
// CST-150
// Professor Smithers

namespace CST_150_Activity13
{
    public partial class ticTacToe : Form
    {
        public Class1 engine;
        public Class2 theBoard;

        public ticTacToe()
        {
            InitializeComponent();
        } 

        public void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics toPass = panel1.CreateGraphics();
            engine = new Class1(toPass);
            theBoard = new Class2();
            theBoard.initializeBoard();
            refreshLabel();
        }

        public void panel1_Click(object sender, EventArgs e)
        {
            Point mouse = Cursor.Position;
            mouse = panel1.PointToClient(mouse);
            theBoard.detectHit(mouse);
            refreshLabel();
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            theBoard.reset();
            Class1.setUpCanvas();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        public void refreshLabel()
        {
            String newText = "It is ";
            if(theBoard.getPlayerForTurn() == Class2.X)
            {
                newText += "X";
            }
            else
            {
                newText += "O";
            }
            newText += "'s Turn \n";
            newText += "X has won " + theBoard.getXWins()
                + " times. \n O has won "
                + theBoard.getOWins();
            label1.Text = newText;
        }
    }
}
