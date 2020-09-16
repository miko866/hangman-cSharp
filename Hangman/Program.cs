using System;
using System.Threading;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] messages =
            {
                @" _   _   ___   _   _  _____ ___  ___  ___   _   _ 
| | | | / _ \ | \ | ||  __ \|  \/  | / _ \ | \ | |
| |_| |/ /_\ \|  \| || |  \/| .  . |/ /_\ \|  \| |
|  _  ||  _  || . ` || | __ | |\/| ||  _  || . ` |
| | | || | | || |\  || |_\ \| |  | || | | || |\  |
\_| |_/\_| |_/\_| \_/ \____/\_|  |_/\_| |_/\_| \_/",
                @" _____   ___  ___  ___ _____  _____  _   _  _____  _____ ______ 
|  __ \ / _ \ |  \/  ||  ___||  _  || | | ||  ___||  ___|| ___ \
| |  \// /_\ \| .  . || |__  | | | || | | || |__  | |__  | |_/ /
| | __ |  _  || |\/| ||  __| | | | || | | ||  __| |  __| |    / 
| |_\ \| | | || |  | || |___ \ \_/ /\ \_/ /| |___ | |___ | |\ \ 
 \____/\_| |_/\_|  |_/\____/  \___/  \___/ \____/ \____/ \_| \_|",
                @"
__   __ _____  _   _   _    _  _____  _   _ 
\ \ / /|  _  || | | | | |  | ||_   _|| \ | |
 \ V / | | | || | | | | |  | |  | |  |  \| |
  \ /  | | | || | | | | |/\| |  | |  | . ` |
  | |  \ \_/ /| |_| | \  /\  / _| |_ | |\  |
  \_/   \___/  \___/   \/  \/  \___/ \_| \_/"
            };
            string[] counting =
            {
                @" __  
/  | 
`| | 
 | | 
_| |_
\___/",
                @" _____ 
/ __  \
`' / /'
  / /  
./ /___
\_____/",
                @" _____ 
|____ |
    / /
    \ \
.___/ /
\____/ ",
                @"  ___ 
  /   |
 / /| |
/ /_| |
\___  |
    |_/",
                @" _____ 
|  ___|
|___ \ 
    \ \
/\__/ /
\____/ 
       "
            };

            bool gameOver = false;

            string startWord = "guess";
            char[] maskStartWord = new string('-', startWord.Length).ToCharArray();
            string currentGuessedCharacter = "";
            string guessedCharactersList = "";

            int guessingTries = startWord.Length * 2;

            int violations = 0;

            Console.CursorVisible = false;
			

            for(int i = counting.Length; i > 0; i--)
			{
                Console.WriteLine(messages[0]);
                Console.WriteLine(counting[i - 1]);
				Thread.Sleep(1000);
                Console.Clear();
			}

            while(!gameOver)
			{
              
                Console.WriteLine("Guess the word: {0}", new string(maskStartWord));
				Console.WriteLine("Guesses characters: {0}", guessedCharactersList);
				Console.WriteLine("You have {0} tries left.", guessingTries);
				Console.WriteLine();
				Console.Write("Your next guess is: ");

                currentGuessedCharacter = Console.ReadLine();
                guessedCharactersList += currentGuessedCharacter[0] + ", ";

                if (currentGuessedCharacter.Length > 1)
				{
                    if (violations >=  1)
					{
                        guessingTries--;
					}
                    Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("\nYou have to input only One single character!");
					Console.WriteLine("You will lose 2 tries for each following violation of the rule!");
                    Thread.Sleep(3000);
                    Console.ResetColor();

                    violations++;
				}

                if (startWord.Contains(currentGuessedCharacter[0].ToString()))
				{
                    for (int i = 0; i < startWord.Length; i++)
					{
                        if (startWord[i] == currentGuessedCharacter[0])
						{
                            maskStartWord[i] = currentGuessedCharacter[0];
						}
					}
				}

                guessingTries--;
                Console.Clear();

                if (guessingTries == 0)
				{
                    gameOver = true;
					Console.WriteLine(messages[1]);
				} else if (!(new string(maskStartWord).Contains("-")))
				{
                    gameOver = true;
                    Console.WriteLine(messages[2]);
				}

             
			}
        }
    }
}
