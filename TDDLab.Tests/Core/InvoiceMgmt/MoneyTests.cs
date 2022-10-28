using BasicUtils;
using TDDLab.Core.InvoiceMgmt;

namespace TDDLab.Tests.Core.InvoiceMgmt
{
    public class MoneyTests
    {
        private const ulong MoneyAmount = 100;
        private const string MoneyCurrency = "testCurrency";

        private readonly Money _subject = new(MoneyAmount, MoneyCurrency);

        [Fact]
        public void Should_SumMoney_When_PlusOperator()
        {
            var testSubject = new Money(MoneyAmount, "fakeCurrency");

            var result = _subject + testSubject;

            Assert.Equal(new Money(MoneyAmount * 2, MoneyCurrency), result);
        }

        [Fact]
        public void Should_SubtractMoney_When_MinusOperator()
        {
            var testSubject = new Money(MoneyAmount / 2, "fakeCurrency");

            var result = _subject - testSubject;

            Assert.Equal(new Money(MoneyAmount - MoneyAmount / 2, MoneyCurrency), result);
        }

        [Fact]
        public void Should_SubtractMoneyWhileMinumumValueIsZero_When_MinusOperator()
        {
            var testSubject = new Money(5 * MoneyAmount, "fakeCurrency");

            var result = _subject - testSubject;

            Assert.Equal(new Money(0, MoneyCurrency), result);
        }

        [Fact]
        public void Should_ReturnProperRule_When_ValidationRuleCurrency()
        {
            var subject = Money.ValidationRules.Currency;
            
            Assert.IsType<BusinessRule<Money>>(subject);
            Assert.Equal("get_Currency", subject.Name);
            Assert.Equal("Currency should be specified", subject.Description);
        }

        [Fact]
        public void Should_ValidateWithValidData_When_Validate()
        {
            var result = _subject.Validate();

            Assert.Empty(result);
        }

        [Fact]
        public void Should_ReturnBrokenRule_When_CurrencyIsNull_When_Validate()
        {
            var subject = new Money(MoneyAmount, null);

            var result = subject.Validate();

            Assert.Single(result);
            Assert.Collection<IRule>(result, 
                item => Assert.Equal(Money.ValidationRules.Currency, item)
            );
        }

        [Fact]
        public void Should_ReturnBrokenRule_When_CurrencyIsEmpty_When_Validate()
        {
            var subject = new Money(MoneyAmount, string.Empty);

            var result = subject.Validate();

            Assert.Single(result);
            Assert.Collection<IRule>(result, 
                item => Assert.Equal(Money.ValidationRules.Currency, item)
            );
        }

        [Fact]
        public void Should_ReturnFalse_OnCheckingEqualityOnNull_When_Equals()
        {
            var result = _subject.Equals(null);

            Assert.False(result);
        }

        [Fact]
        public void Should_ReturnTrue_OnCheckingEqualityOnTheSameObject_When_Equals()
        {
            bool result = _subject.Equals(_subject);

            Assert.True(result);
        }

        [Fact]
        public void Should_ReturnTrue_OnCheckingEqualityWithObjectWithTheSameParameters_When_Equals()
        {
            var subject = new Money(MoneyAmount, MoneyCurrency);

            bool result = _subject.Equals(subject);

            Assert.True(result);
        }

        [Fact]
        public void Should_ReturnFalse_OnCheckingEqualityWithObjectWithDifferentParameters_When_Equals()
        {
            var subject = new Money(MoneyAmount + 100, MoneyCurrency);

            bool result = _subject.Equals(subject);

            Assert.False(result);
        }

        [Fact]
        public void Should_ReturnFalse_OnCheckingObjectEqualityOnNull_When_Equals()
        {
            object? subject = null;

            var result = _subject.Equals(subject);

            Assert.False(result);
        }

        [Fact]
        public void Should_ReturnTrue_OnCheckingObjectEqualityOnTheSameObject_When_Equals()
        {
            object subject = _subject;

            var result = _subject.Equals(subject);

            Assert.True(result);
        }

        [Fact]
        public void Should_ReturnFalse_OnCheckingObjectEqualityOnDifferentObject_When_Equals()
        {
            object subject = 100;

            var result = _subject.Equals(subject);

            Assert.False(result);
        }

        [Fact]
        public void Should_ReturnTrue_OnCheckingObjectEqualityWithObjectWithTheSameParameters_When_Equals()
        {
            object subject = new Money(MoneyAmount, MoneyCurrency);

            bool result = _subject.Equals(subject);

            Assert.True(result);
        }

        [Fact]
        public void Should_ReturnFalse_OnCheckingObjectEqualityWithObjectWithDifferentParameters_When_Equals()
        {
            object subject = new Money(MoneyAmount + 100, MoneyCurrency);

            bool result = _subject.Equals(subject);

            Assert.False(result);
        }

        [Fact]
        public void Should_ReturnDifferentHashCodeEvenIfAmountIsTheSame_When_GetHashCode()
        {
            var subject1 = new Money(MoneyAmount, "test1");
            var subject2 = new Money(MoneyAmount, "test2");

            Assert.NotEqual(subject1.GetHashCode(), subject2.GetHashCode());
        }

        [Fact]
        public void Should_ReturnDifferentHashCodeEvenIfCurrencyIsTheSame_When_GetHashCode()
        {
            var subject1 = new Money(MoneyAmount, MoneyCurrency);
            var subject2 = new Money(MoneyAmount * 123, MoneyCurrency);

            Assert.NotEqual(subject1.GetHashCode(), subject2.GetHashCode());
        }

        [Fact]
        public void Should_ReturnTrueIfObjectsAreTheSame_When_EqualOperator()
        {
            var subject1 = new Money(MoneyAmount, MoneyCurrency);
            var subject2 = new Money(MoneyAmount, MoneyCurrency);

            Assert.True(subject1 == subject2);
        }

        [Fact]
        public void Should_ReturnFalseIfObjectsAreNotTheSame_When_EqualOperator()
        {
            var subject1 = new Money(MoneyAmount, MoneyCurrency);
            var subject2 = new Money(MoneyAmount * 123, MoneyCurrency);

            Assert.False(subject1 == subject2);
        }

        [Fact]
        public void Should_ReturnTrueIfObjectsAreNotTheSame_When_NotEqualOperator()
        {
            var subject1 = new Money(MoneyAmount, MoneyCurrency);
            var subject2 = new Money(MoneyAmount * 123, MoneyCurrency);

            Assert.True(subject1 != subject2);
        }

        [Fact]
        public void Should_ReturnFalseIfObjectsAreTheSame_When_NotEqualOperator()
        {
            var subject1 = new Money(MoneyAmount, MoneyCurrency);
            var subject2 = new Money(MoneyAmount, MoneyCurrency);

            Assert.False(subject1 != subject2);
        }
    }
}
