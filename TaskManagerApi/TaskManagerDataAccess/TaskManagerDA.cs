using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerDataAccess
{
    public class TaskManagerDA
    {
        public List<Task> ReadAllTask()
        {
            using (FSECapsuleEntities FSECapsuleEntities = new FSECapsuleEntities())
            {
                return FSECapsuleEntities.Tasks.ToList<Task>();
            }
        }
        public List<ParentTask> ReadAllParentTask()
        {
            using (FSECapsuleEntities FSECapsuleEntities = new FSECapsuleEntities())
            {
                return FSECapsuleEntities.ParentTasks.ToList<ParentTask>();
            }
        }

        public Task ReadTask(int? TaskId)
        {
            using (FSECapsuleEntities FSECapsuleEntities = new FSECapsuleEntities())
            {
                return FSECapsuleEntities.Tasks.Where(t => t.Task_ID == TaskId).FirstOrDefault();
            }
        }

        public ParentTask ReadParentTask(int? TaskId)
        {
            using (FSECapsuleEntities FSECapsuleEntities = new FSECapsuleEntities())
            {
                return FSECapsuleEntities.ParentTasks.Where(t => t.Parent_ID == TaskId).FirstOrDefault();
            }
        }

        public void AddTask(Task task)
        {
            using (FSECapsuleEntities FSECapsuleEntities = new FSECapsuleEntities())
            {
                try
                {
                    FSECapsuleEntities.Tasks.Add(task);
                    FSECapsuleEntities.SaveChanges();
                }
                catch (Exception ex)
                {

                }
            }
        }

        public void EndTask(Task taskId)
        {
            using (FSECapsuleEntities FSECapsuleEntities = new FSECapsuleEntities())
            {
                Task task = FSECapsuleEntities.Tasks.Where(t => t.Task_ID == taskId.Task_ID).FirstOrDefault();
                FSECapsuleEntities.Tasks.Remove(task);
                FSECapsuleEntities.SaveChanges();
            }
        }

        public void UpdateTask(Task task)
        {
            using (FSECapsuleEntities FSECapsuleEntities = new FSECapsuleEntities())
            {
                Task currentTask = FSECapsuleEntities.Tasks.Where(t => t.Task_ID == task.Task_ID).FirstOrDefault();
                currentTask.Parent__ID = task.Parent__ID;
                currentTask.Task1 = task.Task1;
                currentTask.Priority = task.Priority;
                currentTask.Start_Date = task.Start_Date;
                currentTask.End_Date = task.End_Date;
                currentTask.Project_ID = task.Project_ID;
                FSECapsuleEntities.SaveChanges();
            }
        }

        public List<User> ReadAllUsers()
        {
            using (FSECapsuleEntities FSECapsuleEntities = new FSECapsuleEntities())
            {
                return FSECapsuleEntities.Users.ToList<User>();
            }
        }

        public User ReadUser(int? userId)
        {
            using (FSECapsuleEntities FSECapsuleEntities = new FSECapsuleEntities())
            {
                return FSECapsuleEntities.Users.Where(t => t.User_ID == userId).FirstOrDefault();
            }
        }

        public void AddUser(User user)
        {
            using (FSECapsuleEntities FSECapsuleEntities = new FSECapsuleEntities())
            {
                FSECapsuleEntities.Users.Add(user);
                FSECapsuleEntities.SaveChanges();
            }
        }

        public void UpdateUser(User user)
        {
            using (FSECapsuleEntities FSECapsuleEntities = new FSECapsuleEntities())
            {
                User currentUser = FSECapsuleEntities.Users.Where(t => t.User_ID == user.User_ID).FirstOrDefault();
                currentUser.Employee_ID = user.Employee_ID;
                currentUser.FirstName = user.FirstName;
                currentUser.LastName = user.LastName;
                currentUser.Task_ID = user.Task_ID;
                currentUser.Project_ID = user.Project_ID;
                FSECapsuleEntities.SaveChanges();
            }
        }

        public void DeleteUser(User user)
        {
            using (FSECapsuleEntities FSECapsuleEntities = new FSECapsuleEntities())
            {
                User currentUser = FSECapsuleEntities.Users.Where(t => t.User_ID == user.User_ID).FirstOrDefault();
                FSECapsuleEntities.Users.Remove(currentUser);
                FSECapsuleEntities.SaveChanges();
            }
        }

        public List<Project> ReadAllProjects()
        {
            using (FSECapsuleEntities FSECapsuleEntities = new FSECapsuleEntities())
            {
                return FSECapsuleEntities.Projects.ToList<Project>();
            }
        }

        public Project ReadProject(int? projectId)
        {
            using (FSECapsuleEntities FSECapsuleEntities = new FSECapsuleEntities())
            {
                return FSECapsuleEntities.Projects.Where(t => t.Project_ID == projectId).FirstOrDefault();
            }
        }

        public void AddProject(Project project)
        {
            using (FSECapsuleEntities FSECapsuleEntities = new FSECapsuleEntities())
            {
                FSECapsuleEntities.Projects.Add(project);
                FSECapsuleEntities.SaveChanges();
            }
        }

        public void UpdateProject(Project project)
        {
            using (FSECapsuleEntities FSECapsuleEntities = new FSECapsuleEntities())
            {
                Project currentProject = FSECapsuleEntities.Projects.Where(t => t.Project_ID == project.Project_ID).FirstOrDefault();
                currentProject.Project1 = project.Project1;
                currentProject.Start_Date = project.Start_Date;
                currentProject.End_Date = project.End_Date;
                currentProject.Priority = project.Priority;
                FSECapsuleEntities.SaveChanges();
            }
        }

        public void DeleteProject(Project project)
        {
            using (FSECapsuleEntities FSECapsuleEntities = new FSECapsuleEntities())
            {
                Project currentProject = FSECapsuleEntities.Projects.Where(t => t.Project_ID == project.Project_ID).FirstOrDefault();
                FSECapsuleEntities.Projects.Remove(currentProject);
                FSECapsuleEntities.SaveChanges();
            }
        }
    }
}
