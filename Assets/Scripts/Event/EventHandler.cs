using System;
using UnityEngine;
using UnityEngine.Events;

namespace GreatDay
{
    public static class EventHandler
    {
        // ����һ��UnityEvent�����ڴ����ַ���������������ʾ�Ի�  
        public static UnityEvent<string> ShowDialogEvent = new UnityEvent<string>();

        // ����һ��UnityEvent�����ڴ���GameStateö��ֵ�����ڸı���Ϸ״̬  
        public static UnityEvent<GameState> GameStateChangedEvent = new UnityEvent<GameState>();

        // ������ʾ�Ի����¼�  
        public static void CallShowDialogEvent(string dialogText)
        {
            ShowDialogEvent?.Invoke(dialogText);
        }

        // ������Ϸ״̬�ı���¼�  
        public static void CallGameStateChangedEvent(GameState newState)
        {
            GameStateChangedEvent?.Invoke(newState);
        }

        // ��Ӽ���������ʾ�Ի����¼�  
        public static void AddShowDialogListener(UnityAction<string> listener)
        {
            ShowDialogEvent.AddListener(listener);
        }

        // �Ƴ�����������ʾ�Ի����¼�  
        public static void RemoveShowDialogListener(UnityAction<string> listener)
        {
            ShowDialogEvent.RemoveListener(listener);
        }

        // ��Ӽ���������Ϸ״̬�ı���¼�  
        public static void AddGameStateChangedListener(UnityAction<GameState> listener)
        {
            GameStateChangedEvent.AddListener(listener);
        }

        // �Ƴ�����������Ϸ״̬�ı���¼�  
        public static void RemoveGameStateChangedListener(UnityAction<GameState> listener)
        {
            GameStateChangedEvent.RemoveListener(listener);
        }
    }

    // ������Ϸ״̬��ö��  
    public enum GameState
    {
        GamePlay,
        Pause,
        // ������Ϸ״̬...  
    }
}