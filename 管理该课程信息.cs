using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
namespace 用户登录
{
    public partial class 管理该课程信息 : Form
    {
        public 管理该课程信息()
        {
            InitializeComponent();
        }
        string strtno, strcno;
        public 管理该课程信息(string s1,string s2)
        {
            InitializeComponent();
            this.dataGridView1.CellValueChanged += new DataGridViewCellEventHandler(dataGridView1_CellValueChanged);//把他看成监听器就好
            strtno = s1;
            strcno = s2;
            CreateSqlConn.con.Open();
            string s = "select student.sno,sname,score from student,score where student.sno=score.sno and score.cno='"+strcno+"' and score.tno='"+strtno+"'";

            SqlDataAdapter da = new SqlDataAdapter(s, CreateSqlConn.con);

            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count != 0)
            {
                dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                dataGridView1.ColumnHeadersHeight = 25;
                dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
                dataGridView1.RowHeadersWidth = 103;
                this.dataGridView1.Size = new Size((ds.Tables[0].Columns.Count + 1) * 103, (ds.Tables[0].Rows.Count + 1) * 25);
                this.dataGridView1.DataSource = ds.Tables[0];
            }
            else
                dataGridView1.DataSource = null;
            CreateSqlConn.con.Close();
        }
        static class CreateSqlConn
        {
            public static string ConnectionString = "Data Source=.;Initial Catalog= 学生成绩管理;Integrated Security=SSPI";
            //连接数据库字段，作为非系统管理员
            public static SqlConnection con = new SqlConnection(ConnectionString);  //创建一个连接对象
        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                string strcomm = "select * from dept";
                string strcolumn = dataGridView1.Columns[e.ColumnIndex].HeaderText;//获取列标题
                string strrow = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();//获取焦点触发行的第一个值
                string value = dataGridView1.CurrentCell.Value.ToString();//获取当前点击的活动单元格的值
                strcomm = "update score set score ='" + value + "' where sno = '" + strrow + "' and cno='"+strcno+"'";
                //update FilTer set 列名 = value where id = 3
                CreateSqlConn.con.Open();
                SqlCommand comm = new SqlCommand(strcomm, CreateSqlConn.con);
                comm.ExecuteNonQuery();
                if (comm.ExecuteNonQuery() > 0)
                    MessageBox.Show("修改成功！");
                else
                    MessageBox.Show("修改失败！你没有权限！");
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }
            finally
            {
                CreateSqlConn.con.Close();
            }
        }

    }
}
