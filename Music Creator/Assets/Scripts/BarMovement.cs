using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarMovement : MonoBehaviour
{
    public float translation;
    public Vector3 initialPos;
    public float speed = 1;
    Rigidbody2D myRB;
    private Vector2 velocity;
    public float maxX;
    public bool Playing = false;
    public Text speedText, currentSequenceText;
    public float speedController = 1;
    private Image myImage;
    public AudioSource[] allSoundsDrumMachine;
    public int currentSequence;
    public int maxSequences;
    public SecuencesController secuencesController;
    public GameObject[] samplers;
    private void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myImage = GetComponent<Image>();
        currentSequence = secuencesController.secuences;
        maxSequences = currentSequence;
    }
    public void Play()
    {
        Playing = true;
        StartCoroutine(MoveBar());
    }
    public void Stop()
    {
        Playing = false;
    }
    private void Update()
    {
        if(transform.position.x>maxX)
        {
            maxSequences = secuencesController.secuences;
            if(currentSequence<maxSequences)
            {
                currentSequence++;
                currentSequenceText.text = currentSequence.ToString();
                transform.position = initialPos;
                foreach (AudioSource audios in allSoundsDrumMachine)
                {
                    audios.Stop();
                }
                foreach(GameObject _samplers in samplers)
                {
                    _samplers.SetActive(false);
                    samplers[currentSequence-1].SetActive(true);
                }
            }
            else
            {
                currentSequence = 1;
                currentSequenceText.text = currentSequence.ToString();
                transform.position = initialPos;
                foreach (AudioSource audios in allSoundsDrumMachine)
                {
                    audios.Stop();
                }
                foreach (GameObject _samplers in samplers)
                {
                    _samplers.SetActive(false);
                    samplers[currentSequence-1].SetActive(true);
                }
            }
            
        }
    }
    IEnumerator MoveBar()
    {
        while(Playing)
        {
            transform.Translate(new Vector2(translation, 0));
            myImage.enabled = true;
            yield return new WaitForSeconds(speed/2);
        }  
    }
    public void ToIncrementSpeed()
    {
        if(speedController<2)
        {
            speedController += 0.25f;
            speed -= 0.1f;
        }
        speedText.text = "X" + speedController;
        
    }
    public void ToDecrementSpeed()
    {
        if (speedController > 0.25f)
        {
            speedController -= 0.25f;
            speed += 0.1f;
        }
        speedText.text = "X" + speedController;
        
    }

}

