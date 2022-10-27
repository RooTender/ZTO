using Moq;
using TDDLab.Core.InvoiceMgmt;

namespace TDDLab.Tests.Core.InvoiceMgmt
{
    public class DomainExtensionsTests
    {
        [Fact]
        public void Should_ReturnMoneyWithNewCurrency_When_ToConvert()
        {
            var money = new Mock<Money>((ulong)100);
            const string newCurrencyName = "NewCurrency";

            // ReSharper disable once InvokeAsExtensionMethod
            var subject = DomainExtensions.ToCurrency(money.Object, newCurrencyName);

            Assert.Equal(newCurrencyName, subject.Currency);
        }
    }
}
