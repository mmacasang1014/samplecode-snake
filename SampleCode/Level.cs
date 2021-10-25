using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCode
{
    class Level
    {
        public static char FOOD = '@';
        public static char OBSTACLE = '*';
        public static char VOID = ' ';

        private Cell[,] m_grid;
        private int m_gridHeight = 0;
        private int m_gridWidth = 0;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="pGridH">Grid's Height</param>
        /// <param name="pGridW">Grid's Width</param>
        public void Create(int pGridW, int pGridH)
        {
            m_gridHeight = pGridH;
            m_gridWidth = pGridW;

            Restart();
        }

        public void Update()
        {
            Console.SetCursorPosition(0, 0);
            Render();
        }

        public void Restart()
        {
            m_grid = new Cell[m_gridWidth, m_gridHeight];
            Generate();
        }

        /// <summary>
        /// Add food to level
        /// </summary>
        public void AddFood()
        {
            Random r = new Random();
            Cell cell;

            //TODO fix this
            while (true)
            {
                cell = m_grid[r.Next(m_grid.GetLength(0)), r.Next(m_grid.GetLength(1))];
                if (cell.val == VOID)
                    cell.val = FOOD;
                break;
            }
        }

        public Cell[,] Grid
        {
            get
            {
                return m_grid;
            }
        }

        public int GridHeight
        {
            get
            {
                return m_gridHeight;
            }
        }

        public int GridWidth
        {
            get
            {
                return m_gridWidth;
            }
        }

        public Cell CenterGrid
        {
            get
            {
                return m_grid[(int)Math.Ceiling((double)m_gridWidth / 2), (int)Math.Ceiling((double)m_gridHeight / 2)];
            }
        }

        /// <summary>
        /// Generate Level
        /// </summary>
        private void Generate()
        {
            for (int row = 0; row < m_gridWidth; row++)
            {
                for (int col = 0; col < m_gridHeight; col++)
                {
                    Cell cell = new Cell();
                    cell.x = row;
                    cell.y = col;
                    cell.visited = false;

                    cell.Set(OBSTACLE);

                    if (cell.x == 0 || cell.x > m_gridWidth - 2 || cell.y == 0 || cell.y > m_gridHeight - 2)
                        cell.Set(OBSTACLE);
                    else
                        cell.Clear();

                    m_grid[row, col] = cell;
                }
            }
        }

        private void Render()
        {
            string level = "";
            for (int col = 0; col < m_gridHeight; col++)
            {
                for (int row = 0; row < m_gridWidth; row++)
                {
                    m_grid[row, col].Decay();
                    level += m_grid[row, col].val;
                }
                level += "\n";
            }
            Console.WriteLine(level);
        }

    }
    
}
