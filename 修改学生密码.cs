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
    public partial class 修改学生密码 : Form
    {
        String str;
        public 修改学生密码()
        {
            InitializeComponent();
        }
        public 修改学生密码(String s)
        {
            InitializeComponent();
            str = s;
        }
        static class CreateSqlConn
        {
            public static string ConnectionString = "Data Source=.;Initial Catalog= 学生成绩管理;Integrated Security=SSPI";
            //连接数据库字段，作为非系统管理员
            public static SqlConnection con = new SqlConnection(ConnectionString);  //创建一个连接对象
        }
        private void button1_Click(object sender, EventArgs e)
        {  
             
                  SqlCommand  cmd = new SqlCommand("update student set scode ='" + textBox1.Text.Trim() + "' where sno='" + str + "'", CreateSqlConn.con);
               CreateSqlConn.con.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("修改密码成功！");

                    }
                    else
                    {

                        MessageBox.Show("修改密码失败！");

                    }


                    CreateSqlConn.con.Close();

            
           
          
            
        }
     
    }
}
