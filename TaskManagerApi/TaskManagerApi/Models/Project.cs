using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManagerApi.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int Priority { get; set; }
    }
}