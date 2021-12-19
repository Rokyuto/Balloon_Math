using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

using System.Windows.Threading; // import the threading namespace first, this way we can use the dispatcher time inside of the c# script

namespace Balloon_Math
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer gameTimer = new DispatcherTimer(); // create a new instance of the dispatcher time called gameTimer
        Random MyRandom = new Random(); //Random Instance

        float Num1, Num2;
        float Result;
        int Result_int;
        int Score;
        char[] symbols = new char[] { '+', '-', '*', '/' };
        int chosen_symbol;
        int Min_Num = 0, Max_Num = 10;
        // Declare buttons array
        ArrayList Buttons_ArrList = new ArrayList(); //Create ArrayList with Game Buttons

        public MainWindow()
        {
            InitializeComponent();

            myCanvas.Focus(); // set the main focus of the program to the my canvas element, with this line it wont register the keyboard events

            StartGame(); // run the start game function
        }

        private void StartGame()
        {
            Score_Label.Content = "Score: " + Score;
            //Add Game Buttons to ArrayList
            Buttons_ArrList.Add(Button1);
            Buttons_ArrList.Add(Button2);
            Buttons_ArrList.Add(Button3);

            //Call Functions
            Generate();
            Equation_Calc();
            Buttons_Content();
        }

        //Generate and Display Math Equation
        private void Generate()
        {
            Num1 = MyRandom.Next(Min_Num, Max_Num); //Generate Number1 [ 0 - 10 ]
            Num2 = MyRandom.Next(Min_Num, Max_Num); //Generate Number2 [ 0 - 10 ]
            chosen_symbol = MyRandom.Next(0, symbols.Length); //Generate Symbol

            Num1_Label.Content = Num1; //Display Number1
            Num2_Label.Content = Num2; //Display Number2
            Symbol_Label.Content = symbols[chosen_symbol]; //Display Symbol
        }

        //Calculate Equation
        private void Equation_Calc()
        {
            switch (chosen_symbol)
            {
                case 0: //Chosen Symbol is + 
                    Result = Num1 + Num2;
                    break;
                case 1: //Chosen Symbol is - 
                    Result = Num1 - Num2;
                    break;
                case 2: //Chosen Symbol is *
                    Result = Num1 * Num2;
                    break;
                case 3: //Chosen Symbol is /
                    Result = Num1 / Num2;
                    Result_int = (int)Result;
                    break;
            }
        }

        //Asign Buttons Values
        private void Buttons_Content()
        {
            //Asign Random Values to Buttons
            float Button1_Value = Result;
            int Button2_Value = MyRandom.Next(0, 101);
            int Button3_Value = MyRandom.Next(0, 101);

            //Convert Buttons' Values to Float for the Check
            Button1.Content = Button1_Value;
            Button2.Content = (float)Button2_Value;
            Button3.Content = (float)Button3_Value;

        }

        //On Button1 Click 
        private async void Button1_Click(object sender, RoutedEventArgs e)
        {
            if ((float)Button1.Content == (float)Result) //If Button1 Value is Corect Equation Answer
            {
                Button1.Background = Brushes.LightGreen;
                Button1.BorderBrush = new SolidColorBrush(Colors.DarkGreen);

                await Task.Delay(3000); // 3 seconds waiting before go to next level

                UpadateScore();
            }
            else //If Wrong
            {
                Button1.Background = Brushes.IndianRed;
                Button1.BorderBrush = new SolidColorBrush(Colors.DarkRed);
                Button1.Opacity = 0.75;
            }
        }

        //On Button2 Click 
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            if ((float)Button2.Content == (float)Result) //If Button2 Value is Corect Equation Answer
            {
                UpadateScore();
                Button2.Background = Brushes.LightGreen;
                Button2.BorderBrush = new SolidColorBrush(Colors.DarkGreen);
            }
            else //If Wrong
            {
                Button2.Background = Brushes.IndianRed;
                Button2.BorderBrush = new SolidColorBrush(Colors.DarkRed);
                Button2.Opacity = 0.75;
            }
        }

        //On Button3 Click 
        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            if ((float)Button3.Content == (float)Result) //If Button3 Value is Corect Equation Answer
            {
                UpadateScore();
                Button3.Background = Brushes.LightGreen;
                Button3.BorderBrush = new SolidColorBrush(Colors.DarkGreen);
            }
            else //If Wrong
            {
                Button3.Background = Brushes.IndianRed;
                Button3.BorderBrush = new SolidColorBrush(Colors.DarkRed);
                Button3.Opacity = 0.75;
            }
        }

        //Update Score
        private void UpadateScore()
        {
            Score += 1;
            Score_Label.Content = "Score: " + Score;
            Generate(); //Generate new Equation
            Equation_Calc(); //Calcuete the new Equation
            Buttons_Content(); //Generate new Buttons Values
            Clear_Buttons_Style(); //Call Clear Buttons Style Func
        }

        //Clear Butoons Style adter finishing Level
        private void Clear_Buttons_Style()
        {
            Button1.Background = Brushes.LightGray;
            Button1.BorderBrush = new SolidColorBrush(Colors.Gray);
            Button1.Opacity = 1;

            Button2.Background = Brushes.LightGray;
            Button2.BorderBrush = new SolidColorBrush(Colors.Gray);
            Button2.Opacity = 1;

            Button3.Background = Brushes.LightGray;
            Button3.BorderBrush = new SolidColorBrush(Colors.Gray);
            Button3.Opacity = 1;
        }
    }
}