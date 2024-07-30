using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogue : MonoBehaviour
{
    //用于查询当前npc姓名
    //private DBServer dbServer;
    // Start is called before the first frame update
    private Time timeController;
    private int ate;
    private int time;
    void Start()
    {
        
/*        //显示名字
        dbServer = GameObject.FindObjectOfType<DBServer>();
        if (dbServer != null)
        {
            List<string> npcNames = dbServer.GetNPCNames();
            foreach (string name1 in npcNames)
            {
                if (name == name1)
                {
                    name = name1;
                    Debug.Log("NPC名字: " + name);
                }

                // 这里你可以根据需要进行其他操作，比如设置UI上的文本等  
            }
        }
        else
        {
            Debug.LogError("未找到DBServer实例！");
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// 自动触发对话（日期，时间，行动点）【每1/3天触发】
    /// </summary>
    /// <param name="dateNum"></param>
    /// <param name="timeNum"></param>
    /// <param name="RAP"></param>
    private void autoDisplay(int dateNum, int timeNum, int RAP)
    {

    }
}
