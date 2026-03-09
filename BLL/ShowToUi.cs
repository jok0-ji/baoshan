using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAT;
using Model;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace BLL
{
   public class ShowToUi
    {
        public DataSet qfdntable = new DataSet();
        public SQLString sqlstr=new SQLString();
        static IniHelp ini = new IniHelp(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "sys.ini"));
       // private Communicat communicate ;

        public ShowToUi()
        {
        }
       
        public bool updateDataTable(string tablename,string str)
        {
            try
            {
                qfdntable = DataBase.ExecuteTable(sqlstr.selectSqlString(tablename), str);
                //jdtable = DataBase.ExecuteTable(sqlstr.selectSqlString(tablename), str);
                return true;
            }
            catch (Exception ex)
            {
                AppLog.WriteError(string.Format("{0}表格显示失败,{1}",tablename,ex.ToString()), true);
                return false;
            }
        }
        public void updateDataTable(string tablename,string dt1,string dt2,string str)
        {//按时间查询
            qfdntable = DataBase.ExecuteTable(sqlstr.selectSqlStringByTime(tablename,dt1,dt2), str);
        }
        public void updateDataTableMachineCode(string tablename, string dt1, string dt2, string machine,string str)
        {//按时间+机台号

            qfdntable = DataBase.ExecuteTable(sqlstr.selectSqlString(tablename, dt1, dt2, "MacID", machine), str);
        }
        public void updateDataTableVague(string tablename,string code,string str)
        {//晶编模糊查询
            qfdntable = DataBase.ExecuteTable(sqlstr.vagueSelectSqlString(tablename, "Code",code), str);
        }
        /// <summary>
        /// 查看产品规格
        /// </summary>
        public void findSped(string str)
        {
            qfdntable = DataBase.ExecuteTable(sqlstr.selectSpecSqlString("SPECSETTING"), str);
        }
        public void insertSped(Spec spec)
        {
           // sqlstr.insertSpecSqlString(spec);
            DataBase.Update(sqlstr.insertSpecSqlString(spec));
        }
        public void deleteSped(string condition)
        {
            DataBase.Update(sqlstr.deleteSqlString("SPECSETTING", "PRODUCT", condition));
        }
       
        public void showAllMachine(string tablename, string str)
        {
            //jdtable = DataBase.ExecuteTable(sqlstr.selectSpecSqlString(tablename), str);
        }
        public void updateMachineSpec(string tablename,int id,int spec)
        {
            DataBase.Update(sqlstr.updateSqlString(tablename, "Formula", spec.ToString(), "No", id.ToString()));
        }
        public void showPerformace(string per,string str)
        {
            //jdtable=DataBase.ExecuteTable(sqlstr.selectPerformace(per), str);
        }
        public void showPerformaceByCode(string per,string code,string str)
        {
           // jdtable = DataBase.ExecuteTable(sqlstr.selectPerformace(per, code), str);
        }
        public void showPerformaceByTime(string per, string dt1,string dt2, string str)
        {
            //jdtable = DataBase.ExecuteTable(sqlstr.selectPerformace(per, dt1,dt2), str);
        }
        public void showPerformaceByNg(string per, string dt1, string dt2, string str)
        {
            //jdtable = DataBase.ExecuteTable(sqlstr.selectPerformace(per,2, dt1, dt2), str);
        }
        public int getCount(string tablename,string time1,string time2)
        {
            //2021-08-27 15:19:46.000
            DataBase.SelectForScalar(sqlstr.selectCount(tablename, time1 + " 08:30", time2 + " 08:30"), out int count);
            return count;  
        }
        public bool getPlcConnection()//获取PLC的连接状况
        {
            
            return false;
        }
        public bool getDatabaseConnection()//获取数据库的连接状况
        {
            return false;
        }
        public bool ifOpenDataBase()
        {
            DataBase dbHelp = new DataBase();
            return dbHelp.ifOpen();
        }
    }
}
