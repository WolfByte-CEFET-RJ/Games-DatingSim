using UnityEngine;
using UnityEngine.EventSystems;

public class SFXmouse : MonoBehaviour, IPointerUpHandler
{
    // Método chamado quando o mouse é solto sobre o GameObject
    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("O mouse foi solto!");
        // Reproduza o som aqui ou adicione a lógica desejada
        AudioManager.Instance.PlaySFX("mouseclick");
    }
}
