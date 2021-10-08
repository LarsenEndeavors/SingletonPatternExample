using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SingletonPatternExample.Util
{
    public static class LinkedListHelper
    {
        public static LinkedList<T> Shuffle<T>(this LinkedList<T> linkedList)
        {
            var random = new Random();
            var unlinkedList = linkedList.ToList();
            var shuffledList = new List<T>();

            for (var i = unlinkedList.Count - 1; i >= 0; i--)
            {
                var j = random.Next(0, i);
                var insertIndex = shuffledList.Count == 0 ? 0 : random.Next(0,shuffledList.Count - 1);
                shuffledList.Insert(insertIndex, unlinkedList[j]);
                unlinkedList.Remove(unlinkedList[j]);
            }

            if (TestLength(linkedList, shuffledList))
            {
                return new LinkedList<T>(shuffledList);
            }

            throw new Exception("The length of the new list does not match the length of the input list.");
        }

        public static string PrintCommaSeparated<T>(this IEnumerable<T> linkedList)
        {
            var toStringedList = linkedList.Select(link => link.ToString()).ToList();
            return string.Join(',', toStringedList);
        }

        private static bool TestLength(ICollection linkedList, ICollection shuffledList)
        {
            return linkedList.Count == shuffledList.Count;
        }
    }
}