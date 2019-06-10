using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsButtons : MonoBehaviour
{
    [SerializeField] Text changeText;
    int currentVolume = 5;
    int volumeMin = 0;
    int volumeMax = 10;

    private void Start()
    {
        changeText.text = currentVolume.ToString();
    }

    public void RaiseVolume(Text changeText)
    {
        currentVolume++;
        if (currentVolume > volumeMax)
        {
            currentVolume = 10;
        }
        changeText.text = currentVolume.ToString();
    }

    public void LowerVolume(Text changeText)
    {
        currentVolume--;
        if (currentVolume < volumeMin)
        {
            currentVolume = 0;
        }
        changeText.text = currentVolume.ToString();
    }
}
