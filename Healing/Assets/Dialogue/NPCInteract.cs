using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class NPCInteract : MonoBehaviour
{
    private DialogueRunner dialogueRunner;
    private MeshRenderer textRender;

    public bool isTalking;
    // Start is called before the first frame update
    public void Start()
    {
        dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();
        dialogueRunner.onDialogueComplete.AddListener(EndConversation);
        textRender = GetComponentInChildren<MeshRenderer>();

    }

    public string conversationStartNode;
    // Update is called once per frame
    void Update()
    {
        if(interactable && !dialogueRunner.IsDialogueRunning && Input.GetKeyDown(KeyCode.E))
        {
            StartConversation();
        }
    }

    private bool isCurrentConversation;

    private void StartConversation()
    {
        isTalking = true;
        isCurrentConversation= true;
        dialogueRunner.StartDialogue(conversationStartNode);
    }

    private void EndConversation()
    {
        if(isCurrentConversation)
        {
            // Stop talking animation
            isCurrentConversation = false;
            isTalking = false;
        }
    }

    private bool interactable = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            interactable = true;
            textRender.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            interactable = false;
            textRender.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
