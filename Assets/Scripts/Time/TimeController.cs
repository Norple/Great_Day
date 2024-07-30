using Language.Lua;
using PixelCrushers.DialogueSystem;
using UnityEngine;

/// <summary>
/// 在这里改变时间，开始时是（0，3），新手指引。指引结束后进入（1，1）开始行动。
/// </summary>
namespace GreatDay
{
    public class TimeController : MonoBehaviour
    {
        public Information informationComponent; // 引用Information组件  
        // 假设初始值设置为0和3 
        private int dateNum = 0;
        private int timeNum = 3;
        //public DialogController dialogController;
        //private DialogueDatabase dialogueDB;

        void Start()
        {
            //dialogueDB = FindAnyObjectByType<DialogueDatabase>();
            dateNum = DialogueLua.GetVariable("day").asInt;
            timeNum = DialogueLua.GetVariable("time").asInt;
            Debug.Log("天数" + dateNum + "时间" + timeNum);
            informationComponent.SetDataNum(dateNum);
            informationComponent.SetTimeNum(timeNum);
        }
        //根据游戏状态或时间来更新dataNum和timeNum的值
        private void Update()
        {
            timeUpdate();
        }
        /// <summary>
        /// 检查并更新当前时间
        /// </summary>
        private void timeUpdate()
        {
            if (dateNum!= DialogueLua.GetVariable("day").asInt)
            {
                
                dateNum = DialogueLua.GetVariable("day").asInt;
                informationComponent.SetDataNum(dateNum);
                Debug.Log("日期改变了");
            }
            if(timeNum!= DialogueLua.GetVariable("time").asInt)
            {
                

                timeNum = DialogueLua.GetVariable("time").asInt;
                informationComponent.SetTimeNum(timeNum);
                Debug.Log("时间改变了，当前时间" + timeNum);
            }
        }
    }
}