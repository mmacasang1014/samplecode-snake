using System;
using System.Threading;

namespace SampleCode
{
    class Program
    {
        static SnakeGame m_snakeGame;

        static int START_SNAKE_LENGTH   = 5;
        static int START_LVL_HEIGHT     = 25;
        static int START_LVL_WIDTH      = 90;
        static void Main(string[] args)
        {
            m_snakeGame = new SnakeGame(START_SNAKE_LENGTH, START_LVL_WIDTH, START_LVL_HEIGHT);

            m_snakeGame.Create();

            while (!InputHandler.GetInstance().IsQuit)
            {
                m_snakeGame.Update();

                if (m_snakeGame.IsGameOver)
                {
                    Restart();
                }
            }
        }

        static void Restart()
        {
            ScoreUIHandler.GetInstance().ShowGameOver();
            ScoreUIHandler.GetInstance().Update(m_snakeGame.GetScore);

            Thread.Sleep(1000);
            Console.Clear();

            m_snakeGame.Restart();
        }
    }
}