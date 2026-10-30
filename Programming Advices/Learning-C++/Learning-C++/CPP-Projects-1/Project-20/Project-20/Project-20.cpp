// Circle Area Inscribed In A Square

#include <iostream>
#include <cmath>

using namespace std;

float ReadSquareSide()
{
    float A;

    cout << "Please enter square side A ?\n";
    cin >> A;

    return A;
}

float CircleAreaInscribedInSquare(float A)
{
    const float PI = 3.141592653589793238;
    float Area = (pow(A, 2) * PI) / 4;

    return Area;
}

void PrintResult(float Area)
{
    cout << "\nCircle Area Inscribed In Square = " << Area << endl;
}

int main()
{
    PrintResult(CircleAreaInscribedInSquare(ReadSquareSide()));
    cout << endl;

    return 0;
}