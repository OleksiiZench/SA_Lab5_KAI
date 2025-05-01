using Microsoft.EntityFrameworkCore;
using FoodDelivery.DAL.Entities;

namespace FoodDelivery.DAL.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Entities.DayOfWeek> DaysOfWeek { get; set; }
        public DbSet<MenuDish> MenuDishes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=FoodDelivery.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MenuDish>()
                .HasKey(md => new { md.MenuId, md.DishId });

            Seed(modelBuilder);
        }

        private static void Seed(ModelBuilder modelBuilder)
        {
            // Додавання днів тижня
            modelBuilder.Entity<Entities.DayOfWeek>().HasData(
                new Entities.DayOfWeek { Id = 1, Name = "Понеділок" },
                new Entities.DayOfWeek { Id = 2, Name = "Вівторок" },
                new Entities.DayOfWeek { Id = 3, Name = "Середа" },
                new Entities.DayOfWeek { Id = 4, Name = "Четвер" },
                new Entities.DayOfWeek { Id = 5, Name = "П'ятниця" },
                new Entities.DayOfWeek { Id = 6, Name = "Субота" },
                new Entities.DayOfWeek { Id = 7, Name = "Неділя" }
            );

            // Додавання категорій страв
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Салати" },
                new Category { Id = 2, Name = "Супи" },
                new Category { Id = 3, Name = "Основні страви" },
                new Category { Id = 4, Name = "Гарніри" },
                new Category { Id = 5, Name = "Десерти" },
                new Category { Id = 6, Name = "Напої" },
                new Category { Id = 7, Name = "Сніданки" },
                new Category { Id = 8, Name = "Вегетаріанські страви" }
            );

            // Додавання страв
            modelBuilder.Entity<Dish>().HasData(
                // Салати
                new Dish { Id = 1, Name = "Салат Цезар", Description = "Класичний салат з куркою, сухариками та соусом", Price = 120.00m, CategoryId = 1 },
                new Dish { Id = 2, Name = "Грецький салат", Description = "Традиційний грецький салат з фетою та оливками", Price = 110.50m, CategoryId = 1 },
                new Dish { Id = 3, Name = "Салат Олів'є", Description = "Традиційний салат з картоплею, горошком та майонезом", Price = 95.00m, CategoryId = 1 },
                new Dish { Id = 4, Name = "Вінегрет", Description = "Традиційний український салат з буряком", Price = 85.00m, CategoryId = 1 },

                // Супи
                new Dish { Id = 5, Name = "Борщ український", Description = "Традиційний український борщ зі сметаною", Price = 90.50m, CategoryId = 2 },
                new Dish { Id = 6, Name = "Суп з фрикадельками", Description = "Легкий суп з м'ясними фрикадельками", Price = 85.00m, CategoryId = 2 },
                new Dish { Id = 7, Name = "Окрошка", Description = "Холодний літній суп на кефірі", Price = 80.00m, CategoryId = 2 },
                new Dish { Id = 8, Name = "Грибний крем-суп", Description = "Ніжний крем-суп з лісових грибів", Price = 95.00m, CategoryId = 2 },

                // Основні страви
                new Dish { Id = 9, Name = "Котлета по-київськи", Description = "Традиційна котлета з начинкою з масла та зелені", Price = 140.00m, CategoryId = 3 },
                new Dish { Id = 10, Name = "Бефстроганов", Description = "Шматочки яловичини в сметанному соусі", Price = 160.00m, CategoryId = 3 },
                new Dish { Id = 11, Name = "Шашлик зі свинини", Description = "Маринована свинина, смажена на вугіллі", Price = 180.00m, CategoryId = 3 },
                new Dish { Id = 12, Name = "Лосось на грилі", Description = "Філе лосося з лимоном та травами", Price = 210.00m, CategoryId = 3 },
                new Dish { Id = 13, Name = "Карбонара", Description = "Паста з беконом та яйцем", Price = 135.00m, CategoryId = 3 },

                // Гарніри
                new Dish { Id = 14, Name = "Картопляне пюре", Description = "Ніжне пюре з вершковим маслом", Price = 60.00m, CategoryId = 4 },
                new Dish { Id = 15, Name = "Відварний рис", Description = "Розсипчастий рис з вершковим маслом", Price = 50.00m, CategoryId = 4 },
                new Dish { Id = 16, Name = "Овочі на грилі", Description = "Асорті сезонних овочів на грилі", Price = 75.00m, CategoryId = 4 },

                // Десерти
                new Dish { Id = 17, Name = "Тірамісу", Description = "Італійський десерт з маскарпоне та кавою", Price = 90.00m, CategoryId = 5 },
                new Dish { Id = 18, Name = "Наполеон", Description = "Багатошаровий торт з заварним кремом", Price = 85.00m, CategoryId = 5 },
                new Dish { Id = 19, Name = "Чізкейк", Description = "Ніжний десерт з сирною начинкою", Price = 95.00m, CategoryId = 5 },
                new Dish { Id = 20, Name = "Морозиво", Description = "Три кульки різних смаків", Price = 70.00m, CategoryId = 5 },

                // Напої
                new Dish { Id = 21, Name = "Лимонад", Description = "Освіжаючий лимонад з м'ятою", Price = 45.00m, CategoryId = 6 },
                new Dish { Id = 22, Name = "Кава Американо", Description = "Класична кава", Price = 40.00m, CategoryId = 6 },
                new Dish { Id = 23, Name = "Капучіно", Description = "Кава з молочною пінкою", Price = 50.00m, CategoryId = 6 },
                new Dish { Id = 24, Name = "Чай", Description = "Вибір чаїв в асортименті", Price = 35.00m, CategoryId = 6 },
                new Dish { Id = 25, Name = "Узвар", Description = "Традиційний напій з сухофруктів", Price = 40.00m, CategoryId = 6 },

                // Сніданки
                new Dish { Id = 26, Name = "Омлет", Description = "Пухкий омлет з сиром", Price = 75.00m, CategoryId = 7 },
                new Dish { Id = 27, Name = "Вівсянка", Description = "Вівсяна каша з фруктами та медом", Price = 65.00m, CategoryId = 7 },
                new Dish { Id = 28, Name = "Млинці", Description = "Тонкі млинці з різними начинками", Price = 85.00m, CategoryId = 7 },
                new Dish { Id = 29, Name = "Сирники", Description = "Сирники зі сметаною та джемом", Price = 95.00m, CategoryId = 7 },

                // Вегетаріанські страви
                new Dish { Id = 30, Name = "Вареники з картоплею", Description = "Вареники з картоплею та цибулею", Price = 85.00m, CategoryId = 8 },
                new Dish { Id = 31, Name = "Рататуй", Description = "Тушковані овочі по-французьки", Price = 95.00m, CategoryId = 8 },
                new Dish { Id = 32, Name = "Фалафель", Description = "Котлети з нуту з соусом тахіні", Price = 105.00m, CategoryId = 8 }
            );

            // Додавання меню на кожен день тижня
            for (int i = 1; i <= 7; i++)
            {
                modelBuilder.Entity<Menu>().HasData(
                    new Menu { Id = i, DayOfWeekId = i }
                );
            }

            // Понеділок
            modelBuilder.Entity<MenuDish>().HasData(
                // Сніданок
                new MenuDish { MenuId = 1, DishId = 26 },
                new MenuDish { MenuId = 1, DishId = 27 },
                new MenuDish { MenuId = 1, DishId = 24 },
                // Обід
                new MenuDish { MenuId = 1, DishId = 1 },
                new MenuDish { MenuId = 1, DishId = 5 },
                new MenuDish { MenuId = 1, DishId = 9 },
                new MenuDish { MenuId = 1, DishId = 14 },
                new MenuDish { MenuId = 1, DishId = 21 },
                // Вечеря
                new MenuDish { MenuId = 1, DishId = 3 },
                new MenuDish { MenuId = 1, DishId = 16 },
                new MenuDish { MenuId = 1, DishId = 17 }
            );

            // Вівторок
            modelBuilder.Entity<MenuDish>().HasData(
                // Сніданок
                new MenuDish { MenuId = 2, DishId = 28 },
                new MenuDish { MenuId = 2, DishId = 22 },
                // Обід
                new MenuDish { MenuId = 2, DishId = 2 },
                new MenuDish { MenuId = 2, DishId = 6 },
                new MenuDish { MenuId = 2, DishId = 10 },
                new MenuDish { MenuId = 2, DishId = 15 },
                new MenuDish { MenuId = 2, DishId = 21 },
                // Вечеря
                new MenuDish { MenuId = 2, DishId = 32 },
                new MenuDish { MenuId = 2, DishId = 18 }
            );

            // Середа
            modelBuilder.Entity<MenuDish>().HasData(
                // Сніданок
                new MenuDish { MenuId = 3, DishId = 29 },
                new MenuDish { MenuId = 3, DishId = 23 },
                // Обід
                new MenuDish { MenuId = 3, DishId = 4 },
                new MenuDish { MenuId = 3, DishId = 7 },
                new MenuDish { MenuId = 3, DishId = 13 },
                new MenuDish { MenuId = 3, DishId = 24 },
                // Вечеря
                new MenuDish { MenuId = 3, DishId = 30 },
                new MenuDish { MenuId = 3, DishId = 19 }
            );

            // Четвер
            modelBuilder.Entity<MenuDish>().HasData(
                // Сніданок
                new MenuDish { MenuId = 4, DishId = 26 },
                new MenuDish { MenuId = 4, DishId = 24 },
                // Обід
                new MenuDish { MenuId = 4, DishId = 1 },
                new MenuDish { MenuId = 4, DishId = 8 },
                new MenuDish { MenuId = 4, DishId = 11 },
                new MenuDish { MenuId = 4, DishId = 14 },
                new MenuDish { MenuId = 4, DishId = 25 },
                // Вечеря
                new MenuDish { MenuId = 4, DishId = 31 },
                new MenuDish { MenuId = 4, DishId = 20 }
            );

            // П'ятниця
            modelBuilder.Entity<MenuDish>().HasData(
                // Сніданок
                new MenuDish { MenuId = 5, DishId = 27 },
                new MenuDish { MenuId = 5, DishId = 22 },
                // Обід
                new MenuDish { MenuId = 5, DishId = 2 },
                new MenuDish { MenuId = 5, DishId = 5 },
                new MenuDish { MenuId = 5, DishId = 12 },
                new MenuDish { MenuId = 5, DishId = 16 },
                new MenuDish { MenuId = 5, DishId = 21 },
                // Вечеря
                new MenuDish { MenuId = 5, DishId = 3 },
                new MenuDish { MenuId = 5, DishId = 17 }
            );

            // Субота
            modelBuilder.Entity<MenuDish>().HasData(
                // Сніданок
                new MenuDish { MenuId = 6, DishId = 28 },
                new MenuDish { MenuId = 6, DishId = 23 },
                // Обід
                new MenuDish { MenuId = 6, DishId = 4 },
                new MenuDish { MenuId = 6, DishId = 6 },
                new MenuDish { MenuId = 6, DishId = 9 },
                new MenuDish { MenuId = 6, DishId = 15 },
                new MenuDish { MenuId = 6, DishId = 24 },
                // Вечеря
                new MenuDish { MenuId = 6, DishId = 32 },
                new MenuDish { MenuId = 6, DishId = 18 }
            );

            // Неділя
            modelBuilder.Entity<MenuDish>().HasData(
                // Сніданок
                new MenuDish { MenuId = 7, DishId = 29 },
                new MenuDish { MenuId = 7, DishId = 22 },
                // Обід
                new MenuDish { MenuId = 7, DishId = 1 },
                new MenuDish { MenuId = 7, DishId = 8 },
                new MenuDish { MenuId = 7, DishId = 10 },
                new MenuDish { MenuId = 7, DishId = 14 },
                new MenuDish { MenuId = 7, DishId = 21 },
                // Вечеря
                new MenuDish { MenuId = 7, DishId = 30 },
                new MenuDish { MenuId = 7, DishId = 19 }
            );
        }
    }
}
