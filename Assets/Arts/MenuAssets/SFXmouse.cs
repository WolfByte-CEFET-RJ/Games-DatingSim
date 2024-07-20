using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXmouse : MonoBehaviour
{
    private void OnMouseUp()
    {
        AudioManager.Instance.PlaySFX("mouseclick");
    }
}

