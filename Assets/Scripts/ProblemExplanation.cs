using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProblemExplanation : MonoBehaviour
{

    public GameObject dialogBox;
    public Text dialogText;
    public string[] dialog;
    private int currentDialog;
    public bool playerInRange;
    public bool formal;
    public int initFormal;

    // Start is called before the first frame update
    void Start()
    {
        formal = false;
        currentDialog = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && formal == false)
        {
            formal = true;
            currentDialog = initFormal;
        }
            
        else if (Input.GetKeyDown(KeyCode.F) && formal == true)
        {
            formal = false;
            currentDialog = 0;
        }
            

        if (Input.GetKeyDown(KeyCode.Space) && playerInRange && formal==true)
        {
            if (dialogBox.activeInHierarchy && currentDialog == dialog.Length)
            {
                dialogBox.SetActive(false);
                currentDialog = initFormal;
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

        if(Input.GetKeyDown(KeyCode.Space) && playerInRange && formal == false)
        {
            if (dialogBox.activeInHierarchy && currentDialog == initFormal)
            {
                dialogBox.SetActive(false);
                currentDialog = 0;
            }
            else
            {
                if (currentDialog < initFormal)
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
}
