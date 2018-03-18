using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SnakeGame
{
    class Snake
    {
        private SnakeSegment head;
        private Canvas board;
        private Key currentDirection;
        private Key counterDirection;
        private Timer snakeTimer;

        private Food foodObject;

        Queue<SnakeSegment> segments;
        private int queueLength;

        public Snake(Canvas boardOfGame)
        {
            this.board = boardOfGame;
            head = new SnakeSegment(300, 300);
            segments = new Queue<SnakeSegment>();
            queueLength = 3;
            foodObject = new Food();
            foodObject.moveToNewPlace(this.board, this);

            snakeTimer = new Timer(60000); // 1 sec = 1000, 60 sec = 60000

            t.AutoReset = true;

            t.Elapsed += new System.Timers.ElapsedEventHandler(t_Elapsed);

            t.Start();

            printMe();
        }

        public void printMe()
        {
            head.printMe(this.board);
            if (segments.Count > queueLength)
            {
                this.board.Children.Remove(segments.Dequeue().Rect);
            }
        }

        public SnakeSegment Head { get { return this.head; } }
        public Queue<SnakeSegment> Segments { get{ return this.segments; } }

        public void Move(Key newDirection)
        {
            if ((newDirection != currentDirection)&&(newDirection != counterDirection))
            {
                if (newDirection == Key.Right)
                {
                    this.currentDirection = Key.Right;
                    this.counterDirection = Key.Left;
                    this.GoRight();
                }
                if (newDirection == Key.Left)
                {
                    this.currentDirection = Key.Left;
                    this.counterDirection = Key.Right;
                    this.GoLeft();
                }
                if (newDirection == Key.Up)
                {
                    this.currentDirection = Key.Up;
                    this.counterDirection = Key.Down;
                    this.GoUp();
                }
                if (newDirection == Key.Down)
                {
                    this.currentDirection = Key.Down;
                    this.counterDirection = Key.Up;
                    this.GoDown();
                }
            }
        }

        internal void GoRight()
        {
            if (head.X + 60 <= board.Width)
            {
                this.segments.Enqueue(head);
                head = new SnakeSegment(this.head.X + 30, this.head.Y);
                isFoodEaten();
                IsDead();
                printMe();
            }
            else
            {
                this.segments.Enqueue(head);
                head = new SnakeSegment(this.head.X = 0, this.head.Y);
                isFoodEaten();
                IsDead();
                printMe();
            }

        }

        internal void GoLeft()
        {
            if (head.X > 0)
            {
                this.segments.Enqueue(head);
                head = new SnakeSegment(this.head.X - 30, this.head.Y);
                isFoodEaten();
                IsDead();
                printMe();
            }
        }

        internal void GoUp()
        {
            if (head.Y > 0)
            {
                this.segments.Enqueue(head);
                head = new SnakeSegment(this.head.X, this.head.Y - 30);
                isFoodEaten();
                IsDead();
                printMe();
            }
        }

        internal void GoDown()
        {
            if (head.Y + 60 <= board.Height)
            {
                this.segments.Enqueue(head);
                head = new SnakeSegment(this.head.X, this.head.Y + 30);
                isFoodEaten();
                IsDead();
                printMe();
            }
        }

        private bool isFoodEaten()
        {
            if ((this.Head.X == foodObject.X) && (this.Head.Y == this.foodObject.Y))
            {
                this.queueLength++;
                this.foodObject.moveToNewPlace(this.board, this);
                return true;
            }

            else return false;
        }

        private bool IsDead()
        {
            bool isDead = false;

            foreach (var segment in segments)
            {
                if ((head.X == segment.X)&&(head.Y == segment.Y))
                {
                    isDead = true;
                }
            }

            if (isDead == true)
            {
                Gameover();
            }
            return isDead;
        }

        private void Gameover()
        {
            MessageBox.Show("Koniec Gry!");
            System.Windows.Application.Current.Shutdown();
        }

        private static void t_Elapsed(object sender, System.Timers.ElapsedEventArgs e)

        {

            

        }

    }
}
