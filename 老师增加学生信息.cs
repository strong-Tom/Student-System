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
    public partial class 老师增加学生信息 : Form
    {
        public 老师增加学生信息()
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
            // insert into student values('1','马超','男','24','1','123','计算机学院','666666')
            CreateSqlConn.con.Open();
            string s = "insert into score values('" + textBox1.Text.Trim() + "','" + textBox2.Text.Trim() + "','" + textBox3.Text.Trim() + "','" + textBox4.Text.Trim()
                + "')";
            try
            {
                SqlCommand com = new SqlCommand(s, CreateSqlConn.con);
                if (com.ExecuteNonQuery() > 0)
                    MessageBox.Show("增加成功!");
                else
                    MessageBox.Show("增加失败!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            CreateSqlConn.con.Close();
        }
    }
}
