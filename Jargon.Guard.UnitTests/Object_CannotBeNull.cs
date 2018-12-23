using System;
using Xunit;

namespace Jargon.Guard.UnitTests
{
    public class Object_CannotBeNull
    {
        [Fact]
        public void ReturnsSameObject()
        {
            object thing = new object();
            Assert.Same(thing, thing.CannotBeNull());
        }

        [Fact]
        public void ThrowsWhenNull()
        {
            object thing = null;
            Assert.Throws<ArgumentNullException>(() => thing.CannotBeNull());
        }

        [Fact]
        public void SetsExceptionParameterName()
        {
            object thing = null;
            Assert.Throws<ArgumentNullException>(null, () => thing.CannotBeNull());
            Assert.Throws<ArgumentNullException>("thing", () => thing.CannotBeNull("thing"));
        }

        [Fact]
        public void SetsExceptionMessage()
        {
            object thing = null;
            Assert.Equal("Object cannot be null.", Assert.Throws<ArgumentNullException>(() => thing.CannotBeNull()).Message);
            Assert.Equal("Object cannot be null.\r\nParameter name: thing", Assert.Throws<ArgumentNullException>(() => thing.CannotBeNull("thing")).Message);
            Assert.Equal("Error!", Assert.Throws<ArgumentNullException>(() => thing.CannotBeNull(errorMessage: "Error!")).Message);
            Assert.Equal("Error!\r\nParameter name: thing", Assert.Throws<ArgumentNullException>(() => thing.CannotBeNull("thing", "Error!")).Message);
        }
    }
}