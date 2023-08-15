using MAGES.OperationAnalytics;
using UnityEngine;
using UnityEngine.UI;

public class UIClock : MonoBehaviour
{
    private Text TextTimer;
    int seconds = 0;
    int minutes = 0;

    void Start()
    {
        TextTimer = GetComponent<Text>();
        
    }

    void Update()
    {

        seconds = UserPathTracer.Get.GetSecondsFromStart();
        minutes = UserPathTracer.Get.GetMinutesFromStart();

        SetTimeText();
    }

    void SetTimeText()
    {
        if (minutes < 10)
        {
            TextTimer.text = "0" + minutes + ":";
        }
        else
        {
            TextTimer.text = minutes + ":";
        }
        if (seconds < 10)
        {
            TextTimer.text += "0" + seconds;
        }
        else
        {
            TextTimer.text += seconds;
        }
    }
}

