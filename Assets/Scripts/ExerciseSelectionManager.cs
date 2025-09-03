using System.Timers;
using UnityEngine;
using TMPro;

public class ExerciseSelectionManager : MonoBehaviour
{
    // variables
    public GameObject mainLogScreen;
    public GameObject exerciseSelectionScreen;
    public Transform logContentParent;
    public GameObject exerciseEntryPrefab;
    public GameObject addExerciseButton;

    public Timer timerScript;

    // function that gets called when the exercise is selected; exercise name is chosen in the inspector panel
    public void SelectExercise(string exerciseName)
    {
        GameObject entry = Instantiate(exerciseEntryPrefab, logContentParent, false);
        
        int buttonIndex = addExerciseButton.transform.GetSiblingIndex();
        entry.transform.SetSiblingIndex(buttonIndex);
        
        TMP_Text textComponent = entry.GetComponentInChildren<TMP_Text>();
        if (textComponent != null)
        {
            textComponent.text = exerciseName;
        }
        
        mainLogScreen.SetActive(true);
        exerciseSelectionScreen.SetActive(false);
    }

    // update function
    void Update()
    {
        if (timerScript.running == false)
        {
            Destroy(exerciseEntryPrefab);
        }
    }
}