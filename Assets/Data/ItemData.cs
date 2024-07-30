using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObject/道具数据", order = 0)]
public class ItemData : ScriptableObject
{
    //道具ID
    public int id;
    //道具名称
    public string strName;
    //道具图标
    public string icon;
    //道具类型
    public int type;
}
