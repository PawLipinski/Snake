using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SnakeGame
{
    class Snake
    {
        private SnakeSegment head;
        private Canvas board;

        private Food foodObject;

        List<SnakeSegment> segments;

        public Snake(Canvas boardOfGame)
        {
            this.board = boardOfGame;
            head = new SnakeSegment(300, 300);
            segments = new List<SnakeSegment>();
            segments.Add(head);
            foodObject = new Food();
            printMe();
        }

        public void printMe()
        {
            foreach (var segment in segments)
            {
                segment.printMe(board);
            }
        }

        public SnakeSegment Head { get { return this.head; } }

        internal void GoRight()
        {
            if (head.X + 60 <= board.Width) head.X += 30;
            printMe();
        }

        internal void GoLeft()
        {
            if (head.X > 0) head.X -= 30;
            printMe();
        }

        internal void GoUp()
        {
            if (head.Y > 0 ) head.Y -= 30;
            printMe();
        }

        internal void GoDown()
        {
            if (head.Y + 60 <= board.Height) head.Y += 30;
            printMe();
        }
    }
}
