using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapController : MonoBehaviour
{
    //��ȡ�����λ��x,z���꣬�жϵ�ǰ���䣬��place name�����ui��
    // ��������һ��Text�������ʾ������  
    public Text roomNameText;

    // ��������һ���ֵ����洢���䷶Χ�����ǵ�����  
    private Dictionary<string, Rect> roomBounds = new Dictionary<string, Rect>();

    // ��ʼ��ʱ���÷���߽磨��ֻ��һ��ʾ�����������Ҫ����ʵ�ʳ���������  
    void Start()
    {
        roomBounds.Add("Room101", new Rect(6, -450, 241, -318)); // x��Χ0-10, z��Χ0-10  
        roomBounds.Add("Room102", new Rect(241, -450, 518, -318));
        roomBounds.Add("Room103", new Rect(518, -450, 793, -318));
        roomBounds.Add("Room104", new Rect(573, -236, 793, -130));
        roomBounds.Add("Room105", new Rect(316, -236, 573, -130));
        roomBounds.Add("Room106", new Rect(81, -236, 316, -130));
        roomBounds.Add("My Room", new Rect(81, 102, 316, 198));
        roomBounds.Add("Room108", new Rect(316, 102, 573, 198));
        roomBounds.Add("Room109", new Rect(573, 102, 793, 198));
        roomBounds.Add("Room110", new Rect(448, 428, 794, 534));
        roomBounds.Add("Room111", new Rect(124, 428, 448, 534));
        roomBounds.Add("Room112", new Rect(-84, 428, 124, 534));
    }

    // Update is called once per frame  
    void Update()
    {
        // ���������ڵķ��䲢����UI  
        string currentRoomName = GetCurrentRoomName();
        roomNameText.text = currentRoomName;
    }

    private string GetCurrentRoomName()
    {
        // ��ȡ��ҵ�x��z����  
        float playerX = transform.position.x;
        float playerZ = transform.position.z;
        //Debug.Log("��ʱ���������Ϊ"+ playerX + "," + playerZ);

        // ��������߽��ֵ䣬�ҵ�������ڵķ���  
        foreach (var room in roomBounds)
        {
            if (room.Value.Contains(new Vector2(playerX, playerZ)))
            {
                return room.Key; // ���ط�����  
            }
        }

        // ���û���ҵ�ƥ��ķ��䣬����һ��Ĭ��ֵ����ַ���  
        return "Unknown Room";
    }
}
