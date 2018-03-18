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
    class Food : SnakeSegment
    {
        public Food()
        {
            segmentBody = new Rectangle();
            segmentBody.Stroke = new SolidColorBrush(Colors.Green);
            segmentBody.Fill = new SolidColorBrush(Colors.Green);
            segmentBody.Width = SnakeSegment.module;
            segmentBody.Height = SnakeSegment.module;
        }

        public void moveToNewPlace(Canvas board, Snake snakeObject)
        {
            board.Children.Remove(this.segmentBody);
            bool onSnake;
            do
            {
                onSnake = false;
                Random generator = new Random();
                this.X = generator.Next(0, 20) * 30;
                this.Y = generator.Next(0, 20) * 30;
                foreach (var segment in snakeObject.Segments)
                {
                    if ((segment.X == this.X) && (segment.Y == this.Y))
                    {
                        onSnake = true;
                    }
                }

                Canvas.SetLeft(this.segmentBody, this.X);
                Canvas.SetTop(this.segmentBody, this.Y);

            }
            while (onSnake == true);
            board.Children.Add(this.segmentBody);
        }
    }
}
