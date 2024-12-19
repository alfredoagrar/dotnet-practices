using AutoMapper;
using CleanArchitecture.Application.Repositories;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Features.Products.CreateProduct
{
    /// <summary>
    /// Handles the creation of a new product by implementing the <see cref="IRequestHandler{CreateProductRequest, CreateProductResponse}"/> interface.
    /// </summary>
    public sealed class CreateProductHandler : IRequestHandler<CreateProductRequest, CreateProductResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateProductHandler"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work used to commit changes to the database.</param>
        /// <param name="productRepository">The repository used to manage product entities.</param>
        /// <param name="mapper">The AutoMapper instance used to map between request and entity objects.</param>
        public CreateProductHandler(IUnitOfWork unitOfWork, IProductRepository productRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the creation of a new product.
        /// </summary>
        /// <param name="request">The request containing the details of the product to create.</param>
        /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
        /// <returns>A <see cref="Task{CreateProductResponse}"/> representing the asynchronous operation, with a result of the created product response.</returns>
        public async Task<CreateProductResponse> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            // Map the request to a Product entity
            var product = _mapper.Map<Product>(request);
            DateTime now = DateTime.Now;
            product.Created = now;
            product.CreatedBy = "Default";
            product.LastModified = now;
            product.LastModifiedBy = "Default";

            // Create the product entity in the repository
            _productRepository.Create(product);

            // Save changes in the unit of work
            await _unitOfWork.Save(cancellationToken);

            // Map the created Product entity to a response
            return _mapper.Map<CreateProductResponse>(product);
        }
    }
}
