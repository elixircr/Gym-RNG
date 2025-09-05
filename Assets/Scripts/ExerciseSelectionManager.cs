using System.Net;
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

    // runs every time it is enabled
    void OnEnable()
    {
        if (Timer.instance.running == true)
        {
            Debug.Log("Still running");
            return;
        }
        // for loop
        for (int i = logContentParent.childCount - 1; i >= 0; i--)
        {
            // resets log 
            Transform child = logContentParent.GetChild(i);
            Debug.Log(child.tag);
            if (child.CompareTag("Exercise"))
                Destroy(child.gameObject);
        }
    }

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
}