using Core.Constants;
using Core.Entities;
using Core.Helpers;
using DataAccess.Implementations;
using Manage1.Controller;
using Manage1.Controllers;
using System;
namespace Manage1
{
    public class Manage1
    {
        static void Main()
        {

            GroupController _groupController = new GroupController();
            StudentController _studentController=new StudentController();

            ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "Welcome :) ");
            Console.WriteLine("---");

            while (true)
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "1 - Create Group");
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "2 - Update Group");
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "3 - Delete Group");
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "4 - All Group");
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "5 - Get Group By Name");
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "6 - Create Student");
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "7 - Update Student");
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "8 - Delete Student");
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "9 - Get All Student By Group");
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "10 - Get Student By Group");
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "0 - Exit");



                Console.WriteLine("---");


                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Please, Select Option");
                string number = Console.ReadLine();

                int selectedNumber;
                bool result = int.TryParse(number, out selectedNumber);

                if (result)
                {
                    if (selectedNumber >= 0 && selectedNumber <= 10)
                    {
                        switch (selectedNumber)
                        {
                          
                            case (int)Options.CreateGroup:
                                _groupController.CreateGroup();
                                break;
                            case (int)Options.UpdateGroup:
                                _groupController.UpdateGroup();
                                break;
                            case (int)Options.DeleteGroup:
                                _groupController.DeleteGroup();
                                break;
                            case (int)Options.AllGroup:
                                _groupController.AllGroup();
                                break;
                            case (int)Options.GetGroupByName:
                                _groupController.GetGroupByName();
                                break;
                            case (int)Options.CreateStudent:
                                _studentController.CreateStudent();
                                break;
                                case (int)Options.UpdateStudent:
                                _studentController.UpdateStudent(); 
                                break;
                            case (int)Options.DeleteStudent:
                                _studentController.DeleteStudent();
                                break;
                            case (int)Options.GetAllStudentByGroup:
                                _studentController.GetAllStudentByGroup();
                                break;
                            case (int)Options.GetStudentByGroup:
                                _studentController.GetStudentByGroup();
                                break;
                            case (int)Options.Exit:
                                _groupController.Exit();    
                                return;
                        }
                    }
                    else
                    {
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Please select correct option");
                    }
                }
                else
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Please select correct option");
                }
            }
        }
    }
}