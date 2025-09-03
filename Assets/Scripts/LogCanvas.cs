using UnityEngine;

public class LogCanvas : MonoBehaviour
{
    
    public GameObject mainLogScreenCanvas;
    public GameObject exerciseSelectionCanvas;

    // similar to buttonmanagement, turns on respective canvas'
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
