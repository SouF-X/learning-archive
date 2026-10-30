// Math Game

#include <iostream>
#include <cmath>
#include <string>
#include <cstdlib>

using namespace std;

enum enLevel { Easy = 1, Med = 2, Hard = 3, MixLevel = 4};
enum enOpType { Add = 1, Sub = 2, Mul = 3, Div = 4, MixOpType = 5};
enum enPassOrFail { Fail = 1, Pass = 2 };

struct stQuestionInfo
{
	short FirstNumber = 0;
	short SecondNumber = 0;
	char OpType;
	short Result = 0;
};

struct stGameResult
{
	short TotalQuestion = 0;
	short NumberOfRightQuestions = 0;
	short NumberOfWrongQuestions = 0;
	enPassOrFail Pass;
};

int RandomNumber(int From, int To)
{
	// Function to generate a random number
	int randNum = rand() % (To - From + 1) + From;
	return randNum;
}

short HowManyQuestions()
{
	int Questions = 0;

	do
	{
		cout << "How Many Questions do you want to answer ? ";
		cin >> Questions;
	} while (Questions < 0);

	return Questions;
}

enLevel GenerateQuestionLevel()
{
	int QuestionLevel = 0;

	do
	{
		cout << "Enter Questions Level [1] Easy, [2] Med, [3] Hard, [4] Mix ? ";
		cin >> QuestionLevel;
	} while (QuestionLevel < 0);

	return (enLevel)QuestionLevel;
}

string PrintLevel(enLevel Level)
{
	switch (Level)
	{
	case enLevel::Easy:
		return "Easy";
	case enLevel::Med:
		return "Medium";
	case enLevel::Hard:
		return "Hard";
	default:
		return "Mix";
	}
}

enOpType GenerateOperationType()
{
	int OpType = 0;

	do
	{
		cout << "Enter OperatinoType [1] Add, [2] Sub, [3] Mul, [4] Div, [5] Mix ? ";
		cin >> OpType;
	} while (OpType < 0);

	return (enOpType)OpType;
}

enOpType CheckOpType(enOpType OpType)
{
	if (OpType == enOpType::Add)
	{
		return enOpType::Add;
	}
	else if (OpType == enOpType::Sub)
	{
		return enOpType::Sub;
	}
	else if (OpType == enOpType::Mul)
	{
		return enOpType::Mul;
	}
	else if (OpType == enOpType::Div)
	{
		return enOpType::Div;
	}
	else if (OpType == enOpType::MixOpType)
	{
		return (enOpType)RandomNumber(1, 4);
	}
}

char GetOpTypeChar(enOpType OperationType)
{
	char OpType = '+';

	switch (OperationType)
	{
	case enOpType::Add:
		OpType = '+';
		break;
	case enOpType::Sub:
		OpType = '-';
		break;
	case enOpType::Mul:
		OpType = '*';
		break;
	case enOpType::Div:
		OpType = '/';
		break;
	}

	return OpType;
}

string PrintOpType(enOpType OpType)
{
	switch (OpType)
	{
	case enOpType::Add:
		return "+";
	case enOpType::Sub:
		return "-";
	case enOpType::Mul:
		return "*";
	case enOpType::Div:
		return "/";
	default:
		return "Mix";
	}
}

short FirstNumber(enLevel Level)
{
	short FirstNumber = 0;

	switch (Level)
	{
	case enLevel::Easy:
		return FirstNumber = RandomNumber(1, 10);
	case enLevel::Med:
		return FirstNumber = RandomNumber(10, 50);
	case enLevel::Hard:
		return FirstNumber = RandomNumber(50, 100);
	case enLevel::MixLevel:
		return FirstNumber = RandomNumber(1, 100);
	}
}

short SecondNumber(enLevel Level)
{
	int SecondNumber = 0;

	switch (Level)
	{
	case enLevel::Easy:
		return SecondNumber = RandomNumber(1, 10);
	case enLevel::Med:
		return SecondNumber = RandomNumber(10, 50);
	case enLevel::Hard:
		return SecondNumber = RandomNumber(50, 100);
	case enLevel::MixLevel:
		return SecondNumber = RandomNumber(1, 100);
	}

}

int CalculateResult(short FirstNumber, short SecondNumber, char OpType)
{
	int Result = 0;

	if (OpType == '+')
		return Result = FirstNumber + SecondNumber;
	else if (OpType == '-')
		return Result= FirstNumber - SecondNumber;
	else if (OpType == '*')
		return Result = FirstNumber * SecondNumber;
	else
		return Result = FirstNumber / SecondNumber;

}

void FillQuestionInfo(stQuestionInfo& QuestionInfo, enLevel Level, enOpType OperationType)
{
	QuestionInfo.FirstNumber = FirstNumber(Level);
	QuestionInfo.SecondNumber = SecondNumber(Level);
	QuestionInfo.OpType = GetOpTypeChar(CheckOpType(OperationType));
}

bool CheckingResult(int UserResult, int Result)
{
	if (UserResult == Result)
	{
		cout << "\nRight Answer :-)\n";
		system("color 2F");
		return true;
	}
	else
	{
		cout << "\nWrong Answer :-(\n";
		cout << "The Right Answer is : " << Result << endl;
		system("color 4F");
		return false;
	}
}

enPassOrFail PassOrFail(short NumberOfRightQuestions, short NumberOfWrongQuestions)
{
	if (NumberOfRightQuestions > NumberOfWrongQuestions)
		return enPassOrFail::Pass;
	else
		return enPassOrFail::Fail;
}

stGameResult FillGameResult(short HowManyQuestions, short NumberOfRightQuestions, short NumberOfWrongQuestions)
{
	stGameResult GameResult;

	GameResult.TotalQuestion = HowManyQuestions;
	GameResult.NumberOfRightQuestions = NumberOfRightQuestions;
	GameResult.NumberOfWrongQuestions = NumberOfWrongQuestions;
	GameResult.Pass = PassOrFail(NumberOfRightQuestions, NumberOfWrongQuestions);

	return GameResult;
}

string CheckPassingOrNot(stGameResult GameResult)
{
	if (GameResult.Pass == enPassOrFail::Pass)
		return "Pass :-)";
	else
		return "Fail :-(";
}

stGameResult PlayGame(short HowManyQuestions, enLevel QuestionLevel, enOpType OperationType)
{
	stQuestionInfo QuestionInfo;

	short NumberOfRightQuestions = 0, NumberOfWrongQuestions = 0;

	int Result = 0;

	for (int QuestionNumber = 1; QuestionNumber <= HowManyQuestions; QuestionNumber++)
	{
		FillQuestionInfo(QuestionInfo, QuestionLevel, OperationType);
		QuestionInfo.Result = CalculateResult(QuestionInfo.FirstNumber, QuestionInfo.SecondNumber, QuestionInfo.OpType);

		cout << "\n\nQuestion [" << QuestionNumber << "/" << HowManyQuestions << "]\n";
		cout << QuestionInfo.FirstNumber << endl;
		cout << QuestionInfo.SecondNumber << " " << QuestionInfo.OpType << endl;
		cout << "__________\n";
		cin >> Result;

		if (CheckingResult(Result, QuestionInfo.Result))
			NumberOfRightQuestions++;
		else
			NumberOfWrongQuestions++;

	}

	return FillGameResult(HowManyQuestions, NumberOfRightQuestions, NumberOfWrongQuestions);
}

void ShowGameOverScreen(stGameResult GameResult)
{
	cout << "\n\n______________________________________\n\n";
	cout << "  Final Results is " << CheckPassingOrNot(GameResult) << endl;
	cout << "______________________________________\n\n";
}

void FinalScreenGameColor(short NumberOfRightQuestions, short NumberOfWrongQuestions)
{
	if (NumberOfRightQuestions > NumberOfWrongQuestions)
		system("color 2F");
	else
		system("color 4F");
}

void PrintGameResult(stGameResult GameResult, string Level, string OpType)
{
	cout << "Number of Questions     : " << GameResult.TotalQuestion << endl;
	cout << "Questions Level         : " << Level << endl;
	cout << "OpType                  : " <<  OpType << endl;
	cout << "Number of Right Answers : " << GameResult.NumberOfRightQuestions << endl;
	cout << "Number of Wrong Answers : " << GameResult.NumberOfWrongQuestions << endl;
	cout << "______________________________________\n";

	FinalScreenGameColor(GameResult.NumberOfRightQuestions, GameResult.NumberOfWrongQuestions);
}

void ResetScreen()
{
	system("cls");
	system("color 0F");
}

void StartGame()
{
	char playagain = 'Y';

	do
	{
		ResetScreen();

		short Questions = HowManyQuestions();
		enLevel QuestionLvl = GenerateQuestionLevel();
		enOpType OpType = GenerateOperationType();

		stGameResult GameResult = PlayGame(Questions, QuestionLvl, OpType);

		ShowGameOverScreen(GameResult);

		PrintGameResult(GameResult, PrintLevel(QuestionLvl), PrintOpType(OpType));

		cout << "\nDo You Want To Play Again (Y / N) ? ";
		cin >> playagain;

	} while (playagain == 'Y' || playagain == 'y');
}


int main()
{
	srand((unsigned)time(NULL));

	StartGame();

	return 0;
}