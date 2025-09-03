using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToggleCounter : MonoBehaviour
{
    // variables
    public Toggle setToggle;
    public TMP_InputField repsInput;
    public TMP_InputField weightInput;

    private bool ticked = false;

    // before anything else runs, sets the toggle off
    private void Awake()
    {
        setToggle.isOn = false;
    }

    // adds a listener to the toggle
    void Start()
    {
        if (setToggle != null)
            setToggle.onValueChanged.AddListener(OnSetCompleted);
    }
    

    //  when toggle is triggered, function runs
    void OnSetCompleted(bool isOn)
    {
        // if both inputs are empty or null, do nothing; else, allows for the toggle to work
        if (isOn)
        {
            if (string.IsNullOrEmpty(repsInput.text) || string.IsNullOrEmpty(weightInput.text))
            {
                setToggle.isOn = false;
                Debug.Log("Input Numbers");
            }
            else
            {
                ticked = true;
                SpinManager.instance.AddCompletedSet();
            }
        }
        // if toggle is already on, turns it off
        else
        {
            if (ticked)
            {
                SpinManager.instance.RemoveCompletedSets();
                ticked = false;
            }
        }
    }
}
