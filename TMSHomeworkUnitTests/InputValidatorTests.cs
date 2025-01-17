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
        [InlineData("Ma", "123456789", "123456789")]
        [InlineData("Mark", "123456789", "123")]
        [InlineData("Mark", "puzzle", "puzzle")]
        [InlineData("Mark", "zzzzzzzz", "zzzzzzzz")]
        [InlineData("", "", "")]
        [InlineData(null, null, null)]
        [InlineData("ksjdfhksdfkhsdkfhskdjhf", "123456789", "123456789")]
        [InlineData("ksjd", "18263816182638126381263816238761283", "123456789")]
        public void IsCorrectInput_Fail(string name, string password, string confirmPassword)
        {
            var result = InputValidator.IsCorrectInput(name, password, confirmPassword);
            Assert.False(result);
        }

        [Fact]
        public void ValidateLogin_ShouldWrongLoginExceptionThrows()
        {
            Assert.Throws<WrongLoginException>(() => InputValidator.ValidateLogin("Ma", InputValidator.LoginPattern));
        }

        [Fact]
        public void ValidatePassword_ShouldWrongPasswordExceptionThrows()
        {
            Assert.Throws<WrongPasswordException>(() => InputValidator.ValidatePassword("password", "password", InputValidator.PasswordPattern));
        }
    }
}