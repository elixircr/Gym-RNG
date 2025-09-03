using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManagement : MonoBehaviour
{
    // variables
    public GameObject homeScreen;
    public GameObject logScreen;
    public GameObject invScreen;
    
    // functions that turns on home screen, etc
    
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