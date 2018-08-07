
#include "ast.h"

NODE * mknode(char *token, NODE *left, NODE *midLeft, NODE *midRight, NODE *right)
{
	NODE *newnode = (NODE *)malloc(sizeof(NODE));
	char *newstr = (char*)malloc(sizeof(token) + 1);
	strcpy(newstr, token);
	newstr[sizeof(token)] = '\0';
	newnode->left = left;
	newnode->midLeft = midLeft;
	newnode->midRight = midRight;
	newnode->right = right;
	newnode->token = newstr;
	return newnode;
}

void print_tree(NODE* tree, int tab)
{
	int i;

	if (strcmp(tree->token, "(") == 0 || strcmp(tree->token, "(BLOCK") == 0 || strcmp(tree->token, "(ARGS") == 0 || strcmp(tree->token, "(CALL") == 0)
	{
		printf("\n");
		for (i = 0; i<tab; i++)
			printf("   ");
		tab++;
	}


	if (tree)
	{
		if (strcmp(tree->token, "(") == 0 || strcmp(tree->token, "[") == 0 || strcmp(tree->token, "&") == 0 || strcmp(tree->token, "^") == 0)
			printf("%s", tree->token);
		else
			printf("%s ", tree->token);
	}
	if (strcmp(tree->token, ")") == 0)
	{
		printf("\n");
		tab--;
		for (i = 0; i<tab - 1; i++)
			printf("   ");
	}
	if (tree->left || tree->right || tree->midLeft || tree->midRight)
	{

		if (tree->left)
			print_tree(tree->left, tab);
		if (tree->midLeft)
			print_tree(tree->midLeft, tab);
		if (tree->midRight)
			print_tree(tree->midRight, tab);
		if (tree->right)
			print_tree(tree->right, tab);
	}
}