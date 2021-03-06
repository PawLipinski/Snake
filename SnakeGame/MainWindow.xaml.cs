﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SnakeGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Snake mySnake;

        public MainWindow()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(OnButtonKeyDown);

            mySnake = new Snake(this.Board);
        }

        private void OnButtonKeyDown(object sender, KeyEventArgs e)
        {
            mySnake.ChangeDirection(e.Key);
        }
    }

    
}
