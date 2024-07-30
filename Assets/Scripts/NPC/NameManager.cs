using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 包含功能：判断靠近，绘制姓名，显示对话提示
/// </summary>
namespace GreatDay
{
    public class NameManager : MonoBehaviour
    {
        private GameObject player; // 主角对象  
        private Camera camera; // 主摄像机对象
                               //private string name = "成都"; // NPC名称
        private string name;
        private float npcHeight = 20f; // NPC模型高度，可根据模型大小更改
        private float displayDistance = 50f; // 玩家进入此范围时显示名字
        private bool shouldDisplay; // 默认为false，即不显示名字
        public GameObject inforTag;

        void Start()
        {
            // 根据Tag得到主角对象  
            player = GameObject.FindWithTag("Player");
            camera = Camera.main;
            shouldDisplay = false;
            Debug.Log("玩家不在显示距离内，设置shouldDisplayName为false");
            name = gameObject.name;
            showTag(shouldDisplay);
        }

        void Update()
        {
            // 计算玩家与NPC之间的距离  
            float distance = Vector3.Distance(transform.position, player.transform.position);

            // 如果玩家在显示距离内，设置shouldDisplayName为true  
            if (distance <= displayDistance)
            {
                
                shouldDisplay = true;
                Debug.Log("玩家在显示距离内，设置shouldDisplayName和canInteract为true");
            }
            else
            {
                shouldDisplay = false;
                Debug.Log($"玩家已离开 {name} 显示距离，设置shouldDisplayName和canInteract为false");
            }
            showTag(shouldDisplay);
        }

        /// <summary>
        /// npc头顶绘制姓名
        /// </summary>
        void OnGUI()
        {
            if (camera == null || player == null)
            {
                return;
            }
            if (shouldDisplay)
            {
                Debug.Log("输出npc名字");
                // 得到NPC头顶在3D世界中的坐标  
                Vector3 worldPosition = new Vector3(transform.position.x, transform.position.y + npcHeight, transform.position.z);
                // 根据NPC头顶的3D坐标换算成它在2D屏幕中的坐标  
                Vector2 position = camera.WorldToScreenPoint(worldPosition);
                // 得到真实NPC头顶的2D坐标  
                position = new Vector2(position.x, Screen.height - position.y);
                // 设置GUI样式和颜色等  
                GUIStyle fontStyle = new GUIStyle();
                fontStyle.fontSize = 60;
                //GUI.color = Color.yellow;
                // 计算NPC名称的宽高  
                Vector2 nameSize = GUI.skin.label.CalcSize(new GUIContent(name));
                // 绘制NPC名称  
                GUI.Label(new Rect(position.x - (nameSize.x / 2) - 100, position.y - nameSize.y, nameSize.x, nameSize.y), name, fontStyle);
            }
        }
        private void showTag(bool near)
        {
            if (near)
            {
                inforTag.SetActive(true);
                Debug.Log("交谈提示成功显示");
            }
            else inforTag.SetActive(false);
        }

    }
}