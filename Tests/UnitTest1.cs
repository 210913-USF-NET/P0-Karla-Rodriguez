using System;
using Xunit;
using Models;

namespace Tests
{
    public class ModelTests
    {
        [Fact]
        public void CustomersShouldCreate()
        {
            
            Customers test = new Customers();

            Assert.NotNull(test);
        }

        [Fact]
        public void CustomersShouldSetValidData()
        {
            //Arrange
            Customers test = new Customers();
            string testFirstName = "test customers";

            //Act
            test.FirstName = testFirstName;

            //Assert
            Assert.Equal(testFirstName, test.FirstName);
        }

        [Fact]
        public void OrdersShouldCreate()
        {
            //Arrange & Act
            Orders test = new Orders();

            Assert.NotNull(test);
        }

        [Theory]
        [InlineData("")]
        [InlineData("123567890")]
        [InlineData("%$@^^")]
        public void CustomersShouldNotAllowInvalidName(string input)
        {
            //Arrange
            Customers test = new Customers();
            
            //Assert 
            Assert.Throws<InputInvalidException>(() => test.FirstName = input);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(10000)]
        public void OrdersShouldNotSetInvalidTotals(int input)
        {
            Orders test = new Orders();

            Assert.Throws<InputInvalidException>(() => test.Totals = input);
        }
    }
}