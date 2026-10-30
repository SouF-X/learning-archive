// Stone Paper Scissor Game

#include <iostream>
#include <string>
#include <cstdlib>
#include <cmath>

using namespace std;

enum enChoice { Stone = 1, Paper = 2, Scissor = 3 };

int RandomNumber(int From, int To)
{
	int randNum = rand() % (To - From + 1) + From;
	return randNum;
}

int AskHowManyRounds()
{
	int Rounds = 0;

	do
	{
		cout << "How Many Rounds 1 to 10 ?\n";
		cin >> Rounds;
	} while (Rounds > 10);

	return Rounds;
}

enChoice UserChoice()
{
	int Choice = 0;

	cout << "Your Choice: [1]:Stone, [2]:Paper, [3]:Scissors ? ";
	cin >> Choice;

	return enChoice(Choice);
}

string GenerateUserChoice(enChoice UserChoice)
{
	if (UserChoice == enChoice::Stone)
		return "Stone";
	else if (UserChoice == enChoice::Paper)
		return "Paper";
	else
		return "Scissor";
}

enChoice ComputerChoice()
{
	int Choice = RandomNumber(1, 3);

	return enChoice(Choice);
}

string GenerateComputerChoice(enChoice ComputerChoice)
{
	if (ComputerChoice == enChoice::Stone)
		return "Stone";
	else if (ComputerChoice == enChoice::Paper)
		return "Paper";
	else
		return "Scissor";
}

string FindTheWinner(enChoice ComputerChoice, enChoice UserChoice)
{
	if (ComputerChoice == enChoice::Stone && UserChoice == enChoice::Paper)
	{
		return "Player1";
	}
	else if (ComputerChoice == enChoice::Stone && UserChoice == enChoice::Scissor)
	{
		return "Computer";
	}
	else if (ComputerChoice == enChoice::Stone && UserChoice == enChoice::Stone)
	{
		return "No Winner";
	}
	else if (ComputerChoice == enChoice::Paper && UserChoice == enChoice::Stone)
	{
		return "Computer";
	}
	else if (ComputerChoice == enChoice::Paper && UserChoice == enChoice::Scissor)
	{
		return "Player1";
	}
	else if (ComputerChoice == enChoice::Paper && UserChoice == enChoice::Paper)
	{
		return "No Winner";
	}
	else if (ComputerChoice == enChoice::Scissor && UserChoice == enChoice::Stone)
	{
		return "Player1";
	}
	else if (ComputerChoice == enChoice::Scissor && UserChoice == enChoice::Paper)
	{
		return "Computer";
	}
	else if (ComputerChoice == enChoice::Scissor && UserChoice == enChoice::Scissor)
	{
		return "No Winner";
	}

}

void ScreenColor(enChoice ComputerChoice, enChoice UserChoice)
{
	string winner = FindTheWinner(ComputerChoice, UserChoice);

	if (winner == "Computer")
	{
		system("color 4F");
		cout << "\a";
	}
	else if (winner == "Player1")
	{
		system("color 2F");
	}
	else
		system("color 6F");
}

void GameResult(int GameRounds, short Player1Win, short ComputerWin, short DrawTimes)
{
	string Winner = "";

	if (Player1Win < ComputerWin)
		Winner = "Computer";
	else if (Player1Win > ComputerWin)
		Winner = "Player1";
	else
		Winner = "No Winner";


	cout << "\t\t\t\t__________________________________________________________________\n\n";
	cout << "\t\t\t\t\t\t\     +++ G a m e   O v e r +++\n";
	cout << "\n\t\t\t\t__________________________________________________________________\n";
	cout << "\n\t\t\t\t________________________ [ Game Results ] _______________________\n\n";

	cout << "\t\t\t\tGame Rounds        : " << GameRounds << endl;
	cout << "\t\t\t\tPlayer1 won times  : " << Player1Win << endl;
	cout << "\t\t\t\tComputer won times : " << ComputerWin << endl;
	cout << "\t\t\t\tDraw times         : " << DrawTimes << endl;
	cout << "\t\t\t\tFinal Winner       : " << Winner << endl;
	cout << "\t\t\t\t__________________________________________________________________\n\n";

}

void GenerateRoundsAndGameResult(int Rounds)
{
	short CountPlayer1Win = 0;
	short CountComputerWin = 0;
	short CountDrawTimes = 0;

	for (int i = 1; i <= Rounds; i++)
	{
			cout << "\nRound [" << i << "] begins:\n\n";
			enChoice UsChoice = UserChoice();
			enChoice CPchoice = ComputerChoice();


			cout << "\n\n_______________Round [" << i << "]_______________\n\n";
			cout << "Player1  Choice: " << GenerateUserChoice(UsChoice) << endl;
			cout << "Computer Choice: " << GenerateComputerChoice(CPchoice) << endl;
			cout << "Round Winner   : " "[" << FindTheWinner(CPchoice, UsChoice) << "]" << endl;
			cout << "_______________________________________\n\n";


			ScreenColor(CPchoice, UsChoice);

			if (FindTheWinner(CPchoice, UsChoice) == "Player1")
				CountPlayer1Win++;
			else if (FindTheWinner(CPchoice, UsChoice) == "Computer")
				CountComputerWin++;
			else
				CountDrawTimes++;
	}

	GameResult(Rounds, CountPlayer1Win, CountComputerWin, CountDrawTimes);
}

int main()
{
	srand((unsigned)time(NULL));

	bool PLAY = true;

	while (PLAY)
	{

		int Rounds = AskHowManyRounds();
		string playagain;

		GenerateRoundsAndGameResult(Rounds);

		cout << "\t\t\t\tDo You want to play again ? (Y / N) : ";
		cin >> playagain;

		if (playagain == "N" || playagain == "n")
		{
			PLAY = false;
		}

		cout.flush();
		system("clear");
	}


	return 0;
}