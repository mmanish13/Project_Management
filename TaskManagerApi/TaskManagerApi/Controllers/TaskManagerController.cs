using System;
using System.Collections.Generic;
using System.Web.Http;
using TaskManagerApi.Models;
using TaskManagerBusiness;
using DA = TaskManagerDataAccess;

namespace TaskManagerApi.Controllers
{
    public class TaskManagerController : ApiController
    {
        [HttpGet]
        [ActionName("GetAllTasks")]
        // GET: api/TaskManager
        public IEnumerable<Task> GetAllTasks()
        {
            TaskManagerBL taskManagerBL = new TaskManagerBL();
            List<Task> lstTask = new List<Task>();
            foreach (var task in taskManagerBL.ReadAllTask())
            {
                lstTask.Add(new Task()
                {
                    Name = task.Task1,
                    EndDate = task.End_Date.ToString("dd/MM/yyyy"),
                    ParentId = task.Parent__ID,
                    StartDate = task.Start_Date.ToString("dd/MM/yyyy"),
                    Priority = task.Priority,
                    TaskId = task.Task_ID,
                    ParentTaskName = task.Parent__ID == null ? "" : taskManagerBL.ReadParentTask(task.Parent__ID).Parent_Task
                });
            }
            return lstTask;
        }

        [HttpGet]
        [ActionName("GetAllParentTasks")]
        // GET: api/TaskManager/5
        public IEnumerable<ParentTask> GetAllParentTasks()
        {
            TaskManagerBL taskManagerBL = new TaskManagerBL();
            List<ParentTask> lstTask = new List<ParentTask>();
            foreach (var task in taskManagerBL.ReadAllParentTask())
            {
                lstTask.Add(new ParentTask()
                {
                    ParentId = task.Parent_ID,
                    ParentTaskName = task.Parent_Task
                });
            }
            return lstTask;
        }

        [HttpGet]
        [ActionName("GetTask")]
        // GET: api/TaskManager/5
        public Task GetTask(int id)
        {
            TaskManagerBL taskManagerBL = new TaskManagerBL();
            DA.Task task = taskManagerBL.ReadTask(id);

            if (task != null)
                return new Task()
                {
                    Name = task.Task1,
                    EndDate = task.End_Date.ToString("dd/MM/yyyy"),
                    ParentId = task.Parent__ID,
                    StartDate = task.Start_Date.ToString("dd/MM/yyyy"),
                    Priority = task.Priority,
                    TaskId = task.Task_ID
                };
            return null;
        }

        [HttpPost]
        [ActionName("AddTask")]
        // POST: api/TaskManager
        public void AddTask([FromBody]Task task)
        {
            TaskManagerBL taskManagerBL = new TaskManagerBL();

            taskManagerBL.AddTask(new DA.Task()
            {
                Task1 = task.Name,
                Parent__ID = task.ParentId,
                Priority = task.Priority,
                End_Date = Convert.ToDateTime(task.EndDate),
                Start_Date = Convert.ToDateTime(task.StartDate)
            });
        }

        [HttpPost]
        [ActionName("UpdateTask")]
        // PUT: api/TaskManager/5
        public void UpdateTask([FromBody]Task task)
        {
            TaskManagerBL taskManagerBL = new TaskManagerBL();

            taskManagerBL.UpdateTask(new DA.Task()
            {
                Task_ID = task.TaskId,
                Task1 = task.Name,
                Parent__ID = task.ParentId,
                Priority = task.Priority,
                End_Date = Convert.ToDateTime(task.EndDate),
                Start_Date = Convert.ToDateTime(task.StartDate)
            });
        }

        [HttpGet]
        [ActionName("DeleteTask")]
        // DELETE: api/TaskManager/5
        public void DeleteTask(int id)
        {
            TaskManagerBL taskManagerBL = new TaskManagerBL();
            taskManagerBL.EndTask(id);
        }

        [HttpGet]
        [ActionName("GetAllUsers")]
        // GET: api/TaskManager
        public IEnumerable<User> GetAllUsers()
        {
            TaskManagerBL taskManagerBL = new TaskManagerBL();
            List<User> lstUser = new List<User>();
            foreach (var user in taskManagerBL.ReadAllUsers())
            {
                lstUser.Add(new User()
                {
                    UserId = user.User_ID,
                    EmployeeId = user.Employee_ID,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    ProjectId = user.Project_ID,
                    TaskId = user.Task_ID
                });
            }
            return lstUser;
        }

        [HttpGet]
        [ActionName("GetUser")]
        // GET: api/TaskManager/5
        public User GetUser(int id)
        {
            TaskManagerBL taskManagerBL = new TaskManagerBL();
            DA.User user = taskManagerBL.ReadUser(id);

            if (user != null)
                return new User()
                {
                    UserId = user.User_ID,
                    EmployeeId = user.Employee_ID,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    ProjectId = user.Project_ID,
                    TaskId = user.Task_ID
                };
            return null;
        }

        [HttpPost]
        [ActionName("AddUser")]
        // POST: api/TaskManager
        public void AddUser([FromBody]User user)
        {
            TaskManagerBL taskManagerBL = new TaskManagerBL();

            taskManagerBL.AddUser(new DA.User()
            {
                Task_ID = user.TaskId,
                Project_ID = user.ProjectId,
                LastName = user.LastName,
                FirstName = user.FirstName,
                Employee_ID = user.EmployeeId
            });
        }

        [HttpPost]
        [ActionName("UpdateUser")]
        // PUT: api/TaskManager/5
        public void UpdateUser([FromBody]User user)
        {
            TaskManagerBL taskManagerBL = new TaskManagerBL();

            taskManagerBL.UpdateUser(new DA.User()
            {
                User_ID = user.UserId,
                Task_ID = user.TaskId,
                Project_ID = user.ProjectId,
                LastName = user.LastName,
                FirstName = user.FirstName,
                Employee_ID = user.EmployeeId
            });
        }

        [HttpGet]
        [ActionName("DeleteUser")]
        // DELETE: api/TaskManager/5
        public void DeleteUser(int id)
        {
            TaskManagerBL taskManagerBL = new TaskManagerBL();
            taskManagerBL.DeleteUser(id);
        }

        [HttpGet]
        [ActionName("GetAllProjects")]
        // GET: api/TaskManager
        public IEnumerable<Project> GetAllProjects()
        {
            TaskManagerBL taskManagerBL = new TaskManagerBL();
            List<Project> lstProject = new List<Project>();
            foreach (var project in taskManagerBL.ReadAllProjects())
            {
                lstProject.Add(new Project()
                {
                    Name = project.Project1,
                    ProjectId = project.Project_ID,
                    EndDate = project.End_Date.ToString("dd/MM/yyyy"),
                    StartDate = project.Start_Date.ToString("dd/MM/yyyy"),
                    Priority = project.Priority
                });
            }
            return lstProject;
        }

        [HttpGet]
        [ActionName("GetProject")]
        // GET: api/TaskManager/5
        public Project GetProject(int id)
        {
            TaskManagerBL taskManagerBL = new TaskManagerBL();
            DA.Project project = taskManagerBL.ReadProject(id);

            if (project != null)
                return new Project()
                {
                    Name = project.Project1,
                    ProjectId = project.Project_ID,
                    EndDate = project.End_Date.ToString("dd/MM/yyyy"),
                    StartDate = project.Start_Date.ToString("dd/MM/yyyy"),
                    Priority = project.Priority
                };
            return null;
        }

        [HttpPost]
        [ActionName("AddProject")]
        // POST: api/TaskManager
        public void AddProject([FromBody]Project project)
        {
            TaskManagerBL taskManagerBL = new TaskManagerBL();

            taskManagerBL.AddProject(new DA.Project()
            {
                Project1 = project.Name,
                Priority = project.Priority,
                End_Date = Convert.ToDateTime(project.EndDate),
                Start_Date = Convert.ToDateTime(project.StartDate)
            });
        }

        [HttpPost]
        [ActionName("UpdateProject")]
        // PUT: api/TaskManager/5
        public void UpdateProject([FromBody]Project project)
        {
            TaskManagerBL taskManagerBL = new TaskManagerBL();

            taskManagerBL.UpdateProject(new DA.Project()
            {
                Project_ID = project.ProjectId,
                Project1 = project.Name,
                Priority = project.Priority,
                End_Date = Convert.ToDateTime(project.EndDate),
                Start_Date = Convert.ToDateTime(project.StartDate)
            });
        }

        [HttpGet]
        [ActionName("DeleteProject")]
        // DELETE: api/TaskManager/5
        public void DeleteProject(int id)
        {
            TaskManagerBL taskManagerBL = new TaskManagerBL();
            taskManagerBL.DeleteProject(id);
        }
    }
}
