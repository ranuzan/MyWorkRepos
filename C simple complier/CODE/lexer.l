%{
#include <stdlib.h>
#include <stdio.h>
int counter = 1;
int i=0;
%}
%%
'.' {return CHARACTER;}
\".*\" {return VAR_CHARACTER;}
[/][/].*[\n]  {counter++;}
[/][*][^*]*[*]+([^/*][^*][*]+)*[/] {for(i=0;i<strlen(yytext);i++)if(yytext[i]=='\n')counter++;}
(int|char|boolean) {return TYPE;}
(charp|intp) {return PTR_TYPE;}
string {return STRING;}
while {return WHILE;}
for {return FOR;}
do {return DO;}
if {return IF;}
else {return ELSE;}
"return" {return RETURN;}
NULL {return Nullptr;}
void {return VOID;}
(true|false) {return BOOL;}
[A-Za-z][A-Za-z0-9]* {return ID;}
[0-9]+ {return NUM;}
"&&" {return AND;}
"||" {return OR;}
"^" {return DEREF;}
"&" {return ADDRESS;}
"!" {return NOT;}
"==" {return EQ;}
"!=" {return NEQ;}
"<=" {return LEQ;}
">=" {return GEQ;}
"--" {return DEC;}
"++" {return INC;}
\n counter++;
[ \t] printf(" ");
. return yytext[0];
%%
