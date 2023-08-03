// Generated from c:\Users\logan\source\repos\Zelt\Zelt\Grammar\ZeltLexer.g4 by ANTLR 4.9.2
import org.antlr.v4.runtime.Lexer;
import org.antlr.v4.runtime.CharStream;
import org.antlr.v4.runtime.Token;
import org.antlr.v4.runtime.TokenStream;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.misc.*;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class ZeltLexer extends Lexer {
	static { RuntimeMetaData.checkVersion("4.9.2", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		INTEGER=1, FLOAT=2, STRING=3, BOOL=4, NULL=5, COMMENT=6, MULTILINE_COMMENT=7, 
		WS=8, INT_TYPE=9, FLOAT_TYPE=10, STRING_TYPE=11, BOOL_TYPE=12, FUNCTION_TYPE=13, 
		STRUCT=14, INTERFACE=15, IF=16, ELSE=17, WHILE=18, CALLER=19, RETURN=20, 
		SEMICOLON=21, COMMA=22, LEFT_BRACE=23, RIGHT_BRACE=24, LEFT_PAREN=25, 
		RIGHT_PAREN=26, LEFT_BRACKET=27, RIGHT_BRACKET=28, QUESTION_MARK=29, PERIOD=30, 
		COLON=31, ARROW=32, PLUS=33, MINUS=34, MULTIPLY=35, DIVIDE=36, MODULO=37, 
		NOT=38, AND=39, OR=40, EQUALS=41, NOT_EQUALS=42, LESS_THAN=43, LESS_THAN_OR_EQUAL=44, 
		GREATER_THAN=45, GREATER_THAN_OR_EQUAL=46, IS_DEFINED_AS=47, IDENTIFIER=48, 
		CLOSE_COMMENT=49, NESTED_COMMENT=50, ANY_OTHER=51;
	public static final int
		COMMENT_MODE=1;
	public static String[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static String[] modeNames = {
		"DEFAULT_MODE", "COMMENT_MODE"
	};

	private static String[] makeRuleNames() {
		return new String[] {
			"INTEGER", "FLOAT", "STRING", "BOOL", "NULL", "COMMENT", "MULTILINE_COMMENT", 
			"WS", "INT_TYPE", "FLOAT_TYPE", "STRING_TYPE", "BOOL_TYPE", "FUNCTION_TYPE", 
			"STRUCT", "INTERFACE", "IF", "ELSE", "WHILE", "CALLER", "RETURN", "SEMICOLON", 
			"COMMA", "LEFT_BRACE", "RIGHT_BRACE", "LEFT_PAREN", "RIGHT_PAREN", "LEFT_BRACKET", 
			"RIGHT_BRACKET", "QUESTION_MARK", "PERIOD", "COLON", "ARROW", "PLUS", 
			"MINUS", "MULTIPLY", "DIVIDE", "MODULO", "NOT", "AND", "OR", "EQUALS", 
			"NOT_EQUALS", "LESS_THAN", "LESS_THAN_OR_EQUAL", "GREATER_THAN", "GREATER_THAN_OR_EQUAL", 
			"IS_DEFINED_AS", "IDENTIFIER", "CLOSE_COMMENT", "NESTED_COMMENT", "ANY_OTHER"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, null, null, null, null, "'null'", null, null, null, "'Int'", "'Float'", 
			"'String'", "'Bool'", "'Func'", "'struct'", "'interface'", "'if'", "'else'", 
			"'while'", "'caller'", "'return'", "';'", "','", "'{'", "'}'", "'('", 
			"')'", "'['", "']'", "'?'", "'.'", "':'", "'->'", "'+'", "'-'", "'*'", 
			"'/'", "'%'", "'!'", "'&&'", "'||'", "'=='", "'!='", "'<'", "'<='", "'>'", 
			"'>='", "'='", null, "'*/'"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, "INTEGER", "FLOAT", "STRING", "BOOL", "NULL", "COMMENT", "MULTILINE_COMMENT", 
			"WS", "INT_TYPE", "FLOAT_TYPE", "STRING_TYPE", "BOOL_TYPE", "FUNCTION_TYPE", 
			"STRUCT", "INTERFACE", "IF", "ELSE", "WHILE", "CALLER", "RETURN", "SEMICOLON", 
			"COMMA", "LEFT_BRACE", "RIGHT_BRACE", "LEFT_PAREN", "RIGHT_PAREN", "LEFT_BRACKET", 
			"RIGHT_BRACKET", "QUESTION_MARK", "PERIOD", "COLON", "ARROW", "PLUS", 
			"MINUS", "MULTIPLY", "DIVIDE", "MODULO", "NOT", "AND", "OR", "EQUALS", 
			"NOT_EQUALS", "LESS_THAN", "LESS_THAN_OR_EQUAL", "GREATER_THAN", "GREATER_THAN_OR_EQUAL", 
			"IS_DEFINED_AS", "IDENTIFIER", "CLOSE_COMMENT", "NESTED_COMMENT", "ANY_OTHER"
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


	public ZeltLexer(CharStream input) {
		super(input);
		_interp = new LexerATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	@Override
	public String getGrammarFileName() { return "ZeltLexer.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public String[] getChannelNames() { return channelNames; }

	@Override
	public String[] getModeNames() { return modeNames; }

	@Override
	public ATN getATN() { return _ATN; }

	public static final String _serializedATN =
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\2\65\u014c\b\1\b\1"+
		"\4\2\t\2\4\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t"+
		"\n\4\13\t\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4"+
		"\22\t\22\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4"+
		"\31\t\31\4\32\t\32\4\33\t\33\4\34\t\34\4\35\t\35\4\36\t\36\4\37\t\37\4"+
		" \t \4!\t!\4\"\t\"\4#\t#\4$\t$\4%\t%\4&\t&\4\'\t\'\4(\t(\4)\t)\4*\t*\4"+
		"+\t+\4,\t,\4-\t-\4.\t.\4/\t/\4\60\t\60\4\61\t\61\4\62\t\62\4\63\t\63\4"+
		"\64\t\64\3\2\6\2l\n\2\r\2\16\2m\3\3\6\3q\n\3\r\3\16\3r\3\3\3\3\6\3w\n"+
		"\3\r\3\16\3x\3\4\3\4\7\4}\n\4\f\4\16\4\u0080\13\4\3\4\3\4\3\5\3\5\3\5"+
		"\3\5\3\5\3\5\3\5\3\5\3\5\5\5\u008d\n\5\3\6\3\6\3\6\3\6\3\6\3\7\3\7\3\7"+
		"\3\7\7\7\u0098\n\7\f\7\16\7\u009b\13\7\3\7\3\7\3\7\3\7\3\b\3\b\3\b\3\b"+
		"\3\b\3\b\3\t\6\t\u00a8\n\t\r\t\16\t\u00a9\3\t\3\t\3\n\3\n\3\n\3\n\3\13"+
		"\3\13\3\13\3\13\3\13\3\13\3\f\3\f\3\f\3\f\3\f\3\f\3\f\3\r\3\r\3\r\3\r"+
		"\3\r\3\16\3\16\3\16\3\16\3\16\3\17\3\17\3\17\3\17\3\17\3\17\3\17\3\20"+
		"\3\20\3\20\3\20\3\20\3\20\3\20\3\20\3\20\3\20\3\21\3\21\3\21\3\22\3\22"+
		"\3\22\3\22\3\22\3\23\3\23\3\23\3\23\3\23\3\23\3\24\3\24\3\24\3\24\3\24"+
		"\3\24\3\24\3\25\3\25\3\25\3\25\3\25\3\25\3\25\3\26\3\26\3\27\3\27\3\30"+
		"\3\30\3\31\3\31\3\32\3\32\3\33\3\33\3\34\3\34\3\35\3\35\3\36\3\36\3\37"+
		"\3\37\3 \3 \3!\3!\3!\3\"\3\"\3#\3#\3$\3$\3%\3%\3&\3&\3\'\3\'\3(\3(\3("+
		"\3)\3)\3)\3*\3*\3*\3+\3+\3+\3,\3,\3-\3-\3-\3.\3.\3/\3/\3/\3\60\3\60\3"+
		"\61\5\61\u0134\n\61\3\61\3\61\7\61\u0138\n\61\f\61\16\61\u013b\13\61\3"+
		"\62\3\62\3\62\3\62\3\62\3\62\3\63\3\63\3\63\3\63\3\63\3\63\3\64\3\64\3"+
		"\64\3\64\4~\u0099\2\65\4\3\6\4\b\5\n\6\f\7\16\b\20\t\22\n\24\13\26\f\30"+
		"\r\32\16\34\17\36\20 \21\"\22$\23&\24(\25*\26,\27.\30\60\31\62\32\64\33"+
		"\66\348\35:\36<\37> @!B\"D#F$H%J&L\'N(P)R*T+V,X-Z.\\/^\60`\61b\62d\63"+
		"f\64h\65\4\2\3\7\3\2\62;\5\2\13\f\17\17\"\"\3\2aa\4\2C\\c|\6\2\62;C\\"+
		"aac|\2\u0153\2\4\3\2\2\2\2\6\3\2\2\2\2\b\3\2\2\2\2\n\3\2\2\2\2\f\3\2\2"+
		"\2\2\16\3\2\2\2\2\20\3\2\2\2\2\22\3\2\2\2\2\24\3\2\2\2\2\26\3\2\2\2\2"+
		"\30\3\2\2\2\2\32\3\2\2\2\2\34\3\2\2\2\2\36\3\2\2\2\2 \3\2\2\2\2\"\3\2"+
		"\2\2\2$\3\2\2\2\2&\3\2\2\2\2(\3\2\2\2\2*\3\2\2\2\2,\3\2\2\2\2.\3\2\2\2"+
		"\2\60\3\2\2\2\2\62\3\2\2\2\2\64\3\2\2\2\2\66\3\2\2\2\28\3\2\2\2\2:\3\2"+
		"\2\2\2<\3\2\2\2\2>\3\2\2\2\2@\3\2\2\2\2B\3\2\2\2\2D\3\2\2\2\2F\3\2\2\2"+
		"\2H\3\2\2\2\2J\3\2\2\2\2L\3\2\2\2\2N\3\2\2\2\2P\3\2\2\2\2R\3\2\2\2\2T"+
		"\3\2\2\2\2V\3\2\2\2\2X\3\2\2\2\2Z\3\2\2\2\2\\\3\2\2\2\2^\3\2\2\2\2`\3"+
		"\2\2\2\2b\3\2\2\2\3d\3\2\2\2\3f\3\2\2\2\3h\3\2\2\2\4k\3\2\2\2\6p\3\2\2"+
		"\2\bz\3\2\2\2\n\u008c\3\2\2\2\f\u008e\3\2\2\2\16\u0093\3\2\2\2\20\u00a0"+
		"\3\2\2\2\22\u00a7\3\2\2\2\24\u00ad\3\2\2\2\26\u00b1\3\2\2\2\30\u00b7\3"+
		"\2\2\2\32\u00be\3\2\2\2\34\u00c3\3\2\2\2\36\u00c8\3\2\2\2 \u00cf\3\2\2"+
		"\2\"\u00d9\3\2\2\2$\u00dc\3\2\2\2&\u00e1\3\2\2\2(\u00e7\3\2\2\2*\u00ee"+
		"\3\2\2\2,\u00f5\3\2\2\2.\u00f7\3\2\2\2\60\u00f9\3\2\2\2\62\u00fb\3\2\2"+
		"\2\64\u00fd\3\2\2\2\66\u00ff\3\2\2\28\u0101\3\2\2\2:\u0103\3\2\2\2<\u0105"+
		"\3\2\2\2>\u0107\3\2\2\2@\u0109\3\2\2\2B\u010b\3\2\2\2D\u010e\3\2\2\2F"+
		"\u0110\3\2\2\2H\u0112\3\2\2\2J\u0114\3\2\2\2L\u0116\3\2\2\2N\u0118\3\2"+
		"\2\2P\u011a\3\2\2\2R\u011d\3\2\2\2T\u0120\3\2\2\2V\u0123\3\2\2\2X\u0126"+
		"\3\2\2\2Z\u0128\3\2\2\2\\\u012b\3\2\2\2^\u012d\3\2\2\2`\u0130\3\2\2\2"+
		"b\u0133\3\2\2\2d\u013c\3\2\2\2f\u0142\3\2\2\2h\u0148\3\2\2\2jl\t\2\2\2"+
		"kj\3\2\2\2lm\3\2\2\2mk\3\2\2\2mn\3\2\2\2n\5\3\2\2\2oq\t\2\2\2po\3\2\2"+
		"\2qr\3\2\2\2rp\3\2\2\2rs\3\2\2\2st\3\2\2\2tv\7\60\2\2uw\t\2\2\2vu\3\2"+
		"\2\2wx\3\2\2\2xv\3\2\2\2xy\3\2\2\2y\7\3\2\2\2z~\7$\2\2{}\13\2\2\2|{\3"+
		"\2\2\2}\u0080\3\2\2\2~\177\3\2\2\2~|\3\2\2\2\177\u0081\3\2\2\2\u0080~"+
		"\3\2\2\2\u0081\u0082\7$\2\2\u0082\t\3\2\2\2\u0083\u0084\7v\2\2\u0084\u0085"+
		"\7t\2\2\u0085\u0086\7w\2\2\u0086\u008d\7g\2\2\u0087\u0088\7h\2\2\u0088"+
		"\u0089\7c\2\2\u0089\u008a\7n\2\2\u008a\u008b\7u\2\2\u008b\u008d\7g\2\2"+
		"\u008c\u0083\3\2\2\2\u008c\u0087\3\2\2\2\u008d\13\3\2\2\2\u008e\u008f"+
		"\7p\2\2\u008f\u0090\7w\2\2\u0090\u0091\7n\2\2\u0091\u0092\7n\2\2\u0092"+
		"\r\3\2\2\2\u0093\u0094\7\61\2\2\u0094\u0095\7\61\2\2\u0095\u0099\3\2\2"+
		"\2\u0096\u0098\13\2\2\2\u0097\u0096\3\2\2\2\u0098\u009b\3\2\2\2\u0099"+
		"\u009a\3\2\2\2\u0099\u0097\3\2\2\2\u009a\u009c\3\2\2\2\u009b\u0099\3\2"+
		"\2\2\u009c\u009d\7\f\2\2\u009d\u009e\3\2\2\2\u009e\u009f\b\7\2\2\u009f"+
		"\17\3\2\2\2\u00a0\u00a1\7\61\2\2\u00a1\u00a2\7,\2\2\u00a2\u00a3\3\2\2"+
		"\2\u00a3\u00a4\b\b\3\2\u00a4\u00a5\b\b\2\2\u00a5\21\3\2\2\2\u00a6\u00a8"+
		"\t\3\2\2\u00a7\u00a6\3\2\2\2\u00a8\u00a9\3\2\2\2\u00a9\u00a7\3\2\2\2\u00a9"+
		"\u00aa\3\2\2\2\u00aa\u00ab\3\2\2\2\u00ab\u00ac\b\t\2\2\u00ac\23\3\2\2"+
		"\2\u00ad\u00ae\7K\2\2\u00ae\u00af\7p\2\2\u00af\u00b0\7v\2\2\u00b0\25\3"+
		"\2\2\2\u00b1\u00b2\7H\2\2\u00b2\u00b3\7n\2\2\u00b3\u00b4\7q\2\2\u00b4"+
		"\u00b5\7c\2\2\u00b5\u00b6\7v\2\2\u00b6\27\3\2\2\2\u00b7\u00b8\7U\2\2\u00b8"+
		"\u00b9\7v\2\2\u00b9\u00ba\7t\2\2\u00ba\u00bb\7k\2\2\u00bb\u00bc\7p\2\2"+
		"\u00bc\u00bd\7i\2\2\u00bd\31\3\2\2\2\u00be\u00bf\7D\2\2\u00bf\u00c0\7"+
		"q\2\2\u00c0\u00c1\7q\2\2\u00c1\u00c2\7n\2\2\u00c2\33\3\2\2\2\u00c3\u00c4"+
		"\7H\2\2\u00c4\u00c5\7w\2\2\u00c5\u00c6\7p\2\2\u00c6\u00c7\7e\2\2\u00c7"+
		"\35\3\2\2\2\u00c8\u00c9\7u\2\2\u00c9\u00ca\7v\2\2\u00ca\u00cb\7t\2\2\u00cb"+
		"\u00cc\7w\2\2\u00cc\u00cd\7e\2\2\u00cd\u00ce\7v\2\2\u00ce\37\3\2\2\2\u00cf"+
		"\u00d0\7k\2\2\u00d0\u00d1\7p\2\2\u00d1\u00d2\7v\2\2\u00d2\u00d3\7g\2\2"+
		"\u00d3\u00d4\7t\2\2\u00d4\u00d5\7h\2\2\u00d5\u00d6\7c\2\2\u00d6\u00d7"+
		"\7e\2\2\u00d7\u00d8\7g\2\2\u00d8!\3\2\2\2\u00d9\u00da\7k\2\2\u00da\u00db"+
		"\7h\2\2\u00db#\3\2\2\2\u00dc\u00dd\7g\2\2\u00dd\u00de\7n\2\2\u00de\u00df"+
		"\7u\2\2\u00df\u00e0\7g\2\2\u00e0%\3\2\2\2\u00e1\u00e2\7y\2\2\u00e2\u00e3"+
		"\7j\2\2\u00e3\u00e4\7k\2\2\u00e4\u00e5\7n\2\2\u00e5\u00e6\7g\2\2\u00e6"+
		"\'\3\2\2\2\u00e7\u00e8\7e\2\2\u00e8\u00e9\7c\2\2\u00e9\u00ea\7n\2\2\u00ea"+
		"\u00eb\7n\2\2\u00eb\u00ec\7g\2\2\u00ec\u00ed\7t\2\2\u00ed)\3\2\2\2\u00ee"+
		"\u00ef\7t\2\2\u00ef\u00f0\7g\2\2\u00f0\u00f1\7v\2\2\u00f1\u00f2\7w\2\2"+
		"\u00f2\u00f3\7t\2\2\u00f3\u00f4\7p\2\2\u00f4+\3\2\2\2\u00f5\u00f6\7=\2"+
		"\2\u00f6-\3\2\2\2\u00f7\u00f8\7.\2\2\u00f8/\3\2\2\2\u00f9\u00fa\7}\2\2"+
		"\u00fa\61\3\2\2\2\u00fb\u00fc\7\177\2\2\u00fc\63\3\2\2\2\u00fd\u00fe\7"+
		"*\2\2\u00fe\65\3\2\2\2\u00ff\u0100\7+\2\2\u0100\67\3\2\2\2\u0101\u0102"+
		"\7]\2\2\u01029\3\2\2\2\u0103\u0104\7_\2\2\u0104;\3\2\2\2\u0105\u0106\7"+
		"A\2\2\u0106=\3\2\2\2\u0107\u0108\7\60\2\2\u0108?\3\2\2\2\u0109\u010a\7"+
		"<\2\2\u010aA\3\2\2\2\u010b\u010c\7/\2\2\u010c\u010d\7@\2\2\u010dC\3\2"+
		"\2\2\u010e\u010f\7-\2\2\u010fE\3\2\2\2\u0110\u0111\7/\2\2\u0111G\3\2\2"+
		"\2\u0112\u0113\7,\2\2\u0113I\3\2\2\2\u0114\u0115\7\61\2\2\u0115K\3\2\2"+
		"\2\u0116\u0117\7\'\2\2\u0117M\3\2\2\2\u0118\u0119\7#\2\2\u0119O\3\2\2"+
		"\2\u011a\u011b\7(\2\2\u011b\u011c\7(\2\2\u011cQ\3\2\2\2\u011d\u011e\7"+
		"~\2\2\u011e\u011f\7~\2\2\u011fS\3\2\2\2\u0120\u0121\7?\2\2\u0121\u0122"+
		"\7?\2\2\u0122U\3\2\2\2\u0123\u0124\7#\2\2\u0124\u0125\7?\2\2\u0125W\3"+
		"\2\2\2\u0126\u0127\7>\2\2\u0127Y\3\2\2\2\u0128\u0129\7>\2\2\u0129\u012a"+
		"\7?\2\2\u012a[\3\2\2\2\u012b\u012c\7@\2\2\u012c]\3\2\2\2\u012d\u012e\7"+
		"@\2\2\u012e\u012f\7?\2\2\u012f_\3\2\2\2\u0130\u0131\7?\2\2\u0131a\3\2"+
		"\2\2\u0132\u0134\t\4\2\2\u0133\u0132\3\2\2\2\u0133\u0134\3\2\2\2\u0134"+
		"\u0135\3\2\2\2\u0135\u0139\t\5\2\2\u0136\u0138\t\6\2\2\u0137\u0136\3\2"+
		"\2\2\u0138\u013b\3\2\2\2\u0139\u0137\3\2\2\2\u0139\u013a\3\2\2\2\u013a"+
		"c\3\2\2\2\u013b\u0139\3\2\2\2\u013c\u013d\7,\2\2\u013d\u013e\7\61\2\2"+
		"\u013e\u013f\3\2\2\2\u013f\u0140\b\62\4\2\u0140\u0141\b\62\2\2\u0141e"+
		"\3\2\2\2\u0142\u0143\7\61\2\2\u0143\u0144\7,\2\2\u0144\u0145\3\2\2\2\u0145"+
		"\u0146\b\63\3\2\u0146\u0147\b\63\2\2\u0147g\3\2\2\2\u0148\u0149\13\2\2"+
		"\2\u0149\u014a\3\2\2\2\u014a\u014b\b\64\2\2\u014bi\3\2\2\2\r\2\3mrx~\u008c"+
		"\u0099\u00a9\u0133\u0139\5\b\2\2\7\3\2\6\2\2";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}