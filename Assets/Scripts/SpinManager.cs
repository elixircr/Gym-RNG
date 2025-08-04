using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpinManager : MonoBehaviour
{
    public int spinsLeft = 3;

    public TMP_Text spinsText;
    
    public Transform invPanelParent;

    public List<GameObject> commonPrefabs; 
    public List<GameObject> rarePrefabs; 
    public List<GameObject> epicPrefabs; 
    public List<GameObject> legendaryPrefabs; 
    public List<GameObject> mythicPrefabs;

    void Start()
    {
        UpdateUI();
    }
    
    public void Spin()
    {
        if (spinsLeft <= 0)
        {
            Debug.Log("No spins");
            return;
        }
        
        spinsLeft--;
        
        GameObject prefabToAdd = null; // resets back to empty;
        
        int number = Random.Range(1, 1000);
        Debug.Log(number);
        if (number <= 2) 
        {
            Debug.Log("Mythic!"); // 0.2%
            prefabToAdd = mythicPrefabs[Random.Range(0, mythicPrefabs.Count)];
        }else if (number <= 10)
        {
            Debug.Log("Legendary!"); // 0.8%
            prefabToAdd =  legendaryPrefabs[Random.Range(0, legendaryPrefabs.Count)];
        } else if (number <= 100)
        {
            Debug.Log("Epic!");  //~10%
            prefabToAdd = epicPrefabs[Random.Range(0, epicPrefabs.Count)];
        } else if (number <= 500)
        {
            Debug.Log("Rare!"); //40%
            prefabToAdd =  rarePrefabs[Random.Range(0, rarePrefabs.Count)];
        }
        else
        {
            Debug.Log("Common");
            prefabToAdd =  commonPrefabs[Random.Range(0, commonPrefabs.Count)];
        }
        
        AddToInv(prefabToAdd);
        UpdateUI();
    }

    void AddToInv(GameObject prefab)
    {
        if (prefab != null)
            Instantiate(prefab, invPanelParent, false);
    }
    
    private void UpdateUI()
    {
        spinsText.text = "Spins left: " + spinsLeft.ToString();
    }
}
