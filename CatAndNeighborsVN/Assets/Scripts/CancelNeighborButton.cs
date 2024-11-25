using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelNeighborButton : MonoBehaviour
{
    public GameObject chooseButton;

    public void Click() {
        NeighborCanvasParent parentCanva = GetComponentInParent<NeighborCanvasParent>();
        parentCanva.UnsetChosenNeighbor();

        gameObject.SetActive(false);
        chooseButton.SetActive(false);
    }
}