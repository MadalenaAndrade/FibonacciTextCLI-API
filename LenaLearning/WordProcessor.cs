using System.Text.RegularExpressions; //regex!


namespace LenaLearning
{
    public class WordProcessor
    {
        private string _text = string.Empty; //The text doesn't initiate as null if empty, it initializes as an empty string

        public string Text
        {
            get => _text; 
            set 
            {
                EnsureTextIsNotEmpty(value);
                _text = value; 
            }
        }


        //Class Methods
        public int CountWords()
        {
            EnsureTextIsNotEmpty(_text);

            if (string.IsNullOrWhiteSpace(_text))
            {
                return 0;
            }
            return GetWordsList().Count;
        }

        public int CountWordEntry(string wordEntry)
        {
            EnsureTextIsNotEmpty(_text);
            EnsureTextIsNotEmpty(wordEntry);

            if (Regex.IsMatch(wordEntry, @"[^\p{L}]"))
            {
                throw new MyException("Invalid character in word entry");
            }

            int count = 0;
            foreach (string word in GetWordsList())
            {
                if (word.ToUpper() == wordEntry.ToUpper())
                {
                    count++;
                }
            }
            return count;
        }

        public char GetCharacterAt(int i)
        {
            i--;
            EnsureTextIsNotEmpty(_text);
            ValidateIndex(i);
            return _text[i];
        }

        public string GetWordAtCharacterPosition(int i)
        {
            i--;
            EnsureTextIsNotEmpty(_text);
            ValidateIndex(i);

            char character = _text[i];

            if (char.IsWhiteSpace(character)) //return if is a space
            {
                return "blank character";
            }

            if (!char.IsLetter(character)) //return if is a special character or digit
            {
                return $"{character}";
            }

            //Calculates how many not repetitive pontuation up to the index, and returns a count(WordIndex) that works as an index for the words in the array.
            List<string> words = GetWordsList();

            int wordIndex = 0;
            bool isSpecial = false; //used to control continuous special characters

            for (int index = 0; index <= i; index++)
            {
                if (!char.IsLetterOrDigit(_text[index])) //if punctuation
                {
                    if (!isSpecial)
                    {
                        wordIndex++;
                        isSpecial = true; //it keeps true until it reaches word
                    }
                }
                else //if it's part of the word it keeps false until next punctuation
                {
                    isSpecial = false;
                }
            }

            return words[wordIndex];
        }

        public string GetWordByWordPosition(int i)
        {
            i--;
            EnsureTextIsNotEmpty(_text);
            ValidateIndex(i);

            List<string> words = GetWordsList();

            return words[i];
        }

        public int GetPhraseCount()
        {
            EnsureTextIsNotEmpty(_text);

            string finalPunctuation = @"[!?.~]+";
            string[] sentences = Regex.Split(_text, finalPunctuation);

            int count = 0;

            foreach (string sentence in sentences) 
            {
                if(sentence != "") 
                { 
                    count++; 
                }
            }
            return count;
        }

        //validations and helper methods
        private void EnsureTextIsNotEmpty(string word)
        {
            if (string.IsNullOrEmpty(word) || string.IsNullOrWhiteSpace(word))
            {
                throw new MyException("Text is empty");
            }
        }

        private void ValidateIndex(int i)
        {
            if (i < 0 || i >= _text.Length)
            {
                throw new MyException("Index is out of range");
            }
        }

        private List<string> GetWordsList() //tried to use some regex specific methods, not sure if I could do it another way
        {
            string continuousLetters = @"\p{L}+"; //every continuous letter

            MatchCollection matches = Regex.Matches(_text, continuousLetters); //it gets every word as it only matches continuous letters

            List<string> words = new List<string>();

            foreach (Match match in matches)
            {
                if (match.Success)
                {
                    words.Add(match.Value);
                }
            }
            return words;
        }
    }
}
