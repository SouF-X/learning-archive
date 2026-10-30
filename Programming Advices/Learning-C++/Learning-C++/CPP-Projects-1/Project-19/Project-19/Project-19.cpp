// Circle Area By Diameter

#include <iostream>
#include <cmath>

using namespace std;

float ReadDiameter()
{
    float D;

    cout << "Please enter radious D ?\n";
    cin >> D;

    return D;
}

float CircleAreaByDiameter(float D)
{
    const float PI = 3.141592653589793238;
    float Area = (PI * pow(D, 2)) / 4;

    return Area;
}

void PrintResult(float Area)
{
    cout << "\nCircle Are By Diameter = " << Area << endl;
}

int main()
{
    PrintResult(CircleAreaByDiameter(ReadDiameter()));
    cout << "\n";
    return 0;
}