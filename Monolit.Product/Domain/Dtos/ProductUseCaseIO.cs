namespace Monolit.Product.Domain.Dtos;

public class InputProductUseCase
{
    public string Name {get; set;} = string.Empty;
    public double Price {get; set;}
    public string Description {get; set;} = string.Empty;
}

public class OutputProductUseCase
{
    public Guid Id {get; set;}
    public string Name {get; set;} = string.Empty;
    public double Price {get; set;}
    public string Description {get; set;} = string.Empty;
}
