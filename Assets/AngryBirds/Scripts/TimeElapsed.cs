using System;
using UnityEngine;

public class TimeElapsed : MonoBehaviour
{
    TMPro.TextMeshProUGUI clock;
    private float gameTime;
    
    void Start()
    {
        clock = GetComponent<TMPro.TextMeshProUGUI>();
        gameTime = 0f;
    }

    void Update()
    {
        gameTime += Time.deltaTime;

        TimeSpan timeSpan = TimeSpan.FromSeconds(gameTime);
        clock.text = string.Format("{0:D2}:{1:D2}:{2:D2}.{3}",
            timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds / 100);
    }
}
