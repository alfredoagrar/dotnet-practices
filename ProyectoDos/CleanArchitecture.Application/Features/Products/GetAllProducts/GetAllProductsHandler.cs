using AutoMapper;
using CleanArchitecture.Application.Repositories;
using MediatR;

namespace CleanArchitecture.Application.Features.Products.GetAllProducts
{
    /// <summary>
    /// Handles the retrieval of all products by implementing the <see cref="IRequestHandler{GetAllProductsRequest, List{GetAllProductsResponse}}"/> interface.
    /// </summary>
    internal class GetAllProductsHandler : IRequestHandler<GetAllProductsRequest, List<GetAllProductsResponse>>
    {
        private readonly IProductRepository _productsRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllProductsHandler"/> class.
        /// </summary>
        /// <param name="productsRepository">The repository used to retrieve product entities.</param>
        /// <param name="mapper">The AutoMapper instance used to map between product entities and response objects.</param>
        public GetAllProductsHandler(IProductRepository productsRepository, IMapper mapper)
        {
            _productsRepository = productsRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the request to retrieve all products.
        /// </summary>
        /// <param name="request">The request to retrieve all products.</param>
        /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
        /// <returns>A <see cref="Task{List{GetAllProductsResponse}}"/> representing the asynchronous operation, with a result of the list of product responses.</returns>
        public async Task<List<GetAllProductsResponse>> Handle(GetAllProductsRequest request, CancellationToken cancellationToken)
        {
            // Retrieve all product entities from the repository
            var products = await _productsRepository.GetAll(cancellationToken);

            // Map the product entities to a list of response objects
            return _mapper.Map<List<GetAllProductsResponse>>(products);
        }
    }
}
