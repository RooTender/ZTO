using BasicUtils;
using TDDLab.Core.InvoiceMgmt;

namespace TDDLab.Tests.Core.InvoiceMgmt
{
    public class RecipientTests
    {
        private const string TestName = "TestName";
        private static readonly Address TestAddress = new("address", "city", "state", "zip");

        private readonly Recipient _subject = new(TestName, TestAddress);

        [Fact]
        public void Should_ReturnProperRule_When_ValidationRuleName()
        {
            var subject = Recipient.ValidationRules.Name;
            
            Assert.IsType<BusinessRule<Recipient>>(subject);
            Assert.Equal("get_Name", subject.Name);
            Assert.Equal("Recipient name should be specified", subject.Description);
        }

        [Fact]
        public void Should_ReturnProperRule_When_ValidationRuleAddress()
        {
            var subject = Recipient.ValidationRules.Address;
            
            Assert.IsType<BusinessRule<Recipient>>(subject);
            Assert.Equal("get_Address", subject.Name);
            Assert.Equal("Address should be valid", subject.Description);
        }

        [Fact]
        public void Should_ValidateWithValidData_When_Validate()
        {
            var result = _subject.Validate();

            Assert.Empty(result);
        }

        [Fact]
        public void Should_ReturnBrokenRule_When_NameIsNull_When_Validate()
        {
            var subject = new Recipient(null, TestAddress);

            var result = subject.Validate();

            Assert.Single(result);
            Assert.Collection<IRule>(result, 
                item => Assert.Equal(Recipient.ValidationRules.Name, item)
            );
        }

        [Fact]
        public void Should_ReturnBrokenRule_When_NameIsEmpty_When_Validate()
        {
            var subject = new Recipient(string.Empty, TestAddress);

            var result = subject.Validate();

            Assert.Single(result);
            Assert.Collection<IRule>(result, 
                item => Assert.Equal(Recipient.ValidationRules.Name, item)
            );
        }
    }
}
