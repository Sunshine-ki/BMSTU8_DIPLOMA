grammar SqlSelectGrammar;

/*
 * Parser Rules
 */
query_specification  
	: SELECT (distinct)? query_expression (COMMA query_expression)*
	;

query_expression 
	: equation
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

equation
   : expression (relop expression)*
   ;

expression
	: expression POW expression
	| expression (MULTIPLICATION | DIV) expression
	| expression (PLUS | MINUS) expression
	| LPAREN expression RPAREN
	| simple_expression
	;

simple_expression
	: literal
	;

literal
	: NUMBER | CHARACTER_STRING
	;

distinct 
	: ALL | DISTINCT
	;

relop
   : EQ
   | NQ
   | GT
   | LT
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

fragment INT
	: '0' | [1-9] [0-9]*
	;

// no leading zeros
fragment EXP
	: [Ee] [+\-]? INT 
	;

// This is tokens

// TODO: 
//fragment SIGN
//   : ('+' | '-')
//   ;

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

NQ
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

DISTINCT 
	: D I S T I N C T ;

SELECT 
	: S E L E C T
	;

END 
	: E N D 
	;
// end keywords

// TODO: Is it working?
NUMBER 
	: ('-' | '+')? (INT '.' [0-9] + EXP? | INT EXP | INT) 
	;

//NUMBER
//	: '-'? INT '.' [0-9] + EXP? 
//	| '-'? INT EXP 
//	| '-'? INT
//	;

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