using System;

namespace Jargon.Guard
{
    /// <summary>Provides a set of simple guard clauses for method parameters.</summary>
    public static partial class Guard
    {
        /// <summary>Ensures the <paramref name="parameter"/> is not <c>null</c>.</summary>
        /// <typeparam name="TClass">The type of the <paramref name="parameter"/>. Must be a reference type.</typeparam>
        /// <param name="parameter">The variable that shouldn't be <c>null</c>.</param>
        /// <param name="parameterName">Optional. The name of the variable that shouldn't be <c>null</c>.</param>
        /// <param name="errorMessage">Optional. The error message to use if the variable is <c>null</c>.</param>
        /// <returns>Returns the <paramref name="parameter"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the <paramref name="parameter"/> is <c>null</c>.</exception>
        public static TClass CannotBeNull<TClass>(this TClass parameter, string parameterName = default, string errorMessage = "Object cannot be null.") where TClass : class =>
            parameter ?? throw new ArgumentNullException(parameterName, errorMessage);

        /// <summary>Ensures the <paramref name="parameter"/> is not <c>null</c>.</summary>
        /// <typeparam name="TStruct">The type of the nullable <paramref name="parameter"/>. Must be a value type.</typeparam>
        /// <param name="parameter">The variable that shouldn't be <c>null</c>.</param>
        /// <param name="parameterName">Optional. The name of the variable that shouldn't be <c>null</c>.</param>
        /// <param name="errorMessage">Optional. The error message to use if the variable is <c>null</c>.</param>
        /// <returns>Returns the <paramref name="parameter"/> as non-nullable type <typeparamref name="TStruct"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the <paramref name="parameter"/> is <c>null</c>.</exception>
        public static TStruct CannotBeNull<TStruct>(this TStruct? parameter, string parameterName = default, string errorMessage = "Value cannot be null.") where TStruct : struct =>
            parameter ?? throw new ArgumentNullException(parameterName, errorMessage);
    }
}