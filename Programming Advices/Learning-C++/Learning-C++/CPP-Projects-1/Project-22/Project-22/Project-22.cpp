// Circle Area Inscrived In An Isosceles Triangle

#include <iostream>
#include <cmath>

using namespace std;

void ReadTriangleData(float& A, float& B)
{
    cout << "Please enter triangle side A ?\n";
    cin >> A;

    cout << "Please enter triangle base B ?\n";
    cin >> B;
}

float CircleAreaByITriangle(float A, float B)
{
    const float PI = 3.141592653589793238;
    float Area = PI * (pow(B, 2) / 4) * ((2 * A - B) / (2 * A + B));

    return Area;
}

void PrintResult(float Area)
{
    cout << "\nCircle Area = " << Area << endl;
    cout << endl;
}

int main()
{
    float A, B;
    ReadTriangleData(A, B);
    PrintResult(CircleAreaByITriangle(A, B));

    return 0;
}