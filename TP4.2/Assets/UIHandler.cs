using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    public void OnButtonClick()
    {
        Debug.Log("Le bouton a �t� cliqu� !");
    }
    public void OnSliderValueChanged(float value)
    {
        Debug.Log("Valeur du slider : " + value);
    }
}
