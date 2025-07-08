using UnityEngine;
using TMPro;

public class ExerciseSelectionManager : MonoBehaviour
{
    public GameObject mainLogScreen;
    public GameObject exerciseSelectionScreen;
    public Transform logContentParent;
    public GameObject exerciseEntryPrefab;
    public GameObject addExerciseButton;

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
}