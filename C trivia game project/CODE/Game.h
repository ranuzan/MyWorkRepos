#include "GameSettings.h" 
#define uRED   "\x1B[31m"
#define uGRN   "\x1B[32m"
#define uWHT   "\x1B[37m"

//GAME
typedef struct Game {
	Question *questionList;
	int numOfQuestion;
	User *UserList;
	int numOfUsers;
	GameSettings settings;
}Game;

/*declerations*/
void makeHeadline();
void mainMenu();
void login(Game newGame);
void playerMenu(Game newGame, int userIndex);
void startNewGame(Game newGame, int userIndex);
void editorMenu(Game newGame, int userIndex);
void managerMenu(Game newGame, int userIndex);
void registerPlayer(Game newGame);
void EasterEgg();
int Check(char k);
void menuHelp();
void gameHelp();
void printUI(Game newGame, int score, int replaceQuestion, int fiftyFifty, int currentQuestion);
int pickQuestion(Game newGame, int currentDifficulty);
char getGameInput(Game newGame, int questionIndex, int score, int replaceQuestion, int fiftyFifty);
char useFiftyFifty(Game newGame, int questionIndex);
char useReplaceQuestion(Game newGame, int *questionIndex);
void gameOver();
void RunAllUnitTests();
void freemem(Game newGame)
{
	if (newGame.questionList != NULL)
		free(newGame.questionList);
	if (newGame.UserList != NULL)
		free(newGame.UserList);
}
int compereString(char *str1, char *str2)
{
	return (strcmp(str1, str2)==0);
}

/*login /register*/
void registerPlayer(Game newGame)
{
	FILE *GP;
	User newUser;
	int i = 0, len, flag = 0;
	char Name[Len], Last[Len], Email[Len * 2];
	if ((GP = fopen("UserDetails.txt", "a")) == NULL)
		printf("File couldn't be opened.\n");
	printf("Enter your details:\n");
	do					//accept user name and tests if its ok
	{
		printf("Username:");
		scanf(" %[^\n]s", newUser.userName);

		if (userNameTest(newUser.userName, newGame.UserList, newGame.numOfUsers) == 0)
		{
			printf("Username is used or has spaces\n");
			system("pause");
			system("cls");
		}
	} while (userNameTest(newUser.userName, newGame.UserList, newGame.numOfUsers) == 0);

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


	fseek(GP, 0, SEEK_END);
	fprintf(GP, "\n%s\n%s\n%c\n", newUser.userName, newUser.userPassword, newUser.permission);


	do {
		flag = 0;
		printf("First Name: ");
		scanf("%20s", Name);
		len = strlen(Name);
		for (i = 0; i < len; i++)
			if (isdigit(Name[i]) != 0)
			{
				printf("Error name cannot contain digits!!\n");
				flag = 1;
				break;
			}

	} while (flag == 1);
	Name[0] = toupper(Name[0]);

	do {
		flag = 0;
		printf("Last Name: ");
		scanf("%20s", Last);
		len = strlen(Last);
		for (i = 0; i < len; i++)
			if (isdigit(Last[i]) != 0)
			{
				printf("Error last name cannot contain digits!!\n");
				flag = 1;
				break;
			}

	} while (flag == 1);
	Last[0] = toupper(Last[0]);
	do {
		flag = 1;
		printf("Email: ");
		scanf("%41s", Email);
		len = strlen(Email);
		for (i = 0; i < len; i++)
			if (Email[i] == '@')
			{
				flag = 0;
				break;
			}
		if (i==len && flag == 1)
			printf("Error incorrect email address!!\n");

	} while (flag == 1);
	fprintf(GP, "%s\n%s\n%s", Name, Last, Email);
	fclose(GP);
	newGame.UserList = (User*)realloc(newGame.UserList, sizeof(User)*(newGame.numOfUsers + 1));
	newGame.numOfUsers++;
	strcpy(newGame.UserList[newGame.numOfUsers - 1].userName, newUser.userName);
	strcpy(newGame.UserList[newGame.numOfUsers - 1].userPassword, newUser.userPassword);
	newGame.UserList[newGame.numOfUsers - 1].permission = newUser.permission;
	usersStructToFile(newGame.UserList, newGame.numOfUsers);
	printf("Registaration complete challenger!!!\n");
	system("pause");
	system("cls");

}
void login(Game newGame)
{
	newGame.UserList = usersFileToStruct();
	newGame.numOfUsers = findNumOfUsers();
	makeHeadline();
	int userIndex, x;
	char string1[Len], string2[Len];
	_flushall();
	printf("Enter Username\n");
	scanf("%s", string1);
	userIndex = FindUserIndex(string1, newGame.UserList, newGame.numOfUsers);
	if (userIndex == -1)
	{
		printf("UserName not found\n");
		system("pause");
		system("cls");
		freemem(newGame);
		return;
	}
	_flushall();
	printf("enter password\n");
	x = 0;

	do {
		string2[x] = _getch();
		_putch('*');
		x++;
	} while (x != strlen(string2) && string2[x - 1] != '\r');// make password awesome *****!!!!!
	string2[x - 1] = '\0';
	printf("\n");

	if (compereString(newGame.UserList[userIndex].userPassword, string2) == 0)
	{
		printf("incorect password\n");
		system("pause");
		system("cls");
		freemem(newGame);
		return;
	}
	switch (newGame.UserList[userIndex].permission)
	{
	case 'P':
	{
		playerMenu(newGame, userIndex);
		break;
	}

	case 'E':
	{
		editorMenu(newGame, userIndex);
		break;
	}
	case 'M':
	{
		managerMenu(newGame, userIndex);
		break;

	}
	default:
	{
		printf("something went wrong : unknown error\n ");
		freemem(newGame);
		return;
		break;
	}

	}
}

/*menus*/
void mainMenu()
{
	Game newGame;
	newGame.settings = GetSetFromFile();

	char choice;
	
	do
	{
		//updating  lists
		newGame.questionList = questionFileToStruct();
		newGame.numOfQuestion = findNumofQuestion();
		newGame.UserList = usersFileToStruct();
		newGame.numOfUsers = findNumOfUsers();


		makeHeadline();
		printf("Welcome to Trivia Game\n");
		printf("MAIN MENU\n");
		printf("1. Login\n");//DONE
		printf("2. Register\n");//DONE
		printf("3. what happens when u win?\n");
		printf("4. Run Unit tests\n");
		printf("0. Exit\n");//DONE
		printf("Please enter your choice: ");
		choice = _getch();
		printf("%c\n", choice);
		switch (choice) {
		case '1':
			system("cls");
			//Login function call
			login(newGame);
			break;
		case '2':
			system("cls");
			//Register function call
			registerPlayer(newGame);
			freemem(newGame);
			break;
		case '3':
			system("cls");
			freemem(newGame);
			EasterEgg();
			break;
		case '4':
			system("cls");
			RunAllUnitTests();
			freemem(newGame);
			system("pause");
			system("cls");
			break;
		case '0':
			system("cls");
			printf("Goodbye\n");
			freemem(newGame);
			exit(0);
			break;
		default:
			system("cls");
			printf("Invalid input!!!\n");
			freemem(newGame);
			system("pause");
			system("cls");
		}
	} while (choice != 0);
}
void playerMenu(Game newGame, int userIndex)
{
	system("cls");

	printf("Welcome %s!\n", newGame.UserList[userIndex].userName);

	char choice;
	do
	{
		makeHeadline();
		printf("PLAYER MENU\n");
		printf("1. Start new game\n");//DONE (need to code time and score calc)
		printf("2. View Leaderboard\n");//DONE
		printf("3. Help\n");
		printf("9. LogOut\n");//DONE
		printf("0. Exit\n");//DONE
		printf("Please enter your choice: ");
		choice = _getch();
		printf("%c\n", choice);
		switch (choice) {
		case '1':
			system("cls");
			//play function call
			startNewGame(newGame, userIndex);
			break;
		case '2':
			system("cls");
			View_leaderboard();
			system("pause");
			system("cls");
			//leaderboard function call
			break;
		case '3':
			system("cls");
			menuHelp();
			//Help function call
			break;
		case '9':
			system("cls");
			//log out function call
			freemem(newGame);
			return;
			break;
		case '0':
			system("cls");
			printf("Thanks for playing goodbye\n");
			freemem(newGame);
			exit(0);
			break;
		default:
			system("cls");
			printf("Invalid input!!!\n");
			system("pause");
			system("cls");
		}
	} while (choice != 0);

}
void editorMenu(Game newGame, int userIndex)
{
	system("cls");

	printf("Welcome %s!\n", newGame.UserList[userIndex].userName);

	char choice;
	do
	{
		makeHeadline();
		printf("Editor MENU\n");
		printf("1. View all question\n");//DONE
		printf("2. Add questions\n");//DONE
		printf("3. Edit question\n");//DONE
		printf("4. Change answer time\n");//DONE
		printf("5. Change lifesaver amount\n");//DONE
		printf("6. Update score calculation\n");//DONE
		printf("9. LogOut\n");//DONE
		printf("0. Exit\n");//DONE
		printf("Please enter your choice: ");
		choice = _getch();
		printf("%c\n", choice);
		switch (choice) {
		case '1':
			system("cls");
			editorViewQuestions(newGame.questionList, newGame.numOfQuestion);
			break;
		case '2':
			system("cls");
			newGame.questionList=editorAddQuestion(newGame.questionList, &newGame.numOfQuestion);
			system("pause");
			questionArrayToFile(newGame.questionList,newGame.numOfQuestion);
			system("cls");
			break;
		case '3':
			system("cls");
			editorViewOrEditQuestion(newGame.questionList, newGame.numOfQuestion);
			questionArrayToFile(newGame.questionList, newGame.numOfQuestion);
			break;
		case '4':
			system("cls");
			newGame.settings = UpdateTimeToAnswer();
			break;
		case '5':
			system("cls");
			newGame.settings = UpdateLifeSavers();
			break;
		case '6':
			system("cls");
			newGame.settings = UpdatePointByDifficulty();
			break;
		case '9':
			system("cls");
			freemem(newGame);
			//log out function call
			return;
			break;
		case '0':
			system("cls");
			printf("Goodbye\n");
			freemem(newGame);
			exit(0);
			break;
		default:
			system("cls");
			printf("Invalid input!!!\n");
			system("pause");
			system("cls");
			break;
		}
	} while (choice != 0);
}
void managerMenu(Game newGame, int userIndex)
{
	system("cls");

	printf("Welcome %s!\n", newGame.UserList[userIndex].userName);

	char choice;
	do
	{
		makeHeadline();
		printf("MANAGER MENU\n");
		printf("1. Clear leaderboard\n");//DONE
		printf("2. Remove user from leaderboard\n");//DONE
		printf("3. Create new player\n");//DONE
		printf("4. Delete user\n");//DONE
		printf("5. Change user permission\n");
		printf("9. Logout\n");//DONE
		printf("0. Exit\n");//DONE
		printf("Please enter your choice: ");
		choice = _getch();
		printf("%c\n", choice);
		switch (choice) {
		case '1':
			system("cls");
			Delete_all_scores();
			printf("leaderboard has been cleared!!\n");
			system("pause");
			system("cls");
			break;
		case '2':
			system("cls");
			DeleteScore();
			system("cls");
			break;
		case '3':
			newGame.UserList = makeUser(newGame.UserList, &newGame.numOfUsers);
			usersStructToFile(newGame.UserList, newGame.numOfUsers);
			break;
		case '4':
			system("cls");
			newGame.UserList=deleteUser(newGame.UserList, &newGame.numOfUsers);
			usersStructToFile(newGame.UserList, newGame.numOfUsers);
			break;
		case '5':
			system("cls");
			changeUserPermission(newGame.UserList, newGame.numOfUsers);
			usersStructToFile(newGame.UserList, newGame.numOfUsers);
			break;
		case '9':
			system("cls");
			freemem(newGame);
			return;
			break;
		case '0':
			system("cls");
			printf("GoodBye\n");
			freemem(newGame);
			exit(0);
			break;
		default:
			system("cls");
			printf("Invalid input!!!\n");
			system("pause");
			system("cls");
			break;
		}
	} while (choice != 0);
}

/*game*/
void startNewGame(Game newGame, int userIndex)
{
	newGame.settings = GetSetFromFile();
	printf("*********************************************************************\n");
	printf("Game instructions\n");
	printf("You will recive points based on correct answer,and answer time.\n");
	printf("Dificulty rises with every correct answer.\n");
	printf("Wrong answer will result in losing the game.\n");
	printf("you can exit the game at anytime but your progress will be lost.\n");
	printf("you can press h at any time to see further help.\n");
	printf("Good luck!\n");
	printf("*********************************************************************\n");
	system("pause");
	system("cls");


	int i, score = 0, dif = 0, questionIndex,storeIndex=-1;
	int replaceQuestion = newGame.settings.lifeSaver / 2;
	int fiftyFifty = newGame.settings.lifeSaver / 2;
	char answer;
	int timer;


	/* Intializes random number generator */
	time_t t;	//for srand
	time_t diff,t1 , t2;	//for timer
	srand((unsigned)time(&t));

	for (i = 1; i <= 10; i++)
	{
		printUI(newGame,score,replaceQuestion,fiftyFifty,i);//prints user interface

		questionIndex = pickQuestion(newGame,i);//picks random question

		t1 = time(0);

		answer = toupper(getGameInput(newGame, questionIndex, score, replaceQuestion, fiftyFifty));//getting input
		

		if (answer == '1')		//case 50/50
		{
			system("cls");
			printUI(newGame, score, replaceQuestion, --fiftyFifty, i);//prints user interface
			printf("%s\n", newGame.questionList[questionIndex].questionBody);//print current question
			answer=useFiftyFifty(newGame, questionIndex);
		}
		if (answer == '2')		//case reaplce question
		{
			system("cls");
			printUI(newGame, score, --replaceQuestion, fiftyFifty, i);//prints user interface
			answer = useReplaceQuestion(newGame, &questionIndex);
		}
		if (answer == '9')	//case return to main menu
		{
			system("cls");
			return;
		}
		if (answer == '0')	//case exit
		{
			printf("**Thank you for playing**\n");
			printf(" **Goodbye Challenger**   \n");
			freemem(newGame);
			exit(0);
		}
		if (isalpha(answer)==1)		//case a-d
		{
			if (answer != newGame.questionList[questionIndex].answer)//case wrong
			{
				printf(uRED" Wrong answer! \n"uWHT);
				printf("Game Over!\n");
				system("pause");
				system("cls");
				break;
			}
			else
			{
				//printf("t1 is %")
				t2 = time(0);
				diff = t2 - t1;
				timer = (int)diff;
				printf("you answered in %d seconds\n", timer);
				printf(uGRN"CORRECT ANSWER!\n"uWHT);
				if (timer >= newGame.settings.timeToAnswer)
				{
					score += newGame.settings.pointsByDifficulty[i - 1]*10 ;
				}
				else
				{
					score += (newGame.settings.pointsByDifficulty[i - 1]*10) + ((newGame.settings.timeToAnswer - timer)*2);
				}
				system("pause");
				system("cls");
				continue;
			}
		}

	}
	if (i == 11)	//case winner
		EasterEgg();

	else gameOver();//case loser

	
	AddPlayerScore(newGame.UserList[userIndex].userName, score,1);
	return;
}
int pickQuestion(Game newGame, int currentDifficulty)//function picks random question pram difficulty
{
	/* Intializes random number generator */
	time_t t;
	srand((unsigned)time(&t));

	int index, dif=0;
	while (dif != currentDifficulty)
	{
		index = rand() % newGame.numOfQuestion;
		dif = newGame.questionList[index].difficulty;
	}
	return index;
		
}//function picks random question pram difficulty
char useFiftyFifty(Game newGame,int questionIndex)
{
	/* Intializes random number generator */
	time_t t;
	srand((unsigned)time(&t));

	char answer;
	char correct, incorect;
	int tmp;

	correct = newGame.questionList[questionIndex].answer;
	do {
		tmp = rand() % 4 + 1;
		if (tmp == 1)
			incorect = 'a';
		if (tmp == 2)
			incorect = 'b';
		if (tmp == 3)
			incorect = 'c';
		if (tmp == 4)
			incorect = 'd';
	} while (toupper(incorect) == toupper(correct));

	if(rand() % 2==0)//random way of printing
	printf("50/50 - %c  or  %c :\n", tolower(correct), incorect);
	else
	printf("50/50 - %c  or  %c :\n", incorect, tolower(correct));


	do				//input test only a-d
	{
		printf("enter you answer a-d (cannot use more lifesavers)\n");
		answer = toupper(_getch());
		if (answer == 'A' || answer == 'B' || answer == 'C' || answer == 'D' || answer == '9' || answer == '0')
			break;
		else printf("invalid input!\n");
	} while (1);

	return answer;
}
char useReplaceQuestion(Game newGame, int *questionIndex)
{
	char answer;

	int newQuestionIndex = -1;
	
	do
	{
		newQuestionIndex = pickQuestion(newGame, newGame.questionList[questionIndex[0]].difficulty);
	} while (questionIndex[0] == newQuestionIndex);

	questionIndex[0] = newQuestionIndex;
	printf("%s\n", newGame.questionList[newQuestionIndex].questionBody);//print current question


	do				//input test only a-d
	{
		printf("enter you answer a-d (cannot use more lifesavers)\n");
		answer = toupper(_getch());
		if (answer == 'A' || answer == 'B' || answer == 'C' || answer == 'D' || answer == '9' || answer == '0')
			break;
		else printf("invalid input!\n");
	} while (1);

	return answer;

}

/*help*/
void menuHelp()
{
	FILE *fp = fopen("help.txt", "r");		//opening file
	if (fp == NULL)
		return;
	char c;

	while (!feof(fp))
	{
		fscanf(fp, "%c", &c);
		while (c != '*')//stopes print at * (marker of end of menu help)
		{
			printf("%c", c);
			fscanf(fp, "%c", &c);
		}
		if (c == '*')
			break;
	}
	fclose(fp);
	system("pause");
	system("cls");
	return;
}
void gameHelp()
{
	FILE *fp = fopen("help.txt", "r");		//opening file
	if (fp == NULL)
		return;
	char c;

	while (!feof(fp))
	{
		fscanf(fp, "%c", &c);
		while (c != '*')
		{
			fscanf(fp, "%c", &c);
		}
		break;
	}
	while (!feof(fp))		//start printing at * (marker of start of game help
	{
		fscanf(fp, "%c", &c);
		printf("%c", c);
	}
	fclose(fp);
	system("pause");
	system("cls");
	return;
}

/*input test*/
int Check(char ans) {
	ans = toupper(ans);
	if (ans == 'A' || ans == 'B' || ans == 'C' || ans == 'D' || ans == '1' || ans == '2' || ans == '0' || ans == '9' || ans == 'H')
		return 1;
	return 0;

}
char getGameInput(Game newGame, int questionIndex, int score, int replaceQuestion, int fiftyFifty)
{
	system("cls");
	printUI(newGame, score, replaceQuestion, fiftyFifty, newGame.questionList[questionIndex].difficulty);
	printf("%s\n", newGame.questionList[questionIndex].questionBody);//print current question

	char answer;

	do
	{									//checking input
		printf("enter your answer a-d :\n ");
		answer = _getch();
		if (Check(answer) == 0)
		{
			printf("invalid input!\n");
			system("pause");
			system("cls");
			printUI(newGame, score, replaceQuestion, fiftyFifty, newGame.questionList[questionIndex].difficulty);
			printf("%s\n", newGame.questionList[questionIndex].questionBody);//print current question
		}
	} while (Check(answer) == 0);

	if (answer == 'h' || answer == 'H')		//game help
	{
		system("cls");
		gameHelp();
		printUI(newGame, score, replaceQuestion, fiftyFifty, newGame.questionList[questionIndex].difficulty);
		return getGameInput(newGame, questionIndex, score, replaceQuestion, fiftyFifty);
	}

	if (answer == '1' && fiftyFifty == 0)  //case no 50/50 left
	{
		printf("You have no 50/50 lifesavers left!\n");
		system("pause");
		return getGameInput(newGame, questionIndex, score, replaceQuestion, fiftyFifty);
	}

	if (answer == '2' && replaceQuestion == 0)  //case no Replace Question left
	{
		printf("You have no replace question lifesavers left!\n");
		system("pause");
		return getGameInput(newGame, questionIndex, score, replaceQuestion, fiftyFifty);
	}
	return answer;

}

/*ALL PRINTS*/
void makeHeadline()
{

	FILE *fp = fopen("1.txt", "r");		//opening file
	if (fp == NULL)
		printf("problem with file");
	char c;

	while (!feof(fp))
	{
		fscanf(fp, "%c", &c);		//prints headline char by char
		printf("%c", c);
	}
	fclose(fp);

}
void EasterEgg()
{
	int i = 0;
	char c;
	FILE *fp;
	time_t start, end;
	while (i<4)
	{
		fp = fopen("pikachuRight.txt", "r");
		while (!feof(fp))
		{
			fscanf(fp, "%c", &c);
			printf(uWHT"%c", c);
		}
		fclose(fp);
		time(&start);
		do time(&end); while (difftime(end, start) <= 0.1);
		system("cls");

		fp = fopen("pikachuLeft.txt", "r");
		while (!feof(fp))
		{
			fscanf(fp, "%c", &c);
			printf("%c", c);
		}
		fclose(fp);
		time(&start);
		do time(&end); while (difftime(end, start) <= 0.1);
		system("cls");
		i++;
	}
}
void printUI(Game newGame, int score, int replaceQuestion, int fiftyFifty, int currentQuestion)
{
	printf("------------------------------------------------------\n");
	printf("Score: %d\t\t\t Replace Question : %d \n", score, replaceQuestion);
	printf("Question time: %d\t\t\t    50/50 : %d\n", newGame.settings.timeToAnswer, fiftyFifty);
	printf("------------------------------------------------------\n");
	printf("[1] for 50 / 50\t\t[2] for replace question\n");
	printf("[9] back to Menu\t[0] to exit\n\n");
	printf("Question number %d:\n", currentQuestion);
}
void gameOver()
{
	{

		FILE *fp = fopen("gameover.txt", "r");		//opening file
		if (fp == NULL)
			printf("problem with file");
		char c;

		while (!feof(fp))
		{
			fscanf(fp, "%c", &c);		//prints headline char by char
			printf("%c", c);
		}
		fclose(fp);
		printf("\n\n");
		system("pause");
		system("cls");
	}
}