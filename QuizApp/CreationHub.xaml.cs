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
    /// Interaction logic for CreationHub.xaml
    /// </summary>
    public partial class CreationHub : Window
    {
        public CreationHub()
        {
            InitializeComponent();
            foreach(Question question in Question.GetAllQuestions())
            {
                QuestionView.Items.Add(question.GetTitle());
            }
        }

        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            new AddWindow().Show();
            Close();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (QuestionView.SelectedItem != null)
            {
                Question question = Question.GetQuestionFromTitle(QuestionView.SelectedItem.ToString());
                new AddWindow(question).Show();
                Question.DeleteQuestion(question.GetTitle());
                Close();
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if(QuestionView.SelectedItem != null)
            {
                MessageBoxResult result = MessageBox.Show("Do you really want to delete this question ? \nYou cannot undo this action!", "Deleting question", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    Question.DeleteQuestion(QuestionView.SelectedItem.ToString());
                    QuestionView.Items.Remove(QuestionView.SelectedItem);
                }
            }
        }
    }
}
