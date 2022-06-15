using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingChecker
{
    public class ManagerAnswers
    {
        public static List<string> Answers { get; set; }
        static ManagerAnswers()
        {
            Answers = new List<string>();
        }
    }
}
