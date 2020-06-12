using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace PWMS.DataClass
{
    class MyMeans
    {
        #region
        public static string Login_ID = "";
        public static string Login_Name = "";
        //定义静态全局变量，记录“基础信息”各窗体中的表名、SQL语句以及要添加和修改的字段名
        public static string Mean_SQL = "", Mean_Table = "", Mean_Field = "";
        //定义一个SqlConnection类型的静态公共变量My_con，用于判断数据库是否连接成功
        public static SqlConnection My_con;
        //连接字符串 TODO:这里记得补全自己的数据库
        public static string M_str_sqlcon = "Data Source=";
        public static int Login_n = 0; //用户登录与重新登陆的标识
        //存储职工基本信息表中的SQL语句
        public static string AllSql = "SELECT * FROM tb_Staffbasic";
        #endregion

        public static SqlConnection getcon()
        {
            My_con = new SqlConnection(M_str_sqlcon); //与指定的数据库相连接
            My_con.Open(); 
            return My_con;
        }
        //测试数据库是否赋加
        public void con_open()
        {
            getcon();
            //con_close();
        }
        //操作完之后判断是否与数据库连接，如连接则关闭
        public void con_close()
        {
            if(My_con.State == ConnectionState.Open)
            {
                My_con.Close();
                My_con.Dispose(); //释放My_con变量的所有空间
            }
        }
        //用SqlDataReader对象以只读的方式读取指定表中的信息的信息
        public SqlDataReader getcom(string SQLstr)
        {
            getcon(); //打开与数据库的连接
            //用于执行SQL语句
            SqlCommand My_com = My_con.CreateCommand();
            My_com.CommandText = SQLstr;
            SqlDataReader My_read = My_com.ExecuteReader();
            return My_read;
        }
        //用SqlCommand对象执行数据库中的添加、修改和删除的操作
        public void getsqlcom(string SQLstr)
        {
            getcon();
            SqlCommand SQLcom = new SqlCommand(SQLstr, My_con);
            SQLcom.ExecuteNonQuery();
            SQLcom.Dispose();
            con_close();
        }
        //用SqlCommand对象执行数据库中的添加、修改和删除的操作
        public DataSet getDataSet(string SQLstr, string tableName)
        {
            getcon();
            SqlDataAdapter SQLda = new SqlDataAdapter(SQLstr, My_con);
            DataSet My_DataSet = new DataSet();
            SQLda.Fill(My_DataSet, tableName);
            con_close();
            return My_DataSet;
        }
    }
}
