using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

// Author: Miguel Torres Perez
// CST-150  
// Professor Smithers


namespace CST_150_Activity13
{
    public class Class2 
    {
        public int movesMade = 0;
        public int Owins = 0;
        public int Xwins = 0;
        public Holder[,] holders = new Holder[3,3];
        public const int X = 0;
        public const int O = 1;
        public const int B = 2;
        public int playersTurn = X;
        public int getPlayerForTurn()
        {
            return playersTurn;
        }   
        public int getOWins()
        {
            return Owins;
        }
        public int getXWins()
        {
            return Xwins;
        }
        public void initializeBoard()
        {
            for(int x = 0; x < 3; x++)
            {
                for(int y = 0; y < 3; y++)
                {                    
                    holders[x, y] = new Holder();
                    holders[x, y].setValue(B);
                    holders[x, y].setLocation(new Point(x, y));
                }
            }
        }
        public void detectHit(Point location)
        {
            if (location.Y <= 500)
            {
                int x = 0;
                int y = 0;
                if (location.X < 167)
                {
                    x = 0;
                }
                else if (location.X > 167 && location.X < 334)
                {
                    x = 1;
                }
                else if (location.X > 334)
                {
                    x = 2;
                }
                if (location.Y < 167)
                {
                    y = 0;
                }
                else if (location.Y > 167 && location.Y < 334)
                {
                    y = 1;
                }
                else if (location.Y > 334 && location.Y < 500)
                {
                    y = 2;
                }                
                if(movesMade % 2 == 0)
                {
                    Class1.DrawX(new Point(x, y));
                    holders[x, y].setValue(X);
                    if (detectRow())
                    {
                        MessageBox.Show("You have won, X");
                        Xwins++;
                        reset();
                        Class1.setUpCanvas();
                    }
                    playersTurn = O;
                }
                else
                {
                    Class1.drawO(new Point(x, y));
                    holders[x, y].setValue(O);
                    if (detectRow())
                    {
                        MessageBox.Show("You have won, O");
                        Owins++;
                        reset();
                        Class1.setUpCanvas();
                    }
                    playersTurn = X;
                }
                movesMade++;
            }
        }
        public bool detectRow()
        {
            bool isWon = false;
            for(int x = 0; x < 3; x++)
            {
                if (holders[x, 0].getValue() == X && holders[x, 1].getValue() == X && holders[x,2].getValue() == X)
                {
                    return true;
                }
                if (holders[x, 0].getValue() == O && holders[x, 1].getValue() == O && holders[x, 2].getValue() == O)
                {
                    return true;
                }
                switch (x)
                {
                    case 0:
                        if (holders[x,0].getValue() == X && holders[x+1,1].getValue() == X && holders[x+2,2].getValue()==X) 
                        {
                            return true;
                        }
                        if (holders[x, 0].getValue() == O && holders[x + 1, 1].getValue() == O && holders[x + 2, 2].getValue() == O)
                        {
                            return true;
                        }
                        break;
                    case 2:
                        if(holders[x,0].getValue() == X && holders[x-1,1].getValue() == X && holders[x-2,2].getValue() == X)
                        {
                            return true;
                        }
                        if (holders[x, 0].getValue() == O && holders[x - 1, 1].getValue() == O && holders[x - 2, 2].getValue() == O)
                        {
                            return true;
                        }
                        break;
                }
            }
            for(int y = 0; y < 3; y++)
            {
                if (holders[0,y].getValue() == X && holders[1,y].getValue() == X && holders[2,y].getValue() == X)
                {
                    return true;
                }
                if (holders[0,y].getValue() == O && holders[1,y].getValue() == O && holders[2,y].getValue() == O)
                {
                    return true;
                }
            }
            return isWon;
        }
        public void reset()
        {
            holders = new Holder[3, 3];
            initializeBoard();
        }
    }
    public class Holder
    {
        public Point location;
        public int value = Class2.B;
        public void setLocation(Point p)
        {
            location = p;
        }
        public Point getLocation()
        {
            return location;
        }
        public void setValue(int i)
        {
            value = i;
        }
        public int getValue()
        {
            return value;
        }
    }
}
