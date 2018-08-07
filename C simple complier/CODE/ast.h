#define _CRT_SECURE_NO_WARNINGS

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <ctype.h>

typedef struct node
{
	char *token;
	struct node *left;
	struct node *midLeft;
	struct node *midRight;
	struct node *right;
}NODE;

NODE* ast;
NODE* mknode(char* token, NODE* left, NODE* midLeft, NODE* midRight, NODE* right);
void print_tree(NODE* tree, int tab);

