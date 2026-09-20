using OnlineShop.Context;
using OnlineShop.Entities;
using static System.Net.Mime.MediaTypeNames;

using var context = new AppDbContext();

// Создать User без FirstName
try
{
    var user = new User
    {
        Email = "test1@gmail.com"
    };

    context.Users.Add(user);
    context.SaveChanges();

}
catch (Exception ex)
{
    Console.WriteLine("Тест 1: FirstName обязателен");
}

// Создать двух пользователей с одинаковым Email
try
{
    var user1 = new User
    {
        FirstName = "Ali",
        Email = "test2@gmail.com"
    };

    var user2 = new User
    {
        FirstName = "Ali2",
        Email = "test2@gmail.com"
    };

    context.Users.AddRange(user1, user2);
    context.SaveChanges();
}
catch (Exception ex)
{
    Console.WriteLine("Тест 2: Пользователь с такой почтой существует");
}

// Создать Product с Price = -100
try
{
    var product = new Product
    {
        Name = "Test Product",
        Price = -100,
        StockQuantity = 10,
        CategoryId = 1
    };

    context.Products.Add(product);
    context.SaveChanges();
}
catch (Exception ex)
{
    Console.WriteLine("Тест 3: Отрицательная цена запрещена");
}

// Product с StockQuantity = -5
try
{
    var product = new Product
    {
        Name = "Test Product 2",
        Price = 100,
        StockQuantity = -5,
        CategoryId = 1
    };

    context.Products.Add(product);
    context.SaveChanges();
}
catch (Exception ex)
{
    Console.WriteLine("Тест 4: Отрицательный StockQuantity запрещен");
}

// Review с Rating = 10
try
{
    var review = new Review
    {
        UserId = 1,
        ProductId = 1,
        Rating = 10,
        Comment = "Bad"
    };

    context.Reviews.Add(review);
    context.SaveChanges();
}
catch (Exception ex)
{
    Console.WriteLine("Тест 5: Rating должен быть от 1 до 5");
}

// Второй Review для того же UserId + ProductId
try
{
    var review1 = new Review
    {
        UserId = 1,
        ProductId = 1,
        Rating = 5,
        Comment = "First review"
    };

    var review2 = new Review
    {
        UserId = 1,
        ProductId = 1,
        Rating = 4,
        Comment = "Second review"
    };

    context.Reviews.AddRange(review1, review2);
    context.SaveChanges();
}
catch (Exception ex)
{
    Console.WriteLine("Тест 6: UserId + ProductId должны быть уникальными");
}

// OrderItem с Quantity = 0
try
{
    var orderItem = new OrderItem
    {
        OrderId = 1,
        ProductId = 1,
        Quantity = 0,
        UnitPrice = 100
    };

    context.OrderItems.Add(orderItem);
    context.SaveChanges();
}
catch (Exception ex)
{
    Console.WriteLine("Тест 7: Quantity должен быть > 0");
}

// OrderItem с UnitPrice = -50
try
{
    var orderItem = new OrderItem
    {
        OrderId = 1,
        ProductId = 1,
        Quantity = 1,
        UnitPrice = -50
    };

    context.OrderItems.Add(orderItem);
    context.SaveChanges();
}
catch (Exception ex)
{
    Console.WriteLine("Тест 8: UnitPrice должен быть > 0");
}

// Удалить User, у которого есть Orders
try
{
    var user = context.Users.FirstOrDefault(u => u.Id == 1);

    context.Users.Remove(user);
    context.SaveChanges();
}
catch (Exception ex)
{
    Console.WriteLine("Тест 9: User с Orders удалить нельзя");
}