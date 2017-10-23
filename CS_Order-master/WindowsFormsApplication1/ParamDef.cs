using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Drawing;
using System.Runtime.InteropServices;

namespace SimpleCase
{
    public partial class ParamDef
    {
        #region 資料結構宣告
        public struct AccountInfo
        {
            public char cAcctType;
            public string szBranchNo;
            public string szAccount;
            public string szName;
			public string szId;
			public int Id_Cmt;

			public bool CA_Check;
			public int CA_Status;
        };

        public struct EXCHINFO
        {
            public ushort mExch;
            public ushort sExch;
            public char TranType;      //交易市場別
            public uint ExchState;     //目前交易狀態
            public uint TradeDate;     //交易市場日期
            public string ExchAlarm;   //價格檢查警示
            public string ExchName;    //交易市場名稱
            public string ExtraType;   //交易市場代號
            public string ExchMessage; //交易狀態訊息
        };
    
        [StructLayout(LayoutKind.Sequential)]
        public struct RESERVEQUANTITY
        {
            public int BitsBalanceToday;       //零股
            public int StockBalanceYesterday;  //現股昨餘
            public int StockBalanceToday;      //現股今餘
            public int StockTrustBuy;          //現股買委
            public int StockTrustSell;         //現股賣委
            public int StockMatchBuy;          //現股買成
            public int StockMatchSell;         //現股賣成
            public int FinaBalanceYesterday;   //融資昨餘
            public int FinaBalanceToday;       //融資今餘
            public int FinaTrustBuy;           //融資買委
            public int FinaTrustSell;          //融資賣委
            public int FinaMatchBuy;           //融資買成
            public int FinaMatchSell;          //融資賣成
            public int SecuBalanceYesterday;   //融券昨餘
            public int SecuBalanceToday;       //融券今餘
            public int SecuTrustBuy;           //融券買委
            public int SecuTrustSell;          //融券賣委
            public int SecuMatchBuy;           //融券買成
            public int SecuMatchSell;          //融券賣成
        };
        public struct RESERVEQUANTITY_COLLECT
        {
            public char AccountType;
            public string BranchNo;
            public string Account;
            public ushort mExch;
            public ushort TranType;
            public string Symbol;
            public string Currency;
            public RESERVEQUANTITY rsvqty;
        };

        public struct FUTUREPOSITION
        {
            public int SettleUp;               //了結
            public int OILongYesterday;        //昨日留倉-買
            public int OIShortYesterday;       //昨日留倉-賣
            public int TrustLong;              //本日委託-買
            public int TrustShort;             //本日委託-賣
            public int MatchLong;              //目前成交-買
            public int MatchShort;             //目前成交-賣
            public int OILongToday;            //目前留倉-買
            public int OIShortToday;           //目前留倉-賣
            public double MatchLongPrice;      //平均成本-買
            public double MatchShortPrice;     //平均成本-賣
            public double MatchLongValue;      //成交總金額-買
            public double MatchShortValue;     //成交總金額-賣
        };
        public struct FUTUREPOSITION_COLLECT
        {
            public char AccountType;
            public string BranchNo;
            public string Account;
            public ushort mExch;
            public ushort TranType;
            public string Symbol;
            public string Currency;
            public FUTUREPOSITION futpos;
        };

        public struct ENTRUST_COLLECT
        {
            public string BranchNo;  //券商 OR 期貨商代碼
            public string Account;   //帳號
            public char ltype;       //登入類別
            public string sname  ;   //中文名
            public char Status;      //委託狀態
            public string KeyNo;     //電子單號        : 委託和成交單比對次要欄位
            public string OrderSheet;//交易所委回櫃序號: 委託和成交單比對優先欄位 (委託和成交單欄位須具值)
            public string OrderNo;   //交易單號
            public ushort mExch;     //主要股市別
            public ushort sExch;     //次要股市別
            public string Symbol;    //股票代碼
            public char oType;       //交易別
            public char TranType;    //交易股市別: C:普通, F:定價, D:零股, T:期貨, O:選擇權, E:興櫃, S:國外
            public char Cdi;         //易動別, I: 新增, C: 改量, D: 刪單
            public char BuySell;     //B: 買進, S: 賣出
            public string tprice;    //委託價格
			public string mprice;    //成交價格
            public string aprice;    //成交均價
            public string stopprc;   //觸價價格
            public string rcvrprc;   //追價價格(OCO)
            public int tqty;        //委託數量, 新增單為委託數, 刪改單為刪改後數
            public int cqty;        //改變數量(成功數量), 新增單為 0, 刪改單為刪改數
            public int lqty;        //委託可刪量 (含成交)
            public int eqty;        //總取消數量
            public int mqty;        //成交數量
            public int aqty;        //委託後量
            public int bqty;        //委託前量
			public int uqty;        //委託可刪量 (AP用)
            public char valid;       //顯示刪改
            public uint kdate;       //委託下單日期
            public uint ktime;       //委託下單時間
            public uint bdate;       //下單交易日 (有效日期?): 21-1 交易股市狀態出現 比對交易市場日期 (TradeDate), 判斷回報之刪改欄位顯示與否
            public uint btime;       //交易所委託回報時間
            public uint ttime;       //成交時間
            public string fordt;     //委託條件
            public uint stoptp;      //觸價種類
            public string stopcond;   //觸價條件
            public string stopcondstr; //觸價條件顯示字串
            public string prcml;     //限、市價
            public char DayTrade;    //當沖碼
            public char chgprc;      //指定改價（期交所）: Y:改價, N:改量
            public string msg;       //訊息
            public string statusstr; //狀態顯示字串
			public int ReportType;   //回報類別
        };
        
        #endregion

		#region UI介面
		public static Color BuyColor= Color.Red;
        public static Color SellColor= Color.Green;

		public const string MENU_TAG_FONT= "Font";
		public const string MENU_TAG_FIELDSET= "FieldSet";

		public const string NULL_PRC= "--";
		public const string NULL_FIELD= "--";

		public const string DEC_FORMAT= "F2";  //未定義之顯示小數位數格式

		public const int RPT_TRUST= 0;
		public const int RPT_MATCH= 1;

		#endregion

		#region 帳號
        public enum IDTYPE
        {
            itNone = 0,
            itIdentity = ' ',
            itStock = 'T',
            itNTC = 'E',
            itFuture = 'F',
            itStkFut = 'M',
            itIntFut = 'S'
        }

		public const int ACCOUNT_TYPE_MAX = 6;
        public static char[] ACCOUNT_TYPE = new char[ACCOUNT_TYPE_MAX] {' ',    //身分證
                                                                      'T',    //證券帳號
                                                                      'F',    //期貨帳號
                                                                      'M',    //證期合一
                                                                      'S',    //國際期貨
                                                                      ' '};   //營業員

		//帳號類別
        public const string ACCOUNT_TYPE_ID = "身分證";
        public const string ACCOUNT_TYPE_T  = "證券帳號";
        public const string ACCOUNT_TYPE_F  = "期貨帳號";
        public const string ACCOUNT_TYPE_M  = "證期合一";
        public const string ACCOUNT_TYPE_S  = "國際期貨";

        //  帳號 Status Bits Set  //  The Mask of Account-Comment
		public const uint MAC_ORDALL = (1 << 1);
		public const uint MAC_QRYALL = (1 << 2);
		public const uint MAC_ORDSAL = (1 << 3);
		public const uint MAC_ORDPCK = (1 << 4);
		public const uint MAC_ORDNMK = (1 << 5);
		public const uint MAC_ORDUCA = (1 << 6);
		public const uint MAC_ORDCOP = (1 << 7);
		public const uint MAC_ORDCND = (1 << 8);

		//CA
		public const int CS_ERROR_CERTSIGN          = -2;  // 憑證簽章錯誤
		public const int CS_ERROR_INIT_LIB          = -1;  // 初始化元件錯誤：簽章元件載入錯誤或呼叫函式錯誤
		public const int CS_SUCCESS                 = 0;   // 成功

		public const int CS_ERROR_NO_SIGNERCLASS    = 1;   // 未正確載入簽章模組
		public const int CS_ERROR_NO_SIGNER_TYPE    = 2;   // 未指定簽章元件類別
		public const int CS_ERROR_TYPE_NOT_SURPORT  = 3;   // 指定尚未支援的簽章元件
		public const int CS_ERROR_CERT_SIGNING      = 4;   // 上一筆資料正在進行簽章，在結果未回覆之前無法再進行簽章
		public const int CS_ERROR_NO_EXPDATETIME    = 5;   // 憑證日期未存在或未找到
		public const int CS_ERROR_LIBPATH_NOT_EXIST = 6;   // 簽章元件路徑載入錯誤
		public const int CS_ERROR_NO_SETTING_FILE   = 7;   // 未指定簽章主體設定檔
		public const int CS_ERROR_NO_CERT_SUBJECT   = 8;   // 未指定憑證主體
		public const int CS_ERROR_NO_CERT_FILE      = 9;   // 未指定憑證檔案
		public const int CS_ERROR_UNKNOW            = 999; // 未知錯誤

		#endregion

        #region 市場商品區分
		//---------------------------------------------------------------------------
        //	台灣股市
        //---------------------------------------------------------------------------
        public const int MEXCH_TWN = 1;
               public const int SEXCH_TSE = 0;	// 上市
               public const int SEXCH_OTC = 1;  // 上櫃
               public const int SEXCH_NTC = 4;  // 興櫃
        //---------------------------------------------------------------------------

        //---------------------------------------------------------------------------
        //	台期指
        //---------------------------------------------------------------------------
        public const int MEXCH_TWFX	= 2;
               public const int SEXCH_FTC = 2;  // 期貨
               public const int SEXCH_OPT = 3;  // 選擇權
               public const int SEXCH_FTD = 5;  // 期貨複式(跨月價差)
               public const int SEXCH_FTS = 6;  // 個股期貨
               public const int SEXCH_FSD = 7;  // 個股期貨複式(跨月價差)
        //---------------------------------------------------------------------------

        //---------------------------------------------------------------------------
        //	SIMEX
        //---------------------------------------------------------------------------
        public const int MEXCH_SIMEX = 11;

        //---------------------------------------------------------------------------
        //  NYMEX/COMEX    紐約商業期貨交易所/ 紐約商品期貨交易所
        //---------------------------------------------------------------------------
        public const int MEXCH_NYMEX = 13;

        //---------------------------------------------------------------------------
        //  芝加哥商品交易所
        //---------------------------------------------------------------------------
        public const int MEXCH_CBOT = 14;

        //---------------------------------------------------------------------------
        //	SGX
        //---------------------------------------------------------------------------
        public const int MEXCH_SIMEXN = 16;
               public const int SEXCH_SNK = 1;   // NK 225       (期貨)
               public const int SEXCH_SNT = 2;   // NT 300       (期貨)
               public const int SEXCH_STW = 3;   // MSCI TWN     (期貨)
               public const int SEXCH_SSG = 4;   // 摩星
               public const int SEXCH_SHK = 5;   // 摩港
               public const int SEXCH_SIN = 6;   // 印S&P
               public const int SEXCH_SST = 7;   // 新海峽
               public const int SEXCH_SED = 20;  // 歐元
               public const int SEXCH_SEY = 21;  // 歐日T
               public const int SEXCH_SEL = 22;  // 歐日L
               public const int SEXCH_SSD = 23;  // 星率
               public const int SEXCH_SJB = 25;  // 日債(10Y)
               public const int SEXCH_SSB = 26;  // 星債(5Y)
               public const int SEXCH_SBC = 27;  // Brent Crude Oil
        //---------------------------------------------------------------------------

        //---------------------------------------------------------------------------
        //	美國芝加哥期貨 CME
        //---------------------------------------------------------------------------
        public const int MEXCH_CME = 17;
               public const int SEXCH_IDXFUT = 1;      //指數期貨
               public const int SEXCH_FCFUT = 2;      //外匯期貨
               public const int SEXCH_IRFUT = 3;      //利率期貨
               public const int SEXCH_NYMFUT = 4;      //紐約能源期貨
        //---------------------------------------------------------------------------

        #endregion

		#region 市場 & 交易 & 商品
		public const char BUY = 'B';
		public const char SELL = 'S';

        //交易股市別 - 股票
		public enum Tran_STK
		{
			tcNORMAL = 'C',  //普
			tcFIXED = 'F',   //定
			tcBITS = 'D',    //零
		}
		public const string TRAN_S_0= "普通";
		public const string TRAN_S_1= "定盤";
		public const string TRAN_S_2= "零股";

		//交易別 - 股票
        public enum oType_S
        {
            Stock   = '0',    //現股
            FNAgent = '1',    //資代
            SLAgent = '2',    //券代
            FNSelf  = '3',    //資自
            SLSelf  = '4'     //券自
        }
        public const string OTYPE_S_0 = "現股";
        public const string OTYPE_S_1 = "融資";  //資代
        public const string OTYPE_S_2 = "融券";  //券代
        //public const string OTYPE_S_3 = "融資";  //資自
        //public const string OTYPE_S_4 = "融券";  //券自

		//交易別 - 期權
        public enum oType_F
        {
            Open     = '0',    //新倉
            Close    = '1',    //平倉
            Auto     = '9'     //自動
        }
        public const string OTYPE_F_0 = "新倉";
        public const string OTYPE_F_1 = "平倉";
        public const string OTYPE_F_9 = "自動"; 

        public enum TRANCLASS 
        {
            tcNonClass = 0,
            tcNORMAL = 'C',  //普
            tcFIXED = 'F',  //定
            tcBITS = 'D',  //零
            tcFUTURE = 'T',  //期貨
            tcOPTION = 'O',  //選擇權
            tcNTC = 'E',  //興櫃
            tcINTFUT = 'S',  //國際期貨
            tcCount = 128
        }

        public enum EXCHCLASS
        {
            ecNonClass = 0,
            ecNORMAL = 1,    //普
            ecFIXED = 2,    //定
            ecBITS = 3,    //零
            ecFUTURE = 7,    //期貨
            ecOPTION = 8,    //選擇權
            ecNTC = 10,   //興櫃
            ecINTFUT = 16,   //國際期貨
            ecCount
        }

		public enum CDI   // 委託類型
		{
			otInsert = 'I',  //新增
			otChange = 'C',  //改量
			otDelete = 'D',  //刪單
		}

        public enum ORDSTAT // 委託狀態
        {
            osUD = 'U', //未傳
            osWR = 'I', //待回
            osSU = 'Y', //成功
            osER = 'E', //錯誤
            osOUD = 'W', //預約未傳
            osOSU = 'X', //預約成功(已刪)
            osOWR = 'T', //逾時未回(可刪)
            osUER = 'M', //不明錯誤(刪改單可繼續刪改)
            osCND = 'C', //條件下單 (Defined by AP Programmer)
            osHWR = 'H', //送單待回 (Defined by AP Programmer)
            osHER = 'F'  //送單失敗 (Defined by AP Programmer)
        }

        public enum EXCHSTATE : uint //  交易狀態
        {
            esNONE = 0,
            esNORMAL = 1,    //正常
            esORDER = 3,    //預約
            esPAUSE = 9     //暫停
        }

        public class OTypeValue
        {
            public string Name= "";
            public char Value= '0';     
        };

        public class FordtValue
        {
            public string Fordt= "";
            public string mktStr= "";
            public bool mktEn= false;
            public bool lmtEn= false;
            public bool stpEn= false;

            public FordtFieldRef ffr= null;
        };

        public class StpCondition
        {
            public string Name= "";
            public ushort Value= 0;     
        };

        public class FordtFieldRef
        {
            public string Fordt= "";
            public string Name= "";
            public List<StpCondition> stclist= new List<StpCondition>();        
        };

		//委託條件
        public const string ORDER_FORDT_ROD = "ROD";
        public const string ORDER_FORDT_IOC = "IOC";
        public const string ORDER_FORDT_FOK = "FOK";
        public const string ORDER_FORDT_FAK = "FAK";
        public const string ORDER_FORDT_SLO = "SLO";
        public const string ORDER_FORDT_STI = "STI";
        public const string ORDER_FORDT_ROC = "ROC";
        public const string ORDER_FORDT_MOO = "MOO";
        public const string ORDER_FORDT_MOC = "MOC";
        public const string ORDER_FORDT_AO  = "AO";
        public const string ORDER_FORDT_OCO = "OCO";

        public const string ORDER_FORDT_ROD_DESC = "ROD 當日有效";
        public const string ORDER_FORDT_IOC_DESC = "IOC 立刻成交或取消";
        public const string ORDER_FORDT_FOK_DESC = "FOK 全部成交否則取消";
        public const string ORDER_FORDT_FAK_DESC = "FAK 立刻成交或取消";
        public const string ORDER_FORDT_SLO_DESC = "SLO 觸價委託";
        public const string ORDER_FORDT_STI_DESC = "STI 停損委託";
        public const string ORDER_FORDT_ROC_DESC = "ROC";
        public const string ORDER_FORDT_MOO_DESC = "MOO";
        public const string ORDER_FORDT_MOC_DESC = "MOC";
        public const string ORDER_FORDT_AO_DESC  = "AO 競價盤";
        public const string ORDER_FORDT_OCO_DESC = "OCO 雙向限價";

        public static string RUNMODE_REALTIME  = "即時交易";
        public static string RUNMODE_LIMIT     = "限價交易 Limit";
        public static string RUNMODE_STOPLIMIT = "觸價交易 StopLimit";
        public static string RUNMODE_OCO       = "雙向限價 OCO";

		public static string PRCML_MKT_STR = "市價";
		public static string PRCML_MKT = "MKT";
		public static string PRCML_LMT = "LMT";
		public static string PRC_MKT = "S0";
		public static string PRC_MTL = "T0";
		public static string PRC_AO = "A0";
		public static string PRC_AO_STR = "AO 盤前競價";

		public static string PRC_M0 = "M0";  //漲停價
		public static string PRC_D0 = "D0";  //跌停價
		public static string PRC_00 = "00";  //平盤價
		public static string PRC_M0_STR = "漲停價";
		public static string PRC_D0_STR = "跌停價";
		public static string PRC_00_STR = "平盤價";

        public static string PRC_FIXED = "S0";
		public static string PRC_FIXED_STR = "定盤價";

		public const int MARKET_COUNT = 2;
        public const string MARKET_OF_FUTURE = "FUT";
        public const string MARKET_OF_OPTION = "OPT";

        public const int EXCH_FUTURE =   0;  //國內期貨交易所商品
        public const int EXCH_SFUTURE =  1;  //國外期貨交易所商品

        public const int EXCH_OPTION =   0;  //國內選擇權商品
        public const int EXCH_SOPTION =  1;  //國外選擇權商品

        public const bool ENTRUST_CONFIRM_EN= true;

		public const bool OCO_EN= false;

		#endregion

		#region 回報
		public enum TStateType
        {
            asCreate,
            asFree
		}

		//連線回報
        public const int CONNECT_NMSG_SYS = 1;  //系統訊息[預設]
        public const int CONNECT_NMSG_WEB = 2;  //訊息網頁URL,20040702新增
        public const int CONNECT_NMSG_ERR = 7;  //錯誤訊息
        public const int CONNECT_SUCCESS = 0;   //連線成功
        public const int CONNECT_FAILURE = -1;  //連線失敗
        public const int CONNECT_ERROR_PARAM = -2;  //連線參數錯誤
        public const int CONNECT_ERROR_STARTUP= -3;  //網路啟動錯誤

        //主動訊息回報 ********************************************************************
        public const int ACTIVE_ACTIONSTATE              = 0x0000;  //狀態回報
        public const int ACTIVE_SERVER_ECHO              = 0x0001;  //伺服器回報
       
        public const int ACTIVE_SYMBOLLIST_UPDATE_START  = 0x0100;  //交易商品代碼表更新開始
        public const int ACTIVE_SYMBOLLIST_UPDATE_FINISH = 0x0101;  //交易商品代碼表更新完成
        public const int ACTIVE_SNOR_UPDATE_START        = 0x0102;  //期貨選擇權類別表更新開始
        public const int ACTIVE_SNOR_UPDATE_FINISH       = 0x0103;  //期貨選擇權類別表更新完成
        public const int ACTIVE_EXCHCATE_UPDATE_START    = 0x0104;  //可交易股市列表更新開始
        public const int ACTIVE_EXCHCATE_UPDATE_FINISH   = 0x0105;  //可交易股市列表更新完成
        public const int ACTIVE_FIELDREF_UPDATE_START    = 0x0106;  //欄位參數資訊更新開始
        public const int ACTIVE_FIELDREF_UPDATE_FINISH   = 0x0107;  //欄位參數資訊更新完成
        public const int ACTIVE_TICKBEAT_UPDATE_START    = 0x0108;  //跳動檔位類別表更新開始
        public const int ACTIVE_TICKBEAT_UPDATE_FINISH   = 0x0109;  //跳動檔位類別表更新完成
 
		public const int ACTIVE_ACCT_NOTEXIST            = 0x0200;  //帳號不存在
        public const int ACTIVE_ACCT_PASSWORD_ERROR      = 0x0201;  //密碼錯誤
		public const int ACTIVE_ACCT_ACCOUNT_EXPIRED     = 0x0202;  //帳號過期
		public const int ACTIVE_ACCT_LOGIN_ERROR         = 0x0203;  //登入錯誤(帶原因)
        public const int ACTIVE_ACCT_FIRSTLOGIN          = 0x0204;  //第一次登入
		public const int ACTIVE_ACCT_PASSWORD_EXPIRED    = 0x0205;  //密碼過期      
        public const int ACTIVE_ACCT_LOGOUT              = 0x0206;  //登出回覆     
		//*********************************************************************************

        public const int DEBUG_LOGTYPE_COMMON = 0xa1;
        public const int DEBUG_LOGTYPE_RECV   = 0xa2;
        public const int DEBUG_LOGTYPE_SEND   = 0xa3;
        public const int DEBUG_LOGTYPE_SENT   = 0xa4;
        public const int DEBUG_LOGTYPE_PARSER = 0xa5;
        public const int DEBUG_LOGTYPE_ERROR  = 0xa6;

		public const int REPORT_FLAG_NONE         = -1;
        public const int REPORT_FLAG_HIS_TRUST    =  0;  //歷史回報 (委託)
        public const int REPORT_FLAG_HIS_MATCH    =  1;  //歷史回報 (成交)
        public const int REPORT_FLAG_HIS_SUMMARY  =  2;  //歷史回報 (匯總)
        public const int REPORT_FLAG_RT_TRUST     =  3;  //即時回報 (委託)
        public const int REPORT_FLAG_RT_MATCH     =  4;  //即時回報 (成交)
        public const int REPORT_FLAG_RT_SUMMARY   =  5;  //即時回報 (匯總)
		public const int REPORT_FLAG_RTS_TRUST     =  6;  //即時回報 (單筆委託)
        public const int REPORT_FLAG_RTS_MATCH     =  7;  //即時回報 (單筆成交)

		#endregion

		#region 欄位

        public enum F_REPORT : int
		{			
			CHANGE= 0,  //刪改
			STATUS,     //委託狀態
			NAME,       //商品
			BS,         //買賣別
            MPRICE,     //成交價
			MQTY,       //成交量
			FORDT,      //委託條件
			TPRICE,     //委託價
			TQTY,       //委託量
			EQTY,       //取消
			AQTY,       //餘量
			TTIME,      //委託時間
			MTIME,      //成交時間
			MDATE,      //成交日期
			ORDERSHEET, //委託單號
			KEYNO,      //電子單號
			ORDERNU,    //交易單號
            COUNT
		};

        public const string RPT_FN_CHANGE    = "刪/改";
        public const string RPT_FN_STATUS    = "委託狀態";
        public const string RPT_FN_NAME      = "商品";
        public const string RPT_FN_BS        = "買賣別";
        public const string RPT_FN_MPRICE    = "成交價";
        public const string RPT_FN_MQTY      = "成交量";
        public const string RPT_FN_FORDT     = "委託條件";
        public const string RPT_FN_TPRICE    = "委託價";
        public const string RPT_FN_TQTY      = "委託量";
        public const string RPT_FN_EQTY      = "取消";
		public const string RPT_FN_AQTY      = "餘量";
        public const string RPT_FN_TTIME     = "委託時間";
        public const string RPT_FN_MTIME     = "成交時間";
        public const string RPT_FN_MDATE     = "成交日期";
        public const string RPT_FN_ORDERSHEET= "委託單號";
        public const string RPT_FN_KEYNO     = "電子單號";
        public const string RPT_FN_ORDERNU   = "交易單號";

		#endregion

        #region CA參數

        public enum TCertType
		{
			caFreeStyle,    //不使用憑證
			caFormosoftNML, //全景 一般
			caFormosoftPFX, //全景 PFX
			caMSStockNML,   //MSStockOCX 一般
			caMSStockPFX,   //MSStockOCX PFX (No one uses this.)
			caTaiCaNML,     //TaiCA 一般
			caTaiCaPFX,     //TaiCA PFX
			caVSPTANML,     //VeriSign Personal Trust Agent 一般
			caVSPTAPFX,     //VeriSign Personal Trust Agent PFX (No one uses this.)
			caAFXeKeyNML,   //AFX eKey Normal
			caAFXeKeyPFX,   //AFX eKey PFX
			caCAPICOMNML,   //Microsoft CAPICOM 一般
			caCAPICOMPFX,   //Microsoft CAPICOM PFX
			caMSSignNML,    //MSSignOCX 一般
			caMSSignPFX,    //MSSignOCX PFX (No one uses this.)
			caHiTrustNML,   //HiTrust 一般
			caHiTrustPFX,   //HiTrust PFX (No one uses this.)
			caDCCapiNML,    //DC Securities ATL Normal
			caDCCapiPFX,    //DC Securities ATL PFX
			caCOUNT
		}
        #endregion
        #region  保險單程式條件
        public struct Condition_bundle
        {
            public string Monitor_target;// 監控標的
            public string Condition;       //大於或小於
            public ushort trigger_point; //觸發點
            public ushort Order_typ;     //下單標的 0=期貨 1=買權 2=賣權
            public ushort Order_typ_BorS;//下單買或賣
            public ushort Option_trgt ;   //選擇權標的 期貨則為０
            public ushort Option_month;   //選擇權月分
            public string Order_p;       //下單價格根據  成交or ...
            public ushort Order_q;       //下單數量
            public ushort offset_point;  //平倉點
            public ushort delay_sec;     //智慧改單延遲秒數
            public bool condition_loop;//循環
            public DateTime duration;    //有效時間             
        }


        #endregion

        #region 
                

        
        #endregion

    }
}
