using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObject/��������", order = 0)]
public class ItemData : ScriptableObject
{
    //����ID
    public int id;
    //��������
    public string strName;
    //����ͼ��
    public string icon;
    //��������
    public int type;
}
