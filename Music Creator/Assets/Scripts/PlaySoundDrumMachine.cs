using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaySoundDrumMachine : MonoBehaviour
{
    private AudioSource myAudioSource;
    public SamplesController samplesController;
    public Color _colorSample;
    public Color _colorNoSample;
    private Image myImage;
    private Text IDText;
    
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        myImage = GetComponent<Image>();
        IDText = GetComponentInChildren<Text>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bar"))
        {
            myAudioSource.Play();
        }
    }
    public void AssignAudioClip()
    {
        if(myAudioSource.clip ==null)
        {
            if (samplesController.clipSelected != null)
            {
                myAudioSource.clip = samplesController.clipSelected;

            }
            if (myAudioSource.clip != null)
            {
                myImage.color = _colorSample;
                IDText.text = samplesController.IDSampleSelected.ToString();
            }
        }
        else
        {
            myAudioSource.clip = null;
            myImage.color = _colorNoSample;
            IDText.text = "";
        }    
    }
}
