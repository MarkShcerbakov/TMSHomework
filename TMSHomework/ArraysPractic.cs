using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSHomework
{
    internal class ArraysPractic
    {
        public enum Suits
        {
            Wands,
            Coins,
            Cups,
            Swords
        }

        public static int[] GetFirstEvenNumbers(int count) => new int[count].Select((_, i) => (i + 1) * 2).ToArray();

        public static int MaxIndex(double[] array) => array.Length == 0 ? -1 : array.Select((x, i) => (x, i)).MaxBy(t => t.x).i;

        public static int GetElementCount(int[] items, int itemToCount) => Array.FindAll(items, m => m == itemToCount).Length;

        public static bool ContainsAtIndex(int[] array, int[] subArray, int i) => array[i..(subArray.Length + i)].SequenceEqual(subArray);

        public static string GetSuit(Suits suit) => new[] { "посохов", "монет", "кубков", "мечей" }[(int)suit];

        public static bool CheckFirstElement(int[] array) => array?.FirstOrDefault(-1) == 0;

        public static int[] GetPoweredArray(int[] arr, int power) => arr.Select(x => (int)Math.Pow(x, power)).ToArray();
    }
}
