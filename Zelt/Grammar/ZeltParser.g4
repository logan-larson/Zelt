parser grammar ZeltParser;

options { tokenVocab=ZeltLexer; }


// ---------------------------------------------------------------------------------------------
// ------------------------------------- Program -----------------------------------------------
// ---------------------------------------------------------------------------------------------

program : statement* EOF ;

statement
	: declarationStatement
	| assignmentStatement
	| controlFlowStatement
	//| functionCallStatement
	| printStatement
	| interfaceDeclaration
	| structDeclaration
	//| functionDeclaration
	| returnStatement
	;

// TEMP: I'm going to use this to test how far the parser gets
printStatement : PRINT LEFT_PAREN expression RIGHT_PAREN SEMICOLON ;


// ---------------------------------------------------------------------------------------------
// ------------------------------------- Control Flow ------------------------------------------
// ---------------------------------------------------------------------------------------------

controlFlowStatement
	: ifStatement
	| whileStatement
	| eachStatement
	;

ifStatement: IF expression block (ELSE elseIfStatement)? ;

elseIfStatement
	: ifStatement
	| block
	;

whileStatement : WHILE expression block ;

eachStatement : EACH declarationList IN expressionList block ;

returnStatement
	: RETURN SEMICOLON
	| RETURN expression (COMMA expression)* SEMICOLON
	;


// ---------------------------------------------------------------------------------------------
// ------------------------------------- Declarations ------------------------------------------
// ---------------------------------------------------------------------------------------------

declarationStatement
	: declaration SEMICOLON
	;

declarationList
	: declaration (COMMA declaration)*
	;

declaration
	// x : Int; y, z : Float; a, b : Int, String;
	: identifierList COLON typeList
	; 

function

	// (x : Int, y : Int) => Int { return x + y; }
	: LEFT_PAREN parameterDeclarationList? RIGHT_PAREN DOUBLE_ARROW typeList block

	// Vector2 (v : Vector2) => Vector2 { return Vector2(caller.x + x, caller.y + y); }
	| type LEFT_PAREN parameterDeclarationList? RIGHT_PAREN DOUBLE_ARROW typeList block

	// (x : Int) => Int { return x * x; }
	//| LEFT_PAREN parameterDeclarationList? RIGHT_PAREN DOUBLE_ARROW typeList block
	;

interfaceDeclaration
	// interface Splittable { IType split() => IType, IType; }
	: INTERFACE IDENTIFIER interfaceBlock
	;

structDeclaration
	// struct Vector2 { x : Int; y : Int; }
	: STRUCT IDENTIFIER (COLON identifierList)? structBlock
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

functionSignature
	// add(Int, Int) => Int
	: ITYPE functionIdentifier LEFT_PAREN parameterTypeList? RIGHT_PAREN DOUBLE_ARROW returnTypeList SEMICOLON
	| functionIdentifier LEFT_PAREN parameterTypeList? RIGHT_PAREN DOUBLE_ARROW returnTypeList SEMICOLON
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
	// x : Int = 5; y, z : Float, Int = 3.14, 3;
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

functionCallStatement
	: functionCall SEMICOLON
	;

functionCall
	// add(x, Vector2(), 6)
	: functionIdentifier LEFT_PAREN expressionList? RIGHT_PAREN
	// caller.add(Vector2(1, 2))
	| CALLER PERIOD functionIdentifier LEFT_PAREN expressionList? RIGHT_PAREN
	// myVector2.add(Vector2(1, 2))
	| IDENTIFIER PERIOD functionIdentifier LEFT_PAREN expressionList? RIGHT_PAREN
	;

expressionList
	: expression (COMMA expression)*
	;

expression

	// 5, 3.14, "Hello, World!", true, false, null
	: literal									#literalExpression

	// [1, 2, 3, 4, 5], [1..10], [1..10, 2], [1, 2..10]
	| list										#listExpression

	// myVector2.x, _window.length, caller.y
	| accessor									#accessorExpression

	// x, y, z, _a, _b, _c
	| IDENTIFIER								#identifierExpression

	// (x : Int) => Int { return x * x; }, Int (y : Int) => Int { return caller + y; }
	| function									#functionExpression

	// add(x, Vector2(), 6) -- Vector2() is a function call to the Vector2 'constructor'
	| functionCall								#functionCallExpression

	// ( x + ( y + z ) )
	| LEFT_PAREN expression RIGHT_PAREN			#parenExpression

	// ! x == y
	| NOT expression							#notExpression

	// x * y, x / y, x % y
	| expression multOp expression				#multExpression

	// x + y, x - y
	| expression addOp expression				#addExpression

	// x < y, x <= y, x > y, x >= y, x == y, x != y
	| expression relOp expression				#relationalExpression

	// x && y, x || y
	| expression boolOp expression				#logicalExpression

	// _  -- underscore discards the value of the expression
	| UNDERSCORE								#underscoreExpression
	;


// ---------------------------------------------------------------------------------------------
// --------------------------------------- Types -----------------------------------------------
// ---------------------------------------------------------------------------------------------

typeList
	// Int, Float, [Int], (Int, Int) => Int, Int (Int) => Int
	: type (COMMA type)*
	;

parameterTypeList
	// Int, Float or nothing (no parameters)
	: (type (COMMA type)*)?
	;

returnTypeList
	// Int, Float
	: type (COMMA type)*
	;

type
	// String (Int, Int) => Int, Int -- function type with a caller type
	: functionCallerType

	// (Int, Int) => Int, Int -- function type without a caller type
	| functionType

	// [Int] -- list type
	| listType

	// IType -- interface type used for getting the type that implements the interface
	| ITYPE

	// Int -- type
	| IDENTIFIER
	;

callerType
	: IDENTIFIER
	;

functionCallerType
	// String (Int, Int) => Int, Int -- function type with a caller type
	// What happens if the IDENTIFIER is a type??
	: callerType LEFT_PAREN parameterTypeList RIGHT_PAREN DOUBLE_ARROW returnTypeList
	;

functionType
	// (Int, Int) => Int, Int -- function type without a caller type
	: LEFT_PAREN parameterTypeList RIGHT_PAREN DOUBLE_ARROW returnTypeList
	;

listType
	// [Int] -- list type
	: LEFT_BRACKET type RIGHT_BRACKET
	;


// ---------------------------------------------------------------------------------------------
// ------------------------------------- Literals ----------------------------------------------
// ---------------------------------------------------------------------------------------------

identifierList
	// x, _y, z123, R2D2
	: IDENTIFIER (COMMA IDENTIFIER)*
	;

literal
	// 5, 3.14, "Hello, World!", true, false, null
	: INTEGER
	| FLOAT
	| STRING
	| BOOL
	| NULL
	;

list
	// [1, 2, 3, 4, 5], [1..10], [10..5, 2], [3..5, 1, 2..7]
	: LEFT_BRACKET (listElement (COMMA listElement)*)? RIGHT_BRACKET
	;

listElement
	: expression
	// 1..5, 10..5 => [1, 2, 3, 4, 5], [10, 9, 8, 7, 6, 5]
	| expression DOUBLE_PERIOD expression
	;

functionIdentifier
	// add, render
	: IDENTIFIER
	;

// ---------------------------------------------------------------------------------------------
// -------------------------------------- Blocks -----------------------------------------------
// ---------------------------------------------------------------------------------------------

block 
	// { x := 5; y := 3.14; }
	: LEFT_BRACE statement* RIGHT_BRACE;

interfaceBlock
	// { IType add(IType x) => IType; IType square() => IType; retString() => String }
	: LEFT_BRACE functionSignature* RIGHT_BRACE
	;

structBlock
	// { x :: Int; y :: Float; }
	: LEFT_BRACE (declarationStatement | inferAssignment SEMICOLON | assignment SEMICOLON )* RIGHT_BRACE
	;


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
	// +, -
	: PLUS
	| MINUS
	;

multOp
	// *, /, %
	: MULTIPLY
	| DIVIDE
	| MODULO
	;

relOp
	// <, >, <=, >=, ==, !=
	: LESS_THAN
	| GREATER_THAN
	| LESS_THAN_OR_EQUAL
	| GREATER_THAN_OR_EQUAL
	| EQUALS
	| NOT_EQUALS
	;

boolOp
	// &&, ||
	: AND
	| OR
	;




