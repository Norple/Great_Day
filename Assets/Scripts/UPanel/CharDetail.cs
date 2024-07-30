using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharDetail : MonoBehaviour
{
    public Image buttonImage;//��ť�µ�ͼƬ
    public Color hoverColor = Color.red; // ��ͣʱ����ɫ  
    private Color originalColor; // ԭʼ��ɫ����������˳�ʱ�ָ� 

    // Start is called before the first frame update
    void Start()
    {
        if (buttonImage == null)
        {
            buttonImage = transform.Find("Image").GetComponent<Image>();
        }
        //������ʼ��ɫ
        originalColor = buttonImage.color;
    }
    // �����ָ�����ɵ�����󣨱����еİ�ť���ı߽�ʱ����  
    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonImage.color = hoverColor; // ����ͼƬ��ɫΪ��ͣ��ɫ  
    }

    // �����ָ���˳��ɵ������ı߽�ʱ����  
    public void OnPointerExit(PointerEventData eventData)
    {
        buttonImage.color = originalColor; // �ָ�ͼƬ��ɫΪԭʼ��ɫ  
    }
}
