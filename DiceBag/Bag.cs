using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kingmaker;


namespace WrathLessRandom.DiceBag
{
    public class Bag
    {
        public int DiceType;
        public int CutOff;
        public List<int> Dice;
        public List<int> DiceList;

        private Random rng = new Random();
        private int index;

        public Bag(List<int> diceList, int cutoff)
        {
            DiceType = diceList.Count;
            CutOff = cutoff;
            DiceList = diceList;
            Dice = new List<int>();
            Refill();
        }
        public void Refill()
        {
            index = 0;
            Dice.Clear();
            for  (int i = 0; i < DiceList.Count; i++)
                for (int j = 0; j < DiceList[i]; j++)
                    Dice.Add(i+1);
            Dice.Shuffle(rng);
        }

        public int Roll()
        {
            if (index >= Dice.Count - CutOff)
                Refill();
            return (Dice[index++]);
        }
    }

    internal static class Extensions
    {
        public static void Shuffle<T>(this List<T> list, Random rng)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
