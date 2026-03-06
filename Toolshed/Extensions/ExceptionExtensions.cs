using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text;

namespace Toolshed.Extensions;

/// <summary>
/// Provides extension methods for validating object state and throwing exceptions related to invalid operations.
/// </summary>
/// <remarks>Use this class to enforce preconditions and guard against invalid states by throwing exceptions when
/// necessary. The methods are intended to simplify validation logic and improve code readability.</remarks>
public static class InvalidOperationExceptionExtensions
{
    extension(InvalidOperationException)
    {
        /// <summary>
        /// Throws an exception if the specified object is null.
        /// </summary>
        /// <remarks>Use this method to enforce non-null arguments or state. This method is typically used
        /// to validate input and prevent null reference errors.</remarks>
        /// <param name="obj">The object to check for null. If this parameter is null, an exception is thrown.</param>
        /// <param name="message">An optional message that describes the error. If provided, it is used as the exception message.</param>
        /// <param name="innerException">An optional inner exception to include in the thrown exception.</param>
        /// <exception cref="InvalidOperationException">Thrown if <paramref name="obj"/> is null.</exception>
        public static void ThrowIfNull([NotNull] object? obj, string? message = null, Exception? innerException = null)
        {
            if (obj is null)
            {
                throw new InvalidOperationException(message, innerException);
            }
        }
    }
}