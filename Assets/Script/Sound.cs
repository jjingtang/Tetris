using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{

    public AudioSource audiosource;

    public static Sound _instance;
    void Awake()
    {
        audiosource = gameObject.AddComponent<AudioSource>();

        audiosource.playOnAwake = false;  //when playOnAwake is false,use play()to call

        _instance = this; //Sound._instance.PlayAudioByName("Control Game Object");
    }

    //play the audio from specific path using the method: PlayClipAtPoint()
    public void PlayAudioByName(string name)
    {
        //play the audio clip in the path: Resources/Sounds/file name
        AudioClip clip = Resources.Load<AudioClip>("Audio/" + name);
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
    }

    //if there is an audio playing at the moment, stop the current audio and play the next
    public void PlayMusicByName(string name)
    {
        AudioClip clip = Resources.Load<AudioClip>("Audio/" + name);

        if (audiosource.isPlaying)
        {
            audiosource.Stop();
        }

        audiosource.clip = clip;
        audiosource.Play();
    }
}