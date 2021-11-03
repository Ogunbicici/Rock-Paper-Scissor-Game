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

namespace BladSteenSchaar
{
   
    public partial class MainWindow : Window
    {              
        bool gameOver = false;

        string[] cpuKeuzeLijst = {"Blad","Steen","Schaar","Steen","Schaar","Blad"};

        int randomNumber = 0;
        Random rnd = new Random();

        string CPUKeuze;
        string playerKeuze;

        int playerScore;
        int CPUScore;
        public MainWindow()
        {
            InitializeComponent();
            playerKeuze = "none";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            randomNumber = rnd.Next(0, cpuKeuzeLijst.Length);
            ComputerView.Content = cpuKeuzeLijst[randomNumber];
            CPUKeuze = cpuKeuzeLijst[randomNumber];
            SpelerView.Content = "Blad";
            playerKeuze = "Blad";
            bladOutcome();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            randomNumber = rnd.Next(0, cpuKeuzeLijst.Length);
            ComputerView.Content = cpuKeuzeLijst[randomNumber];
            CPUKeuze = cpuKeuzeLijst[randomNumber];
            SpelerView.Content = "Steen";
            playerKeuze = "Steen";
            steenOutcome();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            randomNumber = rnd.Next(0, cpuKeuzeLijst.Length);
            ComputerView.Content = cpuKeuzeLijst[randomNumber];
            CPUKeuze = cpuKeuzeLijst[randomNumber];
            SpelerView.Content = "Schaar";
            playerKeuze = "Schaar";
            schaarOutcome();

        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            playerScore = 0;
            CPUScore = 0;           
            gameOver = false;
            SpelerView.Background = Brushes.White;
            ComputerView.Background = Brushes.White;
            SpelerView.Content = Convert.ToString(playerScore); 
            ComputerView.Content = Convert.ToString(CPUScore);
            ComputerScoreLabel.Content = Convert.ToString(CPUScore);
            SpelerScoreLabel.Content = Convert.ToString(playerScore);
            startNextRound();

        }

        private void bladOutcome()
        {
            
            if (CPUKeuze == "Schaar")
            {
                CPUScore += 1;
                ComputerView.Background = Brushes.Green;
                SpelerView.Background = Brushes.White;
                ComputerScoreLabel.Content = Convert.ToString(CPUScore);
                MessageBox.Show("CPU wins");
            }
            else if (CPUKeuze == "Steen")
            {
                playerScore += 1;
                SpelerView.Background = Brushes.Green;
                ComputerView.Background = Brushes.White;
                SpelerScoreLabel.Content = Convert.ToString(playerScore);
                MessageBox.Show("Speler Wins");
            }
            else if (CPUKeuze == "Blad")
            {
                MessageBox.Show("Gelijkspel");
                SpelerView.Background = Brushes.White;
                ComputerView.Background = Brushes.White;
            }
            else
            {
                MessageBox.Show("Choose!");
            }
        }
        private void steenOutcome()
        {
            if (CPUKeuze == "Schaar")
            {
                playerScore += 1;
                SpelerView.Background = Brushes.Green;
                ComputerView.Background = Brushes.White;
                SpelerScoreLabel.Content = Convert.ToString(playerScore);
                MessageBox.Show("Speler Wins");
            }
            else if (CPUKeuze == "Steen")
            {
                MessageBox.Show("Gelijkspel");
                SpelerView.Background = Brushes.White;
                ComputerView.Background = Brushes.White;
            }
            else if (CPUKeuze == "Blad")
            {
                CPUScore += 1;
                ComputerView.Background = Brushes.Green;
                SpelerView.Background = Brushes.White;
                ComputerScoreLabel.Content = Convert.ToString(CPUScore);
                MessageBox.Show("CPU wins");
            }
            else
            {
                MessageBox.Show("Choose!");
            }
        }
        private void schaarOutcome()
        {
            if (CPUKeuze == "Schaar")
            {

                MessageBox.Show("Gelijkspel");
                SpelerView.Background = Brushes.White;
                ComputerView.Background = Brushes.White;
            }
            else if (CPUKeuze == "Steen")
            {
                CPUScore += 1;
                ComputerView.Background = Brushes.Green;
                SpelerView.Background = Brushes.White;
                ComputerScoreLabel.Content = Convert.ToString(CPUScore);
                MessageBox.Show("CPU wins");
            }
            else if (CPUKeuze == "Blad")
            {
                playerScore += 1;
                SpelerView.Background = Brushes.Green;
                ComputerView.Background = Brushes.White;
                SpelerScoreLabel.Content = Convert.ToString(playerScore);
                MessageBox.Show("Speler Wins");
            }
            else
            {
                MessageBox.Show("Choose!");
            }
        }
     
        private void startNextRound()
        {
            if(gameOver == true)
            {
                return;
            }

        }

        
    }
}
