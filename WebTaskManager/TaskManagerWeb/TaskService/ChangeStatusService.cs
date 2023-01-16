using TaskManagerWeb.Models;

namespace TaskManagerWeb.TaskService
{
    public class ChangeStatusService
    {
        private readonly DbStorage _storage;
        public ChangeStatusService(DbStorage storage)
        {
            _storage = storage;
        } 
        public void ChangeStatus(int id, string status)
        {
            var task = _storage.Tasks.Find(id);

            if (task != null)
            {
                switch (status)
                {
                    case "Выполнять":
                        if (task.Status.DivplayValue == "Остановлено" 
                            | task.Status.DivplayValue == "В плане")
                        {
                            task.Status = _storage.Statuses.Find(2);
                            task.StartDate = DateTime.Now;
                        }
                        break;
                    case "Остановить":
                        if (task.Status.DivplayValue == "Выполняется")
                        {
                            task.Status = _storage.Statuses.Find(3);
                            task.EndDate = DateTime.Now;
                            task.DateTime += task.EndDate.Subtract(task.StartDate);

                        }
                        break;
                    case "Завершить":
                        if (task.Status.DivplayValue != "Завершено" && task.Status.DivplayValue != "В плане")
                        {
                            task.Status = _storage.Statuses.Find(4);
                            task.EndDate = DateTime.Now;
                            task.DateTime += task.EndDate.Subtract(task.StartDate);
                        }
                        break;
                }
            }
            _storage.SaveChanges();
        }
    }
}
