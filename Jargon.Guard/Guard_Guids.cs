using System;

namespace Jargon.Guard
{
    public static partial class Guard
    {
        /// <summary>Ensures the <c>Guid</c> is not empty.</summary>
        /// <param name="parameter">The <c>Guid</c> that shouldn't be empty.</param>
        /// <param name="parameterName">Optional. The name of the <c>Guid</c> that shouldn't be empty.</param>
        /// <param name="errorMessage">Optional. The error message to use if the <c>Guid</c> is empty.</param>
        /// <returns>Returns the <c>Guid</c>.</returns>
        /// <exception cref="ArgumentException">Thrown when the <c>Guid</c> is empty.</exception>
        public static Guid CannotBeEmpty(this Guid parameter, string parameterName = default, string errorMessage = "Guid cannot be empty.") =>
            parameter == Guid.Empty ? throw new ArgumentException(errorMessage, parameterName) : parameter;

        /// <summary>Ensures the <c>Guid?</c> is not empty.</summary>
        /// <remarks>This will not prevent the <c>Guid?</c> from being <c>null</c>; It only prevents the <c>Guid?</c> from being <c>Guid.Empty</c>.</remarks>
        /// <param name="parameter">The <c>Guid?</c> that shouldn't be empty.</param>
        /// <param name="parameterName">Optional. The name of the <c>Guid?</c> that shouldn't be empty.</param>
        /// <param name="errorMessage">Optional. The error message to use if the <c>Guid?</c> is empty.</param>
        /// <returns>Returns the <c>Guid?</c>.</returns>
        /// <exception cref="ArgumentException">Thrown when the <c>Guid?</c> is empty.</exception>
        public static Guid? CannotBeEmpty(this Guid? parameter, string parameterName = default, string errorMessage = "Guid cannot be empty.") =>
            parameter == Guid.Empty ? throw new ArgumentException(errorMessage, parameterName) : parameter;
    }
}