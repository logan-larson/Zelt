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
		WS=8, PRINT=9, STRUCT=10, INTERFACE=11, ITYPE=12, IF=13, ELSE=14, WHILE=15, 
		EACH=16, IN=17, CALLER=18, RETURN=19, SEMICOLON=20, COMMA=21, LEFT_BRACE=22, 
		RIGHT_BRACE=23, LEFT_PAREN=24, RIGHT_PAREN=25, LEFT_BRACKET=26, RIGHT_BRACKET=27, 
		QUESTION_MARK=28, ELLIPSIS=29, DOUBLE_PERIOD=30, PERIOD=31, DOUBLE_COLON=32, 
		COLON=33, ARROW=34, DOUBLE_ARROW=35, PLUS=36, MINUS=37, MULTIPLY=38, DIVIDE=39, 
		MODULO=40, NOT=41, AND=42, OR=43, EQUALS=44, NOT_EQUALS=45, LESS_THAN=46, 
		LESS_THAN_OR_EQUAL=47, GREATER_THAN=48, GREATER_THAN_OR_EQUAL=49, IS_DEFINED_AS=50, 
		IDENTIFIER=51, UNDERSCORE=52, CLOSE_COMMENT=53, NESTED_COMMENT=54, ANY_OTHER=55;
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
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\29\u015f\b\1\b\1\4"+
		"\2\t\2\4\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n"+
		"\4\13\t\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22"+
		"\t\22\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4\31"+
		"\t\31\4\32\t\32\4\33\t\33\4\34\t\34\4\35\t\35\4\36\t\36\4\37\t\37\4 \t"+
		" \4!\t!\4\"\t\"\4#\t#\4$\t$\4%\t%\4&\t&\4\'\t\'\4(\t(\4)\t)\4*\t*\4+\t"+
		"+\4,\t,\4-\t-\4.\t.\4/\t/\4\60\t\60\4\61\t\61\4\62\t\62\4\63\t\63\4\64"+
		"\t\64\4\65\t\65\4\66\t\66\4\67\t\67\48\t8\3\2\5\2t\n\2\3\2\6\2w\n\2\r"+
		"\2\16\2x\3\3\6\3|\n\3\r\3\16\3}\3\3\3\3\6\3\u0082\n\3\r\3\16\3\u0083\3"+
		"\4\3\4\7\4\u0088\n\4\f\4\16\4\u008b\13\4\3\4\3\4\3\5\3\5\3\5\3\5\3\5\3"+
		"\5\3\5\3\5\3\5\5\5\u0098\n\5\3\6\3\6\3\6\3\6\3\6\3\7\3\7\3\7\3\7\7\7\u00a3"+
		"\n\7\f\7\16\7\u00a6\13\7\3\7\3\7\3\7\3\7\3\b\3\b\3\b\3\b\3\b\3\b\3\t\6"+
		"\t\u00b3\n\t\r\t\16\t\u00b4\3\t\3\t\3\n\3\n\3\n\3\n\3\n\3\n\3\13\3\13"+
		"\3\13\3\13\3\13\3\13\3\13\3\f\3\f\3\f\3\f\3\f\3\f\3\f\3\f\3\f\3\f\3\r"+
		"\3\r\3\r\3\r\3\r\3\r\3\16\3\16\3\16\3\17\3\17\3\17\3\17\3\17\3\20\3\20"+
		"\3\20\3\20\3\20\3\20\3\21\3\21\3\21\3\21\3\21\3\22\3\22\3\22\3\23\3\23"+
		"\3\23\3\23\3\23\3\23\3\23\3\24\3\24\3\24\3\24\3\24\3\24\3\24\3\25\3\25"+
		"\3\26\3\26\3\27\3\27\3\30\3\30\3\31\3\31\3\32\3\32\3\33\3\33\3\34\3\34"+
		"\3\35\3\35\3\36\3\36\3\36\3\36\3\37\3\37\3\37\3 \3 \3!\3!\3!\3\"\3\"\3"+
		"#\3#\3#\3$\3$\3$\3%\3%\3&\3&\3\'\3\'\3(\3(\3)\3)\3*\3*\3+\3+\3+\3,\3,"+
		"\3,\3-\3-\3-\3.\3.\3.\3/\3/\3\60\3\60\3\60\3\61\3\61\3\62\3\62\3\62\3"+
		"\63\3\63\3\64\5\64\u0145\n\64\3\64\3\64\7\64\u0149\n\64\f\64\16\64\u014c"+
		"\13\64\3\65\3\65\3\66\3\66\3\66\3\66\3\66\3\66\3\67\3\67\3\67\3\67\3\67"+
		"\3\67\38\38\38\38\4\u0089\u00a4\29\4\3\6\4\b\5\n\6\f\7\16\b\20\t\22\n"+
		"\24\13\26\f\30\r\32\16\34\17\36\20 \21\"\22$\23&\24(\25*\26,\27.\30\60"+
		"\31\62\32\64\33\66\348\35:\36<\37> @!B\"D#F$H%J&L\'N(P)R*T+V,X-Z.\\/^"+
		"\60`\61b\62d\63f\64h\65j\66l\67n8p9\4\2\3\7\3\2\62;\5\2\13\f\17\17\"\""+
		"\3\2aa\4\2C\\c|\6\2\62;C\\aac|\2\u0167\2\4\3\2\2\2\2\6\3\2\2\2\2\b\3\2"+
		"\2\2\2\n\3\2\2\2\2\f\3\2\2\2\2\16\3\2\2\2\2\20\3\2\2\2\2\22\3\2\2\2\2"+
		"\24\3\2\2\2\2\26\3\2\2\2\2\30\3\2\2\2\2\32\3\2\2\2\2\34\3\2\2\2\2\36\3"+
		"\2\2\2\2 \3\2\2\2\2\"\3\2\2\2\2$\3\2\2\2\2&\3\2\2\2\2(\3\2\2\2\2*\3\2"+
		"\2\2\2,\3\2\2\2\2.\3\2\2\2\2\60\3\2\2\2\2\62\3\2\2\2\2\64\3\2\2\2\2\66"+
		"\3\2\2\2\28\3\2\2\2\2:\3\2\2\2\2<\3\2\2\2\2>\3\2\2\2\2@\3\2\2\2\2B\3\2"+
		"\2\2\2D\3\2\2\2\2F\3\2\2\2\2H\3\2\2\2\2J\3\2\2\2\2L\3\2\2\2\2N\3\2\2\2"+
		"\2P\3\2\2\2\2R\3\2\2\2\2T\3\2\2\2\2V\3\2\2\2\2X\3\2\2\2\2Z\3\2\2\2\2\\"+
		"\3\2\2\2\2^\3\2\2\2\2`\3\2\2\2\2b\3\2\2\2\2d\3\2\2\2\2f\3\2\2\2\2h\3\2"+
		"\2\2\2j\3\2\2\2\3l\3\2\2\2\3n\3\2\2\2\3p\3\2\2\2\4s\3\2\2\2\6{\3\2\2\2"+
		"\b\u0085\3\2\2\2\n\u0097\3\2\2\2\f\u0099\3\2\2\2\16\u009e\3\2\2\2\20\u00ab"+
		"\3\2\2\2\22\u00b2\3\2\2\2\24\u00b8\3\2\2\2\26\u00be\3\2\2\2\30\u00c5\3"+
		"\2\2\2\32\u00cf\3\2\2\2\34\u00d5\3\2\2\2\36\u00d8\3\2\2\2 \u00dd\3\2\2"+
		"\2\"\u00e3\3\2\2\2$\u00e8\3\2\2\2&\u00eb\3\2\2\2(\u00f2\3\2\2\2*\u00f9"+
		"\3\2\2\2,\u00fb\3\2\2\2.\u00fd\3\2\2\2\60\u00ff\3\2\2\2\62\u0101\3\2\2"+
		"\2\64\u0103\3\2\2\2\66\u0105\3\2\2\28\u0107\3\2\2\2:\u0109\3\2\2\2<\u010b"+
		"\3\2\2\2>\u010f\3\2\2\2@\u0112\3\2\2\2B\u0114\3\2\2\2D\u0117\3\2\2\2F"+
		"\u0119\3\2\2\2H\u011c\3\2\2\2J\u011f\3\2\2\2L\u0121\3\2\2\2N\u0123\3\2"+
		"\2\2P\u0125\3\2\2\2R\u0127\3\2\2\2T\u0129\3\2\2\2V\u012b\3\2\2\2X\u012e"+
		"\3\2\2\2Z\u0131\3\2\2\2\\\u0134\3\2\2\2^\u0137\3\2\2\2`\u0139\3\2\2\2"+
		"b\u013c\3\2\2\2d\u013e\3\2\2\2f\u0141\3\2\2\2h\u0144\3\2\2\2j\u014d\3"+
		"\2\2\2l\u014f\3\2\2\2n\u0155\3\2\2\2p\u015b\3\2\2\2rt\7/\2\2sr\3\2\2\2"+
		"st\3\2\2\2tv\3\2\2\2uw\t\2\2\2vu\3\2\2\2wx\3\2\2\2xv\3\2\2\2xy\3\2\2\2"+
		"y\5\3\2\2\2z|\t\2\2\2{z\3\2\2\2|}\3\2\2\2}{\3\2\2\2}~\3\2\2\2~\177\3\2"+
		"\2\2\177\u0081\7\60\2\2\u0080\u0082\t\2\2\2\u0081\u0080\3\2\2\2\u0082"+
		"\u0083\3\2\2\2\u0083\u0081\3\2\2\2\u0083\u0084\3\2\2\2\u0084\7\3\2\2\2"+
		"\u0085\u0089\7$\2\2\u0086\u0088\13\2\2\2\u0087\u0086\3\2\2\2\u0088\u008b"+
		"\3\2\2\2\u0089\u008a\3\2\2\2\u0089\u0087\3\2\2\2\u008a\u008c\3\2\2\2\u008b"+
		"\u0089\3\2\2\2\u008c\u008d\7$\2\2\u008d\t\3\2\2\2\u008e\u008f\7v\2\2\u008f"+
		"\u0090\7t\2\2\u0090\u0091\7w\2\2\u0091\u0098\7g\2\2\u0092\u0093\7h\2\2"+
		"\u0093\u0094\7c\2\2\u0094\u0095\7n\2\2\u0095\u0096\7u\2\2\u0096\u0098"+
		"\7g\2\2\u0097\u008e\3\2\2\2\u0097\u0092\3\2\2\2\u0098\13\3\2\2\2\u0099"+
		"\u009a\7p\2\2\u009a\u009b\7w\2\2\u009b\u009c\7n\2\2\u009c\u009d\7n\2\2"+
		"\u009d\r\3\2\2\2\u009e\u009f\7\61\2\2\u009f\u00a0\7\61\2\2\u00a0\u00a4"+
		"\3\2\2\2\u00a1\u00a3\13\2\2\2\u00a2\u00a1\3\2\2\2\u00a3\u00a6\3\2\2\2"+
		"\u00a4\u00a5\3\2\2\2\u00a4\u00a2\3\2\2\2\u00a5\u00a7\3\2\2\2\u00a6\u00a4"+
		"\3\2\2\2\u00a7\u00a8\7\f\2\2\u00a8\u00a9\3\2\2\2\u00a9\u00aa\b\7\2\2\u00aa"+
		"\17\3\2\2\2\u00ab\u00ac\7\61\2\2\u00ac\u00ad\7,\2\2\u00ad\u00ae\3\2\2"+
		"\2\u00ae\u00af\b\b\3\2\u00af\u00b0\b\b\2\2\u00b0\21\3\2\2\2\u00b1\u00b3"+
		"\t\3\2\2\u00b2\u00b1\3\2\2\2\u00b3\u00b4\3\2\2\2\u00b4\u00b2\3\2\2\2\u00b4"+
		"\u00b5\3\2\2\2\u00b5\u00b6\3\2\2\2\u00b6\u00b7\b\t\2\2\u00b7\23\3\2\2"+
		"\2\u00b8\u00b9\7r\2\2\u00b9\u00ba\7t\2\2\u00ba\u00bb\7k\2\2\u00bb\u00bc"+
		"\7p\2\2\u00bc\u00bd\7v\2\2\u00bd\25\3\2\2\2\u00be\u00bf\7u\2\2\u00bf\u00c0"+
		"\7v\2\2\u00c0\u00c1\7t\2\2\u00c1\u00c2\7w\2\2\u00c2\u00c3\7e\2\2\u00c3"+
		"\u00c4\7v\2\2\u00c4\27\3\2\2\2\u00c5\u00c6\7k\2\2\u00c6\u00c7\7p\2\2\u00c7"+
		"\u00c8\7v\2\2\u00c8\u00c9\7g\2\2\u00c9\u00ca\7t\2\2\u00ca\u00cb\7h\2\2"+
		"\u00cb\u00cc\7c\2\2\u00cc\u00cd\7e\2\2\u00cd\u00ce\7g\2\2\u00ce\31\3\2"+
		"\2\2\u00cf\u00d0\7K\2\2\u00d0\u00d1\7V\2\2\u00d1\u00d2\7{\2\2\u00d2\u00d3"+
		"\7r\2\2\u00d3\u00d4\7g\2\2\u00d4\33\3\2\2\2\u00d5\u00d6\7k\2\2\u00d6\u00d7"+
		"\7h\2\2\u00d7\35\3\2\2\2\u00d8\u00d9\7g\2\2\u00d9\u00da\7n\2\2\u00da\u00db"+
		"\7u\2\2\u00db\u00dc\7g\2\2\u00dc\37\3\2\2\2\u00dd\u00de\7y\2\2\u00de\u00df"+
		"\7j\2\2\u00df\u00e0\7k\2\2\u00e0\u00e1\7n\2\2\u00e1\u00e2\7g\2\2\u00e2"+
		"!\3\2\2\2\u00e3\u00e4\7g\2\2\u00e4\u00e5\7c\2\2\u00e5\u00e6\7e\2\2\u00e6"+
		"\u00e7\7j\2\2\u00e7#\3\2\2\2\u00e8\u00e9\7k\2\2\u00e9\u00ea\7p\2\2\u00ea"+
		"%\3\2\2\2\u00eb\u00ec\7e\2\2\u00ec\u00ed\7c\2\2\u00ed\u00ee\7n\2\2\u00ee"+
		"\u00ef\7n\2\2\u00ef\u00f0\7g\2\2\u00f0\u00f1\7t\2\2\u00f1\'\3\2\2\2\u00f2"+
		"\u00f3\7t\2\2\u00f3\u00f4\7g\2\2\u00f4\u00f5\7v\2\2\u00f5\u00f6\7w\2\2"+
		"\u00f6\u00f7\7t\2\2\u00f7\u00f8\7p\2\2\u00f8)\3\2\2\2\u00f9\u00fa\7=\2"+
		"\2\u00fa+\3\2\2\2\u00fb\u00fc\7.\2\2\u00fc-\3\2\2\2\u00fd\u00fe\7}\2\2"+
		"\u00fe/\3\2\2\2\u00ff\u0100\7\177\2\2\u0100\61\3\2\2\2\u0101\u0102\7*"+
		"\2\2\u0102\63\3\2\2\2\u0103\u0104\7+\2\2\u0104\65\3\2\2\2\u0105\u0106"+
		"\7]\2\2\u0106\67\3\2\2\2\u0107\u0108\7_\2\2\u01089\3\2\2\2\u0109\u010a"+
		"\7A\2\2\u010a;\3\2\2\2\u010b\u010c\7\60\2\2\u010c\u010d\7\60\2\2\u010d"+
		"\u010e\7\60\2\2\u010e=\3\2\2\2\u010f\u0110\7\60\2\2\u0110\u0111\7\60\2"+
		"\2\u0111?\3\2\2\2\u0112\u0113\7\60\2\2\u0113A\3\2\2\2\u0114\u0115\7<\2"+
		"\2\u0115\u0116\7<\2\2\u0116C\3\2\2\2\u0117\u0118\7<\2\2\u0118E\3\2\2\2"+
		"\u0119\u011a\7/\2\2\u011a\u011b\7@\2\2\u011bG\3\2\2\2\u011c\u011d\7?\2"+
		"\2\u011d\u011e\7@\2\2\u011eI\3\2\2\2\u011f\u0120\7-\2\2\u0120K\3\2\2\2"+
		"\u0121\u0122\7/\2\2\u0122M\3\2\2\2\u0123\u0124\7,\2\2\u0124O\3\2\2\2\u0125"+
		"\u0126\7\61\2\2\u0126Q\3\2\2\2\u0127\u0128\7\'\2\2\u0128S\3\2\2\2\u0129"+
		"\u012a\7#\2\2\u012aU\3\2\2\2\u012b\u012c\7(\2\2\u012c\u012d\7(\2\2\u012d"+
		"W\3\2\2\2\u012e\u012f\7~\2\2\u012f\u0130\7~\2\2\u0130Y\3\2\2\2\u0131\u0132"+
		"\7?\2\2\u0132\u0133\7?\2\2\u0133[\3\2\2\2\u0134\u0135\7#\2\2\u0135\u0136"+
		"\7?\2\2\u0136]\3\2\2\2\u0137\u0138\7>\2\2\u0138_\3\2\2\2\u0139\u013a\7"+
		">\2\2\u013a\u013b\7?\2\2\u013ba\3\2\2\2\u013c\u013d\7@\2\2\u013dc\3\2"+
		"\2\2\u013e\u013f\7@\2\2\u013f\u0140\7?\2\2\u0140e\3\2\2\2\u0141\u0142"+
		"\7?\2\2\u0142g\3\2\2\2\u0143\u0145\t\4\2\2\u0144\u0143\3\2\2\2\u0144\u0145"+
		"\3\2\2\2\u0145\u0146\3\2\2\2\u0146\u014a\t\5\2\2\u0147\u0149\t\6\2\2\u0148"+
		"\u0147\3\2\2\2\u0149\u014c\3\2\2\2\u014a\u0148\3\2\2\2\u014a\u014b\3\2"+
		"\2\2\u014bi\3\2\2\2\u014c\u014a\3\2\2\2\u014d\u014e\7a\2\2\u014ek\3\2"+
		"\2\2\u014f\u0150\7,\2\2\u0150\u0151\7\61\2\2\u0151\u0152\3\2\2\2\u0152"+
		"\u0153\b\66\4\2\u0153\u0154\b\66\2\2\u0154m\3\2\2\2\u0155\u0156\7\61\2"+
		"\2\u0156\u0157\7,\2\2\u0157\u0158\3\2\2\2\u0158\u0159\b\67\3\2\u0159\u015a"+
		"\b\67\2\2\u015ao\3\2\2\2\u015b\u015c\13\2\2\2\u015c\u015d\3\2\2\2\u015d"+
		"\u015e\b8\2\2\u015eq\3\2\2\2\16\2\3sx}\u0083\u0089\u0097\u00a4\u00b4\u0144"+
		"\u014a\5\b\2\2\7\3\2\6\2\2";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}