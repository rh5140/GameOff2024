using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CancelNeighborButton : MonoBehaviour
{
    public GameObject chooseButton;
    public GameObject chooseNeighborNameText;

    public GameObject fashionDesigner;
    public GameObject vampireNurse;
    public GameObject pitifulRobot;

    public void Click() {
        NeighborCanvasParent parentCanva = GetComponentInParent<NeighborCanvasParent>();
        parentCanva.UnsetChosenNeighbor();

        fashionDesigner.GetComponent<NeighborSelect>().clickable = true;
        vampireNurse.GetComponent<NeighborSelect>().clickable = true;
        pitifulRobot.GetComponent<NeighborSelect>().clickable = true;

        gameObject.SetActive(false);
        chooseButton.SetActive(false);
        chooseNeighborNameText.SetActive(false);
    }
}