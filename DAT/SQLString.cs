using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Common;

namespace DAT
{
    /// <summary>
    /// 常用的SQL语句提前写好，用的少的自动生成
    /// </summary>
    public class SQLString
    {
        /// <summary>
        /// 通用根据晶编查询语句
        /// </summary>
        /// <param name="pro"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public string selectSqlString(string table_name, string field_judge_condition, string judge_condition)
        {
            string sqlstr;
            sqlstr = string.Format("select * from {0} where {1} = '{2}'",
              table_name, field_judge_condition, judge_condition);
            return sqlstr;
        }//指定单一条件查询
        public string vagueSelectSqlString(string table_name, string field_judge_condition, string judge_condition)
        {
            string sqlstr;
            sqlstr = string.Format("select * from {0} where {1} like '%{2}%'",
              table_name, field_judge_condition, judge_condition);
            return sqlstr;
        }//指定单一条件查询
        public string selectSqlString(string table_name)//全查询
        {
            string sqlstr;
            sqlstr = string.Format("select * from {0} order by CREATETIME desc", table_name);
            return sqlstr;
        }
        public string selectSpecSqlString(string table_name)//全查询
        {
            string sqlstr;
            sqlstr = string.Format("select * from {0}", table_name);
            return sqlstr;
        }
        public string selectSqlString(string table_name, string field_judge_condition, int judge_condition)
        {
            string sqlstr;
            sqlstr = string.Format("select * from {0} where {1} = {2}",
              table_name, field_judge_condition, judge_condition);
            return sqlstr;
        }//按照单一条件查询
        /// <summary>
        ///根据时间全查询
        /// </summary>
        /// <param name="pro"></param>
        /// <param name="dt1"></param>
        /// <param name="dt2"></param>
        /// <returns></returns>
        public string selectSqlStringByTime(string table_name, string dt1, string dt2)
        {
            string sqlstr;
            sqlstr = string.Format("select * from {0} where createtime >'{1}' and createtime<'{2}' order by CreateTime desc",
                 table_name,dt1,dt2);
            return sqlstr;
        }
        //按照时间加条件查询
        public string selectSqlString(string table_name, string dt1, string dt2, string field_judge_condition,string judge_condition)
        {
            string sqlstr;
            sqlstr = string.Format("select * from {0} where createtime >'{1}' and createtime<'{2}' and {4} like '%{3}%' order by CREATETIME desc",
                 table_name, dt1, dt2, judge_condition, field_judge_condition);
            return sqlstr;
        }
        /// <summary>
        /// 更新圆棒表
        /// </summary>
        /// <param name="pro"></param>
        /// <param name="stup"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public string updateStupSqlString(ProductDetail pro, StupMessage stup, string str)
        {
            string sqlstr;
            sqlstr = string.Format("update {0} set {1}={2},{3}={4},{5}={6} where {6}='{7}'",
                pro.table_name, pro.sectionlength, stup.Sectionlength, pro.measurelength, stup.Measurelength,
                pro.tomss, stup.Tomss, pro.crystalid, stup.Cryatalid);//根据晶编更新圆棒表的有效长度，测量长度，工序等级
            return sqlstr;
        }
        /// <summary>
        /// 插入圆棒表消息
        /// </summary>
        /// <param name="stup"></param>
        /// <returns></returns>
        public string insertProdentail(RczdetailMes rczdetailMes,string code)
        {
            string sqlstr;
            string time = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            sqlstr = string.Format("insert into ProductDetail (CrystalId,Product,SectionLength,ResistLv,CreateTime,Tomss) values ('{0}','{1}','{2}','U','{3}',0)",code,rczdetailMes.ProductParentName,Convert.ToInt16(rczdetailMes.LotLenth),time);
             return sqlstr;
        }
        public string insertStupSqlString(StupMessage stup)
        {
            string sqlstr;
            sqlstr = string.Format("insert into ProductDetail values ('{0}','{1}','{2}',{3},{4},'{5}','{6}',{7})",
                 stup.Cryatalid, stup.Parentcrystaid, stup.Product, stup.Sectionlength, stup.Measurelength,
               stup.Resistlv, stup.Creattime, stup.Tomss);
            return sqlstr;
        }
        /// <summary>
        /// 长毛棒表来自MES写入，只需查询与更新，无需插入
        /// </summary>
        /// <param name="longstep"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public string updataLongthStupSqlString(LongStupMessage longstep,string str)
        {
            string sqlstr;
            sqlstr = string.Format("update RCZDETAILINFO set UNDERLINENUM={0},SECTIONLENGTH_1={1},SECTIONLENGTH_2={2},SECTIONLENGTH_3={3}," +
            "SECTIONLENGTH_4={4},SECTIONLENGTH_5={5},SECTIONLENGTH_6={6},SECTIONLENGTH_7={7},TOMSS='{8}' where CRYSTALID='{9}'",
            longstep.Underlineunm,longstep.Sectionlength[0],longstep.Sectionlength[1],longstep.Sectionlength[2],longstep.Sectionlength[3],
            longstep.Sectionlength[4],longstep.Sectionlength[5],longstep.Sectionlength[6],longstep.Tomss,str);
            return sqlstr;
        }
        /// <summary>
        /// 简单更新语句，根据一个条件，更新一个字段
        /// </summary>
        /// <returns></returns>
        public string updateSqlString(string table_name, string field_judge_condition, string judge_condition, string field_name, string field_value)
        {
            string sqlstring;
            sqlstring = string.Format("update {0} set {1}={2} where {3}={4}", table_name, field_judge_condition, judge_condition, field_name, field_value);
            return sqlstring;
        }
        public string updateSqlString(string table_name, string field_judge_condition, int judge_condition, string field_name, string field_value)
        {
            string sqlstring;
            sqlstring = string.Format("update {0} set {1}={2} where {3}='{4}'", table_name, field_judge_condition, judge_condition, field_name, field_value);
            return sqlstring;
        }
        public string updateTomss(string table_name, string field_judge_condition, string judge_condition, string field_name, string field_value)
        {
            string sqlstring;
            sqlstring = string.Format("update {0} set {1}= '{2}' where {3}='{4}'",table_name, field_judge_condition, judge_condition, field_name, field_value);


            return sqlstring;
        }
            /// <summary>
            /// 上料报表只需要插入查询即可，不存在更新
            /// </summary>
            /// <param name="kup"></param>
            /// <returns></returns>
            public string insertKFUpSqlString(KFUpReport kup)//
        {
            string sqlstring;
            sqlstring = string.Format("insert into REPORTSQUREFEED values( '{0}','{1}',{2},'{3}','{4}','{5}')",
                kup.Crystalid,kup.Product,kup.Sectionlength,kup.Processmachine,kup.Createtime,kup.Tomss);
            return sqlstring;
        }
        public string insertJDUpSqlString(JDUpReport jup)//
        {
            string sqlstring;
            sqlstring = string.Format("insert into REPORTTRUNCFEED values ('{0}','{1}',{2},'{3}','{4}','{5}')",
                jup.Crystalid, jup.Product, jup.Crystallength, jup.Processmachine, jup.Createtime, jup.Tomss);
            return sqlstring;
        }
        public string insertSpecSqlString(Spec spec)//
        {
            string sqlstring;
            sqlstring = string.Format("insert into SPECSETTING (PRODUCT,FORMULATRUNC,FORMULASQURE,FORMULAPOLISHER) values( '{0}',{1},{2},{3})",
                spec.Product, spec.Formulatrunc, spec.Formulasqure, spec.Formulapolisher);
            return sqlstring;
        }

        public string insertSurSqlString(SurfaceChecked sur)//
        {//INSERT INTO table_name (列1, 列2,...) VALUES (值1, 值2,....)
            string sqlstring;
            sqlstring = string.Format("insert into SURFACECHECKED ( CRYSTALID,CHECKERESULT,CREATETIME,TOMSS) values ( '{0}',{1},'{2}','{3}')",
                sur.Crystalid, sur.Checkeresult,sur.Createtime, sur.Tomss);
            return sqlstring;
        }
        public string insertSignalFeed(string code,string judge_condition,int length,int tom)
        {
            string sqlstring;
            sqlstring = string.Format("insert into ProductDetail (CrystalId,Product,SectionLength,MeasureLength,Tomss) values ('{0}','{1}','{2}','{3}',{4})",code,judge_condition,length,length,tom);
                return sqlstring;
        }
        /// <summary>
        /// 下料报表
        /// </summary>
        /// <param name="kup"></param>
        /// <returns></returns>
       
        //下料报表是否存在
          public string ifKFDownExistsql(string code)
        {
            return string.Format("select count(CRYSTALID) from REPORTSQUREFINISHED where CRYSTALID='{0}'", code);
        }
        public string insertKFDownSqlString(KFDownReport kup)//
        {
            string sqlstring;
            sqlstring = string.Format("insert into REPORTSQUREFINISHED values ('{0}','{1}',{2},'{3}','{4}','{5}','{6}','{7}')",
                kup.Crystalid, kup.Product, kup.Sectionlength, kup.Processmachine,kup.Processstarttime,kup.Processendtime,kup.Createtime, kup.Tomss);
            return sqlstring;
        }
        //上料报表是否存在
        public string ifKFUpExistsql(string code)
        {
            return string.Format("select count(CRYSTALID) from REPORTPOLISHERFEED where CRYSTALID='{0}'", code);
        }

        public string insertPMUpSqlString(PMUpReport kup)//
        {
            string sqlstring;
            sqlstring = string.Format("insert into REPORTPOLISHERFEED values ('{0}','{1}',{2},'{3}','{4}','{5}')",
                kup.Crystalid, kup.Product, kup.Sectionlength, kup.Processmachine, kup.Createtime, kup.Tomss);
            return sqlstring;
        }
        public string insertPMDownSqlString(PMDownReport pm)//
        {////INSERT INTO table_name (列1, 列2,...) VALUES (值1, 值2,....)
            string sqlstring;
            sqlstring = string.Format("insert into REPORTPOLISHERFINISHED values ('{0}','{1}',{2},'{3}','{4}','{5}','{6}','{7}')",
                pm.Crystalid, pm.Product, pm.Sectionlength, pm.Processmachine, pm.Processstarttime, pm.Processendtime, pm.Createtime, pm.Tomss);
            return sqlstring;
        }
        /// <summary>
        /// 同用删除
        /// </summary>
        /// <param name="table_name"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public string deleteSqlString(string table_name,string column,string value)
        {
            string sqlstring;
            sqlstring = string.Format("delete from {0} where {1}='{2}'",table_name,column,value);
            return sqlstring;
        }
        /// <summary>
        /// 通用简单查询
        /// </summary>
        /// <param name="table_name"></param>
        /// <param name="select_column"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public string selectSqlString(string select_column, string table_name, string column,string value)
        {
            string sqlstr;
            sqlstr = string.Format("select {0} from {1} where {2}='{3}'",select_column,table_name,column,value);
            return sqlstr;
        }
        public string insertEngravungSqlString(EngravungDetail eng)//
        {
            string sqlstring;
            sqlstring = string.Format("insert into ENGRAVINGDETAIL values ('{0}','{1}',{2},'{3}','{4}')",
                eng.Crystalid,eng.Product,eng.Sectionlength,eng.Createtime,eng.Tomss);
            return sqlstring;
        }
        public string selectPerformace(string str)
        {
            string sqlstring;
            sqlstring = string.Format("select ProductDetail.CRYSTALID,PROCESSCHECKED.CREATETIME,{0} from ProductDetail inner join PROCESSCHECKED on ProductDetail.CRYSTALID=PROCESSCHECKED.CRYSTALID　order by PROCESSCHECKED.CREATETIME desc", str);
            return sqlstring;
        }
        public string selectPerformace(string str,string code)
        {
            string sqlstring;
            sqlstring = string.Format("select ProductDetail.CRYSTALID,PROCESSCHECKED.CREATETIME,{0} from ProductDetail inner join PROCESSCHECKED on ProductDetail.CRYSTALID=PROCESSCHECKED.CRYSTALID where ProductDetail.CRYSTALID like '%{1}%' ", str, code);
            return sqlstring;
        }
        public string selectPerformace(string str, int result,string dt1,string dt2)
        {
            string sqlstring;
            sqlstring = string.Format("select ProductDetail.CRYSTALID,PROCESSCHECKED.CREATETIME,{0} from ProductDetail inner join PROCESSCHECKED on ProductDetail.CRYSTALID=PROCESSCHECKED.CRYSTALID where {1}={2} and PROCESSCHECKED.CREATETIME>'{3}' and PROCESSCHECKED.CREATETIME <'{4}' ", 
                str, str,result,dt1,dt2);
            return sqlstring;
        }
        public string selectPerformace(string str, string dt1, string dt2)
        {
            string sqlstring;
            sqlstring = string.Format("select ProductDetail.CRYSTALID,PROCESSCHECKED.CREATETIME,{0} from ProductDetail inner join PROCESSCHECKED on ProductDetail.CRYSTALID=PROCESSCHECKED.CRYSTALID where PROCESSCHECKED.CREATETIME>'{1}' and PROCESSCHECKED.CREATETIME <'{2}' ",
                str, dt1, dt2);
            return sqlstring;
        }
        public string insertSplicedetail(Splicedetail spli,string tablename)
        {
            string str;
            str = string.Format("insert into {0}(CRYSTALID_1,CRYSTALID_2,SECTIONLENGTH_1,SECTIONLENGTH_2,PRODUCT_1,PRODUCT_2,CREATETIME) values ({1},{2},{3},{4},{5},{6},{7})",
              tablename, spli.Crystalid_1, spli.Crystalid_2, spli.Sectionlength_1, spli.Sectionlength_2, spli.Product_1, spli.Product_2, spli.Createtime);
            return str;
        }
        public string updateSplicedetail(Splicedetail spli, string tablename)
        {
            string str;
            str = string.Format("insert into {0}(CRYSTALID_1,CRYSTALID_2,SECTIONLENGTH_1,SECTIONLENGTH_2,PRODUCT_1,PRODUCT_2,CREATETIME) values ('{1}','{2}',{3},{4},'{5}','{6}',{7})",
              tablename, spli.Crystalid_1, spli.Crystalid_2, spli.Sectionlength_1, spli.Sectionlength_2, spli.Product_1, spli.Product_2, spli.Createtime);
            return str;
        }
        public string selectSplicedetail(string code)
        {
            string str;
            str = string.Format("select * from SPLICEDETAIL where CRYSTALID_1='{0}' or CRYSTALID_2='{1}'", code, code);
            return str;            
        }
        public string selectTomss(string tablename)
        {
            string str;
            str = string.Format("select Top 5 * from {0} where TOMSS IS NULL or TOMSS=0", tablename);
            return str;
        }
        //临时增加的开方上料报表过站
        public string selectKfupTomss(string tablename)
        {
            string str;
            str = string.Format("select Top 5 * from {0} where createtime>'2022-05-14 08:00:00.000' and(TOMSS IS NULL or TOMSS=0)", tablename);
            return str;
        }
        public string selectCount(string tablename, string timer1, string timer2)
        {
            string str;
            str = string.Format("select count(*) from {0} where CREATETIME >'{1}' and CREATETIME<'{2}'", tablename, timer1, timer2);
            return str;
        }
        public string updateKFMachineState(KF_Machine kfMachinec)//更新机台状态
        {
            //UPDATE table_name SET column1 = value1, column2 = value2, ...WHERE condition;
            string str;
            str = string.Format("update MACHINESQURE set State={0},Code='{1}',Length={2},OFFLINE={3}  where No={4}", kfMachinec.State,kfMachinec.Code,kfMachinec.Length,kfMachinec.Online,kfMachinec.Id);
            return str;
        }
        public string insertNGReport(NGReport ngreport)
        {//INSERT INTO table_name (列1, 列2,...) VALUES (值1, 值2,....)
            string str;
            str = string.Format("INSERT INTO NGREPORTS (CRYSTALID,PRODUCT,SECTIONLENGTH,NGREASON,CREATETIME) values ('{0}','{1}',{2},'{3}','{4})'",ngreport.Crystalid,ngreport.Product,ngreport.Length,ngreport.Ngreason,ngreport.Createtime);
            return str;
        }
        public string updatePMMachineState(PM_Machine pmMachinec)//更新机台状态
        {
            //UPDATE table_name SET column1 = value1, column2 = value2, ...WHERE condition;
            string str;
            str = string.Format("update MACHINEPOLISHER set State={0},Code='{1}',Length={2},OFFLINE={3} where No={4}", pmMachinec.State, pmMachinec.Code, pmMachinec.Length, pmMachinec.Online, pmMachinec.Id);
            return str;
        }
        public string insertToRczDetail(LongStupMessage longStupMessage)
        {
            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            return string.Format("insert into RCZDETAILINFO (CRYSTALID,PRODUCT,RESISTLV,CRYSTALLENGTH,UNDERLINENUM,SECTIONLENGTH_1,SECTIONLENGTH_2,SECTIONLENGTH_3,SECTIONLENGTH_4,SECTIONLENGTH_5,SECTIONLENGTH_6,SECTIONLENGTH_7,SECTIONLENGTH_8,SECTIONLENGTH_9,SECTIONLENGTH_10,CREATETIME) values ('{0}','{1}','{2}',{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},'{15}') ",
                longStupMessage.Crystalid,longStupMessage.Product,longStupMessage.Resistlv,longStupMessage.Crystalleng,longStupMessage.Underlineunm,longStupMessage.Sectionlength[0],longStupMessage.Sectionlength[1],longStupMessage.Sectionlength[2],longStupMessage.Sectionlength[3],longStupMessage.Sectionlength[4],longStupMessage.Sectionlength[5],longStupMessage.Sectionlength[6],longStupMessage.Sectionlength[7],longStupMessage.Sectionlength[8],longStupMessage.Sectionlength[9],time);
        }
        public string ifLongstupExistSql(string code)
        {
            return string.Format("select count(CRYSTALID) from RCZDETAILINFO where CRYSTALID='{0}'", code);
        }
        public string ifProcessCheckedExictSql(string code)
        {
            return string.Format("select count(CRYSTALID) from PROCESSCHECKED where CRYSTALID='{0}'", code);
        }
        public string ifProDentailExictSql(string code)
        {
            return string.Format("select count(CRYSTALID) from ProductDetail where CRYSTALID='{0}'", code);
        }
        public string insertProcessChecked(StupMessage step)
        {
            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            return string.Format("insert into PROCESSCHECKED (CRYSTALID,PRODUCT,SECTIONLENGTH,CREATETIME) values ('{0}','{1}',{2},'{3}')", step.Cryatalid, step.Product, step.Sectionlength, time);
        }
        public string insertProcessCheckedResult(string code,int result)
        {
            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            return string.Format("insert into PROCESSCHECKED (CRYSTALID,ElectricResult,CREATETIME) values ('{0}',{1},'{2}')", code,result,time);
        }
        public string updateProcessChecked(string code, short result)
        {
            return string.Format("update PROCESSCHECKED set ElectricResult={0} where CRYSTALID='{1}'", result, code);
        }
       
        public string updateProcessChecked(string code, short result, short way)
        {
            return string.Format("update PROCESSCHECKED set OXYGENRESULT={0},Way={1}  where CRYSTALID='{2}'", result,way,code);
        }
        public string updateProcessCheckedWay(string code,short way)
        {
            return string.Format("update PROCESSCHECKED set Way={0}  where CRYSTALID='{1}'",way, code);
        }

        public string updateJDMachineState(JD_Machine jD_Machine)
        {
            return string.Format("update MACHINETRUNC set State={0},Code1='{1}',Code2='{2}',Length1={3},Length2={4},Offline={5}  where No={6}",jD_Machine.State,jD_Machine.Code[0],jD_Machine.Code[1],jD_Machine.Length[0],jD_Machine.Length[1],jD_Machine.Online,jD_Machine.Id);
        }

        public string ifJdFinishReportExictSql(string code)
        {
            return string.Format("select count(CRYSTALID) from REPORTTRUNCFINISHED where CRYSTALID='{0}'", code);
        }
        public string insertJdFinishReport(JDFinishReport jDFinishReport)
        {
            return string.Format("insert into REPORTTRUNCFINISHED  (CRYSTALID,PRODUCT,SECTIONLENGTH,PROCESSMACHINE,PROCESSSTARTTIME,PROCESSENDTIME,CREATETIME,TOMSS) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}',{7})"
                , jDFinishReport.Crystalid, jDFinishReport.Product, jDFinishReport.Sectionlength, jDFinishReport.Processmachine, jDFinishReport.Processstarttime, jDFinishReport.Processendtime, jDFinishReport.Processendtime,0);
        }
        public string insertNgString(string code,string reason)//
        {//INSERT INTO table_name (列1, 列2,...) VALUES (值1, 值2,....)
            string sqlstring;
            sqlstring = string.Format("insert into NGREPORTS (CRYSTALID,NGREASON) values ('{0}','{1}')",
                code,reason);
            return sqlstring;
        }
        

        public string selectQfYuan(string code)
        {
            string sqlstring;
            sqlstring = string.Format("select * from [BS5GW].[dbo].[YuanBang] where code = '{0}' ORDER BY RepairMark DESC", code);
            return sqlstring;
        }
        public string selectMacB(int no)
        {
            string sqlstring;
            sqlstring = string.Format("select * from [BS5GW].[dbo].[MachineB] where no = {0} ", no);
            return sqlstring;
        }
        public string selectProductSpec()
        {
            string sqlstring;
            sqlstring = string.Format("select * from [BS5GW].[dbo].[ProductSpec]");
            return sqlstring;
        }
        public string insertQfFinishReport(QFDownReport qFDownReport,string strr,float result,string name)
        {
            string sqlstring;
            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            sqlstring = string.Format("insert into [BS5GW].[dbo].[ProductB] (CreateTime, Flight, MacShop, Code, Spec,MacID, RepairMark, Length, CalWeight, WireCost, WireLeft, WireBreakTimes,StartTime,EndTime,MacTMID,Width1,Width2,WireStart,technologyName) " +
                "values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}',{6},{7} ,{8}, {9}, {10}, {11},'{12}','{13}','{14}',{15},{16},{17},'{18}')", time, qFDownReport.Flight1, qFDownReport.MacShop1, qFDownReport.Code1,
                qFDownReport.Spec1, qFDownReport.MacID1, qFDownReport.RepairMark1, qFDownReport.Length1, qFDownReport.CalWeight1, qFDownReport.WireCost1, qFDownReport.WireLeft1,
                qFDownReport.WireBreakTimes1, qFDownReport.beginTime.ToString(), qFDownReport.endTime.ToString(), strr, qFDownReport.Width1, qFDownReport.Width2,result,name) ;
            return sqlstring;
            //INSERT INTO dbo.ProductB (CreateTime, Flight, MacShop, Code, Spec, "
            //L"MacID, RepairMark, Length, CalWeight, WireCost, WireLeft, WireBreakTimes) "
            //L"VALUES ('%s', '%s', '%s', '%s', '%s', '%s', %d, %d, %f, %f, %d, %d)",
        }
      
    } 
}

