// Date Library

#include <iostream>
#include "clsDate.h"

using namespace std;

int main()
{
	clsDate Date1;

	Date1.Print();

	clsDate Date2("4/12/2022");
	Date2.Print();

	clsDate Date3(20, 12, 2022);
	Date3.Print();

	return 0;
}