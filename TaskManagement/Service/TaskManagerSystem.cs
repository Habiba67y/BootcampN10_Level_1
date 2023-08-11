using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Interfaces;
using TaskManagement.Model;

namespace TaskManagement.Service
{
    public class TaskManagerSystem
    {
        //public void AddUser(User user)
        //{

        //}
        public static int AuthenticateUser(string Login, string Password, User user)
        {
            if (user.Login == Login && user.Password == Password)
            {
                return user.Role;
            }
            return 2;
        }
        //void CreateProject()
        //void AddTaskToProject()
        //AssignTaskToDeveeloper()
        //SendNotificationToUser()
        //GetNotificationForUser()
    }
}
