using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGo.Model
{
    public class QuestionsModel
    {
        #region Global variables
        private const int TOTAL_QUESTIONS = 5;
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
                                               "What is capital of Gujarat",
                                               "Ahmedabad",
                                               "Surat",
                                               "Gandhinagar",
                                               "Baroda",
                                               3));

            Questionnaire.Add(GenerateQuestion(Questionnaire.Count + 1,
                                               "What is capital of Gujarat",
                                               "Ahmedabad",
                                               "Surat",
                                               "Gandhinagar",
                                               "Baroda",
                                               3));

            Questionnaire.Add(GenerateQuestion(Questionnaire.Count + 1,
                                               "What is capital of Gujarat",
                                               "Ahmedabad",
                                               "Surat",
                                               "Gandhinagar",
                                               "Baroda",
                                               3));

            Questionnaire.Add(GenerateQuestion(Questionnaire.Count + 1,
                                               "What is capital of Gujarat",
                                               "Ahmedabad",
                                               "Surat",
                                               "Gandhinagar",
                                               "Baroda",
                                               3));

            Questionnaire.Add(GenerateQuestion(Questionnaire.Count + 1,
                                               "What is capital of Gujarat",
                                               "Ahmedabad",
                                               "Surat",
                                               "Gandhinagar",
                                               "Baroda",
                                               3));

            Questionnaire.Add(GenerateQuestion(Questionnaire.Count + 1,
                                               "What is capital of Gujarat",
                                               "Ahmedabad",
                                               "Surat",
                                               "Gandhinagar",
                                               "Baroda",
                                               3));

            Questionnaire.Add(GenerateQuestion(Questionnaire.Count + 1,
                                               "What is capital of Gujarat",
                                               "Ahmedabad",
                                               "Surat",
                                               "Gandhinagar",
                                               "Baroda",
                                               3));

            Questionnaire.Add(GenerateQuestion(Questionnaire.Count + 1,
                                               "What is capital of Gujarat",
                                               "Ahmedabad",
                                               "Surat",
                                               "Gandhinagar",
                                               "Baroda",
                                               3));

            Questionnaire.Add(GenerateQuestion(Questionnaire.Count + 1,
                                               "What is capital of Bihar?",
                                               "Patna",
                                               "Gaya",
                                               "Bhagalbur",
                                               "Banka",
                                               1));
        }
        #endregion

        #region private functions
        private QuestionDetail GenerateQuestion(int id, string question, string option1, string option2, string option3, string option4, int correctOption)
        {
            QuestionDetail questionDetail = new QuestionDetail();
            questionDetail.QuestionID = id;
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
                randomNumber = random.Next(1, Questionnaire.Count);
                if (!randomQuestions.Any(question => question.QuestionID == randomNumber))
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
