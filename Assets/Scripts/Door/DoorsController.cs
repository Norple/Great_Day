using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorsController : MonoBehaviour
{
    private Animator anim; // 动画控制器组件  
    private bool isOpen = false; // 记录门是否打开  
    private Collider doorCollider; // 门的碰撞体组件  

    public bool isInfor = false;
    public GameObject InforTip;

    // Start is called before the first frame update  
    void Start()
    {
        anim = GetComponent<Animator>(); // 获取动画控制器组件  
        doorCollider = GetComponent<Collider>(); // 获取门的碰撞体组件
        // 初始设置门不是触发器  
        doorCollider.isTrigger = isOpen;
        Debug.Log(name);
    }

    // Update is called once per frame  
    void Update()
    {
        // 如果门是打开的且玩家按下了E键，则关闭门  
        if (isOpen && Input.GetKeyDown(KeyCode.E))
        {
            CloseDoor();
        }
        // 如果门是关闭的且玩家按下了E键，并且玩家与门发生了碰撞，则打开门  
        else if (!isOpen && Input.GetKeyDown(KeyCode.E) && IsPlayerNearDoor())
        {
            OpenDoor();
        }
        Debug.Log(doorCollider.isTrigger);
    }

    private void OnDestroy()
    {
        //Debug.Log(name+"门组件脚本已关闭");
    }

    private void OpenDoor()
    {
        // 触发开门动画  
        anim.SetTrigger("Open");
        // 将门设置为触发器，允许玩家穿过
        isOpen = true; // 标记门为打开状态  
        doorCollider.isTrigger = isOpen;
        Debug.Log("触发开门动画，isTrigger为" + isOpen);
    }

    private void CloseDoor()
    {
        // 触发关门动画
        anim.SetTrigger("Close");
        //Debug.Log("此时isTrigger为false，isOpen为false");
        // 如果之前将门设置为触发器，现在关闭时应该将其改回非触发器状态  
        isOpen = false; // 标记门为关闭状态
        doorCollider.isTrigger = isOpen;
        Debug.Log("触发关门动画，isTrigger为" + isOpen);
    }

    // 检查玩家是否接近门（通过碰撞器检测）  
    private bool IsPlayerNearDoor()
    {
        // 假设玩家有一个名为PlayerTag的标签
        Collider[] colliders = Physics.OverlapBox(doorCollider.bounds.center, doorCollider.bounds.size * 0.5f); // 使用门的中心和大小来检测碰撞体  
        foreach (Collider col in colliders)
        {
            if (col.CompareTag("Player")) // 检查碰撞体是否有"Player"标签  
            {
                return true; // 如果找到带有"PlayerTag"标签的碰撞体，则返回true  
            }
        }
        return false; // 如果没有找到，则返回false
    }

    private void OnTriggerEnter(Collider other)
    {
        InforTip.SetActive(true);
        
    }

    private void OnTriggerStay(Collider other)
    {
        /*var doorX = transform.position.x;
        var doorZ = transform.position.z;*/
    }

    private void OnTriggerExit(Collider other)
    {
        InforTip.SetActive(false);
    }
}