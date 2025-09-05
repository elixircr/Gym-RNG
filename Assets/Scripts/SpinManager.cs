using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine;

public class SpinManager : MonoBehaviour
{
    // variables
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

    public string rarity;

    public int completedSets = 0;


    // before anything else runs, creates instance of this script to prevent any bugs;
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        resultPanel.SetActive(false);
        UpdateUI();
    }

    // function that handels spins
    public void Spin()
    {
        if (spinsLeft <= 0)
        {
            Debug.Log("No spins");
            return;
        }

        spinsLeft--;

        GameObject prefabToAdd = null; // resets back to empty;
        rarity = null;

        int number = Random.Range(1, 1000);
        Debug.Log(number);
        if (number <= 2)
        {
            Debug.Log("Mythic!"); // 0.2%
            prefabToAdd = mythicPrefabs[Random.Range(0, mythicPrefabs.Count)];
            rarity = "Mythic";
        }
        else if (number <= 10)
        {
            Debug.Log("Legendary!"); // 0.8%
            prefabToAdd = legendaryPrefabs[Random.Range(0, legendaryPrefabs.Count)];
            rarity = "Legendary";
        }
        else if (number <= 100)
        {
            Debug.Log("Epic!"); //~10%
            prefabToAdd = epicPrefabs[Random.Range(0, epicPrefabs.Count)];
            rarity = "Epic";
        }
        else if (number <= 500)
        {
            Debug.Log("Rare!"); //40%
            prefabToAdd = rarePrefabs[Random.Range(0, rarePrefabs.Count)];
            rarity = "Rare";
        }
        else
        {
            Debug.Log("Common");
            prefabToAdd = commonPrefabs[Random.Range(0, commonPrefabs.Count)];
            rarity = "Common";
        }

        AddToInv(prefabToAdd);
        UpdateUI();

        if (prefabToAdd != null)
            StartCoroutine(ShowResult(prefabToAdd.name));
    }

    // adds won item to inv
    void AddToInv(GameObject prefab)
    {
        if (prefab != null)
            Instantiate(prefab, invPanelParent, false);
    }

    // function that updates text
    private void UpdateUI()
    {
        spinsText.text = "Spins left: " + spinsLeft.ToString();
    }

    // ienumerator for timed popups
    private IEnumerator ShowResult(string itemName)
    {
        resultPanel.SetActive(true);
        resultText.text = rarity + "!" + "\nYou got: " + itemName;

        yield return new WaitForSeconds(2f);

        resultPanel.SetActive(false);
    }

    // functions that gets called by ToggleCounter.cs;
    public void AddCompletedSet()
    {
        completedSets++;
    }

    public void RemoveCompletedSets()
    {
        completedSets--;
    }

    // funtion that gets called when finsihed
    public void FinishedWorkoutSpins()
    {
        spinsLeft += completedSets;
        UpdateUI();
        StartCoroutine(FinishWorkout());
        completedSets = 0;

    }

    // timed screen
    private IEnumerator FinishWorkout()
    {
        FinishPanel.SetActive(true);
        setResultText.text = "You have finished: " + completedSets + " sets!";

        yield return new WaitForSeconds(2f);

        FinishPanel.SetActive(false);
    }
}