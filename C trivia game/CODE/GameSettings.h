#include "Score.h"

//GAMESETTING
typedef struct GameSettings {
	int timeToAnswer;
	int pointsByDifficulty[N];
	int lifeSaver;
}GameSettings;

//READ FILE
GameSettings GetSetFromFile()
{
	GameSettings temp;
	FILE* GSP;
	int size,i=0;
	if ((GSP = fopen("gameSettings.txt", "r")) == NULL)
		printf("File couldn't be opened.\n");
	fseek(GSP, 0, SEEK_END);
	size = ftell(GSP);

	if (0 == size)
	{
		printf("There are no game settings\n");
		fclose(GSP);
		temp.timeToAnswer=0;
		return temp;
	}
	fseek(GSP, 0, SEEK_SET);
	while (!feof(GSP))//reads from the file to the leaderboard array and print it to the screen
	{
		fscanf(GSP, "%d %d ", &temp.timeToAnswer, &temp.lifeSaver);
		for (int j = 0; j < N; j++)
			fscanf(GSP, "%d", &temp.pointsByDifficulty[j]);
	}
	return temp;
}

//WRITE FILE
GameSettings UpdateTimeToAnswer()
{
	FILE* GSP;
	GameSettings gameSettings = GetSetFromFile();
	char newTime[4];
	int i = 0, j = 0, flag = 0,len;
	if (gameSettings.timeToAnswer == 0)
	{
		printf("the game setting file is corrupted");
		exit(0);
	}
	printf("current time  to answer is : %d secends \n", gameSettings.timeToAnswer);
	do{
		flag = 0;
		printf("Enter a new time to answer:\n");
		_flushall();
		scanf("%3s", newTime);
		if (newTime[0] == '0')
			{
				printf("Error time cannot be set to zero!!\n");
				flag = 1;
			}
		len = strlen(newTime);
	for (i = 0; i < len; i++)
		if (isdigit(newTime[i]) == 0)
			{
			printf("Error invalid input!!\n");
			flag = 1;
			break;
			}
	} while (flag == 1);
	
	gameSettings.timeToAnswer =atoi(newTime);
	if ((GSP = fopen("gameSettings.txt", "w")) == NULL)
		printf("File couldn't be opened.\n");

	fprintf(GSP,"%d\n%d\n", gameSettings.timeToAnswer, gameSettings.lifeSaver);
	for (int j = 0; j < N; j++)
		fprintf(GSP, "%d ", gameSettings.pointsByDifficulty[j]);
	printf("the new time successfully updated \n");
	fclose(GSP);
	system("pause");
	system("cls");
	return gameSettings;
	
}
GameSettings UpdateLifeSavers(){
	FILE* GSP;
	GameSettings gameSettings = GetSetFromFile();
	char life[3];
	int i = 0, j = 0, flag = 0,len;
	printf("current life savers amount is : %d\n", gameSettings.lifeSaver);
	if (gameSettings.timeToAnswer == 0)
	{
		printf("the game setting file is corrupted");
		exit(1);
	}
	do{
		flag = 0;
		printf("Enter a new life savers amount:\n");
		_flushall();
		scanf("%2s", life);
		len = strlen(life);
		for (i = 0; i < len; i++)
			if (isdigit(life[i]) == 0)
			{
				printf("Error invalid input!!\n");
				flag = 1;
				break;
			}
		if (atoi(life) % 2 != 0 && flag ==0)
		{
			printf("Error life savers amount can only be even!!\n");
			flag = 1;
		}
	} while (flag == 1);

	gameSettings.lifeSaver = atoi(life);
	if ((GSP = fopen("gameSettings.txt", "w")) == NULL)
		printf("File couldn't be opened.\n");

	fprintf(GSP, "%d\n%d\n", gameSettings.timeToAnswer, gameSettings.lifeSaver);
	for (int j = 0; j < N; j++)
		fprintf(GSP, "%d ", gameSettings.pointsByDifficulty[j]);
	printf("the new amount successfully updated \n");
	fclose(GSP);
	system("pause");
	system("cls");
	return gameSettings;

}
GameSettings UpdatePointByDifficulty(){
	FILE* GSP;
	GameSettings gameSettings = GetSetFromFile();
	int i = 0, j = 0, flag = 0,len;
	char key[3],value[4];
	if (gameSettings.timeToAnswer == 0)
	{
		printf("the game setting file is corrupted");
		exit(1);
	}
	for (i = 0; i < N; i++)
			printf("Difficulty (%d)\t\t%d\n",i+1, gameSettings.pointsByDifficulty[i]);
	printf("\n");
	do{
		flag = 0;
		printf("Enter a difficulty number to change:\n");
		_flushall();
		scanf("%2s", key);
		len = strlen(key);
		for (i = 0; i < len; i++)
			if (isdigit(key[i]) == 0)
			{
				printf("Error invalid input!!\n");
				flag = 1;
				break;
			}
		if (atoi(key)<=0 || atoi(key)>10)
		{
			printf("Error difficulty must be between 1 - 10 !!\n");
			flag = 1;
		}
	} while (flag == 1);
	do{
		flag = 0;
		printf("Enter new difficulty value:\n");
		_flushall();
		scanf("%3s", value);
		len = strlen(value);
		for (i = 0; i < len; i++)
			if (isdigit(value[i]) == 0)
			{
				printf("Error invalid input!!\n");
				flag = 1;
				break;
			}
	} while (flag == 1);
	gameSettings.pointsByDifficulty[atoi(key)-1] = atoi(value);
	if ((GSP = fopen("gameSettings.txt", "w")) == NULL)
		printf("File couldn't be opened.\n");

	fprintf(GSP, "%d\n%d\n", gameSettings.timeToAnswer, gameSettings.lifeSaver);
	for (int j = 0; j < N; j++)
		fprintf(GSP, "%d ", gameSettings.pointsByDifficulty[j]);
	printf("the new value successfully updated \n");
	fclose(GSP);
	system("pause");
	system("cls");
	return gameSettings;
}