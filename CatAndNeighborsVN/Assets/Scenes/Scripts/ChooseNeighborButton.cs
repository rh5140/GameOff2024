using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class ChooseNeighborButton : MonoBehaviour
{
    public GameObject neighborSelectionCanva;
    public GameObject correctNeighbor;
    public GameObject chosenNeighbor;
    public GameObject otherNeighborOne;

    [SerializeField] private string correctNeighborStartNode;
    [SerializeField] private string otherNeighborOneStartNode;

	private DialogueRunner dialogueRunner;

    public void Start() {
        dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();
    }

    private void JumpToNeighborDialogue(GameObject neighbor) {
        if (neighbor == correctNeighbor) {
            dialogueRunner.StartDialogue(correctNeighborStartNode);
        }
        if (neighbor == otherNeighborOne) {
            dialogueRunner.StartDialogue(otherNeighborOneStartNode);
        }
        
    }

    public void Click() {
        NeighborCanvasParent parentCanva = GetComponentInParent<NeighborCanvasParent>();
        chosenNeighbor = parentCanva.chosenNeighbor;

        if (!dialogueRunner.IsDialogueRunning) {
            JumpToNeighborDialogue(chosenNeighbor);
        }

        gameObject.SetActive(false);
        neighborSelectionCanva.SetActive(false);
    }
}