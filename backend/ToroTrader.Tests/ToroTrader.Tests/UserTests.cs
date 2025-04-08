using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToroTrader.Application.Domain.Entities;

namespace ToroTrader.Tests
{
    public class UserTests
    {
        [Fact]
        public void Constructor_ShouldInitializeProperties_WhenValidParametersAreProvided()
        {
            // Arrange
            var name = "John Doe";
            var balance = 1000m;
            var documentNumber = "123456789";
            var accountId = "ACC123";
            var clientId = "CLI456";

            // Act
            var user = new User(name, balance, documentNumber, accountId, clientId);

            // Assert
            Assert.Equal(name, user.Name);
            Assert.Equal(balance, user.Balance);
            Assert.Equal(documentNumber, user.DocumentNumber);
            Assert.Equal(accountId, user.AccountId);
            Assert.Equal(clientId, user.ClientId);
        }

        [Fact]
        public void Constructor_ShouldSetRandomValues_WhenOptionalParametersAreNotProvided()
        {
            // Arrange
            var name = "John Doe";
            var balance = 1000m;
            var documentNumber = "123456789";

            // Act
            var user = new User(name, balance, documentNumber);

            // Assert
            Assert.False(string.IsNullOrWhiteSpace(user.AccountId));
            Assert.False(string.IsNullOrWhiteSpace(user.ClientId));

            var accountIdValue = int.Parse(user.AccountId);
            var clientIdValue = int.Parse(user.ClientId);

            Assert.InRange(accountIdValue, 1, 5000);
            Assert.InRange(clientIdValue, 1, 5000);
        }

        [Theory]
        [InlineData(null, 1000, "123456789", nameof(User.Name))]
        [InlineData("John Doe", 1000, null, nameof(User.DocumentNumber))]
        public void Constructor_ShouldThrowArgumentNullException_WhenRequiredParametersAreNull(
            string name, decimal balance, string documentNumber, string paramName)
        {
            // Act & Assert
            var exception = Assert.Throws<ArgumentNullException>(() => new User(name, balance, documentNumber));
            Assert.Equal(paramName, exception.ParamName);
        }

        [Fact]
        public void SetLastAccess_ShouldUpdateLastAccessDate()
        {
            // Arrange
            var user = new User("John Doe", 1000m, "123456789");
            var newDate = DateTime.UtcNow;

            // Act
            user.SetLastAccess(newDate);

            // Assert
            Assert.Equal(newDate, user.LastAccess);
        }

        [Fact]
        public void Debit_ShouldReduceBalance_WhenAmountIsValid()
        {
            // Arrange
            var user = new User("John Doe", 1000m, "123456789");
            var amount = 200m;

            // Act
            user.Debit(amount);

            // Assert
            Assert.Equal(800m, user.Balance);
        }

        [Fact]
        public void Debit_ShouldThrowArgumentException_WhenAmountIsZeroOrNegative()
        {
            // Arrange
            var user = new User("John Doe", 1000m, "123456789");

            // Act & Assert
            Assert.Throws<ArgumentException>(() => user.Debit(0));
            Assert.Throws<ArgumentException>(() => user.Debit(-100));
        }

        [Fact]
        public void Debit_ShouldThrowInvalidOperationException_WhenAmountExceedsBalance()
        {
            // Arrange
            var user = new User("John Doe", 100m, "123456789");

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => user.Debit(200m));
        }
    }
}
