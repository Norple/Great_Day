using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapController : MonoBehaviour
{
    //获取到玩家位置x,z坐标，判断当前房间，将place name输出在ui上
    // 假设你有一个Text组件来显示房间名  
    public Text roomNameText;

    // 假设你有一个字典来存储房间范围和它们的名字  
    private Dictionary<string, Rect> roomBounds = new Dictionary<string, Rect>();

    // 初始化时设置房间边界（这只是一个示例，你可能需要根据实际场景调整）  
    void Start()
    {
        roomBounds.Add("Room101", new Rect(6, -450, 241, -318)); // x范围0-10, z范围0-10  
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
        // 检查玩家所在的房间并更新UI  
        string currentRoomName = GetCurrentRoomName();
        roomNameText.text = currentRoomName;
    }

    private string GetCurrentRoomName()
    {
        // 获取玩家的x和z坐标  
        float playerX = transform.position.x;
        float playerZ = transform.position.z;
        //Debug.Log("此时的玩家坐标为"+ playerX + "," + playerZ);

        // 遍历房间边界字典，找到玩家所在的房间  
        foreach (var room in roomBounds)
        {
            if (room.Value.Contains(new Vector2(playerX, playerZ)))
            {
                return room.Key; // 返回房间名  
            }
        }

        // 如果没有找到匹配的房间，返回一个默认值或空字符串  
        return "Unknown Room";
    }
}
