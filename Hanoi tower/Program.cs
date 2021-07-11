using System;
using static HanoiTower.Options;

namespace HanoiTower
{
    internal static class Program
    {
        private static void Main()
        {
            Options.SetDifficulty();
            var player = new Player();
            var board = new Board(Difficulty, CollumCount);
            DrawGameState.Draw(player, board);

            while (true)
            {
                var pressedKey = Console.ReadKey(true).Key;
                switch (pressedKey)
                {
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;

                    case ConsoleKey.LeftArrow or ConsoleKey.A:
                        player.MoveLeft();
                        DrawGameState.Draw(player, board);
                        break;

                    case ConsoleKey.RightArrow or ConsoleKey.D:
                        player.MoveRight();
                        DrawGameState.Draw(player, board);
                        break;

                    case ConsoleKey.Spacebar or ConsoleKey.Enter:
                        Action(player, board);
                        DrawGameState.Draw(player, board);
                        break;
                }
            }
        }

        private static void Action(Player player, Board board)
        {
            if (player.HasRing == 0)
            {
                player.TakeRing(board.TakeTopRing(player.Position));
            }
            else
            {
                if (player.HasRing < board.TopRing(player.Position) || board.TopRing(player.Position) == 0)
                {
                    board.PutTopRing(player.PutRing(), player.Position);
                }
            }
        }
    }
}