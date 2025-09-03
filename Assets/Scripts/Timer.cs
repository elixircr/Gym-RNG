using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;
    private float timePast = 0f;
    public bool running = false;
    
    // update function; runs every frame
    void Update()
    {
        if (!running) 
            return;

        // timer adds a second every second
        timePast += Time.deltaTime;

        int minutes = (int)(timePast / 60);
        int seconds = (int)(timePast % 60);

        // converts this to readable time (got this from google)
        if (timerText != null)
            timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }

    public void StartTimer()
    {
        if (running)
            return;
        timePast = 0f;
        running = true;
    }

    public void StopTimer()
    {
        running = false;
        SpinManager.instance.FinishedWorkoutSpins();
    }
}