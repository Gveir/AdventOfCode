using Xunit;

namespace AdventOfCode04.Tests
{
    public class PasswordValidatorTests
    {
        [Theory]
        [InlineData("122345", true)]
        [InlineData("111123", false)]
        [InlineData("135679", false)]
        [InlineData("111111", false)]
        [InlineData("223450", false)]
        [InlineData("123789", false)]
        [InlineData("112233", true)]
        [InlineData("123444", false)]
        [InlineData("111122", true)]
        public void Validate(string password, bool expectedOutput)
        {
            Assert.Equal(expectedOutput, PasswordValidator.Validate(password));
        }

        [Fact]
        public void CountValidPasswordsInRange()
        {
            int from = 171309;
            int to = 643603;

            int count = 0;

            for (int i = from; i <= to; i++)
            {
                if (PasswordValidator.Validate(i.ToString()))
                {
                    count++;
                }
            }

            Assert.Equal(1111, count);
        }
    }
}
