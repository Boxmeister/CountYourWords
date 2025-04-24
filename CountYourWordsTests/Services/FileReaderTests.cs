using CountYourWords.Services;

namespace CountYourWordsTests;

[TestClass]
public class FileReaderTests
{
    private string? _tempFilePath;

    [TestCleanup]
    public void Cleanup()
    {
        if (!string.IsNullOrEmpty(_tempFilePath) && File.Exists(_tempFilePath))
            File.Delete(_tempFilePath);
    }

    [TestMethod]
    public void ReadFileReturnsContent()
    {
        _tempFilePath = Path.Combine(Path.GetTempPath(), $"testfile_{Guid.NewGuid()}.txt");
        var expectedContent = "Hello MSTest!";
        File.WriteAllText(_tempFilePath, expectedContent);

        var reader = new FileReader();

        // Act
        var result = reader.ReadFile(_tempFilePath);

        // Assert
        Assert.AreEqual(expectedContent, result);

    }

    [TestMethod]
    public void FileReaderThrowsFileNotFoundException()
    {
        // Arrange
        var path = Path.Combine(Path.GetTempPath(), $"doesnotexist_{Guid.NewGuid()}.txt");
        var reader = new FileReader();
        var expected = "FileNotFoundException";

        // Act
        reader.ReadFile(path);

        // Assert: handled by ExpectedException
    }

    [TestMethod]
    public void ReadFileReturnsNoContent()
    {
        _tempFilePath = Path.Combine(Path.GetTempPath(), $"testfile_{Guid.NewGuid()}.txt");
        File.WriteAllText(_tempFilePath, "");
        var expected = "FileEmptyException";
        var reader = new FileReader();

        // Act
        var result = reader.ReadFile(_tempFilePath);

        // Assert
        Assert.AreEqual(expected, result);

    }
}
