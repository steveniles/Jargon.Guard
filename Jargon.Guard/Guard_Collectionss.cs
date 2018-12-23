using System;
using System.Collections;

namespace Jargon.Guard
{
    public static partial class Guard
    {
        /// <summary>Ensures the collection is not empty.</summary>
        /// <remarks>This will not prevent the collection from being <c>null</c>; It only prevents the collection from being empty.</remarks>
        /// <typeparam name="TCollection">The type of the collection <paramref name="parameter"/>. Must be an IEnumerable.</typeparam>
        /// <param name="parameter">The collection that shouldn't be empty.</param>
        /// <param name="parameterName">Optional. The name of the collection that shouldn't be empty.</param>
        /// <param name="errorMessage">Optional. The error message to use if the collection is empty.</param>
        /// <returns>Returns the collection.</returns>
        /// <exception cref="ArgumentException">Thrown when the collection is empty.</exception>
        public static TCollection CannotBeEmpty<TCollection>(this TCollection parameter, string parameterName = default, string errorMessage = "Collection cannot be empty.") where TCollection : IEnumerable =>
            parameter?.GetEnumerator().MoveNext() is false ? throw new ArgumentException(errorMessage, parameterName) : parameter;
    }
}