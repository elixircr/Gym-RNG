using UnityEngine;

public class LogCanvas : MonoBehaviour
{
    public GameObject mainLogScreenCanvas;
    public GameObject exerciseSelectionCanvas;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LogScreenCanvas ()
    {
        mainLogScreenCanvas.SetActive(true);
        exerciseSelectionCanvas.SetActive(false);
    }
    
    public void ExerciseSelectionCanvas()
    {
        exerciseSelectionCanvas.SetActive(true);
        mainLogScreenCanvas.SetActive(false);
    }
}
