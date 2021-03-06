using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MathSign : MonoBehaviour
{

    public GameObject dialogBox;
    public Text dialogText;
    public string[] dialog;
    private int currentDialog;
    private string rta1;
    private string rta2;
    public bool playerInRange;
    public Math matematica;


    // Start is called before the first frame update
    void Start(){
        currentDialog = 0;
        int valor = Random.Range(0, 4);
        Debug.Log(valor);
        if (this.CompareTag("Prob1"))
        {
            dialog[1] = matematica.Exp1(valor);
            rta1 = matematica.Resp1(valor);
        }else if(this.CompareTag("Prob2"))
            {
            dialog[1] = matematica.Exp2(valor);
            rta2 = matematica.Resp2(valor);
        } 
        //texto = matematica.Exp1();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            if (dialogBox.activeInHierarchy && currentDialog == dialog.Length)
            {
                dialogBox.SetActive(false);
                currentDialog = 0;
            }
            else
            {
                if (currentDialog < dialog.Length)
                {
                    dialogBox.SetActive(true);
                    dialogText.text = dialog[currentDialog];
                    currentDialog++;
                }
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

    public string RetornaRespCerta(int N)
    {
        //if (this.CompareTag("Prob1"))
        if(N==1)
            return rta1;
        else
            return rta2;
    }
}
