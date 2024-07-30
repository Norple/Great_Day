using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient; // ȷ�����������  
using UnityEngine;

public class DBServer : MonoBehaviour
{
    private MySqlConnection connection;
    private string connectionStr = "Server=127.0.0.1;Port=3306;Database=gddb;Uid=root;Pwd=root;";
    void Start()
    {
        // ��ʼ��MySQL����  
        connection = new MySqlConnection(connectionStr);
        try
        {
            // ������  
            connection.Open();

            string sqlQuery = "SELECT * FROM charactor";

            // ִ�в�ѯ����ȡ���  
            using (MySqlDataAdapter adapter = new MySqlDataAdapter(sqlQuery, connection))
            {
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                Debug.Log("��������" + ds.Tables[0].Rows.Count + " ������");

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Debug.Log("������" + ds.Tables[0].Rows[i]["C_NAME"] + " �Ա�" + ds.Tables[0].Rows[i]["C_GENDER"]);
                }
            }
        }
        catch (MySqlException ex)
        {
            // ����MySQL�쳣  
            Debug.LogError("MySQL����: " + ex.Message);
        }
        finally
        {
            // �ر�����  
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
    // �������������ڻ�ȡNPC�����б�  
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

            string sqlQuery = "SELECT C_NAME FROM charactor"; // ����C_NAME��NPC���ֵ��ֶ���  

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
            Debug.LogError("MySQL����: " + ex.Message);
        }

        return npcNames;
    }
}