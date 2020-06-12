using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Tic_tac_toe_csharp
{
    class Board
    {
        //to know holders of each square
        private Holder[,] holders = new Holder[3, 3];

        //this counter is for counting how many squares  played
        //and to check how its turn it is, which player must play now
        private int counter = 0;

        public Board()
        {
            //create Squares of the grid
            this.createSquares();
        }
        private void createSquares()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int x = 0; x < 3; x++)
                {
                    //initialize holders
                    holders[i, x] = new Holder();
                    holders[i, x].setLocation(new Point(i, x));
                }
            }
        }

        public void getClick(ref GF engine, Point point)
        {
            //check if the user clicked on our grid 
            //if he clicked on the board then lets check in which squere he played
            if (point.X <= 500)
            {
                int x = 0;
                int y = 0;

                //O 1 2 (grid board columns) x=0 mean user clicked on [0,something]
                //< 167  index 0
                if (point.X < 167)
                    x = 0;
                //index 1
                else if (point.X > 167 && point.X < 334)
                    x = 1;
                //index 2
                else if (point.X > 334)
                    x = 2;

                if (point.Y < 167)
                    y = 0;
                else if (point.Y > 167 && point.Y < 334)
                    y = 1;
                else if (point.Y > 334 && point.Y < 500)
                    y = 2;


                //now put the picture of the player in the board
                //if player 2 who played 
                if(this.counter % 2 == 0)
                {
                    if (this.holders[x, y].getState() == 0)
                    {
                        engine.jerry(new Point(x * 167, y * 167));
                        //holder of [x,y] is player2
                        this.holders[x, y].setState(2);

                        //Put which square played by jerry to our history file
                        this.savePlayerHistory("Jerry", x, y);
                        this.counter += 1;

                    }

                }
                else //if player 1 who played
                {
                    if (this.holders[x, y].getState() == 0)
                    {
                        engine.tom(new Point(x * 167, y * 167));
                        //holder of [x,y] is player 1
                        this.holders[x, y].setState(1);
                        //Put which square played by jerry to our history file
                        this.savePlayerHistory("Tom", x, y);
                        this.counter += 1;

                    }
                }
            }
            else
                //if user clicked out of the board we show a error message
                MessageBox.Show("Please click on the board game!!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void savePlayerHistory(string player, int x, int y)
        {
            var path = @"C:\Users\Ripper\source\repos\Tic_tac_toe_csharp\History.txt";

            var sw = new StreamWriter(path, true);

            sw.WriteLine($"{player} Played: [{x},{y}]");

            sw.Close();
        }

        //detect if someone win
        public int isWin()
        {
            //Player 1
            if (
                (this.holders[0, 0].getState() == 1) &&
                (this.holders[1, 0].getState() == 1) &&
                (this.holders[2, 0].getState() == 1)
                )
                return 1;

            if (
                (this.holders[0, 1].getState() == 1) &&
                (this.holders[1, 1].getState() == 1) &&
                (this.holders[2, 1].getState() == 1)
                )
                return 1;

            if (
                (this.holders[0, 2].getState() == 1) &&
                (this.holders[1, 2].getState() == 1) &&
                (this.holders[2, 2].getState() == 1)
                )
                return 1;

            if (
                  (this.holders[0, 0].getState() == 1) &&
                  (this.holders[0, 1].getState() == 1) &&
                  (this.holders[0, 2].getState() == 1)
                 )
                return 1;

            if (
                (this.holders[1, 0].getState() == 1) &&
                (this.holders[1, 1].getState() == 1) &&
                (this.holders[1, 2].getState() == 1)
                )
                return 1;

            if (
                (this.holders[2, 0].getState() == 1) &&
                (this.holders[2, 1].getState() == 1) &&
                (this.holders[2, 2].getState() == 1)
                )
                return 1;


            // player 2

            if (
                (this.holders[0, 0].getState() == 2) &&
                (this.holders[1, 0].getState() == 2) &&
                (this.holders[2, 0].getState() == 2)
                )
                return 2;

            if (
                (this.holders[0, 1].getState() == 2) &&
                (this.holders[1, 1].getState() == 2) &&
                (this.holders[2, 1].getState() == 2)
                )
                return 2;

            if (
                (this.holders[0, 2].getState() == 2) &&
                (this.holders[1, 2].getState() == 2) &&
                (this.holders[2, 2].getState() == 2)
                )
                return 2;

            if (
                (this.holders[0, 0].getState() == 2) &&
                (this.holders[0, 1].getState() == 2) &&
                (this.holders[0, 2].getState() == 2)
                )
                return 2;

            if (
                (this.holders[1, 0].getState() == 2) &&
                (this.holders[1, 1].getState() == 2) &&
                (this.holders[1, 2].getState() == 2)
                )
                return 2;

            if (
                (this.holders[2, 0].getState() == 2) &&
                (this.holders[2, 1].getState() == 2) &&
                (this.holders[2, 2].getState() == 2)
                )
                return 2;

            // player 1
            if (
                (this.holders[0, 0].getState() == 1) &&
                (this.holders[1, 1].getState() == 1) &&
                (this.holders[2, 2].getState() == 1)
                )
                return 1;

            // player 1
            if (
                (this.holders[0, 2].getState() == 1) &&
                (this.holders[1, 1].getState() == 1) &&
                (this.holders[2, 0].getState() == 1)
                )
                return 1;


            // player 2
            if (
                (this.holders[0, 2].getState() == 2) &&
                (this.holders[1, 1].getState() == 2) &&
                (this.holders[2, 0].getState() == 2)
                )
                return 2;

            // player 2
            if (
                (this.holders[0, 0].getState() == 2) &&
                (this.holders[1, 1].getState() == 2) &&
                (this.holders[2, 2].getState() == 2)
                )
                return 2;

            //check draw
            if (
                (this.holders[0, 0].getState() == 2 || this.holders[0, 0].getState() == 1) &&
                (this.holders[0, 1].getState() == 2 || this.holders[0, 1].getState() == 1) &&
                (this.holders[0, 2].getState() == 2 || this.holders[0, 2].getState() == 1) &&
                (this.holders[1, 0].getState() == 2 || this.holders[1, 0].getState() == 1) &&
                (this.holders[1, 1].getState() == 2 || this.holders[1, 1].getState() == 1) &&
                (this.holders[1, 2].getState() == 2 || this.holders[1, 2].getState() == 1) &&
                (this.holders[2, 0].getState() == 2 || this.holders[2, 0].getState() == 1) &&
                (this.holders[2, 1].getState() == 2 || this.holders[2, 1].getState() == 1) &&
                (this.holders[2, 2].getState() == 2 || this.holders[2, 2].getState() == 1)
                )
                return 0;

            return 6;
        }

        //restart game by re instanciate holders object & re create squares
        public void restart()
        {
            this.holders = new Holder[3, 3];
            this.createSquares();
        }

        //Player turn
        public string playerTurn()
        {
            return this.counter % 2 == 0 ? "Now Its Player One Turn" : "Now Its Player Two Turn";
        }

    }
}
