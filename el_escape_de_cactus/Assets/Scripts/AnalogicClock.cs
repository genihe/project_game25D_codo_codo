using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnalogicClock : MonoBehaviour
{
    public GameObject HourHand;
    public GameObject MinuteHand;
    public GameObject SecondHand;

    public int Hour;
    public int Minute;
    public int Second;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Hour=System.DateTime.Now.Hour;
        Minute=System.DateTime.Now.Minute;
        Second=System.DateTime.Now.Second;
        Clockhands_manager();
    }

    void Clockhands_manager(){
        SecondHand.transform.eulerAngles=new Vector3(0,0,-(Second*6));
        MinuteHand.transform.eulerAngles=new Vector3(0,0,-(Minute*6));
        HourHand.transform.eulerAngles=new Vector3(0,0,-(Hour*30)-(Minute/2));
    }
}
