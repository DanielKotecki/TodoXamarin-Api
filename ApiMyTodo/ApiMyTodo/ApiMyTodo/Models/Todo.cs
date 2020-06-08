using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMyTodo.Models
{


    public class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }

        public bool IsUse { get; set; }

        public DateTime UpdateAt { get; set; }
        public User User { get; set; }

        public string UserNameId { get; set; }


    }
}
