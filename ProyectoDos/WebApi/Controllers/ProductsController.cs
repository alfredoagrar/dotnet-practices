using CleanArchitecture.Application.Features.Products.CreateProduct;
using CleanArchitecture.Application.Features.Products.DeleteProduct;
using CleanArchitecture.Application.Features.Products.GetAllProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/products")] // Mejor usar una ruta representativa
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Creates a new product.
    /// </summary>
    /// <param name="request">The product creation request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A response containing the created product.</returns>
    [HttpPost]
    public async Task<ActionResult<CreateProductResponse>> Create(
        [FromBody] CreateProductRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return CreatedAtAction(nameof(GetAll), new { id = response.Id }, response); // 201 Created con la URL del recurso recién creado
    }

    /// <summary>
    /// Retrieves all products.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A list of all products.</returns>
    [HttpGet]
    public async Task<ActionResult<List<GetAllProductsResponse>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllProductsRequest(), cancellationToken);
        return Ok(response); // 200 OK
    }

    /// <summary>
    /// Deletes a product by ID.
    /// </summary>
    /// <param name="id">The ID of the product to delete.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>An empty response if successful.</returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(
        [FromRoute] int id, // Mejor usar el ID desde la ruta
        CancellationToken cancellationToken)
    {
        var request = new DeleteProductRequest { Id = id };
        await _mediator.Send(request, cancellationToken);
        return NoContent(); // 204 No Content
    }
}
