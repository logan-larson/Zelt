// Generated from c:\Users\logan\source\repos\Zelt\Zelt\Grammar\ZeltParser.g4 by ANTLR 4.9.2
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.misc.*;
import org.antlr.v4.runtime.tree.*;
import java.util.List;
import java.util.Iterator;
import java.util.ArrayList;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class ZeltParser extends Parser {
	static { RuntimeMetaData.checkVersion("4.9.2", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		INTEGER=1, FLOAT=2, STRING=3, BOOL=4, NULL=5, COMMENT=6, MULTILINE_COMMENT=7, 
		WS=8, PRINT=9, STRUCT=10, INTERFACE=11, ITYPE=12, IF=13, ELSE=14, WHILE=15, 
		EACH=16, IN=17, CALLER=18, RETURN=19, SEMICOLON=20, COMMA=21, LEFT_BRACE=22, 
		RIGHT_BRACE=23, LEFT_PAREN=24, RIGHT_PAREN=25, LEFT_BRACKET=26, RIGHT_BRACKET=27, 
		QUESTION_MARK=28, ELLIPSIS=29, DOUBLE_PERIOD=30, PERIOD=31, DOUBLE_COLON=32, 
		COLON=33, ARROW=34, DOUBLE_ARROW=35, PLUS=36, MINUS=37, MULTIPLY=38, DIVIDE=39, 
		MODULO=40, NOT=41, AND=42, OR=43, EQUALS=44, NOT_EQUALS=45, LESS_THAN=46, 
		LESS_THAN_OR_EQUAL=47, GREATER_THAN=48, GREATER_THAN_OR_EQUAL=49, IS_DEFINED_AS=50, 
		IDENTIFIER=51, UNDERSCORE=52, CLOSE_COMMENT=53, NESTED_COMMENT=54, ANY_OTHER=55;
	public static final int
		RULE_program = 0, RULE_line = 1, RULE_statement = 2, RULE_printStatement = 3, 
		RULE_controlFlowStatement = 4, RULE_ifStatement = 5, RULE_elseIfStatement = 6, 
		RULE_whileStatement = 7, RULE_eachStatement = 8, RULE_returnStatement = 9, 
		RULE_declarationStatement = 10, RULE_declaration = 11, RULE_functionDeclaration = 12, 
		RULE_interfaceDeclaration = 13, RULE_structDeclaration = 14, RULE_parameterDeclarationList = 15, 
		RULE_parameterDeclaration = 16, RULE_functionSignature = 17, RULE_assignmentStatement = 18, 
		RULE_assignment = 19, RULE_inferAssignment = 20, RULE_simpleAssignment = 21, 
		RULE_functionCallStatement = 22, RULE_functionCall = 23, RULE_expressionList = 24, 
		RULE_expression = 25, RULE_typeList = 26, RULE_parameterTypeList = 27, 
		RULE_returnTypeList = 28, RULE_type = 29, RULE_functionCallerType = 30, 
		RULE_functionType = 31, RULE_listType = 32, RULE_identifierList = 33, 
		RULE_literal = 34, RULE_list = 35, RULE_listElement = 36, RULE_functionIdentifier = 37, 
		RULE_block = 38, RULE_interfaceBlock = 39, RULE_structBlock = 40, RULE_accessor = 41, 
		RULE_addOp = 42, RULE_multOp = 43, RULE_relOp = 44, RULE_boolOp = 45;
	private static String[] makeRuleNames() {
		return new String[] {
			"program", "line", "statement", "printStatement", "controlFlowStatement", 
			"ifStatement", "elseIfStatement", "whileStatement", "eachStatement", 
			"returnStatement", "declarationStatement", "declaration", "functionDeclaration", 
			"interfaceDeclaration", "structDeclaration", "parameterDeclarationList", 
			"parameterDeclaration", "functionSignature", "assignmentStatement", "assignment", 
			"inferAssignment", "simpleAssignment", "functionCallStatement", "functionCall", 
			"expressionList", "expression", "typeList", "parameterTypeList", "returnTypeList", 
			"type", "functionCallerType", "functionType", "listType", "identifierList", 
			"literal", "list", "listElement", "functionIdentifier", "block", "interfaceBlock", 
			"structBlock", "accessor", "addOp", "multOp", "relOp", "boolOp"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, null, null, null, null, "'null'", null, null, null, "'print'", 
			"'struct'", "'interface'", "'IType'", "'if'", "'else'", "'while'", "'each'", 
			"'in'", "'caller'", "'return'", "';'", "','", "'{'", "'}'", "'('", "')'", 
			"'['", "']'", "'?'", "'...'", "'..'", "'.'", "'::'", "':'", "'->'", "'=>'", 
			"'+'", "'-'", "'*'", "'/'", "'%'", "'!'", "'&&'", "'||'", "'=='", "'!='", 
			"'<'", "'<='", "'>'", "'>='", "'='", null, "'_'", "'*/'"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, "INTEGER", "FLOAT", "STRING", "BOOL", "NULL", "COMMENT", "MULTILINE_COMMENT", 
			"WS", "PRINT", "STRUCT", "INTERFACE", "ITYPE", "IF", "ELSE", "WHILE", 
			"EACH", "IN", "CALLER", "RETURN", "SEMICOLON", "COMMA", "LEFT_BRACE", 
			"RIGHT_BRACE", "LEFT_PAREN", "RIGHT_PAREN", "LEFT_BRACKET", "RIGHT_BRACKET", 
			"QUESTION_MARK", "ELLIPSIS", "DOUBLE_PERIOD", "PERIOD", "DOUBLE_COLON", 
			"COLON", "ARROW", "DOUBLE_ARROW", "PLUS", "MINUS", "MULTIPLY", "DIVIDE", 
			"MODULO", "NOT", "AND", "OR", "EQUALS", "NOT_EQUALS", "LESS_THAN", "LESS_THAN_OR_EQUAL", 
			"GREATER_THAN", "GREATER_THAN_OR_EQUAL", "IS_DEFINED_AS", "IDENTIFIER", 
			"UNDERSCORE", "CLOSE_COMMENT", "NESTED_COMMENT", "ANY_OTHER"
		};
	}
	private static final String[] _SYMBOLIC_NAMES = makeSymbolicNames();
	public static final Vocabulary VOCABULARY = new VocabularyImpl(_LITERAL_NAMES, _SYMBOLIC_NAMES);

	/**
	 * @deprecated Use {@link #VOCABULARY} instead.
	 */
	@Deprecated
	public static final String[] tokenNames;
	static {
		tokenNames = new String[_SYMBOLIC_NAMES.length];
		for (int i = 0; i < tokenNames.length; i++) {
			tokenNames[i] = VOCABULARY.getLiteralName(i);
			if (tokenNames[i] == null) {
				tokenNames[i] = VOCABULARY.getSymbolicName(i);
			}

			if (tokenNames[i] == null) {
				tokenNames[i] = "<INVALID>";
			}
		}
	}

	@Override
	@Deprecated
	public String[] getTokenNames() {
		return tokenNames;
	}

	@Override

	public Vocabulary getVocabulary() {
		return VOCABULARY;
	}

	@Override
	public String getGrammarFileName() { return "ZeltParser.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public ATN getATN() { return _ATN; }

	public ZeltParser(TokenStream input) {
		super(input);
		_interp = new ParserATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	public static class ProgramContext extends ParserRuleContext {
		public TerminalNode EOF() { return getToken(ZeltParser.EOF, 0); }
		public List<LineContext> line() {
			return getRuleContexts(LineContext.class);
		}
		public LineContext line(int i) {
			return getRuleContext(LineContext.class,i);
		}
		public ProgramContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_program; }
	}

	public final ProgramContext program() throws RecognitionException {
		ProgramContext _localctx = new ProgramContext(_ctx, getState());
		enterRule(_localctx, 0, RULE_program);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(95);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << PRINT) | (1L << STRUCT) | (1L << INTERFACE) | (1L << ITYPE) | (1L << IF) | (1L << WHILE) | (1L << EACH) | (1L << CALLER) | (1L << RETURN) | (1L << LEFT_PAREN) | (1L << LEFT_BRACKET) | (1L << IDENTIFIER))) != 0)) {
				{
				{
				setState(92);
				line();
				}
				}
				setState(97);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(98);
			match(EOF);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class LineContext extends ParserRuleContext {
		public StatementContext statement() {
			return getRuleContext(StatementContext.class,0);
		}
		public LineContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_line; }
	}

	public final LineContext line() throws RecognitionException {
		LineContext _localctx = new LineContext(_ctx, getState());
		enterRule(_localctx, 2, RULE_line);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(100);
			statement();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class StatementContext extends ParserRuleContext {
		public DeclarationStatementContext declarationStatement() {
			return getRuleContext(DeclarationStatementContext.class,0);
		}
		public AssignmentStatementContext assignmentStatement() {
			return getRuleContext(AssignmentStatementContext.class,0);
		}
		public ControlFlowStatementContext controlFlowStatement() {
			return getRuleContext(ControlFlowStatementContext.class,0);
		}
		public FunctionCallStatementContext functionCallStatement() {
			return getRuleContext(FunctionCallStatementContext.class,0);
		}
		public PrintStatementContext printStatement() {
			return getRuleContext(PrintStatementContext.class,0);
		}
		public InterfaceDeclarationContext interfaceDeclaration() {
			return getRuleContext(InterfaceDeclarationContext.class,0);
		}
		public StructDeclarationContext structDeclaration() {
			return getRuleContext(StructDeclarationContext.class,0);
		}
		public FunctionDeclarationContext functionDeclaration() {
			return getRuleContext(FunctionDeclarationContext.class,0);
		}
		public ReturnStatementContext returnStatement() {
			return getRuleContext(ReturnStatementContext.class,0);
		}
		public StatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_statement; }
	}

	public final StatementContext statement() throws RecognitionException {
		StatementContext _localctx = new StatementContext(_ctx, getState());
		enterRule(_localctx, 4, RULE_statement);
		try {
			setState(111);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,1,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(102);
				declarationStatement();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(103);
				assignmentStatement();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(104);
				controlFlowStatement();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(105);
				functionCallStatement();
				}
				break;
			case 5:
				enterOuterAlt(_localctx, 5);
				{
				setState(106);
				printStatement();
				}
				break;
			case 6:
				enterOuterAlt(_localctx, 6);
				{
				setState(107);
				interfaceDeclaration();
				}
				break;
			case 7:
				enterOuterAlt(_localctx, 7);
				{
				setState(108);
				structDeclaration();
				}
				break;
			case 8:
				enterOuterAlt(_localctx, 8);
				{
				setState(109);
				functionDeclaration();
				}
				break;
			case 9:
				enterOuterAlt(_localctx, 9);
				{
				setState(110);
				returnStatement();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class PrintStatementContext extends ParserRuleContext {
		public TerminalNode PRINT() { return getToken(ZeltParser.PRINT, 0); }
		public TerminalNode LEFT_PAREN() { return getToken(ZeltParser.LEFT_PAREN, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public TerminalNode RIGHT_PAREN() { return getToken(ZeltParser.RIGHT_PAREN, 0); }
		public TerminalNode SEMICOLON() { return getToken(ZeltParser.SEMICOLON, 0); }
		public PrintStatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_printStatement; }
	}

	public final PrintStatementContext printStatement() throws RecognitionException {
		PrintStatementContext _localctx = new PrintStatementContext(_ctx, getState());
		enterRule(_localctx, 6, RULE_printStatement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(113);
			match(PRINT);
			setState(114);
			match(LEFT_PAREN);
			setState(115);
			expression(0);
			setState(116);
			match(RIGHT_PAREN);
			setState(117);
			match(SEMICOLON);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ControlFlowStatementContext extends ParserRuleContext {
		public IfStatementContext ifStatement() {
			return getRuleContext(IfStatementContext.class,0);
		}
		public WhileStatementContext whileStatement() {
			return getRuleContext(WhileStatementContext.class,0);
		}
		public EachStatementContext eachStatement() {
			return getRuleContext(EachStatementContext.class,0);
		}
		public ControlFlowStatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_controlFlowStatement; }
	}

	public final ControlFlowStatementContext controlFlowStatement() throws RecognitionException {
		ControlFlowStatementContext _localctx = new ControlFlowStatementContext(_ctx, getState());
		enterRule(_localctx, 8, RULE_controlFlowStatement);
		try {
			setState(122);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case IF:
				enterOuterAlt(_localctx, 1);
				{
				setState(119);
				ifStatement();
				}
				break;
			case WHILE:
				enterOuterAlt(_localctx, 2);
				{
				setState(120);
				whileStatement();
				}
				break;
			case EACH:
				enterOuterAlt(_localctx, 3);
				{
				setState(121);
				eachStatement();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class IfStatementContext extends ParserRuleContext {
		public TerminalNode IF() { return getToken(ZeltParser.IF, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public BlockContext block() {
			return getRuleContext(BlockContext.class,0);
		}
		public TerminalNode ELSE() { return getToken(ZeltParser.ELSE, 0); }
		public ElseIfStatementContext elseIfStatement() {
			return getRuleContext(ElseIfStatementContext.class,0);
		}
		public IfStatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_ifStatement; }
	}

	public final IfStatementContext ifStatement() throws RecognitionException {
		IfStatementContext _localctx = new IfStatementContext(_ctx, getState());
		enterRule(_localctx, 10, RULE_ifStatement);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(124);
			match(IF);
			setState(125);
			expression(0);
			setState(126);
			block();
			setState(129);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==ELSE) {
				{
				setState(127);
				match(ELSE);
				setState(128);
				elseIfStatement();
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ElseIfStatementContext extends ParserRuleContext {
		public IfStatementContext ifStatement() {
			return getRuleContext(IfStatementContext.class,0);
		}
		public BlockContext block() {
			return getRuleContext(BlockContext.class,0);
		}
		public ElseIfStatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_elseIfStatement; }
	}

	public final ElseIfStatementContext elseIfStatement() throws RecognitionException {
		ElseIfStatementContext _localctx = new ElseIfStatementContext(_ctx, getState());
		enterRule(_localctx, 12, RULE_elseIfStatement);
		try {
			setState(133);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case IF:
				enterOuterAlt(_localctx, 1);
				{
				setState(131);
				ifStatement();
				}
				break;
			case LEFT_BRACE:
				enterOuterAlt(_localctx, 2);
				{
				setState(132);
				block();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class WhileStatementContext extends ParserRuleContext {
		public TerminalNode WHILE() { return getToken(ZeltParser.WHILE, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public BlockContext block() {
			return getRuleContext(BlockContext.class,0);
		}
		public WhileStatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_whileStatement; }
	}

	public final WhileStatementContext whileStatement() throws RecognitionException {
		WhileStatementContext _localctx = new WhileStatementContext(_ctx, getState());
		enterRule(_localctx, 14, RULE_whileStatement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(135);
			match(WHILE);
			setState(136);
			expression(0);
			setState(137);
			block();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class EachStatementContext extends ParserRuleContext {
		public TerminalNode EACH() { return getToken(ZeltParser.EACH, 0); }
		public DeclarationContext declaration() {
			return getRuleContext(DeclarationContext.class,0);
		}
		public TerminalNode IN() { return getToken(ZeltParser.IN, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public BlockContext block() {
			return getRuleContext(BlockContext.class,0);
		}
		public EachStatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_eachStatement; }
	}

	public final EachStatementContext eachStatement() throws RecognitionException {
		EachStatementContext _localctx = new EachStatementContext(_ctx, getState());
		enterRule(_localctx, 16, RULE_eachStatement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(139);
			match(EACH);
			setState(140);
			declaration();
			setState(141);
			match(IN);
			setState(142);
			expression(0);
			setState(143);
			block();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ReturnStatementContext extends ParserRuleContext {
		public TerminalNode RETURN() { return getToken(ZeltParser.RETURN, 0); }
		public TerminalNode SEMICOLON() { return getToken(ZeltParser.SEMICOLON, 0); }
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public List<TerminalNode> COMMA() { return getTokens(ZeltParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(ZeltParser.COMMA, i);
		}
		public ReturnStatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_returnStatement; }
	}

	public final ReturnStatementContext returnStatement() throws RecognitionException {
		ReturnStatementContext _localctx = new ReturnStatementContext(_ctx, getState());
		enterRule(_localctx, 18, RULE_returnStatement);
		int _la;
		try {
			setState(158);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,6,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(145);
				match(RETURN);
				setState(146);
				match(SEMICOLON);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(147);
				match(RETURN);
				setState(148);
				expression(0);
				setState(153);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(149);
					match(COMMA);
					setState(150);
					expression(0);
					}
					}
					setState(155);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				setState(156);
				match(SEMICOLON);
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class DeclarationStatementContext extends ParserRuleContext {
		public DeclarationContext declaration() {
			return getRuleContext(DeclarationContext.class,0);
		}
		public TerminalNode SEMICOLON() { return getToken(ZeltParser.SEMICOLON, 0); }
		public DeclarationStatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_declarationStatement; }
	}

	public final DeclarationStatementContext declarationStatement() throws RecognitionException {
		DeclarationStatementContext _localctx = new DeclarationStatementContext(_ctx, getState());
		enterRule(_localctx, 20, RULE_declarationStatement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(160);
			declaration();
			setState(161);
			match(SEMICOLON);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class DeclarationContext extends ParserRuleContext {
		public IdentifierListContext identifierList() {
			return getRuleContext(IdentifierListContext.class,0);
		}
		public TerminalNode COLON() { return getToken(ZeltParser.COLON, 0); }
		public TypeListContext typeList() {
			return getRuleContext(TypeListContext.class,0);
		}
		public DeclarationContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_declaration; }
	}

	public final DeclarationContext declaration() throws RecognitionException {
		DeclarationContext _localctx = new DeclarationContext(_ctx, getState());
		enterRule(_localctx, 22, RULE_declaration);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(163);
			identifierList();
			setState(164);
			match(COLON);
			setState(165);
			typeList();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class FunctionDeclarationContext extends ParserRuleContext {
		public FunctionIdentifierContext functionIdentifier() {
			return getRuleContext(FunctionIdentifierContext.class,0);
		}
		public TerminalNode LEFT_PAREN() { return getToken(ZeltParser.LEFT_PAREN, 0); }
		public TerminalNode RIGHT_PAREN() { return getToken(ZeltParser.RIGHT_PAREN, 0); }
		public TerminalNode DOUBLE_ARROW() { return getToken(ZeltParser.DOUBLE_ARROW, 0); }
		public TypeListContext typeList() {
			return getRuleContext(TypeListContext.class,0);
		}
		public BlockContext block() {
			return getRuleContext(BlockContext.class,0);
		}
		public ParameterDeclarationListContext parameterDeclarationList() {
			return getRuleContext(ParameterDeclarationListContext.class,0);
		}
		public TypeContext type() {
			return getRuleContext(TypeContext.class,0);
		}
		public FunctionDeclarationContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_functionDeclaration; }
	}

	public final FunctionDeclarationContext functionDeclaration() throws RecognitionException {
		FunctionDeclarationContext _localctx = new FunctionDeclarationContext(_ctx, getState());
		enterRule(_localctx, 24, RULE_functionDeclaration);
		int _la;
		try {
			setState(197);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,10,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(167);
				functionIdentifier();
				setState(168);
				match(LEFT_PAREN);
				setState(170);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==IDENTIFIER) {
					{
					setState(169);
					parameterDeclarationList();
					}
				}

				setState(172);
				match(RIGHT_PAREN);
				setState(173);
				match(DOUBLE_ARROW);
				setState(174);
				typeList();
				setState(175);
				block();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(177);
				type();
				setState(178);
				functionIdentifier();
				setState(179);
				match(LEFT_PAREN);
				setState(181);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==IDENTIFIER) {
					{
					setState(180);
					parameterDeclarationList();
					}
				}

				setState(183);
				match(RIGHT_PAREN);
				setState(184);
				match(DOUBLE_ARROW);
				setState(185);
				typeList();
				setState(186);
				block();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(188);
				match(LEFT_PAREN);
				setState(190);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==IDENTIFIER) {
					{
					setState(189);
					parameterDeclarationList();
					}
				}

				setState(192);
				match(RIGHT_PAREN);
				setState(193);
				match(DOUBLE_ARROW);
				setState(194);
				typeList();
				setState(195);
				block();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class InterfaceDeclarationContext extends ParserRuleContext {
		public TerminalNode INTERFACE() { return getToken(ZeltParser.INTERFACE, 0); }
		public TerminalNode IDENTIFIER() { return getToken(ZeltParser.IDENTIFIER, 0); }
		public InterfaceBlockContext interfaceBlock() {
			return getRuleContext(InterfaceBlockContext.class,0);
		}
		public InterfaceDeclarationContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_interfaceDeclaration; }
	}

	public final InterfaceDeclarationContext interfaceDeclaration() throws RecognitionException {
		InterfaceDeclarationContext _localctx = new InterfaceDeclarationContext(_ctx, getState());
		enterRule(_localctx, 26, RULE_interfaceDeclaration);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(199);
			match(INTERFACE);
			setState(200);
			match(IDENTIFIER);
			setState(201);
			interfaceBlock();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class StructDeclarationContext extends ParserRuleContext {
		public TerminalNode STRUCT() { return getToken(ZeltParser.STRUCT, 0); }
		public TerminalNode IDENTIFIER() { return getToken(ZeltParser.IDENTIFIER, 0); }
		public StructBlockContext structBlock() {
			return getRuleContext(StructBlockContext.class,0);
		}
		public TerminalNode COLON() { return getToken(ZeltParser.COLON, 0); }
		public IdentifierListContext identifierList() {
			return getRuleContext(IdentifierListContext.class,0);
		}
		public StructDeclarationContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_structDeclaration; }
	}

	public final StructDeclarationContext structDeclaration() throws RecognitionException {
		StructDeclarationContext _localctx = new StructDeclarationContext(_ctx, getState());
		enterRule(_localctx, 28, RULE_structDeclaration);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(203);
			match(STRUCT);
			setState(204);
			match(IDENTIFIER);
			setState(207);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==COLON) {
				{
				setState(205);
				match(COLON);
				setState(206);
				identifierList();
				}
			}

			setState(209);
			structBlock();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ParameterDeclarationListContext extends ParserRuleContext {
		public List<ParameterDeclarationContext> parameterDeclaration() {
			return getRuleContexts(ParameterDeclarationContext.class);
		}
		public ParameterDeclarationContext parameterDeclaration(int i) {
			return getRuleContext(ParameterDeclarationContext.class,i);
		}
		public List<TerminalNode> COMMA() { return getTokens(ZeltParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(ZeltParser.COMMA, i);
		}
		public ParameterDeclarationListContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_parameterDeclarationList; }
	}

	public final ParameterDeclarationListContext parameterDeclarationList() throws RecognitionException {
		ParameterDeclarationListContext _localctx = new ParameterDeclarationListContext(_ctx, getState());
		enterRule(_localctx, 30, RULE_parameterDeclarationList);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(211);
			parameterDeclaration();
			setState(216);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(212);
				match(COMMA);
				setState(213);
				parameterDeclaration();
				}
				}
				setState(218);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ParameterDeclarationContext extends ParserRuleContext {
		public DeclarationContext declaration() {
			return getRuleContext(DeclarationContext.class,0);
		}
		public AssignmentContext assignment() {
			return getRuleContext(AssignmentContext.class,0);
		}
		public InferAssignmentContext inferAssignment() {
			return getRuleContext(InferAssignmentContext.class,0);
		}
		public ParameterDeclarationContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_parameterDeclaration; }
	}

	public final ParameterDeclarationContext parameterDeclaration() throws RecognitionException {
		ParameterDeclarationContext _localctx = new ParameterDeclarationContext(_ctx, getState());
		enterRule(_localctx, 32, RULE_parameterDeclaration);
		try {
			setState(222);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,13,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(219);
				declaration();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(220);
				assignment();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(221);
				inferAssignment();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class FunctionSignatureContext extends ParserRuleContext {
		public TerminalNode ITYPE() { return getToken(ZeltParser.ITYPE, 0); }
		public FunctionIdentifierContext functionIdentifier() {
			return getRuleContext(FunctionIdentifierContext.class,0);
		}
		public TerminalNode LEFT_PAREN() { return getToken(ZeltParser.LEFT_PAREN, 0); }
		public TerminalNode RIGHT_PAREN() { return getToken(ZeltParser.RIGHT_PAREN, 0); }
		public TerminalNode DOUBLE_ARROW() { return getToken(ZeltParser.DOUBLE_ARROW, 0); }
		public ReturnTypeListContext returnTypeList() {
			return getRuleContext(ReturnTypeListContext.class,0);
		}
		public TerminalNode SEMICOLON() { return getToken(ZeltParser.SEMICOLON, 0); }
		public ParameterTypeListContext parameterTypeList() {
			return getRuleContext(ParameterTypeListContext.class,0);
		}
		public FunctionSignatureContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_functionSignature; }
	}

	public final FunctionSignatureContext functionSignature() throws RecognitionException {
		FunctionSignatureContext _localctx = new FunctionSignatureContext(_ctx, getState());
		enterRule(_localctx, 34, RULE_functionSignature);
		try {
			setState(245);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case ITYPE:
				enterOuterAlt(_localctx, 1);
				{
				setState(224);
				match(ITYPE);
				setState(225);
				functionIdentifier();
				setState(226);
				match(LEFT_PAREN);
				setState(228);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,14,_ctx) ) {
				case 1:
					{
					setState(227);
					parameterTypeList();
					}
					break;
				}
				setState(230);
				match(RIGHT_PAREN);
				setState(231);
				match(DOUBLE_ARROW);
				setState(232);
				returnTypeList();
				setState(233);
				match(SEMICOLON);
				}
				break;
			case IDENTIFIER:
				enterOuterAlt(_localctx, 2);
				{
				setState(235);
				functionIdentifier();
				setState(236);
				match(LEFT_PAREN);
				setState(238);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,15,_ctx) ) {
				case 1:
					{
					setState(237);
					parameterTypeList();
					}
					break;
				}
				setState(240);
				match(RIGHT_PAREN);
				setState(241);
				match(DOUBLE_ARROW);
				setState(242);
				returnTypeList();
				setState(243);
				match(SEMICOLON);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class AssignmentStatementContext extends ParserRuleContext {
		public AssignmentContext assignment() {
			return getRuleContext(AssignmentContext.class,0);
		}
		public TerminalNode SEMICOLON() { return getToken(ZeltParser.SEMICOLON, 0); }
		public InferAssignmentContext inferAssignment() {
			return getRuleContext(InferAssignmentContext.class,0);
		}
		public SimpleAssignmentContext simpleAssignment() {
			return getRuleContext(SimpleAssignmentContext.class,0);
		}
		public AssignmentStatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_assignmentStatement; }
	}

	public final AssignmentStatementContext assignmentStatement() throws RecognitionException {
		AssignmentStatementContext _localctx = new AssignmentStatementContext(_ctx, getState());
		enterRule(_localctx, 36, RULE_assignmentStatement);
		try {
			setState(256);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,17,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(247);
				assignment();
				setState(248);
				match(SEMICOLON);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(250);
				inferAssignment();
				setState(251);
				match(SEMICOLON);
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(253);
				simpleAssignment();
				setState(254);
				match(SEMICOLON);
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class AssignmentContext extends ParserRuleContext {
		public IdentifierListContext identifierList() {
			return getRuleContext(IdentifierListContext.class,0);
		}
		public TerminalNode COLON() { return getToken(ZeltParser.COLON, 0); }
		public TypeListContext typeList() {
			return getRuleContext(TypeListContext.class,0);
		}
		public TerminalNode IS_DEFINED_AS() { return getToken(ZeltParser.IS_DEFINED_AS, 0); }
		public ExpressionListContext expressionList() {
			return getRuleContext(ExpressionListContext.class,0);
		}
		public AssignmentContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_assignment; }
	}

	public final AssignmentContext assignment() throws RecognitionException {
		AssignmentContext _localctx = new AssignmentContext(_ctx, getState());
		enterRule(_localctx, 38, RULE_assignment);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(258);
			identifierList();
			setState(259);
			match(COLON);
			setState(260);
			typeList();
			setState(261);
			match(IS_DEFINED_AS);
			setState(262);
			expressionList();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class InferAssignmentContext extends ParserRuleContext {
		public IdentifierListContext identifierList() {
			return getRuleContext(IdentifierListContext.class,0);
		}
		public TerminalNode COLON() { return getToken(ZeltParser.COLON, 0); }
		public TerminalNode IS_DEFINED_AS() { return getToken(ZeltParser.IS_DEFINED_AS, 0); }
		public ExpressionListContext expressionList() {
			return getRuleContext(ExpressionListContext.class,0);
		}
		public InferAssignmentContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_inferAssignment; }
	}

	public final InferAssignmentContext inferAssignment() throws RecognitionException {
		InferAssignmentContext _localctx = new InferAssignmentContext(_ctx, getState());
		enterRule(_localctx, 40, RULE_inferAssignment);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(264);
			identifierList();
			setState(265);
			match(COLON);
			setState(266);
			match(IS_DEFINED_AS);
			setState(267);
			expressionList();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class SimpleAssignmentContext extends ParserRuleContext {
		public IdentifierListContext identifierList() {
			return getRuleContext(IdentifierListContext.class,0);
		}
		public TerminalNode IS_DEFINED_AS() { return getToken(ZeltParser.IS_DEFINED_AS, 0); }
		public ExpressionListContext expressionList() {
			return getRuleContext(ExpressionListContext.class,0);
		}
		public SimpleAssignmentContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_simpleAssignment; }
	}

	public final SimpleAssignmentContext simpleAssignment() throws RecognitionException {
		SimpleAssignmentContext _localctx = new SimpleAssignmentContext(_ctx, getState());
		enterRule(_localctx, 42, RULE_simpleAssignment);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(269);
			identifierList();
			setState(270);
			match(IS_DEFINED_AS);
			setState(271);
			expressionList();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class FunctionCallStatementContext extends ParserRuleContext {
		public FunctionCallContext functionCall() {
			return getRuleContext(FunctionCallContext.class,0);
		}
		public TerminalNode SEMICOLON() { return getToken(ZeltParser.SEMICOLON, 0); }
		public FunctionCallStatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_functionCallStatement; }
	}

	public final FunctionCallStatementContext functionCallStatement() throws RecognitionException {
		FunctionCallStatementContext _localctx = new FunctionCallStatementContext(_ctx, getState());
		enterRule(_localctx, 44, RULE_functionCallStatement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(273);
			functionCall();
			setState(274);
			match(SEMICOLON);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class FunctionCallContext extends ParserRuleContext {
		public FunctionIdentifierContext functionIdentifier() {
			return getRuleContext(FunctionIdentifierContext.class,0);
		}
		public TerminalNode LEFT_PAREN() { return getToken(ZeltParser.LEFT_PAREN, 0); }
		public TerminalNode RIGHT_PAREN() { return getToken(ZeltParser.RIGHT_PAREN, 0); }
		public ExpressionListContext expressionList() {
			return getRuleContext(ExpressionListContext.class,0);
		}
		public TerminalNode CALLER() { return getToken(ZeltParser.CALLER, 0); }
		public TerminalNode PERIOD() { return getToken(ZeltParser.PERIOD, 0); }
		public TerminalNode IDENTIFIER() { return getToken(ZeltParser.IDENTIFIER, 0); }
		public FunctionCallContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_functionCall; }
	}

	public final FunctionCallContext functionCall() throws RecognitionException {
		FunctionCallContext _localctx = new FunctionCallContext(_ctx, getState());
		enterRule(_localctx, 46, RULE_functionCall);
		int _la;
		try {
			setState(301);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,21,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(276);
				functionIdentifier();
				setState(277);
				match(LEFT_PAREN);
				setState(279);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << INTEGER) | (1L << FLOAT) | (1L << STRING) | (1L << BOOL) | (1L << NULL) | (1L << CALLER) | (1L << LEFT_PAREN) | (1L << LEFT_BRACKET) | (1L << NOT) | (1L << IDENTIFIER) | (1L << UNDERSCORE))) != 0)) {
					{
					setState(278);
					expressionList();
					}
				}

				setState(281);
				match(RIGHT_PAREN);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(283);
				match(CALLER);
				setState(284);
				match(PERIOD);
				setState(285);
				functionIdentifier();
				setState(286);
				match(LEFT_PAREN);
				setState(288);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << INTEGER) | (1L << FLOAT) | (1L << STRING) | (1L << BOOL) | (1L << NULL) | (1L << CALLER) | (1L << LEFT_PAREN) | (1L << LEFT_BRACKET) | (1L << NOT) | (1L << IDENTIFIER) | (1L << UNDERSCORE))) != 0)) {
					{
					setState(287);
					expressionList();
					}
				}

				setState(290);
				match(RIGHT_PAREN);
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(292);
				match(IDENTIFIER);
				setState(293);
				match(PERIOD);
				setState(294);
				functionIdentifier();
				setState(295);
				match(LEFT_PAREN);
				setState(297);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << INTEGER) | (1L << FLOAT) | (1L << STRING) | (1L << BOOL) | (1L << NULL) | (1L << CALLER) | (1L << LEFT_PAREN) | (1L << LEFT_BRACKET) | (1L << NOT) | (1L << IDENTIFIER) | (1L << UNDERSCORE))) != 0)) {
					{
					setState(296);
					expressionList();
					}
				}

				setState(299);
				match(RIGHT_PAREN);
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ExpressionListContext extends ParserRuleContext {
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public List<TerminalNode> COMMA() { return getTokens(ZeltParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(ZeltParser.COMMA, i);
		}
		public ExpressionListContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_expressionList; }
	}

	public final ExpressionListContext expressionList() throws RecognitionException {
		ExpressionListContext _localctx = new ExpressionListContext(_ctx, getState());
		enterRule(_localctx, 48, RULE_expressionList);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(303);
			expression(0);
			setState(308);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,22,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					{
					{
					setState(304);
					match(COMMA);
					setState(305);
					expression(0);
					}
					} 
				}
				setState(310);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,22,_ctx);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ExpressionContext extends ParserRuleContext {
		public ExpressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_expression; }
	 
		public ExpressionContext() { }
		public void copyFrom(ExpressionContext ctx) {
			super.copyFrom(ctx);
		}
	}
	public static class AddExpressionContext extends ExpressionContext {
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public AddOpContext addOp() {
			return getRuleContext(AddOpContext.class,0);
		}
		public AddExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
	}
	public static class AccessorExpressionContext extends ExpressionContext {
		public AccessorContext accessor() {
			return getRuleContext(AccessorContext.class,0);
		}
		public AccessorExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
	}
	public static class RelationalExpressionContext extends ExpressionContext {
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public RelOpContext relOp() {
			return getRuleContext(RelOpContext.class,0);
		}
		public RelationalExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
	}
	public static class IdentifierExpressionContext extends ExpressionContext {
		public TerminalNode IDENTIFIER() { return getToken(ZeltParser.IDENTIFIER, 0); }
		public IdentifierExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
	}
	public static class FunctionCallExpressionContext extends ExpressionContext {
		public FunctionCallContext functionCall() {
			return getRuleContext(FunctionCallContext.class,0);
		}
		public FunctionCallExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
	}
	public static class UnderscoreExpressionContext extends ExpressionContext {
		public TerminalNode UNDERSCORE() { return getToken(ZeltParser.UNDERSCORE, 0); }
		public UnderscoreExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
	}
	public static class MultExpressionContext extends ExpressionContext {
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public MultOpContext multOp() {
			return getRuleContext(MultOpContext.class,0);
		}
		public MultExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
	}
	public static class NotExpressionContext extends ExpressionContext {
		public TerminalNode NOT() { return getToken(ZeltParser.NOT, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public NotExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
	}
	public static class ParenExpressionContext extends ExpressionContext {
		public TerminalNode LEFT_PAREN() { return getToken(ZeltParser.LEFT_PAREN, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public TerminalNode RIGHT_PAREN() { return getToken(ZeltParser.RIGHT_PAREN, 0); }
		public ParenExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
	}
	public static class BoolOpExpressionContext extends ExpressionContext {
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public BoolOpContext boolOp() {
			return getRuleContext(BoolOpContext.class,0);
		}
		public BoolOpExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
	}
	public static class LiteralExpressionContext extends ExpressionContext {
		public LiteralContext literal() {
			return getRuleContext(LiteralContext.class,0);
		}
		public LiteralExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
	}
	public static class ListExpressionContext extends ExpressionContext {
		public ListContext list() {
			return getRuleContext(ListContext.class,0);
		}
		public ListExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
	}

	public final ExpressionContext expression() throws RecognitionException {
		return expression(0);
	}

	private ExpressionContext expression(int _p) throws RecognitionException {
		ParserRuleContext _parentctx = _ctx;
		int _parentState = getState();
		ExpressionContext _localctx = new ExpressionContext(_ctx, _parentState);
		ExpressionContext _prevctx = _localctx;
		int _startState = 50;
		enterRecursionRule(_localctx, 50, RULE_expression, _p);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(324);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,23,_ctx) ) {
			case 1:
				{
				_localctx = new LiteralExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;

				setState(312);
				literal();
				}
				break;
			case 2:
				{
				_localctx = new ListExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(313);
				list();
				}
				break;
			case 3:
				{
				_localctx = new AccessorExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(314);
				accessor();
				}
				break;
			case 4:
				{
				_localctx = new IdentifierExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(315);
				match(IDENTIFIER);
				}
				break;
			case 5:
				{
				_localctx = new FunctionCallExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(316);
				functionCall();
				}
				break;
			case 6:
				{
				_localctx = new ParenExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(317);
				match(LEFT_PAREN);
				setState(318);
				expression(0);
				setState(319);
				match(RIGHT_PAREN);
				}
				break;
			case 7:
				{
				_localctx = new NotExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(321);
				match(NOT);
				setState(322);
				expression(6);
				}
				break;
			case 8:
				{
				_localctx = new UnderscoreExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(323);
				match(UNDERSCORE);
				}
				break;
			}
			_ctx.stop = _input.LT(-1);
			setState(344);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,25,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					setState(342);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,24,_ctx) ) {
					case 1:
						{
						_localctx = new MultExpressionContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(326);
						if (!(precpred(_ctx, 5))) throw new FailedPredicateException(this, "precpred(_ctx, 5)");
						setState(327);
						multOp();
						setState(328);
						expression(6);
						}
						break;
					case 2:
						{
						_localctx = new AddExpressionContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(330);
						if (!(precpred(_ctx, 4))) throw new FailedPredicateException(this, "precpred(_ctx, 4)");
						setState(331);
						addOp();
						setState(332);
						expression(5);
						}
						break;
					case 3:
						{
						_localctx = new RelationalExpressionContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(334);
						if (!(precpred(_ctx, 3))) throw new FailedPredicateException(this, "precpred(_ctx, 3)");
						setState(335);
						relOp();
						setState(336);
						expression(4);
						}
						break;
					case 4:
						{
						_localctx = new BoolOpExpressionContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(338);
						if (!(precpred(_ctx, 2))) throw new FailedPredicateException(this, "precpred(_ctx, 2)");
						setState(339);
						boolOp();
						setState(340);
						expression(3);
						}
						break;
					}
					} 
				}
				setState(346);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,25,_ctx);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			unrollRecursionContexts(_parentctx);
		}
		return _localctx;
	}

	public static class TypeListContext extends ParserRuleContext {
		public List<TypeContext> type() {
			return getRuleContexts(TypeContext.class);
		}
		public TypeContext type(int i) {
			return getRuleContext(TypeContext.class,i);
		}
		public List<TerminalNode> COMMA() { return getTokens(ZeltParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(ZeltParser.COMMA, i);
		}
		public TypeListContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_typeList; }
	}

	public final TypeListContext typeList() throws RecognitionException {
		TypeListContext _localctx = new TypeListContext(_ctx, getState());
		enterRule(_localctx, 52, RULE_typeList);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(347);
			type();
			setState(352);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,26,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					{
					{
					setState(348);
					match(COMMA);
					setState(349);
					type();
					}
					} 
				}
				setState(354);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,26,_ctx);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ParameterTypeListContext extends ParserRuleContext {
		public List<TypeContext> type() {
			return getRuleContexts(TypeContext.class);
		}
		public TypeContext type(int i) {
			return getRuleContext(TypeContext.class,i);
		}
		public List<TerminalNode> COMMA() { return getTokens(ZeltParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(ZeltParser.COMMA, i);
		}
		public ParameterTypeListContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_parameterTypeList; }
	}

	public final ParameterTypeListContext parameterTypeList() throws RecognitionException {
		ParameterTypeListContext _localctx = new ParameterTypeListContext(_ctx, getState());
		enterRule(_localctx, 54, RULE_parameterTypeList);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(363);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << ITYPE) | (1L << LEFT_PAREN) | (1L << LEFT_BRACKET) | (1L << IDENTIFIER))) != 0)) {
				{
				setState(355);
				type();
				setState(360);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(356);
					match(COMMA);
					setState(357);
					type();
					}
					}
					setState(362);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ReturnTypeListContext extends ParserRuleContext {
		public List<TypeContext> type() {
			return getRuleContexts(TypeContext.class);
		}
		public TypeContext type(int i) {
			return getRuleContext(TypeContext.class,i);
		}
		public List<TerminalNode> COMMA() { return getTokens(ZeltParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(ZeltParser.COMMA, i);
		}
		public ReturnTypeListContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_returnTypeList; }
	}

	public final ReturnTypeListContext returnTypeList() throws RecognitionException {
		ReturnTypeListContext _localctx = new ReturnTypeListContext(_ctx, getState());
		enterRule(_localctx, 56, RULE_returnTypeList);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(365);
			type();
			setState(370);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,29,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					{
					{
					setState(366);
					match(COMMA);
					setState(367);
					type();
					}
					} 
				}
				setState(372);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,29,_ctx);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class TypeContext extends ParserRuleContext {
		public FunctionCallerTypeContext functionCallerType() {
			return getRuleContext(FunctionCallerTypeContext.class,0);
		}
		public FunctionTypeContext functionType() {
			return getRuleContext(FunctionTypeContext.class,0);
		}
		public ListTypeContext listType() {
			return getRuleContext(ListTypeContext.class,0);
		}
		public TerminalNode ITYPE() { return getToken(ZeltParser.ITYPE, 0); }
		public TerminalNode IDENTIFIER() { return getToken(ZeltParser.IDENTIFIER, 0); }
		public TypeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_type; }
	}

	public final TypeContext type() throws RecognitionException {
		TypeContext _localctx = new TypeContext(_ctx, getState());
		enterRule(_localctx, 58, RULE_type);
		try {
			setState(378);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,30,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(373);
				functionCallerType();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(374);
				functionType();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(375);
				listType();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(376);
				match(ITYPE);
				}
				break;
			case 5:
				enterOuterAlt(_localctx, 5);
				{
				setState(377);
				match(IDENTIFIER);
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class FunctionCallerTypeContext extends ParserRuleContext {
		public TerminalNode IDENTIFIER() { return getToken(ZeltParser.IDENTIFIER, 0); }
		public TerminalNode LEFT_PAREN() { return getToken(ZeltParser.LEFT_PAREN, 0); }
		public ParameterTypeListContext parameterTypeList() {
			return getRuleContext(ParameterTypeListContext.class,0);
		}
		public TerminalNode RIGHT_PAREN() { return getToken(ZeltParser.RIGHT_PAREN, 0); }
		public TerminalNode DOUBLE_ARROW() { return getToken(ZeltParser.DOUBLE_ARROW, 0); }
		public ReturnTypeListContext returnTypeList() {
			return getRuleContext(ReturnTypeListContext.class,0);
		}
		public FunctionCallerTypeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_functionCallerType; }
	}

	public final FunctionCallerTypeContext functionCallerType() throws RecognitionException {
		FunctionCallerTypeContext _localctx = new FunctionCallerTypeContext(_ctx, getState());
		enterRule(_localctx, 60, RULE_functionCallerType);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(380);
			match(IDENTIFIER);
			setState(381);
			match(LEFT_PAREN);
			setState(382);
			parameterTypeList();
			setState(383);
			match(RIGHT_PAREN);
			setState(384);
			match(DOUBLE_ARROW);
			setState(385);
			returnTypeList();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class FunctionTypeContext extends ParserRuleContext {
		public TerminalNode LEFT_PAREN() { return getToken(ZeltParser.LEFT_PAREN, 0); }
		public ParameterTypeListContext parameterTypeList() {
			return getRuleContext(ParameterTypeListContext.class,0);
		}
		public TerminalNode RIGHT_PAREN() { return getToken(ZeltParser.RIGHT_PAREN, 0); }
		public TerminalNode DOUBLE_ARROW() { return getToken(ZeltParser.DOUBLE_ARROW, 0); }
		public ReturnTypeListContext returnTypeList() {
			return getRuleContext(ReturnTypeListContext.class,0);
		}
		public FunctionTypeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_functionType; }
	}

	public final FunctionTypeContext functionType() throws RecognitionException {
		FunctionTypeContext _localctx = new FunctionTypeContext(_ctx, getState());
		enterRule(_localctx, 62, RULE_functionType);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(387);
			match(LEFT_PAREN);
			setState(388);
			parameterTypeList();
			setState(389);
			match(RIGHT_PAREN);
			setState(390);
			match(DOUBLE_ARROW);
			setState(391);
			returnTypeList();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ListTypeContext extends ParserRuleContext {
		public TerminalNode LEFT_BRACKET() { return getToken(ZeltParser.LEFT_BRACKET, 0); }
		public TypeContext type() {
			return getRuleContext(TypeContext.class,0);
		}
		public TerminalNode RIGHT_BRACKET() { return getToken(ZeltParser.RIGHT_BRACKET, 0); }
		public ListTypeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_listType; }
	}

	public final ListTypeContext listType() throws RecognitionException {
		ListTypeContext _localctx = new ListTypeContext(_ctx, getState());
		enterRule(_localctx, 64, RULE_listType);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(393);
			match(LEFT_BRACKET);
			setState(394);
			type();
			setState(395);
			match(RIGHT_BRACKET);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class IdentifierListContext extends ParserRuleContext {
		public List<TerminalNode> IDENTIFIER() { return getTokens(ZeltParser.IDENTIFIER); }
		public TerminalNode IDENTIFIER(int i) {
			return getToken(ZeltParser.IDENTIFIER, i);
		}
		public List<TerminalNode> COMMA() { return getTokens(ZeltParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(ZeltParser.COMMA, i);
		}
		public IdentifierListContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_identifierList; }
	}

	public final IdentifierListContext identifierList() throws RecognitionException {
		IdentifierListContext _localctx = new IdentifierListContext(_ctx, getState());
		enterRule(_localctx, 66, RULE_identifierList);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(397);
			match(IDENTIFIER);
			setState(402);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(398);
				match(COMMA);
				setState(399);
				match(IDENTIFIER);
				}
				}
				setState(404);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class LiteralContext extends ParserRuleContext {
		public TerminalNode INTEGER() { return getToken(ZeltParser.INTEGER, 0); }
		public TerminalNode FLOAT() { return getToken(ZeltParser.FLOAT, 0); }
		public TerminalNode STRING() { return getToken(ZeltParser.STRING, 0); }
		public TerminalNode BOOL() { return getToken(ZeltParser.BOOL, 0); }
		public TerminalNode NULL() { return getToken(ZeltParser.NULL, 0); }
		public LiteralContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_literal; }
	}

	public final LiteralContext literal() throws RecognitionException {
		LiteralContext _localctx = new LiteralContext(_ctx, getState());
		enterRule(_localctx, 68, RULE_literal);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(405);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << INTEGER) | (1L << FLOAT) | (1L << STRING) | (1L << BOOL) | (1L << NULL))) != 0)) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ListContext extends ParserRuleContext {
		public TerminalNode LEFT_BRACKET() { return getToken(ZeltParser.LEFT_BRACKET, 0); }
		public TerminalNode RIGHT_BRACKET() { return getToken(ZeltParser.RIGHT_BRACKET, 0); }
		public List<ListElementContext> listElement() {
			return getRuleContexts(ListElementContext.class);
		}
		public ListElementContext listElement(int i) {
			return getRuleContext(ListElementContext.class,i);
		}
		public List<TerminalNode> COMMA() { return getTokens(ZeltParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(ZeltParser.COMMA, i);
		}
		public ListContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_list; }
	}

	public final ListContext list() throws RecognitionException {
		ListContext _localctx = new ListContext(_ctx, getState());
		enterRule(_localctx, 70, RULE_list);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(407);
			match(LEFT_BRACKET);
			setState(416);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << INTEGER) | (1L << FLOAT) | (1L << STRING) | (1L << BOOL) | (1L << NULL) | (1L << CALLER) | (1L << LEFT_PAREN) | (1L << LEFT_BRACKET) | (1L << NOT) | (1L << IDENTIFIER) | (1L << UNDERSCORE))) != 0)) {
				{
				setState(408);
				listElement();
				setState(413);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(409);
					match(COMMA);
					setState(410);
					listElement();
					}
					}
					setState(415);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				}
			}

			setState(418);
			match(RIGHT_BRACKET);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ListElementContext extends ParserRuleContext {
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public TerminalNode DOUBLE_PERIOD() { return getToken(ZeltParser.DOUBLE_PERIOD, 0); }
		public ListElementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_listElement; }
	}

	public final ListElementContext listElement() throws RecognitionException {
		ListElementContext _localctx = new ListElementContext(_ctx, getState());
		enterRule(_localctx, 72, RULE_listElement);
		try {
			setState(425);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,34,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(420);
				expression(0);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(421);
				expression(0);
				setState(422);
				match(DOUBLE_PERIOD);
				setState(423);
				expression(0);
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class FunctionIdentifierContext extends ParserRuleContext {
		public TerminalNode IDENTIFIER() { return getToken(ZeltParser.IDENTIFIER, 0); }
		public FunctionIdentifierContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_functionIdentifier; }
	}

	public final FunctionIdentifierContext functionIdentifier() throws RecognitionException {
		FunctionIdentifierContext _localctx = new FunctionIdentifierContext(_ctx, getState());
		enterRule(_localctx, 74, RULE_functionIdentifier);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(427);
			match(IDENTIFIER);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class BlockContext extends ParserRuleContext {
		public TerminalNode LEFT_BRACE() { return getToken(ZeltParser.LEFT_BRACE, 0); }
		public TerminalNode RIGHT_BRACE() { return getToken(ZeltParser.RIGHT_BRACE, 0); }
		public List<LineContext> line() {
			return getRuleContexts(LineContext.class);
		}
		public LineContext line(int i) {
			return getRuleContext(LineContext.class,i);
		}
		public BlockContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_block; }
	}

	public final BlockContext block() throws RecognitionException {
		BlockContext _localctx = new BlockContext(_ctx, getState());
		enterRule(_localctx, 76, RULE_block);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(429);
			match(LEFT_BRACE);
			setState(433);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << PRINT) | (1L << STRUCT) | (1L << INTERFACE) | (1L << ITYPE) | (1L << IF) | (1L << WHILE) | (1L << EACH) | (1L << CALLER) | (1L << RETURN) | (1L << LEFT_PAREN) | (1L << LEFT_BRACKET) | (1L << IDENTIFIER))) != 0)) {
				{
				{
				setState(430);
				line();
				}
				}
				setState(435);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(436);
			match(RIGHT_BRACE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class InterfaceBlockContext extends ParserRuleContext {
		public TerminalNode LEFT_BRACE() { return getToken(ZeltParser.LEFT_BRACE, 0); }
		public TerminalNode RIGHT_BRACE() { return getToken(ZeltParser.RIGHT_BRACE, 0); }
		public List<FunctionSignatureContext> functionSignature() {
			return getRuleContexts(FunctionSignatureContext.class);
		}
		public FunctionSignatureContext functionSignature(int i) {
			return getRuleContext(FunctionSignatureContext.class,i);
		}
		public InterfaceBlockContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_interfaceBlock; }
	}

	public final InterfaceBlockContext interfaceBlock() throws RecognitionException {
		InterfaceBlockContext _localctx = new InterfaceBlockContext(_ctx, getState());
		enterRule(_localctx, 78, RULE_interfaceBlock);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(438);
			match(LEFT_BRACE);
			setState(442);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==ITYPE || _la==IDENTIFIER) {
				{
				{
				setState(439);
				functionSignature();
				}
				}
				setState(444);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(445);
			match(RIGHT_BRACE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class StructBlockContext extends ParserRuleContext {
		public TerminalNode LEFT_BRACE() { return getToken(ZeltParser.LEFT_BRACE, 0); }
		public TerminalNode RIGHT_BRACE() { return getToken(ZeltParser.RIGHT_BRACE, 0); }
		public List<DeclarationStatementContext> declarationStatement() {
			return getRuleContexts(DeclarationStatementContext.class);
		}
		public DeclarationStatementContext declarationStatement(int i) {
			return getRuleContext(DeclarationStatementContext.class,i);
		}
		public List<InferAssignmentContext> inferAssignment() {
			return getRuleContexts(InferAssignmentContext.class);
		}
		public InferAssignmentContext inferAssignment(int i) {
			return getRuleContext(InferAssignmentContext.class,i);
		}
		public List<TerminalNode> SEMICOLON() { return getTokens(ZeltParser.SEMICOLON); }
		public TerminalNode SEMICOLON(int i) {
			return getToken(ZeltParser.SEMICOLON, i);
		}
		public List<AssignmentContext> assignment() {
			return getRuleContexts(AssignmentContext.class);
		}
		public AssignmentContext assignment(int i) {
			return getRuleContext(AssignmentContext.class,i);
		}
		public StructBlockContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_structBlock; }
	}

	public final StructBlockContext structBlock() throws RecognitionException {
		StructBlockContext _localctx = new StructBlockContext(_ctx, getState());
		enterRule(_localctx, 80, RULE_structBlock);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(447);
			match(LEFT_BRACE);
			setState(457);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==IDENTIFIER) {
				{
				setState(455);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,37,_ctx) ) {
				case 1:
					{
					setState(448);
					declarationStatement();
					}
					break;
				case 2:
					{
					setState(449);
					inferAssignment();
					setState(450);
					match(SEMICOLON);
					}
					break;
				case 3:
					{
					setState(452);
					assignment();
					setState(453);
					match(SEMICOLON);
					}
					break;
				}
				}
				setState(459);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(460);
			match(RIGHT_BRACE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class AccessorContext extends ParserRuleContext {
		public List<TerminalNode> IDENTIFIER() { return getTokens(ZeltParser.IDENTIFIER); }
		public TerminalNode IDENTIFIER(int i) {
			return getToken(ZeltParser.IDENTIFIER, i);
		}
		public TerminalNode PERIOD() { return getToken(ZeltParser.PERIOD, 0); }
		public TerminalNode CALLER() { return getToken(ZeltParser.CALLER, 0); }
		public AccessorContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_accessor; }
	}

	public final AccessorContext accessor() throws RecognitionException {
		AccessorContext _localctx = new AccessorContext(_ctx, getState());
		enterRule(_localctx, 82, RULE_accessor);
		try {
			setState(468);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case IDENTIFIER:
				enterOuterAlt(_localctx, 1);
				{
				setState(462);
				match(IDENTIFIER);
				setState(463);
				match(PERIOD);
				setState(464);
				match(IDENTIFIER);
				}
				break;
			case CALLER:
				enterOuterAlt(_localctx, 2);
				{
				setState(465);
				match(CALLER);
				setState(466);
				match(PERIOD);
				setState(467);
				match(IDENTIFIER);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class AddOpContext extends ParserRuleContext {
		public TerminalNode PLUS() { return getToken(ZeltParser.PLUS, 0); }
		public TerminalNode MINUS() { return getToken(ZeltParser.MINUS, 0); }
		public AddOpContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_addOp; }
	}

	public final AddOpContext addOp() throws RecognitionException {
		AddOpContext _localctx = new AddOpContext(_ctx, getState());
		enterRule(_localctx, 84, RULE_addOp);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(470);
			_la = _input.LA(1);
			if ( !(_la==PLUS || _la==MINUS) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class MultOpContext extends ParserRuleContext {
		public TerminalNode MULTIPLY() { return getToken(ZeltParser.MULTIPLY, 0); }
		public TerminalNode DIVIDE() { return getToken(ZeltParser.DIVIDE, 0); }
		public TerminalNode MODULO() { return getToken(ZeltParser.MODULO, 0); }
		public MultOpContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_multOp; }
	}

	public final MultOpContext multOp() throws RecognitionException {
		MultOpContext _localctx = new MultOpContext(_ctx, getState());
		enterRule(_localctx, 86, RULE_multOp);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(472);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << MULTIPLY) | (1L << DIVIDE) | (1L << MODULO))) != 0)) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class RelOpContext extends ParserRuleContext {
		public TerminalNode LESS_THAN() { return getToken(ZeltParser.LESS_THAN, 0); }
		public TerminalNode GREATER_THAN() { return getToken(ZeltParser.GREATER_THAN, 0); }
		public TerminalNode LESS_THAN_OR_EQUAL() { return getToken(ZeltParser.LESS_THAN_OR_EQUAL, 0); }
		public TerminalNode GREATER_THAN_OR_EQUAL() { return getToken(ZeltParser.GREATER_THAN_OR_EQUAL, 0); }
		public TerminalNode EQUALS() { return getToken(ZeltParser.EQUALS, 0); }
		public TerminalNode NOT_EQUALS() { return getToken(ZeltParser.NOT_EQUALS, 0); }
		public RelOpContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_relOp; }
	}

	public final RelOpContext relOp() throws RecognitionException {
		RelOpContext _localctx = new RelOpContext(_ctx, getState());
		enterRule(_localctx, 88, RULE_relOp);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(474);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << EQUALS) | (1L << NOT_EQUALS) | (1L << LESS_THAN) | (1L << LESS_THAN_OR_EQUAL) | (1L << GREATER_THAN) | (1L << GREATER_THAN_OR_EQUAL))) != 0)) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class BoolOpContext extends ParserRuleContext {
		public TerminalNode AND() { return getToken(ZeltParser.AND, 0); }
		public TerminalNode OR() { return getToken(ZeltParser.OR, 0); }
		public BoolOpContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_boolOp; }
	}

	public final BoolOpContext boolOp() throws RecognitionException {
		BoolOpContext _localctx = new BoolOpContext(_ctx, getState());
		enterRule(_localctx, 90, RULE_boolOp);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(476);
			_la = _input.LA(1);
			if ( !(_la==AND || _la==OR) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public boolean sempred(RuleContext _localctx, int ruleIndex, int predIndex) {
		switch (ruleIndex) {
		case 25:
			return expression_sempred((ExpressionContext)_localctx, predIndex);
		}
		return true;
	}
	private boolean expression_sempred(ExpressionContext _localctx, int predIndex) {
		switch (predIndex) {
		case 0:
			return precpred(_ctx, 5);
		case 1:
			return precpred(_ctx, 4);
		case 2:
			return precpred(_ctx, 3);
		case 3:
			return precpred(_ctx, 2);
		}
		return true;
	}

	public static final String _serializedATN =
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\39\u01e1\4\2\t\2\4"+
		"\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13\t"+
		"\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4\31\t\31"+
		"\4\32\t\32\4\33\t\33\4\34\t\34\4\35\t\35\4\36\t\36\4\37\t\37\4 \t \4!"+
		"\t!\4\"\t\"\4#\t#\4$\t$\4%\t%\4&\t&\4\'\t\'\4(\t(\4)\t)\4*\t*\4+\t+\4"+
		",\t,\4-\t-\4.\t.\4/\t/\3\2\7\2`\n\2\f\2\16\2c\13\2\3\2\3\2\3\3\3\3\3\4"+
		"\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\4\5\4r\n\4\3\5\3\5\3\5\3\5\3\5\3\5\3\6"+
		"\3\6\3\6\5\6}\n\6\3\7\3\7\3\7\3\7\3\7\5\7\u0084\n\7\3\b\3\b\5\b\u0088"+
		"\n\b\3\t\3\t\3\t\3\t\3\n\3\n\3\n\3\n\3\n\3\n\3\13\3\13\3\13\3\13\3\13"+
		"\3\13\7\13\u009a\n\13\f\13\16\13\u009d\13\13\3\13\3\13\5\13\u00a1\n\13"+
		"\3\f\3\f\3\f\3\r\3\r\3\r\3\r\3\16\3\16\3\16\5\16\u00ad\n\16\3\16\3\16"+
		"\3\16\3\16\3\16\3\16\3\16\3\16\3\16\5\16\u00b8\n\16\3\16\3\16\3\16\3\16"+
		"\3\16\3\16\3\16\5\16\u00c1\n\16\3\16\3\16\3\16\3\16\3\16\5\16\u00c8\n"+
		"\16\3\17\3\17\3\17\3\17\3\20\3\20\3\20\3\20\5\20\u00d2\n\20\3\20\3\20"+
		"\3\21\3\21\3\21\7\21\u00d9\n\21\f\21\16\21\u00dc\13\21\3\22\3\22\3\22"+
		"\5\22\u00e1\n\22\3\23\3\23\3\23\3\23\5\23\u00e7\n\23\3\23\3\23\3\23\3"+
		"\23\3\23\3\23\3\23\3\23\5\23\u00f1\n\23\3\23\3\23\3\23\3\23\3\23\5\23"+
		"\u00f8\n\23\3\24\3\24\3\24\3\24\3\24\3\24\3\24\3\24\3\24\5\24\u0103\n"+
		"\24\3\25\3\25\3\25\3\25\3\25\3\25\3\26\3\26\3\26\3\26\3\26\3\27\3\27\3"+
		"\27\3\27\3\30\3\30\3\30\3\31\3\31\3\31\5\31\u011a\n\31\3\31\3\31\3\31"+
		"\3\31\3\31\3\31\3\31\5\31\u0123\n\31\3\31\3\31\3\31\3\31\3\31\3\31\3\31"+
		"\5\31\u012c\n\31\3\31\3\31\5\31\u0130\n\31\3\32\3\32\3\32\7\32\u0135\n"+
		"\32\f\32\16\32\u0138\13\32\3\33\3\33\3\33\3\33\3\33\3\33\3\33\3\33\3\33"+
		"\3\33\3\33\3\33\3\33\5\33\u0147\n\33\3\33\3\33\3\33\3\33\3\33\3\33\3\33"+
		"\3\33\3\33\3\33\3\33\3\33\3\33\3\33\3\33\3\33\7\33\u0159\n\33\f\33\16"+
		"\33\u015c\13\33\3\34\3\34\3\34\7\34\u0161\n\34\f\34\16\34\u0164\13\34"+
		"\3\35\3\35\3\35\7\35\u0169\n\35\f\35\16\35\u016c\13\35\5\35\u016e\n\35"+
		"\3\36\3\36\3\36\7\36\u0173\n\36\f\36\16\36\u0176\13\36\3\37\3\37\3\37"+
		"\3\37\3\37\5\37\u017d\n\37\3 \3 \3 \3 \3 \3 \3 \3!\3!\3!\3!\3!\3!\3\""+
		"\3\"\3\"\3\"\3#\3#\3#\7#\u0193\n#\f#\16#\u0196\13#\3$\3$\3%\3%\3%\3%\7"+
		"%\u019e\n%\f%\16%\u01a1\13%\5%\u01a3\n%\3%\3%\3&\3&\3&\3&\3&\5&\u01ac"+
		"\n&\3\'\3\'\3(\3(\7(\u01b2\n(\f(\16(\u01b5\13(\3(\3(\3)\3)\7)\u01bb\n"+
		")\f)\16)\u01be\13)\3)\3)\3*\3*\3*\3*\3*\3*\3*\3*\7*\u01ca\n*\f*\16*\u01cd"+
		"\13*\3*\3*\3+\3+\3+\3+\3+\3+\5+\u01d7\n+\3,\3,\3-\3-\3.\3.\3/\3/\3/\2"+
		"\3\64\60\2\4\6\b\n\f\16\20\22\24\26\30\32\34\36 \"$&(*,.\60\62\64\668"+
		":<>@BDFHJLNPRTVXZ\\\2\7\3\2\3\7\3\2&\'\3\2(*\3\2.\63\3\2,-\2\u01f2\2a"+
		"\3\2\2\2\4f\3\2\2\2\6q\3\2\2\2\bs\3\2\2\2\n|\3\2\2\2\f~\3\2\2\2\16\u0087"+
		"\3\2\2\2\20\u0089\3\2\2\2\22\u008d\3\2\2\2\24\u00a0\3\2\2\2\26\u00a2\3"+
		"\2\2\2\30\u00a5\3\2\2\2\32\u00c7\3\2\2\2\34\u00c9\3\2\2\2\36\u00cd\3\2"+
		"\2\2 \u00d5\3\2\2\2\"\u00e0\3\2\2\2$\u00f7\3\2\2\2&\u0102\3\2\2\2(\u0104"+
		"\3\2\2\2*\u010a\3\2\2\2,\u010f\3\2\2\2.\u0113\3\2\2\2\60\u012f\3\2\2\2"+
		"\62\u0131\3\2\2\2\64\u0146\3\2\2\2\66\u015d\3\2\2\28\u016d\3\2\2\2:\u016f"+
		"\3\2\2\2<\u017c\3\2\2\2>\u017e\3\2\2\2@\u0185\3\2\2\2B\u018b\3\2\2\2D"+
		"\u018f\3\2\2\2F\u0197\3\2\2\2H\u0199\3\2\2\2J\u01ab\3\2\2\2L\u01ad\3\2"+
		"\2\2N\u01af\3\2\2\2P\u01b8\3\2\2\2R\u01c1\3\2\2\2T\u01d6\3\2\2\2V\u01d8"+
		"\3\2\2\2X\u01da\3\2\2\2Z\u01dc\3\2\2\2\\\u01de\3\2\2\2^`\5\4\3\2_^\3\2"+
		"\2\2`c\3\2\2\2a_\3\2\2\2ab\3\2\2\2bd\3\2\2\2ca\3\2\2\2de\7\2\2\3e\3\3"+
		"\2\2\2fg\5\6\4\2g\5\3\2\2\2hr\5\26\f\2ir\5&\24\2jr\5\n\6\2kr\5.\30\2l"+
		"r\5\b\5\2mr\5\34\17\2nr\5\36\20\2or\5\32\16\2pr\5\24\13\2qh\3\2\2\2qi"+
		"\3\2\2\2qj\3\2\2\2qk\3\2\2\2ql\3\2\2\2qm\3\2\2\2qn\3\2\2\2qo\3\2\2\2q"+
		"p\3\2\2\2r\7\3\2\2\2st\7\13\2\2tu\7\32\2\2uv\5\64\33\2vw\7\33\2\2wx\7"+
		"\26\2\2x\t\3\2\2\2y}\5\f\7\2z}\5\20\t\2{}\5\22\n\2|y\3\2\2\2|z\3\2\2\2"+
		"|{\3\2\2\2}\13\3\2\2\2~\177\7\17\2\2\177\u0080\5\64\33\2\u0080\u0083\5"+
		"N(\2\u0081\u0082\7\20\2\2\u0082\u0084\5\16\b\2\u0083\u0081\3\2\2\2\u0083"+
		"\u0084\3\2\2\2\u0084\r\3\2\2\2\u0085\u0088\5\f\7\2\u0086\u0088\5N(\2\u0087"+
		"\u0085\3\2\2\2\u0087\u0086\3\2\2\2\u0088\17\3\2\2\2\u0089\u008a\7\21\2"+
		"\2\u008a\u008b\5\64\33\2\u008b\u008c\5N(\2\u008c\21\3\2\2\2\u008d\u008e"+
		"\7\22\2\2\u008e\u008f\5\30\r\2\u008f\u0090\7\23\2\2\u0090\u0091\5\64\33"+
		"\2\u0091\u0092\5N(\2\u0092\23\3\2\2\2\u0093\u0094\7\25\2\2\u0094\u00a1"+
		"\7\26\2\2\u0095\u0096\7\25\2\2\u0096\u009b\5\64\33\2\u0097\u0098\7\27"+
		"\2\2\u0098\u009a\5\64\33\2\u0099\u0097\3\2\2\2\u009a\u009d\3\2\2\2\u009b"+
		"\u0099\3\2\2\2\u009b\u009c\3\2\2\2\u009c\u009e\3\2\2\2\u009d\u009b\3\2"+
		"\2\2\u009e\u009f\7\26\2\2\u009f\u00a1\3\2\2\2\u00a0\u0093\3\2\2\2\u00a0"+
		"\u0095\3\2\2\2\u00a1\25\3\2\2\2\u00a2\u00a3\5\30\r\2\u00a3\u00a4\7\26"+
		"\2\2\u00a4\27\3\2\2\2\u00a5\u00a6\5D#\2\u00a6\u00a7\7#\2\2\u00a7\u00a8"+
		"\5\66\34\2\u00a8\31\3\2\2\2\u00a9\u00aa\5L\'\2\u00aa\u00ac\7\32\2\2\u00ab"+
		"\u00ad\5 \21\2\u00ac\u00ab\3\2\2\2\u00ac\u00ad\3\2\2\2\u00ad\u00ae\3\2"+
		"\2\2\u00ae\u00af\7\33\2\2\u00af\u00b0\7%\2\2\u00b0\u00b1\5\66\34\2\u00b1"+
		"\u00b2\5N(\2\u00b2\u00c8\3\2\2\2\u00b3\u00b4\5<\37\2\u00b4\u00b5\5L\'"+
		"\2\u00b5\u00b7\7\32\2\2\u00b6\u00b8\5 \21\2\u00b7\u00b6\3\2\2\2\u00b7"+
		"\u00b8\3\2\2\2\u00b8\u00b9\3\2\2\2\u00b9\u00ba\7\33\2\2\u00ba\u00bb\7"+
		"%\2\2\u00bb\u00bc\5\66\34\2\u00bc\u00bd\5N(\2\u00bd\u00c8\3\2\2\2\u00be"+
		"\u00c0\7\32\2\2\u00bf\u00c1\5 \21\2\u00c0\u00bf\3\2\2\2\u00c0\u00c1\3"+
		"\2\2\2\u00c1\u00c2\3\2\2\2\u00c2\u00c3\7\33\2\2\u00c3\u00c4\7%\2\2\u00c4"+
		"\u00c5\5\66\34\2\u00c5\u00c6\5N(\2\u00c6\u00c8\3\2\2\2\u00c7\u00a9\3\2"+
		"\2\2\u00c7\u00b3\3\2\2\2\u00c7\u00be\3\2\2\2\u00c8\33\3\2\2\2\u00c9\u00ca"+
		"\7\r\2\2\u00ca\u00cb\7\65\2\2\u00cb\u00cc\5P)\2\u00cc\35\3\2\2\2\u00cd"+
		"\u00ce\7\f\2\2\u00ce\u00d1\7\65\2\2\u00cf\u00d0\7#\2\2\u00d0\u00d2\5D"+
		"#\2\u00d1\u00cf\3\2\2\2\u00d1\u00d2\3\2\2\2\u00d2\u00d3\3\2\2\2\u00d3"+
		"\u00d4\5R*\2\u00d4\37\3\2\2\2\u00d5\u00da\5\"\22\2\u00d6\u00d7\7\27\2"+
		"\2\u00d7\u00d9\5\"\22\2\u00d8\u00d6\3\2\2\2\u00d9\u00dc\3\2\2\2\u00da"+
		"\u00d8\3\2\2\2\u00da\u00db\3\2\2\2\u00db!\3\2\2\2\u00dc\u00da\3\2\2\2"+
		"\u00dd\u00e1\5\30\r\2\u00de\u00e1\5(\25\2\u00df\u00e1\5*\26\2\u00e0\u00dd"+
		"\3\2\2\2\u00e0\u00de\3\2\2\2\u00e0\u00df\3\2\2\2\u00e1#\3\2\2\2\u00e2"+
		"\u00e3\7\16\2\2\u00e3\u00e4\5L\'\2\u00e4\u00e6\7\32\2\2\u00e5\u00e7\5"+
		"8\35\2\u00e6\u00e5\3\2\2\2\u00e6\u00e7\3\2\2\2\u00e7\u00e8\3\2\2\2\u00e8"+
		"\u00e9\7\33\2\2\u00e9\u00ea\7%\2\2\u00ea\u00eb\5:\36\2\u00eb\u00ec\7\26"+
		"\2\2\u00ec\u00f8\3\2\2\2\u00ed\u00ee\5L\'\2\u00ee\u00f0\7\32\2\2\u00ef"+
		"\u00f1\58\35\2\u00f0\u00ef\3\2\2\2\u00f0\u00f1\3\2\2\2\u00f1\u00f2\3\2"+
		"\2\2\u00f2\u00f3\7\33\2\2\u00f3\u00f4\7%\2\2\u00f4\u00f5\5:\36\2\u00f5"+
		"\u00f6\7\26\2\2\u00f6\u00f8\3\2\2\2\u00f7\u00e2\3\2\2\2\u00f7\u00ed\3"+
		"\2\2\2\u00f8%\3\2\2\2\u00f9\u00fa\5(\25\2\u00fa\u00fb\7\26\2\2\u00fb\u0103"+
		"\3\2\2\2\u00fc\u00fd\5*\26\2\u00fd\u00fe\7\26\2\2\u00fe\u0103\3\2\2\2"+
		"\u00ff\u0100\5,\27\2\u0100\u0101\7\26\2\2\u0101\u0103\3\2\2\2\u0102\u00f9"+
		"\3\2\2\2\u0102\u00fc\3\2\2\2\u0102\u00ff\3\2\2\2\u0103\'\3\2\2\2\u0104"+
		"\u0105\5D#\2\u0105\u0106\7#\2\2\u0106\u0107\5\66\34\2\u0107\u0108\7\64"+
		"\2\2\u0108\u0109\5\62\32\2\u0109)\3\2\2\2\u010a\u010b\5D#\2\u010b\u010c"+
		"\7#\2\2\u010c\u010d\7\64\2\2\u010d\u010e\5\62\32\2\u010e+\3\2\2\2\u010f"+
		"\u0110\5D#\2\u0110\u0111\7\64\2\2\u0111\u0112\5\62\32\2\u0112-\3\2\2\2"+
		"\u0113\u0114\5\60\31\2\u0114\u0115\7\26\2\2\u0115/\3\2\2\2\u0116\u0117"+
		"\5L\'\2\u0117\u0119\7\32\2\2\u0118\u011a\5\62\32\2\u0119\u0118\3\2\2\2"+
		"\u0119\u011a\3\2\2\2\u011a\u011b\3\2\2\2\u011b\u011c\7\33\2\2\u011c\u0130"+
		"\3\2\2\2\u011d\u011e\7\24\2\2\u011e\u011f\7!\2\2\u011f\u0120\5L\'\2\u0120"+
		"\u0122\7\32\2\2\u0121\u0123\5\62\32\2\u0122\u0121\3\2\2\2\u0122\u0123"+
		"\3\2\2\2\u0123\u0124\3\2\2\2\u0124\u0125\7\33\2\2\u0125\u0130\3\2\2\2"+
		"\u0126\u0127\7\65\2\2\u0127\u0128\7!\2\2\u0128\u0129\5L\'\2\u0129\u012b"+
		"\7\32\2\2\u012a\u012c\5\62\32\2\u012b\u012a\3\2\2\2\u012b\u012c\3\2\2"+
		"\2\u012c\u012d\3\2\2\2\u012d\u012e\7\33\2\2\u012e\u0130\3\2\2\2\u012f"+
		"\u0116\3\2\2\2\u012f\u011d\3\2\2\2\u012f\u0126\3\2\2\2\u0130\61\3\2\2"+
		"\2\u0131\u0136\5\64\33\2\u0132\u0133\7\27\2\2\u0133\u0135\5\64\33\2\u0134"+
		"\u0132\3\2\2\2\u0135\u0138\3\2\2\2\u0136\u0134\3\2\2\2\u0136\u0137\3\2"+
		"\2\2\u0137\63\3\2\2\2\u0138\u0136\3\2\2\2\u0139\u013a\b\33\1\2\u013a\u0147"+
		"\5F$\2\u013b\u0147\5H%\2\u013c\u0147\5T+\2\u013d\u0147\7\65\2\2\u013e"+
		"\u0147\5\60\31\2\u013f\u0140\7\32\2\2\u0140\u0141\5\64\33\2\u0141\u0142"+
		"\7\33\2\2\u0142\u0147\3\2\2\2\u0143\u0144\7+\2\2\u0144\u0147\5\64\33\b"+
		"\u0145\u0147\7\66\2\2\u0146\u0139\3\2\2\2\u0146\u013b\3\2\2\2\u0146\u013c"+
		"\3\2\2\2\u0146\u013d\3\2\2\2\u0146\u013e\3\2\2\2\u0146\u013f\3\2\2\2\u0146"+
		"\u0143\3\2\2\2\u0146\u0145\3\2\2\2\u0147\u015a\3\2\2\2\u0148\u0149\f\7"+
		"\2\2\u0149\u014a\5X-\2\u014a\u014b\5\64\33\b\u014b\u0159\3\2\2\2\u014c"+
		"\u014d\f\6\2\2\u014d\u014e\5V,\2\u014e\u014f\5\64\33\7\u014f\u0159\3\2"+
		"\2\2\u0150\u0151\f\5\2\2\u0151\u0152\5Z.\2\u0152\u0153\5\64\33\6\u0153"+
		"\u0159\3\2\2\2\u0154\u0155\f\4\2\2\u0155\u0156\5\\/\2\u0156\u0157\5\64"+
		"\33\5\u0157\u0159\3\2\2\2\u0158\u0148\3\2\2\2\u0158\u014c\3\2\2\2\u0158"+
		"\u0150\3\2\2\2\u0158\u0154\3\2\2\2\u0159\u015c\3\2\2\2\u015a\u0158\3\2"+
		"\2\2\u015a\u015b\3\2\2\2\u015b\65\3\2\2\2\u015c\u015a\3\2\2\2\u015d\u0162"+
		"\5<\37\2\u015e\u015f\7\27\2\2\u015f\u0161\5<\37\2\u0160\u015e\3\2\2\2"+
		"\u0161\u0164\3\2\2\2\u0162\u0160\3\2\2\2\u0162\u0163\3\2\2\2\u0163\67"+
		"\3\2\2\2\u0164\u0162\3\2\2\2\u0165\u016a\5<\37\2\u0166\u0167\7\27\2\2"+
		"\u0167\u0169\5<\37\2\u0168\u0166\3\2\2\2\u0169\u016c\3\2\2\2\u016a\u0168"+
		"\3\2\2\2\u016a\u016b\3\2\2\2\u016b\u016e\3\2\2\2\u016c\u016a\3\2\2\2\u016d"+
		"\u0165\3\2\2\2\u016d\u016e\3\2\2\2\u016e9\3\2\2\2\u016f\u0174\5<\37\2"+
		"\u0170\u0171\7\27\2\2\u0171\u0173\5<\37\2\u0172\u0170\3\2\2\2\u0173\u0176"+
		"\3\2\2\2\u0174\u0172\3\2\2\2\u0174\u0175\3\2\2\2\u0175;\3\2\2\2\u0176"+
		"\u0174\3\2\2\2\u0177\u017d\5> \2\u0178\u017d\5@!\2\u0179\u017d\5B\"\2"+
		"\u017a\u017d\7\16\2\2\u017b\u017d\7\65\2\2\u017c\u0177\3\2\2\2\u017c\u0178"+
		"\3\2\2\2\u017c\u0179\3\2\2\2\u017c\u017a\3\2\2\2\u017c\u017b\3\2\2\2\u017d"+
		"=\3\2\2\2\u017e\u017f\7\65\2\2\u017f\u0180\7\32\2\2\u0180\u0181\58\35"+
		"\2\u0181\u0182\7\33\2\2\u0182\u0183\7%\2\2\u0183\u0184\5:\36\2\u0184?"+
		"\3\2\2\2\u0185\u0186\7\32\2\2\u0186\u0187\58\35\2\u0187\u0188\7\33\2\2"+
		"\u0188\u0189\7%\2\2\u0189\u018a\5:\36\2\u018aA\3\2\2\2\u018b\u018c\7\34"+
		"\2\2\u018c\u018d\5<\37\2\u018d\u018e\7\35\2\2\u018eC\3\2\2\2\u018f\u0194"+
		"\7\65\2\2\u0190\u0191\7\27\2\2\u0191\u0193\7\65\2\2\u0192\u0190\3\2\2"+
		"\2\u0193\u0196\3\2\2\2\u0194\u0192\3\2\2\2\u0194\u0195\3\2\2\2\u0195E"+
		"\3\2\2\2\u0196\u0194\3\2\2\2\u0197\u0198\t\2\2\2\u0198G\3\2\2\2\u0199"+
		"\u01a2\7\34\2\2\u019a\u019f\5J&\2\u019b\u019c\7\27\2\2\u019c\u019e\5J"+
		"&\2\u019d\u019b\3\2\2\2\u019e\u01a1\3\2\2\2\u019f\u019d\3\2\2\2\u019f"+
		"\u01a0\3\2\2\2\u01a0\u01a3\3\2\2\2\u01a1\u019f\3\2\2\2\u01a2\u019a\3\2"+
		"\2\2\u01a2\u01a3\3\2\2\2\u01a3\u01a4\3\2\2\2\u01a4\u01a5\7\35\2\2\u01a5"+
		"I\3\2\2\2\u01a6\u01ac\5\64\33\2\u01a7\u01a8\5\64\33\2\u01a8\u01a9\7 \2"+
		"\2\u01a9\u01aa\5\64\33\2\u01aa\u01ac\3\2\2\2\u01ab\u01a6\3\2\2\2\u01ab"+
		"\u01a7\3\2\2\2\u01acK\3\2\2\2\u01ad\u01ae\7\65\2\2\u01aeM\3\2\2\2\u01af"+
		"\u01b3\7\30\2\2\u01b0\u01b2\5\4\3\2\u01b1\u01b0\3\2\2\2\u01b2\u01b5\3"+
		"\2\2\2\u01b3\u01b1\3\2\2\2\u01b3\u01b4\3\2\2\2\u01b4\u01b6\3\2\2\2\u01b5"+
		"\u01b3\3\2\2\2\u01b6\u01b7\7\31\2\2\u01b7O\3\2\2\2\u01b8\u01bc\7\30\2"+
		"\2\u01b9\u01bb\5$\23\2\u01ba\u01b9\3\2\2\2\u01bb\u01be\3\2\2\2\u01bc\u01ba"+
		"\3\2\2\2\u01bc\u01bd\3\2\2\2\u01bd\u01bf\3\2\2\2\u01be\u01bc\3\2\2\2\u01bf"+
		"\u01c0\7\31\2\2\u01c0Q\3\2\2\2\u01c1\u01cb\7\30\2\2\u01c2\u01ca\5\26\f"+
		"\2\u01c3\u01c4\5*\26\2\u01c4\u01c5\7\26\2\2\u01c5\u01ca\3\2\2\2\u01c6"+
		"\u01c7\5(\25\2\u01c7\u01c8\7\26\2\2\u01c8\u01ca\3\2\2\2\u01c9\u01c2\3"+
		"\2\2\2\u01c9\u01c3\3\2\2\2\u01c9\u01c6\3\2\2\2\u01ca\u01cd\3\2\2\2\u01cb"+
		"\u01c9\3\2\2\2\u01cb\u01cc\3\2\2\2\u01cc\u01ce\3\2\2\2\u01cd\u01cb\3\2"+
		"\2\2\u01ce\u01cf\7\31\2\2\u01cfS\3\2\2\2\u01d0\u01d1\7\65\2\2\u01d1\u01d2"+
		"\7!\2\2\u01d2\u01d7\7\65\2\2\u01d3\u01d4\7\24\2\2\u01d4\u01d5\7!\2\2\u01d5"+
		"\u01d7\7\65\2\2\u01d6\u01d0\3\2\2\2\u01d6\u01d3\3\2\2\2\u01d7U\3\2\2\2"+
		"\u01d8\u01d9\t\3\2\2\u01d9W\3\2\2\2\u01da\u01db\t\4\2\2\u01dbY\3\2\2\2"+
		"\u01dc\u01dd\t\5\2\2\u01dd[\3\2\2\2\u01de\u01df\t\6\2\2\u01df]\3\2\2\2"+
		"*aq|\u0083\u0087\u009b\u00a0\u00ac\u00b7\u00c0\u00c7\u00d1\u00da\u00e0"+
		"\u00e6\u00f0\u00f7\u0102\u0119\u0122\u012b\u012f\u0136\u0146\u0158\u015a"+
		"\u0162\u016a\u016d\u0174\u017c\u0194\u019f\u01a2\u01ab\u01b3\u01bc\u01c9"+
		"\u01cb\u01d6";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}