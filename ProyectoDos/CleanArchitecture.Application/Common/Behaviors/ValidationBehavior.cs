using CleanArchitecture.Application.Common.Exceptions;
using FluentValidation;
using MediatR;

namespace CleanArchitecture.Application.Common.Behaviors
{
    /// <summary>
    /// A behavior that handles validation for requests using FluentValidation.
    /// Implements the <see cref="IPipelineBehavior{TRequest, TResponse}"/> interface.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request.</typeparam>
    /// <typeparam name="TResponse">The type of the response.</typeparam>
    public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationBehavior{TRequest, TResponse}"/> class.
        /// </summary>
        /// <param name="validators">A collection of validators for the request.</param>
        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        /// <summary>
        /// Handles the request by validating it and then calling the next handler in the pipeline.
        /// </summary>
        /// <param name="request">The request to handle.</param>
        /// <param name="next">A delegate to invoke the next handler in the pipeline.</param>
        /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
        /// <returns>The response from the next handler in the pipeline.</returns>
        /// <exception cref="BadRequestException">Thrown when validation errors are detected.</exception>
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (!_validators.Any()) return await next();

            var context = new ValidationContext<TRequest>(request);

            var errors = _validators
                .Select(x => x.Validate(context))
                .SelectMany(x => x.Errors)
                .Where(x => x != null)
                .Select(x => x.ErrorMessage)
                .Distinct()
                .ToArray();

            if (errors.Any())
                throw new BadRequestException(errors);

            return await next();
        }
    }
}
