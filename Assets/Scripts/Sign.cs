using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{

    public GameObject dialogBox;
    public Text dialogText;
    public string[] dialog;
    private int currentDialog;
    public bool playerInRange;

    // Start is called before the first frame update
    void Start()
    {
        currentDialog = 0;
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
}
