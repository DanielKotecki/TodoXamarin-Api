using System;
using System.Collections.Generic;
using System.Text;

namespace TodoMobile.Models
{
    public class TodoDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }

        public bool IsUse { get; set; }

        public DateTime UpdateAt { get; set; }


        public string UserNameId { get; set; }
    }
}
