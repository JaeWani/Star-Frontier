using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance = null;
    public static SoundManager Instance => _instance;

    public List<AudioClip> mList = new List<AudioClip>();
    public List<AudioClip> soundList = new List<AudioClip>();
    GameObject curBGM;

    void Awake()
    {
        _instance = this;
        Sound(mList[0], true, 1);
    }

    public void Sound(AudioClip clip, bool isLoop, float volume){
        GameObject obj = new GameObject("obj");
        AudioSource audio = obj.AddComponent<AudioSource>();
        audio.clip = clip;
        audio.loop = isLoop;
        audio.volume = volume;
        audio.Play();

        if(!isLoop) Destroy(obj, clip.length);
        else {
            if(curBGM != null) Destroy(curBGM);
            curBGM = obj;
        }
    }

    public void SoundInt(int clip, float volume, float speed)
    {
        GameObject obj = new GameObject("obj");
        AudioSource audio = obj.AddComponent<AudioSource>();
        audio.clip = soundList[clip];
        audio.loop = false;
        audio.volume = volume;
        audio.pitch = speed;
        audio.Play();

        Destroy(obj, soundList[clip].length);

    }
}
