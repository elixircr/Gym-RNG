using UnityEngine;
using TMPro;

public class AddSetManager : MonoBehaviour
{
    public Transform setParent;
    public GameObject set;
    public GameObject addSetButton;

    
    public void AddSet()
    {
        GameObject newSet = Instantiate(set, setParent, false);
        
        int buttonIndex = addSetButton.transform.GetSiblingIndex();
        newSet.transform.SetSiblingIndex(buttonIndex);
        
    }
}