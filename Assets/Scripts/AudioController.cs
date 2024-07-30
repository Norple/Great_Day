using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource Main_Audio;//主要音乐
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("背景音乐成功播放");
        Main_Audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
