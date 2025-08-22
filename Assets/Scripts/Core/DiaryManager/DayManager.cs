using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayManager : MonoBehaviour
{
    public Diary diary;
    private List<string> dayEvents = new List<string>();

    public static DayManager Instance { get; private set; }

    public void RecordEvent(string eventDescription)
    {
        dayEvents.Add(eventDescription);
    }

    public void EndDay(int day)
    {
        string dailySummary = string.Join("\n", dayEvents);
        diary.AddEntry("Dia " + day + ":\n" + dailySummary);
        diary.UpdateDiaryUI();
        dayEvents.Clear();
    }
}