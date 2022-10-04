using Snake_and_Ladder_Game_.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace Snake_and_Ladder_Game_
{
    public partial class Form1 : Form
    {
        //player_how_rolls_dice if this variable have true this means that player 1 rolls
        //else player 2 who have to rolls
        bool player_how_rolls_dice;
        //dice varible contains random from 1 to 6 at any roll
        int dice;
        int player_1_position, player_2_position;
        bool player_1_right, player_2_right;
        public Form1()
        {
            InitializeComponent();
        }
        
        private void startingValues()
        {
            //assign srarting location to player 1 and player 2
            pictureBox4.Location = new Point(0, 517);
            pictureBox5.Location = new Point(44, 517);
            //hide players one and to untill dice = 6 appers to start any of them 
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            //filling pictureboxes with images 
            pictureBox3.Image = Resources.ROLL_THE_DICE;
            //asigning StretchImage property to pictureboxes to show it beter than it's posible
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            //player_how_rolls_dice = true this this means that player 1 rolls dice
            player_how_rolls_dice = true;

            player_1_position = -1;
            player_2_position = -1;

            player_1_right = true;
            player_2_right = true;

            button1.Visible = false;
        }
        private void Form1_Load_1(object sender, EventArgs e)
        {
            startingValues();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (player_how_rolls_dice)
            {
                dice = Game.rollDice(pictureBox3);
                if (player_1_position == -1)
                {
                    if (dice == 6)
                    {
                        player_1_position = 1;
                        pictureBox4.Visible = true;
                    }
                }
                else
                {
                    if (Game.checkEnd(player_1_position, dice))
                    {
                        Game.changeCurentPosition(dice, ref player_1_position, pictureBox4, ref player_1_right);
                        Game.ladder(ref player_1_position, pictureBox4, ref player_1_right, player_how_rolls_dice);
                        Game.snake(ref player_1_position, pictureBox4, ref player_1_right, player_how_rolls_dice);
                        if (Game.winer(player_1_position))
                        {
                            MessageBox.Show("Congratulation Player 1");
                            startingValues();
                            //end game********************
                        }
                    }
                }
                player_how_rolls_dice = false;
                button1.Visible = true;
                button2.Visible = false;
            }
            else
            {
                dice = Game.rollDice(pictureBox3);
                if (player_2_position == -1)
                {
                    if (dice == 6)
                    {
                        player_2_position = 1;
                        pictureBox5.Visible = true;
                    }

                }
                else
                {
                    if (Game.checkEnd(player_2_position, dice))
                    {
                        Game.changeCurentPosition(dice, ref player_2_position, pictureBox5, ref player_2_right);
                        Game.ladder(ref player_2_position, pictureBox5, ref player_2_right, player_how_rolls_dice);
                        Game.snake(ref player_2_position, pictureBox5, ref player_2_right, player_how_rolls_dice);
                        if (Game.winer(player_2_position))
                        {
                            MessageBox.Show("Congratulation Player 2");
                            startingValues();
                            //end game********************
                        }
                    }

                }
                player_how_rolls_dice = true;
                button1.Visible = false;
                button2.Visible = true;
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
