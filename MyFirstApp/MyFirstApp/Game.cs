using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyFirstApp
{
    //@djowlz 
    //This is the class that contains the game
    class Game
    {
        //These are global variables
        static int gridSize = 21; //This is best if set to an odd number
        static char ballChar = 'o'; //This is the character for the "ball"
        static char blankChar = ' '; //This is the character for the blank spaces in the grid
        static char[,] gridArray = new char[gridSize, gridSize];
        static Random random = new Random(System.DateTime.Now.Millisecond);

        private int numFood = 50;
        private int health = 30;
        public int score = 0;

        public Game()//this is called a constructor, it comes first when this class is instantiated
        {
            int difficulty = 0;
            int spikes = 50;
            while (true)
            {
                Console.WriteLine("Enter Difficulty");
                String input = Console.ReadLine();
                if (int.TryParse(input, out difficulty) == true)
                {
                    difficulty = int.Parse(input);
                    spikes *= difficulty;
                    break;
                }
                else
                {
                    Console.WriteLine("Enter a number (recommend 1 or 2)");
                }
            }
            Console.Clear(); //clear console afte difficulty menu

            int xPos = gridSize / 2; //first we set the player position to the centre
            int yPos = gridSize / 2 + 3; //y we offset a little

            InitGrid(blankChar);//initialise the grid, placing this char in all positions in the array

            //randomly fill the grid
            RandFill('#', numFood);
            RandFill('x', spikes);

            //set the centre block of the grid to the players character
            gridArray[xPos, yPos] = ballChar; 

            bool running = true;
            while (running)//this is an infinite loop, it will never end unless the player dies or presses escape
            {
                Console.WriteLine("   Arrow keys to move : Score " + score + " : Health : " + health); //tell user what they need to do
                PrintCharArray2D(gridArray); //function that prints all the characters in the array

                var ch = Console.ReadKey(false).Key;//gets the key input

                switch (ch) //a switch statement is a bit like an if statement
                {
                    case ConsoleKey.Escape: //if consolekey escape, do something
                        running = false;
                        break;//you must use break
                    case ConsoleKey.UpArrow:
                        if (xPos > 0)
                        {
                            xPos--;
                        }
                        break;//use break
                    case ConsoleKey.DownArrow:
                        if (xPos < gridSize - 1)
                        {
                            xPos++;
                        }
                        break;//use break
                    case ConsoleKey.RightArrow:
                        if (yPos < gridSize - 1)
                        {
                            yPos++;
                        }
                        break;//use break
                    case ConsoleKey.LeftArrow:
                        if (yPos > 0)
                        {
                            yPos--;
                        }
                        break;//use break
                }
                if (gridArray[xPos, yPos] == '#')
                {
                    health += difficulty * difficulty;
                    score += difficulty;
                }
                if (gridArray[xPos, yPos] == 'o')
                {
                    break;
                }
                if (gridArray[xPos, yPos] == 'x')
                {
                    if (health > 30)
                    {
                        health -= 29;
                    }
                    else
                    {
                        running = false;
                        break;
                    }
                }
                gridArray[xPos, yPos] = blankChar; //set balls current position to blank space
                gridArray[xPos, yPos] = ballChar; //sets new position
                Console.Clear(); //clears the screen
            }
            GameOver(this); 
        }

        public void GameOver(Game theGame)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Game Over:  Your Score " + score);
                Console.WriteLine("Would you like to play again Y / N");
                string kInput = Console.ReadLine();
                if (kInput == "Y" || kInput == "Yes" || kInput == "y" || kInput == "yes")
                {
                    Console.Clear(); //clear the console and restart the program
                    theGame = new Game();
                }
                if (kInput == "N" || kInput == "n" || kInput == "No" || kInput == "no")
                {
                    break;
                }
            }
        }

        public static void InitGrid(char theChar)//this is a function, it fills the array with a character
        {
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    gridArray[i, j] = theChar; //fill all spaces in grid with the character
                }
            }
        }

        public static void PrintCharArray2D(Char[,] anArray) //this is another function, it prints our game grid
        {
            Console.WriteLine("   ----------------------------------------");
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    Console.Write(anArray[i, j] + " ");
                }
                Console.WriteLine("");
            }
            Console.WriteLine("   ---------------------------------------");
        }

        public static void RandFill(Char character, int numObjects)
        {
            for (int i = 0; i < numObjects; i++)
            {
                int randNumberX = random.Next();
                int randNumberY = random.Next();
                randNumberX = randNumberX % gridSize;
                randNumberY = randNumberY % gridSize;
                gridArray[randNumberX, randNumberY] = character;
            }
        }
    }
}
