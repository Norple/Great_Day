/*using GreatDay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogUI : MonoBehaviour
{
    public GameObject panel;
    public Text dialogText;

    private void OnEnable()
    {
        EventHandler.ShowDialogEvent += ShowDialog;
    }

    private void OnDisable()
    {
        EventHandler.ShowDialogEvent -= ShowDialog;
    }


    private void ShowDialog(string dialog)
    {
        if (dialog != string.Empty)
            panel.SetActive(true);
        else
            panel.SetActive(false);
        dialogText.text = dialog;
    }
}*/
using UnityEngine;
using UnityEngine.UI;

namespace GreatDay
{
    public class DialogUI : MonoBehaviour
    {
        public GameObject panel;
        public Text dialogText;

        private void OnEnable()
        {
            // ʹ��AddListener������¼�������  
            EventHandler.ShowDialogEvent.AddListener(ShowDialog);
        }

        private void OnDisable()
        {
            // ʹ��RemoveListener���Ƴ��¼�������  
            EventHandler.ShowDialogEvent.RemoveListener(ShowDialog);
        }
        private void ShowDialog(string dialog)
        {
            if (dialog != string.Empty)
                panel.SetActive(true);
            else
                panel.SetActive(false);

            dialogText.text = dialog;
        }
    }
}

