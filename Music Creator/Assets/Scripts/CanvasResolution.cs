using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasResolution : MonoBehaviour
{
    public float aspect;
    public float rounded;
    private CanvasScaler canvasScaler;
    public GameObject[] canvasObjectsToMove;
    public GameObject[] samplersSequences;
    public GameObject[] scrollView;
    [Header("Screen 18:9")]
    public float newPositionX;
    public float _newPositionX;
    [Header("Screen 2960x1440")]
    public float TnewPositionX;
    public float T_newPositionX;
    [Header("Screen 800x480")]
    public float TnewPositionY;
    public float T_newPositionY;
    public float T__newPositionY;
    void Start()
    {
        canvasScaler = GetComponent<CanvasScaler>();
        aspect = Camera.main.aspect;
        rounded = (int)(aspect * 100.0f) / 100.0f;
        if (rounded == 2)
        {
            AddRatios(0.5f);
            foreach (GameObject samplersSequence in samplersSequences)
            {
                samplersSequence.transform.position = new Vector3(newPositionX, samplersSequence.transform.position.y, samplersSequence.transform.position.z);
            }
            foreach (GameObject _scrollView in scrollView)
            {
                _scrollView.transform.position = new Vector3(_newPositionX, _scrollView.transform.position.y, _scrollView.transform.position.z);
            }
        }
        else if (rounded == 2.04f || (rounded == 2.05f) || (rounded == 2.06f))
        {
            AddRatios(0.6f);
            foreach (GameObject samplersSequence in samplersSequences)
            {
                samplersSequence.transform.position = new Vector3(TnewPositionX, samplersSequence.transform.position.y, samplersSequence.transform.position.z);
            }
            foreach (GameObject _scrollView in scrollView)
            {
                _scrollView.transform.position = new Vector3(T_newPositionX, _scrollView.transform.position.y, _scrollView.transform.position.z);
            }
        }
        else if (rounded == 1.66f || (rounded == 1.67f) || (rounded == 1.68f))
        {
            AddRatios(0f);
            canvasObjectsToMove[0].transform.position = new Vector3(canvasObjectsToMove[0].transform.position.x, TnewPositionY, canvasObjectsToMove[0].transform.position.z);
            canvasObjectsToMove[1].transform.position = new Vector3(canvasObjectsToMove[1].transform.position.x, T_newPositionY, canvasObjectsToMove[1].transform.position.z);
            canvasObjectsToMove[2].transform.position = new Vector3(canvasObjectsToMove[2].transform.position.x, T__newPositionY, canvasObjectsToMove[2].transform.position.z);

        }

    }
    void AddRatios(float m)
    {
        if(canvasScaler!=null)
        {
            canvasScaler.matchWidthOrHeight = m;
            
        }
    }
    
}
