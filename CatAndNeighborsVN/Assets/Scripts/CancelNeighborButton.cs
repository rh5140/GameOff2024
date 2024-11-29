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

        // Make characters not greyed out
        fashionDesigner.GetComponent<Image>().color = Color.white;
        vampireNurse.GetComponent<Image>().color = Color.white;
        pitifulRobot.GetComponent<Image>().color = Color.white;

        gameObject.SetActive(false);
        chooseButton.SetActive(false);
        chooseNeighborNameText.SetActive(false);
    }
}