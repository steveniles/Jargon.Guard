using System;
using Xunit;

namespace Jargon.Guard.UnitTests
{
    public class Collection_CannotBeEmpty
    {
        [Fact]
        public void ReturnsSameCollection()
        {
            object[] thing = { null };
            Assert.Same(thing, thing.CannotBeEmpty());
        }

        [Fact]
        public void DoesNotThrowWhenNull()
        {
            object[] thing = null;
            thing.CannotBeEmpty();
        }

        [Fact]
        public void ThrowsWhenEmpty()
        {
            object[] thing = Array.Empty<object>();
            Assert.Throws<ArgumentException>(() => thing.CannotBeEmpty());
        }

        [Fact]
        public void SetsExceptionParameterName()
        {
            object[] thing = Array.Empty<object>();
            Assert.Throws<ArgumentException>(null, () => thing.CannotBeEmpty());
            Assert.Throws<ArgumentException>("thing", () => thing.CannotBeEmpty("thing"));
        }

        [Fact]
        public void SetsExceptionMessage()
        {
            object[] thing = Array.Empty<object>();
            Assert.Equal("Collection cannot be empty.", Assert.Throws<ArgumentException>(() => thing.CannotBeEmpty()).Message);
            Assert.Equal("Collection cannot be empty.\r\nParameter name: thing", Assert.Throws<ArgumentException>(() => thing.CannotBeEmpty("thing")).Message);
            Assert.Equal("Error!", Assert.Throws<ArgumentException>(() => thing.CannotBeEmpty(errorMessage: "Error!")).Message);
            Assert.Equal("Error!\r\nParameter name: thing", Assert.Throws<ArgumentException>(() => thing.CannotBeEmpty("thing", "Error!")).Message);
        }
    }
}