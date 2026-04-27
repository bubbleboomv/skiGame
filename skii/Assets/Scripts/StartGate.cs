using System;
using UnityEngine;

public class StartGate : MonoBehaviour
{
    public static event GameManager.TimerEvent StartRace;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
            {
            StartRace.Invoke();
            }
    }
}
