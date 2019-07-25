using System.Collections.Generic;
using TaskManagerDataAccess;

namespace TaskManagerBusiness
{
    public class TaskManagerBL
    {
        public List<Task> ReadAllTask()
        {
            TaskManagerDA taskManagerDA = new TaskManagerDA();
            return taskManagerDA.ReadAllTask();
        }

        public List<ParentTask> ReadAllParentTask()
        {
            TaskManagerDA taskManagerDA = new TaskManagerDA();
            return taskManagerDA.ReadAllParentTask();
        }

        public Task ReadTask(int TaskId)
        {
            TaskManagerDA taskManagerDA = new TaskManagerDA();
            return taskManagerDA.ReadTask(TaskId);
        }

        public ParentTask ReadParentTask(int? TaskId)
        {
            TaskManagerDA taskManagerDA = new TaskManagerDA();
            return taskManagerDA.ReadParentTask(TaskId);
        }

        public void AddTask(Task task)
        {
            TaskManagerDA taskManagerDA = new TaskManagerDA();
            taskManagerDA.AddTask(task);
        }

        public void EndTask(int taskId)
        {
            TaskManagerDA taskManagerDA = new TaskManagerDA();
            taskManagerDA.EndTask(taskManagerDA.ReadTask(taskId));
        }

        public void UpdateTask(Task task)
        {
            TaskManagerDA taskManagerDA = new TaskManagerDA();
            taskManagerDA.UpdateTask(task);
        }

        public List<User> ReadAllUsers()
        {
            TaskManagerDA taskManagerDA = new TaskManagerDA();
            return taskManagerDA.ReadAllUsers();
        }

        public User ReadUser(int? userId)
        {
            TaskManagerDA taskManagerDA = new TaskManagerDA();
            return taskManagerDA.ReadUser(userId);
        }

        public void AddUser(User user)
        {
            TaskManagerDA taskManagerDA = new TaskManagerDA();
            taskManagerDA.AddUser(user);
        }

        public void UpdateUser(User user)
        {
            TaskManagerDA taskManagerDA = new TaskManagerDA();
            taskManagerDA.UpdateUser(user);
        }

        public void DeleteUser(int userId)
        {
            TaskManagerDA taskManagerDA = new TaskManagerDA();
            taskManagerDA.DeleteUser(taskManagerDA.ReadUser(userId));
        }

        public List<Project> ReadAllProjects()
        {
            TaskManagerDA taskManagerDA = new TaskManagerDA();
            return taskManagerDA.ReadAllProjects();
        }

        public Project ReadProject(int? projectId)
        {
            TaskManagerDA taskManagerDA = new TaskManagerDA();
            return taskManagerDA.ReadProject(projectId);
        }

        public void AddProject(Project project)
        {
            TaskManagerDA taskManagerDA = new TaskManagerDA();
            taskManagerDA.AddProject(project);
        }

        public void UpdateProject(Project project)
        {
            TaskManagerDA taskManagerDA = new TaskManagerDA();
            taskManagerDA.UpdateProject(project);
        }

        public void DeleteProject(int projectId)
        {
            TaskManagerDA taskManagerDA = new TaskManagerDA();
            taskManagerDA.DeleteProject(taskManagerDA.ReadProject(projectId));
        }
    }
}