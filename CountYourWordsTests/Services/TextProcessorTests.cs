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
        Dictionary<string, int> expected = new Dictionary<string, int>
        {
            { "hello", 1 },
            { "world", 1 },
            { "how", 1 },
            { "are", 1 },
            { "you", 2 },
            { "love", 1 },
            { "ever", 1 }
        };

        //Act
        var result = _textProcessor.CountWords(input);
        //Assert
        CollectionAssert.AreEqual(expected, result);
    }
}
