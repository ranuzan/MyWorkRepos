%{
#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#include "symtab.h"

#define N NULL

void yyerror();
int yylex();
NODE* root;
NODE* mknode(char* token,NODE* left, NODE* midLeft,NODE* midRight ,NODE* right);
void print_tree(NODE* tree,int tab);
extern char* yytext;
#define YYSTYPE NODE *
%}

%token IF ELSE ID NUM EQ NEQ LEQ GEQ TYPE WHILE FOR DO DEC INC VOID DEREF/*^*/ ADDRESS/*&*/ STRING CHARACTER VAR_CHARACTER NOT 
%token RETURN Nullptr PTR_TYPE BOOL OR AND
%right '='
%left  '+' '-' 
%left  '*' '/'
%nonassoc then
%nonassoc ELSE
%start PROGRAM
%%
PROGRAM : 
	 FUNC PROGRAM {$$=mknode("",$1,$2,N,N);root=mknode("",$1,$2,N,N);}
	|FUNC  {root =mknode("",$1,N,N,N);}
	;

TYPEDEF :
	 TYPE {$$=mknode(yytext,N,N,N,N);}
	|PTR_TYPE {$$=mknode(yytext,N,N,N,N);}
	;
STRINGTYPE:
	STRING {$$=mknode(yytext,N,N,N,N);};
FUNC : 	
	 TYPEDEF IDENT PUSHSCOPE '('FUNC_VAR')'  '{'ST_REC {addReturnValue($2->token);} RETURN_TYPE'}' {$$=mknode("(",mknode("FUNC",$1,$2,mknode("(ARGS",$5,N,N,mknode(")",N,N,N,N)),N),mknode("(BLOCK",$8,$10,N,mknode(")",N,N,N,N)),N,mknode(")",N,N,N,N));;pop();addSymbol($2->token,$1->token);addParam($2->token);}

	|VOID IDENT PUSHSCOPE '('FUNC_VAR')''{'ST_REC RETURN_VOID'}'{$$=mknode("(",mknode("FUNC",mknode("void",N,N,N,N),$2,mknode("(ARGS",$5,N,N,mknode(")",N,N,N,N)),N),mknode("(BLOCK",$8,$9,N,mknode(")",N,N,N,N)),N,mknode(")",N,N,N,N));pop();addSymbol($2->token,"void");addParam($2->token);}
	;

RETURN_VOID:
 	 RETURN';'{$$=mknode("RETURN",N,N,N,N);}
	 |{$$=mknode("",N,N,N,N);}
	 ;

RETURN_TYPE:
	RETURN  EXP_CALC ';' {$$=mknode("RETURN",$2,N,N,N);closeReturn();}
;

FUNC_VAR:	
	 TYPEDEF IDENT {$$=mknode("",$1,$2,N,N);addSymbol($2->token,$1->token);pushParam("<!>");pushParam($1->token);}
	|STRINGTYPE IDENT  {$$=mknode("",$1,$2,N,N);addSymbol($2->token,$1->token);pushParam($1->token);pushParam("<!>");}
	|TYPEDEF IDENT ',' FUNC_VAR {$$=mknode("",$1,$2,$4,N);addSymbol($2->token,$1->token);pushParam($1->token);}
	|STRINGTYPE IDENT ',' FUNC_VAR {$$=mknode("",$1,$2,N,$4);addSymbol($2->token,$1->token);pushParam($1->token);}
	|{$$=mknode("",N,N,N,N);}
	;
VAR : 	
	 TYPEDEF VAR_REC';'  {$$=mknode("(",$1,$2,N,mknode(")",N,N,N,N));}
	|STRINGTYPE VAR_REC_STRING ';' {$$=mknode("(",$1,$2,N,mknode(")",N,N,N,N));}
	;
VAR_REC: 
	  VAR_REC ','IDENT {$$=mknode("(",$1,$3,N,mknode(")",N,N,N,N));addSymbol($3->token,$0->token);}
	 |VAR_REC',' IDENT '='PUSHASSIGN EXP_CALC {$$=mknode("",$1,mknode(",",N,N,N,N),mknode("=",$3,$6,N,N),N);addSymbol($3->token,$0->token);addAssignParams1($3->token,N);closeAssignExp();}
	 |VAR_REC ','  IDENT '=' PUSHASSIGN CHAR  {$$=mknode("",$1,mknode(",",N,N,N,N),mknode("=",$3,$6,N,N),N);addSymbol($3->token,$0->token);addAssignParams1($3->token,N);addAssignParams2("char");closeAssignExp();}
       	 |IDENT '=' PUSHASSIGN  CHAR {$$=mknode("",mknode("=",N,N,N,N),$1,$4,N);addSymbol($1->token,$0->token);addAssignParams1($1->token,N);addAssignParams2("char");closeAssignExp();}
	 |IDENT {addSymbol($1->token,$0->token);}
	 |IDENT '=' PUSHASSIGN EXP_CALC {$$=mknode("",mknode("=",N,N,N,N),$1,$4,N);addSymbol($1->token,$0->token);addAssignParams1($1->token,N);closeAssignExp();}

	 ;

VAR_REC_STRING:
	 IDENT '['NUMBER']' {$$=mknode("",$1,mknode("[",$3,N,N,mknode("]",N,N,N,N)),N,N);addSymbol($1->token,$0->token);}
	 |VAR_REC_STRING','IDENT '['NUMBER']' {$$=mknode("",$1,$3,mknode("[",$5,mknode("]",N,N,N,N),N,N),N);addSymbol($3->token,$0->token);}
	;

ST : 	 LOOP
	|IF_ELSE	
	|EXP 
	|FUNC_CALL ';'
	|VAR
	;
CHAR:   CHARACTER {$$=mknode(yytext,N,N,N,N);}
	;
IDREC:
	EXP_CALC 
	|IDREC ',' EXP_CALC {$$=mknode("",$1,$3,N,N);}
	|CHAR	{addCallParams("char");}
	|IDREC ',' CHAR {$$=mknode("",$1,$3,N,N);addCallParams("char");}
	| {$$=mknode("",N,N,N,N);}
	;
FUNC_ASSIGN:
	IDENT '=' PUSHASSIGN PUSHBOOL IDENT {addFuncall($5->token);}  '('IDREC ')'{$$=mknode("(",mknode("=",N,N,N,N),
	$1,mknode("(CALL",mknode("",$5,mknode("PARAMS:",$8,N,N,N),N,N),N,N,mknode(")",N,N,N,N)),mknode(")",N,N,N,N));
	checkVarDeclaration($1->token);addBoolSign("<>");addAssignSign("<>");checkVarDeclaration($5->token);closeFuncall();addFuncAssign($1->token,$5->token);
	closeAssignExp();closeBoolExp();}
	;
FUNC_CALL:
	IDENT PUSHFUNCALL '('IDREC')'{$$=mknode("(CALL",mknode("",$1,mknode("PARAMS:",$4,N,N,N),N,N),N,N,mknode(")",N,N,N,N));checkVarDeclaration($1->token);closeFuncall();}
	;
PUSHFUNCALL:{addFuncall($0->token);}
	;

PUSHBOOL:{addBoolExp();mkBoolParams1();};
POPBOOL:{addBoolSign($0->token);mkBoolParams2();};
COND : 	 
	 EXP_BOOL 
	|COND  LOGIC_SIGN PUSHBOOL  EXP_BOOL {$$=mknode("(",$2,$1,$4,mknode(")",N,N,N,N));}
	|'(' COND LOGIC_SIGN PUSHBOOL  EXP_BOOL ')' {$$=mknode("(",$3,$2,$5,mknode(")",N,N,N,N));}
	;

EXP_BOOL:
	 BOOLEAN  {addAssignParams2("boolean");closeBoolExp();}
	|NOT_SIGN BOOLEAN  {$$=mknode("",$1,$2,N,N);closeBoolExp();}
   	|EXP_CALC   BOOL_SIGN POPBOOL EXP_CALC  {$$=mknode("(",$2,$1,$4,mknode(")",N,N,N,N));addAssignSign($2->token);closeBoolExp();}
	|BOOL_REC/*new*/
	|'('BOOL_REC')' {$$=mknode("(",$2,N,N,mknode(")",N,N,N,N));}
	|'(' EXP_CALC   BOOL_SIGN POPBOOL EXP_CALC')'{$$=mknode("(",$3,$2,$5,mknode(")",N,N,N,N));addAssignSign($3->token);closeBoolExp();}
	|NOT_SIGN '(' EXP_CALC   BOOL_SIGN POPBOOL EXP_CALC')'{$$=mknode("(",$1,mknode("(",$4,$3,$6,mknode(")",N,N,N,N)),N,mknode(")",N,N,N,N));addAssignSign($4->token);closeBoolExp();}
	|EXP_CALC {closeBoolExp();}
	|NOT_SIGN EXP_CALC {$$=mknode("",$1,$2,N,N);closeBoolExp();}
	|CHAR_BOOL
	|'('CHAR_BOOL ')' {$$=mknode("(",$2,N,N,mknode(")",N,N,N,N));}
	|ARRAY_BOOL
	|'('ARRAY_BOOL ')' {$$=mknode("(",$2,N,N,mknode(")",N,N,N,N));}
	|EXP_PTR_BOOL
	;
EXP_CALC:
  	 IDENT {checkVarDeclaration($1->token);addBoolParam($1->token);addAssignParams2($1->token);addReturnParam($1->token);addCallParams($1->token);}
   	|NUMBER  {addBoolParam("int");addAssignParams2("int");addReturnParam("int");addCallParams("int");}
	|'('EXP_CALC')'{$$=mknode("(",$2,N,N,mknode(")",N,N,N,N));}
	|EXP_CALC  SIGN %prec then EXP_CALC  {$$=mknode("(",$2,$1,$3,mknode(")",N,N,N,N)); addFuncallSign($2->token);}/*new*/
	|'|'IDENT'|'{$$=mknode("|",$2,N,N,mknode("|",N,N,N,N));addBoolParam("int");addAssignParams2("int");addReturnParam("int");addVarinAbs($2->token);checkVarDeclaration($2->token);addCallParams("int");}
	|'|'NUMBER'|'{$$=mknode("|",$2,N,N,mknode("|",N,N,N,N));addBoolParam("int");addAssignParams2("int");
	addReturnParam;("int");addCallParams("int");}
	;
EXP_ASSIGN:
	 IDENT  '='PUSHASSIGN PUSHBOOL COND  {$$=mknode("(",mknode("=",N,N,N,N),$1,$5,mknode(")",N,N,N,N));checkVarDeclaration($1->token);addAssignParams1($1->token,N);addBoolSign("=");addCondId($1->token);closeAssignExp();}

	|IDENT  '['NUMBER']''=' PUSHASSIGN  CHAR {$$=mknode("(",$1,mknode("[",$3,N,N,mknode("]",N,N,N,N)),mknode("=",$7,N,N,N),mknode(")",N,N,N,N));checkVarDeclaration($1->token);addAssignParams1($1->token,"int");addBracketUse($1->token,getCurrent());addAssignParams2("char");closeAssignExp();}

	|IDENT  '['IDENT']''=' PUSHASSIGN  CHAR {$$=mknode("(",$1,mknode("[",$3,N,N,mknode("]",N,N,N,N)),mknode("=",$7,N,N,N),mknode(")",N,N,N,N));checkVarDeclaration($1->token);checkVarDeclaration($3->token);addBracketUse($1->token,getCurrent());addAssignParams1($1->token,$3->token);addAssignParams2("char");closeAssignExp();}

	|IDENT  '=' PUSHASSIGN PUSHBOOL CHAR  {$$=mknode("(",mknode("=",N,N,N,N),$1,$5,mknode(")",N,N,N,N));
	checkVarDeclaration($1->token);addAssignParams1($1->token,N);addAssignParams2("char");closeAssignExp();closeBoolExp();}

	|IDENT  '=' PUSHASSIGN PUSHBOOL VARCHAR {$$=mknode("(",mknode("=",$1,$5,N,N),N,N,mknode(")",N,N,N,N));
	checkVarDeclaration($1->token);addAssignParams1($1->token,N);addAssignParams2("string");closeAssignExp();closeBoolExp();}

	|IDENT  '['NUMBER']''=' PUSHASSIGN  IDENT {$$=mknode("(",$1,mknode("[",$3,N,N,mknode("]",N,N,N,N)),mknode("=",$7,N,N,N),mknode(")",N,N,N,N));checkVarDeclaration($1->token);checkVarDeclaration($7->token);addAssignParams1($1->token,"int");addAssignParams2($7->token);closeAssignExp();}

	|IDENT  '['IDENT']''=' PUSHASSIGN  IDENT {$$=mknode("(",$1,mknode("[",$3,N,N,mknode("]",N,N,N,N)),mknode("=",$7,N,N,N),mknode(")",N,N,N,N));checkVarDeclaration($1->token);checkVarDeclaration($3->token);checkVarDeclaration($7->token);addAssignParams1($1->token,$3->token);addAssignParams2($7->token);closeAssignExp();}
	;


	
PUSHASSIGN: {addAssignExp();};



VARCHAR:
	VAR_CHARACTER {$$=mknode(yytext,N,N,N,N);}
	;


ST_REC:
	  ST_REC LOOP {$$=mknode("",$1,$2,N,N);}
	| ST_REC VAR {$$=mknode("",$1,$2,N,N);}
	| ST_REC IF_ELSE {$$=mknode("",$1,$2,N,N);}
	| ST_REC EXP {$$=mknode("",$1,$2,N,N);}
	| ST_REC FUNC_CALL ';' {$$=mknode("",$1,$2,N,N);}
	| ST_REC FUNC {$$=mknode("",$1,$2,N,N);}
	| ST_REC '{'PUSHBLOCK ST_REC'}' POP {$$=mknode("",$1,mknode("(BLOCK",$4,N,N,mknode(")",N,N,N,N)),N,N);}
	| {$$=mknode("",N,N,N,N);}
	;

LOOP: 
	 WHILE PUSHWHILE '('PUSHBOOL COND')''{'ST_REC'}' {$$=mknode("(",mknode("WHILE",$5,N,N,mknode("(BLOCK",$8,N,N,mknode(")",N,N,N,N))),N,N,mknode(")",N,N,N,N));pop();}

	|WHILE PUSHWHILE '('PUSHBOOL COND')'ST {$$=mknode("(",mknode("WHILE",$5,N,N,mknode("(",$7,N,N,mknode(")",N,N,N,N))),N,N,mknode(")",N,N,N,N));pop();}

	|DO PUSHWHILE '{'ST_REC'}'WHILE'('PUSHBOOL COND')'';' {$$=mknode("(",mknode("DO",mknode("(",$4,N,N,mknode(")",N,N,N,N)),mknode("(",mknode("WHILE",$9,N,N,N),N,N,mknode(")",N,N,N,N)),N,N),N,N,mknode(")",N,N,N,N));pop();}
		
	|FOR PUSHFOR '('EXP_ASSIGN';'PUSHBOOL COND';'INC_DEC')''{'ST_REC'}'{$$=mknode("(",mknode("FOR",$4,$7,$9,mknode("(BLOCK",$12,N,N,mknode(")",N,N,N,N))),N,N,mknode(")",N,N,N,N));pop();}

	|FOR PUSHFOR '('EXP_ASSIGN';'PUSHBOOL COND';'EXP_ASSIGN')''{'ST_REC'}'{$$=mknode("(",mknode("FOR",$4,$7,$9,mknode("(BLOCK",$12,N,N,mknode(")",N,N,N,N))),N,N,mknode(")",N,N,N,N));pop();}

	|FOR PUSHFOR '('EXP_ASSIGN';'PUSHBOOL COND';'INC_DEC')'ST  {$$=mknode("(",mknode("FOR",$4,$7,$9,mknode("(",$11,N,N,mknode(")",N,N,N,N))),N,N,mknode(")",N,N,N,N));pop();}
	
	|FOR PUSHFOR '('EXP_ASSIGN';'PUSHBOOL COND';'EXP_ASSIGN')'ST {$$=mknode("(",mknode("FOR",$4,$7,$9,mknode("(",$11,N,N,mknode(")",N,N,N,N))),N,N,mknode(")",N,N,N,N));pop();}
	;

IF_ELSE: 
	 IF PUSHIF '('PUSHBOOL COND')'ST %prec then POP{$$=mknode("(",mknode("IF",$5,mknode("(",$7,N,N,mknode(")",N,N,N,N)),N,N),mknode(")",N,N,N,N),N,N);}
	|IF PUSHIF '('PUSHBOOL COND')''{'ST_REC'}' %prec then POP{$$=mknode("(",mknode("IF",$5,mknode("(BLOCK",$8,N,N,mknode(")",N,N,N,N)),N,N),N,N,mknode(")",N,N,N,N));}
	|IF PUSHIF '('PUSHBOOL COND')''{'ST_REC'}' POP ELSE PUSHELSE '{'ST_REC'}' POP {$$=mknode("(",mknode("IF",$5,mknode("(BLOCK",$8,N,N,mknode(")",N,N,N,N)),mknode("(BLOCK",$14,N,N,mknode(")",N,N,N,N)),N),N,N,mknode(")",N,N,N,N));}
	
	|IF PUSHIF '('PUSHBOOL COND')''{'ST_REC'}' POP ELSE PUSHELSE ST POP{$$=mknode("(",mknode("IF",$5,mknode("(BLOCK",$8,N,N,mknode(")",N,N,N,N)),$13,N),N,N,N);}
	
	|IF PUSHIF '('PUSHBOOL COND')'ST POP ELSE PUSHELSE  '{'ST_REC'}' POP{$$=mknode("(",mknode("IF",$5,$7,mknode("(BLOCK",$12,N,N,mknode(")",N,N,N,N)),N),N,N,mknode(")",N,N,N,N));}
	
	|IF PUSHIF '('PUSHBOOL COND')'ST POP ELSE PUSHELSE ST {$$=mknode("(",mknode("IF",$5,$7,$11,N),mknode(")",N,N,N,N),N,N);}
	;




IDENT: 	ID  {$$=mknode(yytext,N,N,N,N);};

NUMBER: NUM {$$=mknode(yytext,N,N,N,N);};

EXP :	 EXP_ASSIGN';'
	|EXP_CALC';'
	|EXP_PTR';'
	|INC_DEC ';'
	|FUNC_ASSIGN ';'	
	;
	

EXP_PTR:
	 IDENT '=' ADDRESS IDENT {$$=mknode("(",mknode("=",N,N,N,N),$1,mknode("&",$3,$4,N,N),mknode(")",N,N,N,N));addressDerefUse($1->token,"&",$4->token,N,N,0);checkVarDeclaration($1->token);checkVarDeclaration($4->token);}

	|DEREF IDENT '=' IDENT {$$=mknode("(",mknode("=",N,N,N,N),mknode("^",$2,N,N,N),$4,mknode(")",N,N,N,N));
	addressDerefUse($2->token,"^",$4->token,N,N,1);checkVarDeclaration($2->token);checkVarDeclaration($4->token);}
	
	|DEREF IDENT '=' NUMBER {$$=mknode("(",mknode("=",N,N,N,N),mknode("^",$2,N,N,N),$4,mknode(")",N,N,N,N));
	addressDerefUse($2->token,"^","int",N,N,1);checkVarDeclaration($2->token);}
	
	|DEREF IDENT '=' CHAR {$$=mknode("(",mknode("=",N,N,N,N),mknode("^",$2,N,N,N),$4,mknode(")",N,N,N,N));
	addressDerefUse($2->token,"^","char",N,N,1);checkVarDeclaration($2->token);}

	|DEREF IDENT '=' IDENT'['IDENT']' {$$=mknode("(",mknode("=",N,N,N,N),mknode("^",$2,N,N,N),mknode("",$4,mknode("[",$5,N,N,mknode("]",N,N,N,N)),N,N),mknode(")",N,N,N,N));addressDerefUse($2->token,"^",$4->token,N,N,1);checkVarDeclaration($2->token);checkVarDeclaration($4->token);checkVarDeclaration($6->token);addBracketParam($6->token,getCurrent());}

	|DEREF IDENT '=' IDENT'['NUMBER']' {$$=mknode("(",mknode("=",N,N,N,N),mknode("^",$2,N,N,N),mknode("",$4,mknode("[",$5,N,N,mknode("]",N,N,N,N)),N,N),mknode(")",N,N,N,N));addressDerefUse($2->token,"^",$4->token,N,N,1);checkVarDeclaration($2->token);checkVarDeclaration($4->token);}

	|IDENT '='ADDRESS IDENT'['IDENT']' {$$=mknode("(",mknode("=",N,N,N,N),$1,mknode("&",$3,$4,N,N),mknode(")",N,N,N,N));addressDerefUse($1->token,"&",$4->token,"[",N,0);addBracketParam($6->token,getCurrent());checkVarDeclaration($1->token);checkVarDeclaration($4->token);checkVarDeclaration($6->token);}

	|IDENT '=' DEREF IDENT {$$=mknode("(",mknode("=",N,N,N,N),$1,mknode("^",$3,$4,N,N),mknode(")",N,N,N,N));addressDerefUse($1->token,"^",$4->token,N,N,0);checkVarDeclaration($1->token);checkVarDeclaration($4->token);}

	|IDENT '=' ADDRESS IDENT'['NUMBER']' {$$=mknode("(",mknode("=",N,N,N,N),$1,mknode("&",$3,$4,mknode("[",$6,N,N,N),mknode("]",N,N,N,N)),mknode(")",N,N,N,N));addressDerefUse($1->token,"&",$4->token,"[",N,0);checkVarDeclaration($1->token);checkVarDeclaration($4->token);}

	|IDENT '=' DEREF'('IDENT SIGN NUMBER')' {$$=mknode("(",mknode("=",N,N,N,N),$1,mknode("(",mknode("^",mknode("(",$6,$5,$7,mknode(")",N,N,N,N)),N,N,mknode(")",N,N,N,N)),N,N,mknode(")",N,N,N,N)),N);addressDerefUse($1->token,"^",$5->token,"1",$6->token,0);checkVarDeclaration($1->token);checkVarDeclaration($5->token);}

	|IDENT '=' DEREF'('IDENT SIGN IDENT')'{$$=mknode("(",mknode("=",N,N,N,N),$1,mknode("(",mknode("^",mknode("(",$6,$5,$7,mknode(")",N,N,N,N)),N,N,mknode(")",N,N,N,N)),N,N,mknode(")",N,N,N,N)),N);addressDerefUse($1->token,"^",$5->token,$7->token,$6->token,0);checkVarDeclaration($1->token);checkVarDeclaration($5->token);checkVarDeclaration($7->token);}
	
	|IDENT '=' NULLPOINTER {$$=mknode("(",mknode("=",$1,$3,N,N),N,N,mknode(")",N,N,N,N));checkVarDeclaration($1->token);addNullAssign($1->token);}
	;
NULLPOINTER:
	Nullptr {$$=mknode("NULL",N,N,N,N);}
	;

BOOLEAN:
	BOOL {$$=mknode(yytext,N,N,N,N);addBoolParam(yytext);};



EXP_PTR_BOOL:
	DEREF IDENT BOOL_SIGN  EXP_CALC  {$$=mknode("(",mknode($3->token,N,N,N,N),mknode("^",$2,N,N,N),$4,mknode(")",N,N,N,N));
	addAdref("^",0);addBoolSign($3->token);checkVarDeclaration($2->token);addBoolParam($2->token);checkVarDeclaration($4->token);closeBoolExp();}
	//adrdef in left  not char or int and deref right is null
		
	|DEREF IDENT BOOL_SIGN CHAR {$$=mknode("(",mknode($3->token,N,N,N,N),mknode("^",$2,N,N,N),$4,mknode(")",N,N,N,N));
	addAdref("^",0);addBoolSign($3->token);checkVarDeclaration($2->token);addBoolParam($2->token);addBoolParam("char");closeBoolExp();}
	
	|CHAR BOOL_SIGN DEREF IDENT {$$=mknode("(",mknode($2->token,N,N,N,N),$1,mknode("^",$4,N,N,N),mknode(")",N,N,N,N));
	addAdref("^",1);addBoolSign($2->token);checkVarDeclaration($4->token);addBoolParam("char");addBoolParam($4->token);closeBoolExp();}
	
	|DEREF IDENT BOOL_SIGN IDENT'['IDENT']' {$$=mknode("(",mknode($3->token,N,N,N,N),mknode("^",$2,N,N,N),mknode("",$4,mknode("[",$6,N,N,mknode("]",N,N,N,N)),N,N),mknode(")",N,N,N,N));addAdref("^",0);checkVarDeclaration($2->token);
	addBoolParam($2->token);addBoolSign($3->token);addBoolParam("char");closeBoolExp();}
	
	|IDENT'['IDENT']' BOOL_SIGN DEREF IDENT {$$=mknode("(",mknode($5->token,N,N,N,N),mknode("",$1,mknode("[",$3,N,N,mknode(")",N,N,N,N)),N,N),mknode("^",$7,N,N,N),mknode(")",N,N,N,N));checkVarDeclaration($1->token);checkVarDeclaration($3->token);checkVarDeclaration($7->token);}
	
	|DEREF IDENT BOOL_SIGN IDENT'['NUMBER']' {$$=mknode("(",mknode($3->token,N,N,N,N),mknode("^",$2,N,N,N),mknode("",$4,mknode("[",$6,N,N,mknode("]",N,N,N,N)),N,N),mknode(")",N,N,N,N));checkVarDeclaration($2->token);checkVarDeclaration($4->token);}
	
	|IDENT'['NUMBER']' BOOL_SIGN DEREF IDENT {$$=mknode("(",mknode($5->token,N,N,N,N),mknode("",$1,mknode("[",$3,N,N,mknode(")",N,N,N,N)),N,N),mknode("^",$7,N,N,N),mknode(")",N,N,N,N));checkVarDeclaration($1->token);checkVarDeclaration($7->token);}
	
	|DEREF IDENT BOOL_SIGN DEREF IDENT {$$=mknode("(",mknode($3->token,N,N,N,N),mknode("^",$2,N,N,N),mknode("^",$5,N,N,N),mknode(")",N,N,N,N));addAdref("^",0);addBoolSign($3->token);checkVarDeclaration($2->token);
	checkVarDeclaration($5->token);addBoolParam($2->token);addAdref("^",1);addBoolParam($5->token);closeBoolExp();}
	
	|ADDRESS IDENT BOOL_SIGN IDENT {$$=mknode("(",mknode($3->token,N,N,N,N),mknode("&",$2,N,N,N),$4,mknode(")",N,N,N,N));addAdref("&",0);addBoolParam($2->token);checkVarDeclaration($2->token);addBoolSign($3->token);
	checkVarDeclaration($4->token);addBoolParam($4->token);closeBoolExp();}
	
	|ADDRESS IDENT BOOL_SIGN ADDRESS IDENT {$$=mknode("(",mknode($3->token,N,N,N,N),mknode("&",$2,N,N,N),mknode("&",$5,N,N,N),mknode(")",N,N,N,N));addAdref("&",0);addBoolParam($2->token);checkVarDeclaration($2->token);
	addBoolSign($3->token);checkVarDeclaration($5->token);addAdref("&",1);addBoolParam($5->token);closeBoolExp();}
	
	|EXP_CALC BOOL_SIGN DEREF IDENT {$$=mknode("(",mknode($2->token,N,N,N,N),$1,mknode("^",$4,N,N,N),mknode(")",N,N,N,N));
	addBoolSign($2->token);checkVarDeclaration($4->token);addAdref("^",1);addBoolParam($4->token);closeBoolExp();}
	
	|EXP_CALC BOOL_SIGN ADDRESS IDENT {$$=mknode("(",mknode($2->token,N,N,N,N),$1,mknode("&",$4,N,N,N),mknode(")",N,N,N,N));
	addBoolSign($2->token);checkVarDeclaration($4->token);addAdref("&",1);addBoolParam($4->token);closeBoolExp();}
	
	;
ARRAY_BOOL:
	IDENT'['IDENT']' EQ IDENT'['IDENT']' {$$=mknode("(",mknode("==",N,N,N,N),mknode("",$1,mknode("[",$3,N,N,mknode("]",N,N,N,N)),N,N),mknode("",$6,mknode("[",$8,N,N,mknode("]",N,N,N,N)),N,N),mknode(")",N,N,N,N));}

	|IDENT'['IDENT']' NEQ IDENT'['IDENT']' {$$=mknode("(",mknode("!=",N,N,N,N),mknode("",$1,mknode("[",$3,N,N,mknode("]",N,N,N,N)),N,N),mknode("",$6,mknode("[",$8,N,N,mknode("]",N,N,N,N)),N,N),mknode(")",N,N,N,N));}

	|IDENT'['NUMBER']' EQ IDENT'['IDENT']' {$$=mknode("(",mknode("==",N,N,N,N),mknode("",$1,mknode("[",$3,N,N,mknode("]",N,N,N,N)),N,N),mknode("",$6,mknode("[",$8,N,N,mknode("]",N,N,N,N)),N,N),mknode(")",N,N,N,N));}

	|IDENT'['NUMBER']' NEQ IDENT'['IDENT']' {$$=mknode("(",mknode("!=",N,N,N,N),mknode("",$1,mknode("[",$3,N,N,mknode("]",N,N,N,N)),N,N),mknode("",$6,mknode("[",$8,N,N,mknode("]",N,N,N,N)),N,N),mknode(")",N,N,N,N));}

	|IDENT'['IDENT']' EQ IDENT'['NUMBER']' {$$=mknode("(",mknode("==",N,N,N,N),mknode("",$1,mknode("[",$3,N,N,mknode("]",N,N,N,N)),N,N),mknode("",$6,mknode("[",$8,N,N,mknode("]",N,N,N,N)),N,N),mknode(")",N,N,N,N));}

	|IDENT'['IDENT']' NEQ IDENT'['NUMBER']' {$$=mknode("(",mknode("!=",N,N,N,N),mknode("",$1,mknode("[",$3,N,N,mknode("]",N,N,N,N)),N,N),mknode("",$6,mknode("[",$8,N,N,mknode("]",N,N,N,N)),N,N),mknode(")",N,N,N,N));}

	|IDENT'['NUMBER']' EQ IDENT'['NUMBER']' {$$=mknode("(",mknode("==",N,N,N,N),mknode("",$1,mknode("[",$3,N,N,mknode("]",N,N,N,N)),N,N),mknode("",$6,mknode("[",$8,N,N,mknode("]",N,N,N,N)),N,N),mknode(")",N,N,N,N));}

	|IDENT'['NUMBER']' NEQ IDENT'['NUMBER']' {$$=mknode("(",mknode("!=",N,N,N,N),mknode("",$1,mknode("[",$3,N,N,mknode("]",N,N,N,N)),N,N),mknode("",$6,mknode("[",$8,N,N,mknode("]",N,N,N,N)),N,N),mknode(")",N,N,N,N));}

	|IDENT'['IDENT']' EQ CHAR {$$=mknode("(",mknode("==",N,N,N,N),$1,mknode("[",$3,N,N,mknode("]",N,N,N,$6)),mknode(")",N,N,N,N));}
	|IDENT'['IDENT']' NEQ CHAR {$$=mknode("(",mknode("!=",N,N,N,N),$1,mknode("[",$3,N,N,mknode("]",N,N,N,$6)),mknode(")",N,N,N,N));}
	|IDENT'['NUMBER']' EQ CHAR {$$=mknode("(",mknode("==",N,N,N,N),$1,mknode("[",$3,N,N,mknode("]",N,N,N,$6)),mknode(")",N,N,N,N));}
	|IDENT'['NUMBER']' NEQ CHAR {$$=mknode("(",mknode("!=",N,N,N,N),$1,mknode("[",$3,N,N,mknode("]",N,N,N,$6)),mknode(")",N,N,N,N));}
	|CHAR EQ IDENT'['NUMBER']' {$$=mknode("(",mknode("==",N,N,N,N),$1,$3,mknode("[",$5,N,N,mknode("]",N,N,N,mknode(")",N,N,N,N))));}
	|CHAR NEQ IDENT'['NUMBER']'  {$$=mknode("(",mknode("!=",N,N,N,N),$1,$3,mknode("[",$5,N,N,mknode("]",N,N,N,mknode(")",N,N,N,N))));}
	|CHAR EQ IDENT'['IDENT']'  {$$=mknode("(",mknode("==",N,N,N,N),$1,$3,mknode("[",$5,N,N,mknode("]",N,N,N,mknode(")",N,N,N,N))));}
	|CHAR NEQ IDENT'['IDENT']'  {$$=mknode("(",mknode("!=",N,N,N,N),$1,$3,mknode("[",$5,N,N,mknode("]",N,N,N,mknode(")",N,N,N,N))));}
	|IDENT'['IDENT']' EQ IDENT {$$=mknode("(",mknode("==",N,N,N,N),$1,mknode("[",$3,N,N,mknode("]",N,N,N,$6)),mknode(")",N,N,N,N));}
	|IDENT'['IDENT']' NEQ IDENT {$$=mknode("(",mknode("!=",N,N,N,N),$1,mknode("[",$3,N,N,mknode("]",N,N,N,$6)),mknode(")",N,N,N,N));}
	|IDENT'['NUMBER']' EQ IDENT {$$=mknode("(",mknode("==",N,N,N,N),$1,mknode("[",$3,N,N,mknode("]",N,N,N,$6)),mknode(")",N,N,N,N));}
	|IDENT'['NUMBER']' NEQ IDENT {$$=mknode("(",mknode("!=",N,N,N,N),$1,mknode("[",$3,N,N,mknode("]",N,N,N,$6)),mknode(")",N,N,N,N));}
	;
CHAR_BOOL:
	CHAR EQ IDENT {$$=mknode("(",mknode("==",$1,$3,N,N),N,N,mknode(")",N,N,N,N));addBoolParam("char");addBoolSign("==");mkBoolParams2();addBoolParam($3->token);closeBoolExp();checkVarDeclaration($3->token);}
	|CHAR NEQ IDENT {$$=mknode("(",mknode("!=",$1,$3,N,N),N,N,mknode(")",N,N,N,N));addBoolParam("char");addBoolSign("!=");mkBoolParams2();addBoolParam($3->token);closeBoolExp();checkVarDeclaration($3->token);}
	|EXP_CALC EQ CHAR {$$=mknode("(",mknode("==",$1,$3,N,N),N,N,mknode(")",N,N,N,N));addBoolSign("==");mkBoolParams2();addBoolParam("char");closeBoolExp();}
	|EXP_CALC NEQ CHAR {$$=mknode("(",mknode("!=",$1,$3,N,N),N,N,mknode(")",N,N,N,N));addBoolSign("!=");mkBoolParams2();addBoolParam("char");closeBoolExp();}
	;
	
BOOL_REC:
	EXP_CALC  BOOL_SIGN POPBOOL BOOLEAN {$$=mknode("(",$2,$1,$4,mknode(")",N,N,N,N));addAssignSign($2->token);closeBoolExp();}/*new*/
	|BOOLEAN  BOOL_SIGN POPBOOL EXP_CALC{$$=mknode("(",$2,$1,$4,mknode(")",N,N,N,N));addAssignSign($2->token);closeBoolExp();}/*new*/
	|BOOLEAN  BOOL_SIGN POPBOOL BOOLEAN{$$=mknode("(",$2,$1,$4,mknode(")",N,N,N,N));addAssignSign($2->token);closeBoolExp();}/*new*/
	;




INC_DEC:
	 IDENT DEC {$$=mknode("(",mknode("--",N,N,N,N),$1,N,mknode(")",N,N,N,N));checkVarDeclaration($1->token);}
	|IDENT INC {$$=mknode("(",mknode("++",N,N,N,N),$1,N,mknode(")",N,N,N,N));checkVarDeclaration($1->token);}
	;

SIGN: 
	 '+' {$$=mknode("+",N,N,N,N);}
	|'-' {$$=mknode("-",N,N,N,N);}
	|'*' {$$=mknode("*",N,N,N,N);}
	|'/' {$$=mknode("/",N,N,N,N);}
	;
BOOL_SIGN:
	'>' {$$=mknode(">",N,N,N,N);}
	|'<' {$$=mknode("<",N,N,N,N);}
	|EQ {$$=mknode("==",N,N,N,N);}
	|NEQ {$$=mknode("!=",N,N,N,N);}
	|LEQ{$$=mknode("<=",N,N,N,N);}
	|GEQ{$$=mknode(">=",N,N,N,N);}
	;
NOT_SIGN:
	NOT{$$=mknode("!",N,N,N,N);}
	;
LOGIC_SIGN:
	 OR{$$=mknode("||",N,N,N,N);}
	|AND{$$=mknode("&&",N,N,N,N);}
	;

PUSHSCOPE:
	{push($0->token);};
PUSHBLOCK:
	{push("block");};
PUSHWHILE:
	{push("while");};
PUSHFOR:
	{push("for");};
PUSHIF:
	{push("if");};
POP:
	{pop();};

PUSHELSE:{push("else");};

%%
#include "lex.yy.c"

void main(){
	yyparse();


	print_tree(root,0);

	//printAllSymbols();
	//printAssignExp();
	//printBoolExp();
	//printAllFuncAssigns();
	//printAllFuncAssigns();
	//printFuncalls();
	printAddressAndDeref();
	runAllTest();
		

	return; 
}

void yyerror(){
 	printf("Error in line [%d] with token : %s\n",counter,yytext);
	exit(1);
}
