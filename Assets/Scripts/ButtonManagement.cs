using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManagement : MonoBehaviour
{
    public GameObject homeScreen;
    public GameObject logScreen;
    public GameObject invScreen;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void HomeScreen()
    {
        homeScreen.SetActive(true);
        logScreen.SetActive(false);
        invScreen.SetActive(false);
    }
    public void LogScreen()
    {
        logScreen.SetActive(true);
        invScreen.SetActive(false);
        homeScreen.SetActive(false);
    }
    public void InventoryScreen()
    {
        invScreen.SetActive(true);
        homeScreen.SetActive(false);
        logScreen.SetActive(false);
    }
}
