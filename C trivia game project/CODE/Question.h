#include "MinUnit.h"

#define _CRT_SECURE_NO_WARNINGS
#define N 10
#define Len 21

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <time.h>
#include <conio.h>
#include <assert.h>
#include <ctype.h>


//QUESTION
typedef struct Question {
	char questionBody[1001];
	char answer;
	int difficulty;
}Question;

/*utitily funcss*/
void printQuestion(Question question)
{
	printf("%s", question.questionBody);
	printf("answer is:%c\n", question.answer);
	printf("difficulty is:%d\n\n", question.difficulty);

}
void printAllQuestion(Question *questionArray,int size)
{
	int i;
		for (i = 0; i < size; i++)
			printQuestion(questionArray[i]); //print current question
}

/*memory allocating*/
Question *addqQestiontoArr(Question newQuestion, Question *questionArray, int size)
{
	if (size == 1)	//case array is empty
	{
		questionArray = (Question*)malloc(sizeof(Question));
		if (questionArray == NULL)
			exit(0);

		questionArray[0] = newQuestion;
	}
	else
	{
		/*will move all data to temp array delete old array and allocate new
		one with bigger size move all data back from temp and adding new question*/

		questionArray = (Question *)realloc(questionArray, size * sizeof(Question));
		if (questionArray == NULL)
		{
			printf("memory problem");
			exit(0);
		}
		questionArray[size - 1] = newQuestion;

	}
	return questionArray;	//return pointer to new array
}

/*add/edit/view  question array*/
Question *editorAddQuestion(Question *questionArray, int *size)
{
	Question newQuestion;
	newQuestion.difficulty = 0;
	newQuestion.answer = 'z';

	int i = 0, j = 0, k = 0, index = 0,flag=0;
	char c = 'a';
	char string[Len],dif[Len];

	char questionBody[500];
	printf("enter question (press enter when finish):\n");

	scanf("%*[^\n]");
	scanf("%*c");
	fgets(questionBody,250,stdin);

	int len = strlen(questionBody);
	for (i = 0; i<len; i++)
		newQuestion.questionBody[i] = questionBody[i];
	for (int j = 0; j < 4; j++)		//loop to accepst answer a-d
	{
		k = 0;

		/*enter a. / b. / c. / d. to question*/
		newQuestion.questionBody[i++] = c;
		newQuestion.questionBody[i++] = '.';
		//newQuestion.questionBody[i] = '\0';

		printf("enter answer %c (press enter when finish):\n", c++);
		fgets(questionBody, 60, stdin);

		len = strlen(questionBody);

		index = i;

		for (i = i; i < index + len; i++)		//loop to move input to question body
		{
			newQuestion.questionBody[i] = questionBody[k];
			k++;
		}

	}

	/*fixing string to match file*/
	newQuestion.questionBody[i] = '\0';
	for (i = strlen(newQuestion.questionBody); i > -1; i--)
	{
		newQuestion.questionBody[i + 1] = newQuestion.questionBody[i];

	}
	newQuestion.questionBody[0] = '\n';



	while (newQuestion.answer >68 || newQuestion.answer < 65)//loop to validate answer
	{

		printf("\nenter answer (a-d)\n");
		scanf("%s", string);
		if (strlen(string) > 1)
		{
			c = 'z';
			printf("invalid input try again \n");
		}
		else c = string[0];
		c = toupper(c);
		newQuestion.answer = c;
	}


	do {
			flag = 0;
			printf("Enter a new diffculty:\n");
			_flushall();
			scanf("%3s", dif);
			len = strlen(dif);
			for (i = 0; i < len; i++)
				if (isdigit(dif[i]) == 0)
				{
					printf("Error invalid input!!\n");
					flag = 1;
					break;
				}
		newQuestion.difficulty= atoi(dif);
		if (newQuestion.difficulty > 10 || newQuestion.difficulty < 1)
			flag = 1;
	} while (flag == 1);
		
	return addqQestiontoArr(newQuestion, questionArray, ++size[0]);
}
void editorEditQuestion(Question *questionList, int size, int indexinlist)
{
	Question newQuestion;
	newQuestion.difficulty = 0;
	newQuestion.answer = 'z';

	int i, j, k, index;
	char c = 'a';

	char questionBody[250];
	printf("enter question (press enter when finish):\n");

	scanf("%*[^\n]");
	scanf("%*c");

	fgets(questionBody, 250, stdin);

	int len = strlen(questionBody);
	for (i = 0; i<len; i++)
		newQuestion.questionBody[i] = questionBody[i];

	for (j = 0; j < 4; j++)		//loop to accepst answer a-d
	{
		k = 0;
		newQuestion.questionBody[i++] = c;
		newQuestion.questionBody[i++] = '.';
		newQuestion.questionBody[i] = '\0';

		printf("enter answer %c (press enter when finish):\n", c++);
		fgets(questionBody, 60, stdin);

		len = strlen(questionBody);

		index = i;

		for (i = i; i < index + len; i++)		//loop to move input to question body
		{
			newQuestion.questionBody[i] = questionBody[k];
			k++;
		}

	}
	newQuestion.questionBody[i] = '\0';

	//fixing question to match file
	if (indexinlist != 0)
	{
		for (i = strlen(newQuestion.questionBody); i > -1; i--)
		{
			newQuestion.questionBody[i + 1] = newQuestion.questionBody[i];

		}
		newQuestion.questionBody[0] = '\n';
	}

	while (newQuestion.answer >68 || newQuestion.answer < 65)	//loop to validate answer
	{

		printf("\nenter answer (a-d)\n");
		scanf("%c", &c);
		c = toupper(c);
		newQuestion.answer = c;
	}

	while (newQuestion.difficulty > 10 || newQuestion.difficulty < 1) //loop to validate difficulty
	{

		printf("enter difficulty (1-10)\n");
		scanf("%d", &newQuestion.difficulty);
	}
	questionList[indexinlist] = newQuestion;
	system("cls");
	return;
}
void editorViewQuestions(Question *questionList, int size)
{
	int i;
	char c;

	if (questionList == NULL)	//case question array empty
		return;
	else
		for (i = 0; i < size; i++)
		{
			printf("---question number %d:------\n\n", i + 1);
			printQuestion(questionList[i]);									//print current question
			printf("press any key to view next question or x to exit\n");
			c = _getch();												//accept choice
			if (c == 'x' || c == 'X')
			{
				system("cls");
				return;
			}
			system("cls");
		}
	system("cls");
	return;
}
void editorViewOrEditQuestion(Question *QuestionList, int size)
{
	if (QuestionList == NULL)	//case question array empty
		return;

	int i;
	char c;
	for (i = 0; i < size; i++)
	{
		printf("question number %d:\n", i + 1);
		printQuestion(QuestionList[i]);					//print current question

		printf("press e to edit current question or press x to return to main menu\n");	//showing current options
		printf("press any other key to view next question\n\n");


		c = _getch();												//accept choice

		if (c == 'e' || c == 'E')
		{
			editorEditQuestion(QuestionList, size, i);
			return;
		}
		if (c == 'x' || c == 'X')
		{
			system("cls");
			return;
		}
		system("cls");
	}
	return;
}

/*read/write file*/
Question *questionFileToStruct()
{
	int i ;						//index for txt file location
	int size = 0;					//represent size of array
	char c;					//will contain current char in file
	Question newQuestion;			//data red from file will go this veriable
	Question* questionArray=NULL;	//will hold all the data in file


	FILE *fp = fopen("question.txt", "r");		//opening file

	if (fp == NULL)					//checks if file opened corectly
	{
		printf("file not found");
		return NULL;
	}

	while (!feof(fp))		//runs on entire file
	{
		i = 0;		//index for txt file location
		c = 'a';	//will contain current char in file


		while (c != '@')	//loop stoped when reach '*' means question body is over
		{
			/*loop builds question body char by char*/
			fscanf(fp, "%c", &c);
			newQuestion.questionBody[i] = c;
			i++;
		}
		newQuestion.questionBody[i - 1] = '\0';	//add \0 to end of body string


		fscanf(fp, "%c", &newQuestion.answer);		//getting question answer
		fscanf(fp, "%d", &newQuestion.difficulty);	//getting question difficulty

		/*adding the new question to question array*/
		questionArray= addqQestiontoArr(newQuestion, questionArray,++size);
	}
	fclose(fp);
	return questionArray;
}
int questionArrayToFile(Question *questionList, int size)
{
	int i;

	FILE *fp = fopen("question.txt", "w");		//opening file

	if (fp == NULL)					//checks if file opened corectly
	{
		printf("file not found");
		return 0;
	}

	for (i = 0; i < size; i++)
	{
		fprintf(fp, "%s", questionList[i].questionBody); //print q body

		fprintf(fp, "@");
		fprintf(fp, "%c\n", questionList[i].answer);		//prints q answer with '*' before

		fprintf(fp, "%d", questionList[i].difficulty);	//print q difficulty

	}
	fclose(fp);
	return 1;
}
int findNumofQuestion()
{
	int size = 0;					//num of question
	char c;							//will contain current char in file

	FILE *fp = fopen("question.txt", "r");		//opening file

	if (fp == NULL)					//checks if file opened corectly
	{
		printf("file not found");
		return 0;
	}

	while (!feof(fp))		//runs on entire file looking for '@'
	{
		fscanf(fp, "%c", &c);
		if (c == '@')
			size++;
	}
	fclose(fp);
	return size;
}


