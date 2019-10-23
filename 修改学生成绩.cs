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
    public partial class 修改学生成绩 : Form
    {
        public 修改学生成绩()
        {
            InitializeComponent();
        }
        static class CreateSqlConn
        {
            public static string ConnectionString = "Data Source=.;Initial Catalog= 学生成绩管理;Integrated Security=SSPI";
            //连接数据库字段，作为非系统管理员
            public static SqlConnection con = new SqlConnection(ConnectionString);  //创建一个连接对象
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string strcomm = "select * from dept";

                strcomm = "update score set score ='" + textBox1.Text.Trim() + "' where sno = '" + textBox2.Text.Trim() + "' and cno ='" + textBox3.Text.Trim()+"'";
                //update FilTer set 列名 = value where id = 3
                CreateSqlConn.con.Open();
                SqlCommand comm = new SqlCommand(strcomm, CreateSqlConn.con);
                comm.ExecuteNonQuery();
                if (comm.ExecuteNonQuery() > 0)
                    MessageBox.Show("修改成功！");
                else
                    MessageBox.Show("修改失败！");
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
