namespace Basket.API.Models;

public class ShoppingCartItem
{
    public int Quantity { get; set; } = default!;
    public string Color { get; set; } = default!;
    public decimal Price { get; set; } = default!;
    public Guid ProductId { get; set; } = default!;
    public string ProductName { get; set; } = default!;

    public ShoppingCartItem(Guid productId, int quantity, string color, decimal price, string productName)
    {
        this.ProductId = productId;
        this.Quantity = quantity;
        this.Color = color;
        this.Price = price;
        this.ProductName = productName;
    }
}
