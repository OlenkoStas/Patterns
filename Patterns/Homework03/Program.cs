

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

    public (int LongestWord, int NumberOfWords) Count(string[] sentence)//один большой метод
    {
        int lettersInTheCurrentWord = 0;
        string currentSentence = "";
        string currentWord = "";
        int longetsWord = 0;
        int i = sentence.Length - 1;//плохие имена переменных
        int j = 0;//плохие имена переменных
        string[] splitedSentence = new string[] { };
        int maxNumberOfWords = 0;

    nextSentence:

        if (i < 0)
        {
            return (longetsWord, maxNumberOfWords);
        }
        else
        {
            if (sentence[i].Contains(" "))
            {
                currentSentence = sentence[i];
                goto wordSplitter;
            }
            else
            {
                currentWord = sentence[i];
                goto letterCounter;
            }
        }

    wordSplitter:
        splitedSentence = currentSentence.Split(" ");

        j = splitedSentence.Length - 1;

        if (j > maxNumberOfWords)
        {
            goto setMaxNumberOfWords;
        }

    nextWord:
        if (j >= 0)
        {
            currentWord = splitedSentence[j];

            if (currentWord.Length > longetsWord)
            {
                goto setLongestWord;
            }
            else
            {
                j--;
                goto nextWord;
            }
        }
        i--;
        goto nextSentence;


    setMaxNumberOfWords:
        maxNumberOfWords = j + 1;
        goto nextWord;

    setLongestWord:
        longetsWord = currentWord.Length;
        j--;
        goto nextWord;

    letterCounter:
        lettersInTheCurrentWord = currentWord.Length;

        if (lettersInTheCurrentWord > longetsWord)
        {
            goto setLongestWord;
        }

        i--;
        goto nextSentence;
    }
}

