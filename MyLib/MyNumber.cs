using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public class MyNumber
    {
        private readonly int Width;
        private int NextNumber;

        public MyNumber(int width, int startNumber = 1)
        {
            this.Width = width;
            this.NextNumber = startNumber;
        }

        public string Next() => Nexts(1).FirstOrDefault();
        public List<string> Nexts(int count)
        {
            var results = GetNextNumbers(this.NextNumber, count);
            this.NextNumber += results.Count;
            return results;
        }

        private List<string> GetNextNumbers(int startNumber, int count)
        {
            var width = this.Width;
            var results = new List<string>();
            var endNumber = startNumber + count - 1;

            int? flagNumber = null;
            #region Step1: 000~999
            var step1Count = (int)Math.Pow(10, width);
            for (var i = startNumber; i < step1Count; i++)
            {
                flagNumber = i;
                results.Add(flagNumber.ToString().PadLeft(width, '0'));
                if (flagNumber == endNumber)
                    return results;
            }
            //將 flagNumber 指定為下一個要執行的數字
            if (!flagNumber.HasValue)
                flagNumber = startNumber;
            else
                flagNumber++;
            #endregion

            #region Last Step: 0~9~A~Z
            if (width == 1 && flagNumber <= endNumber && flagNumber >= 10 && flagNumber < 36)
            {
                for (var i = flagNumber - 10; i < 26; i++)
                {
                    var c = (char)((int)'A' + i);
                    results.Add(c.ToString());
                    if (flagNumber == endNumber)
                        return results;
                    else
                        flagNumber++;
                }
            }
            #endregion

            return results;
        }
    }
}
