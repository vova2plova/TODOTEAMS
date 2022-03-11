using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Models
{
    public class TaskModel
    {
        [Key]
        public int Id { get; set; }
        public int PlanId { get; set; }
        public string Name { get; set; }

        public bool IsComplited { get; set; }
    }
}
