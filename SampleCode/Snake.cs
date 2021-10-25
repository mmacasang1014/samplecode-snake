using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SampleCode
{
    enum Direction
    {
        UP = 0,
        LEFT,
        DOWN,
        RIGHT
    }


    class Snake
    {
        static readonly char[] DIRECTIONHEAD = { '^', '<', 'v', '>' };
        static readonly char SNAKE_BODY = 'O';


        private Cell m_currentCellPos;
        private Level m_level;
        private int m_length = 0;
        private bool m_isHit = false;
        private int m_startLenght;
        private Direction m_direction;

        public Snake(int pStartLength, Level pLevel)
        {
            m_level = pLevel;
            m_direction = Direction.UP;
            m_startLenght = pStartLength;
            m_length = pStartLength;

            InputHandler.GetInstance().onUpKeyPressedCallbacks += Up;
            InputHandler.GetInstance().onDownKeyPressedCallbacks += Down;
            InputHandler.GetInstance().onLeftKeyPressedCallbacks += Left;
            InputHandler.GetInstance().onRightKeyPressedCallbacks += Right;
        }

        public bool IsHit
        {
            get
            {
                return m_isHit;
            }
        }

        public int Length
        {
            get
            {
                return m_length;
            }
        }

        public void Restart()
        {
            m_length = m_startLenght;
            m_currentCellPos = m_level.CenterGrid;
            m_isHit = false;

            Update();
        }

        public void Update()
        {
            Move();
            UpdateDirection();
        }

        public void Move()
        {
            switch (m_direction)
            {
                case Direction.UP:
                    {
                        if (m_level.Grid[m_currentCellPos.x, m_currentCellPos.y - 1].val == Level.OBSTACLE)
                        {
                            Hit();
                            return;
                        }

                        VisitCell(m_level.Grid[ m_currentCellPos.x, m_currentCellPos.y - 1]);
                    }
                    break;
                case Direction.DOWN:
                    {
                        if (m_level.Grid[m_currentCellPos.x, m_currentCellPos.y + 1].val == Level.OBSTACLE)
                        {
                            Hit();
                            return;
                        }
                        VisitCell(m_level.Grid[m_currentCellPos.x, m_currentCellPos.y + 1]);
                    }
                    break;
                case Direction.LEFT:
                    {
                        if (m_level.Grid[m_currentCellPos.x - 1, m_currentCellPos.y].val == Level.OBSTACLE)
                        {
                            Hit();
                            return;
                        }
                        VisitCell(m_level.Grid[m_currentCellPos.x - 1, m_currentCellPos.y]);
                    }
                    break;
                case Direction.RIGHT:
                    {
                        if (m_level.Grid[m_currentCellPos.x + 1, m_currentCellPos.y].val == Level.OBSTACLE)
                        {
                            Hit();
                            return;
                        }
                        VisitCell(m_level.Grid[m_currentCellPos.x + 1, m_currentCellPos.y]);
                    }
                    break;

            }

            var speed = 1;
            Thread.Sleep(speed * 100);
        }

        private void UpdateDirection()
        {
            /**
             * Simple updating of direction
             */
            m_currentCellPos.val = DIRECTIONHEAD[(int)m_direction];

            m_currentCellPos.visited = false;
        }

        private void VisitCell(Cell cell)
        {
            //set the cell to snake body
            m_currentCellPos.val = SNAKE_BODY;
            m_currentCellPos.visited = true;

            //decay is for the length of the snake
            m_currentCellPos.decay = m_length;
            m_currentCellPos = cell;
            
            CheckCell(m_currentCellPos);
        }

        private void CheckCell(Cell cell)
        {
            if (cell.val == Level.FOOD)
            {
                EatFood();
                m_level.AddFood();
            }
            if (cell.visited)
            {
                Hit();
            }
        }

        private void EatFood()
        {
            m_length += 1;
        }

        private void Hit()
        {
            m_isHit = true;
        }

        private void Up()
        {
            if (m_direction == Direction.DOWN)
                return;
            m_direction = Direction.UP;
        }

        private void Right()
        {
            if (m_direction == Direction.LEFT)
                return;
            m_direction = Direction.RIGHT;
        }

        private void Down()
        {
            if (m_direction == Direction.UP)
                return;
            m_direction = Direction.DOWN;
        }

        private void Left()
        {
            if (m_direction == Direction.RIGHT)
                return;
            m_direction = Direction.LEFT;
        }
    }


}
