using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue Option", menuName ="DialogueOptions")]
public class options : MonoBehaviour
{
    [System.Serializable]
    public class Options{
        public string buttonname;
    }

    public options[] optionsinfo;

}
