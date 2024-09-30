public record AddProductDTO(string name, string imageUrl, string description, decimal price, int[]? categoryIds=null);

