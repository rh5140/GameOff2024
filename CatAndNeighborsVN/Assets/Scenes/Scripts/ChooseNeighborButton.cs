using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class ChooseNeighborButton : MonoBehaviour
{
    public GameObject neighborSelectionCanva;
    public GameObject correctNeighbor;
    public GameObject chosenNeighbor;
    public GameObject incorrectNeighborOne;
    public GameObject incorrectNeighborTwo;
    public GameObject cancelButton;
    public GameObject chooseText;

    [SerializeField] private string correctStartNode;
    [SerializeField] private string incorrectOneStartNode;
    [SerializeField] private string incorrectTwoStartNode;

	private DialogueRunner dialogueRunner;

    public void Start() {
        dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();
    }

    private void JumpToNeighborDialogue(GameObject neighbor) {
        if (neighbor == correctNeighbor) {
            dialogueRunner.StartDialogue(correctStartNode);
        }
        if (neighbor == incorrectNeighborOne) {
            dialogueRunner.StartDialogue(incorrectOneStartNode);
        }
        if (neighbor == incorrectNeighborTwo) {
            dialogueRunner.StartDialogue(incorrectTwoStartNode);
        }
    }

    public void Click() {
        NeighborCanvasParent parentCanva = GetComponentInParent<NeighborCanvasParent>();
        chosenNeighbor = parentCanva.chosenNeighbor;

        // switching out portraits to grayscale version after selecting
        chosenNeighbor.transform.Find(chosenNeighbor.name).gameObject.SetActive(false);
        chosenNeighbor.transform.Find("Gray" + chosenNeighbor.name).gameObject.SetActive(true);
        chosenNeighbor.transform.Find(chosenNeighbor.name + "Name").gameObject.SetActive(false);
        chosenNeighbor.transform.Find("Inaccessible").gameObject.SetActive(true);

        if (!dialogueRunner.IsDialogueRunning) {
            JumpToNeighborDialogue(chosenNeighbor);
        }

        gameObject.SetActive(false);
        cancelButton.SetActive(false);
        neighborSelectionCanva.SetActive(false);
        chooseText.SetActive(false);
    }
}