lexer grammar ZeltLexer;


// -- Literals --

INTEGER : [0-9]+;
FLOAT : [0-9]+ '.' [0-9]+;
STRING : '"' .*? '"';
BOOL : 'true' | 'false';
NULL : 'null';

// -- Comments --

COMMENT : '//' .*? '\n' -> skip;

MULTILINE_COMMENT
	: '/*' -> pushMode(COMMENT_MODE), skip
	;

WS : [ \t\r\n]+ -> skip;

// -- Keywords --

// Types
// TODO: these will eventually be handled by the compiler as a type system using IDENTIFIERs

//INT_TYPE : 'Int';
//FLOAT_TYPE : 'Float';
//STRING_TYPE : 'String';
//BOOL_TYPE : 'Bool';
//FUNC: 'Func'; // I think I need this to be a keyword for now
PRINT: 'print';

// Declarations

STRUCT : 'struct';
INTERFACE : 'interface';
// ENUM : 'enum'; Don't know if we'll have enums yet

// Control flow
IF : 'if';
ELSE : 'else';
WHILE : 'while';

// Misc
CALLER : 'caller';
RETURN : 'return';
// BREAK : 'break';
// CONTINUE : 'continue';



// -- Common Characters --

SEMICOLON : ';';
COMMA : ',';
LEFT_BRACE : '{';
RIGHT_BRACE : '}';
LEFT_PAREN : '(';
RIGHT_PAREN : ')';
LEFT_BRACKET : '[';
RIGHT_BRACKET : ']';
QUESTION_MARK : '?';
PERIOD : '.';
COLON : ':';
ARROW : '->';

// -- Operators --

// Arithmetic Operators

PLUS : '+';
MINUS : '-';
MULTIPLY : '*';
DIVIDE : '/';
MODULO : '%';

// Logical operators

NOT : '!';
AND : '&&';
OR : '||';

// Relational operators

EQUALS : '==';
NOT_EQUALS : '!=';
LESS_THAN : '<';
LESS_THAN_OR_EQUAL : '<=';
GREATER_THAN : '>';
GREATER_THAN_OR_EQUAL : '>=';

// Assignment operator

IS_DEFINED_AS : '='; 


// -- Identifiers --

IDENTIFIER : [_]?[a-zA-Z][a-zA-Z0-9_]*;


// -- Comments continued --
mode COMMENT_MODE;

	CLOSE_COMMENT
	: '*/' -> popMode, skip
	;

	NESTED_COMMENT
	: '/*' -> pushMode(COMMENT_MODE), skip
	;

	ANY_OTHER
	: . -> skip
	;
