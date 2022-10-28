using BasicUtils;
using TDDLab.Core.InvoiceMgmt;

namespace TDDLab.Tests.Core.InvoiceMgmt
{
    public class InvoiceLineTests
    {
        private class MoneyStub : Money
        {
            public MoneyStub() : base(100, "stub")
            {
            }

            public new static string ToString() { return "Fake Money"; }
        }
        
        private const string ProductName = "TestName";
        private readonly MoneyStub MockMoney = new();
        private readonly InvoiceLine _subject;

        public InvoiceLineTests() => _subject = new InvoiceLine(ProductName, MockMoney);

        [Fact]
        public void Should_FormatInvoiceLineToString_When_ToString()
        {
            var result = _subject.ToString();

            Assert.Equal(result, $"{ProductName} for {MockMoney}");
        }

        [Fact]
        public void Should_ReturnProperRule_When_ValidationRuleProductName()
        {
            var subject = InvoiceLine.ValidationRules.ProductName;
            
            Assert.IsType<BusinessRule<InvoiceLine>>(subject);
            Assert.Equal("get_ProductName", subject.Name);
            Assert.Equal("Product name should be specified", subject.Description);
        }

        [Fact]
        public void Should_ReturnProperRule_When_ValidationRuleMoney()
        {
            var subject = InvoiceLine.ValidationRules.Money;
            
            Assert.IsType<BusinessRule<InvoiceLine>>(subject);
            Assert.Equal("get_Money", subject.Name);
            Assert.Equal("Money should be valid", subject.Description);
        }

        [Fact]
        public void Should_ValidateWithValidData_When_Validate()
        {
            var result = _subject.Validate();

            Assert.Empty(result);
        }

        [Fact]
        public void Should_ReturnBrokenRule_When_ProductNameIsNull_When_Validate()
        {
            var subject = new InvoiceLine(null, MockMoney);

            var result = subject.Validate();

            Assert.Single(result);
            Assert.Collection<IRule>(result, 
                item => Assert.Equal(InvoiceLine.ValidationRules.ProductName, item)
            );
        }

        [Fact]
        public void Should_ReturnBrokenRule_When_ProductNameIsEmpty_When_Validate()
        {
            var subject = new InvoiceLine(string.Empty, MockMoney);

            var result = subject.Validate();

            Assert.Single(result);
            Assert.Collection<IRule>(result, 
                item => Assert.Equal(InvoiceLine.ValidationRules.ProductName, item)
            );
        }

        [Fact]
        public void Should_ReturnBrokenRule_When_MoneyIsNull_When_Validate()
        {
            var subject = new InvoiceLine(ProductName, null);

            var result = subject.Validate();

            Assert.Single(result);
            Assert.Collection<IRule>(result, 
                item => Assert.Equal(InvoiceLine.ValidationRules.Money, item)
            );
        }
    }
}
