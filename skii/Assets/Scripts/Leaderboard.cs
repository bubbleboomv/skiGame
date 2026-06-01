using System;
using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class Leaderboard : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] entries; // 5 text fields

    private const int MaxEntries = 5;
    private const string KeyPrefix = "LeaderboardTime_";
    private const string KeyCount = "LeaderboardCount";

    private List<float> times = new List<float>();

    public static Leaderboard Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        LoadTimes();
    }

    private void LoadTimes()
    {
        times.Clear();
        int count = PlayerPrefs.GetInt(KeyCount, 0);
        for (int i = 0; i < count; i++)
        {
            times.Add(PlayerPrefs.GetFloat(KeyPrefix + i));
        }
    }

    public void AddTime(float time)
    {
        times.Add(time);
        times.Sort();
        if (times.Count > MaxEntries)
            times.RemoveRange(MaxEntries, times.Count - MaxEntries);

        SaveTimes();
        UpdateUI();
    }

    private void SaveTimes()
    {
        PlayerPrefs.SetInt(KeyCount, times.Count);
        for (int i = 0; i < times.Count; i++)
        {
            PlayerPrefs.SetFloat(KeyPrefix + i, times[i]);
        }
        PlayerPrefs.Save();
    }

    public void UpdateUI()
    {
        for (int i = 0; i < entries.Length; i++)
        {
            if (i < times.Count)
            {
                TimeSpan ts = TimeSpan.FromSeconds(times[i]);
                entries[i].text = (i + 1) + ". " + ts.ToString(@"mm\:ss\.ff");
            }
            else
            {
                entries[i].text = (i + 1) + ". ---";
            }
        }
    }
}