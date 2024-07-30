using UnityEngine;
using UnityEditor;
public class EditorTool
{
    [MenuItem("Tool/创建道具数据")]
    public static void CreateMyData()
    {
        //得到需要创建的数据结构类型
        ItemData asset = ScriptableObject.CreateInstance<ItemData>();
        //创建一个数据资源文件，第二个参数为存储路径
        AssetDatabase.CreateAsset(asset, "Assets/Data/ItemData.asset");
        //保存创建的资源
        AssetDatabase.SaveAssets();
        //刷新界面
        AssetDatabase.Refresh();
    }
}