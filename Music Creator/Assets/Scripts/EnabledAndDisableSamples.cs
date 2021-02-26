using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnabledAndDisableSamples : MonoBehaviour
{
    public GameObject[] Samples;
    public GameObject[] PanelsForLock;
    public SamplesController samplesController;

    public void EnableSamplesOfInstrument(int IDinstrument)
    {
        samplesController.clipSelected = null;
        foreach (GameObject instruments in Samples)
        {
            instruments.gameObject.SetActive(false);    
            {
                switch (IDinstrument)
                {
                    case 0:
                        {
                            Samples[0].gameObject.SetActive(true);
                            break;
                        }
                    case 1:
                        {
                            Samples[1].gameObject.SetActive(true);
                            break;
                        }
                    case 2:
                        {
                            Samples[2].gameObject.SetActive(true);
                            break;
                        }
                    case 3:
                        {
                            Samples[3].gameObject.SetActive(true);
                            break;
                        }
                    case 4:
                        {
                            Samples[4].gameObject.SetActive(true);
                            break;
                        }
                    case 5:
                        {
                            Samples[5].gameObject.SetActive(true);
                            break;
                        }
                    case 6:
                        {
                            Samples[6].gameObject.SetActive(true);
                            break;
                        }
                    case 7:
                        {
                            Samples[7].gameObject.SetActive(true);
                            break;
                        }
                    case 8:
                        {
                            Samples[8].gameObject.SetActive(true);
                            break;
                        }
                }
            }
        }   
    }
    public void EnablePanels(GameObject myPanel)
    {
        foreach(GameObject panels in PanelsForLock)
        {
            panels.gameObject.SetActive(true);
            myPanel.SetActive(false);
        }
    }
}
