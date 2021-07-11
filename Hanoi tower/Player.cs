using System;

namespace HanoiTower
{
    public class Player : IDrawable

    {
        public Player()
        {
            Position = 1;
            HasRing = 0;
        }

        public void MoveLeft()
        {
            Position--;
            if (Position < 1) Position = Options.CollumCount;
        }

        public void MoveRight()
        {
            Position++;
            if (Position > Options.CollumCount) Position = 1;
        }

        public int PutRing()
        {
            var ring = HasRing;
            HasRing = 0;
            return ring;
        }

        public void TakeRing(int ring)
        {
            HasRing = ring;
        }

        public void Draw()
        {
            var half = new string('=', HasRing);
            var temp = new string(' ', (Options.Difficulty) + (Position - 1) * (2 * (Options.Difficulty + 3)) - half.Length + 2);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(temp + '(' + half + 'X' + half + ')');
            Console.ResetColor();
        }

        public int HasRing { get; private set; }
        public int Position { get; private set; }
    }
}