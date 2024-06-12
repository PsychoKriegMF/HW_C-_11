using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_C__11
{
    public class Task
    {
        public int Id {  get; set; }
        public string Title {  get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public int Priority {  get; set; }
        public Task() { }
        public Task(int id, string title, string description, DateTime dueDate, int priority)
        {
            Id = id;
            Title = title;
            Description = description;
            DueDate = dueDate;
            Priority = priority;
        }
    }
}
