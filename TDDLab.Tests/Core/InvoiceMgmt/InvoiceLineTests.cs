using BasicUtils;
using Moq;
using TDDLab.Core.InvoiceMgmt;

namespace TDDLab.Tests.Core.InvoiceMgmt
{
    public class InvoiceLineTests
    {
        private const string TestProductName = "TestName";
        private const ulong TestMoneyAmount = 100;

        private readonly InvoiceLine _subject;

        public InvoiceLineTests()
        {
            var money = new Mock<Money>(TestMoneyAmount)
            {
                CallBase = true
            };
            money.Setup(x => x.Amount).Returns(100);

            _subject = new InvoiceLine(TestProductName, money.Object);
        }

        [Fact]
        public void Should_FormatInvoiceLineToString_When_ToString()
        {
            var result = _subject.ToString();

            Assert.Equal(result, $"{TestProductName} for {TestMoneyAmount}");
        }

        [Fact]
        public void Should_ReturnProperRule_When_ValidationRuleProductName()
        {
            var subject = Invoice.ValidationRules.Lines;
            
            Assert.IsType<BusinessRule<InvoiceLine>>(subject);
            Assert.Equal("get_Lines", subject.Name);
            Assert.Equal("Invoice lines should all be valid", subject.Description);
        }

        [Fact]
        public void Should_ReturnProperRule_When_ValidationRuleMoney()
        {
            var subject = Invoice.ValidationRules.Lines;
            
            Assert.IsType<BusinessRule<InvoiceLine>>(subject);
            Assert.Equal("get_Lines", subject.Name);
            Assert.Equal("Invoice lines should all be valid", subject.Description);
        }
    }
}
