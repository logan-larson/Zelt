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
		WS=8, PRINT=9, STRUCT=10, INTERFACE=11, IF=12, ELSE=13, WHILE=14, CALLER=15, 
		RETURN=16, SEMICOLON=17, COMMA=18, LEFT_BRACE=19, RIGHT_BRACE=20, LEFT_PAREN=21, 
		RIGHT_PAREN=22, LEFT_BRACKET=23, RIGHT_BRACKET=24, QUESTION_MARK=25, ELLIPSIS=26, 
		PERIOD=27, COLON=28, ARROW=29, PLUS=30, MINUS=31, MULTIPLY=32, DIVIDE=33, 
		MODULO=34, NOT=35, AND=36, OR=37, EQUALS=38, NOT_EQUALS=39, LESS_THAN=40, 
		LESS_THAN_OR_EQUAL=41, GREATER_THAN=42, GREATER_THAN_OR_EQUAL=43, IS_DEFINED_AS=44, 
		IDENTIFIER=45, UNDERSCORE=46, CLOSE_COMMENT=47, NESTED_COMMENT=48, ANY_OTHER=49;
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
			"WS", "PRINT", "STRUCT", "INTERFACE", "IF", "ELSE", "WHILE", "CALLER", 
			"RETURN", "SEMICOLON", "COMMA", "LEFT_BRACE", "RIGHT_BRACE", "LEFT_PAREN", 
			"RIGHT_PAREN", "LEFT_BRACKET", "RIGHT_BRACKET", "QUESTION_MARK", "ELLIPSIS", 
			"PERIOD", "COLON", "ARROW", "PLUS", "MINUS", "MULTIPLY", "DIVIDE", "MODULO", 
			"NOT", "AND", "OR", "EQUALS", "NOT_EQUALS", "LESS_THAN", "LESS_THAN_OR_EQUAL", 
			"GREATER_THAN", "GREATER_THAN_OR_EQUAL", "IS_DEFINED_AS", "IDENTIFIER", 
			"UNDERSCORE", "CLOSE_COMMENT", "NESTED_COMMENT", "ANY_OTHER"
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
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\2\63\u0139\b\1\b\1"+
		"\4\2\t\2\4\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t"+
		"\n\4\13\t\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4"+
		"\22\t\22\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4"+
		"\31\t\31\4\32\t\32\4\33\t\33\4\34\t\34\4\35\t\35\4\36\t\36\4\37\t\37\4"+
		" \t \4!\t!\4\"\t\"\4#\t#\4$\t$\4%\t%\4&\t&\4\'\t\'\4(\t(\4)\t)\4*\t*\4"+
		"+\t+\4,\t,\4-\t-\4.\t.\4/\t/\4\60\t\60\4\61\t\61\4\62\t\62\3\2\6\2h\n"+
		"\2\r\2\16\2i\3\3\6\3m\n\3\r\3\16\3n\3\3\3\3\6\3s\n\3\r\3\16\3t\3\4\3\4"+
		"\7\4y\n\4\f\4\16\4|\13\4\3\4\3\4\3\5\3\5\3\5\3\5\3\5\3\5\3\5\3\5\3\5\5"+
		"\5\u0089\n\5\3\6\3\6\3\6\3\6\3\6\3\7\3\7\3\7\3\7\7\7\u0094\n\7\f\7\16"+
		"\7\u0097\13\7\3\7\3\7\3\7\3\7\3\b\3\b\3\b\3\b\3\b\3\b\3\t\6\t\u00a4\n"+
		"\t\r\t\16\t\u00a5\3\t\3\t\3\n\3\n\3\n\3\n\3\n\3\n\3\13\3\13\3\13\3\13"+
		"\3\13\3\13\3\13\3\f\3\f\3\f\3\f\3\f\3\f\3\f\3\f\3\f\3\f\3\r\3\r\3\r\3"+
		"\16\3\16\3\16\3\16\3\16\3\17\3\17\3\17\3\17\3\17\3\17\3\20\3\20\3\20\3"+
		"\20\3\20\3\20\3\20\3\21\3\21\3\21\3\21\3\21\3\21\3\21\3\22\3\22\3\23\3"+
		"\23\3\24\3\24\3\25\3\25\3\26\3\26\3\27\3\27\3\30\3\30\3\31\3\31\3\32\3"+
		"\32\3\33\3\33\3\33\3\33\3\34\3\34\3\35\3\35\3\36\3\36\3\36\3\37\3\37\3"+
		" \3 \3!\3!\3\"\3\"\3#\3#\3$\3$\3%\3%\3%\3&\3&\3&\3\'\3\'\3\'\3(\3(\3("+
		"\3)\3)\3*\3*\3*\3+\3+\3,\3,\3,\3-\3-\3.\5.\u011f\n.\3.\3.\7.\u0123\n."+
		"\f.\16.\u0126\13.\3/\3/\3\60\3\60\3\60\3\60\3\60\3\60\3\61\3\61\3\61\3"+
		"\61\3\61\3\61\3\62\3\62\3\62\3\62\4z\u0095\2\63\4\3\6\4\b\5\n\6\f\7\16"+
		"\b\20\t\22\n\24\13\26\f\30\r\32\16\34\17\36\20 \21\"\22$\23&\24(\25*\26"+
		",\27.\30\60\31\62\32\64\33\66\348\35:\36<\37> @!B\"D#F$H%J&L\'N(P)R*T"+
		"+V,X-Z.\\/^\60`\61b\62d\63\4\2\3\7\3\2\62;\5\2\13\f\17\17\"\"\3\2aa\4"+
		"\2C\\c|\6\2\62;C\\aac|\2\u0140\2\4\3\2\2\2\2\6\3\2\2\2\2\b\3\2\2\2\2\n"+
		"\3\2\2\2\2\f\3\2\2\2\2\16\3\2\2\2\2\20\3\2\2\2\2\22\3\2\2\2\2\24\3\2\2"+
		"\2\2\26\3\2\2\2\2\30\3\2\2\2\2\32\3\2\2\2\2\34\3\2\2\2\2\36\3\2\2\2\2"+
		" \3\2\2\2\2\"\3\2\2\2\2$\3\2\2\2\2&\3\2\2\2\2(\3\2\2\2\2*\3\2\2\2\2,\3"+
		"\2\2\2\2.\3\2\2\2\2\60\3\2\2\2\2\62\3\2\2\2\2\64\3\2\2\2\2\66\3\2\2\2"+
		"\28\3\2\2\2\2:\3\2\2\2\2<\3\2\2\2\2>\3\2\2\2\2@\3\2\2\2\2B\3\2\2\2\2D"+
		"\3\2\2\2\2F\3\2\2\2\2H\3\2\2\2\2J\3\2\2\2\2L\3\2\2\2\2N\3\2\2\2\2P\3\2"+
		"\2\2\2R\3\2\2\2\2T\3\2\2\2\2V\3\2\2\2\2X\3\2\2\2\2Z\3\2\2\2\2\\\3\2\2"+
		"\2\2^\3\2\2\2\3`\3\2\2\2\3b\3\2\2\2\3d\3\2\2\2\4g\3\2\2\2\6l\3\2\2\2\b"+
		"v\3\2\2\2\n\u0088\3\2\2\2\f\u008a\3\2\2\2\16\u008f\3\2\2\2\20\u009c\3"+
		"\2\2\2\22\u00a3\3\2\2\2\24\u00a9\3\2\2\2\26\u00af\3\2\2\2\30\u00b6\3\2"+
		"\2\2\32\u00c0\3\2\2\2\34\u00c3\3\2\2\2\36\u00c8\3\2\2\2 \u00ce\3\2\2\2"+
		"\"\u00d5\3\2\2\2$\u00dc\3\2\2\2&\u00de\3\2\2\2(\u00e0\3\2\2\2*\u00e2\3"+
		"\2\2\2,\u00e4\3\2\2\2.\u00e6\3\2\2\2\60\u00e8\3\2\2\2\62\u00ea\3\2\2\2"+
		"\64\u00ec\3\2\2\2\66\u00ee\3\2\2\28\u00f2\3\2\2\2:\u00f4\3\2\2\2<\u00f6"+
		"\3\2\2\2>\u00f9\3\2\2\2@\u00fb\3\2\2\2B\u00fd\3\2\2\2D\u00ff\3\2\2\2F"+
		"\u0101\3\2\2\2H\u0103\3\2\2\2J\u0105\3\2\2\2L\u0108\3\2\2\2N\u010b\3\2"+
		"\2\2P\u010e\3\2\2\2R\u0111\3\2\2\2T\u0113\3\2\2\2V\u0116\3\2\2\2X\u0118"+
		"\3\2\2\2Z\u011b\3\2\2\2\\\u011e\3\2\2\2^\u0127\3\2\2\2`\u0129\3\2\2\2"+
		"b\u012f\3\2\2\2d\u0135\3\2\2\2fh\t\2\2\2gf\3\2\2\2hi\3\2\2\2ig\3\2\2\2"+
		"ij\3\2\2\2j\5\3\2\2\2km\t\2\2\2lk\3\2\2\2mn\3\2\2\2nl\3\2\2\2no\3\2\2"+
		"\2op\3\2\2\2pr\7\60\2\2qs\t\2\2\2rq\3\2\2\2st\3\2\2\2tr\3\2\2\2tu\3\2"+
		"\2\2u\7\3\2\2\2vz\7$\2\2wy\13\2\2\2xw\3\2\2\2y|\3\2\2\2z{\3\2\2\2zx\3"+
		"\2\2\2{}\3\2\2\2|z\3\2\2\2}~\7$\2\2~\t\3\2\2\2\177\u0080\7v\2\2\u0080"+
		"\u0081\7t\2\2\u0081\u0082\7w\2\2\u0082\u0089\7g\2\2\u0083\u0084\7h\2\2"+
		"\u0084\u0085\7c\2\2\u0085\u0086\7n\2\2\u0086\u0087\7u\2\2\u0087\u0089"+
		"\7g\2\2\u0088\177\3\2\2\2\u0088\u0083\3\2\2\2\u0089\13\3\2\2\2\u008a\u008b"+
		"\7p\2\2\u008b\u008c\7w\2\2\u008c\u008d\7n\2\2\u008d\u008e\7n\2\2\u008e"+
		"\r\3\2\2\2\u008f\u0090\7\61\2\2\u0090\u0091\7\61\2\2\u0091\u0095\3\2\2"+
		"\2\u0092\u0094\13\2\2\2\u0093\u0092\3\2\2\2\u0094\u0097\3\2\2\2\u0095"+
		"\u0096\3\2\2\2\u0095\u0093\3\2\2\2\u0096\u0098\3\2\2\2\u0097\u0095\3\2"+
		"\2\2\u0098\u0099\7\f\2\2\u0099\u009a\3\2\2\2\u009a\u009b\b\7\2\2\u009b"+
		"\17\3\2\2\2\u009c\u009d\7\61\2\2\u009d\u009e\7,\2\2\u009e\u009f\3\2\2"+
		"\2\u009f\u00a0\b\b\3\2\u00a0\u00a1\b\b\2\2\u00a1\21\3\2\2\2\u00a2\u00a4"+
		"\t\3\2\2\u00a3\u00a2\3\2\2\2\u00a4\u00a5\3\2\2\2\u00a5\u00a3\3\2\2\2\u00a5"+
		"\u00a6\3\2\2\2\u00a6\u00a7\3\2\2\2\u00a7\u00a8\b\t\2\2\u00a8\23\3\2\2"+
		"\2\u00a9\u00aa\7r\2\2\u00aa\u00ab\7t\2\2\u00ab\u00ac\7k\2\2\u00ac\u00ad"+
		"\7p\2\2\u00ad\u00ae\7v\2\2\u00ae\25\3\2\2\2\u00af\u00b0\7u\2\2\u00b0\u00b1"+
		"\7v\2\2\u00b1\u00b2\7t\2\2\u00b2\u00b3\7w\2\2\u00b3\u00b4\7e\2\2\u00b4"+
		"\u00b5\7v\2\2\u00b5\27\3\2\2\2\u00b6\u00b7\7k\2\2\u00b7\u00b8\7p\2\2\u00b8"+
		"\u00b9\7v\2\2\u00b9\u00ba\7g\2\2\u00ba\u00bb\7t\2\2\u00bb\u00bc\7h\2\2"+
		"\u00bc\u00bd\7c\2\2\u00bd\u00be\7e\2\2\u00be\u00bf\7g\2\2\u00bf\31\3\2"+
		"\2\2\u00c0\u00c1\7k\2\2\u00c1\u00c2\7h\2\2\u00c2\33\3\2\2\2\u00c3\u00c4"+
		"\7g\2\2\u00c4\u00c5\7n\2\2\u00c5\u00c6\7u\2\2\u00c6\u00c7\7g\2\2\u00c7"+
		"\35\3\2\2\2\u00c8\u00c9\7y\2\2\u00c9\u00ca\7j\2\2\u00ca\u00cb\7k\2\2\u00cb"+
		"\u00cc\7n\2\2\u00cc\u00cd\7g\2\2\u00cd\37\3\2\2\2\u00ce\u00cf\7e\2\2\u00cf"+
		"\u00d0\7c\2\2\u00d0\u00d1\7n\2\2\u00d1\u00d2\7n\2\2\u00d2\u00d3\7g\2\2"+
		"\u00d3\u00d4\7t\2\2\u00d4!\3\2\2\2\u00d5\u00d6\7t\2\2\u00d6\u00d7\7g\2"+
		"\2\u00d7\u00d8\7v\2\2\u00d8\u00d9\7w\2\2\u00d9\u00da\7t\2\2\u00da\u00db"+
		"\7p\2\2\u00db#\3\2\2\2\u00dc\u00dd\7=\2\2\u00dd%\3\2\2\2\u00de\u00df\7"+
		".\2\2\u00df\'\3\2\2\2\u00e0\u00e1\7}\2\2\u00e1)\3\2\2\2\u00e2\u00e3\7"+
		"\177\2\2\u00e3+\3\2\2\2\u00e4\u00e5\7*\2\2\u00e5-\3\2\2\2\u00e6\u00e7"+
		"\7+\2\2\u00e7/\3\2\2\2\u00e8\u00e9\7]\2\2\u00e9\61\3\2\2\2\u00ea\u00eb"+
		"\7_\2\2\u00eb\63\3\2\2\2\u00ec\u00ed\7A\2\2\u00ed\65\3\2\2\2\u00ee\u00ef"+
		"\7\60\2\2\u00ef\u00f0\7\60\2\2\u00f0\u00f1\7\60\2\2\u00f1\67\3\2\2\2\u00f2"+
		"\u00f3\7\60\2\2\u00f39\3\2\2\2\u00f4\u00f5\7<\2\2\u00f5;\3\2\2\2\u00f6"+
		"\u00f7\7/\2\2\u00f7\u00f8\7@\2\2\u00f8=\3\2\2\2\u00f9\u00fa\7-\2\2\u00fa"+
		"?\3\2\2\2\u00fb\u00fc\7/\2\2\u00fcA\3\2\2\2\u00fd\u00fe\7,\2\2\u00feC"+
		"\3\2\2\2\u00ff\u0100\7\61\2\2\u0100E\3\2\2\2\u0101\u0102\7\'\2\2\u0102"+
		"G\3\2\2\2\u0103\u0104\7#\2\2\u0104I\3\2\2\2\u0105\u0106\7(\2\2\u0106\u0107"+
		"\7(\2\2\u0107K\3\2\2\2\u0108\u0109\7~\2\2\u0109\u010a\7~\2\2\u010aM\3"+
		"\2\2\2\u010b\u010c\7?\2\2\u010c\u010d\7?\2\2\u010dO\3\2\2\2\u010e\u010f"+
		"\7#\2\2\u010f\u0110\7?\2\2\u0110Q\3\2\2\2\u0111\u0112\7>\2\2\u0112S\3"+
		"\2\2\2\u0113\u0114\7>\2\2\u0114\u0115\7?\2\2\u0115U\3\2\2\2\u0116\u0117"+
		"\7@\2\2\u0117W\3\2\2\2\u0118\u0119\7@\2\2\u0119\u011a\7?\2\2\u011aY\3"+
		"\2\2\2\u011b\u011c\7?\2\2\u011c[\3\2\2\2\u011d\u011f\t\4\2\2\u011e\u011d"+
		"\3\2\2\2\u011e\u011f\3\2\2\2\u011f\u0120\3\2\2\2\u0120\u0124\t\5\2\2\u0121"+
		"\u0123\t\6\2\2\u0122\u0121\3\2\2\2\u0123\u0126\3\2\2\2\u0124\u0122\3\2"+
		"\2\2\u0124\u0125\3\2\2\2\u0125]\3\2\2\2\u0126\u0124\3\2\2\2\u0127\u0128"+
		"\7a\2\2\u0128_\3\2\2\2\u0129\u012a\7,\2\2\u012a\u012b\7\61\2\2\u012b\u012c"+
		"\3\2\2\2\u012c\u012d\b\60\4\2\u012d\u012e\b\60\2\2\u012ea\3\2\2\2\u012f"+
		"\u0130\7\61\2\2\u0130\u0131\7,\2\2\u0131\u0132\3\2\2\2\u0132\u0133\b\61"+
		"\3\2\u0133\u0134\b\61\2\2\u0134c\3\2\2\2\u0135\u0136\13\2\2\2\u0136\u0137"+
		"\3\2\2\2\u0137\u0138\b\62\2\2\u0138e\3\2\2\2\r\2\3intz\u0088\u0095\u00a5"+
		"\u011e\u0124\5\b\2\2\7\3\2\6\2\2";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}