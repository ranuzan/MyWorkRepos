#include "Question.h"

//USER
typedef struct User {
	char userName[21];
	char userPassword[21];
	char permission;
}User;

/*PRINTS*/
void printUser(User user)
{
	printf("UserName: %s\n", user.userName);
	printf("Password: %s\n", user.userPassword);
	printf("Permission: %c\n", user.permission);
}
void printAllUsers(User *usersArr, int size)
{
	int i;

	if (usersArr == NULL)
		return;

	for (i = 0; i < size; i++)
	{
		printUser(usersArr[i]);
		printf("\n");
	}

	return;
}

/*memory allcoating*/
User *addUserToArr(User newUser, User *usersArr, int size)
{
	if (size == 1)	//case array is empty
	{
		usersArr = (User*)malloc(sizeof(User));

		if (usersArr == NULL)
			exit(0);

		usersArr[0] = newUser;
	}
	else
	{
		/*will move all data to temp array delete old array and allocate new
		one with bigger size move all data back from temp and adding new question*/

		usersArr = (User *)realloc(usersArr, size * sizeof(User));
		if (usersArr == NULL)
			exit(0);

		usersArr[size - 1] = newUser;
	}
	return usersArr;	//return pointer to new array
}

/*string test*/
int spaceTest(char *string) //function test if there is space in a string
{
	int i = 0;
	int len = strlen(string);

	for (i = 0; i < len; i++)
	{
		if (string[i] == ' ')
			return 0;
	}

	return 1;

}
int userNameTest(char *name, User *usersArr, int size)
{
	int i;

	for (i = 0; i < size; i++)		//username taken test
		if (strcmp(usersArr[i].userName, name) == 0)
			return 0;

	return spaceTest(name);
}
int FindUserIndex(char *name, User *usersArr, int size)
{
	int i; 

	for (i = 0; i < size; i++)		//runs on array to find name in user list
		if (strcmp(usersArr[i].userName, name) == 0)
			return i;				//case found
	return -1;						//case not found
}
int permissionTest(char permission)
{
	if (permission == 'P' || permission == 'M' || permission == 'E')
		return 1;
	return 0;
}

/*read / write  file*/
int usersStructToFile(User *usersArr, int size)
{
	int i = 0;

	FILE *fp = fopen("user.txt", "w");		//opening file

	if (fp == NULL)					//checks if file opened corectly
	{
		printf("File not found");
		return 0;
	}

	for (i = 0; i < size; i++)
	{
		fprintf(fp, "%s\n", usersArr[i].userName); //print user name
		fprintf(fp, "%s\n", usersArr[i].userPassword);		//prints user password
		fprintf(fp, "%c", usersArr[i].permission);	//print user permission

		if (i == size - 1)	//case last one dont need \n
			break;

		fprintf(fp, "\n");
	}

	fclose(fp);
	return 1;
}
int findNumOfUsers()
{
	int size = 1;					//represent size of array
	char c;					//will contain current char in file

	FILE *fp = fopen("user.txt", "r");		//opening file

	if (fp == NULL)					//checks if file opened corectly
	{
		printf("File not found");
		return 0;
	}

	while (!feof(fp))		//runs on entire file
	{
		fscanf(fp, "%c", &c);
		if (c == '\n')
			size++;
	}

	fclose(fp);
	return (size) / 3;
}
User *usersFileToStruct()
{
	int i = 0;						//index for txt file location
	int size = 0;					//represent size of array
	User newUser;			//data red from file will go this veriable
	User* userArr = NULL;	//will hold all the data in file

	FILE *fp = fopen("user.txt", "r");		//opening file

	if (fp == NULL)					//checks if file opened corectly
	{
		printf("File not found");
		return NULL;
	}

	while (!feof(fp))		//runs on entire file
	{
		fscanf(fp, "%s  %s  %c", &newUser.userName, &newUser.userPassword, &newUser.permission);
		userArr = addUserToArr(newUser, userArr, ++size);
	}

	fclose(fp);
	return userArr;
}

/*add / delete user*/
User *makeUser(User *usersArr, int *size)
{
	system("cls");
	User newUser;
	printf("Enter user info\n");
	do					//accept user name and tests if its ok
	{
		printf("Username:");
		scanf(" %[^\n]s", newUser.userName);

		//newUser.userName[strlen(newUser.userName) - 1] = '\0';	//canceling /n at end of string
		if (userNameTest(newUser.userName, usersArr, size[0]) == 0)
		{
			printf("Username is used or has spaces\n");
			system("pause");
			system("cls");
		}
	} while (userNameTest(newUser.userName, usersArr, size[0]) == 0);


	do						//accept user password and tests if its ok
	{
		printf("Password: ");
		_flushall();
		scanf(" %[^\n]s", newUser.userPassword);

		if (spaceTest(newUser.userPassword) == 0)
		{
			printf("Password has spaces\n");
			system("pause");
			system("cls");
		}
	} while (spaceTest(newUser.userPassword) == 0);

	newUser.permission = 'P';
	printf("user %s has been added\n", newUser.userName);
	system("pause");
	system("cls");
	return addUserToArr(newUser, usersArr, ++size[0]);
}
User *deleteUser(User *usersArr, int *size)
{
	static int index = 1;
	int i, j, cnt;				//index for loops and counter for compering string
	char username[Len];
	printAllUsers(usersArr, size[0]);
	if (usersArr == NULL || size == 0)	//case no users
		return NULL;
	if (index==1)
	{
	scanf("%*[^\n]");
	scanf("%*c");
	index++;
	}

	printf("enter username:");

	fgets(username, Len, stdin);
	username[strlen(username) - 1] = '\0';	//canceling /n at end of string

	for (i = 0; i < size[0]; i++)		//loop array to find if username is in aray
		if (strcmp(usersArr[i].userName, username) == 0) //compering strings
		{
			if (usersArr[i].permission == 'M')
			{
				printf("cannot delete a manager!\n");
				system("pause");
				system("cls");
					return usersArr;
			}
			break;
		}

	if (i >= size[0])		//case not found
	{
		printf("User name not found\n");
		system("pause");
		system("cls");
		return usersArr;
	}

	printf("user %s has been deleted\n", usersArr[i].userName);
	system("pause");
	system("cls");

	User *newUsersArr = NULL;
	newUsersArr = (User *)malloc((size[0] - 1) * sizeof(User));
	if (newUsersArr == NULL)
	{
		printf("memory allcoation failed!");
		system("pause");
		exit(1);
	}
	cnt = 0;						//cnt is index of spot in new array
	for (j = 0; j < size[0]; j++)	//j is index current spot old array
	{
		if (j == i)					//i is index of user to be deleted
			continue;
		newUsersArr[cnt] = usersArr[j];
		cnt++;
	}
	free(usersArr);				//delete old list
	size[0]--;				//decrese size

	return newUsersArr;
}

/*change user information*/
int changeUserPermission(User *usersArr, int size)
{
	int i;	//index for loops and counter for compering string
	char newPermission;
	char username[Len];
	printAllUsers(usersArr, size);
	if (usersArr == NULL || size == 0)
		return 0;

	printf("enter username:\n");
	scanf(" %[^\n]s", username);


	for (i = 0; i < size; i++)		//loop array to find if user is in aray
	{
		if (strcmp(username, usersArr[i].userName)==0)	//case found
		{
			do {
				printf("enter new permission (P/M/E):\n ");
				_flushall();
				scanf(" %c", &newPermission);
				newPermission = toupper(newPermission);
			} while (permissionTest(newPermission)==0);
			usersArr[i].permission = newPermission;
			printf("User permission changed\n");
			system("pause");
			system("cls");
			return 1;
		}
	}

	printf("User name not found\n");		//case not found
	system("pause");
	system("cls");
	return 0;
}


