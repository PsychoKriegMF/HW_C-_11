using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace HW_C__11
{
    public class TaskManager
    {
        private List<Task> tasks = new List<Task>();
        public void AddTask(Task task)
        {
            tasks.Add(task);
        }

        public void RemoveTask(int id)
        {            
            tasks.RemoveAll(task=>task.Id == id);
        }

        public void SaveTaskAsXml(string filePath)
        {
            var serializer = new XmlSerializer(typeof(List<Task>));
            using (var stream = new FileStream(filePath,FileMode.Create))

            {
                serializer.Serialize(stream,tasks.Cast<Task>().ToList());
            }
        }

        public void SaveTaskAsJson(string filePath)
        {
            var json = JsonConvert.SerializeObject(tasks);
            File.WriteAllText(filePath, json);
        }

        public void SaveTaskAsCsv(string filePath)
        {
            var csv = new StringBuilder();
            csv.AppendLine("Id,Title,Description,DueDate,Priority");
            foreach (var task in tasks)
            {
                csv.AppendLine($"{task.Id},{task.Title},{task.Description},{task.DueDate},{task.Priority}");
            }
            File.WriteAllText(filePath,csv.ToString());
        }

        public void LoadTasksFromXml(string filePath)
        {
            var serializer = new XmlSerializer(typeof(List<Task>));
            using (var reader = XmlReader.Create(filePath))
            {
                tasks = (List<Task>)serializer.Deserialize(reader);
            }
        }

        public void LoadTasksFromJson(string filePath)
        {
            var json = File.ReadAllText(filePath);
            tasks = JsonConvert.DeserializeObject<List<Task>>(json);
        }

        public void LoadTasksFromCsv(string filePath)
        {
            var lines = File.ReadAllLines(filePath).Skip(1);
            tasks.Clear();
            foreach (var line in lines)
            {
                var values = line.Split(',');
                tasks.Add(new Task(
                    int.Parse(values[0]),
                    values[1],
                    values[2],
                    DateTime.Parse(values[3]),
                    int.Parse(values[4])
                ));
            }
        }

        public IEnumerable<Task> FilterTasksByPriority(int priority)
        {
            return tasks.Where(task => task.Priority == priority);
        }

        public IEnumerable<Task> SortTasksByDueDate()
        {
            return tasks.OrderBy(task => task.DueDate);
        }

        public IEnumerable<IGrouping<int, Task>> GroupTasksByPriority()
        {
            return tasks.GroupBy(task => task.Priority);
        }
    }
}
