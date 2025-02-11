namespace LenaLearningAPI.Models
{
    public class TextBase
    {
        public string Text { get; set; }
        public string Message { get; set; }
    }
    public class GetTextResponse: TextBase { }
    public class PostTextResponse : TextBase { }
    public class CountWordsResponse : TextBase
    {
        public int WordCount { get; set; }
    }
    public class CountWordEntryResponse : TextBase
    {
        public string WordEntry { get; set; }
        public int WordCount { get; set; }
    }
    public class GetCharacterAtResponse : TextBase
    {
        public int Position { get; set; }
        public string Character { get; set; }
    }
    public class GetWordInPositionResponse : TextBase
    {
        public int Position { get; set; }
        public string Word { get; set; }
    }
    public class GetWordByPositionResponse : TextBase
    {
        public int WordNumber { get; set; }
        public string Word { get; set; }
    }
    public class GetPhraseCountResponse : TextBase
    {
        public int PhraseCount { get; set; }
    }
}

