using AccountingTestWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace AccountingTestWPF.Data
{
    public class DataAccess
    {
        internal static List<Operation> GetAllOperations()
        {
            using (DataContext db = new DataContext())
            {
                var result = db.Operations.Include(nameof(User)).Include(nameof(Category)).Include(nameof(Recipient)).ToList();
                return result;
            }
        }

        internal static List<Recipient> GetAllRecipients()
        {
            using (DataContext db = new DataContext())
            {
                var result = db.Recipients.ToList();
                return result;
            }
        }

        internal static void AddUser(string name, bool isAdmin, decimal balance)
        {
            using (DataContext db = new DataContext())
            {
                bool checkExist = db.Users.Any(e => e.FullName == name);
                if (!checkExist)
                {
                    User newUser = new User { FullName = name, IsAdmin = isAdmin, Balance = balance };
                    db.Users.Add(newUser);
                    db.SaveChanges();
                }
                else
                {
                    MessageBox.Show($"Пользователь с именем {name} уже существует.", "Добавление пользователя");
                }
            }
        }

        internal static List<Category> GetAllCategories()
        {
            using (DataContext db = new DataContext())
            {
                var result = db.Categories.ToList();
                return result;
            }
        }

        internal static void LoadDefaultData()
        {
            using (DataContext db = new DataContext())
            {
                if (db.Users.Count() == 0)
                {
                    db.Users.Add(new User() { FullName = "Admin1", Balance = 100000, IsAdmin = true});
                    db.Users.Add(new User() { FullName = "User1", Balance = 50000, IsAdmin = false });
                    db.SaveChanges();
                }

                if (db.Categories.Count() == 0)
                {
                    db.Categories.Add(new Category() { CategoryName = "Дивиденды" });
                    db.Categories.Add(new Category() { CategoryName = "Налог" });
                    db.SaveChanges();
                }

                if (db.Recipients.Count() == 0)
                {
                    db.Recipients.Add(new Recipient() { RecipientName = "Людмила" });
                    db.Recipients.Add(new Recipient() { RecipientName = "Пётр" });
                    db.SaveChanges();
                }
            }
        }

        internal static List<User> GetAllUsers()
        {
            using (DataContext db = new DataContext())
            {
                var result = db.Users.ToList();
                return result;
            }
        }

        internal static void AddOperation(int userId, int categoryId, int? recipientId, bool isIncome, decimal sum, string note)
        {
            using (DataContext db = new DataContext())
            {
                var user = db.Users.FirstOrDefault(e => e.Id == userId);
                var category = db.Categories.FirstOrDefault(e => e.Id == categoryId);
                var recipient = db.Recipients.FirstOrDefault(e => e.Id == recipientId);

                Operation op = new Operation()
                {
                    User = user,
                    Category = category,
                    Recipient = recipient,
                    IsIncome = isIncome,
                    OperationDate = DateTime.Now,
                    Sum = sum,
                    Note = note
                };

                db.Operations.Add(op);

                if (isIncome)
                {
                    user.Balance += sum;
                }
                else
                {
                    user.Balance -= sum;
                }

                db.SaveChanges();
            }
        }

        internal static void AddCategory(string name)
        {
            using (DataContext db = new DataContext())
            {
                bool checkExist = db.Categories.Any(e => e.CategoryName == name);
                if (!checkExist)
                {
                    Category newCategory = new Category { CategoryName = name };
                    db.Categories.Add(newCategory);
                    db.SaveChanges();
                }
                else
                {
                    MessageBox.Show($"Категория {name} уже существует.", "Добавление категории");
                }
            }
        }

        internal static void AddRecipient(string name)
        {
            using (DataContext db = new DataContext())
            {
                bool checkExist = db.Recipients.Any(e => e.RecipientName == name);
                if (!checkExist)
                {
                    Recipient newRecipient = new Recipient { RecipientName = name };
                    db.Recipients.Add(newRecipient);
                    db.SaveChanges();
                }
                else
                {
                    MessageBox.Show($"Получатель с именем {name} же существует.", "Добавление получателя");
                }
            }
        }

        internal static User GetUserById(int userId)
        {
            using (DataContext db = new DataContext())
            {
                User pos = db.Users.FirstOrDefault(p => p.Id == userId);
                return pos;
            }
        }
    }
}
