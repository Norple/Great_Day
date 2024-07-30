using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceToPlayer : MonoBehaviour
{
    private float rotateSpeed = 50f;
    public void FaceToFace()
    {
        var playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        transform.LookAt(playerPos);
/*        Vector2 direction = playerPos.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        // 使用RotateTowards来平滑旋转  
        Quaternion currentRotation = transform.rotation;
        transform.rotation = Quaternion.RotateTowards(currentRotation, targetRotation, rotateSpeed * Time.deltaTime);*/
    }
}
