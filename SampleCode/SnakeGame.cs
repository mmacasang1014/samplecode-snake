using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCode
{
    class SnakeGame
    {
        private Level m_level = null;
        private Snake m_snake = null;

        private bool m_isLoaded = false;
        private bool m_isGameOver = false;

        private int m_snakeStartLength = 0;
        private int m_gridHeight = 0;
        private int m_gridWidth = 0;
        public SnakeGame(int pInitSnakeLength, int pLvlWidth, int pLvlHeight)
        {
            m_snakeStartLength = pInitSnakeLength;
            m_gridHeight = pLvlHeight;
            m_gridWidth = pLvlWidth;

            m_level = new Level();
            m_snake = new Snake(m_snakeStartLength, m_level);
        }

        public void Create()
        {
            m_level.Create(m_gridWidth, m_gridHeight);

            m_isLoaded = true;

            Restart();
        }

        public void Update()
        {
            InputHandler.GetInstance().Update();

            m_snake.Update();
            m_level.Update();


            if(m_snake.IsHit)
            {
                GameOver();
            }
        }

        public void Restart()
        {
            m_level.Restart();
            m_snake.Restart();

            m_level.AddFood();
            m_isGameOver = false;
        }

        public bool IsGameOver
        {
            get
            {
                return m_isGameOver;
            }
        }

        public int GetScore
        {
            get
            {
                return m_snake.Length - m_snakeStartLength;
            }
        }

        private void GameOver()
        {
            m_isGameOver = true;
        }
    }
}
