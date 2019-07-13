using QuizGo.Common;
using QuizGo.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuizGo.ViewModel
{
    public class QuestionsViewModel : INotifyPropertyChanged
    {
        #region Commands
        private DelegateCommand NextDelegateCommand;
        public ICommand NextCommand
        {
            get { return NextDelegateCommand ?? (NextDelegateCommand = new DelegateCommand(NextButton_Clicked, NextButton_CanExecute)); }
        }

        private DelegateCommand PreviousDelegateCommand;
        public ICommand PreviousCommand
        {
            get { return PreviousDelegateCommand ?? (PreviousDelegateCommand = new DelegateCommand(PreviousButton_Clicked, PreviousButton_CanExecute)); }
        }
        #endregion

        #region Global variable
        QuestionsModel questionsModel;
        #endregion

        #region Binding Variable
        private ObservableCollection<QuestionDetail> quizQuestions;
        public ObservableCollection<QuestionDetail> QuizQuestions
        {
            get { return quizQuestions ?? (quizQuestions = new ObservableCollection<QuestionDetail>()); }
            set { quizQuestions = value; NotifyPropertyChanged(); }
        }

        private QuestionDetail currentQuestion;
        public QuestionDetail CurrentQuestion
        {
            get { return currentQuestion; }
            set { currentQuestion = value; NotifyPropertyChanged(); }
        }

        private int currentQuestionNo;

        public int CurrentQuestionNo
        {
            get { return currentQuestionNo; }
            set { currentQuestionNo = value; NotifyPropertyChanged(); }
        }

        private int totalQuestion;

        public int TotalQuestion
        {
            get { return totalQuestion; }
            set { totalQuestion = value; NotifyPropertyChanged(); }
        }
        #endregion

        #region Constructor
        public QuestionsViewModel()
        {
            questionsModel = new QuestionsModel();

            //TODO: Call below function once questios view is laoded.
            LoadQestions();
        }
        #endregion

        #region Command Functions
        private bool NextButton_CanExecute()
        {
            return CurrentQuestionNo < QuizQuestions.Count;
        }

        private void NextButton_Clicked()
        {
            CurrentQuestionNo++;
            CurrentQuestion = QuizQuestions.FirstOrDefault(question => question.QuestionNo == CurrentQuestionNo);
        }

        private bool PreviousButton_CanExecute()
        {
            return CurrentQuestionNo > 1;
        }

        private void PreviousButton_Clicked()
        {
            CurrentQuestionNo--;
            CurrentQuestion = QuizQuestions.FirstOrDefault(question => question.QuestionNo == CurrentQuestionNo);
        }
        #endregion

        #region Public Functions
        public void LoadQestions()
        {
            foreach (QuestionDetail item in questionsModel.GetRandomQuestions())
            {
                QuizQuestions.Add(item);
            }

            TotalQuestion = QuizQuestions.Count;

            CurrentQuestion = QuizQuestions.First();
            CurrentQuestionNo = 1;
        } 
        #endregion

        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
