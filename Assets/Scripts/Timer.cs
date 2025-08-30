using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;
    private float timePast = 0f;
    public bool running = false;

    void Update()
    {
        if (!running) 
            return;

        timePast += Time.deltaTime;

        int minutes = (int)(timePast / 60);
        int seconds = (int)(timePast % 60);

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