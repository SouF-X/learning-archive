// Print Number From N To 1

#include <iostream>

using namespace std;

int ReadNumber()
{
    int Number;

    cout << "Please enter number ?\n";
    cin >> Number;

    return Number;
}

void PrintRangeFromNto1_UsingWhile(int N)
{
    int  Counter = N;

    cout << "Print range using While Statement : \n";

    while (Counter >= 1)
    {
        cout << Counter << endl;
        Counter--;
    }

}

void PrintRangeFromNto1_UsingDoWhile(int N)
{
    int Counter = N;

    cout << "Print range using Do...While Statement : \n";

    do
    {
        cout << Counter << endl;
        Counter--;

    } while (Counter >= 1);
}

void PrintRangeFromNto1_UsingFor(int N)
{
    cout << "Print range using For Statement : \n";

    for (int Counter = N; Counter >= 1; Counter--)
    {
        cout << Counter << endl;
    }
}

int main()
{
    int N = ReadNumber();

    PrintRangeFromNto1_UsingWhile(N);
    PrintRangeFromNto1_UsingDoWhile(N);
    PrintRangeFromNto1_UsingFor(N);

    return 0;
}