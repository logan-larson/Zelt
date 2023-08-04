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
		WS=8, PRINT=9, STRUCT=10, INTERFACE=11, IF=12, ELSE=13, WHILE=14, CALLER=15, 
		RETURN=16, SEMICOLON=17, COMMA=18, LEFT_BRACE=19, RIGHT_BRACE=20, LEFT_PAREN=21, 
		RIGHT_PAREN=22, LEFT_BRACKET=23, RIGHT_BRACKET=24, QUESTION_MARK=25, ELLIPSIS=26, 
		PERIOD=27, COLON=28, ARROW=29, PLUS=30, MINUS=31, MULTIPLY=32, DIVIDE=33, 
		MODULO=34, NOT=35, AND=36, OR=37, EQUALS=38, NOT_EQUALS=39, LESS_THAN=40, 
		LESS_THAN_OR_EQUAL=41, GREATER_THAN=42, GREATER_THAN_OR_EQUAL=43, IS_DEFINED_AS=44, 
		IDENTIFIER=45, UNDERSCORE=46, CLOSE_COMMENT=47, NESTED_COMMENT=48, ANY_OTHER=49;
	public static final int
		RULE_program = 0, RULE_line = 1, RULE_statement = 2, RULE_printStatement = 3, 
		RULE_ifStatement = 4, RULE_elseIfStatement = 5, RULE_whileStatement = 6, 
		RULE_returnStatement = 7, RULE_declarationStatement = 8, RULE_declaration = 9, 
		RULE_functionDeclaration = 10, RULE_parameterDeclarationList = 11, RULE_parameterDeclaration = 12, 
		RULE_assignmentStatement = 13, RULE_assignment = 14, RULE_inferAssignment = 15, 
		RULE_simpleAssignment = 16, RULE_functionCall = 17, RULE_expressionList = 18, 
		RULE_expression = 19, RULE_typeList = 20, RULE_parameterTypeList = 21, 
		RULE_returnTypeList = 22, RULE_type = 23, RULE_identifierList = 24, RULE_literal = 25, 
		RULE_functionIdentifier = 26, RULE_block = 27, RULE_accessor = 28, RULE_addOp = 29, 
		RULE_multOp = 30, RULE_relOp = 31, RULE_boolOp = 32;
	private static String[] makeRuleNames() {
		return new String[] {
			"program", "line", "statement", "printStatement", "ifStatement", "elseIfStatement", 
			"whileStatement", "returnStatement", "declarationStatement", "declaration", 
			"functionDeclaration", "parameterDeclarationList", "parameterDeclaration", 
			"assignmentStatement", "assignment", "inferAssignment", "simpleAssignment", 
			"functionCall", "expressionList", "expression", "typeList", "parameterTypeList", 
			"returnTypeList", "type", "identifierList", "literal", "functionIdentifier", 
			"block", "accessor", "addOp", "multOp", "relOp", "boolOp"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, null, null, null, null, "'null'", null, null, null, "'print'", 
			"'struct'", "'interface'", "'if'", "'else'", "'while'", "'caller'", "'return'", 
			"';'", "','", "'{'", "'}'", "'('", "')'", "'['", "']'", "'?'", "'...'", 
			"'.'", "':'", "'->'", "'+'", "'-'", "'*'", "'/'", "'%'", "'!'", "'&&'", 
			"'||'", "'=='", "'!='", "'<'", "'<='", "'>'", "'>='", "'='", null, "'_'", 
			"'*/'"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, "INTEGER", "FLOAT", "STRING", "BOOL", "NULL", "COMMENT", "MULTILINE_COMMENT", 
			"WS", "PRINT", "STRUCT", "INTERFACE", "IF", "ELSE", "WHILE", "CALLER", 
			"RETURN", "SEMICOLON", "COMMA", "LEFT_BRACE", "RIGHT_BRACE", "LEFT_PAREN", 
			"RIGHT_PAREN", "LEFT_BRACKET", "RIGHT_BRACKET", "QUESTION_MARK", "ELLIPSIS", 
			"PERIOD", "COLON", "ARROW", "PLUS", "MINUS", "MULTIPLY", "DIVIDE", "MODULO", 
			"NOT", "AND", "OR", "EQUALS", "NOT_EQUALS", "LESS_THAN", "LESS_THAN_OR_EQUAL", 
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
			setState(69);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==PRINT || _la==IDENTIFIER) {
				{
				{
				setState(66);
				line();
				}
				}
				setState(71);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(72);
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
			setState(74);
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
		public PrintStatementContext printStatement() {
			return getRuleContext(PrintStatementContext.class,0);
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
			setState(79);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,1,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(76);
				declarationStatement();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(77);
				assignmentStatement();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(78);
				printStatement();
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
			setState(81);
			match(PRINT);
			setState(82);
			match(LEFT_PAREN);
			setState(83);
			expression(0);
			setState(84);
			match(RIGHT_PAREN);
			setState(85);
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
		enterRule(_localctx, 8, RULE_ifStatement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(87);
			match(IF);
			setState(88);
			expression(0);
			setState(89);
			block();
			setState(92);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,2,_ctx) ) {
			case 1:
				{
				setState(90);
				match(ELSE);
				setState(91);
				elseIfStatement();
				}
				break;
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
		enterRule(_localctx, 10, RULE_elseIfStatement);
		try {
			setState(96);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case IF:
				enterOuterAlt(_localctx, 1);
				{
				setState(94);
				ifStatement();
				}
				break;
			case LEFT_BRACE:
				enterOuterAlt(_localctx, 2);
				{
				setState(95);
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
		enterRule(_localctx, 12, RULE_whileStatement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(98);
			match(WHILE);
			setState(99);
			expression(0);
			setState(100);
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
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public TerminalNode SEMICOLON() { return getToken(ZeltParser.SEMICOLON, 0); }
		public List<TerminalNode> COMMA() { return getTokens(ZeltParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(ZeltParser.COMMA, i);
		}
		public List<AssignmentContext> assignment() {
			return getRuleContexts(AssignmentContext.class);
		}
		public AssignmentContext assignment(int i) {
			return getRuleContext(AssignmentContext.class,i);
		}
		public ReturnStatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_returnStatement; }
	}

	public final ReturnStatementContext returnStatement() throws RecognitionException {
		ReturnStatementContext _localctx = new ReturnStatementContext(_ctx, getState());
		enterRule(_localctx, 14, RULE_returnStatement);
		int _la;
		try {
			setState(130);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,6,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(102);
				match(RETURN);
				setState(103);
				expression(0);
				setState(104);
				match(SEMICOLON);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(106);
				match(RETURN);
				setState(107);
				match(SEMICOLON);
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(108);
				match(RETURN);
				setState(109);
				expression(0);
				setState(114);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(110);
					match(COMMA);
					setState(111);
					expression(0);
					}
					}
					setState(116);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				setState(117);
				match(SEMICOLON);
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(119);
				match(RETURN);
				setState(120);
				assignment();
				setState(125);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(121);
					match(COMMA);
					setState(122);
					assignment();
					}
					}
					setState(127);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				setState(128);
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
		enterRule(_localctx, 16, RULE_declarationStatement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(132);
			declaration();
			setState(133);
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
		enterRule(_localctx, 18, RULE_declaration);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(135);
			identifierList();
			setState(136);
			match(COLON);
			setState(137);
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
		public TerminalNode ARROW() { return getToken(ZeltParser.ARROW, 0); }
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
		enterRule(_localctx, 20, RULE_functionDeclaration);
		int _la;
		try {
			setState(169);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,10,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(139);
				functionIdentifier();
				setState(140);
				match(LEFT_PAREN);
				setState(142);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==IDENTIFIER) {
					{
					setState(141);
					parameterDeclarationList();
					}
				}

				setState(144);
				match(RIGHT_PAREN);
				setState(145);
				match(ARROW);
				setState(146);
				typeList();
				setState(147);
				block();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(149);
				type(0);
				setState(150);
				functionIdentifier();
				setState(151);
				match(LEFT_PAREN);
				setState(153);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==IDENTIFIER) {
					{
					setState(152);
					parameterDeclarationList();
					}
				}

				setState(155);
				match(RIGHT_PAREN);
				setState(156);
				match(ARROW);
				setState(157);
				typeList();
				setState(158);
				block();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(160);
				match(LEFT_PAREN);
				setState(162);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==IDENTIFIER) {
					{
					setState(161);
					parameterDeclarationList();
					}
				}

				setState(164);
				match(RIGHT_PAREN);
				setState(165);
				match(ARROW);
				setState(166);
				typeList();
				setState(167);
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
		enterRule(_localctx, 22, RULE_parameterDeclarationList);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(171);
			parameterDeclaration();
			setState(176);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(172);
				match(COMMA);
				setState(173);
				parameterDeclaration();
				}
				}
				setState(178);
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
		enterRule(_localctx, 24, RULE_parameterDeclaration);
		try {
			setState(182);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,12,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(179);
				declaration();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(180);
				assignment();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(181);
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
		enterRule(_localctx, 26, RULE_assignmentStatement);
		try {
			setState(193);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,13,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(184);
				assignment();
				setState(185);
				match(SEMICOLON);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(187);
				inferAssignment();
				setState(188);
				match(SEMICOLON);
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(190);
				simpleAssignment();
				setState(191);
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
		enterRule(_localctx, 28, RULE_assignment);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(195);
			identifierList();
			setState(196);
			match(COLON);
			setState(197);
			typeList();
			setState(198);
			match(IS_DEFINED_AS);
			setState(199);
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
		enterRule(_localctx, 30, RULE_inferAssignment);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(201);
			identifierList();
			setState(202);
			match(COLON);
			setState(203);
			match(IS_DEFINED_AS);
			setState(204);
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
		enterRule(_localctx, 32, RULE_simpleAssignment);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(206);
			identifierList();
			setState(207);
			match(IS_DEFINED_AS);
			setState(208);
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

	public static class FunctionCallContext extends ParserRuleContext {
		public FunctionIdentifierContext functionIdentifier() {
			return getRuleContext(FunctionIdentifierContext.class,0);
		}
		public TerminalNode LEFT_PAREN() { return getToken(ZeltParser.LEFT_PAREN, 0); }
		public TerminalNode RIGHT_PAREN() { return getToken(ZeltParser.RIGHT_PAREN, 0); }
		public ExpressionListContext expressionList() {
			return getRuleContext(ExpressionListContext.class,0);
		}
		public TerminalNode IDENTIFIER() { return getToken(ZeltParser.IDENTIFIER, 0); }
		public TerminalNode PERIOD() { return getToken(ZeltParser.PERIOD, 0); }
		public FunctionCallContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_functionCall; }
	}

	public final FunctionCallContext functionCall() throws RecognitionException {
		FunctionCallContext _localctx = new FunctionCallContext(_ctx, getState());
		enterRule(_localctx, 34, RULE_functionCall);
		int _la;
		try {
			setState(226);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,16,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(210);
				functionIdentifier();
				setState(211);
				match(LEFT_PAREN);
				setState(213);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << INTEGER) | (1L << FLOAT) | (1L << STRING) | (1L << BOOL) | (1L << NULL) | (1L << CALLER) | (1L << LEFT_PAREN) | (1L << NOT) | (1L << IDENTIFIER) | (1L << UNDERSCORE))) != 0)) {
					{
					setState(212);
					expressionList();
					}
				}

				setState(215);
				match(RIGHT_PAREN);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(217);
				match(IDENTIFIER);
				setState(218);
				match(PERIOD);
				setState(219);
				functionIdentifier();
				setState(220);
				match(LEFT_PAREN);
				setState(222);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << INTEGER) | (1L << FLOAT) | (1L << STRING) | (1L << BOOL) | (1L << NULL) | (1L << CALLER) | (1L << LEFT_PAREN) | (1L << NOT) | (1L << IDENTIFIER) | (1L << UNDERSCORE))) != 0)) {
					{
					setState(221);
					expressionList();
					}
				}

				setState(224);
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
		public TerminalNode ELLIPSIS() { return getToken(ZeltParser.ELLIPSIS, 0); }
		public ExpressionListContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_expressionList; }
	}

	public final ExpressionListContext expressionList() throws RecognitionException {
		ExpressionListContext _localctx = new ExpressionListContext(_ctx, getState());
		enterRule(_localctx, 36, RULE_expressionList);
		try {
			int _alt;
			setState(247);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,19,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(228);
				expression(0);
				setState(233);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,17,_ctx);
				while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
					if ( _alt==1 ) {
						{
						{
						setState(229);
						match(COMMA);
						setState(230);
						expression(0);
						}
						} 
					}
					setState(235);
					_errHandler.sync(this);
					_alt = getInterpreter().adaptivePredict(_input,17,_ctx);
				}
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(236);
				expression(0);
				setState(241);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,18,_ctx);
				while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
					if ( _alt==1 ) {
						{
						{
						setState(237);
						match(COMMA);
						setState(238);
						expression(0);
						}
						} 
					}
					setState(243);
					_errHandler.sync(this);
					_alt = getInterpreter().adaptivePredict(_input,18,_ctx);
				}
				setState(244);
				match(COMMA);
				setState(245);
				match(ELLIPSIS);
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
	public static class FunctionCallExpressionContext extends ExpressionContext {
		public FunctionCallContext functionCall() {
			return getRuleContext(FunctionCallContext.class,0);
		}
		public FunctionCallExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
	}
	public static class AssignmentExpressionContext extends ExpressionContext {
		public AssignmentContext assignment() {
			return getRuleContext(AssignmentContext.class,0);
		}
		public AssignmentExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
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
	public static class CallerExpressionContext extends ExpressionContext {
		public TerminalNode CALLER() { return getToken(ZeltParser.CALLER, 0); }
		public TerminalNode PERIOD() { return getToken(ZeltParser.PERIOD, 0); }
		public TerminalNode IDENTIFIER() { return getToken(ZeltParser.IDENTIFIER, 0); }
		public CallerExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
	}

	public final ExpressionContext expression() throws RecognitionException {
		return expression(0);
	}

	private ExpressionContext expression(int _p) throws RecognitionException {
		ParserRuleContext _parentctx = _ctx;
		int _parentState = getState();
		ExpressionContext _localctx = new ExpressionContext(_ctx, _parentState);
		ExpressionContext _prevctx = _localctx;
		int _startState = 38;
		enterRecursionRule(_localctx, 38, RULE_expression, _p);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(264);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,20,_ctx) ) {
			case 1:
				{
				_localctx = new LiteralExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;

				setState(250);
				literal();
				}
				break;
			case 2:
				{
				_localctx = new AccessorExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(251);
				accessor();
				}
				break;
			case 3:
				{
				_localctx = new FunctionCallExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(252);
				functionCall();
				}
				break;
			case 4:
				{
				_localctx = new AssignmentExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(253);
				assignment();
				}
				break;
			case 5:
				{
				_localctx = new ParenExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(254);
				match(LEFT_PAREN);
				setState(255);
				expression(0);
				setState(256);
				match(RIGHT_PAREN);
				}
				break;
			case 6:
				{
				_localctx = new NotExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(258);
				match(NOT);
				setState(259);
				expression(7);
				}
				break;
			case 7:
				{
				_localctx = new CallerExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(260);
				match(CALLER);
				setState(261);
				match(PERIOD);
				setState(262);
				match(IDENTIFIER);
				}
				break;
			case 8:
				{
				_localctx = new UnderscoreExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(263);
				match(UNDERSCORE);
				}
				break;
			}
			_ctx.stop = _input.LT(-1);
			setState(284);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,22,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					setState(282);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,21,_ctx) ) {
					case 1:
						{
						_localctx = new MultExpressionContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(266);
						if (!(precpred(_ctx, 6))) throw new FailedPredicateException(this, "precpred(_ctx, 6)");
						setState(267);
						multOp();
						setState(268);
						expression(7);
						}
						break;
					case 2:
						{
						_localctx = new AddExpressionContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(270);
						if (!(precpred(_ctx, 5))) throw new FailedPredicateException(this, "precpred(_ctx, 5)");
						setState(271);
						addOp();
						setState(272);
						expression(6);
						}
						break;
					case 3:
						{
						_localctx = new RelationalExpressionContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(274);
						if (!(precpred(_ctx, 4))) throw new FailedPredicateException(this, "precpred(_ctx, 4)");
						setState(275);
						relOp();
						setState(276);
						expression(5);
						}
						break;
					case 4:
						{
						_localctx = new BoolOpExpressionContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(278);
						if (!(precpred(_ctx, 3))) throw new FailedPredicateException(this, "precpred(_ctx, 3)");
						setState(279);
						boolOp();
						setState(280);
						expression(4);
						}
						break;
					}
					} 
				}
				setState(286);
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
		public TerminalNode ELLIPSIS() { return getToken(ZeltParser.ELLIPSIS, 0); }
		public TypeListContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_typeList; }
	}

	public final TypeListContext typeList() throws RecognitionException {
		TypeListContext _localctx = new TypeListContext(_ctx, getState());
		enterRule(_localctx, 40, RULE_typeList);
		try {
			int _alt;
			setState(306);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,25,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(287);
				type(0);
				setState(292);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,23,_ctx);
				while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
					if ( _alt==1 ) {
						{
						{
						setState(288);
						match(COMMA);
						setState(289);
						type(0);
						}
						} 
					}
					setState(294);
					_errHandler.sync(this);
					_alt = getInterpreter().adaptivePredict(_input,23,_ctx);
				}
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(295);
				type(0);
				setState(300);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,24,_ctx);
				while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
					if ( _alt==1 ) {
						{
						{
						setState(296);
						match(COMMA);
						setState(297);
						type(0);
						}
						} 
					}
					setState(302);
					_errHandler.sync(this);
					_alt = getInterpreter().adaptivePredict(_input,24,_ctx);
				}
				setState(303);
				match(COMMA);
				setState(304);
				match(ELLIPSIS);
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
		enterRule(_localctx, 42, RULE_parameterTypeList);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(316);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << LEFT_PAREN) | (1L << LEFT_BRACKET) | (1L << IDENTIFIER))) != 0)) {
				{
				setState(308);
				type(0);
				setState(313);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(309);
					match(COMMA);
					setState(310);
					type(0);
					}
					}
					setState(315);
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
		enterRule(_localctx, 44, RULE_returnTypeList);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(318);
			type(0);
			setState(323);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,28,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					{
					{
					setState(319);
					match(COMMA);
					setState(320);
					type(0);
					}
					} 
				}
				setState(325);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,28,_ctx);
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
		public TerminalNode LEFT_PAREN() { return getToken(ZeltParser.LEFT_PAREN, 0); }
		public ParameterTypeListContext parameterTypeList() {
			return getRuleContext(ParameterTypeListContext.class,0);
		}
		public TerminalNode RIGHT_PAREN() { return getToken(ZeltParser.RIGHT_PAREN, 0); }
		public TerminalNode ARROW() { return getToken(ZeltParser.ARROW, 0); }
		public ReturnTypeListContext returnTypeList() {
			return getRuleContext(ReturnTypeListContext.class,0);
		}
		public TerminalNode LEFT_BRACKET() { return getToken(ZeltParser.LEFT_BRACKET, 0); }
		public List<TypeContext> type() {
			return getRuleContexts(TypeContext.class);
		}
		public TypeContext type(int i) {
			return getRuleContext(TypeContext.class,i);
		}
		public TerminalNode RIGHT_BRACKET() { return getToken(ZeltParser.RIGHT_BRACKET, 0); }
		public TerminalNode IDENTIFIER() { return getToken(ZeltParser.IDENTIFIER, 0); }
		public TypeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_type; }
	}

	public final TypeContext type() throws RecognitionException {
		return type(0);
	}

	private TypeContext type(int _p) throws RecognitionException {
		ParserRuleContext _parentctx = _ctx;
		int _parentState = getState();
		TypeContext _localctx = new TypeContext(_ctx, _parentState);
		TypeContext _prevctx = _localctx;
		int _startState = 46;
		enterRecursionRule(_localctx, 46, RULE_type, _p);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(344);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,29,_ctx) ) {
			case 1:
				{
				setState(327);
				match(LEFT_PAREN);
				setState(328);
				parameterTypeList();
				setState(329);
				match(RIGHT_PAREN);
				setState(330);
				match(ARROW);
				setState(331);
				returnTypeList();
				}
				break;
			case 2:
				{
				setState(333);
				match(LEFT_BRACKET);
				setState(334);
				type(0);
				setState(335);
				match(RIGHT_BRACKET);
				}
				break;
			case 3:
				{
				setState(337);
				match(LEFT_BRACKET);
				setState(338);
				type(0);
				setState(339);
				match(ARROW);
				setState(340);
				type(0);
				setState(341);
				match(RIGHT_BRACKET);
				}
				break;
			case 4:
				{
				setState(343);
				match(IDENTIFIER);
				}
				break;
			}
			_ctx.stop = _input.LT(-1);
			setState(355);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,30,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					{
					_localctx = new TypeContext(_parentctx, _parentState);
					pushNewRecursionContext(_localctx, _startState, RULE_type);
					setState(346);
					if (!(precpred(_ctx, 5))) throw new FailedPredicateException(this, "precpred(_ctx, 5)");
					setState(347);
					match(LEFT_PAREN);
					setState(348);
					parameterTypeList();
					setState(349);
					match(RIGHT_PAREN);
					setState(350);
					match(ARROW);
					setState(351);
					returnTypeList();
					}
					} 
				}
				setState(357);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,30,_ctx);
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
		enterRule(_localctx, 48, RULE_identifierList);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(358);
			match(IDENTIFIER);
			setState(363);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(359);
				match(COMMA);
				setState(360);
				match(IDENTIFIER);
				}
				}
				setState(365);
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
		enterRule(_localctx, 50, RULE_literal);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(366);
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

	public static class FunctionIdentifierContext extends ParserRuleContext {
		public TerminalNode IDENTIFIER() { return getToken(ZeltParser.IDENTIFIER, 0); }
		public FunctionIdentifierContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_functionIdentifier; }
	}

	public final FunctionIdentifierContext functionIdentifier() throws RecognitionException {
		FunctionIdentifierContext _localctx = new FunctionIdentifierContext(_ctx, getState());
		enterRule(_localctx, 52, RULE_functionIdentifier);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(368);
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
		enterRule(_localctx, 54, RULE_block);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(370);
			match(LEFT_BRACE);
			setState(374);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==PRINT || _la==IDENTIFIER) {
				{
				{
				setState(371);
				line();
				}
				}
				setState(376);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(377);
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
		enterRule(_localctx, 56, RULE_accessor);
		try {
			setState(385);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case IDENTIFIER:
				enterOuterAlt(_localctx, 1);
				{
				setState(379);
				match(IDENTIFIER);
				setState(380);
				match(PERIOD);
				setState(381);
				match(IDENTIFIER);
				}
				break;
			case CALLER:
				enterOuterAlt(_localctx, 2);
				{
				setState(382);
				match(CALLER);
				setState(383);
				match(PERIOD);
				setState(384);
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
		enterRule(_localctx, 58, RULE_addOp);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(387);
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
		enterRule(_localctx, 60, RULE_multOp);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(389);
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
		enterRule(_localctx, 62, RULE_relOp);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(391);
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
		enterRule(_localctx, 64, RULE_boolOp);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(393);
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
		case 19:
			return expression_sempred((ExpressionContext)_localctx, predIndex);
		case 23:
			return type_sempred((TypeContext)_localctx, predIndex);
		}
		return true;
	}
	private boolean expression_sempred(ExpressionContext _localctx, int predIndex) {
		switch (predIndex) {
		case 0:
			return precpred(_ctx, 6);
		case 1:
			return precpred(_ctx, 5);
		case 2:
			return precpred(_ctx, 4);
		case 3:
			return precpred(_ctx, 3);
		}
		return true;
	}
	private boolean type_sempred(TypeContext _localctx, int predIndex) {
		switch (predIndex) {
		case 4:
			return precpred(_ctx, 5);
		}
		return true;
	}

	public static final String _serializedATN =
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\3\63\u018e\4\2\t\2"+
		"\4\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13"+
		"\t\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4\31\t\31"+
		"\4\32\t\32\4\33\t\33\4\34\t\34\4\35\t\35\4\36\t\36\4\37\t\37\4 \t \4!"+
		"\t!\4\"\t\"\3\2\7\2F\n\2\f\2\16\2I\13\2\3\2\3\2\3\3\3\3\3\4\3\4\3\4\5"+
		"\4R\n\4\3\5\3\5\3\5\3\5\3\5\3\5\3\6\3\6\3\6\3\6\3\6\5\6_\n\6\3\7\3\7\5"+
		"\7c\n\7\3\b\3\b\3\b\3\b\3\t\3\t\3\t\3\t\3\t\3\t\3\t\3\t\3\t\3\t\7\ts\n"+
		"\t\f\t\16\tv\13\t\3\t\3\t\3\t\3\t\3\t\3\t\7\t~\n\t\f\t\16\t\u0081\13\t"+
		"\3\t\3\t\5\t\u0085\n\t\3\n\3\n\3\n\3\13\3\13\3\13\3\13\3\f\3\f\3\f\5\f"+
		"\u0091\n\f\3\f\3\f\3\f\3\f\3\f\3\f\3\f\3\f\3\f\5\f\u009c\n\f\3\f\3\f\3"+
		"\f\3\f\3\f\3\f\3\f\5\f\u00a5\n\f\3\f\3\f\3\f\3\f\3\f\5\f\u00ac\n\f\3\r"+
		"\3\r\3\r\7\r\u00b1\n\r\f\r\16\r\u00b4\13\r\3\16\3\16\3\16\5\16\u00b9\n"+
		"\16\3\17\3\17\3\17\3\17\3\17\3\17\3\17\3\17\3\17\5\17\u00c4\n\17\3\20"+
		"\3\20\3\20\3\20\3\20\3\20\3\21\3\21\3\21\3\21\3\21\3\22\3\22\3\22\3\22"+
		"\3\23\3\23\3\23\5\23\u00d8\n\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\5\23"+
		"\u00e1\n\23\3\23\3\23\5\23\u00e5\n\23\3\24\3\24\3\24\7\24\u00ea\n\24\f"+
		"\24\16\24\u00ed\13\24\3\24\3\24\3\24\7\24\u00f2\n\24\f\24\16\24\u00f5"+
		"\13\24\3\24\3\24\3\24\5\24\u00fa\n\24\3\25\3\25\3\25\3\25\3\25\3\25\3"+
		"\25\3\25\3\25\3\25\3\25\3\25\3\25\3\25\3\25\5\25\u010b\n\25\3\25\3\25"+
		"\3\25\3\25\3\25\3\25\3\25\3\25\3\25\3\25\3\25\3\25\3\25\3\25\3\25\3\25"+
		"\7\25\u011d\n\25\f\25\16\25\u0120\13\25\3\26\3\26\3\26\7\26\u0125\n\26"+
		"\f\26\16\26\u0128\13\26\3\26\3\26\3\26\7\26\u012d\n\26\f\26\16\26\u0130"+
		"\13\26\3\26\3\26\3\26\5\26\u0135\n\26\3\27\3\27\3\27\7\27\u013a\n\27\f"+
		"\27\16\27\u013d\13\27\5\27\u013f\n\27\3\30\3\30\3\30\7\30\u0144\n\30\f"+
		"\30\16\30\u0147\13\30\3\31\3\31\3\31\3\31\3\31\3\31\3\31\3\31\3\31\3\31"+
		"\3\31\3\31\3\31\3\31\3\31\3\31\3\31\3\31\5\31\u015b\n\31\3\31\3\31\3\31"+
		"\3\31\3\31\3\31\3\31\7\31\u0164\n\31\f\31\16\31\u0167\13\31\3\32\3\32"+
		"\3\32\7\32\u016c\n\32\f\32\16\32\u016f\13\32\3\33\3\33\3\34\3\34\3\35"+
		"\3\35\7\35\u0177\n\35\f\35\16\35\u017a\13\35\3\35\3\35\3\36\3\36\3\36"+
		"\3\36\3\36\3\36\5\36\u0184\n\36\3\37\3\37\3 \3 \3!\3!\3\"\3\"\3\"\2\4"+
		"(\60#\2\4\6\b\n\f\16\20\22\24\26\30\32\34\36 \"$&(*,.\60\62\64\668:<>"+
		"@B\2\7\3\2\3\7\3\2 !\3\2\"$\3\2(-\3\2&\'\2\u019e\2G\3\2\2\2\4L\3\2\2\2"+
		"\6Q\3\2\2\2\bS\3\2\2\2\nY\3\2\2\2\fb\3\2\2\2\16d\3\2\2\2\20\u0084\3\2"+
		"\2\2\22\u0086\3\2\2\2\24\u0089\3\2\2\2\26\u00ab\3\2\2\2\30\u00ad\3\2\2"+
		"\2\32\u00b8\3\2\2\2\34\u00c3\3\2\2\2\36\u00c5\3\2\2\2 \u00cb\3\2\2\2\""+
		"\u00d0\3\2\2\2$\u00e4\3\2\2\2&\u00f9\3\2\2\2(\u010a\3\2\2\2*\u0134\3\2"+
		"\2\2,\u013e\3\2\2\2.\u0140\3\2\2\2\60\u015a\3\2\2\2\62\u0168\3\2\2\2\64"+
		"\u0170\3\2\2\2\66\u0172\3\2\2\28\u0174\3\2\2\2:\u0183\3\2\2\2<\u0185\3"+
		"\2\2\2>\u0187\3\2\2\2@\u0189\3\2\2\2B\u018b\3\2\2\2DF\5\4\3\2ED\3\2\2"+
		"\2FI\3\2\2\2GE\3\2\2\2GH\3\2\2\2HJ\3\2\2\2IG\3\2\2\2JK\7\2\2\3K\3\3\2"+
		"\2\2LM\5\6\4\2M\5\3\2\2\2NR\5\22\n\2OR\5\34\17\2PR\5\b\5\2QN\3\2\2\2Q"+
		"O\3\2\2\2QP\3\2\2\2R\7\3\2\2\2ST\7\13\2\2TU\7\27\2\2UV\5(\25\2VW\7\30"+
		"\2\2WX\7\23\2\2X\t\3\2\2\2YZ\7\16\2\2Z[\5(\25\2[^\58\35\2\\]\7\17\2\2"+
		"]_\5\f\7\2^\\\3\2\2\2^_\3\2\2\2_\13\3\2\2\2`c\5\n\6\2ac\58\35\2b`\3\2"+
		"\2\2ba\3\2\2\2c\r\3\2\2\2de\7\20\2\2ef\5(\25\2fg\58\35\2g\17\3\2\2\2h"+
		"i\7\22\2\2ij\5(\25\2jk\7\23\2\2k\u0085\3\2\2\2lm\7\22\2\2m\u0085\7\23"+
		"\2\2no\7\22\2\2ot\5(\25\2pq\7\24\2\2qs\5(\25\2rp\3\2\2\2sv\3\2\2\2tr\3"+
		"\2\2\2tu\3\2\2\2uw\3\2\2\2vt\3\2\2\2wx\7\23\2\2x\u0085\3\2\2\2yz\7\22"+
		"\2\2z\177\5\36\20\2{|\7\24\2\2|~\5\36\20\2}{\3\2\2\2~\u0081\3\2\2\2\177"+
		"}\3\2\2\2\177\u0080\3\2\2\2\u0080\u0082\3\2\2\2\u0081\177\3\2\2\2\u0082"+
		"\u0083\7\23\2\2\u0083\u0085\3\2\2\2\u0084h\3\2\2\2\u0084l\3\2\2\2\u0084"+
		"n\3\2\2\2\u0084y\3\2\2\2\u0085\21\3\2\2\2\u0086\u0087\5\24\13\2\u0087"+
		"\u0088\7\23\2\2\u0088\23\3\2\2\2\u0089\u008a\5\62\32\2\u008a\u008b\7\36"+
		"\2\2\u008b\u008c\5*\26\2\u008c\25\3\2\2\2\u008d\u008e\5\66\34\2\u008e"+
		"\u0090\7\27\2\2\u008f\u0091\5\30\r\2\u0090\u008f\3\2\2\2\u0090\u0091\3"+
		"\2\2\2\u0091\u0092\3\2\2\2\u0092\u0093\7\30\2\2\u0093\u0094\7\37\2\2\u0094"+
		"\u0095\5*\26\2\u0095\u0096\58\35\2\u0096\u00ac\3\2\2\2\u0097\u0098\5\60"+
		"\31\2\u0098\u0099\5\66\34\2\u0099\u009b\7\27\2\2\u009a\u009c\5\30\r\2"+
		"\u009b\u009a\3\2\2\2\u009b\u009c\3\2\2\2\u009c\u009d\3\2\2\2\u009d\u009e"+
		"\7\30\2\2\u009e\u009f\7\37\2\2\u009f\u00a0\5*\26\2\u00a0\u00a1\58\35\2"+
		"\u00a1\u00ac\3\2\2\2\u00a2\u00a4\7\27\2\2\u00a3\u00a5\5\30\r\2\u00a4\u00a3"+
		"\3\2\2\2\u00a4\u00a5\3\2\2\2\u00a5\u00a6\3\2\2\2\u00a6\u00a7\7\30\2\2"+
		"\u00a7\u00a8\7\37\2\2\u00a8\u00a9\5*\26\2\u00a9\u00aa\58\35\2\u00aa\u00ac"+
		"\3\2\2\2\u00ab\u008d\3\2\2\2\u00ab\u0097\3\2\2\2\u00ab\u00a2\3\2\2\2\u00ac"+
		"\27\3\2\2\2\u00ad\u00b2\5\32\16\2\u00ae\u00af\7\24\2\2\u00af\u00b1\5\32"+
		"\16\2\u00b0\u00ae\3\2\2\2\u00b1\u00b4\3\2\2\2\u00b2\u00b0\3\2\2\2\u00b2"+
		"\u00b3\3\2\2\2\u00b3\31\3\2\2\2\u00b4\u00b2\3\2\2\2\u00b5\u00b9\5\24\13"+
		"\2\u00b6\u00b9\5\36\20\2\u00b7\u00b9\5 \21\2\u00b8\u00b5\3\2\2\2\u00b8"+
		"\u00b6\3\2\2\2\u00b8\u00b7\3\2\2\2\u00b9\33\3\2\2\2\u00ba\u00bb\5\36\20"+
		"\2\u00bb\u00bc\7\23\2\2\u00bc\u00c4\3\2\2\2\u00bd\u00be\5 \21\2\u00be"+
		"\u00bf\7\23\2\2\u00bf\u00c4\3\2\2\2\u00c0\u00c1\5\"\22\2\u00c1\u00c2\7"+
		"\23\2\2\u00c2\u00c4\3\2\2\2\u00c3\u00ba\3\2\2\2\u00c3\u00bd\3\2\2\2\u00c3"+
		"\u00c0\3\2\2\2\u00c4\35\3\2\2\2\u00c5\u00c6\5\62\32\2\u00c6\u00c7\7\36"+
		"\2\2\u00c7\u00c8\5*\26\2\u00c8\u00c9\7.\2\2\u00c9\u00ca\5&\24\2\u00ca"+
		"\37\3\2\2\2\u00cb\u00cc\5\62\32\2\u00cc\u00cd\7\36\2\2\u00cd\u00ce\7."+
		"\2\2\u00ce\u00cf\5&\24\2\u00cf!\3\2\2\2\u00d0\u00d1\5\62\32\2\u00d1\u00d2"+
		"\7.\2\2\u00d2\u00d3\5&\24\2\u00d3#\3\2\2\2\u00d4\u00d5\5\66\34\2\u00d5"+
		"\u00d7\7\27\2\2\u00d6\u00d8\5&\24\2\u00d7\u00d6\3\2\2\2\u00d7\u00d8\3"+
		"\2\2\2\u00d8\u00d9\3\2\2\2\u00d9\u00da\7\30\2\2\u00da\u00e5\3\2\2\2\u00db"+
		"\u00dc\7/\2\2\u00dc\u00dd\7\35\2\2\u00dd\u00de\5\66\34\2\u00de\u00e0\7"+
		"\27\2\2\u00df\u00e1\5&\24\2\u00e0\u00df\3\2\2\2\u00e0\u00e1\3\2\2\2\u00e1"+
		"\u00e2\3\2\2\2\u00e2\u00e3\7\30\2\2\u00e3\u00e5\3\2\2\2\u00e4\u00d4\3"+
		"\2\2\2\u00e4\u00db\3\2\2\2\u00e5%\3\2\2\2\u00e6\u00eb\5(\25\2\u00e7\u00e8"+
		"\7\24\2\2\u00e8\u00ea\5(\25\2\u00e9\u00e7\3\2\2\2\u00ea\u00ed\3\2\2\2"+
		"\u00eb\u00e9\3\2\2\2\u00eb\u00ec\3\2\2\2\u00ec\u00fa\3\2\2\2\u00ed\u00eb"+
		"\3\2\2\2\u00ee\u00f3\5(\25\2\u00ef\u00f0\7\24\2\2\u00f0\u00f2\5(\25\2"+
		"\u00f1\u00ef\3\2\2\2\u00f2\u00f5\3\2\2\2\u00f3\u00f1\3\2\2\2\u00f3\u00f4"+
		"\3\2\2\2\u00f4\u00f6\3\2\2\2\u00f5\u00f3\3\2\2\2\u00f6\u00f7\7\24\2\2"+
		"\u00f7\u00f8\7\34\2\2\u00f8\u00fa\3\2\2\2\u00f9\u00e6\3\2\2\2\u00f9\u00ee"+
		"\3\2\2\2\u00fa\'\3\2\2\2\u00fb\u00fc\b\25\1\2\u00fc\u010b\5\64\33\2\u00fd"+
		"\u010b\5:\36\2\u00fe\u010b\5$\23\2\u00ff\u010b\5\36\20\2\u0100\u0101\7"+
		"\27\2\2\u0101\u0102\5(\25\2\u0102\u0103\7\30\2\2\u0103\u010b\3\2\2\2\u0104"+
		"\u0105\7%\2\2\u0105\u010b\5(\25\t\u0106\u0107\7\21\2\2\u0107\u0108\7\35"+
		"\2\2\u0108\u010b\7/\2\2\u0109\u010b\7\60\2\2\u010a\u00fb\3\2\2\2\u010a"+
		"\u00fd\3\2\2\2\u010a\u00fe\3\2\2\2\u010a\u00ff\3\2\2\2\u010a\u0100\3\2"+
		"\2\2\u010a\u0104\3\2\2\2\u010a\u0106\3\2\2\2\u010a\u0109\3\2\2\2\u010b"+
		"\u011e\3\2\2\2\u010c\u010d\f\b\2\2\u010d\u010e\5> \2\u010e\u010f\5(\25"+
		"\t\u010f\u011d\3\2\2\2\u0110\u0111\f\7\2\2\u0111\u0112\5<\37\2\u0112\u0113"+
		"\5(\25\b\u0113\u011d\3\2\2\2\u0114\u0115\f\6\2\2\u0115\u0116\5@!\2\u0116"+
		"\u0117\5(\25\7\u0117\u011d\3\2\2\2\u0118\u0119\f\5\2\2\u0119\u011a\5B"+
		"\"\2\u011a\u011b\5(\25\6\u011b\u011d\3\2\2\2\u011c\u010c\3\2\2\2\u011c"+
		"\u0110\3\2\2\2\u011c\u0114\3\2\2\2\u011c\u0118\3\2\2\2\u011d\u0120\3\2"+
		"\2\2\u011e\u011c\3\2\2\2\u011e\u011f\3\2\2\2\u011f)\3\2\2\2\u0120\u011e"+
		"\3\2\2\2\u0121\u0126\5\60\31\2\u0122\u0123\7\24\2\2\u0123\u0125\5\60\31"+
		"\2\u0124\u0122\3\2\2\2\u0125\u0128\3\2\2\2\u0126\u0124\3\2\2\2\u0126\u0127"+
		"\3\2\2\2\u0127\u0135\3\2\2\2\u0128\u0126\3\2\2\2\u0129\u012e\5\60\31\2"+
		"\u012a\u012b\7\24\2\2\u012b\u012d\5\60\31\2\u012c\u012a\3\2\2\2\u012d"+
		"\u0130\3\2\2\2\u012e\u012c\3\2\2\2\u012e\u012f\3\2\2\2\u012f\u0131\3\2"+
		"\2\2\u0130\u012e\3\2\2\2\u0131\u0132\7\24\2\2\u0132\u0133\7\34\2\2\u0133"+
		"\u0135\3\2\2\2\u0134\u0121\3\2\2\2\u0134\u0129\3\2\2\2\u0135+\3\2\2\2"+
		"\u0136\u013b\5\60\31\2\u0137\u0138\7\24\2\2\u0138\u013a\5\60\31\2\u0139"+
		"\u0137\3\2\2\2\u013a\u013d\3\2\2\2\u013b\u0139\3\2\2\2\u013b\u013c\3\2"+
		"\2\2\u013c\u013f\3\2\2\2\u013d\u013b\3\2\2\2\u013e\u0136\3\2\2\2\u013e"+
		"\u013f\3\2\2\2\u013f-\3\2\2\2\u0140\u0145\5\60\31\2\u0141\u0142\7\24\2"+
		"\2\u0142\u0144\5\60\31\2\u0143\u0141\3\2\2\2\u0144\u0147\3\2\2\2\u0145"+
		"\u0143\3\2\2\2\u0145\u0146\3\2\2\2\u0146/\3\2\2\2\u0147\u0145\3\2\2\2"+
		"\u0148\u0149\b\31\1\2\u0149\u014a\7\27\2\2\u014a\u014b\5,\27\2\u014b\u014c"+
		"\7\30\2\2\u014c\u014d\7\37\2\2\u014d\u014e\5.\30\2\u014e\u015b\3\2\2\2"+
		"\u014f\u0150\7\31\2\2\u0150\u0151\5\60\31\2\u0151\u0152\7\32\2\2\u0152"+
		"\u015b\3\2\2\2\u0153\u0154\7\31\2\2\u0154\u0155\5\60\31\2\u0155\u0156"+
		"\7\37\2\2\u0156\u0157\5\60\31\2\u0157\u0158\7\32\2\2\u0158\u015b\3\2\2"+
		"\2\u0159\u015b\7/\2\2\u015a\u0148\3\2\2\2\u015a\u014f\3\2\2\2\u015a\u0153"+
		"\3\2\2\2\u015a\u0159\3\2\2\2\u015b\u0165\3\2\2\2\u015c\u015d\f\7\2\2\u015d"+
		"\u015e\7\27\2\2\u015e\u015f\5,\27\2\u015f\u0160\7\30\2\2\u0160\u0161\7"+
		"\37\2\2\u0161\u0162\5.\30\2\u0162\u0164\3\2\2\2\u0163\u015c\3\2\2\2\u0164"+
		"\u0167\3\2\2\2\u0165\u0163\3\2\2\2\u0165\u0166\3\2\2\2\u0166\61\3\2\2"+
		"\2\u0167\u0165\3\2\2\2\u0168\u016d\7/\2\2\u0169\u016a\7\24\2\2\u016a\u016c"+
		"\7/\2\2\u016b\u0169\3\2\2\2\u016c\u016f\3\2\2\2\u016d\u016b\3\2\2\2\u016d"+
		"\u016e\3\2\2\2\u016e\63\3\2\2\2\u016f\u016d\3\2\2\2\u0170\u0171\t\2\2"+
		"\2\u0171\65\3\2\2\2\u0172\u0173\7/\2\2\u0173\67\3\2\2\2\u0174\u0178\7"+
		"\25\2\2\u0175\u0177\5\4\3\2\u0176\u0175\3\2\2\2\u0177\u017a\3\2\2\2\u0178"+
		"\u0176\3\2\2\2\u0178\u0179\3\2\2\2\u0179\u017b\3\2\2\2\u017a\u0178\3\2"+
		"\2\2\u017b\u017c\7\26\2\2\u017c9\3\2\2\2\u017d\u017e\7/\2\2\u017e\u017f"+
		"\7\35\2\2\u017f\u0184\7/\2\2\u0180\u0181\7\21\2\2\u0181\u0182\7\35\2\2"+
		"\u0182\u0184\7/\2\2\u0183\u017d\3\2\2\2\u0183\u0180\3\2\2\2\u0184;\3\2"+
		"\2\2\u0185\u0186\t\3\2\2\u0186=\3\2\2\2\u0187\u0188\t\4\2\2\u0188?\3\2"+
		"\2\2\u0189\u018a\t\5\2\2\u018aA\3\2\2\2\u018b\u018c\t\6\2\2\u018cC\3\2"+
		"\2\2$GQ^bt\177\u0084\u0090\u009b\u00a4\u00ab\u00b2\u00b8\u00c3\u00d7\u00e0"+
		"\u00e4\u00eb\u00f3\u00f9\u010a\u011c\u011e\u0126\u012e\u0134\u013b\u013e"+
		"\u0145\u015a\u0165\u016d\u0178\u0183";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}