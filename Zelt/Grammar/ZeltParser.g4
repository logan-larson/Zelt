parser grammar ZeltParser;

options { tokenVocab=ZeltLexer; }

// Parser rules

program : line* EOF ;

line 
	: statement
	//| ifStatement
	//| whileStatement
	;

statement
	: declarationStatement
	| assignmentStatement
	//| functionCall
	//| functionDeclaration
	//| returnStatement
	| printStatement
	;

// TEMP: I'm going to use this to test how far the parser gets
printStatement : PRINT LEFT_PAREN expression RIGHT_PAREN SEMICOLON ;

ifStatement: IF expression block (ELSE elseIfStatement)? ;

elseIfStatement
	: ifStatement
	| block
	;

whileStatement : WHILE expression block ;

returnStatement
	: RETURN expression SEMICOLON
	| RETURN SEMICOLON
	| RETURN expression (COMMA expression)* SEMICOLON
	| RETURN assignment (COMMA assignment)* SEMICOLON
	;

declarationStatement
	: declaration SEMICOLON
	;

declaration
	// x : Int; y, z : Float;
	: identifierList COLON type
	// x : Int = 5; y, z : Float = 3.14;
	| identifierList COLON type IS_DEFINED_AS expression
	// z := 5; y, z := 3.14;
	| identifierList COLON IS_DEFINED_AS expression
	; 

functionCall : IDENTIFIER LEFT_PAREN (expression (COMMA expression)*)? RIGHT_PAREN ;

// TODO: Add support for multiple return values
// Eventually, I want to be able to do something like this:
// add(x : Int, y : Int) -> Int, Int { return x + y, x - y; }
// TODO: Add support for default values
// TODO: Change type to be a list of IDENTIFIERs
functionDeclaration
	// add(x : Int, y : Int) -> Int { return x + y; }
	: IDENTIFIER LEFT_PAREN parameterList? RIGHT_PAREN ARROW returnTypeList block
	// Vector2 add(v : Vector2) -> Vector2 { return Vector2(caller.x + x, caller.y + y); }
	| IDENTIFIER IDENTIFIER LEFT_PAREN parameterList? RIGHT_PAREN ARROW returnTypeList block
	// (x : Int) -> Int { return x * x; }
	| LEFT_PAREN parameterList? RIGHT_PAREN ARROW returnTypeList block
	;

parameterList
	: parameter (COMMA parameter)*
	;

parameter
	: IDENTIFIER COLON IDENTIFIER
	| IDENTIFIER COLON IDENTIFIER IS_DEFINED_AS expression
	| IDENTIFIER COLON IS_DEFINED_AS expression
	;

returnTypeList
	: IDENTIFIER (COMMA IDENTIFIER)*
	;

assignmentStatement
	: assignment SEMICOLON
	;

assignment
	: IDENTIFIER IS_DEFINED_AS expression
	;

expression
	: literal									#literalExpression
	| accessor									#identifierExpression
	| functionCall								#functionCallExpression
	| LEFT_PAREN expression RIGHT_PAREN			#parenExpression
	| NOT expression							#notExpression
	| expression multOp expression				#multExpression
	| expression addOp expression				#addExpression
	| expression relOp expression				#relationalExpression
	| expression boolOp expression				#boolOpExpression
	| CALLER PERIOD IDENTIFIER					#callerExpression
	;

typeList
	: type (COMMA type)*
	;

type
	// String (Int, Int) -> Int, Int -- function type with a caller type
	: type LEFT_PAREN typeList RIGHT_PAREN ARROW typeList
	// (Int, Int) -> Int, Int -- function type without a caller type
	| LEFT_PAREN typeList RIGHT_PAREN ARROW typeList
	// [Int] -- array type
	| LEFT_BRACKET type RIGHT_BRACKET
	// [Int -> String] -- dictionary type
	| LEFT_BRACKET type ARROW type RIGHT_BRACKET
	// Int -- type
	| IDENTIFIER
	;

identifierList
	: IDENTIFIER (COMMA IDENTIFIER)*
	;

accessor
	// boxDimensions.x -- used for accessing the properties of a variable that is a struct
	: IDENTIFIER PERIOD IDENTIFIER
	// caller.x -- used for accessing the caller's properties in a function
	| CALLER PERIOD IDENTIFIER
	;

literal
	: INTEGER
	| FLOAT
	| STRING
	| BOOL
	| NULL
	;

block : LEFT_BRACE line* RIGHT_BRACE;

// Types are just identifiers that I'm going to check against a list of known types
// So these are temporary
/*
type
	: INT_TYPE
	| FLOAT_TYPE
	| STRING_TYPE
	| BOOL_TYPE
	| FUNCTION_TYPE
	;
*/

addOp
	: PLUS
	| MINUS
	;

multOp
	: MULTIPLY
	| DIVIDE
	| MODULO
	;

relOp
	: LESS_THAN
	| GREATER_THAN
	| LESS_THAN_OR_EQUAL
	| GREATER_THAN_OR_EQUAL
	| EQUALS
	| NOT_EQUALS
	;

boolOp
	: AND
	| OR
	;




