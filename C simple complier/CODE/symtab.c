#include "symtab.h"
int indexCounter = 0; //used to number for/if/while...

int symSize = 0;	//symbol table size
symtab* symbolTable; //symbol table pointer

funcall* calls = NULL;	//function calls pointer
int callSize;	//funcation calls size

stack* paramStk = NULL;	//param stack of function call
int paramStkSize = 0;	//param stack of function call size

stack* stk = NULL;	//scope stack point
int stksize = 0;	//scope stack size

usedVars* vars;
int varsSize = 0;

usedVars* bracketParam = NULL; //stack of param used in bracket([])
int bracketSize = 0;	//size of param used in bracket stack

usedVars* bracketVars = NULL;	//for checking if varible that uses [] is of string type
int bracketVarsSize = 0;			//for bracket vars size/len

symtab* addressAndDeref = NULL;	//for checking if & and ^ are used correctly
int addressAndDerefSize = 0;	//for counting number of times & or ^ appears

funcAssign* assignFuncs = NULL;//for checking assign of funcs to vars
int sizeOfAssignFuncs = 0;		//for counting size of assign to vars

condition *cond = NULL;	//for checking all cond are boolean
int condSize = 0;			//for counting size of condition
int condFlag = 0;		//for knowing when in exp calc to add params to cond

condition *assigns = NULL; //for checking all assigns are valid
int assignSize = 0;		//for counting number of assigns
int assignFlag = 0;		//for knowing when in exp calc to add params to assigns

funcall* returnVars = NULL; //for checking return value matches function value
int returnVarsSize = 0;		//for couning number of return values
int returnFlag = 0;

funcall *varsInAbs = NULL;	//for checking variable in absulote value
funcall *NullAssign = NULL; //for checking variable assigned with null
int funcallFlag = 0;
/*param call funcs*/
void addFuncall(char* name)
{
	funcallFlag = 1;
	if (calls == NULL)
	{
		calls = (funcall*)malloc(sizeof(funcall));
		calls[0].name = name;
		calls[0].paramNum = 0;
		calls[0].params = NULL;
		calls[0].scope = mkstr(getCurrent());
		callSize++;
		calls[0].sign=(char**)malloc(20*sizeof(char*));
		calls[0].signSize=0;
	}
	else
	{
		callSize++;
		calls = realloc(calls, callSize * sizeof(funcall));
		calls[callSize - 1].name = name;
		calls[callSize - 1].paramNum = 0;
		calls[callSize - 1].params = NULL;
		calls[callSize - 1].scope = mkstr(getCurrent());
		calls[callSize - 1].sign=(char**)malloc(20*sizeof(char*));
		calls[callSize - 1].signSize=0;
	}
}
void printFuncalls() {
	int i, j;
	for (i = 0; i < callSize; i++)
	{
		printf("(funcall %d name: %s scope: %s paramNum: %d\n", i+1,calls[i].name, calls[i].scope, calls[i].paramNum);
		printf("params:");
		for (j = 0; j < calls[i].paramNum; j++)
			printf("%s ", calls[i].params[j]);
		if(calls[i].sign!=NULL){
		printf("sign:");
			for(j = 0; j < calls[i].signSize; j++)
			printf("%s ", calls[i].sign[j]);
			}
		printf("\n");
	}
}
void addCallParams(char* ident)
{
	if (funcallFlag == 0)
		return;
	if (calls[callSize - 1].params == NULL)
	{
		calls[callSize - 1].params = (char**)malloc(sizeof(char*));
		calls[callSize - 1].params[0] = mkstr(ident);
		calls[callSize - 1].paramNum++;
	}
	else
	{
		calls[callSize - 1].paramNum++;
		calls[callSize - 1].params = realloc(calls[callSize - 1].params, sizeof(char*)*calls[callSize - 1].paramNum);
		calls[callSize - 1].params[calls[callSize - 1].paramNum - 1] = mkstr(ident);
	}
}
void addFuncallSign(char * sign)
{
		if (funcallFlag == 0)
		return;
	calls[callSize - 1].sign[calls[callSize - 1].signSize] = mkstr(sign);
	calls[callSize - 1].signSize++;
}
void closeFuncall()
{
	funcallFlag = 0;
}

							/*variable assigned with funcs and checks*/
void addNullAssign(char* p)
{
	if (NullAssign == NULL)
	{
		NullAssign = (funcall*)malloc(sizeof(funcall));
		NullAssign[0].scope = mkstr(getCurrent());
		NullAssign[0].params = NULL;
		NullAssign[0].paramNum = 0;
	}
	if (NullAssign[0].params == NULL)
	{
		NullAssign[0].params = (char**)malloc(sizeof(char*));
		NullAssign[0].params[0] = mkstr(p);
		NullAssign[0].paramNum++;
	}
	else
	{
		NullAssign[0].paramNum++;
		int size = NullAssign[0].paramNum;
		NullAssign[0].params = realloc(NullAssign[0].params, sizeof(char*)*(size + 1));
		NullAssign[0].params[size - 1] = mkstr(p);
	}


}
void printNullAssign()
{
	int i;
	printf("params asssigned with NULL:");
	for (i = 0; i < NullAssign->paramNum; i++)
	{
		printf("%s ", NullAssign->params[i]);
	}
	printf("\n");
}
int checkNullAssign()
{
	int i, j, len = 0, flag;
	char* type;
	if (NullAssign == NULL)
		return 0;
	for (i = 0; i < NullAssign->paramNum; i++)
	{
		flag = 0;
		len = 0;
		for (j = 0; j < symSize; j++)
		{
			if (strcmp(symbolTable[j].name, NullAssign->params[i]) == 0 && (scopeComp(NullAssign->scope, symbolTable[j].scope) == 1) && strlen(symbolTable[j].scope) > len)
			{
				type = symbolTable[j].type;
				len = (int)strlen(symbolTable[j].scope);
				flag = 1;
			}
		}
		if (flag == 0)
		{
			printf("UNDEFINED VARIABLE ASSIGNED WITH NULL [%s]\n", NullAssign->params[i]);
			return 1;
		}
		else if (strcmp(type, "charp") != 0 && strcmp(type, "intp") != 0)
		{
			printf("INVALID TYPE ASSIGNED WITH NULL EXPECTED intp/charp RECIEVED [%s]\n", type);
			return 1;
		}
	}
	return 0;

}

/*variables in absulte value funcs and check*/
void addVarinAbs(char* p)
{
	if (varsInAbs == NULL)
	{
		varsInAbs = (funcall*)malloc(sizeof(funcall));
		varsInAbs[0].scope = mkstr(getCurrent());
		varsInAbs[0].params = NULL;
		varsInAbs[0].paramNum = 0;
	}
	if (varsInAbs[0].params == NULL)
	{
		varsInAbs[0].params = (char**)malloc(sizeof(char*));
		varsInAbs[0].params[0] = mkstr(p);
		varsInAbs[0].paramNum++;
	}
	else
	{
		varsInAbs[0].paramNum++;
		int size = varsInAbs[0].paramNum;
		varsInAbs[0].params = realloc(varsInAbs[0].params, sizeof(char*)*(size + 1));
		varsInAbs[0].params[size - 1] = mkstr(p);
	}


}
void printVarinAbs()
{
	int i;
	printf("params in abs:");
	for (i = 0; i < varsInAbs->paramNum; i++)
	{
		printf("%s ", varsInAbs->params[i]);
	}
	printf("\n");
}
int checkVarsinAbs()
{

	int i, j, len = 0, flag;
	char* type;
	if (varsInAbs == NULL)
		return 0;
	for (i = 0; i < varsInAbs->paramNum; i++)
	{
		flag = 0;
		len = 0;
		for (j = 0; j < symSize; j++)
		{
			if (strcmp(symbolTable[j].name, varsInAbs->params[i]) == 0 && (scopeComp(varsInAbs->scope, symbolTable[j].scope) == 1) && strlen(symbolTable[j].scope) > len)
			{
				type = symbolTable[j].type;
				len = (int)strlen(symbolTable[j].scope);
				flag = 1;
			}
		}
		if (flag == 0)
		{
			printf("UNDEFINED VARIABLE USED IN ABS [%s]\n", varsInAbs->params[i]);
			return 1;
		}
		else if (strcmp(type, "int") != 0 && strcmp(type, "string") != 0)
		{
			printf("INVALID TYPE USED IN ABS EXPECTED int/string RECIVED [%s]\n", type);
			return 1;
		}
	}
	return 0;

}

/*return value funcs*/
void addReturnValue(char *func)
{
	returnFlag = 1;
	if (returnVars == NULL) {
		returnVars = (funcall*)malloc(sizeof(funcall));
		returnVars[0].scope = mkstr(getCurrent());
		returnVars[0].params = NULL;
		returnVars[0].paramNum = 0;
		returnVars[0].name = mkstr(func);
		returnVarsSize++;
	}
	else
	{
		returnVarsSize++;
		returnVars = realloc(returnVars, returnVarsSize * sizeof(funcall));
		returnVars[returnVarsSize - 1].paramNum = 0;
		returnVars[returnVarsSize - 1].scope = mkstr(getCurrent());
		returnVars[returnVarsSize - 1].name = mkstr(func);
		returnVars[returnVarsSize - 1].params = NULL;
	}
}
void addReturnParam(char *p)
{
	if (returnFlag == 0)
		return;
	if (returnVars[returnVarsSize - 1].params == NULL)
	{
		returnVars[returnVarsSize - 1].params = (char**)malloc(sizeof(char*));
		returnVars[returnVarsSize - 1].params[0] = mkstr(p);
		returnVars[returnVarsSize - 1].paramNum++;
	}
	else
	{
		returnVars[returnVarsSize - 1].paramNum++;
		int size = returnVars[returnVarsSize - 1].paramNum;
		returnVars[returnVarsSize - 1].params = realloc(returnVars[returnVarsSize - 1].params, sizeof(char*)*(size + 1));
		returnVars[returnVarsSize - 1].params[size - 1] = mkstr(p);
	}
}
void printAllReturnValues()
{
	int i, j;
	for (i = 0; i < returnVarsSize; i++)
	{
		printf("name %s scope %s paramNum %d  params: ", returnVars[i].name, returnVars[i].scope, returnVars[i].paramNum);
		for (j = 0; j < returnVars[i].paramNum; j++)
		{
			printf("%s ", returnVars[i].params[j]);
		}
		printf("\n");
	}
}
int checkReturnValues()
{
	int i, j, k, len = 0, symFlag = 0, funcflag = 0, len2 = 0;
	symtab* function;
	char *returnType, *currentType;
	for (i = 0; i < returnVarsSize; i++)
	{
		currentType = NULL;
		len = 0;
		funcflag = 0;
		function = NULL;
		for (k = 0; k < returnVars[i].paramNum; k++)
		{
			returnType = NULL;
			symFlag = 0;
			len2 = 0;
			for (j = 0; j < symSize; j++)
			{
				if (strcmp(symbolTable[j].name, returnVars[i].name) == 0 && (paramScopeComp(symbolTable[j].scope,returnVars[i].scope) == 1) && strlen(symbolTable[j].scope)>len)
				{

					function = &(symbolTable[j]);
					funcflag = 1;
					len = (int)strlen(symbolTable[j].scope);
				}
				if (strcmp(returnVars[i].params[k], "int") == 0 || strcmp(returnVars[i].params[k], "char") == 0 || strcmp(returnVars[i].params[k], "string") == 0)
				{
					symFlag = 1;
					if (strcmp(returnVars[i].params[k], "int") == 0)
						currentType = mkstr("int");
					else if (strcmp(returnVars[i].params[k], "char") == 0)
						currentType = mkstr("char");
					else
						currentType = mkstr("string");
				}
				else if (strcmp(returnVars[i].params[k], symbolTable[j].name) == 0 &&
					(paramScopeComp(symbolTable[j].scope,returnVars[i].scope) == 1) && strlen(symbolTable[j].scope)>len2)
				{
					currentType = symbolTable[j].type;
					len2 = (int)strlen(symbolTable[j].scope);
					symFlag = 1;
				}
			}

			if (returnType != NULL && strcmp(returnType, currentType) != 0)
			{
				printf("CANNOT USE OPERATORS ON DIFFRENT TYPES");
				return 1;
			}
			returnType = currentType;

			if (symFlag == 0)
			{
				printf("UNDEFINED VARIABLE USED IN RETURN [%s]\n", returnVars[i].params[k]);
				return 1;

			}
		}

		if (funcflag == 0)
		{
			printf("UNDEFINED FUNCTION USED [%s]\n", returnVars[i].name);
			return 1;

		}
		if (strcmp(function->type, returnType) != 0)
		{
			printf("RETURN VALUE WAS %s FUNCTION NEEDS TO RETURN %s\n", returnType, function->type);
			return 1;

		}
	}
	return 0;
}
void closeReturn()
{
	returnFlag = 0;
}
/*ISCOND*/


int isCond(condition assign)
{
	if(assign.sign!=NULL)
		return 1;


/*
	int flag = 0, i, j, k, l, first = 0;
	char ** params;
	int cnt = 0;
	params = (char**)malloc((assign.size2 + 1) * sizeof(char*));
	
	for  (i= 0; i < assign.size2; i++)
	{
		params[i] = mkstr(assign.params2[i]);		
	}


	for (j = 0; j < condSize; j++)
	{
	for (i = 0; i < assign.size2; i++)
			if(strcmp(params[i],"int")==0 ||strcmp(params[i],"char")==0)
			{
					first = 1;
					flag = 1;
					cnt++;
					break;
			}

		flag = 0;
		for (k = 0; k < cond[j].size1; k++)
		{
			for (i = 0; i < assign.size2; i++)
			{

				if (strcmp(cond[j].params1[k], params[i]) == 0)
				{
					first = 1;
					flag = 1;
					cnt++;
					break;
				}
			}

		}
		for (l = 0; l < cond[j].size2; l++)
		{
			for (i = 0; i < assign.size2; i++)
			{
				if (strcmp(cond[j].params2[l], params[i]) == 0)
				{
					flag = 1;
					cnt++;
					break;
				}
			}

		}
		printf("cnt is %d assign size is %d\n",cnt,assign.size2);
		if (cnt == assign.size2)
		{
			return 0;
		}
			cnt = 0;

	}
	return 1;
	*/
}

/*assign EXP funcs*/
void addAssignExp()
{
	assignFlag = 1;
	if (assigns == NULL)
	{
		assigns = (condition*)malloc(sizeof(condition));
		assigns[0].size1 = 0;
		assigns[0].size2 = 0;
		assignSize++;
		assigns[0].params1 = NULL;
		assigns[0].params2 = NULL;
		assigns[0].sign = NULL;
		assigns[0].scope = getCurrent();
	}
	else {
		assignSize++;
		assigns = realloc(assigns, assignSize * sizeof(condition));
		assigns[assignSize - 1].size1 = 0;
		assigns[assignSize - 1].size2 = 0;
		assigns[assignSize - 1].params1 = NULL;
		assigns[assignSize - 1].params2 = NULL;
		assigns[assignSize - 1].sign = NULL;
		assigns[assignSize - 1].scope = getCurrent();
	}
}
void addAssignParams1(char* p1, char* p2)
{
	int size = 1;
	if (p2 != NULL)
		size++;
	assigns[assignSize - 1].params1 = (char**)malloc(sizeof(char*)*size);
	assigns[assignSize - 1].params1[0] = mkstr(p1);
	if (p2 != NULL)
		assigns[assignSize - 1].params1[1] = mkstr(p2);

	assigns[assignSize - 1].size1 = size;
}
void addAssignParams2(char *param)
{
	if (assignFlag == 0)
		return;
	if (assigns[assignSize - 1].params2 == NULL)
	{
		assigns[assignSize - 1].params2 = (char**)malloc(sizeof(char*));
		assigns[assignSize - 1].params2[0] = mkstr(param);
		assigns[assignSize - 1].size2++;
	}
	else
	{
		assigns[assignSize - 1].size2++;
		int size = assigns[assignSize - 1].size2;
		assigns[assignSize - 1].params2 = realloc(assigns[assignSize - 1].params2, sizeof(char*)*(size + 1));
		assigns[assignSize - 1].params2[size - 1] = mkstr(param);
	}
}
void closeAssignExp()
{
	assignFlag = 0;
}
void printAssignExp()
{
	int i, j;
	for (i = 0; i < assignSize; i++) {
		if(assigns[i].sign!=NULL)
			printf ("sign %s",assigns[i].sign);
		printf("assign %d scope %s size1 is %d size2 is %d params 1:", i + 1, assigns[i].scope, assigns[i].size1, assigns[i].size2);
		for (j = 0; j < assigns[i].size1; j++)
			printf("%s ", assigns[i].params1[j]);
		printf("params 2:");
		for (j = 0; j < assigns[i].size2; j++)
			printf("%s ", assigns[i].params2[j]);
		printf("\n");
	}
}
void addAssignSign(char *sign)
{
	if(assignFlag)
	{
	if (assigns[assignSize - 1].sign != NULL)
		return;
	assigns[assignSize - 1].sign = mkstr(sign);
	}
}



int checkAssign()
{
	int i, j, k, len = 0, len2 = 0;
	char *currentType = NULL, *type1 = NULL, *type2 = NULL, *type12;
	symtab *ptr1, *ptr2;
	for (i = 0; i < assignSize; i++)//loops all assigns
	{
		type12=NULL;
		if (assigns[i].size1 == 0 && assigns[i].size2 == 0)
			continue;
		if(assigns[i].sign!=NULL&&strcmp(assigns[i].sign,"<>")==0)
			continue;
		if (isCond(assigns[i]))
		{
			continue;
		}
		type1 = NULL;
		type2 = NULL;
		type12=NULL;
		currentType = NULL;
		for (k = 0; k < assigns[i].size1; k++)//loops assigns[i] params1
		{
			currentType = NULL;
			len = 0;
			len2 = 0;
			ptr1 = NULL;
			ptr2 = NULL;
			type12=NULL;
			for (j = 0; j < symSize; j++)//loops symbol table
			{
				//finds matching symbol to first id
				if ((strcmp(assigns[i].params1[0], symbolTable[j].name) == 0) && paramScopeComp(symbolTable[j].scope,assigns[i].scope) == 1 && strlen(symbolTable[j].scope) > len)
				{
					ptr1 = &(symbolTable[j]);
					len = (int)strlen(symbolTable[j].scope);
					currentType = ptr1->type;
				}

				if (assigns[i].params1[1] != NULL && strcmp(assigns[i].params1[1], "int") != 0)
				{
					//finds matching symbol to second id if its not int
					if ((strcmp(assigns[i].params1[1], symbolTable[j].name) == 0) && paramScopeComp(symbolTable[j].scope,assigns[i].scope) == 1 && strlen(symbolTable[j].scope) > len2)
					{
						type12 = (symbolTable[j].type);
						len2 = (int)strlen(symbolTable[j].scope);
					}

				}
				else if(assigns[i].params1[1] != NULL && strcmp(assigns[i].params1[1], "int") == 0)
						type12 = mkstr("int");
				type1 = currentType;
			}

			if (type1 == NULL)
			{
				printf("UNDEFINED SYMBOL USED IN ASSIGN\n");
				return 1;

			}
			if (assigns[i].size1>1)
			{
				if (assigns[i].params1[1] != NULL && type12 == NULL)
				{
					printf("UNDEFINED SYMBOL USED IN []\n");
					return 1;

				}
				if (assigns[i].params1[1] != NULL && type12 != NULL && strcmp(type12, "int") != 0)
				{
					printf("USED NON INTEGER IN []\n");
					return 1;

				}
			}

		}
		for (k = 0; k < assigns[i].size2; k++)//loops assigns[i] params2
		{
			ptr2 = NULL;
			if (strcmp(assigns[i].params2[k], "int") == 0)
			{
				currentType = mkstr("int");
				if (type2 != NULL && strcmp("int", type2) != 0)
				{
					printf("name 1%s name 2 %s\n",assigns[i].params1[0],assigns[i].params2[0]);
					printf("type 2 is %s\n\n",type2);
					printf("MATH OPERATORS CAN ONLY BE USED ON INT TYPE\n");
					return 1;

				}
				if (type2 != NULL && strcmp(type2, currentType) != 0)
				{
					printf("CANNOT USE MATH OPERATORS ON DIFFRENT TYPES\n");
					return 1;

				}
			}
			else if (strcmp(assigns[i].params2[k], "char") == 0)
			{
				currentType = mkstr("char");
				if (type2 != NULL && strcmp(type2, currentType) != 0)
				{

					printf("CANNOT USE MATH OPERATORS ON DIFFRENT TYPES\n");
					return 1;

				}
			}
			else if (strcmp(assigns[i].params2[k], "string") == 0)
			{
				currentType = mkstr("string");
				if (type2 != NULL && strcmp(type2, currentType) != 0)
				{
					printf("CANNOT USE MATH OPERATORS ON DIFFRENT TYPES\n");
					return 1;

				}
			}
			else if (strcmp(assigns[i].params2[k], "boolean") == 0)
			{
				if (type2 != NULL && strcmp("int", type2) != 0)
				{

					printf("MATH OPERATORS CAN ONLY BE USED ON INT TYPE\n");
					return 1;

				}
				currentType = mkstr("boolean");
				if (type2 != NULL && strcmp(type2, currentType) != 0)
				{

					printf("CANNOT USE MATH OPERATORS ON DIFFRENT TYPES\n");
					return 1;

				}
			}
			else
			{

				for (j = 0; j < symSize; j++)
				{
					len = 0;
					if ((strcmp(assigns[i].params2[k], symbolTable[j].name) == 0) && 
					paramScopeComp(symbolTable[j].scope,assigns[i].scope) == 1 && strlen(symbolTable[j].scope) > len)
					{
						ptr2 = &(symbolTable[j]);
						len = (int)strlen(symbolTable[j].scope);
						currentType = ptr2->type;
					}
				}
				if (ptr2 == NULL)
				{
					printf("UNDEFINED VARIABLE USED IN ASSIGN %s\n", assigns[i].params2[k]);
					return 1;

				}
				else
				{
					currentType = ptr2->type;
					if (type2 != NULL && strcmp("int", type2) != 0)
					{
						if (strcmp(ptr2->type, "charp") == 0 || strcmp(ptr2->type, "intp") == 0)
						{
							printf("CAN ONLY INC OR DEC INTERGER VALUE FROM CHARP OR INTP\n");
							return 1;

						}
						printf("MATH OPERATORS CAN ONLY BE USED ON INT TYPE\n");
						return 1;

					}
					if (k > 0 && strcmp(ptr2->type, type2) != 0)
					{
						if ((strcmp(ptr2->type, "charp") == 0 || strcmp(ptr2->type, "intp") == 0) &&
							strcmp(type2, "int") == 0)
						{
							currentType = ptr2->type;
						}
						else if ((strcmp(type2, "charp") == 0 || strcmp(type2, "intp") == 0) &&
							strcmp(ptr2->type, "int") == 0)
						{
							currentType = type2;
						}

						else {

							printf("CANNOT USE MATH OPERATORS ON DIFFRENT TYPES\n");
							return 1;

						}
					}
				}

			}
			type2 = currentType;
		}
		if (type1 != NULL && type2 != NULL)
		{
			if (strcmp(type1, type2) != 0)
			{
				if (strcmp(type1, "string") == 0 && strcmp(type2, "char") == 0 && type12 != NULL && strcmp(type12, "int") == 0)
					continue;

				printf("CANNOT ASSIGN DIFFRENT TYPES [%s] and [%s]\n",type1,type2);
				return 1;

			}
		}

	}
	return 0;
}

/*bool EXP funcs*/
void addBoolExp()
{
	condFlag = 1;
	if (cond == NULL)
	{
		cond = (condition*)malloc(sizeof(condition));
		cond[0].size1 = 0;
		cond[0].size2 = 0;
		condSize++;
		cond[0].params1 = NULL;
		cond[0].params2 = NULL;
		cond[0].sign = NULL;
		cond[0].scope = getCurrent();
		cond[0].condId = NULL;
		cond[0].adrefLeft= NULL;
		cond[0].adrefRight= NULL;
	}
	else {
		condSize++;
		cond = realloc(cond, condSize * sizeof(condition));
		cond[condSize - 1].size1 = 0;
		cond[condSize - 1].size2 = 0;
		cond[condSize - 1].params1 = NULL;
		cond[condSize - 1].params2 = NULL;
		cond[condSize - 1].sign = NULL;
		cond[condSize - 1].scope = getCurrent();
		cond[condSize - 1].condId = NULL;
		cond[condSize - 1].adrefLeft= NULL;
		cond[condSize - 1].adrefRight= NULL;
	}

}
void mkBoolParams1()
{
	cond[condSize - 1].params1 = (char**)malloc(sizeof(char*));
}
void mkBoolParams2()
{
	cond[condSize - 1].params2 = (char**)malloc(sizeof(char*));
}
void addBoolParam(char *param)
{
	if (condFlag == 0)
		return;
	if (cond == NULL)
		return;
	if (cond[condSize - 1].params2 != NULL)
	{
		int size = cond[condSize - 1].size2;
		cond[condSize - 1].params2[size] = mkstr(param);
		cond[condSize - 1].size2++;
		int newsize = cond[condSize - 1].size2;
		cond[condSize - 1].params2 = realloc(cond[condSize - 1].params2, sizeof(char*)*(newsize + 1));
	}
	else if (cond[condSize - 1].params1 != NULL)
	{
		int size = cond[condSize - 1].size1;
		cond[condSize - 1].params1[size] = mkstr(param);
		cond[condSize - 1].size1++;
		int newsize = cond[condSize - 1].size1;
		cond[condSize - 1].params1 = realloc(cond[condSize - 1].params1, sizeof(char*)*(newsize + 1));
	}
	return;
}
void addBoolSign(char* sign)
{
	if (cond[condSize - 1].sign != NULL)
		return;
	cond[condSize - 1].sign = mkstr(sign);
}
void addCondId(char *id)
{
	cond[condSize - 1].condId = mkstr(id);
}
void addAdref(char*sign,int side/*0 for left 1 for right*/)
{
	if (condFlag == 0)
		return;
	if(side ==0)
	cond[condSize - 1].adrefLeft = mkstr(sign);
	else
	cond[condSize - 1].adrefRight = mkstr(sign);
}
void printBoolExp()
{
	int i, j;
	for (i = 0; i < condSize; i++) {
		if (cond[i].condId != NULL)
			printf("condId %s ", cond[i].condId);
		if(cond[i].sign!=NULL)
			printf ("sign %s",cond[i].sign);
		printf("cond %d scope %s size1 %d size2 %d  ", i + 1, cond[i].scope,cond[i].size1,cond[i].size2);
		if(cond[i].adrefLeft!=NULL)
			printf("adrefleft:%s ",cond[i].adrefLeft);
		if(cond[i].adrefRight!=NULL)
			printf("adrefright:%s ",cond[i].adrefRight);
			
		printf("params 1:");
		for (j = 0; j < cond[i].size1; j++)
			printf("%s ", cond[i].params1[j]);
		printf("params 2:");

		for (j = 0; j < cond[i].size2; j++)
			printf("%s ", cond[i].params2[j]);
		printf("\n");
	}
}
void closeBoolExp()
{
	condFlag = 0;
}
int checkBoolExpPtr()
{
		int i, j, k, len1 = 0,len2=0;
	char *currentType = NULL, *type1 = NULL, *type2 = NULL;
	symtab *ptr1=NULL, *ptr2=NULL;
	for (i = 0; i < condSize; i++)//loops onditon
	{
		if(cond[i].sign!=NULL && strcmp(cond[i].sign,"=")==0)
			continue;
		if(cond[i].adrefLeft == NULL && cond[i].adrefRight == NULL)
			continue;
			
		if(cond[i].sign!=NULL && strcmp(cond[i].sign,"==")!=0&& strcmp(cond[i].sign,"!=")!=0)
		{
			printf("CANNOT USE < <= > >= ON POINTER TYPE\n");
			return 1;
		}
		
		
		if(cond[i].params1[1]==NULL || cond[i].params1[0]==NULL)
		{
			printf("something went wrong\n");
			return 1;
		}
		if(cond[i].adrefLeft!=NULL && cond[i].adrefRight==NULL)
		{
			if(strcmp(cond[i].adrefLeft,"^")==0&&cond[i].adrefRight==NULL&&cond[i].params1[1]!=NULL &&
			strcmp(cond[i].params1[1],"int")!=0 &&strcmp(cond[i].params1[1],"char")!=0)
			{
				char * temp = cond[i].params1[1];
				cond[i].params1[1]= cond[i].params1[0];
				cond[i].params1[0] = temp;
			}
		}

		//x is int y is intp
		//(&x == y )
			if(cond[i].adrefLeft!=NULL && strcmp(cond[i].adrefLeft,"&")==0 && cond[i].adrefRight==NULL)
			{
				len1 =0;
				len2 =0;
				for(k=0;k<symSize;k++)
				{
					if ((strcmp(cond[i].params1[0], symbolTable[k].name) == 0) && 
					paramScopeComp(symbolTable[k].scope,cond[i].scope) == 1 && strlen(symbolTable[k].scope) > len1)
					{
						ptr1 = &(symbolTable[k]);
						len1 = (int)strlen(symbolTable[k].scope);
					}
					if ((strcmp(cond[i].params1[1], symbolTable[k].name) == 0) && 
					paramScopeComp(symbolTable[k].scope,cond[i].scope) == 1 && strlen(symbolTable[k].scope) > len2)
					{
						ptr2 = &(symbolTable[k]);
						len2 = (int)strlen(symbolTable[k].scope);
					}				
				}
				if(strcmp(ptr1->type,"intp")==0||strcmp(ptr1->type,"charp")==0)
				{
					printf("CANNOT USE & ON POINTER TYPE\n");
					return 1;		
				}
				if(strcmp(ptr1->type,"int")==0&&strcmp(ptr2->type,"intp")!=0)
				{
					printf("NON INT POINTER TYPE COMPARED TO INT\n");
					return 1;		
				}
				if(strcmp(ptr1->type,"char")==0&&strcmp(ptr2->type,"charp")!=0)
				{
					printf("NON CHAR POINTER TYPE COMPARED TO CHAR\n");
					return 1;		
				}	
		
			}
			//^y == x        y must be pointer x must be non pointer
			if(cond[i].adrefLeft!=NULL && strcmp(cond[i].adrefLeft,"^")==0 && cond[i].adrefRight==NULL)
			{
				len1 =0;
				len2 =0;
				for(k=0;k<symSize;k++)
				{
					//printf("sym scope %s cond scope %s\n",symbolTable[k].scope,cond[i].scope);
					if ((strcmp(cond[i].params1[0], symbolTable[k].name) == 0) && 
					paramScopeComp(symbolTable[k].scope,cond[i].scope) == 1 && strlen(symbolTable[k].scope) > len1)
					{
						ptr1 = &(symbolTable[k]);
						len1 = (int)strlen(symbolTable[k].scope);
					}
					if ((strcmp(cond[i].params1[1], symbolTable[k].name) == 0) && 
					paramScopeComp(symbolTable[k].scope,cond[i].scope) == 1 && strlen(symbolTable[k].scope) > len2)
					{
						ptr2 = &(symbolTable[k]);
						len2 = (int)strlen(symbolTable[k].scope);
					}				
				}
				
				if(ptr1==NULL)//undefind symbol
				{
					printf("UNDEFINED SYMBOL USED\n");
					return 1;
				}
				if(strcmp(ptr1->type,"intp")!=0&&strcmp(ptr1->type,"charp")!=0)
				{
					//printf("name %s is type is%s\n",ptr1->name,ptr1->type);
					printf("CANNOT USE ^ ON NON POINTER TYPE\n");
					return 1;		
				}
				if(strcmp(ptr1->type,"intp")==0&&strcmp(ptr2->type,"int")!=0)
				{
					printf("NON INT TYPE COMPARED TO INTP\n");
					return 1;		
				}
				if(strcmp(ptr1->type,"charp")==0&&strcmp(ptr2->type,"char")!=0)
				{
					printf("NON CHAR TYPE COMPARED TO CHARP\n");
					return 1;		
				}
			}
		//x is int y is intp
		//(y == &x )
			if(cond[i].adrefRight!=NULL && strcmp(cond[i].adrefRight,"&")==0 && cond[i].adrefLeft==NULL)
			{
				len1 =0;
				len2 =0;
				for(k=0;k<symSize;k++)
				{
					if ((strcmp(cond[i].params1[0], symbolTable[k].name) == 0) && 
					paramScopeComp(symbolTable[k].scope,cond[i].scope) == 1 && strlen(symbolTable[k].scope) > len2)
					{
						ptr2 = &(symbolTable[k]);
						len2 = (int)strlen(symbolTable[k].scope);
					}
					if ((strcmp(cond[i].params1[1], symbolTable[k].name) == 0) && 
					paramScopeComp(symbolTable[k].scope,cond[i].scope) == 1 && strlen(symbolTable[k].scope) > len1)
					{
						ptr1 = &(symbolTable[k]);
						len1 = (int)strlen(symbolTable[k].scope);
					}				
				}
				if(strcmp(ptr1->type,"intp")==0||strcmp(ptr1->type,"charp")==0)
				{
					printf("CANNOT USE & ON POINTER TYPE\n");
					return 1;		
				}
				if(strcmp(ptr1->type,"int")==0&&strcmp(ptr2->type,"intp")!=0)
				{
					printf("NON INT POINTER TYPE COMPARED TO INT\n");
					return 1;		
				}
				if(strcmp(ptr1->type,"char")==0&&strcmp(ptr2->type,"charp")!=0)
				{
					printf("NON CHAR POINTER TYPE COMPARED TO CHAR\n");
					return 1;		
				}	
		
			}
			/*	int x;
			intp y;
			x == ^y */
			if(cond[i].adrefRight!=NULL && strcmp(cond[i].adrefRight,"^")==0 && cond[i].adrefLeft==NULL)
			{
				printf("ima here\n\n\n");
				len1 =0;
				len2 =0;
				for(k=0;k<symSize;k++)
				{
					//printf("sym scope %s cond scope %s\n",symbolTable[k].scope,cond[i].scope);
					if ((strcmp(cond[i].params1[0], symbolTable[k].name) == 0) && 
					paramScopeComp(symbolTable[k].scope,cond[i].scope) == 1 && strlen(symbolTable[k].scope) > len2)
					{
						ptr2 = &(symbolTable[k]);
						len2 = (int)strlen(symbolTable[k].scope);
					}
					if ((strcmp(cond[i].params1[1], symbolTable[k].name) == 0) && 
					paramScopeComp(symbolTable[k].scope,cond[i].scope) == 1 && strlen(symbolTable[k].scope) > len1)
					{
						ptr1 = &(symbolTable[k]);
						len1 = (int)strlen(symbolTable[k].scope);
					}				
				}
				
				if(ptr1==NULL)//undefind symbol
				{
					printf("UNDEFINED SYMBOL USED\n");
					return 1;
				}
				if(strcmp(ptr1->type,"intp")!=0&&strcmp(ptr1->type,"charp")!=0)
				{
					//printf("name %s is type is%s\n",ptr1->name,ptr1->type);
					printf("CANNOT USE ^ ON NON POINTER TYPE\n");
					return 1;		
				}
				if(strcmp(ptr1->type,"intp")==0&&strcmp(ptr2->type,"int")!=0)
				{
					printf("NON INT TYPE COMPARED TO INTP\n");
					return 1;		
				}
				if(strcmp(ptr1->type,"charp")==0&&strcmp(ptr2->type,"char")!=0)
				{
					printf("NON CHAR TYPE COMPARED TO CHARP\n");
					return 1;		
				}
			}
	 	
	 }
}

int checkBoolExp()
{
	int i, j, k, len = 0;
	char *currentType = NULL, *type1 = NULL, *type2 = NULL;
	symtab *ptr1, *ptr2;
	for (i = 0; i < condSize; i++)//loops onditon
	{
		if(cond[i].size1 == 0 && cond[i].size2 == 0)
			continue;
		if(cond[i].sign != NULL && strcmp(cond[i].sign, "<>")==0)
			continue;	
		if(cond[i].adrefLeft!=NULL || cond[i].adrefRight!=NULL)
			continue;
			
		if (cond[i].sign != NULL && strcmp(cond[i].sign, "=") == 0)
		{
			if(cond[i].size1 != 0 && cond[i].size2 != 0 && (strcmp(cond[i].params1[0], "int") == 0 || 
			strcmp(cond[i].params1[0], "char") == 0))
			{
				char * temp = cond[i].params1[0];
				cond[i].params1[0] = cond[i].params2[0];
				cond[i].params2[0] = temp;
			}
			for (j = 0; j < symSize; j++)
			{

				if ((strcmp(cond[i].condId, symbolTable[j].name) == 0) && paramScopeComp(symbolTable
					[j].scope,cond[i].scope) == 1 && strlen(symbolTable[j].scope) > len)
				{
					ptr1 = &(symbolTable[j]);
					len = (int)strlen(symbolTable[j].scope);
				}

			}
			if (strcmp(ptr1->type, "int") == 0)
				continue;
		}

		type1 = NULL;
		type2 = NULL;
		ptr1 = NULL;

		for (k = 0; k < cond[i].size1; k++) //loops params 1
		{

			len = 0;
			ptr1 = NULL;

			if (strcmp(cond[i].params1[k], "int") == 0)
			{
				currentType = mkstr("int");
				if (type1 != NULL && strcmp("int", type1) != 0)
				{
					printf("MATH OPERATORS CAN ONLY BE USED ON INT TYPE\n");
					return 1;

				}
				if (type1 != NULL && strcmp(type1, currentType) != 0)
				{
					printf("CANNOT USE MATH OPERATORS ON DIFFRENT TYPES\n");
					return 1;

				}
			}
			else if (strcmp(cond[i].params1[k], "true") == 0 || strcmp(cond[i].params1[k], "false") == 0)
			{
				currentType = mkstr("boolean");
				if (type1 != NULL && strcmp("int", type1) != 0)
				{
					printf("MATH OPERATORS CAN ONLY BE USED ON INT TYPE\n");
					return 1;

				}
				if (type1 != NULL && strcmp(type1, currentType) != 0)
				{
					printf("CANNOT USE MATH OPERATORS ON DIFFRENT TYPES\n");
					return 1;

				}

			}
			else
			{

				for (j = 0; j < symSize; j++)
				{

					if ((strcmp(cond[i].params1[k], symbolTable[j].name) == 0) && paramScopeComp(symbolTable[j].scope,cond[i].scope) == 1 && strlen(symbolTable[j].scope) > len)
					{
						ptr1 = &(symbolTable[j]);
						len = (int)strlen(symbolTable[j].scope);
					}
				}
				if (ptr1 == NULL)
				{
					printf("UNDEFINED VARIABLE USED IN CONDITION %s\n", cond[i].params1[k]);
					return 1;

				}
				else
				{
					currentType = ptr1->type;
					if (type1 != NULL && strcmp("int", type1) != 0)
					{
						printf("MATH OPERATORS CAN ONLY BE USED ON INT TYPE\n");
						return 1;

					}
					if (k > 0 && strcmp(ptr1->type, type1) != 0)
					{
						printf("CANNOT USE MATH OPERATORS ON DIFFRENT TYPES\n");
						return 1;

					}

				}
			}
			if (cond[i].size1 == 1 && cond[i].size2 == 0)
			{

				if (strcmp(currentType, "boolean") != 0)
				{
					printf("TYPE %s CANNOT BE USED AS CONDITION\n", currentType);
					return 1;

				}
			}
			if (cond[i].size2 == 0 && cond[i].size1 > 1)
			{
				printf("CONDITION MUST BE OF BOOLEAN TYPE\n");
				return 1;
				break;
			}
			type1 = currentType;
		}
		for (k = 0; k < cond[i].size2; k++) //loops params 2
		{

			len = 0;
			ptr2 = NULL;
			if (cond[i].params2[k]!=NULL && strcmp( cond[i].params2[k], "int") == 0)
			{
				currentType = mkstr("int");
				if (type2 != NULL && strcmp("int", type2) != 0)
				{
					printf("MATH OPERATORS CAN ONLY BE USED ON INT TYPE\n");
					return 1;

				}
				if (type2 != NULL && strcmp(type2, currentType) != 0)
				{
					printf("CANNOT USE MATH OPERATORS ON DIFFRENT TYPES\n");
					return 1;

				}
			}
			else if (cond[i].params2[k]!=NULL && (strcmp(cond[i].params2[k], "true") == 0 
			|| strcmp(cond[i].params2[k], "false") == 0))
			{
				if (type2 != NULL && strcmp("int", type2) != 0)
				{
					printf("MATH OPERATORS CAN ONLY BE USED ON INT TYPE\n");
					return 1;

				}
				currentType = mkstr("boolean");
				if (type2 != NULL && strcmp(type2, currentType) != 0)
				{
					printf("CANNOT USE MATH OPERATORS ON DIFFRENT TYPES\n");
					return 1;

				}
			}
			else if (cond[i].params2[k]!=NULL &&  strcmp(cond[i].params2[k], "char") == 0)
			{
				currentType = mkstr("char");
				if(type2 != NULL && strcmp(type2, currentType) != 0)
				{
					printf("CANNOT USE MATH OPERATORS ON DIFFRENT TYPES\n");
					return 1;
				}
			}
			else
			{
				for (j = 0; j < symSize; j++)
				{
					if ((strcmp(cond[i].params2[k], symbolTable[j].name) == 0) && paramScopeComp(symbolTable[j].scope,cond[i].scope) == 1 && strlen(symbolTable[j].scope) > len)
					{
						ptr2 = &(symbolTable[j]);
						len = (int)strlen(symbolTable[j].scope);
					}
				}

				if (ptr2 == NULL)
				{
					printf("UNDEFINED VARIABLE USED IN CONDITION %s\n", cond[i].params2[k]);
					return 1;

				}
				else
				{
					currentType = ptr2->type;
					if (type2 != NULL && strcmp("int", type2) != 0)
					{
						printf("MATH OPERATORS CAN ONLY BE USED ON INT TYPE\n");
						return 1;

					}
					if (k > 0 && strcmp(ptr2->type, type2) != 0)
					{
						printf("CANNOT USE MATH OPERATORS ON DIFFRENT TYPES\n");
						return 1;

					}
				}


			}

			type2 = currentType;
		}

		if (cond[i].sign != NULL && (strcmp(cond[i].sign, "==") == 0 || strcmp(cond[i].sign, "!=") == 0))
		{
			if (type1 != NULL && type2 != NULL &&strcmp(type1, type2) != 0)
			{
				printf("CANNOT USE != OR == SIGNS ON DIFFRENT TYPES\n");
				return 1;

			}
		}

		else if (cond[i].sign != NULL && (strcmp(cond[i].sign, ">") == 0 || strcmp(cond[i].sign, ">=") == 0
			|| strcmp(cond[i].sign, "<=") == 0 || strcmp(cond[i].sign, "<") == 0))
		{

			if (type1 != NULL && type2 != NULL)
			{
				if (strcmp(type1, type2) == 0 && strcmp(type1, "int") != 0)
				{
					printf("CANNOT USE <,<=,>,>= SIGNS ON NON INTEGER TYPES\n");
					return 1;

				}
				else if (strcmp(type1, type2) != 0)
				{
					printf("CANNOT USE <,<=,>,>= SIGNS ON DIFFRENT TYPES\n");
					return 1;
				}
			}
		}
	}


	return 0;

}

/*func assign funcs*/
void addFuncAssign(char* var, char *func)
{
	if (assignFuncs == NULL) {
		assignFuncs = (funcAssign*)malloc(sizeof(funcAssign));
		assignFuncs[0].var = mkstr(var);
		assignFuncs[0].func = mkstr(func);
		assignFuncs[0].scope = mkstr(getCurrent());
		assignFuncs[0].varSym = NULL;
		assignFuncs[0].funcSym = NULL;
		sizeOfAssignFuncs++;
	}
	else
	{
		sizeOfAssignFuncs++;
		assignFuncs = realloc(assignFuncs, sizeOfAssignFuncs * sizeof(funcAssign));
		assignFuncs[sizeOfAssignFuncs - 1].scope = mkstr(getCurrent());
		assignFuncs[sizeOfAssignFuncs - 1].var = mkstr(var);
		assignFuncs[sizeOfAssignFuncs - 1].func = mkstr(func);
		assignFuncs[sizeOfAssignFuncs - 1].varSym = NULL;
		assignFuncs[sizeOfAssignFuncs - 1].funcSym = NULL;
	}
}
void printAllFuncAssigns()
{
	int  i;
	for (i = 0; i < sizeOfAssignFuncs; i++)
	{
		printf("var is %s func is %s scope is %s\n", assignFuncs[i].var, assignFuncs[i].func, assignFuncs[i].scope);
	}
}
int checkFuncsAssign()
{

	int i, j, len = 0;
	for (i = 0; i < sizeOfAssignFuncs; i++)
	{
		len = 0;
		for (j = 0; j < symSize; j++)
		{
			if ((strcmp(assignFuncs[i].var, symbolTable[j].name) == 0) && paramScopeComp(symbolTable[j].scope,assignFuncs[i].scope) == 1 && strlen(symbolTable[j].scope) > len)
			{
				assignFuncs[i].varSym = &(symbolTable[j]);
			}

			if (strcmp(assignFuncs[i].func, symbolTable[j].name) == 0 && (paramScopeComp(symbolTable[j].scope,assignFuncs[i].scope) == 1))
			{

				assignFuncs[i].funcSym = &(symbolTable[j]);
			}
		}
	}
	for (i = 0; i < sizeOfAssignFuncs; i++)
	{
		if (assignFuncs[i].varSym == NULL)
		{
			printf("UNDEFINED VARIABLE %s USED\n ", assignFuncs[i].var);
			return 1;

		}


		if (assignFuncs[i].funcSym == NULL)
		{
			printf("UNDEFINED FUNCTION %s USED\n ", assignFuncs[i].func);
			return 1;

		}
		if (strcmp(assignFuncs[i].funcSym->type, assignFuncs[i].varSym->type) != 0)
		{
			printf("CANNOT ASSIGN VALUE OF TYPE %s TO TYPE %s \n", assignFuncs[i].funcSym->type, assignFuncs[i].varSym->type);
			return 1;

		}

	}

	return 0;
}

/*addres and deref functions*/
void addressDerefUse(char* name, char*sign/*& or ^*/, char*id1, char*id2, char* plusMinus,int flag)//three last params can be null;
{
	int len = 0;
	if (plusMinus != NULL && strcmp(plusMinus, "+") != 0 && strcmp(plusMinus, "-") != 0)
	{
		printf("CANNOT MULTIPLY OR DIVIDE ADDRESS OR DREF \n");
		return;
	}
	//case symbol table empty
	if (addressAndDeref == NULL)
	{
		addressAndDeref = (symtab*)malloc(sizeof(symtab));
		addressAndDeref->name = mkstr(name);
		addressAndDeref->type = mkstr(sign);
		addressAndDeref->scope = mkstr(getCurrent());
		addressAndDeref->paramNum = 0;
		addressAndDeref->params = NULL;
		addressAndDerefSize++;
		addressAndDeref->flag = flag;
		if (id1 != NULL)
			addressAndDeref->paramNum++;
		if (id2 != NULL)
			addressAndDeref->paramNum++;

		if (addressAndDeref->paramNum != 0)
		{
			addressAndDeref->params = (char**)malloc(sizeof(char*)*addressAndDeref->paramNum);
			if (addressAndDeref->paramNum == 1)
			{
				if (id1 != NULL && id2 == NULL)
					addressAndDeref->params[0] = mkstr(id1);

				else if (id1 == NULL && id2 != NULL)
					addressAndDeref->params[0] = mkstr(id2);
			}
			else if (addressAndDeref->paramNum == 2)
			{
				addressAndDeref->params[0] = mkstr(id1);
				addressAndDeref->params[1] = mkstr(id2);
			}
		}
	}
	//case need to add symbol
	else
	{

		addressAndDerefSize++;
		addressAndDeref = realloc(addressAndDeref, addressAndDerefSize * sizeof(symtab));
		addressAndDeref[addressAndDerefSize - 1].name = mkstr(name);
		addressAndDeref[addressAndDerefSize - 1].type = mkstr(sign);
		addressAndDeref[addressAndDerefSize - 1].scope = mkstr(getCurrent());
		addressAndDeref[addressAndDerefSize - 1].paramNum = 0;
		addressAndDeref[addressAndDerefSize - 1].params = NULL;
		addressAndDeref[addressAndDerefSize - 1].flag = flag;

		if (id1 != NULL)
			addressAndDeref[addressAndDerefSize - 1].paramNum++;
		if (id2 != NULL)
			addressAndDeref[addressAndDerefSize - 1].paramNum++;

		if (addressAndDeref[addressAndDerefSize - 1].paramNum != 0)
		{
			addressAndDeref[addressAndDerefSize - 1].params = (char**)malloc(sizeof(char*)*addressAndDeref->paramNum);
			if (addressAndDeref[addressAndDerefSize - 1].paramNum == 1)
			{
				if (id1 != NULL && id2 == NULL)
					addressAndDeref[addressAndDerefSize - 1].params[0] = mkstr(id1);

				else if (id1 == NULL && id2 != NULL)
					addressAndDeref[addressAndDerefSize - 1].params[0] = mkstr(id2);
			}
			else if (addressAndDeref[addressAndDerefSize - 1].paramNum == 2)
			{
				addressAndDeref[addressAndDerefSize - 1].params[0] = mkstr(id1);
				addressAndDeref[addressAndDerefSize - 1].params[1] = mkstr(id2);
			}
		}
	}
}
void printAddressAndDeref()
{
	int i, j;
	for (i = 0; i < addressAndDerefSize; i++)
	{
		printf("Addres/Deref use num #%d name:%s type:%s scope:%s paramNum %d\n", i + 1, addressAndDeref[i].name, addressAndDeref[i].type, addressAndDeref[i].scope, addressAndDeref[i].paramNum);
		for (j = 0; j < addressAndDeref[i].paramNum; j++)
			printf("param #%d name:%s ", j + 1, addressAndDeref[i].params[j]);
		printf("\n");
	}
	return;
}
int checkAdreessAndDeref()
{
	int i, j, k = 0, len = 0, len2 = 0, len3 = 0, flag = 0,len4=0;
	symtab *ptr=NULL,*ptr2=NULL;

	for (i = 0; i < addressAndDerefSize; i++)
	{
	ptr=NULL;
	ptr2=NULL;
		if (addressAndDeref[i].flag == 0)
		{
			for (j = 0; j < symSize; j++)
			{
				len = 0;
				len2 = 0;
				if (strcmp(addressAndDeref[i].type, "&") == 0)
				{
					if ((strcmp(addressAndDeref[i].params[0], symbolTable[j].name) == 0) && paramScopeComp(symbolTable[j].scope, addressAndDeref[i].scope) == 1 && strlen(symbolTable[j].scope) > len)
					{
						flag = 1;
						len = strlen(symbolTable[j].scope);
						ptr = &(symbolTable[j]);
					}
					if(j==symSize-1)
					{
						if(ptr==NULL)
						{
							printf("undefined used with &\n");
							return 1;
						}
			/*	char x;
			intp y;
			y = &x;    */
						if (addressAndDeref[i].paramNum == 2 && strcmp(addressAndDeref[i].params[1], "[") == 0)
						{
						
							if (strcmp(ptr->type, "string") != 0)
							{
								printf("USED & WITH AN INVALID TYPE\n");
								return 1;
							}
						}
						else
						{
							if (strcmp(ptr->type, "char") != 0 && strcmp(ptr->type, "int") != 0)
							{
								printf("OPERATOR & EXPECTED CHAR OR INT RECIEVED %s\n", ptr->type);
								return 1;
							}
						}

					}
				}
				else if (strcmp(addressAndDeref[i].type, "^") == 0)
				{
					if ((strcmp(addressAndDeref[i].params[0], symbolTable[j].name) == 0) && paramScopeComp(symbolTable[j].scope, addressAndDeref[i].scope) == 1 && strlen(symbolTable[j].scope) > len)
					{
						flag = 1;
						if (j==symSize-1 && strcmp(symbolTable[j].type, "charp") != 0 && strcmp(symbolTable[j].type, "intp") != 0)//checking first param to be inp or char case of x=^y   y must be intp or charp
						{
							printf("USED ^ WITH AN INVALID TYPE\n");
							return 1;
						}

						if (addressAndDeref[i].paramNum == 2)//checking 2nd param to be integer case of x=^y+5 or x=^y+x
						{
							for (k = 0; k < symSize; k++)
							{
								if (isdigit(addressAndDeref[i].params[1][0]))//case x=^y+5  all good
									return 0;
								else if ((strcmp(addressAndDeref[i].params[1], symbolTable[k].name) == 0) && paramScopeComp(symbolTable[k].scope, addressAndDeref[i].scope) == 1 && strlen(symbolTable[k].scope) > len2);
								//case x=^y+z  need to check z for integer
								{
									flag = 1;
									if (strcmp(symbolTable[k].type, "int") != 0)
									{
										printf("ADDED A NON ITERGER VALUE TO A POINTER TYPE\n");
										return 1;
									}
								}

							}

						}

					}
				}

			}
		}
		else
		{
			//^mashu1 = mashu2      mushu1 = charp, intp   mashu2 = char/int
			for (j = 0; j < symSize; j++)
			{
				len = 0;
				len2 = 0;
					if ((strcmp(addressAndDeref[i].name, symbolTable[j].name) == 0) && paramScopeComp(symbolTable[j].scope, addressAndDeref[i].scope) == 1 && strlen(symbolTable[j].scope) > len)
					{
						flag = 1;
						ptr = &(symbolTable[j]);
						if (strcmp(symbolTable[j].type, "charp") ==0 )//checking first param to be inp or char case of x=^y   y must be intp or charp
						{
							len4 = 0;
							if (strcmp(addressAndDeref[i].params[0], "char") == 0)
							{
								continue;
							}
							for (k = 0; k < symSize; k++)
							{
								if ((strcmp(addressAndDeref[i].params[0], symbolTable[k].name) == 0) && paramScopeComp(symbolTable[k].scope, addressAndDeref[i].scope) == 1 && strlen(symbolTable[k].scope) > len)
								{

									len4 = strlen(symbolTable[k].scope);
									ptr2 = &(symbolTable[k]);
									if (strcmp(ptr2->type, "char") != 0)
									{
										printf("CANNOT ASSIGN NON CHAR TYPE TO CHARP\n");
										return 1;
									}
								}
							}
						}
						else if(strcmp(symbolTable[j].type, "intp") == 0)
						{
							len4 = 0;
							if (strcmp(addressAndDeref[i].params[0], "int") == 0)
							{
								continue;
							}
							for (k = 0; k < symSize; k++)
							{
								if ((strcmp(addressAndDeref[i].params[0], symbolTable[k].name) == 0) && paramScopeComp(symbolTable[k].scope, addressAndDeref[i].scope) == 1 && strlen(symbolTable[k].scope) > len)
								{
									len4 = strlen(symbolTable[k].scope);
									ptr2 = &(symbolTable[k]);
				
								}
							}
							if (strcmp(ptr2->type, "int") != 0)
							{
									printf("CANNOT ASSIGN NON INT TYPE TO INTP\n");
									return 1;
							}
						}
						else
						{
							printf("CANNOT DEREF NON POINTER TYPE\n");
							return 1;
						}

						if (addressAndDeref[i].paramNum == 2)//checking 2nd param to be integer case of x=^y+5 or x=^y+x
						{
							for (k = 0; k < symSize; k++)
							{
								if (isdigit(addressAndDeref[i].params[1][0]))//case x=^y+5  all good
									return 0;
								else if ((strcmp(addressAndDeref[i].params[1], symbolTable[k].name) == 0) && paramScopeComp(symbolTable[k].scope, addressAndDeref[i].scope) == 1 && strlen(symbolTable[k].scope) > len2);
								//case x=^y+z  need to check z for integer
								{
									flag = 1;
									if (strcmp(symbolTable[k].type, "int") != 0)
									{
										printf("ADDED A NON ITERGER VALUE TO A POINTER TYPE\n");
										return 1;
									}
								}

							}

						}

					}

			}
		}

		if (flag == 0)
		{
			
			printf("UNDEFINED VARIABLE USED\n");
			return 1;
		}
		
	}
	return 0;
}

/*bracket veriables check (can only be used if type is string)*/
void addBracketUse(char *str, char* scope)
{
	if (bracketVars == NULL) {
		bracketVars = (usedVars*)malloc(sizeof(usedVars));
		bracketVars[0].name = mkstr(str);
		bracketVars[0].scope = mkstr(scope);
		bracketVarsSize++;
	}
	else
	{
		bracketVarsSize++;
		bracketVars = realloc(bracketVars, bracketVarsSize * sizeof(usedVars));
		bracketVars[bracketVarsSize - 1].scope = mkstr(scope);
		bracketVars[bracketVarsSize - 1].name = mkstr(str);
	}
}
void printAllBracketVars()
{
	int i;
	for (i = 0; i < bracketVarsSize; i++)
		printf("name %s\n", bracketVars[i].name);
}

/*BRACKET PARAM FUNCS*/
void addBracketParam(char *str, char*scope)
{
	if (bracketParam == NULL) {
		bracketParam = (usedVars*)malloc(sizeof(usedVars));
		bracketParam[0].name = mkstr(str);
		bracketParam[0].scope = mkstr(scope);
		bracketSize++;
		return;
	}
	bracketSize++;
	bracketParam = realloc(bracketParam, bracketSize * sizeof(usedVars));
	bracketParam[bracketSize - 1].scope = mkstr(scope);
	bracketParam[bracketSize - 1].name = mkstr(str);
}
void printAllBracketParam() {
	int i;
	for (i = 0; i < bracketSize; i++)
		printf("name %s\n", bracketParam[i].name);
}
/*checks*/
int checkExits() {
	int i = 0, j = 0;
	if (symbolTable != NULL)
	{
		for (i = 0; i < symSize; i++)
			for (j = i + 1; j < symSize; j++)
			{
				if (strcmp(symbolTable[j].scope, symbolTable[i].scope) == 0)
				{
					if (strcmp(symbolTable[j].type, symbolTable[i].type) == 0)
						printf("REDECLARATION of variable %s\n", symbolTable[j].name);
					else
						printf("DECLATRION ERROR of variable %s\n", symbolTable[j].name);
					return 1;
				}
			}

	}
	return 0;
}
int checkBracketParam()
{
	int i, j, len = 0;
	for (i = 0; i < bracketSize; i++)
	{
		len = 0;
		for (j = 0; j < symSize; j++)
		{
			if ((strcmp(bracketParam[i].name, symbolTable[j].name) == 0) && scopeComp(symbolTable[j].scope, bracketParam[i].scope) == 1 && strlen(symbolTable[j].scope) > len)
			{
				if (strcmp(symbolTable[j].type, "int") != 0)
				{
					printf("INVALID TYPE USED IN BRACKETS , EXPECTED INT RECIEVED %s , (PARAM %s)\n", symbolTable[j].type, symbolTable[j].name);
					return 1;
				}
			}
		}
	}
	return 0;
}
int checkBracketUse()
{
	int i, j, len = 0, flag = 0;
	symtab* ptr;
	for (i = 0; i < bracketVarsSize; i++)
	{
		flag = 0;
		len = 0;
		for (j = 0; j < symSize; j++)
		{
			if ((strcmp(bracketVars[i].name, symbolTable[j].name) == 0) && paramScopeComp(symbolTable[j].scope,bracketVars[i].scope) == 1 && strlen(symbolTable[j].scope) > len)
			{
				flag = 1;
				ptr=&(symbolTable[j]);
			}
		}
		if (strcmp(ptr->type, "string") != 0)
		{
					printf("INVALID TYPE USED WITH [] , EXPECTED STRING RECIEVED %s , (VARIABLE %s)\n", 
					symbolTable[j].type, symbolTable[j].name);
					return 1;
		}
		if (flag == 0)
		{
			//undefined BS
		}
	}
	return 0;
}
int checkCalls()
{
	int i, j, k, len = 0, flag = 0;
	symtab st;
	symtab param;
	for (i = 0; i < callSize; i++)
	{
	calls[i].paramNum = calls[i].paramNum - calls[i].signSize;
		len = 0;
		flag = 0;
		char* scope = calls[i].scope;
		for (j = 0; j < symSize; j++)
		{
		
			if ((strcmp(calls[i].name, symbolTable[j].name) == 0) && paramScopeComp(symbolTable[j].scope, calls[i].scope) == 1 && strlen(symbolTable[j].scope) > len)
			{
				st = symbolTable[j];
				flag = 1;
				len = (int)strlen(symbolTable[j].scope);
			}
		}
		if (flag == 0)
		{
			printf("UNDECLARED OR DIFFRENT SCOPE FUNCTION CALLED %s\n", calls[i].name);
			return 1;
		}
		if (st.paramNum != calls[i].paramNum)
		{
			printf("FUNCTION %s CALLED WITH WRONG NUMBER OF PARAMETERS\n", calls[i].name);
			return 1;

		}

		for (k = 0; k < calls[i].paramNum; k++)//loops params
		{
			len = 0;
			flag = 0;
			for (j = 0; j < symSize; j++)//loops symbols
			{
				if(strcmp(calls[i].params[k],"int")==0)
				{
					flag = 1;
					param.type = mkstr("int");
					break;
				}
				if(strcmp(calls[i].params[k],"char")==0)
				{
					flag = 1;
					param.type = mkstr("char");
					break;
				}
				if (strcmp(calls[i].params[k], symbolTable[j].name) == 0)//compare names
				{
					if (paramScopeComp(symbolTable[j].scope, calls[i].scope) == 1 && strlen(symbolTable[j].scope) > len)//find symbol with MOST matching scope
					{
						param = symbolTable[j];

						flag = 1;
						len = (int)strlen(symbolTable[j].scope);

					}
				}
			}
			if (flag == 0) //didnt find matching symbol to param used in function call
			{
				printf("FUNCTION CALLED WITH A PARAM THAT IS UNDECLARED OR AT DIFFRENT SCOPE param :%s\n", calls[i].params[k]);
				return 1;

			}
			//printf("param type %s  sym param %s",param.type, st.params[k]);
			if (strcmp(param.type, st.params[k]) != 0)
			{
				printf("FUNCTION CALLED WITH A INVALID PARAM TYPE param :%s is invalid type expected %s  recived %s\n", calls[i].params[k], st.params[k], param.type);
				return 1;

			}


		}

	}
	return 0;
}
int checkMain()
{
	int i, cnt = 0;
	for (i = 0; i < symSize; i++)
		if (strcmp(symbolTable[i].name, "main") == 0)
			cnt++;
	if (cnt >= 2)
	{
		printf("CANNOT HAVE MORE THEN ONE MAIN\n");
		return 1;

	}
	if (cnt == 0)
	{
		printf("PROGRAM MUST HAVE MAIN\n");
		return 1;
	}
	for (i = 0; i < symSize; i++)
		if (strcmp(symbolTable[i].name, "main") == 0)
			if (symbolTable[i].paramNum > 0)
			{
				printf("MAIN CANNOT HAVE PARAMETERS\n");
				return 1;

			}
	return 0;
}

/*symbol table funcs*/
void addSymbol(char* name, char* type) {
	//case symbol table empty
	if (symbolTable == NULL) {
		symbolTable = (symtab*)malloc(sizeof(symtab));
		symbolTable->name = "global";
		symbolTable->type = "global";
		symbolTable->scope = "global";
		symbolTable->paramNum = 0;
		symbolTable->params = NULL;
		symSize++;
		addSymbol(name, type);
		return;
	}

	//case need to add symbol
	else
	{

		symSize++;
		symbolTable = realloc(symbolTable, symSize * sizeof(symtab));
		symbolTable[symSize - 1].name = mkstr(name);
		symbolTable[symSize - 1].type = mkstr(type);
		symbolTable[symSize - 1].scope = concat(getCurrent(), concat("/", name));
		symbolTable[symSize - 1].paramNum = 0;
		symbolTable[symSize - 1].params = NULL;
	}
}
char* getScope(symtab sym)
{
	//  global/main/x will return global/main
	int i, namelen = (int)strlen(sym.name);
	int scopelen = (int)strlen(sym.scope);
	char *str = mkstr(sym.scope);
	for (i = 0; i < namelen + 1; i++)
		str[scopelen - 1 - i] = '\0';
	return str;
}
char *getLastScope(char *s)
{
	// global/main/func  will return func
	int len = (int)strlen(s), i = len, j = 0;
	while (s[i] != '/' && i > 0) {
		i--;
	}
	i++;
	char* last = (char*)malloc(sizeof(char)*((len - i) + 1));
	for (j = 0; i < len; i++) {
		last[j] = s[i];
		j++;
	}
	last[j] = '\0';
	return last;
}
void printAllSymbols() {
	int i, j;
	if (symbolTable != NULL)
		for (i = 0; i < symSize; i++)
		{
			printf("[name:%s type:%s scope:%s  ]\n", symbolTable[i].name, symbolTable[i].type, symbolTable[i].scope);
			if (symbolTable[i].params != NULL)
				for (j = 0; j < symbolTable[i].paramNum; j++)
					printf("param %d:%s   ", j + 1, symbolTable[i].params[j]);
			printf("\n");
		}

}
void addParam()
{
	//printParamStk();
	int i, j = 0,k;
	symtab* st = &(symbolTable[symSize - 1]);
	if (paramStkSize == 0)
		return;
	for(i = paramStkSize-1; strcmp(paramStk[i].name,"<!>")!=0;i--){j++;};
	st->paramNum = j;
	st->params = (char**)malloc(sizeof(char*)*j);
	for(k=0;k<j;k++)
	{
		st->params[k] = paramStk[paramStkSize-1].name;
		popParam();
	}
			popParam();
}
symtab *getSymByScope() {

	int i;

	for (i = 0; i < symSize; i++)
		if (strcmp(getCurrent(), symbolTable[i].scope))
			return &(symbolTable[i]);

	printf("ERROR getSymByScope found no result!");
	return &(symbolTable[i]);

}
int paramScopeComp(char* param/*global/main/x*/ ,char* other/*global/main*/)
{
	//other global/fee1/fee2 param global/fee1/k  return true
	//other global/fee1/fee2 param global/fee1/block0/k  return false
	int i,j,k;

	char *p = mkstr(param);
	char *o = mkstr(other);
	
	int len = (int)strlen(p);
		
	for (i = len - 1; p[i] != '/' || i == 0; i--)//take off k from global/fee1/k
		p[i] = '\0';
	if (i > 0)
		p[i] = '\0';
	
	for (i = 0; i < strlen(p); i++)
	//compares global/fee1 with global/fee1/fee2  OR global/fee1/block0 with global/fee1/fee2
	{
		if (p[i] != o[i])
			return 0;
	}
	return 1;

}
int scopeComp(char* small, char* big)
{
	int i;
	int cnt1 = 0, cnt2 = 0;
	for (i = 0; i < strlen(small); i++)
	{
		if (small[i] == '/')
			cnt1++;
	}
	for (i = 0; i < strlen(big); i++)
	{
		if (big[i] == '/')
			cnt2++;
	}
	if (cnt1 > cnt2)
	{
		char *temp = big;
		big = small;
		small = temp;
	}

	int smalllen = (int)strlen(small);
	char *smallstr = mkstr(small);
	for (i = smalllen - 1; smallstr[i] != '/' || i == 0; i--)
		smallstr[i] = '\0';
	if (i > 0)
		smallstr[i] = '\0';
	for (i = 0; i < strlen(smallstr); i++)
	{
		if (smallstr[i] != big[i])
			return 0;
	}
	return 1;
}
int FuncScopeComp(char* small, char* big)
{
	int i;
	int cnt1 = 0, cnt2 = 0;
	for (i = 0; i < strlen(small); i++)
	{
		if (small[i] == '/')
			cnt1++;
	}
	for (i = 0; i < strlen(big); i++)
	{
		if (big[i] == '/')
			cnt2++;
	}
	if (cnt1 > cnt2)
	{
		char *temp = big;
		big = small;
		small = temp;
	}

	int biglen = (int)strlen(big);
	char *bigstr = mkstr(big);
	for (i = biglen - 1; bigstr[i] != '/' || i == 0; i--) //turns global/main/x to global/main
		bigstr[i] = '\0';
	if (i > 0)
		bigstr[i] = '\0';

	int smalllen = (int)strlen(small);
	char *smallstr = mkstr(small);


	for (i = 0; i < strlen(smallstr); i++)//compare global/main to other scope
	{
		if (smallstr[i] != bigstr[i])
			return 0;
	}
	return 1;
}
char* fixScope(char* scope)//removes leftest for/while/if......
{
	//for global/main/for0/func/if1/while2  return global/main/for0/func
	int i;
	char *newScope = mkstr(scope);
	char *lastScope = mkstr(getLastScope(scope));

	char* fo;
	char *iff;
	char *whil;
	int len = (int)strlen(newScope);


	do {
		lastScope = getLastScope(newScope);
		fo = NULL;
		iff = NULL;
		whil = NULL;
		fo = strstr(lastScope, "for");
		iff = strstr(lastScope, "if");
		whil = strstr(lastScope, "while");


		if (fo || whil || iff)
		{
			for (i = len - 1; newScope[i] != '/'; i--)
			{
				newScope[i] = '\0';
			}
			newScope[i] = '\0';
		}
	} while (fo != NULL || whil != NULL || iff != NULL);

	return newScope;

}
/*string funcs*/
char *mkstr(char * str)
{
	char *s = (char*)malloc(strlen(str) * sizeof(char));
	if (s == NULL) {
		printf("error allocating memory ending progrem\n");
		exit(1);
	}
	strcpy(s, str);
	return s;
}
char *concat(char *str1, char *str2)
{
	int i, j = 0;
	char *s = (char*)malloc((strlen(str1) + strlen(str2) + 1) * sizeof(char));
	for (i = 0; i < strlen(str1); i++)
		s[i] = str1[i];
	for (i = i; i < strlen(str1) + strlen(str2); i++) {
		s[i] = str2[j];
		j++;
	}
	s[i] = '\0';
	return s;
}

/*param Stack*/
void pushParam(char *type)
{
	paramStkSize++;
	if (paramStk == NULL && paramStkSize == 1) {
		paramStk = (stack*)malloc(sizeof(stack));
		paramStk->name = mkstr(type);
		return;
	}

	paramStk = realloc(paramStk, paramStkSize * sizeof(stack));
	paramStk[paramStkSize - 1].name = mkstr(type);
}

char* popParam() {

	if (paramStkSize <= 0) {
		printf("popping param stack when empty error");
		paramStk = NULL;
		return NULL;
	}
	else {
		paramStkSize--;
		if (paramStkSize == 0)
		{
			char *s = paramStk[paramStkSize].name;
			paramStk = NULL;
			return s;
		}
		return paramStk[paramStkSize].name;

	}
}

void printParamStk()
{
	while (paramStkSize > 0)
	{
		printf("size is %d  ", paramStkSize);
		printf("name:%s\n", paramStk[paramStkSize - 1].name);
		popParam();
	}
}

/*scope stack funcs*/
void pop()
{

	if (stksize <= 0) {
		printf("popping stack when empty error");
		return;
	}
	stksize--;
	if (stksize == 0) {
		stk = NULL;
	}

}
void push(char* str) {
	stksize++;
	if (stk == NULL && stksize == 1) {
		stk = (stack*)malloc(sizeof(stack));
		stk[0].name = mkstr("global");
		stksize++;
	}
	stk = realloc(stk, stksize * sizeof(stack));
	if (strcmp(str, "while") == 0 || strcmp(str, "for") == 0 || strcmp(str, "do") == 0 || strcmp(str, "if") == 0 || strcmp(str, "else") == 0||strcmp(str, "block") == 0) {
		char numstr[12];
		sprintf(numstr, "%d", indexCounter++);
		stk[stksize - 1].name = concat(stk[stksize - 2].name, concat("/", concat(mkstr(str), numstr)));

	}
	else
		stk[stksize - 1].name = concat(stk[stksize - 2].name, concat("/", mkstr(str)));
}
char* getCurrent() {
	if (stksize != 0)
		return stk[stksize - 1].name;
	else return "global";
}
void printStack() {
	while (stk != NULL)
	{
		printf("size is %d  ", stksize);
		printf("name:%s\n", stk[stksize - 1].name);
		pop();
	}
}

//RULE 6
void addVarError(char* name) {

	if (vars == NULL) {
		vars = (usedVars*)malloc(sizeof(usedVars));
		vars->name = name;
		vars->scope = getCurrent();
		varsSize++;
	}
	else {
		varsSize++;
		vars = realloc(vars, varsSize * sizeof(usedVars));
		vars[varsSize - 1].name = name;
		vars[varsSize - 1].scope = getCurrent();
	}
}
void checkVarDeclaration(char* name)
{
	int i;
	if (symSize == 0)
	{
		addVarError(name);

	}
	for (i = 0; i < symSize; i++)
	{
		if (strcmp(name, symbolTable[i].name) == 0 && strstr(getCurrent(), getScope(symbolTable[i])) != NULL)
		{
			break;
		}
		if (i + 1 == symSize)
		{
			addVarError(name);
		}
	}
}
int checkVarDefenition()
{
	int i;
	if (varsSize > 0)
		printf("Found %d declarations errors\n", varsSize);

	for (i = 0; i < varsSize; i++)
	{
		printf("[%s] was used before/without declaration\n", vars[i].name);
	}
	if (varsSize > 0)
		return 1;
	return 0;
}
char* findVarTypeByName(char* name) {
	int i;

	for (i = symSize - 1; i >= 0; i++)
	{
		if (symbolTable[i].name == name && strstr(getCurrent(), getScope(symbolTable[i])) != NULL)
		{
			return symbolTable[i].type;
		}
	}

	return "Undifiend var";
}


/*all test*/
void fixstuff()
{
	int i,j;
	for(i=0;i<condSize;i++)
	{
		if(cond[i].size1==0)
			cond[i].params1=NULL;
		if(cond[i].size2==0)
			cond[i].params2=NULL;
	}
}

int runAllTest()
{
	fixstuff();


	int cnt = 0;
	
	
	if(checkBoolExpPtr())
		cnt++;

	if (checkMain())
		cnt++;

	if (checkExits())
		cnt++;
	//printf("before checkcalls\n");
	if (checkCalls())
		cnt++;
	//printf("aftercheckcalls\n");
	if (checkBracketParam())
		cnt++;

	if (checkBracketUse())
		cnt++;

	//printf("before adreeeeees\n");
	if (checkAdreessAndDeref())
		cnt++;

	//printf("after adreeeeees\n");

	if (checkFuncsAssign())
		cnt++;
	//printf("ima here before bool exp\n");
	if (checkBoolExp())
		cnt++;
	//printf("ima here after bool exp before assign check\n");
	if (checkAssign())
		cnt++;
	//printf("ima here after assign check\n");

	if (checkNullAssign())
		cnt++;

	if (checkVarsinAbs())
		cnt++;
	if (checkVarDefenition())
		cnt++;
	if (checkReturnValues())
		cnt++;

	if (cnt == 0)
		return 1;
	return 0;

}
