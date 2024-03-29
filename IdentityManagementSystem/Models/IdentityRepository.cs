﻿using System.Data;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace IdentityManagementSystem.Models
{
    public class IdentityRepository : IIdentityRepository
    {
        public void AddUser(User user)
        {
            using (var context = new IdentityDbContext())
            {
                user.Id = Guid.NewGuid();
                context.Users?.Add(user);
                context.SaveChanges();
            }
        }

        public UserModel? GetUser(string? login, string? password)
        {
            if (string.IsNullOrWhiteSpace(login)) return null;
            if (string.IsNullOrWhiteSpace(password)) return null;

            using (var context = new IdentityDbContext())
            {
                var result = context.Users?.FirstOrDefault(o => !string.IsNullOrEmpty(o.UserName) &&
                o.UserName.ToLower() == login.ToLower() && o.Password == password);

                if (result == null) return null;

                var userModel = new UserModel();

                userModel.UserName = result.UserName;

                var roleResult = context.UserRole?.FirstOrDefault(o => o.UserName == userModel.UserName);

                if (roleResult == null) return null;

                userModel.RoleName = roleResult.RoleName;

                var permissionResult = context.RolePermission?.Where(o => o.RoleName == userModel.RoleName).Select(x => x.Action);

                if (permissionResult == null) return null;

                userModel.Permissions = permissionResult.ToList() ?? new List<string?>();

                return userModel;
            }
        }

        public void AddRole(Roles role)
        {
            using (var context = new IdentityDbContext())
            {
                role.Id = Guid.NewGuid();
                context.Role?.Add(role);
                context.SaveChanges();
            }
        }

        public void AddUserRole(UserRoles item)
        {
            using (var context = new IdentityDbContext())
            {
                item.Id = Guid.NewGuid();
                context.UserRole?.Add(item);
                context.SaveChanges();
            }
        }

        public void AddRolePermissions(RolePermissions item)
        {
            using (var context = new IdentityDbContext())
            {
                item.Id = Guid.NewGuid();
                context.RolePermission?.Add(item);
                context.SaveChanges();
            }
        }

        public IEnumerable<User> GetUsers()
        {
            using (var context = new IdentityDbContext())
            {
                return context.Users?.ToList() ?? new List<User>();
            }
        }

        public IEnumerable<Roles> GetRoles()
        {
            using (var context = new IdentityDbContext())
            {
                return context.Role?.ToList() ?? new List<Roles>();
            }
        }

        public IEnumerable<UserRoles> GetUserRoles()
        {
            using (var context = new IdentityDbContext())
            {
                return context.UserRole?.ToList() ?? new List<UserRoles>();
            }
        }

        public IEnumerable<RolePermissions> GetRolePermissions()
        {
            using (var context = new IdentityDbContext())
            {
                return context.RolePermission?.ToList() ?? new List<RolePermissions>();
            }
        }
    }
}
