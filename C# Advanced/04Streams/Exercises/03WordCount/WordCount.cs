using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03WordCount
{
    class WordCount
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> wordsCount = new Dictionary<string, int>();

            using (StreamReader reader = new StreamReader(@"../../../../resources/words.txt"))
            {
                using (StreamReader textReader = new StreamReader(@"../../../../resources/text.txt"))
                {
                    using (StreamWriter writer = new StreamWriter(@"../../../result.txt"))
                    {
                        string input = textReader.ReadLine();
                        string keyWord = reader.ReadLine();

                        List<string> keyWords = new List<string>();
                        keyWord = AddingKeyWordsInCollection(reader, keyWord, keyWords);

                        while (input != null)
                        {
                            string[] line = input.ToLower()
                            .Split(new char[] { ' ', ',', '.', '-' }, StringSplitOptions.RemoveEmptyEntries)
                            .ToArray();

                            for (int i = 0; i < line.Length; i++)
                            {
                                string currentWord = line[i];

                                for (int keyWordIndex = 0; keyWordIndex < keyWords.Count; keyWordIndex++)
                                {
                                    string currentKeyWord = keyWords[keyWordIndex];
                                    if (currentWord == currentKeyWord)
                                    {
                                        if (!wordsCount.ContainsKey(currentWord))
                                        {
                                            wordsCount.Add(currentWord, 1);
                                        }
                                        else
                                        {
                                            wordsCount[currentWord]++;
                                        }
                                    }
                                }
                            }

                            input = textReader.ReadLine();
                        }

                        foreach (var word in wordsCount.OrderByDescending(x => x.Value))
                        {
                            writer.WriteLine($"{word.Key} - {word.Value}");
                        }
                    }
                }
            }
        }
        private static string AddingKeyWordsInCollection(StreamReader reader, string keyWord, List<string> keyWords)
        {
            while (keyWord != null)
            {
                keyWords.Add(keyWord);
                keyWord = reader.ReadLine();
            }
            return keyWord;
        }
    }
}
