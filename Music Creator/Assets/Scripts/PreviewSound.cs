using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreviewSound : MonoBehaviour
{
    private AudioSource audioSource;
    public SamplesController samplesController;
    public GameObject[] otherSamples;
    public AudioSource[] otherAudioSource;
    public Color defaultColor;
    public Color selectedColor;
    private Image myImage;
    private Text sampleName;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        myImage = GetComponent<Image>();
        sampleName = GetComponentInChildren<Text>();
        sampleName.text = audioSource.clip.name;
    }
    public void PreviewAudioClip(int IDSample)
    { 
        samplesController.clipSelected = audioSource.clip;
        samplesController.IDSampleSelected = IDSample;
        foreach(GameObject samples in otherSamples)
        {
            samples.GetComponent<Image>().color = defaultColor;
            myImage.color = selectedColor;
        }
        foreach(AudioSource audioSources in otherAudioSource)
        {
            audioSources.Stop();
            audioSource.Play();
        }
    }
}
