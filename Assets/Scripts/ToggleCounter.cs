using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToggleCounter : MonoBehaviour
{
    public Toggle setToggle;
    public TMP_InputField repsInput;
    public TMP_InputField weightInput;

    private bool ticked = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        setToggle.isOn = false;
    }

    void Start()
    {
        if (setToggle != null)
            setToggle.onValueChanged.AddListener(OnSetCompleted);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnSetCompleted(bool isOn)
    {
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
