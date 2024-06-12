namespace HW_C__11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var taskManager = new TaskManager();

            //добавляем задачи в файл
            var task1 = new Task(1, "Task 1", "Description 1", DateTime.Now.AddDays(1), 1);
            var task2 = new Task(2, "Task 2", "Description 2", DateTime.Now.AddDays(2), 2);
            var task3 = new Task(3, "Task 3", "Description 3", DateTime.Now.AddDays(3), 3);
            var task4 = new Task(4, "Task 4", "Description 4", DateTime.Now.AddDays(4), 2);
            var task5 = new Task(5, "Task 5", "Description 5", DateTime.Now.AddDays(5), 4);
           
            taskManager.AddTask(task1);
            taskManager.AddTask(task2);
            taskManager.AddTask(task3);
            taskManager.AddTask(task4);
            taskManager.AddTask(task5);

            //Сохраняем задачу 
            taskManager.SaveTaskAsXml("file.xml");
            taskManager.SaveTaskAsJson("file.json");
            taskManager.SaveTaskAsCsv("file.csv");

            //Загружаем задачу из фала
            taskManager.LoadTasksFromXml("file.xml");
            taskManager.LoadTasksFromJson("file.json");
            taskManager.LoadTasksFromCsv("file.csv");

            //Фильтрация задачь по приоритету
            var SortByPriority = taskManager.FilterTasksByPriority(2);
            foreach( var task in SortByPriority )
            {
                Console.WriteLine($"{task.Title} : {task.Priority}");
            }

            //Сортировка по датам
            var SortByDate = taskManager.SortTasksByDueDate();
            foreach (var task in SortByDate)
            {
                Console.WriteLine($"{task.Title} : {task.DueDate}");
            }

            //Группировка по приоритету
            var GroupByPriority = taskManager.GroupTasksByPriority();
            foreach (var group in GroupByPriority)
            {
                Console.WriteLine($"Priority: {group.Key}");
                foreach (var task in group)
                {
                    Console.WriteLine($"Task Title: {task.Title}");
                }
            }
        }
    }
}
