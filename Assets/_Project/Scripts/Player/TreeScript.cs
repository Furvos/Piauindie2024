using UnityEditor.IMGUI.Controls;
using UnityEngine;

public class TreeScript : MonoBehaviour, IInteractable
{
    public GameObject seed;
    public GameObject sapling;
    public GameObject adultTree;
    int growth = 1;
    int maxGrowth = 5;

    public enum TreeState
    {
        Seed, Sapling, AdultTree
    }


    public void Interact()
    {
        growth++;
        Debug.Log(growth);
        if(growth >= maxGrowth)
        {
            SwitchState(TreeState.AdultTree);
        }
        if (growth >= maxGrowth)
        {
            growth = 5;
        }
    }

    void SwitchState(TreeState stateToSwitch)
    {

    }
}
