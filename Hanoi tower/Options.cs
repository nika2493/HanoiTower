#nullable enable

using System;

namespace HanoiTower
{
    public static class Options

    {
        public static int Difficulty { get; private set; }
        public static int CollumCount = 4;

        public static int SetDifficulty(string error = "")
        {
            int diff;
            Console.Clear();
            Console.WriteLine("Set your difficulty:3-15 ");
            if (error != "")
                Console.WriteLine(error);
            try
            {
                diff = Convert.ToInt32(Console.ReadLine());
                if (diff is >= 3 and <= 15)
                {
                    Console.Clear();
                }
                else diff = SetDifficulty("needs to be number in range{3-15}!");
            }
            catch
            {
                diff = SetDifficulty("needs to be number in range{3-15}!");
            }
            Difficulty = diff;
            return diff;
        }

        public static void Draw()
        {
            Console.Title = "Hanoi tower";
            Console.CursorVisible = false;
            Console.SetCursorPosition(Console.WindowWidth / 2, Console.CursorTop);
            Console.WriteLine(Difficulty);
            Console.WriteLine('\n');
        }
    }
}