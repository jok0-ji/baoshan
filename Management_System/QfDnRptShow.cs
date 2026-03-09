using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using BLL;
using Model;
using System.Threading;
using System.IO;
using DAT;



namespace Management_System
{
    public partial class QfDnRptShow : Form
    {
        private ShowToUi show;
        private PLCState PLCState = new PLCState();
        private PLC_Process plcProcess = new PLC_Process();
        private bool start = false;


        public QfDnRptShow()
        {
            InitializeComponent();           
           
            show = new ShowToUi();
            show.updateDataTable("[BS5GW].[dbo].[ProductB]", "qfdownreport");
            if (show.qfdntable.Tables.Count > 0 && show.qfdntable.Tables[0].Rows.Count > 0)
            {
                //有数据
                dgview_QfDnRpt.DataSource = show.qfdntable.Tables["qfdownreport"];//设置数据源
                count.Text = show.qfdntable.Tables["qfdownreport"].Rows.Count.ToString();
            }
            else
            {
                //无数据
            }

        }
        Thread plcProcessThread;

        private void QfDnRptShow_Load(object sender, EventArgs e)
        {
            PlcThread plcThread = new PlcThread();
            plcProcessThread = new Thread(plcThread.PlcThreadmain);
            //设置为后台线程
            // thread.IsBackground = true;
            //开始线程
            plcProcessThread.Start();
            start = true;


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //DateTime time = dateTimePicker1.Value;
           
            if (txb_code.Text.ToString() == "")//如果晶编为空
            {
                if(txb_macid.Text.ToString() == "")//晶编为空且机台号为空，那么仅仅按时间区间查询
                {
                    show.updateDataTable("[BS5GW].[dbo].[ProductB]", dateTimePicker1.Text.ToString(), dateTimePicker2.Text.ToString(), "qfdnrpt");
                }
                else//晶编为空，macid有值，那么是机台号和时间查询
                {
                    show.updateDataTableMachineCode("[BS5GW].[dbo].[ProductB]", dateTimePicker1.Text.ToString(), dateTimePicker2.Text.ToString(), txb_macid.Text, "qfdnrpt");
                }
            }
            else//晶编不为空
            {
                show.updateDataTableVague("[BS5GW].[dbo].[ProductB]", txb_code.Text, "qfdnrpt");
                
            }
            dgview_QfDnRpt.DataSource = show.qfdntable.Tables["qfdnrpt"];//设置数据源
            count.Text = show.qfdntable.Tables["qfdnrpt"].Rows.Count.ToString();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void stupcode_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_showall_Click(object sender, EventArgs e)
        {
           
            show.updateDataTable("[BS5GW].[dbo].[ProductB]", "qfdownreport");
            dgview_QfDnRpt.DataSource = show.qfdntable.Tables["qfdownreport"];//设置数据源
            count.Text = show.qfdntable.Tables["qfdownreport"].Rows.Count.ToString();
            
        }

        private void count_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //    if (plcProcess.IsMacConnect() == 1)
            //        toolStripStatusLabel1.Text = "切方机台连接成功";
            //    else

            //        toolStripStatusLabel1.Text = "切方机台连接失败"; 
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void QfDnRptShow_FormClosing(object sender, FormClosingEventArgs e)
        {
            plcProcessThread.Abort();
            //plcProcessThread.
        //PLC连接

    }

     
    }
}
