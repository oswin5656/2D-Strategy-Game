using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2D_Strategy_Game
{
    class MapGenerator
    {
        public static Map GeneratePlainMap(int rows, int cols)
        {
            Square[,] squares = new Square[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    squares[i, j] = new Square(i, j, "plains");
                }
            }

            return new Map(squares, new List<Unit>(), rows, cols);
        }

        public static Map GenerateRandomMap(int rows, int cols)
        {
            Random r = new Random();
            Square[,] squares = new Square[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    switch (r.Next(4))
                    {
                        case 0: squares[i, j] = new Square(i, j, "plains");
                            break;
                        case 1: squares[i, j] = new Square(i, j, "forest");
                            break;
                        case 2: squares[i, j] = new Square(i, j, "hills");
                            break;
                        case 3: squares[i, j] = new Square(i, j, "mountain");
                            break;
                    }   
                }
            }

            return new Map(squares, new List<Unit>(), rows, cols);

        }
    }
}
