using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    public void OnButtonClick()
    {
        Debug.Log("Le bouton a été cliqué !");
    }
    public void OnSliderValueChanged(float value)
    {
        Debug.Log("Valeur du slider : " + value);
    }
}
