using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace N20
{
    internal class BubbleSort
    {
        public int[] bubbleSort(ref int[] members)
        {
            for (int i = 0; i < members.Length-i; i++)
            {
                var swapped = false;
                for (int j = 0; j < members.Length - i - 1; j++)
                {
                    if (members[j] > members[j + 1])
                    {
                        var temp = members[j];
                        members[j]= members[j + 1];
                        members[j+1] = temp;
                        swapped = true;
                    }
                }
                if (swapped == false)
                {
                    break;
                }
            }
            return members;
        }
    }
}
