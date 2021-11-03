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
using System.Media;


namespace BladSteenSchaarV3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        int spelerCounterSchaar = 0;
        int spelerCounterBlad = 0;
        int spelerCounterSteen = 0;

        int cpuCounterSchaar = 0;
        int cpuCounterBlad = 0;
        int cpuCounterSteen = 0;

        private int timePerRound = 5;
        private DispatcherTimer Timer;

        bool gameOver = false;
     
        int randomNumber = 0;
        Random rnd = new Random();
       
        string[] cpuKeuzeLijst = { "Blad", "Steen", "Schaar", "Steen", "Schaar", "Blad", "Blad", "Schaar", "Steen" };
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
            
            //Stoppen van de timer als het game over is.
            if (gameOver == true)
            {
                Timer.Stop();
                
            }

            //Als de timer <=4 is zetten we de tekst kleur naar rood.
            if (timePerRound <= 4)
            {
                
                ComputerView.Source = new BitmapImage(new Uri(@"Images\vraagTekenpic.png", UriKind.RelativeOrAbsolute));
            }

            //als de timer kleiner is dan 1 dan laten we de computer een keuze maken en veranderen we de afbeeldingen.
            if (timePerRound < 1)
            {
                
                Schaar.IsEnabled = true;
                Steen.IsEnabled = true;
                Blad.IsEnabled = true;


                Timer.IsEnabled = false;
                timePerRound = 6;

                //De Computer een willekeurig keuzen laten maken!
                randomNumber = rnd.Next(0, cpuKeuzeLijst.Length);
                CPUKeuze = cpuKeuzeLijst[randomNumber];


                if (CPUKeuze == "Steen")
                {
                    cpuCounterSteen += 1;
                    cpuLabelCounterSteen.Content = "Steen: " + cpuCounterSteen;
                    ComputerView.Source = new BitmapImage(new Uri(@"Images\steenpic.png", UriKind.RelativeOrAbsolute));
                }
                else if (CPUKeuze == "Schaar")
                {
                    cpuCounterSchaar += 1;
                    cpuLabelCounterSchaar.Content = "Schaar: " + cpuCounterSchaar;
                    ComputerView.Source = new BitmapImage(new Uri(@"Images\schaarpic.png", UriKind.RelativeOrAbsolute));
                }
                else if (CPUKeuze == "Blad")
                {
                    cpuCounterBlad += 1;
                    cpuLabelCounterBlad.Content = "Blad: " + cpuCounterBlad;
                    ComputerView.Source = new BitmapImage(new Uri(@"Images\Blad.png", UriKind.RelativeOrAbsolute));
                }

                //Hier checken we de spelregels als de rondes niet op zijn!
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
            Schaar.IsEnabled = false;
            Steen.IsEnabled = false;
            
            Blad.BorderThickness = new Thickness(4);
            Steen.BorderThickness = new Thickness(1);
            Schaar.BorderThickness = new Thickness(1);
            SpelerView.Source = new BitmapImage(new Uri(@"Images\Blad.png", UriKind.RelativeOrAbsolute));
            spelerKeuze = "Blad";

            spelerCounterBlad += 1;
            spelerLabelCounterBlad.Content = "Blad: " + spelerCounterBlad;            

        }

        //Hier wordt de Blad Button grijs wanneer je erover heen gaat.
        private void Blad_MouseEnter(object sender, MouseEventArgs e)
        {
            Bladpic.Source = new BitmapImage(new Uri(@"Images\BladGrijs.png", UriKind.RelativeOrAbsolute));
        }

        //Hier wordt de Button teruggezet op zijn originele kleur.
        private void Blad_MouseLeave(object sender, MouseEventArgs e)
        {
            Bladpic.Source = new BitmapImage(new Uri(@"Images\Blad.png", UriKind.RelativeOrAbsolute));
        }

        //Steen Button 
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Schaar.IsEnabled = false;           
            Blad.IsEnabled = false;

            Steen.BorderThickness = new Thickness(4);
            Blad.BorderThickness = new Thickness(1);
            Schaar.BorderThickness = new Thickness(1);
            SpelerView.Source = new BitmapImage(new Uri(@"Images\steenpic.png", UriKind.RelativeOrAbsolute));
            spelerKeuze = "Steen";

            spelerCounterSteen += 1;
            spelerLabelCounterSteen.Content = "Steen: " + spelerCounterSteen;

        }

        //Hier wordt de Steen Button grijs wanneer je erover heen gaat.
        private void Steen_MouseEnter(object sender, MouseEventArgs e)
        {
            Steenpic.Source = new BitmapImage(new Uri(@"Images\steenpicGrijs.png", UriKind.RelativeOrAbsolute));
        }

        //Hier wordt de Button teruggezet op zijn originele kleur.
        private void Steen_MouseLeave(object sender, MouseEventArgs e)
        {
            Steenpic.Source = new BitmapImage(new Uri(@"Images\steenpic.png", UriKind.RelativeOrAbsolute));
        }

        //Schaar Button
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Steen.IsEnabled = false;
            Blad.IsEnabled = false;

            Schaar.BorderThickness = new Thickness(4);
            Steen.BorderThickness = new Thickness(1);
            Blad.BorderThickness = new Thickness(1);
            SpelerView.Source = new BitmapImage(new Uri(@"Images\schaarpic.png", UriKind.RelativeOrAbsolute));
            spelerKeuze = "Schaar";

            spelerCounterSchaar += 1;           
            spelerLabelCounterSchaar.Content = "Schaar: " + spelerCounterSchaar;

        }

        //Hier wordt de Schaar Button grijs wanneer je erover heen gaat.
        private void Schaar_MouseEnter(object sender, MouseEventArgs e)
        {
            Schaarpic.Source = new BitmapImage(new Uri(@"Images\schaarpicGrijs.png", UriKind.RelativeOrAbsolute));
        }

        //Hier wordt de Button teruggezet op zijn originele kleur.
        private void Schaar_MouseLeave(object sender, MouseEventArgs e)
        {
            Schaarpic.Source = new BitmapImage(new Uri(@"Images\schaarpic.png", UriKind.RelativeOrAbsolute));
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

            cpuCounterSteen = 0;
            cpuLabelCounterSteen.Content = "Steen: " + cpuCounterSteen;
            cpuCounterSchaar = 0;
            cpuLabelCounterSchaar.Content = "Schaar: " + cpuCounterSchaar;
            cpuCounterBlad = 0;
            cpuLabelCounterBlad.Content = "Blad: " + cpuCounterBlad;

            spelerCounterBlad = 0;
            spelerLabelCounterBlad.Content = "Blad: " + spelerCounterBlad;
            spelerCounterSteen = 0;
            spelerLabelCounterSteen.Content = "Steen: " + spelerCounterSteen;
            spelerCounterSchaar = 0;
            spelerLabelCounterSchaar.Content = "Schaar: " + spelerCounterSchaar;

        }


        //Hier kijken we wie er wint en of dat de speler/computer al geen 10 punten heeft.
        private void spelRegels()
        {
            //als de speler een score heeft van 10, dan is het game over.
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

            //als de computer een score heeft van 10, dan is het game over.
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
                CPUKeuze = "none";
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
