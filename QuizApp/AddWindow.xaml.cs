using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuizApp
{
    public partial class AddWindow : Window
    {
        public AddWindow()
        {
            InitializeComponent();
        }
        public AddWindow(Question question)
        {
            InitializeComponent();
            Question_TextBox.Text = question.GetTitle();
            A_TextBox.Text = question.GetAnswers()[0];
            B_TextBox.Text = question.GetAnswers()[1];
            C_TextBox.Text = question.GetAnswers()[2];
            D_TextBox.Text = question.GetAnswers()[3];
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(String.IsNullOrEmpty(Question_TextBox.Text) || String.IsNullOrEmpty(A_TextBox.Text) || String.IsNullOrEmpty(B_TextBox.Text) || String.IsNullOrEmpty(C_TextBox.Text) || String.IsNullOrEmpty(D_TextBox.Text))
            {
                MessageBox.Show("Every Question must have a title and 4 possible answers!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Question question = new Question(Question_TextBox.Text, A_TextBox.Text, B_TextBox.Text, C_TextBox.Text, D_TextBox.Text);
            question.Save();
            MessageBox.Show("Successfully saved your new question", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            new CreationHub().Show();
            Close();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if((sender as TextBox).Text.Contains("~"))
            {
                (sender as TextBox).Text = (sender as TextBox).Text.Replace("~", "");
                MessageBox.Show("Illegal character: '~'", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
