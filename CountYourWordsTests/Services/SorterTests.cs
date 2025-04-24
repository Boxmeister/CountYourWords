using Microsoft.VisualStudio.TestTools.UnitTesting;
using CountYourWords.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CountYourWords.Models;

namespace CountYourWords.Services.Tests
{
    [TestClass()]
    public class SorterTests
    {
        private Sorter _sorter = new Sorter();


        [TestMethod()]
        public void SortWordsTest()
        {
            // Arrange
            var input = new List<WordCount> { new WordCount("banana", 1), new WordCount("apple", 1), new WordCount("cherry", 1) };
            var expected = new List<WordCount> { new WordCount("apple", 1), new WordCount("banana", 1), new WordCount("cherry", 1) };

            // Act
            var result = _sorter.Sort(input);

            // Assert
            CollectionAssert.Equals(expected, result);
        }

        [TestMethod]
        public void Sort_AlreadySortedList_ReturnsSameOrder()
        {
            var input = new List<WordCount> { new WordCount("a", 1), new WordCount("b", 1), new WordCount("c", 1) };
            var result = _sorter.Sort(input);
            CollectionAssert.AreEqual(input, result);
        }

    }
}
