#include <iostream>

using namespace std;

class Node
{
public:

	int value;
	Node* next;
};

void InsertAtTheBegenning(Node*& head, int value)
{
	Node* new_node = new Node();

	new_node->value = value;
	new_node->next = head;

	head = new_node;
}

Node* Find(Node* head, int value)
{
	while (head != NULL)
	{
		if (head->value == value)
			return head;

		head = head->next;
	}
}

void InsertAfter(Node* prev_node, int value)
{
	if (prev_node == NULL)
	{
		cout << "the given previous node cannot be NULL";
		return;
	}

	Node* new_node = new Node();

	new_node->value = value;
	new_node->next = prev_node->next;
	prev_node->next = new_node;
}

void InsertAtTheEnd(Node*& head, int value)
{
	Node* new_node = new Node();

	new_node->value = value;
	new_node->next = NULL;

	if (head == NULL)
	{
		head = new_node;
		return;
	}

	Node* LastNode = head;
	while (LastNode->next != NULL)
	{
		LastNode = LastNode->next;
	}

	LastNode->next = new_node;
	return;
}

void DeleteNode(Node*& head, int value)
{
	Node* Current = head, * Prev = head;

	if (head == NULL)
	{
		return;
	}

	if (Current->value == value)
	{
		head = Current->next;
		delete Current;
		return;
	}

	while (Current != NULL && Current->value != value)
	{
		Prev = Current;
		Current = Current->next;
	}

	if (Current == NULL) return;

	Prev->next = Current->next;
	delete Current;
}

void DeleteFirstNode(Node*& head)
{
	Node* Current = head;

	if (head == NULL)
	{
		return;
	}

	head = Current->next;
	delete Current;
}

void DeleteLastNode(Node*& head)
{
	Node* Current = head, * Prev = head;

	if (head == NULL)
	{
		return;
	}

	if (Current->next == NULL)
	{
		head = NULL;
		delete Current;
		return;
	}

	while (Current != NULL && Current->next != NULL)
	{
		Prev = Current;
		Current = Current->next;
	}

	Prev->next = NULL;
	delete Current;
}

void PrintList(Node* head)
{
	cout << '\n';
	while (head != NULL)
	{
		cout << head->value << " ";
		head = head->next;
	}
}

int main()
{
	Node* head = NULL;

	InsertAtTheEnd(head, 1);
	InsertAtTheEnd(head, 2);
	InsertAtTheEnd(head, 3);;
	InsertAtTheEnd(head, 4);;
	InsertAtTheEnd(head, 5);;
	PrintList(head);

	DeleteLastNode(head);
	DeleteFirstNode(head);
	PrintList(head);

	system("pause>0");

	return 0;
}