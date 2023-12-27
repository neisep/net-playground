using System.Diagnostics;
using System.Linq;

namespace MiscTests.codeToTest
{
    public class ValueInBetween
    {
        private readonly int _from;
        private readonly int _to;

        public ValueInBetween(int from, int to)
        {
            _from = from;
            _to = to;
        }

        //This will actually not work, reason for that is because the second parameter is a count, and if you write 10,100 and it starts counting from 0 it means that 101 is OK.
        //it is also very slow, should not be used at all, but i wanted too test it out... but makes sense why it is not a good idea to use it.            
        public bool ValidateWithLinq(int x)
        {
            return Enumerable.Range(_from, _to).Contains(x) || x == 200;
        }

        public bool ValidateWithouthLinq(int x)
        {
            return x >= _from && x <= _to || x == 200;
        }

        //This is another way todo the same thing but different and not so good.
        public bool ValidateWithCustomClass(int x)
        {
            return Range.Value(_from, _to).Contains(x) || x == 200;
        }
    }

    public class Range
    {
        public static int[] Value(int from, int to)
        {
            var maxValue = to - from;
            var array = new int[maxValue + 1];
            for (int i = 0; i <= maxValue; i ++)
            {
                array[i] = from+i;
            }

            return array;
        }
    }
}
