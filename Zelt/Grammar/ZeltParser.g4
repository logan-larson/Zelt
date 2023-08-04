parser grammar ZeltParser;

options { tokenVocab=ZeltLexer; }


// ---------------------------------------------------------------------------------------------
// ------------------------------------- Program -----------------------------------------------
// ---------------------------------------------------------------------------------------------

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


// ---------------------------------------------------------------------------------------------
// ------------------------------------- Control Flow ------------------------------------------
// ---------------------------------------------------------------------------------------------

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


// ---------------------------------------------------------------------------------------------
// ------------------------------------- Declarations ------------------------------------------
// ---------------------------------------------------------------------------------------------

declarationStatement
	: declaration SEMICOLON
	;

declaration
	// x : Int; y, z : Float; a, b : Int, String;
	: identifierList COLON typeList
	; 

// TODO: Add support for multiple return values
// Eventually, I want to be able to do something like this:

// add(x : Int, y : Int) -> Int, Int { return x + y, x - y; }
functionDeclaration

	// add(x : Int, y : Int) -> Int { return x + y; }
	: IDENTIFIER LEFT_PAREN parameterDeclarationList? RIGHT_PAREN ARROW typeList block

	// Vector2 add(v : Vector2) -> Vector2 { return Vector2(caller.x + x, caller.y + y); }
	| type IDENTIFIER LEFT_PAREN parameterDeclarationList? RIGHT_PAREN ARROW typeList block

	// (x : Int) -> Int { return x * x; }
	| LEFT_PAREN parameterDeclarationList? RIGHT_PAREN ARROW typeList block
	;

parameterDeclarationList
	: parameterDeclaration (COMMA parameterDeclaration)*
	;

parameterDeclaration
	// x : Int
	: declaration
	// x : Int = 5
	| assignment
	// x := 5
	| inferAssignment
	;


// ---------------------------------------------------------------------------------------------
// ------------------------------------- Assignments -------------------------------------------
// ---------------------------------------------------------------------------------------------

assignmentStatement
	: assignment SEMICOLON
	| inferAssignment SEMICOLON
	| simpleAssignment SEMICOLON
	;

assignment
	// x : Int = 5; y, z : Float = 3.14;
	: identifierList COLON typeList IS_DEFINED_AS expressionList
	;

inferAssignment
	// z := 5; y, z := 3.14, 3;
	: identifierList COLON IS_DEFINED_AS expressionList
	;

simpleAssignment
	// z = 5; y, z = 3.14, 3;
	: identifierList IS_DEFINED_AS expressionList
	;


// ---------------------------------------------------------------------------------------------
// ------------------------------------- Expressions -------------------------------------------
// ---------------------------------------------------------------------------------------------

functionCall
	// add(x, y := 5, 6)
	: IDENTIFIER LEFT_PAREN expressionList? RIGHT_PAREN
	// myVector2.add(v : Vector2 = Vector2(1, 2))
	| IDENTIFIER PERIOD IDENTIFIER LEFT_PAREN expressionList? RIGHT_PAREN
	;

expressionList
	: expression (COMMA expression)*
	| expression (COMMA expression)* COMMA ELLIPSIS
	;

expression
	: literal									#literalExpression
	| accessor									#accessorExpression
	| functionCall								#functionCallExpression
	| assignment								#assignmentExpression
	| LEFT_PAREN expression RIGHT_PAREN			#parenExpression
	| NOT expression							#notExpression
	| expression multOp expression				#multExpression
	| expression addOp expression				#addExpression
	| expression relOp expression				#relationalExpression
	| expression boolOp expression				#boolOpExpression
	| CALLER PERIOD IDENTIFIER					#callerExpression
	| UNDERSCORE								#underscoreExpression
	;


// ---------------------------------------------------------------------------------------------
// --------------------------------------- Types -----------------------------------------------
// ---------------------------------------------------------------------------------------------

typeList
	: type (COMMA type)*
	| type (COMMA type)* COMMA ELLIPSIS
	;

parameterTypeList
	: (type (COMMA type)*)?
	;

returnTypeList
	: type (COMMA type)*
	;

type
	// String (Int, Int) -> Int, Int -- function type with a caller type
	: type LEFT_PAREN parameterTypeList RIGHT_PAREN ARROW returnTypeList
	// (Int, Int) -> Int, Int -- function type without a caller type
	| LEFT_PAREN parameterTypeList RIGHT_PAREN ARROW returnTypeList
	// [Int] -- array type
	| LEFT_BRACKET type RIGHT_BRACKET
	// [Int -> String] -- dictionary type
	| LEFT_BRACKET type ARROW type RIGHT_BRACKET
	// Int -- type
	| IDENTIFIER
	;


// ---------------------------------------------------------------------------------------------
// ------------------------------------- Literals ----------------------------------------------
// ---------------------------------------------------------------------------------------------

identifierList
	: IDENTIFIER (COMMA IDENTIFIER)*
	;

literal
	: INTEGER
	| FLOAT
	| STRING
	| BOOL
	| NULL
	;


// ---------------------------------------------------------------------------------------------
// -------------------------------------- Blocks -----------------------------------------------
// ---------------------------------------------------------------------------------------------

block : LEFT_BRACE line* RIGHT_BRACE;


// ---------------------------------------------------------------------------------------------
// ------------------------------------- Operators ---------------------------------------------
// ---------------------------------------------------------------------------------------------

accessor
	// boxDimensions.x -- used for accessing the properties of a variable that is a struct
	: IDENTIFIER PERIOD IDENTIFIER
	// caller.x -- used for accessing the caller's properties in a function
	| CALLER PERIOD IDENTIFIER
	;

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




