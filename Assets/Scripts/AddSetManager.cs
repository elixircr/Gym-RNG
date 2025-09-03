using UnityEngine;
using TMPro;

public class AddSetManager : MonoBehaviour
{
    // variables
    public Transform setParent;
    public GameObject set;
    public GameObject addSetButton;

    // AddSet function that can be called by the add set button
    public void AddSet()
    {
        // sets new GameObject var as 'newSet' then creates a copy of the original set prefab
        GameObject newSet = Instantiate(set, setParent, false);
        
        // code needed so the new set always goes to the bottom
        int buttonIndex = addSetButton.transform.GetSiblingIndex();
        newSet.transform.SetSiblingIndex(buttonIndex);
        
    }
}