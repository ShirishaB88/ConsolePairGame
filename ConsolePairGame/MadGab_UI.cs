using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePairGame
{
    public class MadGab_UI
    {
        
        public void Run()
        {
            RunMenu();
        }
        //Arrays
        string[] questions = { " Dawn Biafra Eight Duff DeedArc"," Strobe Bury Sink Cream "," Is Bunch Pops Queer Pans","Donut Hark Twos Train Jazz","Know Whiff Fans Herbs Hut","Swedes Hicks Dean",
                                   " Abe Odd hull Luck Oak","Ace Lip Puff That Hung" ,"Bat Tree Snot Ink Looted","Ditch Chews Haze Hum Thin" ," Freeze Age Ha! Leak Hood Fell Owe " ,"Hiawatha dean edge van pyre",
                                   "Mare Eek Ate Danish Lee Hole Sin","Pie Rate Softy Care Hip Been","Thick Hull Foam Heck Sicko"
                                    };
       
        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Mad Gab\n" +
                                    "...the game where it's not what you SAY, it's what you HEAR...\n\n");
                Console.WriteLine("Don't be afraid to say the phrase out loud (It might help you out ;) )\n" +
                    $"You only have 3 chances to guess the correct phrase\n" +
                    $"Good luck!\n");
                Console.WriteLine("Enter Player Name here:");
                string playerName = Console.ReadLine();
                Console.WriteLine($"\nWelcome, {playerName}, please enter the number of the desired selection\n" +
                    $"1:Play Game\n" +
                    $"2:Exit\n");
                string userSelection = Console.ReadLine();
                switch (userSelection)
                {
                    case "1":
                        PlayGame();
                        break;
                    default:
                        break;
                }
            }
        }
        private void PlayGame()
        {
            Random random = new Random();
            int indexNumber = random.Next(questions.Length);
            Console.Clear();
            Console.WriteLine("Press enter for the first question.");
            string playerAnswer = Console.ReadLine().ToLower();
            CheckAnswers(playerAnswer);
            Console.WriteLine("Press any key to continue to home screen..........");
            Console.ReadKey();
        }
        private void CheckAnswers(string playerAnswer)
        {
            string[] answers =
            {               "don't be afraid of the dark","strawberries and cream","spongebob squarepants","don't talk to strangers","no ifs ands or buts","sweet sixteen",
                "a bottle of coke","a slip of the tongue","batteries not included","did you say something","for he is a jolly good fellow",
                "i was a teenage vampire","mary kate and ashley oslen","pirates of the carribean","the gulf of mexico"
            };
            int playerGuesses = 0;
            int guessLimit = 3;
            bool outOfGuesses = false;
            int qnum = 0;
            Random random = new Random();
            bool continueToRunTwo = true;
            while (continueToRunTwo)
            {
                foreach (string question in questions.OrderBy(q => random.Next()))
                {
                    Console.WriteLine(question);
                    Console.WriteLine("Enter the answer: ");
                    playerAnswer = Console.ReadLine();
                    if (answers.Contains(playerAnswer.ToLower()))
                    {
                        Console.WriteLine("It's True");
                        qnum++;
                        Console.WriteLine("No of question attempted: " + qnum);
                        Console.WriteLine("You are doing great! Guess another one!");
                        if (qnum == questions.Length)
                        {
                            Console.WriteLine("You Won the game!!!.");
                            continueToRunTwo = false;
                            break;
                        }
                        Console.ReadLine();
                        break;
                    }
                    if (!answers.Contains(playerAnswer.ToLower()) && playerGuesses < 2)
                    {    //Wrong Answer on First Try
                        playerGuesses++;
                        Console.WriteLine("Sorry that's the wrong answer\n" +
                            $"You have had {playerGuesses} incorrect guesses so far.\n\n");
                        string playerAnswerTwo = Console.ReadLine().ToLower();
                        //Wrong Anser on Second Try
                        if (!answers.Contains(playerAnswerTwo.ToLower()) && playerGuesses < 3)
                        {
                            playerGuesses++;
                            Console.WriteLine("Sorry that's the wrong answer\n" +
                                $"You have had {playerGuesses} incorrect guesses so far.\n\n");
                        }
                       // Right Answer on Second Try
                        else if (answers.Contains(playerAnswerTwo.ToLower()))
                        {
                            Console.WriteLine("Congratulations! Your guess is right!\n");
                            continueToRunTwo = false;
                            if (qnum == questions.Length)
                            {
                                continueToRunTwo = false;
                                break;
                            }
                            break;
                        }
                        string playerAnswerThree = Console.ReadLine().ToLower();
                        //Wrong answer on third try
                        if (!answers.Contains(playerAnswerThree.ToLower()) && playerGuesses < 3)
                        {
                            playerGuesses++;
                            Console.WriteLine("You are out of guesses :(\n" +
                            "GAME OVER");
                            outOfGuesses = true;
                            //continueToRunTwo = false;
                            break;
                        }
                        //Right answer on third try
                        else if (answers.Contains(playerAnswerThree.ToLower()))
                        {
                            Console.WriteLine("Congratulations! Your guess is right!\n");
                            continueToRunTwo = false;
                            if (qnum == questions.Length)
                            {
                                continueToRunTwo = false;
                                break;
                            }
                            break;
                        }
                    }
                }

            }
            
        }

    }
}
