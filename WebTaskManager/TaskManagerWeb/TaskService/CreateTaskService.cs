﻿using TaskManagerWeb.Models;

namespace TaskManagerWeb.TaskService
{
    public class CreateTaskService
    {
        private readonly DbStorage _storage;
        public CreateTaskService(DbStorage storage)
        {
            _storage = storage;
        }
        public void CreateTask(string name)
        {
            if (name != null)
            {
                var task = new Models.Task()
                {
                    Name = name,
                    Status = _storage.Statuses.Find(1)
            };
                _storage.Tasks.Add(task);
                _storage.SaveChanges();
            }

        }
    }
}
