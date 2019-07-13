using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGo.ViewModel
{
    public class MainViewModel
    {
        private static readonly Lazy<MainViewModel> instance = new Lazy<MainViewModel>(() => new MainViewModel());
        public static MainViewModel Instance { get { return instance.Value; } }

        private LoginViewModel loginVM;

        public LoginViewModel LoginVM
        {
            get { return loginVM??(loginVM = new LoginViewModel()); }
            set { loginVM = value; }
        }

        private QuestionsViewModel questionsVM;

        public QuestionsViewModel QuestionsVM
        {
            get { return questionsVM?? (questionsVM = new QuestionsViewModel()); }
            set { questionsVM = value; }
        }

        private MainViewModel()
        {

        }
    }
}
