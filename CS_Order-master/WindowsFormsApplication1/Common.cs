using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Globalization;
using System.Resources;
using System.Reflection;
using System.Threading;

using P = SimpleCase.ParamDef;

namespace SimpleCase
{
    class Common
    {
        #region 語系資源
        public static ResourceManager rm = new ResourceManager("OrderDemoCSharp.RES.localize", Assembly.GetExecutingAssembly());
        public static CultureInfo ci = new CultureInfo(CultureInfo.CurrentCulture.Name);  //CultureInfo.CurrentCulture.Name : OS預設的語系
        public static string userUICulture = Thread.CurrentThread.CurrentUICulture.Name;  //Thread.CurrentThread.CurrentUICulture.Name : OS預設的語系

        public static void SetLanguageResource(string CultureName)
        {
            rm = new ResourceManager("OrderDemoCSharp.RES.localize", Assembly.GetExecutingAssembly());
            ci = new CultureInfo(CultureName);       
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }

        public static void SetDefaultLanguageResource()
        {
            rm = new ResourceManager("OrderDemoCSharp.RES.localize", Assembly.GetExecutingAssembly());
            ci = new CultureInfo(CultureInfo.CurrentCulture.Name);  //CultureInfo.CurrentCulture.Name : OS預設的語系
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }

        public static string GetResString(string str)
        {
            //轉換語系資源檔字串
            try {
               string s= rm.GetString(str);
               if(s!=null) return s;
            }
            catch (Exception ex) {
            }      
            return str;
        }

        public static string LocalStringMapping(string str)
        {
            //轉換語系字串
            //...
            return str;
        }
        #endregion

        public static string ConvertDateToString(uint date)
        {
            return String.Format("{0:D4}/{1:D2}/{2:D2}", date/10000, date/100%100, date%100);
        }

        public static string ConverTiimeToString(uint time)
        {
			if(time.ToString().Length>6) return String.Format("{0:D2}:{1:D2}:{2:D2}\"{3:D2}", time/1000000, time/10000%100, time/100%100, time%100);
            return String.Format("{0:D2}:{1:D2}:{2:D2}", time/10000, time/100%100, time%100);
        }

        public static string AccountTypeToName(char type)
        {            
            switch (type) {
                case (char)P.IDTYPE.itStock:  return GetResString("證券");
                case (char)P.IDTYPE.itFuture: return GetResString("期貨");
                case (char)P.IDTYPE.itStkFut: return GetResString("證期");
                case (char)P.IDTYPE.itIntFut: return GetResString("國外");
                default: return " -- ";
            }
        }

        public static uint GetStockUnit(string Symbol)
        {
            //假設交易單位一張為1000股，視個股交易單位而異
            return 1000;        
        }

        public static uint StockUnitToSheet(string Symbol, uint Unit)
        {
            //假設交易單位一張為1000股，視個股交易單位而異
            return Unit/1000;        
        }

        public static string PriceConvert(char TranType, string Price)
        {
			if((Price==P.PRC_MKT) || (Price==P.PRC_MTL)) {
				if (TranType==(char)P.TRANCLASS.tcFIXED) return GetResString(P.PRC_FIXED_STR);  //定盤價

				return GetResString(P.PRCML_MKT_STR);
			}
			else if(Price==P.PRC_AO) return GetResString(P.PRC_AO_STR);
			else if(Price==P.PRC_M0) return GetResString(P.PRC_M0_STR);  //漲停價
			else if(Price==P.PRC_D0) return GetResString(P.PRC_D0_STR);  //跌停價
			else if(Price==P.PRC_00) return GetResString(P.PRC_00_STR);  //平盤價
		    else if(Price.Length==0) return P.NULL_FIELD;
			else return Price;
		}

        public static string FordtConvertString_Future(string Fordt)
        {
            if(Fordt.CompareTo(P.ORDER_FORDT_ROD)==0) return GetResString(P.ORDER_FORDT_ROD_DESC);
            else if(Fordt.CompareTo(P.ORDER_FORDT_IOC)==0) return GetResString(P.ORDER_FORDT_IOC_DESC);
            else if(Fordt.CompareTo(P.ORDER_FORDT_FOK)==0) return GetResString(P.ORDER_FORDT_FOK_DESC);
            else if(Fordt.CompareTo(P.ORDER_FORDT_FAK)==0) return GetResString(P.ORDER_FORDT_FAK_DESC);
            else if(Fordt.CompareTo(P.ORDER_FORDT_SLO)==0) return GetResString(P.ORDER_FORDT_SLO_DESC);
            else if(Fordt.CompareTo(P.ORDER_FORDT_STI)==0) return GetResString(P.ORDER_FORDT_STI_DESC);
            else if(Fordt.CompareTo(P.ORDER_FORDT_ROC)==0) return GetResString(P.ORDER_FORDT_ROC_DESC);
            else if(Fordt.CompareTo(P.ORDER_FORDT_MOO)==0) return GetResString(P.ORDER_FORDT_MOO_DESC);
            else if(Fordt.CompareTo(P.ORDER_FORDT_MOC)==0) return GetResString(P.ORDER_FORDT_MOC_DESC);
            else if(Fordt.CompareTo(P.ORDER_FORDT_AO)==0) return GetResString(P.ORDER_FORDT_AO_DESC);
            else if(Fordt.CompareTo(P.ORDER_FORDT_OCO)==0) return GetResString(P.ORDER_FORDT_OCO_DESC);
            
            return "Unknown";
        }

        public static string FordtRecoverString_Future(string FordtDesc)
        {
            if(FordtDesc.CompareTo(GetResString(P.ORDER_FORDT_ROD_DESC))==0) return P.ORDER_FORDT_ROD;
            else if(FordtDesc.CompareTo(GetResString(P.ORDER_FORDT_IOC_DESC))==0) return P.ORDER_FORDT_IOC;
            else if(FordtDesc.CompareTo(GetResString(P.ORDER_FORDT_FOK_DESC))==0) return P.ORDER_FORDT_FOK;
            
            return FordtDesc;
        }

        public static char TraneConvertChar_Stock(string tran_str)
        {
            if(tran_str.CompareTo(GetResString(P.TRAN_S_0))==0) return (char)P.Tran_STK.tcNORMAL;
            else if(tran_str.CompareTo(GetResString(P.TRAN_S_1))==0) return (char)P.Tran_STK.tcFIXED;
            else if(tran_str.CompareTo(GetResString(P.TRAN_S_2))==0) return (char)P.Tran_STK.tcBITS;
            return ' ';
        }

        public static char OTypeConvertChar_Stock(string otype_str)
        {
            if(otype_str.CompareTo(GetResString(P.OTYPE_S_0))==0) return (char)P.oType_S.Stock;
            else if(otype_str.CompareTo(GetResString(P.OTYPE_S_1))==0) return (char)P.oType_S.FNAgent;
            else if(otype_str.CompareTo(GetResString(P.OTYPE_S_2))==0) return (char)P.oType_S.SLAgent;
            //else if(otype_str.CompareTo(GetResString(OTYPE_S_3))==0) return (char)oType_S.FNSelf;
            //else if(otype_str.CompareTo(GetResString(OTYPE_S_4))==0) return (char)oType_S.SLSelf;
            return ' ';
        }        

        public static char OTypeConvertChar_Future(string otype_str)
        {
            if(otype_str.CompareTo(GetResString(P.OTYPE_F_0))==0) return (char)P.oType_F.Open;
            else if(otype_str.CompareTo(GetResString(P.OTYPE_F_1))==0) return (char)P.oType_F.Close;
            else if(otype_str.CompareTo(GetResString(P.OTYPE_F_9))==0) return (char)P.oType_F.Auto;
            return ' ';
        }
    }   
}
