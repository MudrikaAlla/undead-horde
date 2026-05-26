using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private float time = 0f;
    [SerializeField] private TextMeshProUGUI timeElement;

    void Update()
    {
        if (Time.timeScale > 0f)
        {
            time += Time.deltaTime;
            DisplayTime(time);
        }
    }

    void DisplayTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        timeElement.text = string.Format("Timer: {0:00}:{1:00}", minutes, seconds);
    }
}
