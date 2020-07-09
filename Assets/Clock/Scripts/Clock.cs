using UnityEngine;
using System.Collections;

public class Clock : MonoBehaviour
{

    //-- set start time 00:00
    public float minutes = 0;
    public int hour = 0;
    public int seconds = 0;
    public bool realTime = true;

    public GameObject pointerSeconds;
    public GameObject pointerMinutes;
    public GameObject pointerHours;
    public float realMinutes;
    //-- time speed factor
    public float clockSpeed = 1.0f;     // 1.0f = realtime, < 1.0f = slower, > 1.0f = faster

    //-- internal vars
    float msecs = 0;

    void Start()
    {
        //-- set real time
        if (realTime)
        {

            seconds = System.DateTime.Now.Second;
        }
        hour = 4;
        minutes = 30;
        realMinutes = hour * 60 + minutes;
    }

    void Update()
    {


        minutes += clockSpeed * Time.deltaTime;
        realMinutes += clockSpeed * Time.deltaTime; 
        if (minutes > 60)
        {
            minutes = 0;
            hour++;
            if (hour >= 24)
            {
                hour = 0;
                realMinutes = 0;
            }
        }

        //-- calculate pointer angles
        float rotationMinutes = (360.0f / 60.0f) * minutes;
        float rotationHours = ((360.0f / 12.0f) * hour) + ((360.0f / (60.0f * 12.0f)) * minutes);

        //-- draw pointers
        pointerMinutes.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationMinutes);
        pointerHours.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationHours);

    }
}