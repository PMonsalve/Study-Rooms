using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resposta : MonoBehaviour
{
    public string rpta;
    public GameObject inputField;
    public GameObject textDisplay;

    public void GuardaRpta() {
        rpta = inputField.GetComponent<Text>().text;
        textDisplay.GetComponent<Text>().text = "Resposta " + rpta + " inserida.";
    }
        
}
