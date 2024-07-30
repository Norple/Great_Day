using GreatDay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogController : MonoBehaviour
{
    //ÿ������Ҫ���жԻ�ʱ���Ƚ���ǰ״̬����ΪisTalking�����ó����л��Ĳ�����֮��ÿһ�ε�����ջ�е���һ���Ի����ݽ�����ʾ������ɶԻ�֮��isTalking����Ϊfalse�����½�����ѹ��ջ�С�
    public DialogueData dialogEmpty;
    //public DialogueData dialogFinish;
    //����ջ���洢�Ի�����
    private Stack<string> dialogEmptyStack = new Stack<string>();
    //private Stack<string> dialogFinishStack = new Stack<string>();
    private bool shouldContinueDialog = false;

    public bool isTalking;
    private bool hasMoreDialog = true; // �����ʼʱ���жԻ�Ҫ����

    private void Awake()
    {
        FillDialogStack();
    }

    public void FillDialogStack()
    {
        for (int i = dialogEmpty.dialogueList.Count - 1; i >= 0; i--)
        {
            dialogEmptyStack.Push(dialogEmpty.dialogueList[i]);
        }
    }
    public void ShowDialogEmpty()
    {
        if (!isTalking)
            StartCoroutine(DialogRoutine(dialogEmptyStack));
    }
    private IEnumerator DialogRoutine(Stack<string> data)
    {
        isTalking = true;
        Debug.Log("DialogRoutineЭ�̿�ʼ");

        while (hasMoreDialog && data.TryPop(out string result))
        {
            Debug.Log("��ʼ�Ի�");
            EventHandler.CallShowDialogEvent(result);

            // �ȴ�ֱ����ҵ����������ֱ����һ֡����  
            while (!shouldContinueDialog)
            {
                yield return new WaitForEndOfFrame();
            }
            shouldContinueDialog = false; // ���ñ�־���Ա���һ��ѭ�����  

            // ֻ���ڷǿս��ʱ����ͣ��Ϸ  
            if (!string.IsNullOrEmpty(result))
            {
                EventHandler.CallGameStateChangedEvent(GameState.Pause);
            }
        }
        // ���жԻ�������ϣ��ָ���Ϸ״̬  
        if (!hasMoreDialog)
        {
            EventHandler.CallShowDialogEvent(string.Empty);
            Debug.Log("��string.Empty����Ϊ��");
            FillDialogStack();
            EventHandler.CallGameStateChangedEvent(GameState.GamePlay);
        }
        EventHandler.CallShowDialogEvent(string.Empty);
        isTalking = false;
        //yield break;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isTalking) // 0 ��������  
        {
            shouldContinueDialog = true;
        }
    }
}
