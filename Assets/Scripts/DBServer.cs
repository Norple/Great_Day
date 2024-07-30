using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient; // 确保你有这个库  
using UnityEngine;

public class DBServer : MonoBehaviour
{
    private MySqlConnection connection;
    private string connectionStr = "Server=127.0.0.1;Port=3306;Database=gddb;Uid=root;Pwd=root;";
    void Start()
    {
        // 初始化MySQL连接  
        connection = new MySqlConnection(connectionStr);
        try
        {
            // 打开连接  
            connection.Open();

            string sqlQuery = "SELECT * FROM charactor";

            // 执行查询并获取结果  
            using (MySqlDataAdapter adapter = new MySqlDataAdapter(sqlQuery, connection))
            {
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                Debug.Log("检索到：" + ds.Tables[0].Rows.Count + " 条数据");

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Debug.Log("姓名：" + ds.Tables[0].Rows[i]["C_NAME"] + " 性别：" + ds.Tables[0].Rows[i]["C_GENDER"]);
                }
            }
        }
        catch (MySqlException ex)
        {
            // 处理MySQL异常  
            Debug.LogError("MySQL错误: " + ex.Message);
        }
        finally
        {
            // 关闭连接  
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
    // 公共方法，用于获取NPC名字列表  
    public List<string> GetNPCNames()
    {
        List<string> npcNames = new List<string>();

        try
        {
            if (connection == null || connection.State != ConnectionState.Open)
            {
                connection = new MySqlConnection(connectionStr);
                connection.Open();
            }

            string sqlQuery = "SELECT C_NAME FROM charactor"; // 假设C_NAME是NPC名字的字段名  

            using (MySqlDataAdapter adapter = new MySqlDataAdapter(sqlQuery, connection))
            {
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    npcNames.Add(row["C_NAME"].ToString());
                }
            }
        }
        catch (MySqlException ex)
        {
            Debug.LogError("MySQL错误: " + ex.Message);
        }

        return npcNames;
    }
}