using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharDetail : MonoBehaviour
{
    public Image buttonImage;//按钮下的图片
    public Color hoverColor = Color.red; // 悬停时的颜色  
    private Color originalColor; // 原始颜色，用于鼠标退出时恢复 

    // Start is called before the first frame update
    void Start()
    {
        if (buttonImage == null)
        {
            buttonImage = transform.Find("Image").GetComponent<Image>();
        }
        //保留初始颜色
        originalColor = buttonImage.color;
    }
    // 当鼠标指针进入可点击对象（本例中的按钮）的边界时调用  
    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonImage.color = hoverColor; // 更改图片颜色为悬停颜色  
    }

    // 当鼠标指针退出可点击对象的边界时调用  
    public void OnPointerExit(PointerEventData eventData)
    {
        buttonImage.color = originalColor; // 恢复图片颜色为原始颜色  
    }
}
