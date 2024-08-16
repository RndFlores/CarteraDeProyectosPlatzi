
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace ToDo
{
    internal class Program
    {
        public static List<string> TaskList { get; set; } = new List<string>();

        static void Main(string[] args)
        {
            int menuSelected = 0;
            do
            {
                menuSelected = ShowMainMenu();
                if ((Menu)menuSelected == Menu.Add)
                {
                    ShowMenuAdd();
                }
                else if ((Menu)menuSelected == Menu.Remove)
                {
                    ShowMenuRemove();
                }
                else if ((Menu)menuSelected == Menu.List)
                {
                    ShowMenuTaskList();
                }
            } while ((Menu)menuSelected != Menu.Exit);
        }
        /// <summary>
        /// Show the main menu 
        /// </summary>
        /// <returns>Returns option indicated by user</returns>
        public static int ShowMainMenu()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Ingrese la opción a realizar: ");
            Console.WriteLine("1. Nueva tarea");
            Console.WriteLine("2. Remover tarea");
            Console.WriteLine("3. Tareas pendientes");
            Console.WriteLine("4. Salir");

            // Read line
            string? line = Console.ReadLine();
            return Convert.ToInt32(line);
        }

        public static void ShowMenuRemove()
        {
            try
            {
                Console.WriteLine("Ingrese el número de la tarea a remover: ");
                // Show current taks
                ShowMenuTaskList();

                string? removeLine = Console.ReadLine();
                // Remove one position
                int indexToRemove = Convert.ToInt32(removeLine) - 1;
                while (indexToRemove > (TaskList.Count - 1) && indexToRemove < 0)
                {
                    Console.WriteLine("La tarea no existe, vuelva a intentar");
                    removeLine = Console.ReadLine();
                }

                if (indexToRemove > -1 && TaskList.Count > 0)
                {
                    string task = TaskList[indexToRemove];
                    TaskList.RemoveAt(indexToRemove);
                    Console.WriteLine($"Tarea {task} eliminada");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error al eliminar la tarea");
            }
        }

        public static void ShowMenuAdd()
        {
            try
            {
                Console.WriteLine("Ingrese el nombre de la tarea: ");
                string? pushTask = Console.ReadLine();
                TaskList.Add(pushTask);
                Console.WriteLine("Tarea registrada");
            }
            catch (Exception)
            {

                Console.WriteLine("Error al agregar la tarea");
            }
        }

        public static void ShowMenuTaskList()
        {
            if (TaskList?.Count > 0)
            {
                Console.WriteLine("----------------------------------------");
                int indexTask = 0;

                TaskList.ForEach(task =>
                {
                    Console.WriteLine((indexTask + 1) + ". " + task);
                    indexTask++;
                });
                Console.WriteLine("----------------------------------------");
            }
            else
            {
                Console.WriteLine("No hay tareas por realizar");
            }
        }
    }

    public enum Menu
    {
        Add = 1,
        Remove = 2,
        List = 3,
        Exit = 4
    }
}