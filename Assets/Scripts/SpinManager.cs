using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine;

public class SpinManager : MonoBehaviour
{
    public static SpinManager instance;
    
    public int spinsLeft = 3;
    
    public GameObject resultPanel;
    public GameObject FinishPanel;

    public TMP_Text spinsText;
    public TMP_Text resultText;
    public TMP_Text setResultText;
    
    public Transform invPanelParent;

    public List<GameObject> commonPrefabs; 
    public List<GameObject> rarePrefabs; 
    public List<GameObject> epicPrefabs; 
    public List<GameObject> legendaryPrefabs; 
    public List<GameObject> mythicPrefabs;

    public int completedSets = 0;


    void Awake()
    {
        instance = this;
    }
    
    void Start()
    {
        resultPanel.SetActive(false);
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
        
        if (prefabToAdd != null)
            StartCoroutine(ShowResult(prefabToAdd.name));
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
    
    private IEnumerator ShowResult(string itemName)
    {
        resultPanel.SetActive(true);
        resultText.text = "You got: " + itemName;

        yield return new WaitForSeconds(2f);

        resultPanel.SetActive(false);
    }

    public void AddCompletedSet()
    {
        completedSets++;
    }

    public void RemoveCompletedSets()
    {
        completedSets--;
    }

    public void FinishedWorkoutSpins()
    {
        spinsLeft += completedSets;
        UpdateUI();
        StartCoroutine(FinishWorkout());
        completedSets = 0;
    }

    private IEnumerator FinishWorkout()
    {
        FinishPanel.SetActive(true);
        setResultText.text = "You have finished: " + completedSets + " sets!";

        yield return new WaitForSeconds(2f);
        
        FinishPanel.SetActive(false);
    }
}
