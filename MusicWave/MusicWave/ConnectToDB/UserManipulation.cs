﻿using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Helpers;
using MusicWave.Models;

namespace MusicWave.ConnectToDB
{
    public class UserManipulation
    {
        private bool CheckSex(string sex)
        {
            bool result = sex == "Male";
            if (sex == "Female")
            {
                result = false;
            }
            return result;

        }

        private Guid GetRole(string role)
        {
            var roleId = new Guid();
            using (var db = new WorldDBEntities2())
            {
                try
                {
                    var user = db.Roles.FirstOrDefault(u => u.Name == role);
                    if (user != null)
                    {
                        roleId = user.RoleId;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return roleId;
        }

        public void AddUserToDb(CustomUser model)
        {
            using (var db = new WorldDBEntities2())
            {
                var entity = new User()
                {
                    Id = Guid.NewGuid(),
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Age = model.Age,
                    City = model.City,
                    Description = model.Description,
                    Email = model.Email,
                    Password = Crypto.SHA256(model.Password),
                    Sex = CheckSex(model.Sex),
                    ImageBase64 = model.ImageBase64,
                    ImageContentType = model.ImageContentType,
                    RoleId = GetRole("user")
                };
                try
                {

                    db.User.Add(entity);
                    db.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }
            }
        }
    }
}