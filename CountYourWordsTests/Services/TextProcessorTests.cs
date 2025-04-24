using CountYourWords.Configuration;
using CountYourWords.Interfaces;
using CountYourWords.Models;
using CountYourWords.Services;
using Microsoft.Extensions.Options;
using Moq;

namespace CountYourWordsTests;

[TestClass]
public class TextProcessorTests
{
    private TextProcessor _textProcessor;

    public TextProcessorTests()
    {
        // Mock dependencies  
        var mockReader = new Mock<IFileReader>();
        var mockSorter = new Mock<ISorter>();
        var mockOptions = new Mock<IOptions<FileSettings>>();

        // Provide default values for IOptions<FileSettings>  
        mockOptions.Setup(o => o.Value).Returns(new FileSettings { InputFilePath = "test.txt" });

        // Initialize TextProcessor with mocked dependencies  
        _textProcessor = new TextProcessor(mockReader.Object, mockSorter.Object, mockOptions.Object);
    }

    [TestMethod]
    public void CleanInputTest()
    {
        // Arrange  
        var input = "Hello, world! How are you? love you 4 ever";
        var expected = "hello world how are you love you ever";

        // Act  
        var result = _textProcessor.CleanInput(input);

        // Assert  
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void WordSplitTest()
    {
        // Arrange  
        var input = "hello world how are you love you ever";

        // Act  
        var result = _textProcessor.SplitInput(input);

        // Assert  
        Assert.AreEqual(8, result.Count());
    }

    [TestMethod]
    public void WordCountTest()
    {
        // Arrange  
        var input = new List<string> { "hello", "world", "how", "are", "you", "love", "you", "ever" };
        List<WordCount> expected = new List<WordCount>
       {
           new WordCount("hello", 1),
           new WordCount("world", 1),
           new WordCount("how", 1),
           new WordCount("are", 1),
           new WordCount("you", 2),
           new WordCount("love", 1),
           new WordCount("ever", 1)
       };

        // Act  
        var result = _textProcessor.CountWords(input);

        // Assert  
        CollectionAssert.Equals(expected, result);
    }
}
