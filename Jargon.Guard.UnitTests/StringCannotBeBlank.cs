using System;
using Xunit;

namespace Jargon.Guard.UnitTests
{
    public class StringCannotBeBlank
    {
        [Fact]
        public void ReturnsSameString()
        {
            string thing = "thing";
            Assert.Same(thing, thing.CannotBeBlank());
        }

        [Fact]
        public void DoesNotThrowWhenNull()
        {
            string thing = null;
            thing.CannotBeBlank();
        }

        [Fact]
        public void DoesNotThrowWhenEmpty()
        {
            string thing = string.Empty;
            thing.CannotBeBlank();
        }

        [Fact]
        public void ThrowsWhenBlank()
        {
            string thing = "\t";
            Assert.Throws<ArgumentException>(() => thing.CannotBeBlank());
        }

        [Fact]
        public void SetsExceptionParameterName()
        {
            string thing = "\t";
            Assert.Throws<ArgumentException>(null, () => thing.CannotBeBlank());
            Assert.Throws<ArgumentException>("thing", () => thing.CannotBeBlank("thing"));
        }

        [Fact]
        public void SetsExceptionMessage()
        {
            string thing = "\t";
            Assert.Equal("String cannot be blank.", Assert.Throws<ArgumentException>(() => thing.CannotBeBlank()).Message);
            Assert.Equal("String cannot be blank.\r\nParameter name: thing", Assert.Throws<ArgumentException>(() => thing.CannotBeBlank("thing")).Message);
            Assert.Equal("Error!", Assert.Throws<ArgumentException>(() => thing.CannotBeBlank(errorMessage: "Error!")).Message);
            Assert.Equal("Error!\r\nParameter name: thing", Assert.Throws<ArgumentException>(() => thing.CannotBeBlank("thing", "Error!")).Message);
        }
    }
}