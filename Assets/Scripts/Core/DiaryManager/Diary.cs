using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Diary : MonoBehaviour
{
    public Text diaryText;
    private List<string> entries = new List<string>();

    public void AddEntry(string entry)
    {
        entries.Add(entry);
    }

    public void UpdateDiaryUI()
    {
        diaryText.text = string.Join("\n\n", entries);
    }
}