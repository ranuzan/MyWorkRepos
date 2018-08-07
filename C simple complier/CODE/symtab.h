#include "ast.h"
#include <ctype.h>

typedef struct symtab {
	char* name;
	char* type;
	char* scope;
	int paramNum;
	char **params;
	int flag;
}symtab;

typedef struct funcall {
	char* scope;
	int paramNum;
	char** params;
	char* name;
	char **sign;
	int signSize;
}funcall;

typedef struct stack {
	char* name;
}stack;


typedef struct usedVars {
	char* name;
	char* scope;
	/*int flag;*/
}usedVars;

typedef struct funcAssign {
	char* var;
	char* func;
	char* scope;
	symtab* varSym;
	symtab* funcSym;
}funcAssign;

typedef struct condition {
	char **params1;
	int size1;
	char **params2;
	int size2;
	char* scope;
	char *sign;
	char* condId;
	char *adrefLeft;
	char *adrefRight;
}condition;

int checkBoolExpPtr();
void addAdref(char*,int);
void addAssignSign(char *sign);
/*symboltable funcs*/
void addSymbol(char* name, char* type);
void printAllSymbols();
int scopeComp(char* small, char* big);
int paramScopeComp(char* param,char* other);
char* getScope(symtab);
symtab* getSymByScope();
char* fixScope(char* scope);
int FuncScopeComp(char* small, char* big);
int isCond(condition assign);
void closeFuncall();
/*scope stack*/
void pop();
void push(char *);
char* getCurrent();


/*funcall funcs*/
void addFuncall(char* name);
void printFuncalls();
void addCallParams(char*);
void addFuncallSign(char * sign);

/*checks*/
int runAllTest();
int checkExits();
int checkCalls();
int checkMain();

/*util*/
char *concat(char *str1, char *str2);
char *mkstr(char * str);

/*func decleration param Stack*/
char* popParam();
void pushParam(char*);
void printParamStk();
void addParam();

/*used vars*/
void addVarError(char* name);
void checkVarDeclaration(char* name);
int checkVarDefenition();

/*bracket param*/
void addBracketParam(char *str, char*scope);
void printAllBracketParam();
int checkBracketParam();
int checkBracketUse();

/*bracket variable*/
void printAllBracketVars();
void addBracketUse(char *str, char* scope);

/*addres and deref functions*/
void addressDerefUse(char* name, char*sign/*& or ^*/, char*id1, char*id2, char* plusMinus,int flag);
void printAddressAndDeref();
int checkAdreessAndDeref();

/*return values functions*/
void addReturnValue(char *func);
void printAllReturnValues();
void addReturnParam(char *p);
int checkReturnValues();
void closeReturn();

/*func assign functions*/
void addFuncAssign(char* var, char *func);
void printAllFuncAssigns();
int checkFuncsAssign();
void addFuncAssign(char* var, char *func);

char* findVarTypeByName(char* name);

/*bool EXP funcs*/
void addBoolExp();
void mkBoolParams1();
void mkBoolParams2();
void addBoolParam(char *param);
void printBoolExp();
void closeBoolExp();
int checkBoolExp();
void addBoolSign(char* sign);
void addCondId(char *id);

/*assign EXP funcs*/
void addAssignExp();
void addAssignParams1(char* p1, char* p2);
void addAssignParams2(char *param);
void closeAssignExp();
void printAssignExp();

/*abs Check Funcs*/
void addVarinAbs(char* p);
void printVarinAbs();
int checkVarsinAbs();

/*Null assign funcs*/
void addNullAssign(char* p);
void printNullAssign();
int checkNullAssign();
