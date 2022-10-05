using Microsoft.EntityFrameworkCore;
using SP101K.Data;
using SP101K.Entities;
using SP101K.Repo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SP101K.Service
{
    public class userService : userRepo<User>
    {
        readonly DataContext _DataContext;
        public userService(DataContext DataContext)
        {
            _DataContext = DataContext;
        }
        public IEnumerable<User> Users()
        {
            return _DataContext.Users.ToList();
        }
        public User getUser(int id)
        {
            try
            {
                return _DataContext.Users
                  .FirstOrDefault(e => e.Id == id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetType());
                return null;
            }
        }
        public void addUser(User data)
        {
            try
            {
                _DataContext.Users.Add(data);
                _DataContext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetType());
            }

        }
        public void updateUser(User cuurrentData, User newData)
        {
            try
            {
                cuurrentData.clientName = newData.clientName;
                cuurrentData.dateRegistered = newData.dateRegistered;
                cuurrentData.Location = newData.Location;
                cuurrentData.NumberofUsers = newData.NumberofUsers;
                _DataContext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetType());
            }
        }
        public void deleteUser(User data)
        {
            try
            {
                _DataContext.Users.Remove(data);
                _DataContext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetType());
            }
        }
    }
    }
