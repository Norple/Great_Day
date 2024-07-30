using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController cc;//Ҫ����player��component�����characterController
    public float moveSpeed;

    private float horizontalMove, verticalMove;//��ȡ����ֵ����������
    private Vector3 dir;//����

    private void Start()
    {
        cc = GetComponent<CharacterController>();//��ȡ���
    }
    
    private void Update()
    {
        //��ð���ֵ
        horizontalMove = Input.GetAxis("Horizontal") * moveSpeed;
        verticalMove = Input.GetAxis("Vertical") * moveSpeed;

        dir = transform.forward * verticalMove + transform.right * horizontalMove;
        cc.Move(dir * Time.deltaTime);
    }
}