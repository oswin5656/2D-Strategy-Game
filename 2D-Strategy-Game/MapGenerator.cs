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
                    squares[i, j] = new Square(i, j, "plains", true, 2);
                }
            }

            return new Map(squares, new List<Unit>(), rows, cols);
        }
    }
}
