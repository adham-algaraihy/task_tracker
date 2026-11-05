using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace task_tracker
{

    public class taskTracker
    {
        public string Title;
        public string Description;
        public DateTime DueDate;

    }
    internal class Program
    {
        static string[,] TASKS = new string[10, 5];
        static int Count = 0;


        static void menu()
        {
            Console.WriteLine("\n");
            Console.WriteLine("         ===============================");
            Console.WriteLine("         |        TASK TRACKER         |");
            Console.WriteLine("         ===============================");
            Console.WriteLine("         |                             |");
            Console.WriteLine("         |   1-> Add Tasks             |");
            Console.WriteLine("         |   2-> Update Tasks          |");
            Console.WriteLine("         |   3-> View Tasks            |");
            Console.WriteLine("         |   4-> Delete Tasks          |");
            Console.WriteLine("         |   5-> Exit Tasks            |");
            Console.WriteLine("         |                             |");
            Console.WriteLine("         ===============================");
            Console.Write("\n         Your choice From 1 To 5: ");
        }

        static void NEW_TASK()
        {
            Console.WriteLine("Do You Want Anything? --> (y or n)");
            string New = Console.ReadLine();

            if (New.ToLower() == "y")
            {
                Console.Clear();
                menu();
                input();
            }
            else if (New == "n")
            {
                Console.WriteLine("--> Goodbye ^|^ <--");

            }
            else
            {
                Console.WriteLine("it is invalid");
                NEW_TASK();
            }
        }

        static void Add_Tasks()
        {


            if (Count == 10)
            {
                Console.WriteLine("Your task Tracker IS FULL");
            }
            else
            {
                Console.Write("Enter your Title?");
                TASKS[Count, 0] = Console.ReadLine();

                Console.Write("Enter your Description?");
                TASKS[Count, 1] = Console.ReadLine();

                Console.Write("Choose your status: (low - medium - high)? ");
                TASKS[Count, 2] = Console.ReadLine();

                Console.Write("Enter your priority: (pending - InProgress - completed) ?");
                TASKS[Count, 3] = Console.ReadLine();
                TASKS[Count, 4] = DateTime.Now.ToString("MM-dd HH:MM");
                Count++;
            }

            NEW_TASK();
        }

        static void view()
        {
            if (Count == 0)
            {
                Console.WriteLine("Your task Tracker IS NULL");
            }


            else
            {
                Console.WriteLine("This Your task Tracker");

                for (int i = 0; i < Count; i++)
                {
                    Console.WriteLine($"{i + 1} --> Title:{TASKS[i, 0]} | Description:{TASKS[i, 1]} | status:{TASKS[i, 2]} | priority:{TASKS[i, 3]} | DueDate:{TASKS[i, 4]}");
                }

            }

        }

        static void update()
        {
            if (Count == 0)
            {
                Console.WriteLine("Your task Tracker IS NULL");
            }

            view();

            Console.WriteLine("Enter The Num Of The Task You Want To Update ?");

            int upTask = int.Parse(Console.ReadLine()) - 1;

            if (upTask >= 0 && upTask < Count && TASKS[upTask, 0] != null)
            {
                Console.Write("Enter your Title?\t");
                TASKS[upTask, 0] = Console.ReadLine();

                Console.Write("Enter your Description?\t");
                TASKS[upTask, 1] = Console.ReadLine();

                Console.Write("Choose your status: (low - medium - high)? \n");
                TASKS[upTask, 2] = Console.ReadLine();

                Console.Write("Enter your priority: (pending - InProgress - completed) ?\n");
                TASKS[upTask, 3] = Console.ReadLine();
                TASKS[upTask, 4] = DateTime.Now.ToString("MM-dd HH:MM");

                Console.WriteLine("Your Update Is Successfully ^|^ ");
            }

            else
                Console.WriteLine("Your Update Is Invalid !");

            NEW_TASK();


        }
        static void del()
        {
            if (Count == 0)
            {
                Console.WriteLine("Your task Tracker IS NULL");
            }

            view();

            Console.WriteLine("Enter The Num Of The Task You Want To Delete ?");

            int indexToDelete = int.Parse(Console.ReadLine()) - 1;
            for (int i = indexToDelete; i < Count - 1; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    TASKS[i, j] = TASKS[i + 1, j];
                }
            }
            Count--;

            NEW_TASK();
        }
        static void input()
        {
            int input = int.Parse(Console.ReadLine());

            switch (input)
            {
                case 1:
                    Console.WriteLine(" --> Add New Tasks <-- ");
                    Add_Tasks();
                    break;

                case 2:
                    Console.WriteLine(" --> Update Tasks <-- ");
                    update();
                    break;

                case 3:
                    Console.WriteLine(" --> View All Tasks <-- ");
                    view();
                    break;

                case 4:
                    Console.WriteLine(" --> Delete Tasks <-- ");
                    del();
                    break;

                case 5:
                    Console.WriteLine(" --> Exit Tasks <-- ");
                    Exit();
                    break;

                default:
                    Console.WriteLine("You Must Choose From 1 To 5 .");
                    break;

            }
        }
        static void Exit()
        {
            Console.WriteLine("Enter y or n?");
            string exit = Console.ReadLine();

            if (exit.ToLower() == "n")
            {
                Console.Clear();
                menu();
                input();
            }
            else if (exit == "y")
            {
                Console.WriteLine("--> Goodbye ^|^ <--");

            }
            else
                Console.WriteLine("it is invalid");
        }


        static void Main(string[] args)
        {
            menu();
            input();

        }
    }
}