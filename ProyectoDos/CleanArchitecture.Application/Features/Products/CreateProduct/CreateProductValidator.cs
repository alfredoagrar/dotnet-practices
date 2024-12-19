using FluentValidation;

namespace CleanArchitecture.Application.Features.Products.CreateProduct
{
    /// <summary>
    /// Validator for <see cref="CreateProductRequest"/> using FluentValidation.
    /// </summary>
    public sealed class CreateProductValidator : AbstractValidator<CreateProductRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateProductValidator"/> class and configures validation rules.
        /// </summary>
        public CreateProductValidator()
        {
            // Rule that ensures the Name property is not empty and does not exceed 200 characters.
            RuleFor(x => x.name) 
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(x => x.type)
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(x => x.description)
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(x => x.data)
                .NotEmpty()
                .MaximumLength(200);
        }
    }
}
