// Queue Line Tickets System

#include <iostream>
#include "clsQueueLine.h"

using namespace std;

int main()
{
	clsQueueLine PayBillQueue("Z0", 10);
	clsQueueLine SubscriptionsQueue("B0", 5);

	PayBillQueue.IssueTicket();
	PayBillQueue.IssueTicket();
	PayBillQueue.IssueTicket();
	PayBillQueue.IssueTicket();
	PayBillQueue.IssueTicket();

	cout << "\nPay Bills Queue Info:\n";
	PayBillQueue.PrintInfo();

	PayBillQueue.PrintTicketsLineRTL();
	PayBillQueue.PrintTicketsLineLTR();

	PayBillQueue.PrintAllTickets();
	PayBillQueue.ServeNextClient();
	cout << "\nPay Bills Queue After Serving One client";
	PayBillQueue.PrintInfo();

	cout << "\nSubscriptions Queue info:";

	SubscriptionsQueue.IssueTicket();
	SubscriptionsQueue.IssueTicket();
	SubscriptionsQueue.IssueTicket();

	SubscriptionsQueue.PrintInfo();

	SubscriptionsQueue.PrintTicketsLineRTL();
	SubscriptionsQueue.PrintTicketsLineLTR();

	system("pause>0");
	return 0;
}