using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_Pikachu.PlayViewProcess
{
    public class ProcessPlay
    {
        public static PointNew[] arrayPoint = new PointNew[4];

        #region Check Column
        public int CheckColumn(int [,] numberMatrixIcon, PointNew p1, PointNew p2)
        {
            if (p1.x > p2.x) return 0;
            if (p1.y != p2.y) return 0;
            int i;
            if (p1.x + 1 == p2.x)
            {
                if ((numberMatrixIcon[p1.x, p1.y] == numberMatrixIcon[p2.x, p2.y]) ||
                    (numberMatrixIcon[p1.x, p1.y] == 0 && numberMatrixIcon[p2.x, p2.y]!=0) ||
                    (numberMatrixIcon[p1.x, p1.y] != 0 && numberMatrixIcon[p2.x, p2.y] == 0)) return 1;
                else return 0;
            }
            else
            {
                if ((numberMatrixIcon[p1.x, p1.y] == numberMatrixIcon[p2.x, p2.y]) ||
                   (numberMatrixIcon[p1.x, p1.y] == 0 && numberMatrixIcon[p2.x, p2.y] != 0) ||
                   (numberMatrixIcon[p1.x, p1.y] != 0 && numberMatrixIcon[p2.x, p2.y] == 0))
                {
                    for (i = p1.x + 1; i < p2.x; i++)
                        if (numberMatrixIcon[i, p1.y] != 0) return 0;
                        return 1;
                }
                return 0;                   
            }
        }
        #endregion

        #region CheckRow
        public int CheckRow(int[,] numberMatrixIcon, PointNew p1, PointNew p2)
        {
            if (p1.y > p2.y) return 0;
            if (p1.x != p2.x) return 0;
            int i;
            if (p1.y + 1 == p2.y)
            {
                if ((numberMatrixIcon[p1.x, p1.y] == numberMatrixIcon[p2.x, p2.y])
                    || (numberMatrixIcon[p1.x, p1.y] == 0 && numberMatrixIcon[p2.x, p2.y] != 0)
                    || (numberMatrixIcon[p1.x, p1.y] != 0 && numberMatrixIcon[p2.x, p2.y] == 0)) return 1;
                else return 0;
            }
            else
            {
                if ((numberMatrixIcon[p1.x, p1.y] == numberMatrixIcon[p2.x, p2.y])
                   || (numberMatrixIcon[p1.x, p1.y] == 0 && numberMatrixIcon[p2.x, p2.y] != 0)
                   || (numberMatrixIcon[p1.x, p1.y] != 0 && numberMatrixIcon[p2.x, p2.y] == 0)) 

                {
                    for (i = p1.y + 1; i < p2.y; i++)
                        if (numberMatrixIcon[p1.x, i] != 0) return 0;
                    return 1;
                }
                else return 0;               
            }
        }
        #endregion

        #region Kiểm tra nếu 2 điểm cùng dòng
        public int FindRow(int[,] numberMatrixIcon, PointNew p1, PointNew p2)
        {
            PointNew tg;
            if (p1.y > p2.y)
            {
                tg = p1;
                p1 = p2;
                p2 = tg;
            }
            if (CheckRow(numberMatrixIcon, p1, p2) == 0) return 0;
            arrayPoint[0] = p1;
            arrayPoint[1] = p2;
            return 1;
        }
        #endregion

        #region Kiểm tra nếu 2 điểm cùng cột
        public int FindColumn(int[,] numberMatrixIcon, PointNew p1, PointNew p2)
        {
            PointNew tg;
            if (p1.x > p2.x)
            {
                tg = p1;
                p1 = p2;
                p2 = tg;
            }
            if (CheckColumn(numberMatrixIcon, p1, p2) == 0) return 0;
            arrayPoint[0] = p1;
            arrayPoint[1] = p2;
            return 1;
        }
        #endregion

        #region Kiểm tra đường đi gấp khúc từ trái qua phải
        public int ZigZugLeftToRight(int [,] matrixNumberIcon, PointNew p1, PointNew p2)
        {
            // Nếu p1 ! p2 loại luôn
            if (matrixNumberIcon[p1.x, p1.y] != matrixNumberIcon[p2.x, p2.y]) return 0;
            // Nếu p1 nằm bên phải p2 thì đổi chỗ để dễ xử lý.
            PointNew ptg = new PointNew();
            if (p1.y>p2.y)
            {
                ptg = p1;
                p1 = p2;
                p2 = ptg;
            }

            // Duyệt lần lượt từ trái sang phải
            PointNew p1tg = new PointNew();
            PointNew p2tg = new PointNew();
            int i;
            for (i = 0; i < 23; i++)
            {
                p1tg.x = p1.x;
                p1tg.y = i;
                p2tg.x = p2.x;
                p2tg.y = i;

                // Kiểm tra 2 điểm góc là 0 hoặc (1 điểm thẳng cột với 1 trong 2 điểm p1, p2 và 1 góc bằng 0)
                if ((matrixNumberIcon[p1tg.x, p1tg.y] == 0 && matrixNumberIcon[p2tg.x, p2tg.y] == 0) ||
                   (p1tg.y == p2.y && matrixNumberIcon[p1tg.x, p1tg.y] == 0) ||
                   (p2tg.y == p1.y && matrixNumberIcon[p2tg.x, p2tg.y] == 0))
                {
                    if (FindColumn(matrixNumberIcon, p1tg, p2tg) == 1)
                    {
                        arrayPoint[0] = p1;
                        arrayPoint[1] = p1tg;
                        arrayPoint[2] = p2tg;
                        arrayPoint[3] = p2;
                        // Trường hợp i < p1.y
                        if (i < p1.y)
                        {
                            // Kiểm tra 2 hàng ngang từ p1tg đến p1 và p2tg đến p2
                            if (FindRow(matrixNumberIcon, p1tg, p1) == 1 && FindRow(matrixNumberIcon, p2tg, p2) == 1)
                            {
                                return 1;
                            }

                        }

                        // Trường hợp p1.y <i <p2.y
                        else if (p1.y < i && i < p2.y)
                        {
                            // Kiểm tra 2 hàng ngang từ p1 đến p1tg và p2tg đến p2
                            if (FindRow(matrixNumberIcon, p1, p1tg) == 1 && FindRow(matrixNumberIcon, p2tg, p2) == 1)
                            {
                                return 1;
                            }
                        }
                        
                        //Trường hợp p2.y<i
                        else if (p2.y < i)
                        {
                            //Kiểm tra 2 hàng ngang từ p1tg đến p1 và p2 đến p2tg
                            if (FindRow(matrixNumberIcon, p1tg, p1) == 1 && FindRow(matrixNumberIcon, p2, p2tg) == 1)
                            {
                                return 1;
                            }
                        }

                        //Trường hợp p1.y = i;
                        else if (p1.y == i)
                        {
                            // Kiểm tra 1 hàng ngang từ p2tg đến p2
                            if (FindRow(matrixNumberIcon, p1tg, p2) == 1)
                            {
                                arrayPoint[2] = p2;
                                arrayPoint[3] = p2;
                                return 1;
                            }
                        }

                        // Trường hợp p2.y=i
                        else if (p2.y == i) 
                        {
                            //Kiểm tra 1 hàng ngang từ p1 đến p1tg
                            if (FindRow(matrixNumberIcon, p1, p1tg) == 1)
                            {
                                arrayPoint[2] = p2;
                                arrayPoint[3] = p2;
                                return 1;
                            }
                        }
                        
                    }
                }               
            }
            return 0;




        }
        #endregion


        #region Kiểm tra đường đi gấp khúc từ trên xuống dưới
        public int ZigZugUpToDown(int [,] matrixNumberIcon, PointNew p1, PointNew p2)
        {
            // Nếu p1 ! p2 loại luôn
            if (matrixNumberIcon[p1.x, p1.y] != matrixNumberIcon[p2.x, p2.y]) return 0;
            // Nếu p1 nằm bên dưới p2 thì đổi chỗ để dễ xử lý.
            PointNew ptg = new PointNew();
            if (p1.x>p2.x)
            {
                ptg = p1;
                p1 = p2;
                p2 = ptg;
            }

            // Duyệt lần lượt trên xuống dưới
            PointNew p1tg = new PointNew();
            PointNew p2tg = new PointNew();
            int i;
            for (i = 0; i < 14; i++)
            {
                p1tg.y = p1.y;
                p1tg.x = i;
                p2tg.y = p2.y;
                p2tg.x = i;

                // Kiểm tra 2 điểm góc là 0 hoặc (1 điểm thẳng hàng với 1 trong 2 điểm p1, p2 và 1 góc bằng 0)
                if ((matrixNumberIcon[p1tg.x, p1tg.y] == 0 && matrixNumberIcon[p2tg.x, p2tg.y] == 0) ||
                   (p1tg.x == p2.x && matrixNumberIcon[p1tg.x, p1tg.y] == 0) ||
                   (p2tg.x == p1.x && matrixNumberIcon[p2tg.x, p2tg.y] == 0))
                {
                    if (FindRow(matrixNumberIcon, p1tg, p2tg) == 1)
                    {
                        arrayPoint[0] = p1;
                        arrayPoint[1] = p1tg;
                        arrayPoint[2] = p2tg;
                        arrayPoint[3] = p2;
                        // Trường hợp i < p1.x
                        if (i < p1.x)
                        {
                            // Kiểm tra 2 cột từ p1tg đến p1 và p2tg đến p2
                            if (FindColumn(matrixNumberIcon, p1tg, p1) == 1 && FindColumn(matrixNumberIcon, p2tg, p2) == 1)
                            {
                                return 1;
                            }

                        }

                        // Trường hợp p1.x <i <p2.x
                        else if (p1.x < i && i < p2.x)
                        {
                            // Kiểm tra 2 cột từ p1 đến p1tg và p2tg đến p2
                            if (FindColumn(matrixNumberIcon, p1, p1tg) == 1 && FindColumn(matrixNumberIcon, p2tg, p2) == 1)
                            {
                                return 1;
                            }
                        }
                        
                        //Trường hợp p2.x<i
                        else if (p2.x < i)
                        {
                            //Kiểm tra 2 cột từ p1tg đến p1 và p2 đến p2tg
                            if (FindColumn(matrixNumberIcon, p1tg, p1) == 1 && FindColumn(matrixNumberIcon, p2, p2tg) == 1)
                            {
                                return 1;
                            }
                        }

                        //Trường hợp p1.x = i;
                        else if (p1.x == i)
                        {
                            // Kiểm tra 1 cột từ p2tg đến p2
                            if (FindColumn(matrixNumberIcon, p1tg, p2) == 1)
                            {
                                arrayPoint[2] = p2;
                                arrayPoint[3] = p2;
                                return 1;
                            }
                        }

                        // Trường hợp p2.x=i
                        else if (p2.x == i) 
                        {
                            //Kiểm tra 1 cột từ p1 đến p1tg
                            if (FindColumn(matrixNumberIcon, p1, p1tg) == 1)
                            {
                                arrayPoint[2] = p2;
                                arrayPoint[3] = p2;
                                return 1;
                            }
                        }
                        
                    }
                }               
            }
            return 0;




        }
        #endregion

    }
}
