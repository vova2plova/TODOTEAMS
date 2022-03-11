using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Models
{
    public class Plan
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public List<User> Teammates { get; set; }
        public List<TaskModel> PlanTasks { get; set; }

        public bool IsPrivate { get; set; }
        
        public bool IsComplited { get; set; }
    }
}
