using System;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private DateTime raceStart;
    private TimeSpan raceTime;
    private TimeSpan penaltyTime;
    private bool racing = false;
    public delegate void TimerEvent();

    [SerializeField] private TextMeshProUGUI timerText;

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        StartGate.StartRace += OnRaceStart;
        FinishGate.FinishRace += OnRaceFinish;
    }

    private void OnDisable()
    {
        StartGate.StartRace -= OnRaceStart;
        FinishGate.FinishRace -= OnRaceFinish;
    }

    void OnRaceStart()
    {
        racing = true;
        penaltyTime = TimeSpan.Zero;
        raceStart = DateTime.Now;
        Debug.Log("race started");
    }

    void OnRaceFinish()
    {
        racing = false;
        TimeSpan total = raceTime + penaltyTime;
        string timeString = total.ToString(@"mm\:ss\.ff");
        Debug.Log("Race finished! Total time: " + timeString);
        EndScreen.Instance.ShowEndScreen(timeString, (float)total.TotalSeconds);
    }

    public void AddPenalty()
    {
        penaltyTime += TimeSpan.FromSeconds(1);
        Debug.Log("Penalty! Total penalty: " + penaltyTime.TotalSeconds + "s");
    }

    private void Update()
    {
        if (racing)
        {
            raceTime = DateTime.Now - raceStart;
            TimeSpan total = raceTime + penaltyTime;
            timerText.text = total.ToString(@"mm\:ss\.ff");
        }
    }
}