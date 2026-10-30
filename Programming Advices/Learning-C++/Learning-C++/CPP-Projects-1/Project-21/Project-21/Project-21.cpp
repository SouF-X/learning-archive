// Circle Area Along The Circumference

#include <iostream>
#include <cmath>

using namespace std;

float ReadCircumference()
{
    float L;

    cout << "Please enter  Circumference?\n";
    cin >> L;

    return L;
}

float CircleAreaAlongTheCircumference(float l)
{
    const float PI = 3.14159265358979323846;
    float Area = pow(l, 2) / (4 * PI);

    return Area;
}

void PrintResult(float Area)
{
    cout << "\nCircle Area Along The Circumference = " << Area << endl;
    cout << "\n";
}

int main()
{
    PrintResult(CircleAreaAlongTheCircumference(ReadCircumference()));

    return 0;
}