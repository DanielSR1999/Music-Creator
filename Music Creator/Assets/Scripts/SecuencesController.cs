using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecuencesController : MonoBehaviour
{
    public Text SecuencesText, currentSequenceText;
    public Button[] secuencesButtons;
    public int secuences = 1;
    public GameObject[] secuencesGameObjects;
    public BarMovement barMovement;

    [Header("UI Tutorial")]
    public int currentStateUI = 1;
    public int maxState;
    public int minState;
    public float initialDragPosition;
    public float endDragPosition;
    public float relativeDragging;
    public Image[] points;
    public Color pointActive;
    public GameObject[] UIState;
    public int tutorialValue = 0;
    public GameObject TutorialGameObject;

    void Start()
    {
        tutorialValue = PlayerPrefs.GetInt("Tutorial", 0);
        if(tutorialValue==0)
        {
            TutorialGameObject.SetActive(true);
        }
        else
        {
            TutorialGameObject.SetActive(false);
        }
        
        SecuencesText.text = secuences.ToString();
        foreach(Button buttons in secuencesButtons)
        {
            buttons.interactable = false;
            secuencesButtons[0].interactable = true;
        }
    }

   
    public void IncrementSecuences()
    {
        if(secuences<5)
        {
            secuences++;
            barMovement.maxSequences++;
            SecuencesText.text = secuences.ToString();
            for(int i=0;i<secuences;i++)
            {
                secuencesButtons[i].interactable = true;
            }
        }
        
    }
    public void DecrementSecuences()
    {
        if (secuences > 1)
        {
            secuences--;
            barMovement.maxSequences--;
            SecuencesText.text = secuences.ToString();
            for (int i = secuences; i > secuences-1; i--)
            {
                secuencesButtons[i].interactable = false;
            }
        }

    }

    public void EnableGameObjects(GameObject objectToEnable)
    {
        foreach(GameObject secuences in secuencesGameObjects)
        {
            secuences.gameObject.SetActive(false);
            objectToEnable.gameObject.SetActive(true);
        }
    }
    public void ShowCurrentSequece(int currentSequence)
    {
        currentSequenceText.text = currentSequence.ToString();
        barMovement.currentSequence = currentSequence;
        barMovement.gameObject.transform.position = barMovement.initialPos;
    }
    public void SetActiveGameObject(GameObject _object)
    {
        if(_object.activeSelf)
        {
            _object.gameObject.SetActive(false);
            points[currentStateUI - 1].color = Color.white;
            UIState[currentStateUI - 1].gameObject.SetActive(false);
            currentStateUI = 1;
            points[currentStateUI - 1].color = pointActive;
            UIState[currentStateUI - 1].gameObject.SetActive(true);
        }
        else
        {
            _object.gameObject.SetActive(true);
            points[currentStateUI - 1].color = Color.white;
            UIState[currentStateUI - 1].gameObject.SetActive(false);
            currentStateUI = 1;
            points[currentStateUI - 1].color = pointActive;
            UIState[currentStateUI - 1].gameObject.SetActive(true);
        }
    }

    public void BeginDragUI()
    {
        initialDragPosition = Input.mousePosition.x;
    }
    public void EndDragUI()
    {
        endDragPosition = Input.mousePosition.x;

        relativeDragging = initialDragPosition - endDragPosition;
        if(relativeDragging>0 &&currentStateUI<maxState)
        {
            currentStateUI++;
            points[currentStateUI - 1].color = pointActive;
            points[currentStateUI - 2].color = Color.white;
            UIState[currentStateUI - 1].gameObject.SetActive(true);
            UIState[currentStateUI - 2].gameObject.SetActive(false);
        }
        else if(relativeDragging<0 &&currentStateUI>minState)
        {
            currentStateUI--;
            points[currentStateUI - 1].color = pointActive;
            points[currentStateUI].color = Color.white;
            UIState[currentStateUI - 1].gameObject.SetActive(true);
            UIState[currentStateUI].gameObject.SetActive(false);
        }
    }
    public void FinishTutorial()
    {
        PlayerPrefs.SetInt("Tutorial", 1);
    }
}
