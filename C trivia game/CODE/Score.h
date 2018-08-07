#include "User.h"


/*SCORE*/
typedef struct Score {
	char userName[21];
	int result;
}Score;

//delete
void Delete_all_scores(){
	fclose(fopen("leaderboard.txt", "w"));

}
void DeleteScore(){
	FILE *SP;
	char Name[Len];
	int size,i = 0, j = 0, cnt = 0, NewCnt = 0,len,k;
	Score *leaderboard = (Score*)malloc(sizeof(Score)), *temp = (Score*)malloc(sizeof(Score));

	if ((SP = fopen("leaderboard.txt", "r")) == NULL)
		printf("File couldn't be opened.\n");

	fseek(SP, 0, SEEK_END);
	size = ftell(SP);

	if (0 == size)
	{
		printf("The leaderboard is empty\n");
		system("pause");
		system("cls");
		fclose(SP);
		free(temp);
		free(leaderboard);
		return;
	}
	fseek(SP, 0, SEEK_SET);
	printf("****Leaderboard****\n");
	while (!feof(SP))//reads from the file to the leaderboard array and print it to the screen
	{

		fscanf(SP,"%s %d", leaderboard[i].userName, &leaderboard[i].result);
		
		len = strlen(leaderboard[i].userName);
		printf("%s", leaderboard[i].userName);
		for (k = 0; k < 30 - len; k++)
			printf(" ");
		printf("%d\n",leaderboard[i].result);


		i++;
		leaderboard = (Score*)realloc(leaderboard, sizeof(Score)*(i+1));
		cnt++;
	}
		printf("\nEnter a player name to delete is score:\n");
		scanf("%20s", Name);

	for (i = 0; i < cnt; i++)//creates a temp array without the given "Name" 
	{
		if (strcmp(leaderboard[i].userName, Name) != 0)
		{
			temp = (Score*)realloc(temp, sizeof(Score)*(j + 1));
			strcpy(temp[j].userName, leaderboard[i].userName);
			temp[j].result = leaderboard[i].result;
			j++;
			NewCnt++;
		}
	}
	if (NewCnt == 0) //if when the user is the only user in the leaderboard and he has been deleted
	{
		printf("The leaderboard is empty\n");
		Delete_all_scores();
		fclose(SP);
		free(temp);
		free(leaderboard);
		system("pause");
		system("cls");
		return;
	}
	if (j == cnt)
	{
		printf("User %s was not found!\n",Name);
		fclose(SP);
		free(temp);
		free(leaderboard);
		return;
	}
	free(leaderboard);
	Delete_all_scores();
	fclose(SP);
	if ((SP = fopen("leaderboard.txt", "w")) == NULL)
		printf("File couldn't be opened.\n");
	i = 0;
	
	while (i<NewCnt-1)
	{
		fprintf(SP,"%s    %d\n", temp[i].userName, temp[i].result);
		i++;
	}
	fprintf(SP, "%s    %d", temp[i].userName, temp[i].result);


	fclose(SP);
	free(temp);
	printf("User: %s scores has been deleted\n", Name);
	system("pause");
	system("cls");
}

//print
int View_leaderboard()
{
	FILE *SP;
	int size, i = 0,len,k;
	Score *leaderboard = (Score*)malloc(sizeof(Score));

	if ((SP = fopen("leaderboard.txt", "r")) == NULL)
		printf("File couldn't be opened.\n");

	fseek(SP, 0, SEEK_END);
	size = ftell(SP);

	if (0 == size)
	{
		printf("The leaderboard is empty\n");
		system("pause");
		system("cls");
		fclose(SP);
		free(leaderboard);
		return 0;
	}
	fseek(SP, 0, SEEK_SET);
	printf("**********Leaderboard**********\n");
	while (!feof(SP))//reads from the file to the leaderboard array and print it to the screen
	{
		fscanf(SP, "%s %d", leaderboard[i].userName, &leaderboard[i].result);


		len = strlen(leaderboard[i].userName);
		printf("%s", leaderboard[i].userName);
		for (k = 0; k < 30 - len; k++)
			printf(" ");
		printf("%d\n", leaderboard[i].result);

		i++;
		leaderboard = (Score*)realloc(leaderboard, sizeof(Score)*(i + 1));
	}
	fclose(SP);
	free(leaderboard);
	return 1;
}

//add score
int AddPlayerScore(char* Name,int result,int flag)
{
	FILE *SP;
	int size, i = 0, j = 0, cnt = 0, swapResult=0;
	char swapName[Len];
	Score *leaderboard = (Score*)malloc(sizeof(Score));
	if (leaderboard == NULL)
	{
		printf("memory problem\n");
		return 0;
	}

	if ((SP = fopen("leaderboard.txt", "r")) == NULL)
	{
		printf("File couldn't be opened.\n");
		return 0;
	}

	fseek(SP, 0, SEEK_END);
	size = ftell(SP);
	//case of an empty leaderboard
	if (size == 0)
	{
		fclose(SP);
		if ((SP = fopen("leaderboard.txt", "w")) == NULL)
			printf("File couldn't be opened.\n");
		strcpy(leaderboard[0].userName, Name);
		leaderboard[0].result = result;
		fprintf(SP,"%s %d", leaderboard[0].userName, leaderboard[0].result);
		fclose(SP);
		free(leaderboard);
		View_leaderboard();
		system("pause");
		system("cls");
		return 1;
	}
	fseek(SP, 0, SEEK_SET);
	while (!feof(SP))//reads from the file to the leaderboard array 
	{
		fscanf(SP, "%s %d", leaderboard[i].userName, &leaderboard[i].result);
		i++;
		leaderboard = (Score*)realloc(leaderboard, sizeof(Score)*(i + 1));
		if (leaderboard == NULL)
		{
			printf("memory problem\n");
			return 0;
		}
		cnt++;
	}
	leaderboard = (Score*)realloc(leaderboard, sizeof(Score)*(cnt + 1));
	if (leaderboard == NULL)
	{
		printf("memory problem\n");
		return 0;
	}
	strcpy(leaderboard[cnt].userName, Name);
	leaderboard[cnt].result = result;
	cnt++;
	//bubble sort in decreasing order
	for (i = 0; i < cnt-1; i++)
	{
		for (j = 0; j < cnt - i - 1; j++)
		{
			if (leaderboard[j].result < leaderboard[j + 1].result)
			{
				swapResult = leaderboard[j].result;
				strcpy(swapName,leaderboard[j].userName);
				leaderboard[j].result = leaderboard[j + 1].result;
				strcpy(leaderboard[j].userName, leaderboard[j+1].userName);
				leaderboard[j+1].result=swapResult;
				strcpy(leaderboard[j + 1].userName, swapName);
			}
		}
	
	}
	Delete_all_scores();
	fclose(SP);
	if ((SP = fopen("leaderboard.txt", "w")) == NULL)
		printf("File couldn't be opened.\n");
	for (i = 0; i < cnt-1; i++)
		fprintf(SP,"%s  %d\n", leaderboard[i].userName, leaderboard[i].result);
	fprintf(SP, "%s  %d", leaderboard[i].userName, leaderboard[i].result);
	fclose(SP);
	free(leaderboard);
	if (flag != 0)
	{
		View_leaderboard();
		system("pause");
		system("cls");
	}
	return 1;
}