using System;
using Xunit;

namespace Jargon.Guard.UnitTests
{
    public class GuidCannotBeEmpty
    {
        [Fact]
        public void ReturnsSameGuid()
        {
            Guid thing = Guid.NewGuid();
            Assert.Equal(thing, thing.CannotBeEmpty());
        }

        [Fact]
        public void ThrowsWhenEmpty()
        {
            Guid thing = Guid.Empty;
            Assert.Throws<ArgumentException>(() => thing.CannotBeEmpty());
        }

        [Fact]
        public void SetsExceptionParameterName()
        {
            Guid thing = Guid.Empty;
            Assert.Throws<ArgumentException>(null, () => thing.CannotBeEmpty());
            Assert.Throws<ArgumentException>("thing", () => thing.CannotBeEmpty("thing"));
        }

        [Fact]
        public void SetsExceptionMessage()
        {
            Guid thing = Guid.Empty;
            Assert.Equal("Guid cannot be empty.", Assert.Throws<ArgumentException>(() => thing.CannotBeEmpty()).Message);
            Assert.Equal("Guid cannot be empty.\r\nParameter name: thing", Assert.Throws<ArgumentException>(() => thing.CannotBeEmpty("thing")).Message);
            Assert.Equal("Error!", Assert.Throws<ArgumentException>(() => thing.CannotBeEmpty(errorMessage: "Error!")).Message);
            Assert.Equal("Error!\r\nParameter name: thing", Assert.Throws<ArgumentException>(() => thing.CannotBeEmpty("thing", "Error!")).Message);
        }
    }
}