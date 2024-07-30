using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorsController : MonoBehaviour
{
    private Animator anim; // �������������  
    private bool isOpen = false; // ��¼���Ƿ��  
    private Collider doorCollider; // �ŵ���ײ�����  

    public bool isInfor = false;
    public GameObject InforTip;

    // Start is called before the first frame update  
    void Start()
    {
        anim = GetComponent<Animator>(); // ��ȡ�������������  
        doorCollider = GetComponent<Collider>(); // ��ȡ�ŵ���ײ�����
        // ��ʼ�����Ų��Ǵ�����  
        doorCollider.isTrigger = isOpen;
        Debug.Log(name);
    }

    // Update is called once per frame  
    void Update()
    {
        // ������Ǵ򿪵�����Ұ�����E������ر���  
        if (isOpen && Input.GetKeyDown(KeyCode.E))
        {
            CloseDoor();
        }
        // ������ǹرյ�����Ұ�����E��������������ŷ�������ײ�������  
        else if (!isOpen && Input.GetKeyDown(KeyCode.E) && IsPlayerNearDoor())
        {
            OpenDoor();
        }
        Debug.Log(doorCollider.isTrigger);
    }

    private void OnDestroy()
    {
        //Debug.Log(name+"������ű��ѹر�");
    }

    private void OpenDoor()
    {
        // �������Ŷ���  
        anim.SetTrigger("Open");
        // ��������Ϊ��������������Ҵ���
        isOpen = true; // �����Ϊ��״̬  
        doorCollider.isTrigger = isOpen;
        Debug.Log("�������Ŷ�����isTriggerΪ" + isOpen);
    }

    private void CloseDoor()
    {
        // �������Ŷ���
        anim.SetTrigger("Close");
        //Debug.Log("��ʱisTriggerΪfalse��isOpenΪfalse");
        // ���֮ǰ��������Ϊ�����������ڹر�ʱӦ�ý���ĻطǴ�����״̬  
        isOpen = false; // �����Ϊ�ر�״̬
        doorCollider.isTrigger = isOpen;
        Debug.Log("�������Ŷ�����isTriggerΪ" + isOpen);
    }

    // �������Ƿ�ӽ��ţ�ͨ����ײ����⣩  
    private bool IsPlayerNearDoor()
    {
        // ���������һ����ΪPlayerTag�ı�ǩ
        Collider[] colliders = Physics.OverlapBox(doorCollider.bounds.center, doorCollider.bounds.size * 0.5f); // ʹ���ŵ����ĺʹ�С�������ײ��  
        foreach (Collider col in colliders)
        {
            if (col.CompareTag("Player")) // �����ײ���Ƿ���"Player"��ǩ  
            {
                return true; // ����ҵ�����"PlayerTag"��ǩ����ײ�壬�򷵻�true  
            }
        }
        return false; // ���û���ҵ����򷵻�false
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