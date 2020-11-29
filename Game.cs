using System;
using System.Collections;


namespace Game_Spaceman
{
    class Game
    {

        public string CodeWord // The word players guess.
        { get; private set; }

        public string CurrentWord // To be filled in as the player guesses correctly.
        { get; private set; }

        public int MaxNumGuess // The number of wrong guesses before the abduction is finished.
        { get;set;}

        public int CurrentNumWrongGuess // Increases with each guess that is not in the codeword.
        { get; set;}

        public string PlayerGuess // the letters the pplayer has guessed.
        { get; set; }

        private string[] wordBank = new string[] { "potato", "stars", "galaxy", "alien", "spaceship","moon","telescope", "coding" };

        ArrayList LettersUsed = new ArrayList();
        

        private Ufo ufos = new Ufo();

        public Game()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            CodeWord = wordBank[rand.Next(wordBank.Length)];
            MaxNumGuess = 5;
            CurrentNumWrongGuess = 0;
            for (int i = 0; i < CodeWord.Length; i++)
            {
                CurrentWord += "_";
            }
            
        }

        public void Greet()
        {
            Console.WriteLine("=============UFO: The Game============= \n Instructions: save your friend from alien abduction by guessing the letters in the codeword. \n The word may or may not be linked to space.");
        }

     
        public void Display()
        {  
            Console.WriteLine(ufos.Stringify());
            Console.WriteLine($"Word: {CurrentWord}");
            Console.WriteLine($"Incorrect Guesses: {CurrentNumWrongGuess}");
            Console.WriteLine("Letters used so far:");
            foreach (string LetterUsed in LettersUsed)
            {
                Console.Write(LetterUsed);
            }
            
            
        }
        public void Ask()
        {
            Console.WriteLine("\nGuess a letter:");
            PlayerGuess = Console.ReadLine().ToLower();
            LettersUsed.Add(PlayerGuess);

            while (PlayerGuess.Trim().Length != 1)
            {
                Console.Clear();
                Console.WriteLine("Input 1 letter at a time");
                return;
            }    

            char guess = PlayerGuess.Trim().ToCharArray()[0];
            if(CodeWord.Contains(guess))
            {
                Console.WriteLine($"{guess} is in the word!");
                for (int i = 0; i < CodeWord.Length; i++)
                {
                    if (guess == CodeWord[i])
                    {
                        Console.Clear();
                        CurrentWord = CurrentWord.Remove(i, 1).Insert(i, guess.ToString());
                    } 
                }
            }
            else
            { 
                CurrentNumWrongGuess++;
                ufos.AddPart();
                Console.Clear();
            }

        }

        public bool DidWin()
        {
            if (CodeWord.Equals(CurrentWord))
            {
                Console.WriteLine($"The word was {CodeWord}");
                Console.WriteLine("You Win!");
                return true;
            }
            else
            {
               
                return false;
            }

        }
        public bool DidLose()
        {
            if (CurrentNumWrongGuess >= MaxNumGuess)
            {
                Console.WriteLine($"The word was {CodeWord}");
                Console.WriteLine("You Lost!");
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}
