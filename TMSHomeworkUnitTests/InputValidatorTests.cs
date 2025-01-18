using TMSHomework;

namespace TMSHomeworkUnitTests
{
    public class InputValidatorTests
    {
        [Theory]
        [InlineData("Mark", "123456789", "123456789")]
        [InlineData("Mark", "puzzle1950", "puzzle1950")]
        [InlineData("Joe", "sUpe_123rman", "sUpe_123rman")]
        public void IsCorrectInput_Success(string name, string password, string confirmPassword)
        {
            var result = InputValidator.IsCorrectInput(name, password, confirmPassword);
            Assert.True(result);
        }

        [Theory]
        [InlineData("Ma", "password", "password")]
        [InlineData("Mark", "password", "password")]
        [InlineData("Mark", "pass1", "pass1")]
        [InlineData("", "", "")]
        [InlineData(null, null, null)]
        [InlineData("ksjdfhksdfkhsdkfhskdjhf", "123456789", "123456789")]
        [InlineData("ksjd", "18263816182638126381263816238761283", "123456789")]
        public void IsCorrectInput_Fail(string name, string password, string confirmPassword)
        {
            var result = InputValidator.IsCorrectInput(name, password, confirmPassword);
            Assert.False(result);
        }

        [Theory]
        [InlineData("")]
        [InlineData("Ma")]
        [InlineData("Mark!")]
        [InlineData(null)]
        [InlineData("qiweyiuqwiyiqwvcyviqwvycviqwyi")]
        public void ValidateLogin_ShouldWrongLoginExceptionThrows(string name)
        {
            Assert.Throws<WrongLoginException>(() => InputValidator.ValidateLogin(name));
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("password", "password")]
        [InlineData("pass1", "pass1")]
        [InlineData("password1", "pass1")]
        [InlineData(null, null)]
        [InlineData("qiweyiuqwiyiqwvcyviqwvycviqwyi", "password")]
        public void ValidatePassword_ShouldWrongPasswordExceptionThrows(string password, string confirmPassword)
        {
            Assert.Throws<WrongPasswordException>(() => InputValidator.ValidatePassword(password, confirmPassword));
        }
    }
}