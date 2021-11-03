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
using System.Windows.Threading;

namespace BladSteenSchaarV2
{
    public partial class MainWindow : Window
    {

        private int timePerRound = 5;
        private DispatcherTimer Timer;

        bool gameOver = false;

        string[] cpuKeuzeLijst = { "Blad", "Steen", "Schaar", "Steen", "Schaar", "Blad", "Blad", "Schaar", "Steen" };

        int randomNumber = 0;
        Random rnd = new Random();

        string CPUKeuze;
        string spelerKeuze;

        int rondes = 10;
        int playerScore;
        int CPUScore;

        public MainWindow()
        {

            InitializeComponent();
            Timer = new DispatcherTimer();
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Tick += Timer_Tick;
            Timer.Start();

            InitializeComponent();

            Resultaat.Content = "Resultaat";
            SpelerView.Source = new BitmapImage(new Uri(@"Images\vraagTekenpic.png", UriKind.RelativeOrAbsolute));
            ComputerView.Source = new BitmapImage(new Uri(@"Images\vraagTekenpic.png", UriKind.RelativeOrAbsolute));

            spelerKeuze = "none";
        }


        //Timer laten aftikken en de CPU een keuze laten maken.
        private void Timer_Tick(object sender, EventArgs e)
        {
            timePerRound -= 1;
            TBCountDown.Text = timePerRound.ToString();
            TBCountDown.Foreground = Brushes.Black;


            if (gameOver == true)
            {
                Timer.Stop();
            }

            if (timePerRound <= 4)
            {
                ComputerView.Source = new BitmapImage(new Uri(@"Images\vraagTekenpic.png", UriKind.RelativeOrAbsolute));
            }

            if (timePerRound < 1)
            {

                Timer.IsEnabled = false;
                timePerRound = 6;

                randomNumber = rnd.Next(0, cpuKeuzeLijst.Length);
                CPUKeuze = cpuKeuzeLijst[randomNumber];


                if (CPUKeuze == "Steen")
                {
                    ComputerView.Source = new BitmapImage(new Uri(@"Images\steenpic.png", UriKind.RelativeOrAbsolute));
                }
                else if (CPUKeuze == "Schaar")
                {
                    ComputerView.Source = new BitmapImage(new Uri(@"Images\schaarpic.png", UriKind.RelativeOrAbsolute));
                }
                else if (CPUKeuze == "Blad")
                {
                    ComputerView.Source = new BitmapImage(new Uri(@"Images\Blad.png", UriKind.RelativeOrAbsolute));
                }

                if (rondes > 0)
                {
                    spelRegels();
                }


            }

            if (timePerRound <= 2)
            {
                TBCountDown.Foreground = Brushes.Red;
            }

        }

        ///Blad Button
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Timer.Start();
            Blad.BorderThickness = new Thickness(4);
            Steen.BorderThickness = new Thickness(1);
            Schaar.BorderThickness = new Thickness(1);
            SpelerView.Source = new BitmapImage(new Uri(@"Images\Blad.png", UriKind.RelativeOrAbsolute));
            spelerKeuze = "Blad";

        }

        //Steen button 
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            Timer.Start();
            Steen.BorderThickness = new Thickness(4);
            Blad.BorderThickness = new Thickness(1);
            Schaar.BorderThickness = new Thickness(1);
            SpelerView.Source = new BitmapImage(new Uri(@"Images\steenpic.png", UriKind.RelativeOrAbsolute));
            spelerKeuze = "Steen";

        }

        //Schaar button
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            Timer.Start();
            Schaar.BorderThickness = new Thickness(4);
            Steen.BorderThickness = new Thickness(1);
            Blad.BorderThickness = new Thickness(1);
            SpelerView.Source = new BitmapImage(new Uri(@"Images\schaarpic.png", UriKind.RelativeOrAbsolute));
            spelerKeuze = "Schaar";

        }

        //Restart Button
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Schaar.IsEnabled = true;
            Steen.IsEnabled = true;
            Blad.IsEnabled = true;

            playerScore = 0;
            CPUScore = 0;
            gameOver = false;
            timePerRound = 6;
            SpelerView.Source = new BitmapImage(new Uri(@"Images\vraagTekenpic.png", UriKind.RelativeOrAbsolute));
            ComputerView.Source = new BitmapImage(new Uri(@"Images\vraagTekenpic.png", UriKind.RelativeOrAbsolute));
            ComputerScoreLabel.Content = Convert.ToString(CPUScore);
            SpelerScoreLabel.Content = Convert.ToString(playerScore);

        }


        //Hier kijken we wie er wint en ofdat de speler/cpu al 10 punten heeft.
        private void spelRegels()
        {
            if (CPUScore == 10)
            {

                gameOver = true;
                Schaar.IsEnabled = false;
                Steen.IsEnabled = false;
                Blad.IsEnabled = false;

                Resultaat.Content = "Einde spel.";
                MessageBox.Show("Game over, de Computer wint deze wedstrijd!\nRestart het spel.");


                SpelerView.Source = new BitmapImage(new Uri(@"Images\vraagTekenpic.png", UriKind.RelativeOrAbsolute));
                ComputerView.Source = new BitmapImage(new Uri(@"Images\vraagTekenpic.png", UriKind.RelativeOrAbsolute));

            }
            else if (playerScore == 10)
            {

                gameOver = true;
                Schaar.IsEnabled = false;
                Steen.IsEnabled = false;
                Blad.IsEnabled = false;

                Resultaat.Content = "Einde spel.";
                MessageBox.Show("Game over, de Speler wint deze wedstrijd!\nRestart het spel.");

                SpelerView.Source = new BitmapImage(new Uri(@"Images\vraagTekenpic.png", UriKind.RelativeOrAbsolute));
                ComputerView.Source = new BitmapImage(new Uri(@"Images\vraagTekenpic.png", UriKind.RelativeOrAbsolute));
            }


            if (spelerKeuze == "Steen" && CPUKeuze == "Blad")
            {
                CPUScore += 1;
                ComputerScoreLabel.Content = Convert.ToString(CPUScore);
                Resultaat.Content = "Cpu Wint!";

            }
            else if (spelerKeuze == "Schaar" && CPUKeuze == "Steen")
            {
                CPUScore += 1;
                ComputerScoreLabel.Content = Convert.ToString(CPUScore);
                Resultaat.Content = "Cpu Wint!";
            }
            else if (spelerKeuze == "Blad" && CPUKeuze == "Schaar")
            {
                CPUScore += 1;
                rondes -= 1;
                ComputerScoreLabel.Content = Convert.ToString(CPUScore);
                Resultaat.Content = "Cpu Wint!";
            }
            else if (spelerKeuze == "Steen" && CPUKeuze == "Schaar")
            {
                playerScore += 1;
                SpelerScoreLabel.Content = Convert.ToString(playerScore);

                Resultaat.Content = "Speler Wint!";
            }
            else if (spelerKeuze == "Blad" && CPUKeuze == "Steen")
            {
                playerScore += 1;

                SpelerScoreLabel.Content = Convert.ToString(playerScore);
                Resultaat.Content = "Speler Wint!";
            }
            else if (spelerKeuze == "Schaar" && CPUKeuze == "Blad")
            {
                playerScore += 1;

                SpelerScoreLabel.Content = Convert.ToString(playerScore);
                Resultaat.Content = "Speler Wint!";
            }
            else if (spelerKeuze == "none")
            {
                SpelerView.Source = new BitmapImage(new Uri(@"Images\vraagTekenpic.png", UriKind.RelativeOrAbsolute));
                ComputerView.Source = new BitmapImage(new Uri(@"Images\vraagTekenpic.png", UriKind.RelativeOrAbsolute));
                Resultaat.Content = "Maak een keuze!";
            }
            else
            {
                Resultaat.Content = "Gelijkspel!";
            }

            startVolgendeRonde();

        }

        //Hier starten we de volgende ronde als de rondes niet op zijn!
        private void startVolgendeRonde()
        {
            Timer.IsEnabled = true;
            spelerKeuze = "none";

        }

    }
        
              
    
}
