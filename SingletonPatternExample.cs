using System;
using System.Linq;
using SingletonPatternExample.Objects;
using SingletonPatternExample.Util;

namespace SingletonPatternExample
{
    internal static class SingletonPatternExample
    {
        /*
        * The majority of this code is mocked or directly taken from the Derek Banas YouTube series in
        * an effort to teach myself and get familiar with these patterns.  None of this is meant to be
        * original content, and if you see this and wonder why it's in my repo, mostly it's for me, but
        * I'm happy that you're here and here's proof that I have at least heard of this particular
        * pattern!
        *
        * Author: Nicholas Larsen
        * Date: 2021/10/08
        */
        
        private static void Main()
        {
            // Here we see two separate instances of a singleton object getting created
            var newInstance = Singleton.GetInstance();
            var secondInstance = Singleton.GetInstance();
            Console.WriteLine("Instance Id: " + newInstance.GetHashCode());
            Console.WriteLine(newInstance.GetLetterList().PrintCommaSeparated());
            var playerOneTiles = newInstance.GetTiles(7);
            var playerTwoTiles = secondInstance.GetTiles(7);
            Console.WriteLine("player one: " + playerOneTiles.PrintCommaSeparated());
            Console.WriteLine("player two: " + playerTwoTiles.PrintCommaSeparated());
            // Even though we're calling different variables, both instances give us the same result,
            // this is due to the singleton pattern.  Because on the back end, it's only creating one of itself
            Console.WriteLine("Instance One: Remaining Tiles: " + newInstance.GetLetterList().PrintCommaSeparated());
            Console.WriteLine("Instance Two: Remaining Tiles: " + secondInstance.GetLetterList().PrintCommaSeparated());
        }
    }
}