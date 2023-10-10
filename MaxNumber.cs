using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class MaxNumber
    {
        public static int? GetMaxNumber(List<int> numbers, int index = 0, int? max = null)
        {
            if (index >= numbers.Count)
            {
                return max;
            }
            if (max == null)
            {
                max = numbers[index];
            }
            else if(max < numbers[index])
            {
                max = numbers[index];
            }
            return GetMaxNumber(numbers, ++index, max);   
        }
    }
}
