using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource Main_Audio;//��Ҫ����
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("�������ֳɹ�����");
        Main_Audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
