using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_tac_toe_csharp
{
    public partial class Form1 : Form
    {
        //our engine of the game
        GF engine;
        //our grid board for the game
        Board board;

 

        private int scoreOne=0;
        private int scoreTwo=0;
        public Form1()
        {
            InitializeComponent();

            //put the game date into history file
            this.writeHistory($"Game Date is : {DateTime.Now.ToString()}");
        }
        
        private void writeHistory(string line)
        {
    
            var path = @"C:\Users\Ripper\source\repos\Tic_tac_toe_csharp\History.txt";

            var sw = new StreamWriter(path, true);

            sw.WriteLine(line);

            sw.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphic = bunifuGradientPanel1.CreateGraphics();
            this.engine = new GF(graphic);

            board = new Board();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuGradientPanel1_Click(object sender, EventArgs e)
        {
            Point mouse = Cursor.Position;
            mouse = this.bunifuGradientPanel1.PointToClient(mouse);
            this.board.getClick(ref this.engine, mouse);
            

            //check if game over
            int iswin = this.board.isWin();

            if (iswin == 1)
            {
                MessageBox.Show("Tom Win");
                this.writeHistory("Winner is : Tom");
                this.scoreOne += 1;
                this.PlayerOneScore.Text = this.scoreOne.ToString();
                this.board.restart();
                this.engine.createBoxs();
            }
            else if (iswin == 2)
            {
                MessageBox.Show("Jerry Win");
                this.writeHistory("Winner is : Jerry");
                this.scoreTwo += 1;
                this.PlayerOneScore.Text = this.scoreTwo.ToString();
                this.board.restart();
                this.engine.createBoxs();

            }
            else if(iswin == 0)
            {
                MessageBox.Show("Draw Game");
                this.writeHistory("Draw Game");
                this.board.restart();
                this.engine.createBoxs();
            }

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            this.board.restart();
            this.engine.createBoxs();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            History history = new History();
            history.Show();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

     
        
    }
}
