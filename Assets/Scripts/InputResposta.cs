using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputResposta : MonoBehaviour
{
    public MathSign sinalMatematica;
    public string rta;
    public string inputu;
    public GameObject botao;
    public GameObject inputField;
    public GameObject textDisplay;
    public bool playerInRange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rta = sinalMatematica.RetornaResp();

        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            if (textDisplay.activeInHierarchy)
            {
                botao.SetActive(false);
            }
            else
            {
                botao.SetActive(true);
            }
        }

    }
    public void GuardaRpta()
    {
        inputu = inputField.GetComponent<Text>().text;
        textDisplay.GetComponent<Text>().text = "Resposta " + inputu + " inserida.";

       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            botao.SetActive(false);
        }
    }

}
