using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SnakeGame
{
    class SnakeSegment
    {
        protected Rectangle segmentBody;
        protected const int module = 30;
        
        public SnakeSegment()
        {
            segmentBody = new Rectangle();
            segmentBody.Stroke = new SolidColorBrush(Colors.Black);
            segmentBody.Fill = new SolidColorBrush(Colors.Black);
            segmentBody.Width = SnakeSegment.module;
            segmentBody.Height = SnakeSegment.module;
        }

        public SnakeSegment(int x, int y): this()
        {
            this.X = x;
            this.Y = y;
        }

        public void printMe(Canvas gamesBoard)
        {
            gamesBoard.Children.Remove(this.segmentBody);
            Canvas.SetLeft(this.segmentBody, this.X);
            Canvas.SetTop(this.segmentBody, this.Y);
            gamesBoard.Children.Add(this.segmentBody);
        }

        public int X { get; set; }
        public int Y { get; set; }

        public Rectangle Rect
        {
            get { return this.segmentBody; }
        }
    }
}
