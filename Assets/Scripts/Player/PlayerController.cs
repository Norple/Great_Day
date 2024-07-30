using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController cc;//要先在player的component中添加characterController
    public float moveSpeed;

    private float horizontalMove, verticalMove;//获取按键值的两个变量
    private Vector3 dir;//方向

    private void Start()
    {
        cc = GetComponent<CharacterController>();//获取组件
    }
    
    private void Update()
    {
        //获得按键值
        horizontalMove = Input.GetAxis("Horizontal") * moveSpeed;
        verticalMove = Input.GetAxis("Vertical") * moveSpeed;

        dir = transform.forward * verticalMove + transform.right * horizontalMove;
        cc.Move(dir * Time.deltaTime);
    }
}