using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingChecker
{
    public class RowsList
    {
        public static bool[,] Rows { get; set; }
        static RowsList()
        {
            Rows = new bool[16, 16];
        }
        public static string StringToBinary(bool[,] rows, int i)
        {
            string binaryString = "";
            for (int j = 0; i < 16; i++)
            {
                binaryString += rows[i, j] ? 1 : 0;
            }

            return binaryString;
        }
    }
}
