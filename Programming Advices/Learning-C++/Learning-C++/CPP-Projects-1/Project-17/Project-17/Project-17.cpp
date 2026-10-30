// Triangle Area

#include <iostream>
#include <cmath>

using namespace std;

void ReadNumbers(float& A, float& H)
{
    cout << "Please enter triange base A ?\n";
    cin >> A;

    cout << "Please enter triange height H ?\n";
    cin >> H;
}

float CalulateTriangleArea(float A, float H)
{
    float Area = (A / 2) * H;

    return Area;
}

void PrintResult(float Area)
{
    cout << "\nTriangle Area = " << Area << endl;
}

int main()
{
    float A, H;
    ReadNumbers(A, H);
    PrintResult(CalulateTriangleArea(A, H));

    return 0;
}