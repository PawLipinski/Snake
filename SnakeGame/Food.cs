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
            segmentBody.Fill = new SolidColorBrush(Colors.Black);
            segmentBody.Width = SnakeSegment.module;
            segmentBody.Height = SnakeSegment.module;
        }

        public void moveToNewPlace(Canvas board)
        {
            board.Children.Remove(this.segmentBody);
            Random generator = new Random();
            this.X = generator.Next(0,20)*30;
            this.Y = generator.Next(0, 20) * 30;
            board.Children.Add(this.segmentBody);
        }
    }
}
