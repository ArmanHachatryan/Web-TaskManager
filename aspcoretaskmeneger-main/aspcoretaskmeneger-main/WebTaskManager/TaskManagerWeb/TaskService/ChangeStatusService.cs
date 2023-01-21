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
                        if (task.Status == "Остановлено" | task.Status == "В плане")
                        {
                            task.Status = "Выполняется";
                            task.StartDate = DateTime.Now;

                        }
                        break;
                    case "Остановить":
                        if (task.Status == "Выполняется")
                        {
                            task.Status = "Остановлено";
                            task.EndDate = DateTime.Now;
                            task.DateTime += task.EndDate.Subtract(task.StartDate);

                        }

                        break;
                    case "Завершить":
                        if (task.Status != "Завершено" && task.Status != "В плане")
                        {
                            task.Status = "Завершено";
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
