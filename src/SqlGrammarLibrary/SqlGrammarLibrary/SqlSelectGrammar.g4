grammar SqlSelectGrammar;

/*
 * Parser Rules
 */
query_specification  
	: SELECT (distinct)? query_expression (COMMA query_expression)*
	;

query_expression 
	: expression (AS rename)?
	;

rename
	: NAME
	;

// TODO: В специфицации степени нет, убрать?
expression
	: expression POW expression
	| expression (MULTIPLICATION | DIV) expression
	| expression (PLUS | MINUS) expression
	| LPAREN expression RPAREN
	| expression compare expression
	| simple_expression
	;

compare
   : EQ
   | NEQ
   | GT
   | LT
   ;

simple_expression
	: literal
	| column_name_expression
	;

column_name_expression 
	: ( table_name POINT )? column_name
	;

table_name
	: NAME
	;

column_name
	: NAME
	;

literal
	: number 
	| character_string
	| binary_string
	| date_and_time_notation
	;

number
	: int_number
	| float_number
	| exponential_number
	;

exponential_number
	: EXP_NUMBER
	;


float_number
	: FLOAT
	;

int_number
	: INT
	;


character_string
	: CHARACTER_STRING
	;

// TODO: binary_string and date_and_time_notation
binary_string
	:
	;

date_and_time_notation
	:
	;


distinct 
	: ALL | DISTINCT
	;


/*
 * Lexer Rules
 */
fragment A          : ('A'|'a') ;
fragment B          : ('B'|'b') ;
fragment C          : ('C'|'c') ;
fragment D          : ('D'|'d') ;
fragment E          : ('E'|'e') ;
fragment F          : ('F'|'f') ;
fragment G          : ('G'|'g') ;
fragment H          : ('H'|'h') ;
fragment I          : ('I'|'i') ;
fragment J          : ('J'|'j') ;
fragment K          : ('K'|'k') ;
fragment L          : ('L'|'l') ;
fragment M          : ('M'|'m') ;
fragment N          : ('N'|'n') ;
fragment O          : ('O'|'o') ;
fragment P          : ('P'|'p') ;
fragment Q          : ('Q'|'q') ;
fragment R          : ('R'|'r') ;
fragment S          : ('S'|'s') ;
fragment T          : ('T'|'t') ;
fragment U          : ('U'|'u') ;
fragment V          : ('V'|'v') ;
fragment W          : ('W'|'w') ;
fragment X          : ('X'|'x') ;
fragment Y          : ('Y'|'y') ;
fragment Z          : ('Z'|'z') ;

// no leading zeros
fragment EXP
	: [Ee] [+\-]? INT 
	;

// This is tokens
LPAREN
   : '('
   ;


RPAREN
   : ')'
   ;


PLUS
   : '+'
   ;


MINUS
   : '-'
   ;


MULTIPLICATION
   : '*'
   ;


DIV
   : '/'
   ;


POW
   : '^'
   ;

GT
   : '>'
   ;


LT
   : '<'
   ;

EQ
   : '='
   ;

NEQ
	: '!' '='
   ;

COMMA
	: ','
	;

POINT
	: '.'
	;

// This is keywords
ALL 
	: A L L ;

AS 
	: A S ;

DISTINCT 
	: D I S T I N C T ;

SELECT 
	: S E L E C T
	;

END 
	: E N D 
	;
// end keywords


EXP_NUMBER
	: (FLOAT | INT) EXP
	;

FLOAT
	: INT '.' [0-9]+ 
	;

INT
	: '0' | [1-9] [0-9]*
	;

NAME
	: [a-zA-Z] [a-zA-Z0-9_]* 
	;

// TODO: replace " -> '
// А еще нужно как-то предусмотреть ввод в строке символа ' 
// (его нужно ввести дважды, чтобы юзать в sql)
CHARACTER_STRING 
	: '"' .*? '"'
	;

WHITESPACE          : (' '|'t')+ -> skip ; // WS  : [ \t\r\n]+ -> skip ;
NEWLINE             : ('r'? 'n' | 'r')+ ;