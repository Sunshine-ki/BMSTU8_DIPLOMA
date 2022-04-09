grammar SqlSelectGrammar;

/*
 * Parser Rules
 */
query_specification  
	: SELECT (distinct)? query_expression (COMMA query_expression)*
	  FROM generalized_table_specification 
	;

query_expression 
	: (all_data | expression | subquery) (AS rename)?
	;

subquery 
	: LPAREN query_specification RPAREN
	;

all_data
	: '*'
	;

rename
	: NAME
	;

expression
	: expression POW expression
	| LPAREN expression RPAREN
	| expression (MULTIPLICATION | DIV) expression
	| expression (PLUS | MINUS) expression
	| aggregate_function LPAREN simple_expression RPAREN
	| case_expression
	| simple_expression
	;


aggregate_function
	: COUNT | SUM | AVG | MIN | MAX 
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
	| binary_string
	| time_notation
	| character_string
	;

binary_string
	: x_binary_strings
	| b_binary_strings
	;
	

x_binary_strings
	: X_STRING 
	;

b_binary_strings
	: B_STRING 
	;

case_expression 
	: simple_case 
	//| conditional_case
	;

simple_case
	: 
	CASE expression 
		(WHEN expression THEN expression)+  
		(ELSE expression)? 
	END
	;

//conditional_case ::= CASE { WHEN condition THEN expression3 } [ ELSE expression4 ] END

time_notation
	: TIME
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


distinct 
	: ALL | DISTINCT
	;

generalized_table_specification
	: generalized_table ( AS rename )?
	;

generalized_table
	: table_identifier ( index_specification )?
	// TODO:
	//| LPAREN query_expression RPAREN 
	| generalized_table join_type generalized_table ( join_specification )? // #Join 
	;

join_type
	: CROSS JOIN
	| (NATURAL)? ( INNER | ((LEFT | RIGHT | FULL ) ( OUTER )?) )? JOIN
	;

table_identifier
	: NAME
	;

index_specification
	: INDEX idx
	;

idx
	: NAME
	;

join_specification
	//: ON condition
	| USING column_name ( COMMA column_name)*
	;

c/*ondition
	:
	;*/

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

ON 
	: O N ;
 
AS 
	: A S ;

ALL 
	: A L L ;

CASE 
	: C A S E ; 

WHEN 
	: W H E N ;

THEN 
	: T H E N ;

ELSE 
	: E L S E ;

END 
	: E N D 
	;

MAX 
	: M A X
	;

MIN
	: M I N
	;

AVG 
	: A V G
	;

SUM
	: S U M
	;

USING
	: U S I N G
	;

INDEX
	: I N D E X 
	;

CROSS 
	: C R O S S
	;

JOIN
	: J O I N
	;

COUNT 
	: C O U N T
	;

FROM
	: F R O M
	;

DISTINCT 
	: D I S T I N C T ;

SELECT 
	: S E L E C T
	;

NATURAL
	: N A T U R A L
	;

INNER
	: I N N E R
	;

LEFT
	: L E F T
	;

RIGHT
	: R I G H T
	;

FULL
	: F U L L
	;

OUTER
	: O U T E R
	;
// end keywords


X_STRING
	: X '\'' [0-9A-F]+  '\''
	;

B_STRING
	: B '\'' ('0' | '1')+  '\''
	;

TIME
	: 
	'\'' 
		([0-9] | '1'[0-9] | '2'[0-3]) ':' // H
		([0-9] | [0-5][0-9]) ':'		  // M
		([0-9][0-9]?)					  // S
	'\''
	;

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

// А еще нужно как-то предусмотреть ввод в строке символа ' 
// (его нужно ввести дважды, чтобы юзать в sql)
CHARACTER_STRING 
	: '\'' .*? '\''
	;

WHITESPACE          : (' '|'t')+ -> skip ; // WS  : [ \t\r\n]+ -> skip ;
NEWLINE             : ('r'? 'n' | 'r')+ ;