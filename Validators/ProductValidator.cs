using ProductConsoleOOP.Models;

namespace ProductConsoleOOP.Validators;

public class ProductValidator
{
    public List<string> Validate(Product product)
    {
        List<string> errors = new List<string>();

        if (string.IsNullOrWhiteSpace(product.Name))
        {
            errors.Add("Product name is required.");
        }

        if (product.Price <= 0)
        {
            errors.Add("Product price must be greater than 0.");
        }

        if (product.Quantity < 0)
        {
            errors.Add("Product quantity cannot be negative.");
        }

        return errors;
    }

    public bool IsValid(Product product)
    {
        List<string> errors = Validate(product);
        return errors.Count == 0;
    }
}
