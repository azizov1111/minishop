using Domain.Models;
using Infrastructure.Repositories;


var o = new ProductRepository();
var l = new CategoryRepository();

while (true)
{
    System.Console.WriteLine();
        System.Console.WriteLine("1 Get All Product");
        System.Console.WriteLine("2 Get Product by ID");
        System.Console.WriteLine("3 Get All Categories");
        System.Console.WriteLine("4 Get Category by ID");
        System.Console.WriteLine("5 Add Category");
        System.Console.WriteLine("6 Add Product");
     int a = Convert.ToInt32(Console.ReadLine());
    switch (a)
    {
        case 1:
            var products = o.GetAllProducts();
            foreach (var product in products)
            {
                Console.WriteLine($"Id: {product.id}, Name: {product.name}, Price: {product.price}, Quantity: {product.quantity}, CategoryId: {product.categoryId}");
            }
            break;
        case 2:
            Console.Write("Enter product ID: ");
            int productId = Convert.ToInt32(Console.ReadLine());
            var productById = o.GetProductById(productId);
            if (productById != null)
            {
                Console.WriteLine($"Id: {productById.id}, Name: {productById.name}, Price: {productById.price}, Quantity: {productById.quantity}, CategoryId: {productById.categoryId}");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
            break;
        case 3:
            var categories = l.GetAllCategories();
            foreach (var category in categories)
            {
                Console.WriteLine($"Id: {category.id}, Name: {category.name}");
            }
            break;
        case 4:
            Console.Write("Enter category ID: ");
            int categoryId = Convert.ToInt32(Console.ReadLine());
            var categoryById = l.GetCategoryById(categoryId);
            if (categoryById != null)
            {
                Console.WriteLine($"Id: {categoryById.id}, Name: {categoryById.name}");
            }
            else
            {
                Console.WriteLine("Category not found.");
            }
            break;
        case 5:
            Console.Write("Enter category name: ");
            string categoryName = Console.ReadLine();
            var newCategory = new category { name = categoryName };
            l.AddCategory(newCategory);
            Console.WriteLine("Category added.");
            break;
        case 6:
            Console.Write("Enter product name: ");
            string productName = Console.ReadLine();
            Console.Write("Enter product price: ");
            decimal productPrice = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Enter product quantity: ");
            int productQuantity = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter category ID: ");
            int productCategoryId = Convert.ToInt32(Console.ReadLine());
            var newProduct = new product { name = productName, price = productPrice, quantity = productQuantity, categoryId = productCategoryId };
            o.AddProduct(newProduct);
            Console.WriteLine("Product added.");
            break;
}
}