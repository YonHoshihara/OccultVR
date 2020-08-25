using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolenSoundController : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip damage;
    public AudioClip atack;
    public AudioClip roar;
    public AudioClip die;
    public AudioClip walk;
    public AudioSource audio;

    // Update is called once per frame
    private void playSound(AudioClip sound, bool loop)
    {
        audio.clip = sound;
        audio.loop = loop;
        audio.Play();
    }

    private void stopSound(AudioClip sound, bool loop)
    {
        audio.clip = sound;
        audio.loop = loop;
        audio.Stop();
    }

    public void playWalkSound(bool loop)
    {
        playSound(walk, loop);
    }

    public void playDamageSound(bool loop)
    {
        playSound(damage, loop);
    }

    public void playRoarSound(bool loop)
    {
        playSound(roar, loop);
    }

    public void playDieSound(bool loop)
    {
        playSound(die, loop);
    }

    public void playAtackSound(bool loop)
    {
        playSound(atack,loop);
    }


    public void stopWalkSound(bool loop)
    {
        stopSound(walk, loop);
    }

    public void stopDamageSound(bool loop)
    {
        stopSound(damage, loop);
    }

    public void stopRoarSound(bool loop)
    {
        stopSound(roar, loop);
    }

    public void stopDieSound(bool loop)
    {
        stopSound(die, loop);
    }

    public void stopAtackSound(bool loop)
    {
        stopSound(atack,loop);
    }

    void Update()
    {
        
    }
}
