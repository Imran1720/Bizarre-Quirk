using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource audioSource_BGM;
    public AudioSource audioSource_SFX;

    public SoundTypes[] soundTypes;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        audioSource_BGM.clip = GetSound(Sounds.BGM);
        audioSource_BGM.Play();
    }

    public void PlaySFX(Sounds sound)
    {
        audioSource_SFX.PlayOneShot(GetSound(sound));
    }

    public AudioClip GetSound(Sounds sound)
    {
        SoundTypes soundObject = Array.Find(soundTypes, item => item.soundType == sound);

        if (soundObject != null)
        {
            return soundObject.sound;
        }
        return null;
    }

}
[Serializable]
public class SoundTypes
{
    public Sounds soundType;
    public AudioClip sound;
}

public enum Sounds
{
    BGM,
    ButtonClick,
    PickUp,
    Jump,
    PowerUp,
    GameComplete,
    Lose
}