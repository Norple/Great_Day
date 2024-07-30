using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �������ܣ��жϿ�����������������ʾ�Ի���ʾ
/// </summary>
namespace GreatDay
{
    public class NameManager : MonoBehaviour
    {
        private GameObject player; // ���Ƕ���  
        private Camera camera; // �����������
                               //private string name = "�ɶ�"; // NPC����
        private string name;
        private float npcHeight = 20f; // NPCģ�͸߶ȣ��ɸ���ģ�ʹ�С����
        private float displayDistance = 50f; // ��ҽ���˷�Χʱ��ʾ����
        private bool shouldDisplay; // Ĭ��Ϊfalse��������ʾ����
        public GameObject inforTag;

        void Start()
        {
            // ����Tag�õ����Ƕ���  
            player = GameObject.FindWithTag("Player");
            camera = Camera.main;
            shouldDisplay = false;
            Debug.Log("��Ҳ�����ʾ�����ڣ�����shouldDisplayNameΪfalse");
            name = gameObject.name;
            showTag(shouldDisplay);
        }

        void Update()
        {
            // ���������NPC֮��ľ���  
            float distance = Vector3.Distance(transform.position, player.transform.position);

            // ����������ʾ�����ڣ�����shouldDisplayNameΪtrue  
            if (distance <= displayDistance)
            {
                
                shouldDisplay = true;
                Debug.Log("�������ʾ�����ڣ�����shouldDisplayName��canInteractΪtrue");
            }
            else
            {
                shouldDisplay = false;
                Debug.Log($"������뿪 {name} ��ʾ���룬����shouldDisplayName��canInteractΪfalse");
            }
            showTag(shouldDisplay);
        }

        /// <summary>
        /// npcͷ����������
        /// </summary>
        void OnGUI()
        {
            if (camera == null || player == null)
            {
                return;
            }
            if (shouldDisplay)
            {
                Debug.Log("���npc����");
                // �õ�NPCͷ����3D�����е�����  
                Vector3 worldPosition = new Vector3(transform.position.x, transform.position.y + npcHeight, transform.position.z);
                // ����NPCͷ����3D���껻�������2D��Ļ�е�����  
                Vector2 position = camera.WorldToScreenPoint(worldPosition);
                // �õ���ʵNPCͷ����2D����  
                position = new Vector2(position.x, Screen.height - position.y);
                // ����GUI��ʽ����ɫ��  
                GUIStyle fontStyle = new GUIStyle();
                fontStyle.fontSize = 60;
                //GUI.color = Color.yellow;
                // ����NPC���ƵĿ��  
                Vector2 nameSize = GUI.skin.label.CalcSize(new GUIContent(name));
                // ����NPC����  
                GUI.Label(new Rect(position.x - (nameSize.x / 2) - 100, position.y - nameSize.y, nameSize.x, nameSize.y), name, fontStyle);
            }
        }
        private void showTag(bool near)
        {
            if (near)
            {
                inforTag.SetActive(true);
                Debug.Log("��̸��ʾ�ɹ���ʾ");
            }
            else inforTag.SetActive(false);
        }

    }
}