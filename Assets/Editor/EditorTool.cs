using UnityEngine;
using UnityEditor;
public class EditorTool
{
    [MenuItem("Tool/������������")]
    public static void CreateMyData()
    {
        //�õ���Ҫ���������ݽṹ����
        ItemData asset = ScriptableObject.CreateInstance<ItemData>();
        //����һ��������Դ�ļ����ڶ�������Ϊ�洢·��
        AssetDatabase.CreateAsset(asset, "Assets/Data/ItemData.asset");
        //���洴������Դ
        AssetDatabase.SaveAssets();
        //ˢ�½���
        AssetDatabase.Refresh();
    }
}