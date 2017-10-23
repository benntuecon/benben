using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using P = SimpleCase.ParamDef;
using C = SimpleCase.Common;

namespace SimpleCase
{
    public partial class MainPage : Form
    {

        public static MainPage _inst;

        #region 變數宣告

        public P.AccountInfo currentAccount = new P.AccountInfo();
        public List<P.AccountInfo> OdrAcctList = new List<P.AccountInfo>();
        public List<P.EXCHINFO> ExchInfoList = new List<P.EXCHINFO>();

        public List<P.RESERVEQUANTITY_COLLECT> RsvCollList_Stock = new List<P.RESERVEQUANTITY_COLLECT>();  //國內證券庫存
        public List<P.FUTUREPOSITION_COLLECT> PosCollList_Future = new List<P.FUTUREPOSITION_COLLECT>();   //國內期權庫存
        public List<P.FUTUREPOSITION_COLLECT> PosCollList_SFuture = new List<P.FUTUREPOSITION_COLLECT>();  //國外期權庫存

        public List<P.ENTRUST_COLLECT> ReportList_S = new List<P.ENTRUST_COLLECT>();  //匯總
        public List<P.ENTRUST_COLLECT> ReportList_T = new List<P.ENTRUST_COLLECT>();  //每筆委託回報
        public List<P.ENTRUST_COLLECT> ReportList_M = new List<P.ENTRUST_COLLECT>();  //每筆成交回報

        public ColumnHeader[] columnH_LR;
        public string[] FList_LR;

        public OrderApi oApi = OrderApi.inst;
        public bool Connected = false;

        #endregion

        private System.Random randGen;

        public MainPage()
        {
            InitializeComponent();
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CleanAll);

            randGen = new Random();
            _inst = this;

            NS_Init();

            setupListView();

            SavedListView.ItemCheck += ListView1_ItemCheck1;
        }

        private void CleanAll(object sender, FormClosedEventArgs e)
        {
            oApi.Close();
            Application.Exit();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        ArrayList cdt_list = new ArrayList();
        public void saveBtn_Click(object sender, EventArgs e)
        {
            try
            { 
                
            
            
                P.Condition_bundle con = new P.Condition_bundle();
                con.Monitor_target = Monitoring_Target.SelectedItem.ToString();
                con.trigger_point = (ushort)Trigger_point.Value;
                con.Condition = Monitoring_condition.SelectedItem.ToString();
                con.Order_typ = (ushort)Order_typ.SelectedIndex;
                con.Option_trgt = (ushort)Option_target.Value;
                con.Option_month = (ushort)Option_month.Value;
                con.Order_p = Order_p.SelectedItem.ToString();
                con.Order_q = (ushort)Order_q.Value;
                con.offset_point = (ushort)Offset_point.Value;
                con.delay_sec = (ushort)delay_sec.Value;
                con.condition_loop = loop_or_not.Checked;
                con.duration = Valid_duration.Value;
                cdt_list.Add(con);

                ListViewItem item3 = new ListViewItem();
                item3.Text = "";
                item3.SubItems.Add(Monitoring_Target.SelectedItem.ToString());
                item3.SubItems.Add(Monitoring_condition.SelectedItem.ToString());
                item3.SubItems.Add(Trigger_point.Value.ToString());
                item3.SubItems.Add("{}{}{}{}",Order_typ.SelectedItem.ToString(),Option_month.se,buy_or_sell.SelectedItem.ToString());
                item3.SubItems.Add(Offset_point.Value.ToString());
                item3.SubItems.Add(Valid_duration.Text);

                SavedListView.Items.Add(item3);

                SavedListView.Focus();
                SavedListView.BeginUpdate();

                SavedListView.EndUpdate();

            }
            catch(System.NullReferenceException)
            {
                MessageBox.Show("請完整填入條件");
            }
            
        }

        private void ListView1_ItemCheck1(object sender, ItemCheckEventArgs e) {
            Console.WriteLine(e.NewValue);
            Console.WriteLine(e.Index+""+SavedListView.Items.Count);
            foreach (ListViewItem i in SavedListView.CheckedItems)
            {

           
            }
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SavedListView.BeginUpdate();
            foreach (ListViewItem i in SavedListView.SelectedItems)
                SavedListView.Items.Remove(i);
            SavedListView.EndUpdate();
        }

        private void queryBtn_Click(object sender, EventArgs e)
        {
            //取得庫存
            int a = oApi.GetOpenInterest(currentAccount.cAcctType, currentAccount.szBranchNo, currentAccount.szAccount);
            Console.WriteLine("" + a);
        }

        private void setupListView()
        {
            SavedListView.Columns.Add("啟動");
            SavedListView.Columns.Add("監控標的");
            SavedListView.Columns.Add("條件");
            SavedListView.Columns.Add("觸發點");
            SavedListView.Columns.Add("下單標的");
            SavedListView.Columns.Add("平倉點");
            SavedListView.Columns.Add("存續時間");

            /*ListViewItem item1 = new ListViewItem();
            item1.Text = ""; //The way to properly set the first piece of a data in a row is with .Text
            item1.SubItems.AddRange(new String[] { "1", "2", "3", "" });*/

            /*ListViewItem item2 = new ListViewItem();
            item2.Text = "";
            item2.SubItems.AddRange(new String[] { "11", "22", "33", "" });

            ListViewItem item3 = new ListViewItem();
            item3.Text = "";
            item3.SubItems.AddRange(new String[] { "111", "222", "4444", "" });*/


            SavedListView.BeginUpdate();

            

            SavedListView.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.None);
            SavedListView.Columns[0].Width = 50;
            SavedListView.Columns[1].Width = 80;
            SavedListView.Columns[6].Width=160;
            SavedListView.Columns[2].Width = 80;
            SavedListView.Columns[4].Width = 160;
            SavedListView.EndUpdate();
            
            
        }
        
        void NS_Init()
        {
            oApi.ActiveEvent += new OrderApi.ptActiveEvent(ActiveEvent);
            oApi.ConnectEvent += new OrderApi.ptConnectEvent(ConnectEvent);
            oApi.AccountEvent += new OrderApi.ptAccountEvent(AccountEvent);
            oApi.OpenInterestEvent += new OrderApi.ptOpenInterestEvent(OpenInterestEvent);
            //oApi.OrderReportEvent += new OrderApi.ptOrderReportEvent(OrderReportEvent);
            //oApi.OrderDealEvent += new OrderApi.ptOrderDealEvent(OrderDealEvent);
            //oApi.ExchInfoEvent += new OrderApi.ptExchInfoEvent(ExchInfoEvent);
            oApi.Init(true);
        }

        #region Invoke 處理
        private delegate void InvokeConnectFunction(int RetCode, string Msg);
        private delegate void InvokeServerEchoFunction(int Event, int Param1, int Param2, string Msg);
        private delegate void InvokeAccountFunction(char AccountType, string BranchNo, string Account, string Name, string Id, int Id_Cmt);
        private delegate void InvokeDbgMessageFunction(int Type, string Msg);

        private void ConnectFunction(int RetCode, string Msg)
        {
            /*if (RetCode == P.CONNECT_SUCCESS)
            {
                LoginSuccess();
            }
            else if (RetCode == P.CONNECT_FAILURE)
            {
                if (Connected == true)
                {
                    MessageBox.Show(C.GetResString("連線失敗"), C.GetResString("軟體名稱"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                LoginFail();
            }*/
        }

        private void ServerEchoFunction(int Event, int Param1, int Param2, string Msg)
        {
            MessageBox.Show(C.LocalStringMapping(Msg), C.GetResString("軟體名稱") + "(S)", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
        }

        private void AccountFunction(char AccountType, string BranchNo, string Account, string Name, string Id, int Id_Cmt)
        {
            currentAccount.cAcctType = AccountType;
            currentAccount.szBranchNo = BranchNo;
            currentAccount.szAccount = Account;
            currentAccount.szName = Name;
            currentAccount.szId = Id;
            currentAccount.Id_Cmt = Id_Cmt;
            currentAccount.CA_Check = false;
            currentAccount.CA_Status = P.CS_ERROR_CERTSIGN;
        }

        private void DbgMessageFunction(int Type, string Msg)
        {
            //textBox_dbg.AppendText("<" + DateTime.Now.ToString("HH:mm:ss.fff") + ">" + Msg + "\r\n");
        }
        #endregion

        #region 下單回報
        //連線狀態回報
        private int ConnectEvent(int RetCode, string Msg)
        {
            switch (RetCode)
            {
                case P.CONNECT_SUCCESS:
                    this.Invoke(new InvokeConnectFunction(this.ConnectFunction), new object[] { RetCode, Msg });
                    break;
                case P.CONNECT_FAILURE:
                    this.Invoke(new InvokeConnectFunction(this.ConnectFunction), new object[] { RetCode, Msg });
                    break;
                case P.CONNECT_ERROR_PARAM: break;
                case P.CONNECT_ERROR_STARTUP:
                    this.Invoke(new InvokeConnectFunction(this.ConnectFunction), new object[] { RetCode, Msg });
                    break;
            }
            Console.WriteLine(String.Format("ConnectEvent >> RetCode={0}, Msg={1}", RetCode, Msg));
            return 0;
        }
        //主動事件回報
        int ActiveEvent(int Event, int Param1, int Param2, string Msg)
        {
            if (Event == P.ACTIVE_ACTIONSTATE)
            {
                Console.WriteLine(String.Format("{0}", C.LocalStringMapping(Msg)));
            }
            else if (Event == P.ACTIVE_SERVER_ECHO)
            {
                Console.WriteLine(String.Format("{0}", C.LocalStringMapping(Msg)));
                //this.Invoke(new InvokeServerEchoFunction(this.ServerEchoFunction), new object[] {Event, Param1, Param2, Msg});                                              
            }
            else if (Event == P.ACTIVE_ACCT_NOTEXIST)
            {  //帳號不存在
                Console.WriteLine(String.Format("帳號不存在 ({0})", Msg));
            }
            else if (Event == P.ACTIVE_ACCT_PASSWORD_ERROR)
            {  //密碼錯誤
                Console.WriteLine(String.Format("密碼錯誤 ({0})", Msg));
            }
            else if (Event == P.ACTIVE_ACCT_ACCOUNT_EXPIRED)
            {  //帳號過期
                Console.WriteLine(String.Format("帳號過期 ({0})", Msg));
            }
            else if (Event == P.ACTIVE_ACCT_LOGIN_ERROR)
            {  //登入錯誤(帶原因)
                Console.WriteLine(String.Format("登入錯誤(帶原因): {0}", Msg));
            }
            else if (Event == P.ACTIVE_ACCT_FIRSTLOGIN)
            {  //第一次登入
                Console.WriteLine(String.Format("第一次登入 ({0})", Msg));
            }
            else if (Event == P.ACTIVE_ACCT_PASSWORD_EXPIRED)
            {  //密碼過期
                Console.WriteLine(String.Format("密碼過期 ({0})", Msg));
            }
            else if (Event == P.ACTIVE_ACCT_LOGOUT)
            {  //登出回覆
                Console.WriteLine(String.Format("登出回覆 ({0})", Msg));
            }
            else if (Event == P.ACTIVE_SYMBOLLIST_UPDATE_FINISH)
            {  //交易商品代碼表更新完成
                Console.WriteLine(String.Format("{0}: 主股市別={1}, 次股市別={2}", Msg, Param1, Param2));
            }
            else if (Event == P.ACTIVE_SNOR_UPDATE_FINISH)
            {        //期貨選擇權類別表更新完成
                Console.WriteLine(String.Format("{0}: 主股市別={1}, 次股市別={2}", Msg, Param1, Param2));
            }
            else if (Event == P.ACTIVE_EXCHCATE_UPDATE_FINISH)
            {    //可交易股市列表更新完成
                Console.WriteLine(Msg);
            }
            else if (Event == P.ACTIVE_FIELDREF_UPDATE_FINISH)
            {    //欄位參數資訊更新完成
                Console.WriteLine(Msg);
            }
            else if (Event == P.ACTIVE_TICKBEAT_UPDATE_FINISH)
            {     //跳動檔位類別表更新完成
                Console.WriteLine(Msg);
            }
            return 0;
        }

        //交易帳號回報
        int AccountEvent(char AccountType, string BranchNo, string Account, string name, string Id, int Id_Cmt)
        {
            Console.WriteLine(String.Format("AccountEvent >> AccountType={0}, BranchNo={1}, Account={2}, Name={3}, Id={4}, Id_Cmt={5}", AccountType, BranchNo, Account, Name, Id, Id_Cmt));

            this.Invoke(new InvokeAccountFunction(this.AccountFunction), new object[] { AccountType, BranchNo, Account, name, Id, Id_Cmt });

            return 0;
        }

        //查詢庫存回報
        int OpenInterestRecvCount = 0;
        int OpenInterestRecved = 0;

        int OpenInterestRecvCount2 = 0;
        int OpenInterestRecved2 = 0;

        int OpenInterestType = -1;  //0:單式 /1:複式

        int OpenInterestEvent(string Data)
        {
            Console.WriteLine(String.Format("OpenInterestEvent >> Data={0}", Data));

            char AccountType = ' ';
            string BranchNo = null, Account = null, Symbol = null, Currency = null;
            ushort TranType = 0;
            ushort mExch = 0;
            bool update = false;

            P.RESERVEQUANTITY rsvqty = new P.RESERVEQUANTITY();
            P.FUTUREPOSITION futpos = new P.FUTUREPOSITION();

            string[] token = Data.Split(new char[1] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < token.Length; i++)
            {
                string[] key = token[i].Split(new char[1] { '@' }, StringSplitOptions.RemoveEmptyEntries);

                if (key.Length >= 2)
                {
                    if (key[0].Equals("Cnt"))
                    {  //單式 : 第一筆帶Count
                        OpenInterestType = 0;
                        OpenInterestRecvCount = Int32.Parse(key[1]);
                        OpenInterestRecved = 0;
                        update = true;

                    }
                    else if (key[0].Equals("Cnt2"))
                    {  //複式 : 第一筆帶Count
                        OpenInterestType = 1;
                        OpenInterestRecvCount2 = Int32.Parse(key[1]);
                        OpenInterestRecved2 = 0;
                        update = true;
                    }

                    else if (key[0].Equals("AccountType")) AccountType = key[1][0];
                    else if (key[0].Equals("BranchNo")) BranchNo = key[1];
                    else if (key[0].Equals("Account")) Account = key[1];
                    else if (key[0].Equals("mExch")) mExch = UInt16.Parse(key[1]);
                    else if (key[0].Equals("TranType")) TranType = UInt16.Parse(key[1]);
                    else if (key[0].Equals("Symbol")) Symbol = key[1];
                    else if (key[0].Equals("Currency")) Currency = key[1];
                    else
                    {
                        if ((TranType == (ushort)P.EXCHCLASS.ecNORMAL) || (TranType == (ushort)P.EXCHCLASS.ecFIXED) || (TranType == (ushort)P.EXCHCLASS.ecBITS) || (TranType == (ushort)P.EXCHCLASS.ecNTC))
                        {
                            if (key[0].Equals("BitsBalanceToday")) rsvqty.BitsBalanceToday = Int32.Parse(key[1]);
                            else if (key[0].Equals("StockBalanceYesterday")) rsvqty.StockBalanceYesterday = Int32.Parse(key[1]);
                            else if (key[0].Equals("StockBalanceToday")) rsvqty.StockBalanceToday = Int32.Parse(key[1]);
                            else if (key[0].Equals("StockTrustBuy")) rsvqty.StockTrustBuy = Int32.Parse(key[1]);
                            else if (key[0].Equals("StockTrustSell")) rsvqty.StockTrustSell = Int32.Parse(key[1]);
                            else if (key[0].Equals("StockMatchBuy")) rsvqty.StockMatchBuy = Int32.Parse(key[1]);
                            else if (key[0].Equals("StockMatchSell")) rsvqty.StockMatchSell = Int32.Parse(key[1]);
                            else if (key[0].Equals("FinaBalanceYesterday")) rsvqty.FinaBalanceYesterday = Int32.Parse(key[1]);
                            else if (key[0].Equals("FinaBalanceToday")) rsvqty.FinaBalanceToday = Int32.Parse(key[1]);
                            else if (key[0].Equals("FinaTrustBuy")) rsvqty.FinaTrustBuy = Int32.Parse(key[1]);
                            else if (key[0].Equals("FinaTrustSell")) rsvqty.FinaTrustSell = Int32.Parse(key[1]);
                            else if (key[0].Equals("FinaMatchBuy")) rsvqty.FinaMatchBuy = Int32.Parse(key[1]);
                            else if (key[0].Equals("FinaMatchSell")) rsvqty.FinaMatchSell = Int32.Parse(key[1]);
                            else if (key[0].Equals("SecuBalanceYesterday")) rsvqty.SecuBalanceYesterday = Int32.Parse(key[1]);
                            else if (key[0].Equals("SecuBalanceToday")) rsvqty.SecuBalanceToday = Int32.Parse(key[1]);
                            else if (key[0].Equals("SecuTrustBuy")) rsvqty.SecuTrustBuy = Int32.Parse(key[1]);
                            else if (key[0].Equals("SecuTrustSell")) rsvqty.SecuTrustSell = Int32.Parse(key[1]);
                            else if (key[0].Equals("SecuMatchBuy")) rsvqty.SecuMatchBuy = Int32.Parse(key[1]);
                            else if (key[0].Equals("SecuMatchSell")) rsvqty.SecuMatchSell = Int32.Parse(key[1]);
                        }
                        else if ((TranType == (ushort)P.EXCHCLASS.ecFUTURE) || (TranType == (ushort)P.EXCHCLASS.ecOPTION) || (TranType == (ushort)P.EXCHCLASS.ecINTFUT))
                        {
                            if (key[0].Equals("SettleUp")) futpos.SettleUp = Int32.Parse(key[1]);
                            else if (key[0].Equals("OILongYesterday")) futpos.OILongYesterday = Int32.Parse(key[1]);
                            else if (key[0].Equals("OIShortYesterday")) futpos.OIShortYesterday = Int32.Parse(key[1]);
                            else if (key[0].Equals("TrustLong")) futpos.TrustLong = Int32.Parse(key[1]);
                            else if (key[0].Equals("TrustShort")) futpos.TrustShort = Int32.Parse(key[1]);
                            else if (key[0].Equals("MatchLong")) futpos.MatchLong = Int32.Parse(key[1]);
                            else if (key[0].Equals("MatchShort")) futpos.MatchShort = Int32.Parse(key[1]);
                            else if (key[0].Equals("OILongToday")) futpos.OILongToday = Int32.Parse(key[1]);
                            else if (key[0].Equals("OIShortToday")) futpos.OIShortToday = Int32.Parse(key[1]);
                            else if (key[0].Equals("MatchLongPrice")) futpos.MatchLongPrice = Double.Parse(key[1]);
                            else if (key[0].Equals("MatchShortPrice")) futpos.MatchShortPrice = Double.Parse(key[1]);
                            else if (key[0].Equals("MatchLongValue")) futpos.MatchLongValue = Double.Parse(key[1]);
                            else if (key[0].Equals("MatchShortValue")) futpos.MatchShortValue = Double.Parse(key[1]);
                        }
                    }
                }
            }

            if (OpenInterestType == 0)
            {  //單式
                //國內證券
                if ((TranType == (ushort)P.EXCHCLASS.ecNORMAL) || (TranType == (ushort)P.EXCHCLASS.ecFIXED) || (TranType == (ushort)P.EXCHCLASS.ecBITS) || (TranType == (ushort)P.EXCHCLASS.ecNTC))
                {
                    if (update == true)
                    {
                        RsvCollList_Stock.Clear();
                        //Clear OpenInterest-Stock UI
                    }

                    //AddOpenInterest_Stock(AccountType, BranchNo, Account, mExch, TranType, Symbol, Currency, rsvqty);
                    if (++OpenInterestRecved >= OpenInterestRecvCount)
                    {  //整批資料更新
                        //Update OpenInterest-Stock UI with RsvCollList_Stock
                    }
                }
                //國內期權
                else if ((TranType == (ushort)P.EXCHCLASS.ecFUTURE) || (TranType == (ushort)P.EXCHCLASS.ecOPTION))
                {
                    if (update == true)
                    {
                        PosCollList_Future.Clear();
                        //Clear OpenInterest-Future UI
                    }

                    //AddOpenInterest_Future(AccountType, BranchNo, Account, mExch, TranType, Symbol, Currency, futpos);
                    if (++OpenInterestRecved >= OpenInterestRecvCount)
                    {  //整批資料更新
                        //Update OpenInterest-Future UI with PosCollList_Future
                    }
                }
                //國外期權
                else if (TranType == (ushort)P.EXCHCLASS.ecINTFUT)
                {
                    if (update == true)
                    {
                        PosCollList_SFuture.Clear();
                        //Clear OpenInterest-SFuture UI
                    }

                    //AddOpenInterest_SFuture(AccountType, BranchNo, Account, mExch, TranType, Symbol, Currency, futpos);
                    if (++OpenInterestRecved >= OpenInterestRecvCount)
                    {  //整批資料更新
                        //Update OpenInterest-SFuture UI with PosCollList_SFuture
                    }
                }
            }
            else if (OpenInterestType == 1)
            {  //複式
                //do something
            }
            return 0;
        }

        //委託回報 + 匯總回報 (國外)
        int OrderReportEvent(string Data)
        {
            //Console.WriteLine(String.Format("OrderReportEvent >> Data={0}", Data));

            string KeyNo = "", OrderSheet = "", OrderNo = "", BranchNo = "", Account = "", sname = "", Symbol = "", Fordt = "", Prcml = "", Agent = "", Msg = "", stopprc = "", stopcond = "", stopcondstr = "", rcvrprc = "";
            string tprice = "", mprice = "", aprice = "";
            char lType = ' ', TranType = ' ', oType = ' ', Cdi = ' ', Status = ' ', BuySell = ' ', DayTrade = ' ', valid = ' ', chgprc = ' ';
            int tqty = 0, cqty = 0, lqty = 0, eqty = 0, mqty = 0, aqty = 0, bqty = 0, uqty = 0;
            uint kdate = 0, ktime = 0, bdate = 0, btime = 0, ttime = 0;
            uint stoptp = 0;
            ushort mExch = 0, sExch = 0;
            string statusstr = "";
            int ReportFlag = 0;

            string[] token = Data.Split(new char[1] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < token.Length; i++)
            {
                string[] key = token[i].Split(new char[1] { '@' }, StringSplitOptions.RemoveEmptyEntries);

                if (key.Length >= 2)
                {
                    if (key[0].Equals("KeyNo")) KeyNo = key[1];
                    else if (key[0].Equals("OrderSheet")) OrderSheet = key[1];
                    else if (key[0].Equals("OrderNo")) OrderNo = key[1];
                    else if (key[0].Equals("TranType")) TranType = key[1][0];
                    else if (key[0].Equals("oType")) oType = key[1][0];
                    else if (key[0].Equals("Cdi")) Cdi = key[1][0];
                    else if (key[0].Equals("Status")) Status = key[1][0];
                    else if (key[0].Equals("valid")) valid = key[1][0];
                    else if (key[0].Equals("lType")) lType = key[1][0];
                    else if (key[0].Equals("BranchNo")) BranchNo = key[1];
                    else if (key[0].Equals("Account")) Account = key[1];
                    else if (key[0].Equals("sname")) sname = key[1];
                    else if (key[0].Equals("Symbol")) Symbol = key[1];
                    else if (key[0].Equals("BuySell")) BuySell = key[1][0];
                    else if (key[0].Equals("Fordt")) Fordt = key[1];
                    else if (key[0].Equals("Prcml")) Prcml = key[1];
                    else if (key[0].Equals("DayTrade")) DayTrade = key[1][0];
                    else if (key[0].Equals("Agent")) Agent = key[1];
                    else if (key[0].Equals("Msg")) Msg = key[1];
                    else if (key[0].Equals("ReportFlag")) ReportFlag = Int32.Parse(key[1]);

                    else if (key[0].Equals("mExch")) mExch = UInt16.Parse(key[1]);
                    else if (key[0].Equals("sExch")) sExch = UInt16.Parse(key[1]);

                    else if (key[0].Equals("tprice")) tprice = key[1];
                    else if (key[0].Equals("mprice")) mprice = key[1];
                    else if (key[0].Equals("aprice")) aprice = key[1];
                    else if (key[0].Equals("chgprc")) chgprc = key[1][0];

                    else if (key[0].Equals("tqty")) tqty = Int32.Parse(key[1]);
                    else if (key[0].Equals("cqty")) cqty = Int32.Parse(key[1]);
                    else if (key[0].Equals("lqty")) lqty = Int32.Parse(key[1]);
                    else if (key[0].Equals("eqty")) eqty = Int32.Parse(key[1]);
                    else if (key[0].Equals("mqty")) mqty = Int32.Parse(key[1]);
                    else if (key[0].Equals("aqty")) aqty = Int32.Parse(key[1]);
                    else if (key[0].Equals("bqty")) bqty = Int32.Parse(key[1]);
                    else if (key[0].Equals("uqty")) uqty = Int32.Parse(key[1]);

                    else if (key[0].Equals("kdate")) kdate = UInt32.Parse(key[1]);
                    else if (key[0].Equals("ktime")) ktime = UInt32.Parse(key[1]);
                    else if (key[0].Equals("bdate")) bdate = UInt32.Parse(key[1]);
                    else if (key[0].Equals("btime")) btime = UInt32.Parse(key[1]);
                    else if (key[0].Equals("ttime")) ttime = UInt32.Parse(key[1]);

                    else if (key[0].Equals("stoptp")) stoptp = UInt32.Parse(key[1]);
                    else if (key[0].Equals("stopprc")) stopprc = key[1];
                    else if (key[0].Equals("stopcond")) stopcond = key[1];
                    else if (key[0].Equals("stopcondstr")) stopcondstr = key[1];
                    else if (key[0].Equals("rcvrprc")) rcvrprc = key[1];

                    else if (key[0].Equals("statusstr")) statusstr = key[1];
                }
            }

            /*
            Console.WriteLine(String.Format("OrderReportEvent >> 電子單號={0}, 交易股市別={1}, 交易別={2}, 委託別={3}, 委託狀態={4}, 可刪改={5}, 帳號類別={6}, 券商={7}, 帳號={8}, 使用者姓名={9}, 股票代碼={10}",
                                        KeyNo, TranType, oType, Cdi, Status, valid, lType, BranchNo, Account, sname, Symbol));
            Console.WriteLine(String.Format(">> mExch={0}, sExch={1}, 買賣別={2}, 委託條件={3}, 限市價={4}, 當沖={5}, 委託書號={6}, 委託介面={7}, 訊息={8}, 委託狀態訊息={9}, Flag={10}",
                                        mExch, sExch, BuySell, Fordt, Prcml, DayTrade, OrderSheet, Agent, C.LocalStringMapping(Msg), C.LocalStringMapping(statusstr), ReportFlag));
            Console.WriteLine(String.Format(">> 委託價={0}, 成交價={1}, 成交均價={2}, 指定改價={3}, 委託數量={4}, 改變數量={5}, 委託可刪量={6}, 總取消數量={7}, 成交數量={8}, 委託後量={9}, 委託前數量={10}, 委託可刪量(AP)={11}",
                                        tprice, mprice, aprice, chgprc, tqty, cqty, lqty, eqty, mqty, aqty, bqty, uqty));
            Console.WriteLine(String.Format(">> 委託日期={0}, 委託時間={1}, 成交日期={2}, 成交時間={3}", kdate, ktime, bdate, ttime));
            Console.WriteLine(String.Format(">> 觸價種類={0}, 觸價價格={1}, 觸價條件={2}, 追價價格={3}", stoptp, stopprc, stopcond, rcvrprc));
            */

            //AddOrderReport(ReportFlag, lType, KeyNo, OrderSheet, OrderNo, TranType, oType, Cdi, Status, valid, BranchNo, Account, Symbol, mExch, sExch, BuySell, Fordt, stoptp, stopprc, stopcond, stopcondstr, rcvrprc, Prcml, DayTrade, tprice, mprice, aprice, chgprc, tqty, cqty, lqty, eqty, mqty, aqty, bqty, uqty, kdate, ktime, bdate, btime, ttime, Msg, statusstr);
            return 0;
        }

        //成交回報
        int OrderDealEvent(string Data)
        {
            //Console.WriteLine(String.Format("OrderDealEvent >> Data={0}", Data));

            string KeyNo = "", OrderSheet = "", OrderNo = "", BranchNo = "", Account = "", sname = "", Symbol = "", Fordt = "", Prcml = "", Agent = "", Msg = "", stopprc = "", stopcond = "", stopcondstr = "", rcvrprc = "";
            string tprice = "", mprice = "", aprice = "";
            char lType = ' ', TranType = ' ', oType = ' ', BuySell = ' ', DayTrade = ' ', chgprc = ' ';
            int tqty = 0, cqty = 0, lqty = 0, eqty = 0, mqty = 0, aqty = 0, bqty = 0, uqty = 0;
            uint kdate = 0, ktime = 0, bdate = 0, btime = 0, ttime = 0;
            uint stoptp = 0;
            ushort mExch = 0, sExch = 0;
            string statusstr = "";
            int ReportFlag = 0;

            string[] token = Data.Split(new char[1] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < token.Length; i++)
            {
                string[] key = token[i].Split(new char[1] { '@' }, StringSplitOptions.RemoveEmptyEntries);

                if (key.Length >= 2)
                {
                    if (key[0].Equals("KeyNo")) KeyNo = key[1];
                    else if (key[0].Equals("OrderSheet")) OrderSheet = key[1];
                    else if (key[0].Equals("OrderNo")) OrderNo = key[1];
                    else if (key[0].Equals("TranType")) TranType = key[1][0];
                    else if (key[0].Equals("oType")) oType = key[1][0];
                    else if (key[0].Equals("lType")) lType = key[1][0];
                    else if (key[0].Equals("BranchNo")) BranchNo = key[1];
                    else if (key[0].Equals("Account")) Account = key[1];
                    else if (key[0].Equals("sname")) sname = key[1];
                    else if (key[0].Equals("Symbol")) Symbol = key[1];
                    else if (key[0].Equals("BuySell")) BuySell = key[1][0];
                    else if (key[0].Equals("Fordt")) Fordt = key[1];
                    else if (key[0].Equals("Prcml")) Prcml = key[1];
                    else if (key[0].Equals("DayTrade")) DayTrade = key[1][0];
                    else if (key[0].Equals("Agent")) Agent = key[1];
                    else if (key[0].Equals("Msg")) Msg = key[1];
                    else if (key[0].Equals("ReportFlag")) ReportFlag = Int32.Parse(key[1]);

                    else if (key[0].Equals("mExch")) mExch = UInt16.Parse(key[1]);
                    else if (key[0].Equals("sExch")) sExch = UInt16.Parse(key[1]);

                    else if (key[0].Equals("tprice")) tprice = key[1];
                    else if (key[0].Equals("mprice")) mprice = key[1];
                    else if (key[0].Equals("aprice")) aprice = key[1];
                    else if (key[0].Equals("chgprc")) chgprc = key[1][0];

                    else if (key[0].Equals("tqty")) tqty = Int32.Parse(key[1]);
                    else if (key[0].Equals("cqty")) cqty = Int32.Parse(key[1]);
                    else if (key[0].Equals("lqty")) lqty = Int32.Parse(key[1]);
                    else if (key[0].Equals("eqty")) eqty = Int32.Parse(key[1]);
                    else if (key[0].Equals("mqty")) mqty = Int32.Parse(key[1]);
                    else if (key[0].Equals("aqty")) aqty = Int32.Parse(key[1]);
                    else if (key[0].Equals("bqty")) bqty = Int32.Parse(key[1]);
                    else if (key[0].Equals("uqty")) uqty = Int32.Parse(key[1]);

                    else if (key[0].Equals("kdate")) kdate = UInt32.Parse(key[1]);
                    else if (key[0].Equals("ktime")) ktime = UInt32.Parse(key[1]);
                    else if (key[0].Equals("bdate")) bdate = UInt32.Parse(key[1]);
                    else if (key[0].Equals("btime")) btime = UInt32.Parse(key[1]);
                    else if (key[0].Equals("ttime")) ttime = UInt32.Parse(key[1]);

                    else if (key[0].Equals("stoptp")) stoptp = UInt32.Parse(key[1]);
                    else if (key[0].Equals("stopprc")) stopprc = key[1];
                    else if (key[0].Equals("stopcond")) stopcond = key[1];
                    else if (key[0].Equals("stopcondstr")) stopcondstr = key[1];
                    else if (key[0].Equals("rcvrprc")) rcvrprc = key[1];

                    else if (key[0].Equals("statusstr")) statusstr = key[1];
                }
            }

            /*
            Console.WriteLine(String.Format("OrderDealEvent >> 電子單號={0}, 交易股市別={1}, 交易別={2}, 帳號類別={3}, 券商={4}, 帳號={5}, 使用者姓名={6}, 股票代碼={7}",
                                                     KeyNo, TranType, oType, lType, BranchNo, Account, sname, Symbol));
            Console.WriteLine(String.Format(">> mExch={0}, sExch={1}, 買賣別={2}, 委託條件={3}, 限市價={4}, 當沖={5}, 委託書號={6}, 委託介面={7}, 訊息={8}, 委託狀態訊息={9}, Flag={10}",
                                                     mExch, sExch, BuySell, Fordt, Prcml, DayTrade, OrderSheet, Agent, C.LocalStringMapping(Msg), C.LocalStringMapping(statusstr), ReportFlag));
            Console.WriteLine(String.Format(">> 委託價={0}, 成交價={1}, 成交均價={2}, 指定改價={3}, 委託數量={4}, 改變數量={5}, 委託可刪量={6}, 總取消數量={7}, 成交數量={8}, 委託後量={9}, 委託前數量={10}, 委託可刪量(AP)={11}",
                                                     tprice, mprice, aprice, chgprc, tqty, cqty, lqty, eqty, mqty, aqty, bqty, uqty));
            Console.WriteLine(String.Format(">> 委託日期={0}, 委託時間={1}, 成交日期={2}, 成交時間={3}", kdate, ktime, bdate, ttime));
            Console.WriteLine(String.Format(">> 觸價種類={0}, 觸價價格={1}, 觸價條件={2}, 追價價格={3}", stoptp, stopprc, stopcond, rcvrprc));
            */

            //AddOrderReport(ReportFlag, lType, KeyNo, OrderSheet, OrderNo, TranType, oType, ' ', ' ', ' ', BranchNo, Account, Symbol, mExch, sExch, BuySell, Fordt, stoptp, stopprc, stopcond, stopcondstr, rcvrprc, Prcml, DayTrade, tprice, mprice, aprice, chgprc, tqty, cqty, lqty, eqty, mqty, aqty, bqty, uqty, kdate, ktime, bdate, btime, ttime, Msg, statusstr);
            return 0;
        }
        #endregion

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label17.Text = Monitoring_Target.Text;
            if (Monitoring_condition.SelectedIndex==0)
            {
                label18.Text = "小於";
            }
            else
            {
                label18.Text = "大於";
            }
        }
        
        
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MainPage_Load(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void SavedListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SaveListView_Check(object sender, EventArgs e)//從未選取至選取時
        {

        }
        private void SaveListView_Uncheck(object sender, EventArgs e)//從選取狀態至未選取時
        {

        }
        private void SaveListView_click(object sender, EventArgs e)
        {
            foreach (int i in SavedListView.SelectedIndices)
            {
                Monitoring_Target.Text = ((P.Condition_bundle)cdt_list[i]).Monitor_target;
                Trigger_point.Value = ((P.Condition_bundle)cdt_list[i]).trigger_point;
                Monitoring_condition.Text = ((P.Condition_bundle)cdt_list[i]).Condition;
                Order_typ.SelectedIndex=((P.Condition_bundle)cdt_list[i]).Order_typ;
                Option_target.Value = ((P.Condition_bundle)cdt_list[i]).Option_trgt;
                Option_month.Value = ((P.Condition_bundle)cdt_list[i]).Option_month;
                Order_p.SelectedValue=((P.Condition_bundle)cdt_list[i]).Order_p;
                Order_q.Value=((P.Condition_bundle)cdt_list[i]).Order_q;
                Offset_point.Value=((P.Condition_bundle)cdt_list[i]).offset_point;
                delay_sec.Value=((P.Condition_bundle)cdt_list[i]).delay_sec;
                loop_or_not.Checked=((P.Condition_bundle)cdt_list[i]).condition_loop;
                Valid_duration.Value=((P.Condition_bundle)cdt_list[i]).duration;
            }
        }
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void loop_or_not_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void conditionPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }
        
        
        #region 多執行續
        public void Order_stage(object[] perems)
        {

        }
        public void Offset_stage(object[] perems)
        {

        }

        #endregion

        private void label21_Click(object sender, EventArgs e)
        {

        }
    }   
}
