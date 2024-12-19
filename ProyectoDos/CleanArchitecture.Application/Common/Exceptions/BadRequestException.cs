namespace CleanArchitecture.Application.Common.Exceptions
{
    /// <summary>
    /// Represents an exception that is thrown when a bad request is encountered.
    /// </summary>
    public class BadRequestException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BadRequestException"/> class with a specific error message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public BadRequestException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="BadRequestException"/> class with multiple error details.
        /// </summary>
        /// <param name="errors">An array of error details that explain why the request is considered bad.</param>
        public BadRequestException(string[] errors) : base("Multiple errors occurred. See error details.")
        {
            Errors = errors;
        }

        /// <summary>
        /// Gets or sets the array of error details that explain why the request is considered bad.
        /// </summary>
        public string[] Errors { get; set; }
    }
}
