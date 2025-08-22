using UnityEngine;
using System.Collections.Generic;

public class Entries : MonoBehaviour
{
    public Dictionary<string, string> falas = new Dictionary<string, string>()
    {
        {"CONHECEU_BYTE_M", "Hoje eu conheci o Byte M"},
        {"CONHECEU_BYTE_F", "Hoje eu conheci a Byte F"}
    };

    public string GetEntry(string key)
    {
        if (falas.ContainsKey(key))
        {
            return falas[key];
        }
        else
        {
            return "";
        }
    }
}