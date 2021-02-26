using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteController : MonoBehaviour
{
    public AudioSource[] samplesToMute;
    public bool mute = false;
    public Color muted, noMuted;

    public void MuteInstrument()
    {
        if(mute==false)
        {
            mute = true;
            gameObject.GetComponent<Image>().color = muted;
            foreach(AudioSource mySamples in samplesToMute)
            {
                mySamples.mute = true;
            }
        }
        else
        {
            mute = false;
            gameObject.GetComponent<Image>().color = noMuted;
            foreach (AudioSource mySamples in samplesToMute)
            {
                mySamples.mute = false;
            }
        }
        
    }
}
