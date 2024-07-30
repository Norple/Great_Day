using Language.Lua;
using PixelCrushers.DialogueSystem;
using UnityEngine;

/// <summary>
/// ������ı�ʱ�䣬��ʼʱ�ǣ�0��3��������ָ����ָ����������루1��1����ʼ�ж���
/// </summary>
namespace GreatDay
{
    public class TimeController : MonoBehaviour
    {
        public Information informationComponent; // ����Information���  
        // �����ʼֵ����Ϊ0��3 
        private int dateNum = 0;
        private int timeNum = 3;
        //public DialogController dialogController;
        //private DialogueDatabase dialogueDB;

        void Start()
        {
            //dialogueDB = FindAnyObjectByType<DialogueDatabase>();
            dateNum = DialogueLua.GetVariable("day").asInt;
            timeNum = DialogueLua.GetVariable("time").asInt;
            Debug.Log("����" + dateNum + "ʱ��" + timeNum);
            informationComponent.SetDataNum(dateNum);
            informationComponent.SetTimeNum(timeNum);
        }
        //������Ϸ״̬��ʱ��������dataNum��timeNum��ֵ
        private void Update()
        {
            timeUpdate();
        }
        /// <summary>
        /// ��鲢���µ�ǰʱ��
        /// </summary>
        private void timeUpdate()
        {
            if (dateNum!= DialogueLua.GetVariable("day").asInt)
            {
                
                dateNum = DialogueLua.GetVariable("day").asInt;
                informationComponent.SetDataNum(dateNum);
                Debug.Log("���ڸı���");
            }
            if(timeNum!= DialogueLua.GetVariable("time").asInt)
            {
                

                timeNum = DialogueLua.GetVariable("time").asInt;
                informationComponent.SetTimeNum(timeNum);
                Debug.Log("ʱ��ı��ˣ���ǰʱ��" + timeNum);
            }
        }
    }
}