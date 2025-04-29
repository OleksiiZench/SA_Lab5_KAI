using FoodDelivery.BLL.Mapping;
using FoodDelivery.BLL.Models;
using FoodDelivery.BLL.Services;
using FoodDelivery.DAL.Data;
using FoodDelivery.DAL.UoW;
using Microsoft.Extensions.DependencyInjection;

namespace FoodDelivery.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Налаштовуємо DI-контейнер
            var services = new ServiceCollection();
            ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();

            // Отримуємо сервіси
            var dishService = serviceProvider.GetService<DishService>();
            var menuService = serviceProvider.GetService<MenuService>();
            var orderService = serviceProvider.GetService<OrderService>();

            // Створюємо базу даних, якщо вона ще не існує
            using (var context = serviceProvider.GetService<AppDbContext>())
            {
                context.Database.EnsureCreated();
            }

            bool isRunning = true;
            OrderDto currentOrder = null;

            while (isRunning)
            {
                Console.WriteLine("\nОберіть дію:");
                Console.WriteLine("1. Показати меню за днем тижня");
                Console.WriteLine("2. Показати страви за категорією");
                Console.WriteLine("3. Пошук страв за назвою");
                Console.WriteLine("4. Створити нове замовлення");
                Console.WriteLine("5. Додати страву до замовлення");
                Console.WriteLine("6. Переглянути поточне замовлення");
                Console.WriteLine("7. Вийти");
                Console.Write("Ваш вибір: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowMenuByDay(menuService);
                        break;
                    case "2":
                        ShowDishesByCategory(menuService);
                        break;
                    case "3":
                        SearchDishes(dishService);
                        break;
                    case "4":
                        currentOrder = CreateNewOrder(orderService);
                        break;
                    case "5":
                        if (currentOrder != null)
                            AddDishToOrder(orderService, dishService, currentOrder.Id);
                        else
                            Console.WriteLine("Спочатку створіть нове замовлення.");
                        break;
                    case "6":
                        if (currentOrder != null)
                            ViewCurrentOrder(orderService, currentOrder.Id);
                        else
                            Console.WriteLine("Немає активного замовлення.");
                        break;
                    case "7":
                        isRunning = false;
                        Console.WriteLine("Дякуємо за використання нашого застосунку!");
                        break;
                    default:
                        Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                        break;
                }
            }

            Console.ReadKey();
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            // Реєструємо DbContext
            services.AddDbContext<AppDbContext>();

            // Реєструємо AutoMapper
            services.AddAutoMapper(typeof(MappingProfile));

            // Реєструємо Unit of Work
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Реєструємо сервіси бізнес-логіки
            services.AddScoped<DishService>();
            services.AddScoped<MenuService>();
            services.AddScoped<OrderService>();
        }

        static void ShowMenuByDay(MenuService menuService)
        {
            Console.WriteLine("Введіть ID дня тижня (1-7):");
            if (int.TryParse(Console.ReadLine(), out int dayId))
            {
                var menu = menuService.GetMenuForDay(dayId);
                if (menu.Any())
                {
                    Console.WriteLine($"\nМеню на день {dayId}:");
                    foreach (var dish in menu)
                    {
                        Console.WriteLine($"- {dish.Name} ({dish.Price:C})");
                    }
                }
                else
                {
                    Console.WriteLine("Меню на цей день відсутнє.");
                }
            }
            else
            {
                Console.WriteLine("Невірний формат ID дня.");
            }
        }

        static void ShowDishesByCategory(MenuService menuService)
        {
            Console.WriteLine("Введіть ID категорії:");
            if (int.TryParse(Console.ReadLine(), out int categoryId))
            {
                var dishes = menuService.GetDishesByCategory(categoryId);
                if (dishes.Any())
                {
                    Console.WriteLine($"\nСтрави в категорії {categoryId}:");
                    foreach (var dish in dishes)
                    {
                        Console.WriteLine($"- {dish.Name} ({dish.Price:C}) - {dish.Description}");
                    }
                }
                else
                {
                    Console.WriteLine("Страви в цій категорії відсутні.");
                }
            }
            else
            {
                Console.WriteLine("Невірний формат ID категорії.");
            }
        }

        static void SearchDishes(DishService dishService)
        {
            Console.WriteLine("Введіть назву для пошуку:");
            string searchTerm = Console.ReadLine();
            var results = dishService.SearchDishesByName(searchTerm);
            if (results.Any())
            {
                Console.WriteLine("\nРезультати пошуку:");
                foreach (var dish in results)
                {
                    Console.WriteLine($"- {dish.Name} ({dish.Price:C})");
                }
            }
            else
            {
                Console.WriteLine("Нічого не знайдено.");
            }
        }

        static OrderDto CreateNewOrder(OrderService orderService)
        {
            var order = orderService.CreateOrder();
            Console.WriteLine($"Створено нове замовлення з ID: {order.Id}");
            return order;
        }

        static void AddDishToOrder(OrderService orderService, DishService dishService, int orderId)
        {
            Console.WriteLine("Введіть ID страви, яку хочете додати:");
            if (int.TryParse(Console.ReadLine(), out int dishId))
            {
                var dish = dishService.GetDishById(dishId);
                if (dish != null)
                {
                    Console.WriteLine("Введіть кількість:");
                    if (int.TryParse(Console.ReadLine(), out int quantity) && quantity > 0)
                    {
                        orderService.AddDishToOrder(orderId, dishId, quantity);
                        Console.WriteLine($"{quantity} x {dish.Name} додано до замовлення {orderId}.");
                    }
                    else
                    {
                        Console.WriteLine("Невірна кількість.");
                    }
                }
                else
                {
                    Console.WriteLine("Страва з таким ID не знайдена.");
                }
            }
            else
            {
                Console.WriteLine("Невірний формат ID страви.");
            }
        }

        static void ViewCurrentOrder(OrderService orderService, int orderId)
        {
            var orderItems = orderService.GetOrderItems(orderId);
            if (orderItems.Any())
            {
                Console.WriteLine($"\nВміст замовлення {orderId}:");
                decimal total = 0;
                foreach (var item in orderItems)
                {
                    Console.WriteLine($"- {item.Dish.Name} x {item.Quantity} = {item.Price * item.Quantity:C}");
                    total += item.Price * item.Quantity;
                }
                Console.WriteLine($"Загальна вартість: {total:C}");
            }
            else
            {
                Console.WriteLine($"Замовлення {orderId} порожнє.");
            }
        }
    }
}
