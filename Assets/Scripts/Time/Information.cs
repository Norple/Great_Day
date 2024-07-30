using UnityEngine;
using UnityEngine.UI;

public class Information : MonoBehaviour
{
    public Text dateText; // ������ʾ���ڵ��ı����  
    public Text timeText; // ������ʾʱ����ı����  

    private int dateNum;
    private int timeNum;

    public void SetDataNum(int newDataNum)
    {
        dateNum = newDataNum;
        UpdateDataText();
    }

    public void SetTimeNum(int newTimeNum)
    {
        timeNum = newTimeNum;
        UpdateTimeText();
    }

    private void UpdateDataText()
    {
        if (dateText != null)
        {
            //Debug.Log("��ʱ�ǵ�"+dateNum+"��");
            switch (dateNum)
            {
                case 0:
                    dateText.text = "The ??? Day"; // ����ָ��
                    break;
                case 1:
                    dateText.text = "The First Day";
                    break;
                case 2:
                    dateText.text = "The Second Day";
                    break;
                case 3:
                    dateText.text = "The Third Day";
                    break;
                default:
                    dateText.text = "������";
                    break;
            }
        }
    }

    private void UpdateTimeText()
    {
        if (timeText != null)
        {
            //Debug.Log("time numberΪ"+timeNum);
            switch (timeNum)
            {
                case 1:
                    timeText.text = "*morning*";
                    break;
                case 2:
                    timeText.text = "*afternoon*";
                    break;
                case 3:
                    timeText.text = "*night*";
                    break;
                default:
                    timeText.text = ""; // ����Ĭ��ֵ(������)
                    break;
            }
        }
    }
}