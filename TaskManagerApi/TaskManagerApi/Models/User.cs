using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManagerApi.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmployeeId { get; set; }
        public Nullable<int> TaskId { get; set; }
        public Nullable<int> ProjectId { get; set; }
    }
}