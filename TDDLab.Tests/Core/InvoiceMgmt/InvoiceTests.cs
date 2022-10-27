using Moq;
using TDDLab.Core.InvoiceMgmt;

namespace TDDLab.Tests.Core.InvoiceMgmt
{
    public class InvoiceTests
    {
        private readonly Invoice _subject = new();

        [Fact]
        public void Should_AttachInvoiceLineToLines_When_AttachInvoiceLine()
        {
            var invoiceLine = new Mock<InvoiceLine>("test", new Mock<Money>((ulong)100).Object);

            _subject.AttachInvoiceLine(invoiceLine.Object);

            Assert.Equal(1, _subject.Lines.Count);
        }

        [Fact]
        public void Should_ReturnProperRule_When_ValidationRuleInvoiceNumber()
        {
            var subject = Invoice.ValidationRules.InvoiceNumber;
            
            Assert.Equal("get_InvoiceNumber", subject.Name);
            Assert.Equal("Invoice number should be specified", subject.Description);
        }

        [Fact]
        public void Should_ReturnProperRule_When_ValidationRuleBillingAddress()
        {
            var subject = Invoice.ValidationRules.BillingAddress;
            
            Assert.Equal("get_BillingAddress", subject.Name);
            Assert.Equal("Billing address should be valid", subject.Description);
            Assert.Equal(6, subject.);
        }

        [Fact]
        public void Should_ReturnProperRule_When_ValidationRuleRecipient()
        {
            var subject = Invoice.ValidationRules.Recipient;
            
            Assert.Equal("get_Recipient", subject.Name);
            Assert.Equal("Recipient should be valid", subject.Description);
        }
        
        [Fact]
        public void Should_ReturnProperRule_When_ValidationRuleDiscount()
        {
            var subject = Invoice.ValidationRules.Discount;
            
            Assert.Equal("get_Discount", subject.Name);
            Assert.Equal("Discount should be valid", subject.Description);
        }
        
        [Fact]
        public void Should_ReturnProperRule_When_ValidationRuleLines()
        {
            var subject = Invoice.ValidationRules.Lines;
            
            Assert.Equal("get_Lines", subject.Name);
            Assert.Equal("Invoice lines should all be valid", subject.Description);
        }
    }
}
