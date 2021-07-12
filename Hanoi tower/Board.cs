using System;

namespace HanoiTower
{
    public class Board : IDrawable
    {
        public Board(int lengthOfColumn, int columnCount = 3)
        {
            BoardMatrix = new int[lengthOfColumn, columnCount];

            for (var i = 0; i < columnCount; i++)
            {
                for (var j = 0; j < lengthOfColumn; j++)
                {
                    if (i == 0) BoardMatrix[j, i] = j + 1;
                    else
                        BoardMatrix[j, i] = 0;
                }
            }
        }

        public void Draw()
        {
            for (var i = 0; i < Options.Difficulty; i++)
            {
                string line = "| ";
                for (var j = 0; j < Options.ColumnCount; j++)
                {
                    var count = (BoardMatrix[i, j] * 2 + 1);
                    var tempM1 = new string('=', count);
                    var tempL1 = new string(' ', (Options.Difficulty - BoardMatrix[i, j]));
                    line += tempL1 + "(" + tempM1 + ")" + tempL1 + " | ";
                }
                Console.WriteLine(line);
            }
        }

        public int TakeTopRing(int columnNumber)
        {
            var topElement = 0;
            for (var i = 0; i < Options.Difficulty; i++)
            {
                if (BoardMatrix[i, columnNumber - 1] == 0) continue;
                topElement = BoardMatrix[i, columnNumber - 1];
                BoardMatrix[i, columnNumber - 1] = 0;
                return topElement;
            }
            return topElement;
        }

        public int TopRing(int columnNumber)
        {
            var topElement = 0;
            for (var i = 0; i < Options.Difficulty; i++)
            {
                if (BoardMatrix[i, columnNumber - 1] == 0) continue;
                topElement = BoardMatrix[i, columnNumber - 1];
                return topElement;
            }
            return topElement;
        }

        public void PutTopRing(int ring, int columnNumber)
        {
            for (var i = 1; i < Options.Difficulty; i++)
            {
                if (BoardMatrix[i, columnNumber - 1] != 0)
                {
                    BoardMatrix[i - 1, columnNumber - 1] = ring;
                    break;
                }

                if (i == Options.Difficulty - 1)
                {
                    BoardMatrix[Options.Difficulty - 1, columnNumber - 1] = ring;
                }
            }
        }

        private int[,] BoardMatrix { get; }
    }
}