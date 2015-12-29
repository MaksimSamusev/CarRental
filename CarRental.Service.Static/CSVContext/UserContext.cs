﻿using CarRental.Model;
using CarRental.Service.Static.CSVContext.Common;
using System;
using System.Collections.Generic;
using System.IO;

namespace CarRental.Service.Static.CSVContext
{
   public class UserContext : ICSVContext<User>
    {
       private string next = ";";
        private string _path = @"users.csv";
        private string context;
        public void Add(User item)
        {
            using (StreamWriter file = new StreamWriter(_path))
            {
                context = item.Id + next + item.Login + next + item.Password + next+ item.DateOfAdd.ToString() + next + item.LastVisit;
                file.WriteLine(context);
            }

        }

        public void Delete(int id)
        {
            using (StreamWriter file = new StreamWriter(_path, false))
            {
                string[] _context = File.ReadAllLines(_path);
                for (int i = 0; i < _context.Length; i++)
                {
                    string[] record = _context[i].Split(';');

                    if (int.Parse(record[0]) == id)
                    {
                        _context[i] = "";
                    }
                    if (_context[i] != "") file.WriteLine(_context[i]);
                }
            }


        }

        public List<User> Get()
        {
            string[] _context = File.ReadAllLines(_path);
            List<User> users = new List<User>();
            for (int i = 0; i < _context.Length; i++)
            {
                string[] record = _context[i].Split(';');
                users.Add(new User
                {
                    Id = int.Parse(record[0]),
                    Login = record[1],
                    Password = record[2],
                    DateOfAdd = DateTime.Parse(record[3]),
                    LastVisit = DateTime.Parse(record[4])
                });
            }
            return users;
        }

        public User Get(int id)
        {
            User user = new User();
            string[] _context = File.ReadAllLines(_path);
            for (int i = 0; i < _context.Length; i++)
            {
                string[] record = _context[i].Split(';');
                if (id == int.Parse(record[0]))
                {
                    user = new User
                    {
                        Id = int.Parse(record[0]),
                        Login = record[1],
                        Password = record[2],
                        DateOfAdd = DateTime.Parse(record[3]),
                        LastVisit = DateTime.Parse(record[4])
                    };
                }
            }
            return user;
        }

    }
}