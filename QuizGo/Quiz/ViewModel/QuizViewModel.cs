using Model;
using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.ObjectModel;
using System.Linq;

namespace Quiz.ViewModel
{
    public class QuizViewModel : BindableBase
    {
        #region Constants
        private const int TOTAL_QUESTIONS = 10;
        #endregion

        #region Commands
        public DelegateCommand NextCommand { get; private set; }
        public DelegateCommand PreviousCommand { get; private set; }
        public DelegateCommand<string> SubmitCommand { get; private set; }

        public InteractionRequest<INotification> NotificationRequest { get; set; }
        private readonly IRegionManager regionManager;
        #endregion

        #region Global variable
        QuestionsModel questionsModel;

        #endregion

        #region Binding Variable
        private ObservableCollection<QuestionDetail> quizQuestions;
        public ObservableCollection<QuestionDetail> QuizQuestions
        {
            get { return quizQuestions ?? (quizQuestions = new ObservableCollection<QuestionDetail>()); }
            set { SetProperty(ref quizQuestions, value); }
        }

        private QuestionDetail currentQuestion;
        public QuestionDetail CurrentQuestion
        {
            get { return currentQuestion; }
            set { SetProperty(ref currentQuestion, value); }
        }

        private int currentQuestionNo;
        public int CurrentQuestionNo
        {
            get { return currentQuestionNo; }
            set { SetProperty(ref currentQuestionNo, value); }
        }

        private int totalQuestion;
        public int TotalQuestion
        {
            get { return totalQuestion; }
            set { SetProperty(ref totalQuestion, value); }
        }

        private int currentProgress;
        public int CurrentProgress
        {
            get { return this.currentProgress; }
            private set
            {
                if (this.currentProgress != value)
                {
                    this.currentProgress = value;
                    RaisePropertyChanged(nameof(CurrentProgress));
                }
            }
        }
        #endregion

        public QuizViewModel(IRegionManager regionManager)
        {
            NextCommand = new DelegateCommand(NextButton_Clicked, NextButton_CanExecute);
            PreviousCommand = new DelegateCommand(PreviousButton_Clicked, PreviousButton_CanExecute);
            SubmitCommand = new DelegateCommand<string>(SubmitButton_Clicked);
            NotificationRequest = new InteractionRequest<INotification>();
            this.regionManager = regionManager;
            LoadQestions();
        }

        #region Command Functions
        private bool NextButton_CanExecute()
        {
            return CurrentQuestionNo < QuizQuestions.Count;
        }

        private void NextButton_Clicked()
        {
            CurrentQuestionNo++;
            CurrentQuestion = QuizQuestions.FirstOrDefault(question => question.QuestionNo == CurrentQuestionNo);
            CurrentProgress = (CurrentQuestionNo * 10);
        }

        private bool PreviousButton_CanExecute()
        {
            //return CurrentQuestionNo > 1;
            return true;
        }

        private void PreviousButton_Clicked()
        {
            if (CurrentQuestionNo > 1)
            {
                CurrentQuestionNo--;
                CurrentQuestion = QuizQuestions.FirstOrDefault(question => question.QuestionNo == CurrentQuestionNo);
                CurrentProgress -=  10;
            }
        }

        private void SubmitButton_Clicked(string navigationPath)
        {
            float noOfCorrectQuestions = 0.0f;
            float percent = 0.0f;
            foreach (var item in QuizQuestions.Select(x => x.Options))
            {
                foreach (var options in item)
                {
                    if(options.IsSelected && options.IsCorrect)
                    {
                        noOfCorrectQuestions++;
                    }
                }
            }

            percent = (noOfCorrectQuestions / TOTAL_QUESTIONS) * 100;

            if (percent >= 70)
                NotificationRequest.Raise(new Notification { Content = "Congratulations! You have passed the exam with " + percent + "%", Title = "Result" });
            else
                NotificationRequest.Raise(new Notification { Content = string.Format("You have achieved {0} %, which is not enough to pass the exam. Please try again.", percent), Title = "Result" });

            if (navigationPath != null)
            {
                this.regionManager.RequestNavigate("MainView", navigationPath);
            }
        }
        #endregion

        #region Public Functions
        public void LoadQestions()
        {
            questionsModel = new QuestionsModel();
            foreach (QuestionDetail item in questionsModel.GetRandomQuestions())
            {
                QuizQuestions.Add(item);
            }

            TotalQuestion = QuizQuestions.Count;

            CurrentQuestion = QuizQuestions.First();
            CurrentQuestionNo = 1;
        }
        #endregion
    }
}
