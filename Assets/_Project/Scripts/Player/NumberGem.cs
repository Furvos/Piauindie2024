using UnityEngine;

public class NumberGem : MonoBehaviour, IInteractable
{
    public void Interact(){
        Debug.Log(Random.Range(0, 100));
    }
}
