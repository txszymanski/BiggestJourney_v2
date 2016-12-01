using System;
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

namespace BiggestJourney
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int round = 0;
        int score = 0;
        bool jumpActive = true;
        Random random = new Random();
        Player player;
        Exit exit;

        List<Image> backgroundImageList = new List<Image>();
        List<Image> batImageList = new List<Image>();

        public MainWindow()
        {
            InitializeComponent();
            BackgroundListInitalizer();
            BatListInitalizer();
            NextRound();
        }

        private void NextRound()
        {
            ClearBoard();
            round++;
            GenerateExit();
            player = new Player(5, 9, playerImage);
            Game.objectList.Add(player);
            Game.movingObjectList.Add(player);
            GenerateNonMovingObjects();
            GenerateEnemies();
            UpdateWindow();
            jumpActive = true;
            jumpButton.Content = "Can be activated";
            roundLabel.Content = "Round: " + round;
        }

        private void GenerateExit()
        {
            int x = random.Next(1, 10);
            int y = random.Next(1, 9);
            exit = new Exit(x, y, exitImage);
            Game.objectList.Add(exit);
            exit.updatePosition();
        }

        private void UpdateWindow()
        {
            foreach (IObjects item in Game.objectList)
            {
                item.updatePosition();
            }

            if (player.PositionX==exit.PositionX && player.PositionY==exit.PositionY)
            {
                NextRound();
            }
        }

        private void ClearBoard()
        {
            Game.nonMovingObjectList.Clear();
            Game.movingObjectList.Clear();
            Game.objectList.Clear();
            Game.enemyList.Clear();

            foreach (Image item in backgroundImageList)
            {
                Grid.SetRow(item, 0);
                Grid.SetColumn(item, 0);
                item.Visibility = Visibility.Hidden;
                item.IsEnabled = false;
            }

            foreach (Image item in batImageList)
            {
                Grid.SetRow(item, 0);
                Grid.SetColumn(item, 0);
                item.Visibility = Visibility.Hidden;
                item.IsEnabled = false;
            }
        }

        private void GenerateNonMovingObjects()
        {
            bool canCreateObject;
            for (int i = 0; i < 9;)
            {
                canCreateObject = true;
                int x = random.Next(1, 10);
                int y = random.Next(1, 9);
                foreach (NonMovingObject item in Game.nonMovingObjectList)
                {
                    if (item.PositionX == x && item.PositionY == y)
                        canCreateObject = false;
                }
                if (canCreateObject)
                {
                    Game.nonMovingObjectList.Add(new NonMovingObject(x, y, backgroundImageList[i]));
                    Game.objectList.Add(Game.nonMovingObjectList[i]);
                    Game.nonMovingObjectList[i].updatePosition();
                    backgroundImageList[i].Visibility = Visibility.Visible;
                    backgroundImageList[i].IsEnabled = true;
                    i++;
                }
            }
        }

        private void GenerateEnemies()
        {
            bool canCreateObject;
            int insideRound = round;
            if (insideRound > 5) round = 5;
            for (int i = 0; i < round;)
            {
                canCreateObject = true;
                int x = random.Next(1, 10);
                int y = random.Next(1, 7);
                foreach (IObjects item in Game.objectList)
                {
                    if (item.PositionX == x && item.PositionY == y)
                        canCreateObject = false;
                }
                if (canCreateObject)
                {
                    Game.enemyList.Add(new Bat(x, y, batImageList[i]));
                    Game.movingObjectList.Add(Game.enemyList[Game.enemyList.Count - 1]);
                    Game.objectList.Add(Game.enemyList[Game.enemyList.Count - 1]);
                    Game.enemyList[i].updatePosition();
                    batImageList[i].Visibility = Visibility.Visible;
                    batImageList[i].IsEnabled = true;
                    i++;
                }
            }
        }

        private void Grid_MouseEnter(object sender, MouseButtonEventArgs e)
        {
            if (jumpButton.Content.ToString()=="Activated" && player.CanObjectJump(clickColPosition(), clickRowPosition()) && player.IsPlayerLived)
            {
                player.Move(clickColPosition(), clickRowPosition());

                for (int i = 0; i < Game.enemyList.Count; ++i)
                {
                    if ((Game.enemyList[i].PositionX + 1 == player.PositionX || Game.enemyList[i].PositionX - 1 == player.PositionX || Game.enemyList[i].PositionX == player.PositionX) &&
                        (Game.enemyList[i].PositionY + 1 == player.PositionY || Game.enemyList[i].PositionY - 1 == player.PositionY || Game.enemyList[i].PositionY == player.PositionY))
                    {
                        Game.enemyList[i].PositionX = 0;
                        Game.enemyList[i].PositionY = 0;
                        score++;
                        scoreLabel.Content = "Score: " + score;
                        player.Move(clickColPosition(), clickRowPosition());
                    }
                }
                jumpActive = false;
                jumpButton.Content = "Has to charge...";
                UpdateWindow();

                EnemyMove();
            }
            else if (player.CanObjectMove(clickColPosition(), clickRowPosition()) && player.IsPlayerLived)
            {
                player.Move(clickColPosition(), clickRowPosition());

                for (int i = 0; i < Game.enemyList.Count; ++i)
                {
                    if ((Game.enemyList[i].PositionX + 1 == player.PositionX || Game.enemyList[i].PositionX - 1 == player.PositionX || Game.enemyList[i].PositionX == player.PositionX) &&
                        (Game.enemyList[i].PositionY + 1 == player.PositionY || Game.enemyList[i].PositionY - 1 == player.PositionY || Game.enemyList[i].PositionY == player.PositionY))
                    {
                        Game.enemyList[i].PositionX = 0;
                        Game.enemyList[i].PositionY = 0;
                        score++;
                        scoreLabel.Content = "Score: " + score;
                        player.Move(clickColPosition(), clickRowPosition());
                    }
                }
                //foreach (Enemy enemy in Game.enemyList)
                //{
                //    if(enemy.PositionX ==0 && enemy.PositionY==0)
                //}
                //Game.enemyList.RemoveAt(i);
                //player.Move(clickColPosition(), clickRowPosition());
                UpdateWindow();

                EnemyMove();
            }
        }

        private void EnemyMove()
        {
            foreach (Enemy enemy in Game.enemyList)
            {
                enemy.MoveToKill();
            }
            UpdateWindow();
            foreach (Enemy enemy in Game.enemyList)
            {
                if (enemy.IsPlayerKilled() == true)
                {
                    playerImage.Source = new BitmapImage(new Uri(@"Images/radcaKilled.png", UriKind.Relative));
                    player.IsPlayerLived = false;
                }
            }

        }

        private int clickRowPosition()
        {
            var point = Mouse.GetPosition(mainGrid);
            int row = 0;
            double accumulatedHeight = 0.0;

            foreach (var rowDefinition in mainGrid.RowDefinitions)
            {
                accumulatedHeight += rowDefinition.ActualHeight;
                if (accumulatedHeight >= point.Y)
                    break;
                row++;

            }
            return row;
        }

        private int clickColPosition()
        {
            var point = Mouse.GetPosition(mainGrid);
            int col = 0;
            double accumulatedWidth = 0.0;

            foreach (var columnDefinition in mainGrid.ColumnDefinitions)
            {
                accumulatedWidth += columnDefinition.ActualWidth;
                if (accumulatedWidth >= point.X)
                    break;
                col++;
            }
            return col;
        }

        private void BackgroundListInitalizer()
        {
            backgroundImageList.Add(b1);
            backgroundImageList.Add(b2);
            backgroundImageList.Add(b3);
            backgroundImageList.Add(b4);
            backgroundImageList.Add(b5);
            backgroundImageList.Add(b6);
            backgroundImageList.Add(b7);
            backgroundImageList.Add(b8);
            backgroundImageList.Add(b9);
        }


        private void BatListInitalizer()
        {
            batImageList.Add(bat1);
            batImageList.Add(bat2);
            batImageList.Add(bat3);
            batImageList.Add(bat4);
            batImageList.Add(bat5);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (jumpActive == true)
            {
                jumpButton.Content = "Activated";
            }
        }
    }
}