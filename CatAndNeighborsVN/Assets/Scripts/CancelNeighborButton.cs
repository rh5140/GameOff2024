using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CancelNeighborButton : MonoBehaviour
{
    public GameObject chooseButton;

    public void Click() {
        NeighborCanvasParent parentCanva = GetComponentInParent<NeighborCanvasParent>();
        parentCanva.UnsetChosenNeighbor();

        parentCanva.transform.Find("Marie-Elle").gameObject.GetComponentInChildren<Image>().color = Color.white;
        parentCanva.transform.Find("Dorian").gameObject.GetComponentInChildren<Image>().color = Color.white;
        parentCanva.transform.Find("Fern").gameObject.GetComponentInChildren<Image>().color = Color.white;

        gameObject.SetActive(false);
        chooseButton.SetActive(false);
        GameObject.Find("ChosenNeighborName").SetActive(false);
    }
}