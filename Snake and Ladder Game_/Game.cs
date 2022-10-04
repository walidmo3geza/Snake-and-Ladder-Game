using Snake_and_Ladder_Game_.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal class Game
    {
        public static int rollDice(PictureBox pictureBox)
        {
            Stream s2 = Resources.RATTLE2;
            SoundPlayer su2 = new SoundPlayer(s2);
            su2.Play();
            Random random = new Random();
            int dice = random.Next(1, 7);
            pictureBox.Image = (Image)Resources.ResourceManager.GetObject("_" + dice.ToString());
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            Thread.Sleep(500);
            return dice;
        }
        public static void changeCurentPosition(int dice, ref int player_curent_position, PictureBox pictureBox, ref bool right)
        {
            Stream s2 = Resources.move__2_;
            SoundPlayer su2 = new SoundPlayer(s2);
            su2.Play();
            if (player_curent_position == 1)
            {
                dice--;
            }
            while (dice > 0)
            {
                if (right)
                {
                    if (player_curent_position % 10 == 0)
                    {
                        pictureBox.Location = new Point(pictureBox.Location.X, pictureBox.Location.Y - 57);
                        right = false;
                    }
                    else
                    {
                        pictureBox.Location = new Point(pictureBox.Location.X + 78, pictureBox.Location.Y);
                    }
                }
                else
                {
                    if (player_curent_position % 10 == 0)
                    {
                        pictureBox.Location = new Point(pictureBox.Location.X, pictureBox.Location.Y - 57);
                        right = true;
                    }
                    else
                    {
                        pictureBox.Location = new Point(pictureBox.Location.X - 78, pictureBox.Location.Y);
                    }
                }
                player_curent_position++;
                dice--;
                Thread.Sleep(100);
            }

        }

        public static void ladder(ref int player_curent_position, PictureBox pictureBox, ref bool right, bool player)
        {
            //1 4 9 21 28 51 72 80
            
            bool change = false;
            switch (player_curent_position)
            {
                case 1:
                    pictureBox.Location = new Point(156, 346);
                    right = false;
                    change = true;
                    player_curent_position = 38;
                    break;
                case 4:
                    pictureBox.Location = new Point(468, 460);
                    right = false;
                    change = true;
                    player_curent_position = 14;
                    break;
                case 9:
                    pictureBox.Location = new Point(702, 346);
                    right = false;
                    change = true;
                    player_curent_position = 31;
                    break;
                case 21:
                    pictureBox.Location = new Point(78, 289);
                    right = true;
                    change = true;
                    player_curent_position = 42;
                    break;
                case 28:
                    pictureBox.Location = new Point(234, 57);
                    right = true;
                    change = true;
                    player_curent_position = 84;
                    break;
                case 51:
                    pictureBox.Location = new Point(468, 171);
                    right = true;
                    change = true;
                    player_curent_position = 67;
                    break;
                case 72:
                    pictureBox.Location = new Point(702, 0);
                    right = false;
                    change = true;
                    player_curent_position = 91;
                    break;
                case 80:
                    pictureBox.Location = new Point(78, 0);
                    right = false;
                    change = true;
                    player_curent_position = 99;
                    break;
            }
            if (!player && change)
            {
                pictureBox.Location = new Point(pictureBox.Location.X + 44, pictureBox.Location.Y);
            }
        }
        public static void snake(ref int player_curent_position, PictureBox pictureBox, ref bool right, bool player)
        {
            bool change = false;
            switch (player_curent_position)
            {
                case 17:
                    pictureBox.Location = new Point(468, 517);
                    right = true;
                    change = true;
                    player_curent_position = 7;
                    break;
                case 54:
                    pictureBox.Location = new Point(468, 342);
                    right = false;
                    change = true;
                    player_curent_position = 34;
                    break;
                case 62:
                    pictureBox.Location = new Point(78, 460);
                    right = false;
                    change = true;
                    player_curent_position = 19;
                    break;
                case 64:
                    pictureBox.Location = new Point(0, 232);
                    right = false;
                    change = true;
                    player_curent_position = 60;
                    break;
                case 87:
                    pictureBox.Location = new Point(312, 346);
                    right = false;
                    change = true;
                    player_curent_position = 36;
                    break;
                case 93:
                    pictureBox.Location = new Point(546, 114);
                    right = false;
                    change = true;
                    player_curent_position = 73;
                    break;
                case 95:
                    pictureBox.Location = new Point(390, 114);
                    right = false;
                    change = true;
                    player_curent_position = 75;
                    break;
                case 98:
                    pictureBox.Location = new Point(78, 114);
                    right = false;
                    change = true;
                    player_curent_position = 79;
                    break;
            }
            if (!player && change)
            {
                pictureBox.Location = new Point(pictureBox.Location.X + 44, pictureBox.Location.Y);
            }
        }
        public static bool checkEnd(int curent_position, int dice)
        {
            return curent_position + dice <= 100;
        }
        public static bool winer(int curent_position)
        {
            return curent_position == 100;
        }
    }
}
