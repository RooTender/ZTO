using BasicUtils;
using TDDLab.Core.InvoiceMgmt;

namespace TDDLab.Tests.Core.InvoiceMgmt
{
    public class AddressTests
    {
        private readonly Address _subject;

        private const string AddressLine = "testAddress";
        private const string City = "testCity";
        private const string State = "testState";
        private const string Zip = "testZip";

        public AddressTests() => _subject = new Address(AddressLine, City, State, Zip);

        [Fact]
        public void Should_ReturnImmutableValue_When_AddressLine1()
        {
            var addressLine = _subject.AddressLine1;

            Assert.Equal(AddressLine, addressLine);
        }

        [Fact]
        public void Should_ReturnImmutableValue_When_City()
        {
            var city = _subject.City;

            Assert.Equal(City, city);
        }

        [Fact]
        public void Should_ReturnImmutableValue_When_State()
        {
            var state = _subject.State;

            Assert.Equal(State, state);
        }

        [Fact]
        public void Should_ReturnImmutableValue_When_Zip()
        {
            var zip = _subject.Zip;

            Assert.Equal(Zip, zip);
        }

        [Fact]
        public void Should_ReturnProperBusinessObject_When_ValidationRuleAddressLine1()
        {
            var subject = Address.ValidationRules.AddressLine1;

            Assert.IsType<BusinessRule<Address>>(subject);
            Assert.Equal("get_AddressLine1", subject.Name);
            Assert.Equal("AddressLine1 should be specified", subject.Description);
        }

        [Fact]
        public void Should_ReturnProperBusinessObject_When_ValidationRuleCity()
        {
            var subject = Address.ValidationRules.City;

            Assert.IsType<BusinessRule<Address>>(subject);
            Assert.Equal("get_City", subject.Name);
            Assert.Equal("City should be specified", subject.Description);
        }

        [Fact]
        public void Should_ReturnProperBusinessObject_When_ValidationRuleState()
        {
            var subject = Address.ValidationRules.State;

            Assert.IsType<BusinessRule<Address>>(subject);
            Assert.Equal("get_State", subject.Name);
            Assert.Equal("State should be properly specified", subject.Description);
        }

        [Fact]
        public void Should_ReturnProperBusinessObject_When_ValidationRuleZip()
        {
            var subject = Address.ValidationRules.Zip;

            Assert.IsType<BusinessRule<Address>>(subject);
            Assert.Equal("get_Zip", subject.Name);
            Assert.Equal("Zip code should be specified", subject.Description);
        }
    }
}