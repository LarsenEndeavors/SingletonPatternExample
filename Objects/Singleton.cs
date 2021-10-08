using System.Collections.Generic;
using System.Linq;
using SingletonPatternExample.Util;

namespace SingletonPatternExample.Objects
{
    public class Singleton
    {
        private static Singleton _firstInstance;

        private static readonly string[] ScrabbleLetters = {"a", "a", "a", "a", "a", "a", "a", "a", "a",
            "b", "b", "c", "c", "d", "d", "d", "d", "e", "e", "e", "e", "e",
            "e", "e", "e", "e", "e", "e", "e", "f", "f", "g", "g", "g", "h",
            "h", "i", "i", "i", "i", "i", "i", "i", "i", "i", "j", "k", "l",
            "l", "l", "l", "m", "m", "n", "n", "n", "n", "n", "n", "o", "o",
            "o", "o", "o", "o", "o", "o", "p", "p", "q", "r", "r", "r", "r",
            "r", "r", "s", "s", "s", "s", "t", "t", "t", "t", "t", "t", "u",
            "u", "u", "u", "v", "v", "w", "w", "x", "y", "y", "z"};

        private LinkedList<string> _letterList = new LinkedList<string>(ScrabbleLetters.ToList());


        private Singleton()
        {
            
        }

        public static Singleton GetInstance()
        {
            if (_firstInstance == null)
            {
                _firstInstance = new Singleton();
                _firstInstance._letterList = _firstInstance._letterList.Shuffle();
            }
            
            return _firstInstance;
        }

        public LinkedList<string> GetLetterList()
        {
            return _firstInstance._letterList;
        }

        public LinkedList<string> GetTiles(int quantity)
        {
            var tilesToSend = new LinkedList<string>();

            for (var i = 0; i <= quantity; i++)
            {
                if (_firstInstance._letterList.First != null)
                {
                    tilesToSend.AddLast(_firstInstance._letterList.First.Value);
                    _firstInstance._letterList.RemoveFirst();
                }
            }

            return tilesToSend;
        }
    }
}