using System;
using System.Collections.Generic;
using System.Data.SqlClient;//引用数据库客户端
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Data;

namespace DAL
{
    public class DBHelper
    {
        //连接数据库
        static SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=WMS;Integrated Security=True");
        static SqlDataReader sdr;
        /// <summary>
        /// 获取数据流  查询、显示、绑定下拉
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        private static SqlDataReader GetDataReader(string sql, SqlParameter[] par = null)
        {
            try
            {
                //打开
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                //命令对象
                SqlCommand cmd = new SqlCommand(sql, conn);
                if (par != null)
                {
                    cmd.Parameters.AddRange(par);
                }
                sdr = cmd.ExecuteReader();
                return sdr;
            }
            catch (Exception)
            {
                if (sdr!=null&&!sdr.IsClosed)//数据流关闭
                {
                    sdr.Close();
                }
                throw;
            }

        }
        /// <summary>
        /// 返回受影响行数  
        /// 添加、删除、修改
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql, SqlParameter[] par = null)
        {
            try
            {
                //打开
                //判断状态
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                //命令对象
                SqlCommand cmd = new SqlCommand(sql, conn);
                if (par != null)
                {
                    cmd.Parameters.AddRange(par);
                }
                int n = cmd.ExecuteNonQuery();
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                return n;
            }
            catch (Exception)
            {
               
                throw;
            }
        }
        /// <summary>
        /// 数据流转List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sdr"></param>
        /// <returns></returns>
        private static List<T> DataReaderToList<T>(SqlDataReader sdr) {
            Type t = typeof(T);//获取类型
            //获取所有属性
            PropertyInfo[] p = t.GetProperties();
            //定义集合
            List<T> list = new List<T>();
            //遍历数据流
            while (sdr.Read()) {
                //创建对象
                T obj = (T)Activator.CreateInstance(t);
                //数据流列数
                string[] sdrFileName = new string[sdr.FieldCount];
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    sdrFileName[i] = sdr.GetName(i).Trim();
                }
                foreach (PropertyInfo item in p)
                {
                    //判断Model中的属性是否在流的列名中
                    if (sdrFileName.ToList().IndexOf(item.Name) > -1)
                    {
                        if (sdr[item.Name] != null)
                        {
                            item.SetValue(obj, sdr[item.Name]);//对象属性赋值
                        }
                        else
                        {
                            item.SetValue(obj, null);//对象属性赋值
                        }
                    }
                    else {
                        item.SetValue(obj, null);//对象属性赋值
                    }
                   
                }
                list.Add(obj);
            }
            return list;
        }
        /// <summary>
        /// 获取list集合
        ///  查询、显示、绑定下拉
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> GetToList<T>(string sql, SqlParameter[] par = null) {
            //获取流数据
            SqlDataReader sdr = GetDataReader(sql, par);
            List<T> list = DataReaderToList<T>(sdr);
            if (!sdr.IsClosed)//数据流关闭
            {
                sdr.Close();
            }
            return list;
        }
        /// <summary>
        /// 返回首行首列
        /// 登录
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string sql, SqlParameter[] par = null)
        {
            try
            {
                //打开
                //判断状态
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                //命令对象
                SqlCommand cmd = new SqlCommand(sql, conn);
                if (par != null)
                {
                    cmd.Parameters.AddRange(par);
                }
                object n = cmd.ExecuteScalar();
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                return n;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
