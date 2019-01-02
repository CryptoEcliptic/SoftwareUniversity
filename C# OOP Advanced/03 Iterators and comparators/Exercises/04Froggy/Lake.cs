using System.Collections;
using System.Collections.Generic;

namespace _04Froggy
{
    public class Lake : IEnumerable<int>
    {
        private List<int> stones;
       
        public Lake(params int[] inputStones)
        {
            this.stones = new List<int>(inputStones);
        }

        //1, 2, 3, 4, 5, 6, 7, 8 - input values
        //0, 1, 2, 3, 4, 5, 6, 7 - indexes
       
        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < stones.Count; i += 2)
            {
                yield return this.stones[i];
                
            }
            int lastIndex = stones.Count - 1;
            if (lastIndex % 2 == 0)
            {
                for (int i = stones.Count - 2; i >= 0; i -= 2)
                {
                    yield return this.stones[i];
                }
            }

            if (lastIndex % 2 != 0)
            {
                for (int i = stones.Count - 1; i >= 0; i -= 2)
                {
                    yield return this.stones[i];
                }
            } 
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
