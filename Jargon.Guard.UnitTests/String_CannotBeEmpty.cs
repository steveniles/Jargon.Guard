using System;
using Xunit;

namespace Jargon.Guard.UnitTests
{
    public class String_CannotBeEmpty
    {
        [Fact]
        public void ReturnsSameString()
        {
            string thing = "thing";
            Assert.Same(thing, thing.CannotBeEmpty());
        }

        [Fact]
        public void DoesNotThrowWhenNull()
        {
            string thing = null;
            thing.CannotBeEmpty();
        }

        [Fact]
        public void ThrowsWhenEmpty()
        {
            string thing = string.Empty;
            Assert.Throws<ArgumentException>(() => thing.CannotBeEmpty());
        }

        [Fact]
        public void SetsExceptionParameterName()
        {
            string thing = string.Empty;
            Assert.Throws<ArgumentException>(null, () => thing.CannotBeEmpty());
            Assert.Throws<ArgumentException>("thing", () => thing.CannotBeEmpty("thing"));
        }

        [Fact]
        public void SetsExceptionMessage()
        {
            string thing = string.Empty;
            Assert.Equal("String cannot be empty.", Assert.Throws<ArgumentException>(() => thing.CannotBeEmpty()).Message);
            Assert.Equal("String cannot be empty.\r\nParameter name: thing", Assert.Throws<ArgumentException>(() => thing.CannotBeEmpty("thing")).Message);
            Assert.Equal("Error!", Assert.Throws<ArgumentException>(() => thing.CannotBeEmpty(errorMessage: "Error!")).Message);
            Assert.Equal("Error!\r\nParameter name: thing", Assert.Throws<ArgumentException>(() => thing.CannotBeEmpty("thing", "Error!")).Message);
        }
    }
}