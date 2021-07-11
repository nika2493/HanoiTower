using System;

namespace HanoiTower
{
    public static class DrawGameState
    {
        public static void Draw(Player player, Board board)
        {
            Console.Clear();
            Options.Draw();
            player.Draw();
            board.Draw();
        }
    }
}