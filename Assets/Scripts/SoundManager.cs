using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    private Dictionary<string, GameObject> playingSounds = new Dictionary<string, GameObject>();

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SFXPlay(string sfxname, AudioClip clip)
    {
        GameObject go = new GameObject(sfxname + "Sound");
        AudioSource audiosource = go.AddComponent<AudioSource>();
        audiosource.clip = clip;
        audiosource.Play();
        Destroy(go,clip.length);
        playingSounds[sfxname] = go;
    }
    public void StopSFX(string sfxname)
    {
        if (playingSounds.ContainsKey(sfxname))
        {
            GameObject soundObject = playingSounds[sfxname];
            if (soundObject != null)
            {
                Destroy(soundObject);
                playingSounds.Remove(sfxname);
            }
        }
    }
}

