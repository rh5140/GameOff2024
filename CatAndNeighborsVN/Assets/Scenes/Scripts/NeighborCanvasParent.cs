using UnityEngine;
using UnityEngine.UI;

public class NeighborCanvasParent : MonoBehaviour
{
    public GameObject chosenNeighbor = null;
    
    public void SetChosenNeighbor(GameObject neighbor) {
        Debug.Log("CHOOSE");
        chosenNeighbor = neighbor;
    }

    public void UnsetChosenNeighbor() {
        chosenNeighbor = null;
    }
}