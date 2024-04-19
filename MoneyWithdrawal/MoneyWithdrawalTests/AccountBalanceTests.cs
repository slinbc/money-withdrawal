using MoneyWithdrawal.Console.Models;

namespace MoneyWithdrawalTests
{
    public class AccountBalanceTests
    {
        [Fact]
        public void AddBalance_IncreasesBalance()
        {
            // Arrange
            var account = new AccountBalance("123456789", 100);

            // Act
            account.AddBalance(50);

            // Assert
            Assert.Equal(150, account.Balance);
        }

        [Fact]
        public void AllowWithdrawal_InsufficientFunds_ReturnsFalse()
        {
            // Arrange
            var account = new AccountBalance("987654321", 100);

            // Act
            var canWithdraw = account.AllowWithdrawal(150);

            // Assert
            Assert.False(canWithdraw);
        }

        [Fact]
        public void AllowWithdrawal_SufficientFunds_ReturnsTrue()
        {
            // Arrange
            var account = new AccountBalance("987654321", 100);

            // Act
            var canWithdraw = account.AllowWithdrawal(50);

            // Assert
            Assert.True(canWithdraw);
        }

        [Fact]
        public void AllowWithdrawal_WithAllowedDiscovery_ReturnsTrue()
        {
            // Arrange
            var account = new AccountBalance("987654321", 100, 20);

            // Act
            var canWithdraw = account.AllowWithdrawal(130); // 100 balance + 20 allowed discovery + 10 additional

            // Assert
            Assert.True(canWithdraw);
        }

        [Fact]
        public void AllowWithdrawal_WithAllowedDiscovery_NotEnough_ReturnsFalse()
        {
            // Arrange
            var account = new AccountBalance("987654321", 100, 20);

            // Act
            var canWithdraw = account.AllowWithdrawal(141); // 100 balance + 20 allowed discovery + 21 additional

            // Assert
            Assert.False(canWithdraw);
        }
    }
}
