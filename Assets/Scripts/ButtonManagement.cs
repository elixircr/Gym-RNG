using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManagement : MonoBehaviour
{
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
        SceneManager.LoadScene(0);
    }
    public void LogScreen()
    {
        SceneManager.LoadScene(1);
    }
    public void InventoryScreen()
    {
        SceneManager.LoadScene(2);
    }
}
