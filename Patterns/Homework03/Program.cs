

Console.WriteLine("Starting Homework 03!");

// TODO: write your code here implementing one of the problems below:
// https://leetcode.com/problems/maximum-number-of-words-found-in-sentences/
// https://leetcode.com/problems/jewels-and-stones/
// https://leetcode.com/problems/shuffle-string/


//public class Solution  
//{
//    public int MostWordsFound(string[] sentences) => sentences.Max(m => m.Split(" ").Length); //😎 😎 😎 😎 😎
//}


/*
    Я попытался реализовать спагетти код с несоблюдением принципа KISS
 */

string[] sentence = new string[] { "alice and bob love leetcode", "i think so too", "this is great thanks very much", "" };

Console.WriteLine(new Counter().Count(sentence).NumberOfWords);



public class Counter
{

    public (int LongestWord, int NumberOfWords) Count(string[] sentence)
    {
        int lettersInTheCurrentWord = 0;
        string currentSentence = "";
        string currentWord = "";
        int longetsWord = 0;
        int currentNumberOfSentences = sentence.Length - 1;
        int currentNumberOfWords = 0;
        string[] splitedSentence = new string[] { };
        int maxNumberOfWords = 0;

    nextSentence:

        if (currentNumberOfSentences < 0)
        {
            return (longetsWord, maxNumberOfWords);
        }
        else
        {
            if (sentence[currentNumberOfSentences].Contains(" "))
            {
                currentSentence = sentence[currentNumberOfSentences];
                goto wordSplitter;
            }
            else
            {
                currentWord = sentence[currentNumberOfSentences];
                goto letterCounter;
            }
        }

    wordSplitter:
        splitedSentence = currentSentence.Split(" ");

        currentNumberOfWords = splitedSentence.Length - 1;

        if (currentNumberOfWords > maxNumberOfWords)
        {
            goto setMaxNumberOfWords;
        }

    nextWord:
        if (currentNumberOfWords >= 0)
        {
            currentWord = splitedSentence[currentNumberOfWords];

            if (currentWord.Length > longetsWord)
            {
                goto setLongestWord;
            }
            else
            {
                currentNumberOfWords--;
                goto nextWord;
            }
        }
        currentNumberOfSentences--;
        goto nextSentence;


    setMaxNumberOfWords:
        maxNumberOfWords = currentNumberOfWords + 1;
        goto nextWord;

    setLongestWord:
        longetsWord = currentWord.Length;
        currentNumberOfWords--;
        goto nextWord;

    letterCounter:
        lettersInTheCurrentWord = currentWord.Length;

        if (lettersInTheCurrentWord > longetsWord)
        {
            goto setLongestWord;
        }

        currentNumberOfSentences--;
        goto nextSentence;
    }
}

