using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class she : MonoBehaviour
{

    private void Awake()
    {
        //给对象添加一个AudioSource组件
        music = gameObject.AddComponent<AudioSource>();
        //设置不一开始就播放音效
        music.playOnAwake = false;
        //加载音效文件，我把跳跃的音频文件命名为jump
        she1 = Resources.Load<AudioClip>("Sounds/rocket");

    }

    public AudioSource music;
    public AudioClip she1;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {				
				//把音源music的音效设置为jump
                music.clip = she1;
            //播放音效
            music.Play();
        }
    }
}
