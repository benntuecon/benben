using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using P = SimpleCase.ParamDef;

namespace SimpleCase
{
    public partial class OrderApi
    {
        #region Dll API宣告

        [DllImport("DLL\\NetStockOrder3API.dll")]
        public static extern int NS_OrderInit();
        [DllImport("DLL\\NetStockOrder3API.dll")]
        public static extern void NS_OrderClose();
        [DllImport("DLL\\NetStockOrder3API.dll")]
        public static extern int NS_SetConnectEvent(ptConnectEvent ConnectEvent);
        [DllImport("DLL\\NetStockOrder3API.dll")]
        public static extern int NS_SetActiveEvent(ptActiveEvent ActiveEvent);
        [DllImport("DLL\\NetStockOrder3API.dll")]
        public static extern int NS_SetAccountEvent(ptAccountEvent AccountEvent);
        [DllImport("DLL\\NetStockOrder3API.dll")]
        public static extern int NS_SetOpenInterestEvent(ptOpenInterestEvent OpenInterestEvent);
        [DllImport("DLL\\NetStockOrder3API.dll")]
        public static extern int NS_SetOrderReportEvent(ptOrderReportEvent OrderReportEvent);
        [DllImport("DLL\\NetStockOrder3API.dll")]
        public static extern int NS_SetOrderDealEvent(ptOrderDealEvent OrderDealEvent);
        [DllImport("DLL\\NetStockOrder3API.dll")]
        public static extern int NS_SetExchInfoEvent(ptExchInfoEvent ExchInfoEvent);

        [DllImport("DLL\\NetStockOrder3API.dll")]  //登入
        public static extern int NS_OrderLogin(int Type, string BranchNo, string Account, string Password, string IP, ushort Port);
        [DllImport("DLL\\NetStockOrder3API.dll")]  //登出
        public static extern int NS_OrderLogout();
        [DllImport("DLL\\NetStockOrder3API.dll")]  //取得庫存
        public static extern int NS_GetOpenInterest(char AccountType, string BranchNo, string Account);

        [DllImport("DLL\\NetStockOrder3API.dll")]  //取得交易別(根據股市別)
        public static extern string NS_GetOTypeString(ushort mExch, ushort sExch);

        [DllImport("DLL\\NetStockOrder3API.dll")]  //取得期權委託條件(根據股市別)
        public static extern string NS_GetFordtString(ushort mExch, ushort sExch);

        [DllImport("DLL\\NetStockOrder3API.dll")]  //取得期權單一委託條件欄位內容
        public static extern string NS_GetFordtFieldRef(string Fordt);

		[DllImport("DLL\\NetStockOrder3API.dll")]  //國內證券下單
		public static extern int NS_SendStockOrder(char lType, string BranchNo, string Account, ushort mExch, ushort sExch, string Symbol,
	                                               char Tran, char oType, char BuySell, string Price, uint Qty);
		//國內
        [DllImport("DLL\\NetStockOrder3API.dll")]  //國內期權下單
        public static extern int NS_SendFutureOrder(char lType, string BranchNo, string Account, ushort mExch, ushort sExch, string Symbol,
                                                    char Tran, char oType, char BuySell, string Fordt, string Prcml, char DayTrade,                              
                                                    string Price, uint Qty, string Symbol2, char BuySell2, char MtType, ushort FTimes);
		//國外
        [DllImport("DLL\\NetStockOrder3API.dll")]  //國外期權下單
        public static extern int NS_SendFutureOrder_S(char lType, string BranchNo, string Account, ushort mExch, ushort sExch, string Symbol,
                                                      char Tran, char oType, char BuySell, string Fordt, string Prcml, char DayTrade,                              
                                                      string Price, byte Denominator, ushort StopType, string StopPrc, string RecoverPrc, uint Qty, uint RevQty, string Symbol2, char BuySell2, char MtType, ushort FTimes);
        [DllImport("DLL\\NetStockOrder3API.dll")]  //取消委託
        public static extern int NS_CancelOrder(char lType, string BranchNo, string Account, string KeyNo, string OrderSheet, string OrderNo, uint bdate);

        [DllImport("DLL\\NetStockOrder3API.dll")]  //改價改量委託
        public static extern int NS_ChangeOrder(char lType, string BranchNo, string Account, string KeyNo, string OrderSheet, string OrderNo, uint bdate, string Fordt, string Prcml, string Price, string StopPrice, string RecoverPrice, uint Qty, char ChgPrice);

		[DllImport("DLL\\NetStockOrder3API.dll")]  //設定簽章相關條件
        public static extern int NS_SetSignInfo(int CA, string SettingFile, string Section, ref int Status);

		[DllImport("DLL\\NetStockOrder3API.dll")]  //檢查憑證 & 取得憑證到期日
		public static extern int NS_SetCertInfo(string CertFile, string CertPassword, string Id, string BranchNo, string Account, char AccountType, ref int Status, ref ulong dwDate, ref ulong dwTime);

		[DllImport("DLL\\NetStockOrder3API.dll")]  //取得伺服器日期時間
        public static extern void NS_GetDateTime(ref ulong NowDate, ref ulong NowTime);

        [DllImport("DLL\\NetStockOrder3API.dll")]  //商品資訊更新功能
        public static extern void NS_SymbolsEnable(bool Enable);

        [DllImport("DLL\\NetStockOrder3API.dll")]  //交易商品檔匯出
        public static extern void NS_SymbolsExport(int mExch);

        #endregion

        #region Event Callback 宣告

        //連線狀態回報
        public delegate int ptConnectEvent(int RetCode, string Msg);
        ptConnectEvent pApi_ConnectEvent = new ptConnectEvent(Api_ConnectEvent);
        public ptConnectEvent ConnectEvent = null;

        //主動事件回報
        public delegate int ptActiveEvent(int Event, int Param1, int Param2, string Msg);
        ptActiveEvent pApi_ActiveEvent = new ptActiveEvent(Api_ActiveEvent);
        public ptActiveEvent ActiveEvent = null;

        //交易帳號回報
        public delegate int ptAccountEvent(char AccountType, string BranchNo, string Account, string Name, string Id, int Id_Cmt);
        ptAccountEvent pApi_AccountEvent = new ptAccountEvent(Api_AccountEvent);
        public ptAccountEvent AccountEvent = null;

        //查詢庫存回報
        public delegate int ptOpenInterestEvent(string Data);
        ptOpenInterestEvent pApi_OpenInterestEvent = new ptOpenInterestEvent(Api_OpenInterestEvent);
        public ptOpenInterestEvent OpenInterestEvent = null;

        //委託回報
        public delegate int ptOrderReportEvent(string Data);
        ptOrderReportEvent pApi_OrderReportEvent = new ptOrderReportEvent(Api_OrderReportEvent);
        public ptOrderReportEvent OrderReportEvent = null;

        //成交回報
        public delegate int ptOrderDealEvent(string Data);
        ptOrderDealEvent pApi_OrderDealEvent = new ptOrderDealEvent(Api_OrderDealEvent);
        public ptOrderDealEvent OrderDealEvent = null;

        //股市交易狀態回報
        public delegate int ptExchInfoEvent(string Data);
        ptExchInfoEvent pApi_ExchInfoEvent = new ptExchInfoEvent(Api_ExchInfoEvent);
        public ptExchInfoEvent ExchInfoEvent = null;

        #endregion

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
            caMegaCapiNML,  //Mega Securities ATL Normal
            caMegaCapiPFX,  //Mega Securities ATL PFX
            caYTFinaATLNML, //元大奇唯 ATL Normal
            caYTFinaATLPFX, //元大奇唯 ATL PFX
			caCOUNT
		}

        private static OrderApi _inst;
        public static OrderApi inst
        {
            get
            {
                if (_inst == null)
                    _inst = new OrderApi();
                return _inst;
            }
        }
        public OrderApi() {
        }

        public int Init(bool SymbolEnable)
        {
            NS_SetActiveEvent(pApi_ActiveEvent);
            NS_SetConnectEvent(pApi_ConnectEvent);
            NS_SetAccountEvent(pApi_AccountEvent);
            NS_SetOpenInterestEvent(pApi_OpenInterestEvent);
            NS_SetOrderReportEvent(pApi_OrderReportEvent);
            NS_SetOrderDealEvent(pApi_OrderDealEvent);
            NS_SetExchInfoEvent(pApi_ExchInfoEvent);

            NS_SymbolsEnable(SymbolEnable);  //商品資訊管理及更新功能
            NS_OrderInit();

            SymbolsExport(P.MEXCH_TWN);  //匯出交易商品檔 : 台股
            SymbolsExport(P.MEXCH_TWFX); //匯出交易商品檔 : 台期
            return 0;
        }

        //商品檔匯出
        public void SymbolsExport(int mExch)
        {
            NS_SymbolsExport(mExch);        
        }

        public void Close()
        {
            NS_OrderClose();
        }

        //連線狀態回報
        private static int Api_ConnectEvent(int RetCode, string Msg)
        {
            if(OrderApi._inst.ConnectEvent!= null) {
               OrderApi._inst.ConnectEvent(RetCode, Msg);
            }
            return 0;
        }

        //主動事件回報
        private static int Api_ActiveEvent(int Event, int Param1, int Param2, string Msg)
        {
            if(OrderApi._inst.ActiveEvent!= null) {
               OrderApi._inst.ActiveEvent(Event, Param1, Param2, Msg);
            }
            return 0;
        }

        //交易帳號回報
        private static int Api_AccountEvent(char AccountType, string BranchNo, string Account, string Name, string Id, int Id_Cmt)
        {
            if(OrderApi._inst.AccountEvent!= null) {
               OrderApi._inst.AccountEvent(AccountType, BranchNo, Account, Name, Id, Id_Cmt);
            }
            return 0;
        }

        //查詢庫存回報
        private static int Api_OpenInterestEvent(string Data)
        {
            if(OrderApi._inst.OpenInterestEvent!= null) {
               OrderApi._inst.OpenInterestEvent(Data);
            }
            return 0;
        }

        //委託回報
        private static int Api_OrderReportEvent(string Data)
        {
            if(OrderApi._inst.OrderReportEvent!= null) {
               OrderApi._inst.OrderReportEvent(Data);
            }
            return 0;
        }

        //成交回報
        private static int Api_OrderDealEvent(string Data)
        {
            if(OrderApi._inst.OrderDealEvent!= null) {
               OrderApi._inst.OrderDealEvent(Data);
            }
            return 0;
        }

        //股市交易狀態回報
        private static int Api_ExchInfoEvent(string Data)
        {           
            if(OrderApi._inst.ExchInfoEvent!= null) {
               OrderApi._inst.ExchInfoEvent(Data);
            }
            return 0;
        }

        //登入
        public int OrderLogin(int Type, string BranchNo, string Account, string Password, string IP, ushort Port)
        {
            return NS_OrderLogin(Type, BranchNo, Account, Password, IP, Port);
        }

        //登出
        public int OrderLogout()
        {
            return NS_OrderLogout();
        }

		//國內證券下單
		public int SendStockOrder(char lType, string BranchNo, string Account, ushort mExch, ushort sExch, string Symbol,
	                                               char Tran, char oType, char BuySell, string Price, uint Qty)
		{
			return NS_SendStockOrder(lType, BranchNo, Account, mExch, sExch, Symbol, Tran, oType, BuySell, Price, Qty);		
		}

        //國內期權下單
        public int SendFutureOrder(char lType, string BranchNo, string Account, ushort mExch, ushort sExch, string Symbol,
                                   char Tran, char oType, char BuySell, string Fordt, string Prcml, char DayTrade,                              
                                   string Price, uint Qty, string Symbol2, char BuySell2, char MtType, ushort FTimes)
        {
            return NS_SendFutureOrder(lType, BranchNo, Account, mExch, sExch, Symbol, Tran, oType, BuySell, Fordt, Prcml, DayTrade, Price, Qty, Symbol2, BuySell2, MtType, FTimes);
        }

        //國外期權下單
        public int SendFutureOrder_S(char lType, string BranchNo, string Account, ushort mExch, ushort sExch, string Symbol,
                                     char Tran, char oType, char BuySell, string Fordt, string Prcml, char DayTrade,                              
                                     string Price, byte Denominator, ushort StopType, string StopPrc, string RecoverPrc, uint Qty, uint RevQty, string Symbol2, char BuySell2, char MtType, ushort FTimes)
        {
            return NS_SendFutureOrder_S(lType, BranchNo, Account, mExch, sExch, Symbol, Tran, oType, BuySell, Fordt, Prcml, DayTrade, Price, Denominator, StopType, StopPrc, RecoverPrc, Qty, RevQty, Symbol2, BuySell2, MtType, FTimes);
        }

        //取消委託 (國外期貨)
        public int CancelOrder(char lType, string BranchNo, string Account, string KeyNo, string OrderSheet, string OrderNo, uint bdate)
        {
            return NS_CancelOrder(lType, BranchNo, Account, KeyNo, OrderSheet, OrderNo, bdate);
        }

        //改價改量委託 (國外期貨)
        public int ChangeOrder(char lType, string BranchNo, string Account, string KeyNo, string OrderSheet, string OrderNo, uint bdate, string Fordt, string Prcml, string Price, string StopPrice, string RecoverPrice, uint Qty, char ChgPrice)
        {
            return NS_ChangeOrder(lType, BranchNo, Account, KeyNo, OrderSheet, OrderNo, bdate, Fordt, Prcml, Price, StopPrice, RecoverPrice, Qty, ChgPrice);
        }

        //取得庫存
        public int GetOpenInterest(char AccountType, string BranchNo, string Account)
        {
            return NS_GetOpenInterest(AccountType, BranchNo, Account);
        }

        //取得交易別(根據股市別)
        public string GetOTypeString(ushort mExch, ushort sExch)
        {
            return NS_GetOTypeString(mExch, sExch);
        }

        //取得期權委託條件(根據股市別)
        public string GetFordtString(ushort mExch, ushort sExch)
        {
            return NS_GetFordtString(mExch, sExch);
        }

        //取得期權單一委託條件欄位內容
        public string GetFordtFieldRef(string Fordt)
        {
            return NS_GetFordtFieldRef(Fordt);
        }

		//設定簽章相關條件
        public int SetSignInfo(int CA, string SettingFile, string Section, ref int Status)
		{
			return NS_SetSignInfo(CA, SettingFile, Section, ref Status);		
		}

		//檢查憑證 & 取得憑證到期日
		public int SetCertInfo(string CertFile, string CertPassword, string Id, string BranchNo, string Account, char AccountType, ref int Status, ref ulong dwDate, ref ulong dwTime)
		{
			return NS_SetCertInfo(CertFile, CertPassword, Id, BranchNo, Account, AccountType, ref Status, ref dwDate, ref dwTime);		
		}

		//取得伺服器日期時間
		public void GetDateTime(ref ulong NowDate, ref ulong NowTime)
		{
			NS_GetDateTime(ref NowDate, ref NowTime);		
		}
    }
}
