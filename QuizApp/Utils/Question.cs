using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace QuizApp
{
    public class Question
    {
        string question;
        string[] answers = new string[4];

        public Question(string question, string a, string b, string c, string d)
        {
            this.question = question;
            answers[0] = a;
            answers[1] = b;
            answers[2] = c;
            answers[3] = d;
        }

        public void Save()
        {
            if(!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Quizgame"))
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Quizgame");
            }

            if(!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Quizgame\Questions.quiz"))
            {
                File.Create(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Quizgame\Questions.quiz");
            }

            List<string> lines = File.ReadAllLines(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Quizgame\Questions.quiz").ToList();
            lines.Add(question + "~" + answers[0] + "~" + answers[1] + "~" + answers[2] + "~" + answers[3]);

            File.WriteAllLines(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Quizgame\Questions.quiz", lines);
        }

        public static List<Question> GetAllQuestions()
        {
            List<Question> questions = new List<Question>();
            foreach (String line in File.ReadAllLines(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Quizgame\Questions.quiz"))
            {
                string[] questionParts = line.Split('~');
                Question question = new Question(questionParts[0], questionParts[1], questionParts[2], questionParts[3], questionParts[4]);
                questions.Add(question);
            }
            return questions;
        }

        public static void DeleteQuestion(string questionTitle)
        {
            List<Question> questions = GetAllQuestions();
            List<string> lines = new List<string>();
            foreach (Question question in questions)
            {
                if (question.GetTitle().Equals(questionTitle))
                {
                    continue;
                }
                lines.Add(questionTitle + "~" + question.GetAnswers()[0] + "~" + question.GetAnswers()[1] + "~" + question.GetAnswers()[2] + "~" + question.GetAnswers()[3]);
            }

            File.WriteAllLines(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Quizgame\Questions.quiz", lines);
        }

        public static Question GetQuestionFromTitle(string title)
        {
            foreach(Question question in GetAllQuestions())
            {
                if (question.GetTitle().Equals(title))
                {
                    return question;
                }
            }
            return null;
        }

        public string GetTitle()
        {
            return question;
        }

        public string[] GetAnswers()
        {
            return answers;
        }

    }
}
