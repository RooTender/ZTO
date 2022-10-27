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
        public void Should_ReturnImmutableValue_When_UsingAddressLineGetter()
        {
            var addressLine = _subject.AddressLine1;

            Assert.Equal(AddressLine, addressLine);
        }

        [Fact]
        public void Should_ReturnImmutableValue_When_UsingCityGetter()
        {
            var city = _subject.City;

            Assert.Equal(City, city);
        }

        [Fact]
        public void Should_ReturnImmutableValue_When_UsingStateGetter()
        {
            var state = _subject.State;

            Assert.Equal(State, state);
        }

        [Fact]
        public void Should_ReturnImmutableValue_When_UsingZipGetter()
        {
            var zip = _subject.Zip;

            Assert.Equal(Zip, zip);
        }
    }
}