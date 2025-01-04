namespace Monolit.Checkout.Domain.Dtos.CreateOrder;

public class CreateOrderUseCaseDto
{
    public Guid ClientId { get; set; }
    public List<OrderProductDto> Products { get; set; } = new();
}

public class OrderProductDto
{
    public Guid Id { get; set; }
    public int Quantity { get; set; }
}

public class CreatedOrderUseCaseDto
{
    public Guid OrderId { get; set; }
}