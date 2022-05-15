grammar SqlGrammar;

/*
 * Parser Rules
 */

query
	: query_expression
	;

query_expression 
	: query_term 
	| query_expression connect ( corresponding )? query_term
	;

query_term 
	: query_specification ( sorting )? ( selection )?
	;

connect
	: ( UNION | EXCEPT ) ( ALL )?
	;

corresponding 
	: CORRESPONDING ( BY column_name (COMMA column_name)* )?
	;

sorting
	: ORDER BY expression (ASC | DESC)? ( COMMA expression (ASC | DESC)? )*
	;

selection
	:  limit_num ( offset_num )?
	;

limit_num 
	: LIMIT ( int_number | ALL )
	;

offset_num
	: OFFSET int_number
	;

query_specification
	: SELECT (distinct)? qexpr (COMMA qexpr)*
	  FROM generalized_table_specification 
	  ( WHERE where_condition )?
	  ( GROUP BY expression_group )?
	  ( HAVING having_condition )?
	;

where_condition 
	: condition
	;

expression_group 
	: column_name_expression (COMMA column_name_expression)*
	;

having_condition
	: condition
	;

qexpr 
	: (all_data | expression | subquery) (AS rename)?
	;

subquery 
	: LPAREN query_expression RPAREN // TODO: Do you need to change to query_specification ?
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
	//| conditional_case // TODO?
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
	: generalized_table 
	;

generalized_table
	: table_identifier ( index_specification )? ( AS rename )?
	| LPAREN query_expression RPAREN 
	| generalized_table ( AS rename )? join_type generalized_table ( AS rename )? ( join_specification )? // #Join 
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
	: ON condition
	| USING column_name ( COMMA column_name)*
	;

condition
	: boolean_factor (OR boolean_factor)*
	;

boolean_factor
	: boolean_expression (AND boolean_expression)*
	;

boolean_expression 
	:( inversion )? predicate
	;

inversion
	: NOT
	;

predicate 
	: expression relational_operator expression 
	| is_predicate	
	| generalized_comparison
	| between_predicate
	| in_predicate
	| exists_predicate
	| unique_predicate
	| like_predicate
	| is_null_predicate
	| LPAREN condition RPAREN
	;

is_predicate 
	: expression IS ( inversion )? stage
	;

generalized_comparison
	: expression relational_operator quantifier subquery
	;

between_predicate
	: expression ( NOT )? BETWEEN expression AND expression
	;

in_predicate
	: expression ( NOT )? IN 
	( ( LPAREN expression ( COMMA expression )*  RPAREN ) | subquery )
	;

exists_predicate
	: EXISTS subquery
	;

unique_predicate
	: UNIQUE subquery
	;

like_predicate
	: expression ( NOT )? LIKE expression ( ESCAPE expression )?
	;

is_null_predicate 
	: expression IS ( inversion )? NULL
	;

stage
	: TRUE | FALSE | UNKNOWN // TRUE reads only in caps
	;

relational_operator 
	: GT | LT | EQ | NOTEQ | LEQT |GEQT
	;

quantifier 
	: SOME | ANY | ALL
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

GEQT
   : '>' '='
   ;


LEQT
   : '<' '='
   ;

NEQ
	: '!' '='
   ;

NOTEQ
	: '<' '>'
	;

COMMA
	: ','
	;

POINT
	: '.'
	;


// This is keywords

IS
	: I S ;

IN
	: I N ;

BY 
	: B Y ;

ON 
	: O N ;

OR
	: O R ;

NOT
	: N O T ;

AND 
	: A N D ;

AS 
	: A S ;

ALL 
	: A L L ;


ASC 
	: A S C ;

ANY
	: A N Y
	;

SOME 
	: S O M E
	;

NULL
	: N U L L
	;

LIKE
	: L I K E
	;

DESC 
	: D E S C ; 

ORDER 
	: O R D E R
	;

UNION 
	: U N I O N
	;

LIMIT
	: L I M I T
	;

OFFSET
	: O F F S E T
	;

EXCEPT 
	: E X C E P T
	;

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

TRUE 
	: T R U E 
	;

FALSE
	: F A L S E
	;

UNKNOWN 
	: U N K N O W N
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

EXISTS
	: E X I S T S
	;

UNIQUE
	: U N I Q U E
	;

BETWEEN
	: B E T W E E N
	;

DISTINCT 
	: D I S T I N C T ;

SELECT 
	: S E L E C T
	;

ESCAPE
	: E S C A P E
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

WHERE
	: W H E R E
	;

HAVING
	: H A V I N G
	;

GROUP
	: G R O U P
	;

OUTER
	: O U T E R
	;

CORRESPONDING
	: C O R R E S P O N D I N G
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

// À åùå íóæíî êàê-òî ïðåäóñìîòðåòü ââîä â ñòðîêå ñèìâîëà ' 
// (åãî íóæíî ââåñòè äâàæäû, ÷òîáû þçàòü â sql)
CHARACTER_STRING 
	: '\'' .*? '\''
	;

WHITESPACE          : (' '|'t')+ -> skip ; // WS  : [ \t\r\n]+ -> skip ;
NEWLINE             : ('r'? 'n' | 'r')+ ;