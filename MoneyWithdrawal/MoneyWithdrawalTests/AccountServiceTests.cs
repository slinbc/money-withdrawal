using MoneyWithdrawal.Console.Services;
using MoneyWithdrawal.Console.Repositories;
using MoneyWithdrawal.Console.Models;

namespace MoneyWithdrawalTests
{
    public class AccountServiceTests
    {
        private readonly IAccountService _sut;
        private readonly Mock<IAccountBalanceDAO> _accountBalanceDAOMock;
        private readonly Mock<INotificationService> _notificationServiceMock;
        private readonly Mock<IDateTimeProvider> _dateTimeMock;
        private readonly string testAccountNumber = "0000002";

        public AccountServiceTests()
        {
            _accountBalanceDAOMock = new Mock<IAccountBalanceDAO>();
            _notificationServiceMock = new Mock<INotificationService>();
            _dateTimeMock = new Mock<IDateTimeProvider>();

            _sut = new AccountService(
                _accountBalanceDAOMock.Object,
                _notificationServiceMock.Object,
                _dateTimeMock.Object
            );

            InitSetups();
        }

        [Fact]
        public void Withdraw_ShouldDisplayErrorMessage_WhenBalanceIsNotEnough()
        {
            var withdrawAmount = 120;
            _sut.Withdraw(testAccountNumber, withdrawAmount);
            _notificationServiceMock.Verify(mock => mock.DisplayNotification("Le montant de la demande dépasse votre autorisation de découvert"), Times.Once);
        }

        [Fact]
        public void Withdraw_ShouldNotApplyAmountChanges_WhenBalanceIsNotEnough()
        {

            var withdrawAmount = 120;
            _sut.Withdraw(testAccountNumber, withdrawAmount);
            _accountBalanceDAOMock.Verify(mock => mock.AddAmount(testAccountNumber, -1 * withdrawAmount), Times.Never);
        }

        [Fact]
        public void Withdraw_ShouldDisplaySuccessMessage_WhenBalanceIsEnough()
        {

            var withdrawAmount = 80;
            _sut.Withdraw(testAccountNumber, withdrawAmount);
            _notificationServiceMock.Verify(mock => mock.DisplayNotification($"Vous venez de retirer {withdrawAmount} sur votre compte n° {testAccountNumber}"), Times.Once);
        }

        [Fact]
        public void Withdraw_ShouldApplyAmountChanges_WhenBalanceIsEnough()
        {

            var withdrawAmount = 80;
            _sut.Withdraw(testAccountNumber, withdrawAmount);
            _accountBalanceDAOMock.Verify(mock => mock.AddAmount(testAccountNumber, -1 * withdrawAmount), Times.Once);
        }

        [Fact]
        public void Withdraw_ShouldDisplayErrorMessage_WhenHappensInDecember()
        {
            var withdrawAmount = 50;
            _dateTimeMock.Setup(mock => mock.GetCurrentMonth()).Returns(12);
            _sut.Withdraw(testAccountNumber, withdrawAmount);
            _notificationServiceMock.Verify(mock => mock.DisplayNotification("Aucun retrait n'est autorisé en Décembre"), Times.Once);
            _accountBalanceDAOMock.Verify(mock => mock.AddAmount(testAccountNumber, -1 * withdrawAmount), Times.Never);
        }

        private void InitSetups()
        {
            var account = new AccountBalance(testAccountNumber, 100);

            _accountBalanceDAOMock.Setup(mock => mock.GetByAccountNumber(It.IsAny<string>())).Returns(account);

            _dateTimeMock.Setup(mock => mock.GetCurrentMonth()).Returns(5);
        }
    }
}