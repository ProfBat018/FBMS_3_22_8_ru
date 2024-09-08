namespace TechCommerce.ViewModels;

public record ProductViewModel(
    string Name,
    string? Description,
    decimal Price
);