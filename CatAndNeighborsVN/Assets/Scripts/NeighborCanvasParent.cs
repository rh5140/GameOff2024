using UnityEngine;
using UnityEngine.UI;

public class NeighborCanvasParent : MonoBehaviour
{
    public GameObject chosenNeighbor = null;
    
    public void SetChosenNeighbor(GameObject neighbor) {
        Debug.Log("CHOOSE " + neighbor);
        chosenNeighbor = neighbor;
    }

    public void UnsetChosenNeighbor() {
        Debug.Log("NO CHOOSE");
        chosenNeighbor = null;
    }
}