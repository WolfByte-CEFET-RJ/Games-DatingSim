using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InfoOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public CanvasGroup info;
    private bool fadeIn = false;
    private bool fadeOut = false;

    void Awake()
    {
        info.alpha = 0;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        fadeOut = false;
        fadeIn = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        fadeIn = false;
        fadeOut = true;
    }

    void Update()
    {
        if (fadeIn)
        {
            info.alpha += Time.deltaTime * 4;

            if (info.alpha >= 1)
                fadeIn = false;
        }
        else if (fadeOut)
        {
            info.alpha -= Time.deltaTime * 4;
            
            if (info.alpha <= 0)
                fadeOut = false;
        }
    }
}