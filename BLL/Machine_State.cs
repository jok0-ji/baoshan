using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAT;
using System.Data.SqlClient;
using Model;

namespace BLL
{
   public class Machine_State
    {
        private SQLString sqlstr;
        //private JD_Machine jd_machine;
        //private KF_Machine kf_machine;
        ///private PM_Machine pm_machine;


        public  Machine_State()
        {
            sqlstr = new SQLString();
            //jd_machine = new JD_Machine();
           // kf_machine = new KF_Machine();
            //pm_machine = new PM_Machine();
        }
        //截断机机台状态
        public bool getJDState(int id,ref JD_Machine jD_Machine)
        {
            SqlDataReader sdr = null;
            try
            {
                sdr = DataBase.SelectForReader(sqlstr.selectSqlString("MACHINETRUNC", "No", id));//从数据库中
                sdr.Read();
                if (sdr.HasRows)
                {
                    jD_Machine.Machine_ID = sdr["Name"].ToString();
                    jD_Machine.Spec = Convert.ToInt32(sdr["Formula"]);
                    jD_Machine.State = Convert.ToInt32(sdr["State"]);
                    jD_Machine.Code[0] = sdr["Code1"].ToString();
                    jD_Machine.Code[1] = sdr["Code2"].ToString();
                    jD_Machine.Length[0] = Convert.ToInt32(sdr["Length1"]);
                    jD_Machine.Length[1] = Convert.ToInt32(sdr["Length2"]);//Offline
                    jD_Machine.Online = Convert.ToInt32(sdr["Offline"]);
                    sdr.Close();

                    return true;
                }
                else
                {
                    sdr.Close();
                    AppLog.WriteWarn("截断机的状态从数据库中读取失败1", true);
                    return false;

                }
            }
            catch (Exception ex)
            {
                AppLog.WriteWarn(string.Format("截断机的状态从数据库中读取失败{0}2", ex), true);

                return false;
            }

            finally
            {
                if (sdr != null)
                    if (!sdr.IsClosed)
                        sdr.Close();
            }
        }
        public  bool getKFState(int id, ref KF_Machine kf_machine)
        {
            SqlDataReader sdr = null;
            try
            {
                sdr = DataBase.SelectForReader(sqlstr.selectSqlString("MACHINESQURE", "No", id));//从数据库中
                sdr.Read();
                if (sdr.HasRows)
                {
                    kf_machine.Machine_id = sdr["Name"].ToString();
                    kf_machine.Spec = Convert.ToInt32(sdr["Formula"]);
                    kf_machine.State = Convert.ToInt32(sdr["State"]);
                    kf_machine.Code = sdr["Code"].ToString();
                    kf_machine.Length = (sdr["Length"] == DBNull.Value) ? 0 : Convert.ToInt32(sdr["Length"]);
                    kf_machine.Online = Convert.ToInt32(sdr["Offline"]);
                    sdr.Close();
                    return true;
                }
                else
                {
                    sdr.Close();
                    return false;
                }
            }
            catch
            {
                return false;
            }
            finally 
            {
                if (sdr != null)
                    if (!sdr.IsClosed)
                    sdr.Close();
            }
        }
        public bool getPMState(int id,ref PM_Machine pm_machine)
        {
            SqlDataReader sdr=null;
            try
            {
                pm_machine.initPM_Machine();
                sdr = DataBase.SelectForReader(sqlstr.selectSqlString("MACHINEPOLISHER", "No", id));//从数据库中
                sdr.Read();
                if (sdr.HasRows)
                {
                    pm_machine.Machine_id = sdr["Name"].ToString();
                    pm_machine.Spec = Convert.ToInt32(sdr["Formula"]);
                    pm_machine.State = Convert.ToInt32(sdr["State"]);
                    pm_machine.Code = sdr["Code"].ToString();
                    pm_machine.Length = (sdr["Length"] == DBNull.Value) ? 0 : Convert.ToInt32(sdr["Length"]);
                    pm_machine.Online = Convert.ToInt32(sdr["Offline"]);
                    sdr.Close();
                    return true;
                }
                else
                {
                    sdr.Close();
                    return false;
                }
            }
            catch 
            {
                return false;
            }
            finally
            {
                if (sdr != null)
                    if (!sdr.IsClosed)
                        sdr.Close();
            }
        }
    }
}
