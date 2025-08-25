using TMPro;
using UnityEngine;

public class SimpleTimer : MonoBehaviour
{
    public TMP_Text timerText;
    private float timePast = 0f;
    private bool running = false;

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
        if (timerText != null)
            timerText.gameObject.SetActive(true); // show text when timer starts
    }

    public void StopTimer()
    {
        running = false;
    }
}