using GreatDay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogController : MonoBehaviour
{
    //每次在需要进行对话时首先将当前状态设置为isTalking并禁用场景切换的操作，之后每一次点击便从栈中弹出一条对话内容进行显示。在完成对话之后将isTalking设置为false并重新将数据压入栈中。
    public DialogueData dialogEmpty;
    //public DialogueData dialogFinish;
    //利用栈来存储对话数据
    private Stack<string> dialogEmptyStack = new Stack<string>();
    //private Stack<string> dialogFinishStack = new Stack<string>();
    private bool shouldContinueDialog = false;

    public bool isTalking;
    private bool hasMoreDialog = true; // 假设初始时还有对话要播放

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
        Debug.Log("DialogRoutine协程开始");

        while (hasMoreDialog && data.TryPop(out string result))
        {
            Debug.Log("开始对话");
            EventHandler.CallShowDialogEvent(result);

            // 等待直到玩家点击鼠标左键或直到下一帧结束  
            while (!shouldContinueDialog)
            {
                yield return new WaitForEndOfFrame();
            }
            shouldContinueDialog = false; // 重置标志，以便下一次循环检查  

            // 只有在非空结果时才暂停游戏  
            if (!string.IsNullOrEmpty(result))
            {
                EventHandler.CallGameStateChangedEvent(GameState.Pause);
            }
        }
        // 所有对话播放完毕，恢复游戏状态  
        if (!hasMoreDialog)
        {
            EventHandler.CallShowDialogEvent(string.Empty);
            Debug.Log("将string.Empty设置为空");
            FillDialogStack();
            EventHandler.CallGameStateChangedEvent(GameState.GamePlay);
        }
        EventHandler.CallShowDialogEvent(string.Empty);
        isTalking = false;
        //yield break;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isTalking) // 0 是鼠标左键  
        {
            shouldContinueDialog = true;
        }
    }
}
