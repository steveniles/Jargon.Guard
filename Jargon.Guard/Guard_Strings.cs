using System;
using System.Linq;

namespace Jargon.Guard
{
    public static partial class Guard
    {
        /// <summary>Ensures the <c>string</c> is not empty.</summary>
        /// <remarks>This will not prevent the <c>string</c> from being non-empty whitespace; It only prevents the <c>string</c> from being <c>string.Empty</c>.</remarks>
        /// <param name="parameter">The <c>string</c> that shouldn't be empty.</param>
        /// <param name="parameterName">Optional. The name of the <c>string</c> that shouldn't be empty.</param>
        /// <param name="errorMessage">Optional. The error message to use if the <c>string</c> is empty.</param>
        /// <returns>Returns the <c>string</c>.</returns>
        /// <exception cref="ArgumentException">Thrown when the <c>string</c> is empty.</exception>
        public static string CannotBeEmpty(this string parameter, string parameterName = default, string errorMessage = "String cannot be empty.") =>
            parameter?.Length is 0 ? throw new ArgumentException(errorMessage, parameterName) : parameter;

        /// <summary>Ensures the <c>string</c> is not blank (non-empty whitespace).</summary>
        /// <remarks>This will not prevent the <c>string</c> from being <c>string.Empty</c>; It only prevents the <c>string</c> from being non-empty whitespace.</remarks>
        /// <param name="parameter">The <c>string</c> that shouldn't be blank.</param>
        /// <param name="parameterName">Optional. The name of the <c>string</c> that shouldn't be blank.</param>
        /// <param name="errorMessage">Optional. The error message to use if the <c>string</c> is blank.</param>
        /// <returns>Returns the <c>string</c>.</returns>
        /// <exception cref="ArgumentException">Thrown when the <c>string</c> is non-empty whitespace.</exception>
        public static string CannotBeBlank(this string parameter, string parameterName = default, string errorMessage = "String cannot be blank.") =>
            parameter?.Length > 0 && parameter.All(char.IsWhiteSpace) ? throw new ArgumentException(errorMessage, parameterName) : parameter;
    }
}