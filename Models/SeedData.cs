using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Project.Data;
using System;
using System.Linq;
//using Project.Authorization;
using Project.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Project.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Exercise.Any())
                {
                    return;
                }
                context.Exercise.AddRange(
                    new Exercise
                    {
                        Title = "Calculation I",
                        Conditions = "Calculate x:\n (15,6)^(2,91) + (2201)^(123/x) = 2966,12725",
                        Subject = "Math",
                        Tags = "math",
                        Pictures = "none",
                        RightAnswers = "3128",
                        Status = SolutionStatus.Not_applied,
                        OwnerID = "Admin"
                    },

                    new Exercise
                    {
                        Title = "C# Basics",
                        Conditions = "Дан код:\n" +
                        "string[] strings = Console.ReadLine().Split();\n" +
                        "string result = null;\n" +
                        "foreach (string s in strings)\n" +
                        "  result += s;\n" +
                        "Console.WriteLine(result);\n" +
                        "Программа вывела следующий результат выполнения кода:\n" +
                        "144af00E\n" +
                        "Выберите вариант, который может соответствовать \n" +
                        "входным данным в приложения для данного результата:\n" +
                        "A: 144 af 00 E\n" +
                        "B: 1 44af00E\n" +
                        "C: и вариант A и вариант B - верны\n" +
                        "D: код не скомпилируется\n",
                        Subject = "C#",
                        Tags = "c#",
                        Pictures = "none",
                        RightAnswers = "C",
                        Status = SolutionStatus.Not_applied,
                        OwnerID = "Admin"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
//public static async Task Initialize(IServiceProvider serviceProvider, string testUserPw)
//{
//    using (var context = new ApplicationDbContext(
//        serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
//    {

//        var adminID = await EnsureUser(serviceProvider, testUserPw, "admin@mathius.com");
//        await EnsureRole(serviceProvider, adminID, Constants.ExerciseAdministratorsRole);

//        SeedDB(context, adminID);
//    }
//}

//private static async Task<string> EnsureUser(IServiceProvider serviceProvider,
//                                            string testUserPw, string UserName)
//{
//    var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();

//    var user = await userManager.FindByNameAsync(UserName);
//    if (user == null)
//    {
//        user = new IdentityUser
//        {
//            UserName = UserName,
//            EmailConfirmed = true
//        };
//        await userManager.CreateAsync(user, testUserPw);
//    }

//    if (user == null)
//    {
//        throw new Exception("The password is probably not strong enough!");
//    }

//    return user.Id;
//}

//private static async Task<IdentityResult> EnsureRole(IServiceProvider serviceProvider,
//                                                              string uid, string role)
//{
//    IdentityResult IR = null;
//    var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

//    if (roleManager == null)
//    {
//        throw new Exception("roleManager null");
//    }

//    if (!await roleManager.RoleExistsAsync(role))
//    {
//        IR = await roleManager.CreateAsync(new IdentityRole(role));
//    }

//    var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();

//    var user = await userManager.FindByIdAsync(uid);

//    if (user == null)
//    {
//        throw new Exception("The testUserPw password was probably not strong enough!");
//    }

//    IR = await userManager.AddToRoleAsync(user, role);

//    return IR;
//}
//public static void SeedDB(ApplicationDbContext context, string adminID)
//{
//    if (context.Exercise.Any())
//    {
//        return;
//    }
//    context.Exercise.AddRange(
//        new Exercise
//        {
//            Title = "Calculation I",
//            Conditions = "Calculate x:\n (15,6)^(2,91) + (2201)^(123/x) = 2966,12725",
//            Subject = "Math",
//            Tags = "math",
//            Pictures = "none",
//            RightAnswers = "3128",
//            Status = SolutionStatus.Not_applied,
//            OwnerID = adminID
//        },

//        new Exercise
//        {
//            Title = "C# Basics",
//            Conditions = "Дан код:\n" +
//            "string[] strings = Console.ReadLine().Split();\n" +
//            "string result = null;\n" +
//            "foreach (string s in strings)\n" +
//            "  result += s;\n" +
//            "Console.WriteLine(result);\n" +
//            "Программа вывела следующий результат выполнения кода:\n" +
//            "144af00E\n" +
//            "Выберите вариант, который может соответствовать \n" +
//            "входным данным в приложения для данного результата:\n" +
//            "A: 144 af 00 E\n" +
//            "B: 1 44af00E\n" +
//            "C: и вариант A и вариант B - верны\n" +
//            "D: код не скомпилируется\n",
//            Subject = "C#",
//            Tags = "c#",
//            Pictures = "none",
//            RightAnswers = "C",
//            Status = SolutionStatus.Not_applied,
//            OwnerID = adminID
//        }
//    );
//    context.SaveChanges();
//}