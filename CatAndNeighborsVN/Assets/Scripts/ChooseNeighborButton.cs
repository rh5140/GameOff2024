using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
        // Turn the character color from grey to white - needed if selected is incorrect
        if (fashionDesigner.activeSelf) {
            fashionDesigner.GetComponentInChildren<Image>().color = Color.white;
        }
        if (vampireNurse.activeSelf) {
            vampireNurse.GetComponentInChildren<Image>().color = Color.white;
        }
        if (pitifulRobot != null & pitifulRobot.activeSelf) {
            pitifulRobot.GetComponentInChildren<Image>().color = Color.white;
        }

        NeighborCanvasParent parentCanva = GetComponentInParent<NeighborCanvasParent>();
        chosenNeighbor = parentCanva.chosenNeighbor;
        chosenNeighbor.SetActive(false);
        
        Debug.Log("OnClick");
        if (!dialogueRunner.IsDialogueRunning) {
            Debug.Log("Jump");
            JumpToNeighborDialogue(chosenNeighbor);
        }

        gameObject.SetActive(false);
        cancelButton.SetActive(false);
        neighborSelectionCanva.SetActive(false);
        chooseText.SetActive(false);
    }
}