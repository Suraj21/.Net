using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class QuestionsModel
    {
        #region Global variables
        private const int TOTAL_QUESTIONS = 10;
        #endregion

        #region Public variables
        public List<QuestionDetail> Questionnaire { get; set; }
        #endregion

        #region Constructor
        public QuestionsModel()
        {
            Questionnaire = new List<QuestionDetail>();

            Questionnaire.Add(GenerateQuestion(Questionnaire.Count + 1,
                                               "Who is the founder of Haryanka Dynasty?",
                                               "Ajatshatru",
                                               "Harshvardhan",
                                               "Bimbisar",
                                               "Ghananand",
                                               3));

            Questionnaire.Add(GenerateQuestion(Questionnaire.Count + 1,
                                               "........... is the first woman to head a public sector bank.",
                                               "Arundhati Bhattacharya",
                                               "Shikha Sharma",
                                               "Chanda Kochar",
                                               "Usha Ananthasubramanyan",
                                               1));

            Questionnaire.Add(GenerateQuestion(Questionnaire.Count + 1,
                                               "What is capital of Gujarat?",
                                               "Ahmedabad",
                                               "Surat",
                                               "Gandhinagar",
                                               "Baroda",
                                               3));

            Questionnaire.Add(GenerateQuestion(Questionnaire.Count + 1,
                                               "What is capital of MP?",
                                               "Guna",
                                               "Indore",
                                               "Bhopal",
                                               "Jabalpur",
                                               3));

            Questionnaire.Add(GenerateQuestion(Questionnaire.Count + 1,
                                               "What is capital of Maharashtra?",
                                               "Mumbai",
                                               "Pune",
                                               "Nashik",
                                               "Nagpur",
                                               1));

            Questionnaire.Add(GenerateQuestion(Questionnaire.Count + 1,
                                               "WWW stands for",
                                               "World Whole Web",
                                               "Wide World Web",
                                               "Web World Wide",
                                               "World Wide Web",
                                               4));

            Questionnaire.Add(GenerateQuestion(Questionnaire.Count + 1,
                                               "Where is RAM located?",
                                               "Expansion Board",
                                               "External Drive",
                                               "Mother Board",
                                               "All of above",
                                               3));

            Questionnaire.Add(GenerateQuestion(Questionnaire.Count + 1,
                                               "If a computer has more than one processor then it is known as ?",
                                               "Uniprocess",
                                               "Multiprocessor",
                                               "Multithreaded",
                                               "Multiprogramming",
                                               2));

            Questionnaire.Add(GenerateQuestion(Questionnaire.Count + 1,
                                               "If a computer provides database services to other, then it will be known as ?",
                                               "Web server",
                                               "Application server",
                                               "Database server",
                                               "FTP server",
                                               3));

            Questionnaire.Add(GenerateQuestion(Questionnaire.Count + 1,
                                               "Full form of URL is ?",
                                               "Uniform Resource Locator",
                                               "Uniform Resource Link",
                                               "Uniform Registered Link",
                                               "Unified Resource Link",
                                               1));

            Questionnaire.Add(GenerateQuestion(Questionnaire.Count + 1,
                                               " Which level language is Assembly Language ?",
                                               "high-level programming language",
                                               "medium-level programming language",
                                               "low-level programming language",
                                               "machine language",
                                               3));

            Questionnaire.Add(GenerateQuestion(Questionnaire.Count + 1,
                                               "What is capital of India?",
                                               "Delhi",
                                               "Mumbai",
                                               "Banglore",
                                               "Chennai",
                                               1));

            Questionnaire.Add(GenerateQuestion(Questionnaire.Count + 1,
                                               "Which of following is used in RAM ?",
                                               "Conductor",
                                               "Semi Conductor",
                                               "Vaccum Tubes",
                                               "Transistor",
                                               2));
            Questionnaire.Add(GenerateQuestion(Questionnaire.Count + 1,
                                               "What is full form of ALU ?",
                                               "Arithmetic logic unit",
                                               "Allowed logic unit",
                                               "Ascii logic unit",
                                               "Arithmetic least unit",
                                               1));
            Questionnaire.Add(GenerateQuestion(Questionnaire.Count + 1,
                                               "Who was the Founder of Bluetooth ?",
                                               "Ericson",
                                               "Martin Cooper",
                                               "Steve Jobs",
                                               "Apple",
                                               1));
        }
        #endregion

        #region private functions
        private QuestionDetail GenerateQuestion(int id, string question, string option1, string option2, string option3, string option4, int correctOption)
        {
            QuestionDetail questionDetail = new QuestionDetail();
            questionDetail.QuestionID = id; //Unique Id of the questions
            questionDetail.Question = question;
            List<Options> options = new List<Options>();
            options.Add(new Options()
            {
                OptionID = 1,
                Option = option1,
                IsCorrect = correctOption == 1
            });
            options.Add(new Options()
            {
                OptionID = 2,
                Option = option2,
                IsCorrect = correctOption == 2
            });
            options.Add(new Options()
            {
                OptionID = 3,
                Option = option3,
                IsCorrect = correctOption == 3
            });
            options.Add(new Options()
            {
                OptionID = 4,
                Option = option4,
                IsCorrect = correctOption == 4
            });
            questionDetail.Options = new List<Options>();
            questionDetail.Options.AddRange(options);

            return questionDetail;
        }
        #endregion

        #region Public Functions
        public List<QuestionDetail> GetRandomQuestions()
        {
            List<QuestionDetail> randomQuestions = new List<QuestionDetail>();
            int randomNumber = 0;
            Random random = new Random();
            QuestionDetail questionDetail;

            while (randomQuestions.Count < TOTAL_QUESTIONS)
            {
                randomNumber = random.Next(1, Questionnaire.Count);//Generate a random Question no from the Questionnaire list
                if (!randomQuestions.Any(question => question.QuestionID == randomNumber)) // if the question is not present in the random questions then add to it
                {
                    questionDetail = Questionnaire.FirstOrDefault(question => question.QuestionID == randomNumber);
                    questionDetail.QuestionNo = randomQuestions.Count + 1;
                    randomQuestions.Add(questionDetail);
                }
            }

            return randomQuestions;
        }
        #endregion
    }
}
