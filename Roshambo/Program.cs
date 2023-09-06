// Welcome statements
Console.WriteLine("Welcome to the game, it's still a work in progress :)");
Console.WriteLine("Please enjoy");

// Declarations
int playerScore = 0;
int computerScore = 0;
int totalScore = 0; // when would this even be useful LOL
string userInput;
string playerChoice;
bool valid = false;

// Program
Console.WriteLine("What is your score?");
userInput = Console.ReadLine();
playerScore = Convert.ToInt32(userInput);
totalScore = playerScore + computerScore;
Console.WriteLine("Your score is " + playerScore + ", and the opponent's score is " + computerScore);
if (playerScore > computerScore)
{
    Console.WriteLine("You win!");
}
else if (computerScore > playerScore)
{
    Console.WriteLine("You lose!");
}
else
{
    Console.WriteLine("It's a tie!");
}

do
{
    Console.WriteLine("Rock, Paper, or Scissors?");
    playerChoice = Console.ReadLine();
    switch (playerChoice)
    {
        case "rock":
            Console.WriteLine("You chose " + playerChoice);
            valid = true;
            break;
        case "paper":
            Console.WriteLine("You chose " + playerChoice);
            valid = true;
            break;
        case "scissors":
            Console.WriteLine("You chose " + playerChoice);
            valid = true;
            break;
        default:
            Console.WriteLine("Not an option.");
            break;
    }
}
while (!valid);


// star pyramid challenge
for  (int i = 0; i < ; i++)