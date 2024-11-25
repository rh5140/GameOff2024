using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class ChooseNeighborButton : MonoBehaviour
{
    [Header("Set up neighbor selection UI")]
    [SerializeField] private GameObject neighborSelectionCanva;
    [SerializeField] private GameObject cancelButton;
    [SerializeField] private GameObject chooseText;
    [SerializeField] private GameObject fashionDesigner;
    [SerializeField] private GameObject vampireNurse;
    [SerializeField] private GameObject pitifulRobot;

    [Header("Set up dialogue nodes")]
    [SerializeField] private string fashionDesignerNode;
    [SerializeField] private string vampireNurseNode;
    [SerializeField] private string pitifulRobotNode;
    
    private GameObject chosenNeighbor;

	private DialogueRunner dialogueRunner;

    public void Start() {
        dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();
    }

    private void JumpToNeighborDialogue(GameObject neighbor) {
        if (neighbor == fashionDesigner) {
            dialogueRunner.StartDialogue(fashionDesignerNode);
        }
        else if (neighbor == vampireNurse) {
            dialogueRunner.StartDialogue(vampireNurseNode);
        }
        else if (neighbor == pitifulRobot) {
            dialogueRunner.StartDialogue(pitifulRobotNode);
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