using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDiary : MonoBehaviour
{
    public GameObject diaryUI;

    public void ToggleDiary()
    {
        bool isActive = diaryUI.activeSelf;
        diaryUI.SetActive(!isActive);
    }
}
