using System;
using Xunit;

namespace Jargon.Guard.UnitTests
{
    public class ObjectNullableCannotBeNull
    {
        [Fact]
        public void ReturnsSameValue()
        {
            Guid? thing = Guid.NewGuid();
            Assert.Equal(thing.Value, thing.CannotBeNull());
        }

        [Fact]
        public void ThrowsWhenNull()
        {
            int? thing = null;
            Assert.Throws<ArgumentNullException>(() => thing.CannotBeNull());
        }

        [Fact]
        public void SetsExceptionParameterName()
        {
            int? thing = null;
            Assert.Throws<ArgumentNullException>(null, () => thing.CannotBeNull());
            Assert.Throws<ArgumentNullException>("thing", () => thing.CannotBeNull("thing"));
        }

        [Fact]
        public void SetsExceptionMessage()
        {
            int? thing = null;
            Assert.Equal("Value cannot be null.", Assert.Throws<ArgumentNullException>(() => thing.CannotBeNull()).Message);
            Assert.Equal("Value cannot be null.\r\nParameter name: thing", Assert.Throws<ArgumentNullException>(() => thing.CannotBeNull("thing")).Message);
            Assert.Equal("Error!", Assert.Throws<ArgumentNullException>(() => thing.CannotBeNull(errorMessage: "Error!")).Message);
            Assert.Equal("Error!\r\nParameter name: thing", Assert.Throws<ArgumentNullException>(() => thing.CannotBeNull("thing", "Error!")).Message);
        }
    }
}