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
using System.Windows.Shapes;

namespace QuizApp
{
    /// <summary>
    /// Interaction logic for SinglePlayerGameWindow.xaml
    /// </summary>
    public partial class SinglePlayerGameWindow : Window
    {

        List<Question> questions;
        List<Button> buttons;
        Question currentQuestion;

        public SinglePlayerGameWindow()
        {
            InitializeComponent();

            questions = Question.GetAllQuestions();

            //Shuffle() is an extension method defined in ListUtils.cs
            questions.Shuffle();

            buttons = new List<Button>();

            //AddMultiple() is an extension method defined in ListUtils.cs
            buttons.AddMultiple(Btn1, Btn2, Btn3, Btn4);

            SetupNewQuestion();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(((sender as Button).Content as TextBlock).Text.Equals(currentQuestion.GetAnswers()[0]))
            {
                (sender as Button).Background = Brushes.Lime;
            }
            else
            {
                for (int i = 0; i < currentQuestion.GetAnswers().Length; i++)
                {
                    if((buttons.ElementAt(i).Content as TextBlock).Text.Equals(currentQuestion.GetAnswers()[0]))
                    {
                        buttons.ElementAt(i).Background = Brushes.Lime;
                    }
                    else
                    {
                        buttons.ElementAt(i).Background = Brushes.Red;
                    }
                }
            }
        }

        private void SetupNewQuestion()
        {
            currentQuestion = questions.ElementAt(0);

            QuestionTextBlock.Text = currentQuestion.GetTitle();

            buttons.Shuffle();

            for(int i = 0; i < currentQuestion.GetAnswers().Length; i++)
            {
                (buttons.ElementAt(i).Content as TextBlock).Text = currentQuestion.GetAnswers()[i];
            }

            questions.Remove(questions.ElementAt(0));
        }
    }
}
