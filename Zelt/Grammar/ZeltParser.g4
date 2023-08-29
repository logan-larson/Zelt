parser grammar ZeltParser;

options { tokenVocab=ZeltLexer; }


// ------------------------------------------------------------------------------------------
// ---------------------------------------- Program -----------------------------------------
// ------------------------------------------------------------------------------------------

program : statement* EOF ;

statement
    : expression SEMICOLON
	| printStatement // TEMP
	;

// TEMP: I'm going to use this to test how far the parser gets
// Eventually print() will be mapped to a standard library function or something like that
printStatement : PRINT LEFT_PAREN expression RIGHT_PAREN SEMICOLON ;


// ------------------------------------------------------------------------------------------
// ------------------------------------- Statements -----------------------------------------
// ------------------------------------------------------------------------------------------

// EVERYTHING IS AN EXPRESSION, LITERALLY EVERYTHING!!! NO STATEMENTS ALLOWED


// ------------------------------------------------------------------------------------------
// ------------------------------------ Expressions -----------------------------------------
// ------------------------------------------------------------------------------------------

expressionList
	: expression (COMMA expression)*
	;

expression
	: primaryExpression expressionTail*
	| logicalExpression
	;

// ------------------------------------- Precedence -----------------------------------------

// x && y, x || y
logicalExpression
	: relationalExpression (boolOp relationalExpression)*
	;

// x < y, x <= y, x > y, x >= y, x == y, x != y
relationalExpression
	: addExpression (relOp addExpression)*
	;

// x + y, x - y
addExpression
	: multExpression (addOp multExpression)*
	;

// x * y, x / y, x % y
multExpression
	: unaryExpression (multOp unaryExpression)*
	;

// ! x == y
unaryExpression
	: primaryExpression
	| NOT expression
	;

// --------------------------------------- Primary ------------------------------------------

primaryExpression
	: literal								#literalExpression // 5, 3.14, "Hello, World!", true, false, null
	| list									#listExpression // [1, 2, 3, 4, 5], [1..10], [1..10, 2], [1, 2..10]
	| dictionary						    #dictionaryExpression
	| CALLER								#callerExpression // caller
	| IDENTIFIER							#identifierExpression // x, y, z, _a, _b, _c
	| functionDefintion					    #functionDefintionExpression // (x : Int) => Int { return x * x; }, Int (y : Int) => Int { return caller + y; }
	| functionCall                          #functionCallExpression // add(x, Vector2(), 6)n
	| structDefinition						#structDefinitionExpression // struct <implements Interface List> { x : Int; y : Int; }
	| structConstructor						#structConstructorExpression // Vector2(5, 6)
    | declaration                           #declarationExpression
    | assignment                            #assignmentExpression
    | inferAssignment                       #inferAssignmentExpression
    | simpleAssignment                      #simpleAssignmentExpression
    | if                                    #ifExpression
    | while                                 #whileExpression
    | each                                  #eachExpression
    | jump                                  #jumpExpression
	| LEFT_PAREN expression RIGHT_PAREN		#parenExpression // ( x + ( y + z ) )
	;

expressionTail
    // .add(Vector2(1, 1));     function concatination??
	//: PERIOD functionIdentifier LEFT_PAREN expressionList? RIGHT_PAREN
	: PERIOD functionCall
    // .x;                      property accessor??
	| PERIOD IDENTIFIER
	;

// --------------------------------- Function Expressions -----------------------------------

// TODO: Can I rename this to functionCall and apply it to the expressionTail above
// add(x, Vector2(), 6)
functionCall
	: functionIdentifier LEFT_PAREN expressionList? RIGHT_PAREN
	;

functionDefintion

	// function no caller type
	// (x : Int, y : Int) => Int { return x + y; }
	: LEFT_PAREN parameterDeclarationList? RIGHT_PAREN DOUBLE_ARROW typeList block

	// function with caller type
	// Vector2 (v : Vector2) => Vector2 { return Vector2(caller.x + x, caller.y + y); }
	| type LEFT_PAREN parameterDeclarationList? RIGHT_PAREN DOUBLE_ARROW typeList block
	;

parameterDeclarationList
	: parameterDeclaration (COMMA parameterDeclaration)*
	;

// Does not include simpleAssignment because the identifier needs to be declared for a function definition
parameterDeclaration
	// x : Int
	: declaration
    // Default parameter values
	// x : Int = 5
	| assignment
	// x := 5
	| inferAssignment
	;

// ----------------------------------- Struct Expressions -----------------------------------

// struct <implements Interface List> { x : Int; y : Int; }
structDefinition
	: STRUCT (IMPLEMENTS typeList)? structBlock
	;

// |Vector2|(5, 6)
structConstructor
	: PIPE IDENTIFIER PIPE LEFT_PAREN expressionList? RIGHT_PAREN
	;


// -------------------------------- Declaration Expressions ---------------------------------

declarationList
	: declaration(COMMA declaration)*
	;

declaration
	// x : Int; y, z : Float; a, b : Int, String; myStruct : Struct(Vector2, Int);
	: identifierList COLON typeList
	; 


// --------------------------------- Assignment Expressions ---------------------------------

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

// -------------------------------- Conditional Expressions ---------------------------------

if
    : IF LEFT_PAREN expression RIGHT_PAREN (DOUBLE_ARROW returnTypeList)? block (ELSE elseIf)?
    ;

elseIf
	: if
	| block
	;

// ------------------------------------ Loop Expressions ------------------------------------


while
    : WHILE LEFT_PAREN expression RIGHT_PAREN block
    ;

each
    : EACH LEFT_PAREN declaration (COMMA declaration)* IN expressionList RIGHT_PAREN block
    ;


// ------------------------------------ Jump Expressions ------------------------------------

jump
    : return
    | break
    | continue
    ;

return
	: RETURN
	| RETURN expression (COMMA expression)*
	;

break
    : BREAK
    ;

continue
    : CONTINUE
    ;

// ------------------------------------------------------------------------------------------
// ----------------------------------------- Types ------------------------------------------
// ------------------------------------------------------------------------------------------

// --------------------------------------- Type Lists ---------------------------------------

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

// ------------------------------------- Singular Types -------------------------------------

type
	// String (Int, Int) => Int, Int -- function type with a caller type
	: functionCallerType

	// (Int, Int) => Int, Int -- function type without a caller type
	| functionType

	// Struct(Int, Int) -- struct type
	| structType

	// Interface( (Int) => Int ) -- interface type
	| interfaceType

	// [Int] -- list type
	| listType

	// {String, Int} -- dictionary type
	| dictType

    // TODO: Figure out how I'm going to do generics
	// IType -- interface type used for getting the type that implements the interface
	//| ITYPE

	// Int -- type, could be built-in or user-defined
	| IDENTIFIER
	;

functionCallerType
	// String (Int, Int) => Int, Int -- function type with a caller type
	// What happens if the IDENTIFIER is a type??
	: callerType LEFT_PAREN parameterTypeList RIGHT_PAREN DOUBLE_ARROW returnTypeList
	;

callerType
	: IDENTIFIER
	;

functionTypeList
    : functionType (COMMA functionType)*
    ;

functionType
	// (Int, Int) => Int, Int -- function type without a caller type
	: LEFT_PAREN parameterTypeList RIGHT_PAREN DOUBLE_ARROW returnTypeList
	;

structType
	// Struct(Int, Int) -- struct type
	: STRUCT_TYPE LEFT_PAREN parameterTypeList RIGHT_PAREN
	;

interfaceType
	// Interface( (Int) => Int) -- interface type
	: INTERFACE_TYPE LEFT_PAREN functionTypeList? RIGHT_PAREN
	;

listType
	// [Int] -- list type
	: LEFT_BRACKET type RIGHT_BRACKET
	;

dictType
	// {String, Int} -- dictionary type
	: LEFT_BRACE type COMMA type RIGHT_BRACE
	;


// ---------------------------------------------------------------------------------------------
// ------------------------------------- Literals ----------------------------------------------
// ---------------------------------------------------------------------------------------------

// TODO: This could use tweaking now with expressionTail
identifierList
	// x, _y, z123, R2D2
	: IDENTIFIER (COMMA IDENTIFIER)*
	// myVector.x, myPlayer.myVector.y
	//| IDENTIFIER PERIOD IDENTIFIER (COMMA IDENTIFIER PERIOD IDENTIFIER)*
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

dictionary
	// {(1, 2), (3, 4)} ; {("hello", 2), ("there", 4)} 
	: LEFT_BRACE (dictionaryElement (COMMA dictionaryElement)*)? RIGHT_BRACE
	;

dictionaryElement
	: LEFT_PAREN expression COMMA expression RIGHT_PAREN
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
	// { add : IType (IType x) => IType; square : IType () => IType; retString() => String };
	: LEFT_BRACE declaration* RIGHT_BRACE
	;

structBlock
	// { x : Int; y : Float; }
	: LEFT_BRACE (declaration | inferAssignment SEMICOLON | assignment SEMICOLON )* RIGHT_BRACE
	;


// ---------------------------------------------------------------------------------------------
// ------------------------------------- Operators ---------------------------------------------
// ---------------------------------------------------------------------------------------------

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




