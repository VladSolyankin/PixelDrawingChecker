using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingChecker
{
    public class MarkedList
    {
        public static List<string> isMarked { get; set; }
        static MarkedList()
        {
            isMarked = new List<string>();
            for (int i = 0; i < 16; i++) isMarked.Add("0000");
        }
    }
}
