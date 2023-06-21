using EmployeeManagement.Data.DbModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Common.ConstantsModels
{
    public static class SeedData
    {
        // Bu metot, kullanıcı yöneticisi ve rol yöneticisini kullanarak rol ve kullanıcıları ekleme işlemini gerçekleştirir.
        public static void Seed(UserManager<Employee> userManager, RoleManager<IdentityRole> roleManager)
        {
            // Rol verilerini ekler
            SeedRoles(roleManager);
            // Kullanıcı verilerini ekler
            SeedUsers(userManager);
        }

        // Kullanıcıları ekleme işlemini gerçekleştirir.
        private static void SeedUsers(UserManager<Employee> userManager)
        {
            // Eğer "Admin_Email" olarak tanımlanan kullanıcı veritabanında bulunmuyorsa işleme devam eder.
            if (userManager.FindByNameAsync(ResultConstant.Admin_Email).Result == null)
            {
                // Yeni bir Employee (Çalışan) nesnesi oluşturulur.
                var user = new Employee
                {
                    UserName = ResultConstant.Admin_Email,
                    Email = ResultConstant.Admin_Email
                };
                // Kullanıcıyı ve belirtilen parolayı kullanarak oluşturur.
                var result = userManager.CreateAsync(user, ResultConstant.Admin_Password).Result;
                // Kullanıcı oluşturma işlemi başarılıysa, kullanıcıya "Admin_Role" rolünü ekler.
                if (result.Succeeded)
                    userManager.AddToRoleAsync(user, ResultConstant.Admin_Role);
            }
        }

        // Rolleri ekleme işlemini gerçekleştirir.
        private static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            // Eğer "Admin_Role" olarak tanımlanan rol veritabanında bulunmuyorsa işleme devam eder.
            if (!roleManager.RoleExistsAsync(ResultConstant.Admin_Role).Result)
            {
                // Yeni bir IdentityRole (Kimlik Rolü) nesnesi oluşturulur.
                var role = new IdentityRole
                {
                    Name = ResultConstant.Admin_Role
                };
                // Rolü veritabanına ekler.
                var result = roleManager.CreateAsync(role).Result;
            }
            // Eğer "Employee_Role" olarak tanımlanan rol veritabanında bulunmuyorsa işleme devam eder.
            if (!roleManager.RoleExistsAsync(ResultConstant.Employee_Role).Result)
            {
                // Yeni bir IdentityRole (Kimlik Rolü) nesnesi oluşturulur.
                var role = new IdentityRole
                {
                    Name = ResultConstant.Employee_Role
                };
                // Rolü veritabanına ekler.
                var result = roleManager.CreateAsync(role).Result;
            }
        }
    }
}
