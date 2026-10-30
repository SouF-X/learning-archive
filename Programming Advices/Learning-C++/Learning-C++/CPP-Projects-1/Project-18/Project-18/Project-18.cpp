// Circle Area

#include <iostream>
#include <cmath>

using namespace std;

float ReadRadious()
{
    float R;

    cout << "Please enter radious R ?\n";
    cin >> R;

    return R;
}

float CircleArea(float R)
{
    float const PI = 3.141592653589793238;
    float Area = PI * pow(R, 2);

    return Area;
}

void PrintResult(float Area)
{
    cout << "\nCirlce Area = " << Area << endl;
    cout << endl;
}

int main()
{
    PrintResult(CircleArea(ReadRadious()));

    return 0;
}