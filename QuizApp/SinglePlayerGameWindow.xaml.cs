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

        public SinglePlayerGameWindow()
        {
            InitializeComponent();
            questions = Question.GetAllQuestions();
            SetupNewQuestion();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void SetupNewQuestion()
        {
            Question currentQuestion = questions.ElementAt(0);
            QuestionTextBlock.Text = currentQuestion.GetTitle();
            questions.Remove(questions.ElementAt(0));
        }
    }
}
