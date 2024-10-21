using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Text.RegularExpressions;
using Game_Pikachu.PlayViewProcess;
using PointNew = Game_Pikachu.PlayViewProcess.PointNew;

namespace Game_Pikachu
{
    public class DrawPanelContainIcon
    {
        #region property
        private Panel panel = new Panel();
        public PictureBox[,] matrixIcon = new PictureBox[100, 100];
        public PictureBox[] arrayIcon = new PictureBox[100];
        public int[,] numberMatrixIcon = new int[100, 100];
        public int numberIcon;
        public int[] numberIconArray = new int[100];
        public int[] idIconArray = new int[100];
        public static int checkFlag = 1;
        public static PointNew p1 = new PointNew();
        public static PointNew p2= new PointNew();
        public static string[] position = new string[2];
        #endregion

        #region Random số lượng Icon và số lần xuất hiện mỗi Icon
        // set Random numberIcon
        // Set Random number each Icon, save as array numberIconArray[]
        public void RandomNumberIconArray()
        {
            int sum = 0;
            int tg, i;
            Random rnd = new Random();
            this.numberIcon = rnd.Next(18, 22);
            for (i=0; i<numberIcon; i++)
            {
                tg=rnd.Next(10, 15);
                sum += tg;
                if (sum<252)
                {
                    if (tg % 2 == 1)
                    {
                        tg -= 1;
                        sum -= 1;
                        numberIconArray[i] = tg;
                    }
                    numberIconArray[i] = tg;
                }
                else
                {
                    sum = sum - tg;
                    numberIconArray[i] = 252 - sum;
                    numberIcon = i + 1;
                    break;
                }
            }
        }
        #endregion

        #region Sau khi đã random số lượng Icon, thì random mã Icon cho các Icon đó
        public void RandomIdIcon()
        {
            int i, random;
            RandomNumberIconArray();
            Random rnd = new Random();
            PictureBox[] arrayIconTg = new PictureBox[100];
            for (i = 0; i < 40; i++) arrayIconTg[i] = new PictureBox();
            #region Initial
            
            arrayIconTg[0].BackgroundImage = global::Game_Pikachu.Properties.Resources._31;
            arrayIconTg[1].BackgroundImage = global::Game_Pikachu.Properties.Resources._1;
            arrayIconTg[2].BackgroundImage = global::Game_Pikachu.Properties.Resources._2;
            arrayIconTg[3].BackgroundImage = global::Game_Pikachu.Properties.Resources._3;
            arrayIconTg[4].BackgroundImage = global::Game_Pikachu.Properties.Resources._4;
            arrayIconTg[5].BackgroundImage = global::Game_Pikachu.Properties.Resources._5;
            arrayIconTg[6].BackgroundImage = global::Game_Pikachu.Properties.Resources._6;
            arrayIconTg[7].BackgroundImage = global::Game_Pikachu.Properties.Resources._7;
            arrayIconTg[8].BackgroundImage = global::Game_Pikachu.Properties.Resources._8;
            arrayIconTg[9].BackgroundImage = global::Game_Pikachu.Properties.Resources._9;
            arrayIconTg[10].BackgroundImage = global::Game_Pikachu.Properties.Resources._10;
            arrayIconTg[11].BackgroundImage = global::Game_Pikachu.Properties.Resources._11;
            arrayIconTg[12].BackgroundImage = global::Game_Pikachu.Properties.Resources._12;
            arrayIconTg[13].BackgroundImage = global::Game_Pikachu.Properties.Resources._13;
            arrayIconTg[14].BackgroundImage = global::Game_Pikachu.Properties.Resources._14;
            arrayIconTg[15].BackgroundImage = global::Game_Pikachu.Properties.Resources._15;
            arrayIconTg[16].BackgroundImage = global::Game_Pikachu.Properties.Resources._16;
            arrayIconTg[17].BackgroundImage = global::Game_Pikachu.Properties.Resources._17;
            arrayIconTg[18].BackgroundImage = global::Game_Pikachu.Properties.Resources._18;
            arrayIconTg[19].BackgroundImage = global::Game_Pikachu.Properties.Resources._19;
            arrayIconTg[20].BackgroundImage = global::Game_Pikachu.Properties.Resources._20;
            arrayIconTg[21].BackgroundImage = global::Game_Pikachu.Properties.Resources._21;
            arrayIconTg[22].BackgroundImage = global::Game_Pikachu.Properties.Resources._22;
            arrayIconTg[23].BackgroundImage = global::Game_Pikachu.Properties.Resources._23;
            arrayIconTg[24].BackgroundImage = global::Game_Pikachu.Properties.Resources._24;
            arrayIconTg[25].BackgroundImage = global::Game_Pikachu.Properties.Resources._25;
            arrayIconTg[26].BackgroundImage = global::Game_Pikachu.Properties.Resources._26;

            #endregion

            for (i = 0; i < numberIcon; i++)
            {
                random = rnd.Next(0, 27);
                arrayIcon[i] = new PictureBox();
                arrayIcon[i].BackgroundImage = arrayIconTg[random].BackgroundImage;
                idIconArray[i] = random;
            }
        }
        #endregion

        #region Lưu vào ma trận Icon và mã trận Mã Icon
        public void ProcessRandomIcon(Panel panel)
        {       
            RandomIdIcon();
            this.panel = panel;
            int i, j, k, tg;
            int[] count = new int[100];
            for (i = 0; i < numberIcon; i++) count[i] = 0;
            Random rnd = new Random();
            for (i=0; i<12; i++)
            {
                for (j=0; j<21; j++)
                {
                    PictureBox icon = new PictureBox();
                    icon.Size = new Size(30, 30);
                    icon.Location = new Point(j * 30, i * 30);
                    icon.BackColor = Color.Transparent;
                    icon.BackgroundImageLayout = ImageLayout.Stretch;
                    matrixIcon[i, j] = icon;
                    matrixIcon[i, j].Click += PictureBox_Click;

                    tg = rnd.Next(0, numberIcon);
                    if (count[tg]<=numberIconArray[tg])
                    {
                        matrixIcon[i, j].BackgroundImage = arrayIcon[tg].BackgroundImage;
                        matrixIcon[i, j].Name = (i + 1).ToString() + ' ' + (j + 1).ToString();
                        numberMatrixIcon[i, j] = idIconArray[tg];
                        panel.Controls.Add(matrixIcon[i, j]);
                    }
                    else
                    {
                        for (k = tg; k < numberIcon-1; k++) arrayIcon[k] = arrayIcon[k + 1];
                        numberIcon--;
                    }
                }
            }
            // Bọc xung quanh bởi số 0
            Add0();
        }
        #endregion

        #region Thêm vòng số 0
        void Add0()
        {
            int i, j;
            // Đẩy lên 1 hàng
            for (i=12; i>=1; i--)
            {
                for (j = 0; j < 21; j++) numberMatrixIcon[i, j] = numberMatrixIcon[i - 1, j];
            }

            // Đẩy sang phải 1 cột
            for (j=21; j>=1; j--)
            {
                for (i = 1; i < 13; i++) numberMatrixIcon[i, j] = numberMatrixIcon[i, j - 1];
            }

            for (i = 0; i < 13; i++)
            {
                numberMatrixIcon[i, 0] = 0;
                numberMatrixIcon[i, 12] = 0;
            }
            for (j = 0; j < 22; j++)
            {
                numberMatrixIcon[0, j] = 0;
                numberMatrixIcon[13, j] = 0;
            }
        }
        #endregion

        #region Tạo sự kiện click của mỗi Icon
        void PictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            ProcessPlay processPlay = new ProcessPlay();
            if (checkFlag == 1)
            {
                pictureBox.Size = new Size(35, 35);
                pictureBox.BorderStyle = BorderStyle.Fixed3D;
                position = pictureBox.Name.Split(' ');
                p1.x = Convert.ToInt16(position[0]);
                p1.y = Convert.ToInt16(position[1]);
              /*  MessageBox.Show(position[0] + ' ' + position[1]);
                MessageBox.Show(numberMatrixIcon[p1.x, p1.y].ToString());*/
                checkFlag = 2;
            }
            else if (checkFlag == 2)
            {
                //MessageBox.Show(numberMatrixIcon[0, 13].ToString());
                position = pictureBox.Name.Split(' ');
                p2.x = Convert.ToInt16(position[0]);
                p2.y = Convert.ToInt16(position[1]);

                checkFlag = 1;
                if (p1.x == p2.x && p1.y == p2.y)
                {
                    pictureBox.Size = new Size(30, 30);
                    pictureBox.BorderStyle = BorderStyle.None;
                }
                else
                {
                    // Xử lý trường hợp 2 Icon ăn nhau theo hàng ngang
                    if (processPlay.FindRow(numberMatrixIcon, p1, p2) == 1) 
                    {
                        panel.Controls.Remove(matrixIcon[p1.x - 1, p1.y - 1]);
                        panel.Controls.Remove(matrixIcon[p2.x - 1, p2.y - 1]);
                        numberMatrixIcon[p1.x, p1.y] = 0;
                        numberMatrixIcon[p2.x, p2.y] = 0;
                       /* MessageBox.Show(position[0] + ' ' + position[1]);
                        MessageBox.Show(numberMatrixIcon[p2.x, p2.y].ToString());*/
                        
                    }

                    // Xử lý trường hợp 2 Icon ăn nhau theo hàng dọc
                    else if (processPlay.FindColumn(numberMatrixIcon, p1, p2) == 1)
                    {
                        panel.Controls.Remove(matrixIcon[p1.x - 1, p1.y - 1]);
                        panel.Controls.Remove(matrixIcon[p2.x - 1, p2.y - 1]);
                        numberMatrixIcon[p1.x, p1.y] = 0;
                        numberMatrixIcon[p2.x, p2.y] = 0;
                       /* MessageBox.Show(position[0] + ' ' + position[1]);
                        MessageBox.Show(numberMatrixIcon[p2.x, p2.y].ToString());*/

                    }

                    // Xử lý đường gấp khúc từ trái qua phải
                    else if (processPlay.ZigZugLeftToRight(numberMatrixIcon, p1, p2) == 1)
                    {
                        panel.Controls.Remove(matrixIcon[p1.x - 1, p1.y - 1]);
                        panel.Controls.Remove(matrixIcon[p2.x - 1, p2.y - 1]);
                        numberMatrixIcon[p1.x, p1.y] = 0;
                        numberMatrixIcon[p2.x, p2.y] = 0;
                       /* MessageBox.Show(position[0] + ' ' + position[1]);
                        MessageBox.Show(numberMatrixIcon[p2.x, p2.y].ToString());*/

                        //MessageBox.Show(numberMatrixIcon[p1.x, p1.y].ToString());
                        //MessageBox.Show(numberMatrixIcon[p1.x, p1.y].ToString());
                    }

                    // Xử lý gấp khúc từ trên xuống dưới
                    else if (processPlay.ZigZugUpToDown(numberMatrixIcon, p1, p2) == 1)
                    {
                        panel.Controls.Remove(matrixIcon[p1.x - 1, p1.y - 1]);
                        panel.Controls.Remove(matrixIcon[p2.x - 1, p2.y - 1]);
                        numberMatrixIcon[p1.x, p1.y] = 0;
                        numberMatrixIcon[p2.x, p2.y] = 0;
                      /*  MessageBox.Show(position[0] + ' ' + position[1]);
                        MessageBox.Show(numberMatrixIcon[p2.x, p2.y].ToString());*/

                        //MessageBox.Show(numberMatrixIcon[p1.x, p1.y].ToString());
                        //MessageBox.Show(numberMatrixIcon[p1.x, p1.y].ToString());
                    }


                    // Trường hợp 2 Icon không ăn được nhau
                    else
                    {
                      /*  MessageBox.Show(position[0] + ' ' + position[1]);
                        MessageBox.Show(numberMatrixIcon[p2.x, p2.y].ToString());*/

                        // Tạo một Icon tg bằng với Icon p1, vì sự kiện của p1 lúc này không xử lý được nữa
                        PictureBox pictureBoxTg = new PictureBox();
                        pictureBoxTg = matrixIcon[p1.x - 1, p1.y - 1];
                        pictureBoxTg.Size = new Size(30, 30);
                        pictureBoxTg.BorderStyle = BorderStyle.None;

                        // Xóa p1
                        panel.Controls.Remove(matrixIcon[p1.x - 1, p1.y - 1]);

                        // Chèn tg vào đúng vị trí của p1
                        panel.Controls.Add(pictureBoxTg);

                        // Đưa p2 về trạng thái ban đầu
                        pictureBox.Size = new Size(30, 30);
                        pictureBox.BorderStyle = BorderStyle.None;
                    }
                }
            }
        }
        #endregion

        #region Gắn sự kiện click cho mỗi Icon
        void ProcessEventClick()
        {
            int i, j;
            for (i = 0; i < 12; i++)
            {
                for (j = 0; j < 21; j++)
                {
                    matrixIcon[i, j].Click += PictureBox_Click;
                }
            }
        }

        #endregion
    }
}
