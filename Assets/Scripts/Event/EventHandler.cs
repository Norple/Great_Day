using System;
using UnityEngine;
using UnityEngine.Events;

namespace GreatDay
{
    public static class EventHandler
    {
        // 定义一个UnityEvent，用于传递字符串参数，用于显示对话  
        public static UnityEvent<string> ShowDialogEvent = new UnityEvent<string>();

        // 定义一个UnityEvent，用于传递GameState枚举值，用于改变游戏状态  
        public static UnityEvent<GameState> GameStateChangedEvent = new UnityEvent<GameState>();

        // 触发显示对话的事件  
        public static void CallShowDialogEvent(string dialogText)
        {
            ShowDialogEvent?.Invoke(dialogText);
        }

        // 触发游戏状态改变的事件  
        public static void CallGameStateChangedEvent(GameState newState)
        {
            GameStateChangedEvent?.Invoke(newState);
        }

        // 添加监听器到显示对话的事件  
        public static void AddShowDialogListener(UnityAction<string> listener)
        {
            ShowDialogEvent.AddListener(listener);
        }

        // 移除监听器从显示对话的事件  
        public static void RemoveShowDialogListener(UnityAction<string> listener)
        {
            ShowDialogEvent.RemoveListener(listener);
        }

        // 添加监听器到游戏状态改变的事件  
        public static void AddGameStateChangedListener(UnityAction<GameState> listener)
        {
            GameStateChangedEvent.AddListener(listener);
        }

        // 移除监听器从游戏状态改变的事件  
        public static void RemoveGameStateChangedListener(UnityAction<GameState> listener)
        {
            GameStateChangedEvent.RemoveListener(listener);
        }
    }

    // 定义游戏状态的枚举  
    public enum GameState
    {
        GamePlay,
        Pause,
        // 其他游戏状态...  
    }
}