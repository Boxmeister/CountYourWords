using Microsoft.VisualStudio.TestTools.UnitTesting;
using CountYourWords.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var input = new List<string> { "banana", "apple", "cherry" };
            var expected = new List<string> { "apple", "banana", "cherry" };

            // Act
            var result = _sorter.Sort(input);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }
        [TestMethod]
        public void Sort_EmptyList_ReturnsEmptyList()
        {
            var result = _sorter.Sort(new List<string>());
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void Sort_AlreadySortedList_ReturnsSameOrder()
        {
            var input = new List<string> { "a", "b", "c" };
            var result = _sorter.Sort(input);
            CollectionAssert.AreEqual(input, result);
        }

    }
}
