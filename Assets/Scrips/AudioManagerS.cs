/***********************
 * Title: ""
 * Function:
 * 	- 
 * UsedBy:	
 * Author:	V.
 * Date:	2015.9
 * Record:	
 ***********************/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;                                       //泛型集合命名空间

public class AudioManagerS : MonoBehaviour 
{
	public AudioClip[] AuClipArray;                                     //音频剪辑数组
	private static Dictionary<string, AudioClip> DicAuArray;            //音频库
    private static AudioSource _AuSourceBGMusic;                        //背景音乐音频源
	private static GameObject AudioManagerInstance;						//用于接收音效组件
	
	void Awake() 
	{
        DicAuArray = new Dictionary<string, AudioClip>();               //加载音频库
        foreach (var AudioClip in AuClipArray)
		{
            DicAuArray.Add(AudioClip.name, AudioClip);
		}

		//处理音频源
		_AuSourceBGMusic=this.gameObject.AddComponent<AudioSource>();//背景音乐，位于AudioSource组件数组下标0
		AudioManagerInstance=this.gameObject;//接收音效音频源
	}//Awake_end
	


    /// <summary>
    ///传值 “音乐剪辑” 播放 “背景音乐” 
    /// </summary>
    /// <param name="audiClip">背景音乐剪辑</param>
	public static void PlayBGMusic(AudioClip audiClip)
	{
        if (audiClip)
		{
			_AuSourceBGMusic.loop = true;
            _AuSourceBGMusic.clip = audiClip;    //音频剪辑的赋值
            _AuSourceBGMusic.Play();             //播放背景音乐
		}
	}
	
    /// <summary>
    ///传值 “音乐剪辑名称” 播放 “背景音乐” 
    /// </summary>
    /// <param name="strAudioClipName">背景音乐名称</param>
    public static void PlayBGMusic(string strAudioClipName)
	{
		AudioClip audioClip;
		
		if (!string.IsNullOrEmpty(strAudioClipName))
		{
            audioClip = DicAuArray[strAudioClipName];
            PlayBGMusic(audioClip);                     	  //播放
		}
	}
	


    /// <summary>
    ///传值 “音乐剪辑” 播放 “背景音乐”
    /// </summary>
    /// <param name="audiClip">游戏音效剪辑</param>
	public static void PlayEffAudio(AudioClip audiClip)
	{   
        if (audiClip)                                         //播放
		{
			AudioSource[] AS=AudioManagerInstance.GetComponents<AudioSource>();
			for (int i = 1; i < AS.Length; i++) {//跳过下标0
				if (!AS[i].isPlaying) {
					AS[i].clip = audiClip;                  //音频剪辑的赋值
					AS[i].Play();                           //播放背景音乐
					return;
				}else{
					//元素被占用
				}
			}
			//当需要同时播放多个音效,添加新AudioSource
			AudioSource NewAS=AudioManagerInstance.AddComponent<AudioSource>();
			NewAS.loop=false;
			NewAS.clip=audiClip;
			NewAS.Play();
		}
	}
	
    /// <summary>
    ///传值 “音乐剪辑名称” 播放 “游戏音效”
    /// </summary>
    /// <param name="strAudioClipName">游戏音效剪辑名称</param>
    public static void PlayEffAudio(string strAudioClipName)
	{
		AudioClip audioClip;
		
		if (!string.IsNullOrEmpty(strAudioClipName))
		{
            audioClip = DicAuArray[strAudioClipName];
            PlayEffAudio(audioClip);                          //播放
		}        
	}
}
