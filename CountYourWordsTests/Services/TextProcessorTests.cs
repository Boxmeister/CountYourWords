using CountYourWords.Models;
using CountYourWords.Services;

namespace CountYourWordsTests;

[TestClass]
public class TextProcessorTests
{
    private TextProcessor _textProcessor = new TextProcessor();

    [TestMethod]
    public void CleanInputTest()
    {
        //Arrange
        var input = "Hello, world! How are you? love you 4 ever";
        var expected = "hello world how are you love you ever";

        //Act
        var result = _textProcessor.CleanInput(input);
        //Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void WordSplitTest()
    {
        //Arrange
        var input = "hello world how are you love you ever";
        //Act
        var result = _textProcessor.SplitInput(input);
        //Assert
        Assert.AreEqual(8, result.Count());
    }

    [TestMethod]
    public void WordCountTest()
    {
        //Arrange
        var input = new List<string> { "hello", "world", "how", "are", "you", "love", "you", "ever" };
        List<WordCount> expected = new List<WordCount>{
            {new WordCount ("hello", 1) },
            { new WordCount ("world", 1) },
            { new WordCount ("how", 1) },
            { new WordCount ("are", 1) },
            { new WordCount ("you", 2) },
            { new WordCount ("love", 1) },
            {new WordCount ( "ever", 1) }
        };

        //Act
        var result = _textProcessor.CountWords(input);
        //Assert
        CollectionAssert.Equals(expected, result);
    }
}
