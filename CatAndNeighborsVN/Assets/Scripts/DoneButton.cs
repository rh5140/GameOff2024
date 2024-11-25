using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class DoneButton : MonoBehaviour
{
    public GameObject itemInteractionCanva;

    // internal properties exposed to editor
    [SerializeField] private string conversationStartNode;

	private DialogueRunner dialogueRunner;

    public void Start() {
        dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();
    }

    private void JumpToCharacterSelect() {
        dialogueRunner.StartDialogue(conversationStartNode);
    }

    public void Click() {
        // if no conversation is already running
        if (!dialogueRunner.IsDialogueRunning) {
            // then jump to character selection node
            JumpToCharacterSelect();
        }


        gameObject.SetActive(false);
        itemInteractionCanva.SetActive(false);
    }
}
