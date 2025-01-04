using Monolit.Checkout.Domain.Dtos.CreateOrder;
using Monolit.Checkout.Domain.Entities;
using Monolit.Checkout.Repository;
using Monolit.GeneralDomain.Gateways.ProductGateway;

namespace Monolit.Checkout.UseCases.CreateOrderUseCase;

public class CreateOrderUseCase
{
    private readonly IProductGateway _productService;
    private readonly IOrderRepository _orderRepository;

    public CreateOrderUseCase(
        IProductGateway productService,
        IOrderRepository orderRepository)
    {
        _productService = productService;
        _orderRepository = orderRepository;
    }

    public async Task<CreatedOrderUseCaseDto> Execute(CreateOrderUseCaseDto order)
    {
        List<OrderItemEntity> products = new List<OrderItemEntity>();
        
        try
        {
            foreach (var product in order.Products)
            {
                var productModel = await _productService.GetProduct(product.Id);
                OrderItemEntity productMapped = new OrderItemEntity
                {
                    Product = new ProductEntity 
                    {
                        Id = productModel.Id,
                        Name = productModel.Name,
                        Price = productModel.Price
                    },
                    Quantity = product.Quantity
                };
                products.Add(productMapped);
            }
        }
        catch (System.Exception)
        {
            throw;
        }

        OrderEntity newOrder = new OrderEntity
        {
            ClientId = order.ClientId,
            Products = products,
            Status = OrderStatus.Pending,
        }.CalcTotal();

        try
        {
            var createdOrder = await _orderRepository.CreateOrder(newOrder);
            return new CreatedOrderUseCaseDto(){
                OrderId = createdOrder.Id,
            };
        }
        catch (System.Exception)
        {
            
            throw;
        }
    }
}
