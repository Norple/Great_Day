using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogue : MonoBehaviour
{
    //���ڲ�ѯ��ǰnpc����
    //private DBServer dbServer;
    // Start is called before the first frame update
    private Time timeController;
    private int ate;
    private int time;
    void Start()
    {
        
/*        //��ʾ����
        dbServer = GameObject.FindObjectOfType<DBServer>();
        if (dbServer != null)
        {
            List<string> npcNames = dbServer.GetNPCNames();
            foreach (string name1 in npcNames)
            {
                if (name == name1)
                {
                    name = name1;
                    Debug.Log("NPC����: " + name);
                }

                // ��������Ը�����Ҫ����������������������UI�ϵ��ı���  
            }
        }
        else
        {
            Debug.LogError("δ�ҵ�DBServerʵ����");
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// �Զ������Ի������ڣ�ʱ�䣬�ж��㣩��ÿ1/3�촥����
    /// </summary>
    /// <param name="dateNum"></param>
    /// <param name="timeNum"></param>
    /// <param name="RAP"></param>
    private void autoDisplay(int dateNum, int timeNum, int RAP)
    {

    }
}
