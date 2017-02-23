using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyFirstApp
{
    //@djowlz 
    //This is a very simple program that runs a game
    //it is made so to introduce some very fundamental concepts in programming and game making
    //it is buggy, but it demonstrates basic principles
    class Program
    {
        static void Main(string[] args)//The main function is where our code begins to run.
        {
            //this is a custom class, called game
            Game theGame = new Game();
            GoodBye(); //code is executed sequentially, so this will only get called when the game class has finished      
        }

        static void GoodBye()
        {
            //this is a basic game exit screen that should only be run when the game exits
            //it is written so to introduce you to the code seen in the game class
            Console.Clear();
            String bye = "Goodbye...";
            int index = 0;
            while (true)
            {
                Console.Write(bye[index]);
                System.Threading.Thread.Sleep(500);
                index++;

                if (index == bye.Length)
                {
                    break;
                }
            }
        }
    }
}
