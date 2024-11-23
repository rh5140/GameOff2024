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
    public GameObject cancelButton;

    [SerializeField] private string correctNeighborStartNode;
    [SerializeField] private string otherNeighborOneStartNode;
    [SerializeField] private string noRepeatNode;

	private DialogueRunner dialogueRunner;
    private InMemoryVariableStorage variableStorage;

    public void Start() {
        dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();
        variableStorage = FindObjectOfType<Yarn.Unity.InMemoryVariableStorage>();
    }

    private void JumpToNeighborDialogue(GameObject neighbor) {
        if (neighbor == correctNeighbor) {
            variableStorage.SetValue("$incorrectFinished", true);
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
        cancelButton.SetActive(false);
        neighborSelectionCanva.SetActive(false);
    }
}