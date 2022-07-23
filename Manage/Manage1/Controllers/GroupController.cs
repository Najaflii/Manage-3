using Core.Entities;
using Core.Helpers;
using DataAccess.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage1.Controller
{
    public class GroupController
    {

        private GroupRepositories _groupRepositories;

        public GroupController()
        {
            _groupRepositories = new GroupRepositories();
        }

        #region CreateGroup
        public void CreateGroup()
        {
            ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Enter Group Name:");
            string name = Console.ReadLine();
        MaxSize: ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Enter Group Max Size:");
            string size = Console.ReadLine();

            int maxSize;
            bool result = int.TryParse(size, out maxSize);
            if (result)
            {
                Group group = new Group
                {
                    Name = name,
                    MaxSize = maxSize
                };
                var createdGroup = _groupRepositories.Create(group);
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, $"Name:{createdGroup.Name} is successfully created with max size - {createdGroup.MaxSize} ");
            }
            else
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Please, Enter Correct Group Max Size...");
                goto MaxSize;
            }

        }
        #endregion

        #region UpdateGroup

        public void UpdateGroup()
        {

           name: ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Enter Group Name");
            string name = Console.ReadLine();
            var group = _groupRepositories.Get(g => g.Name.ToLower() == name.ToLower());
            if (group != null)
            {
                int oldSize = group.MaxSize;
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Enter new group name");
                string newName = Console.ReadLine();

               size: ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Enter new group size");
                string size = Console.ReadLine();




                int maxSize;
                bool result = int.TryParse(size, out maxSize);
                if (result)
                {
                    var newGroup = new Group
                    {
                        Id = group.Id,
                        Name = newName,
                        MaxSize = maxSize
                    };
                    _groupRepositories.Update(newGroup);
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, $"name:{name}, Max Size:{oldSize} is updated to Name:{newGroup.Name}, Max Size:{newGroup.MaxSize} ");

                }
                else
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Please, enter correct group max size");
                    goto size;
                }


            }
            else
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Please, enter correct group name");
                goto name;           
            }
        }
        #endregion

        #region DeleteGroup
        public void DeleteGroup()
        {
           name: ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Enter Group Name");
            string name = Console.ReadLine();
            var group = _groupRepositories.Get(g => g.Name.ToLower() == name.ToLower());

            if (group != null)
            {
                _groupRepositories.Delete(group);
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, $"{name} group is deleted");
            }
            else
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "This group doesn't exist");
                goto name;
            }
        }
        #endregion

        #region AllGroup

        public void AllGroup()
        {

            var groups = _groupRepositories.GetAll();
            ConsoleHelpers.WriteTextWithColor(ConsoleColor.DarkBlue, "All Groups:");
            foreach (var group in groups)
            {
                Console.WriteLine($"Group Name:{group.Name} , Max Size:{group.MaxSize}");
            }
        }
        #endregion

        #region GetGroupByName
        public void GetGroupByName()
        {
           name: ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Enter group name");
            string name = Console.ReadLine();

            var group = _groupRepositories.Get(g => g.Name.ToLower() == name.ToLower());
            if (group != null)
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, $"Name:{group.Name}, Max Size:{group.MaxSize}");
            }
            else
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "This group doesn't exist");
                goto name;
            }
        }
        #endregion

        #region Exit
        public void Exit()
        {

            ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Exit");
        }
        #endregion
    }
}



