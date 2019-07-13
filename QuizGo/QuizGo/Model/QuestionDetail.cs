using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGo.Model
{
    public class QuestionDetail
    {
        public int QuestionNo { get; set; }

        public int QuestionID { get; set; }

        public string Question { get; set; }

        public List<Options> Options { get; set; }

        public int UserAnswer { get; set; }
    }

    public class Options
    {
        public int OptionID { get; set; }

        public string Option { get; set; }

        public bool IsCorrect { get; set; }

        public bool IsSelected { get; set; }
    }
}
