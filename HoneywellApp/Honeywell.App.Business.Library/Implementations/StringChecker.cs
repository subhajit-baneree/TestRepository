using Honeywell.App.Business.Library.Helpers;
using Honeywell.App.Business.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Honeywell.App.Business.Library.Implementations
{
    public class StringChecker : IStringChecker
    {
        public string GetModifiedString(string input)
        {            
            var wordListInInput = input.Split(' ');
            var stringWithoutSpecialChars = Extensions.RemoveSpecialCharacters(input);
            var wordsList = stringWithoutSpecialChars.Split(' ').ToList();
            var checkerDictionary = new Dictionary<string, int>();
            foreach (var item in wordsList) 
            {
                if (checkerDictionary.ContainsKey(item))
                {
                    checkerDictionary[item]++;
                }
                else 
                {
                    checkerDictionary.Add(item, 1);
                }
            }
            var output = string.Empty;

            var listOfDuplicateWords = new List<string>();

            foreach(var pair in checkerDictionary) 
            {
                if (pair.Key != string.Empty && pair.Value != 1) 
                {
                    listOfDuplicateWords.Add(pair.Key);
                }
            }

            var common = wordsList.Intersect(listOfDuplicateWords);
            wordsList.RemoveAll(m=>common.Contains(m));

            var listOfWordForOuptut = new List<string>();

            foreach (var item in wordListInInput) 
            {
                foreach (var singleWord in wordsList) 
                {
                    if (singleWord.Equals(item) || singleWord.Equals(Extensions.RemoveSpecialCharacters(item))) 
                    {
                        listOfWordForOuptut.Add(item);
                    }
                }
            }

            foreach (var word in listOfWordForOuptut) 
            {
                output += " " + word;
            }

            Logger.Log(output);
            return output.Trim();
        }
    }
}
