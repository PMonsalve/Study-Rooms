using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Porta : MonoBehaviour
{
    public MathSign matematica1;
    public MathSign matematica2;
    public InputResposta placaResposta1;
    public InputResposta placaResposta2;
    public GameObject dialogBox;
    public Text dialogText;
    public string[] dialog;
    //private int currentDialog;
    public bool playerInRange;
    public string rta1, rta2;
    public string correta1, correta2;


    // Start is called before the first frame update
    void Start()
    {
        //currentDialog = 0;
    }

    // Update is called once per frame
    void Update()
    {
        rta1 = placaResposta1.RetornaResposta();
        rta2 = placaResposta2.RetornaResposta();
        correta1 = matematica1.RetornaRespCerta(1);
        correta2 = matematica2.RetornaRespCerta(2);

        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            if ((rta1 == correta1 && rta2 == correta2) || (rta1 == correta2 && rta2 == correta1))
            {
                Debug.Log("Porta aberta, parabéns!!!");
                //dialogBox.SetActive(false);
                //currentDialog = 0;
            }
            else
            {
                Debug.Log("Porta trancada, tente de novo.");
                //if (currentDialog < dialog.Length)
                //{
                //    dialogBox.SetActive(true);
                //    dialogText.text = dialog[currentDialog];
                //    currentDialog++;
                //}
            }
        }
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
            dialogBox.SetActive(false);
        }
    }
}
