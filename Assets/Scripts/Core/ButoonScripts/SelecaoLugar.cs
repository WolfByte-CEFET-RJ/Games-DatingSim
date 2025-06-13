using UnityEngine;
using UnityEngine.UI;

public class SelecaoLugar : MonoBehaviour
{
    [SerializeField] private Button b1, b2, b3, b4;
    public static char selec = 'N';

    private void Awake()
    {
        b1.onClick.AddListener(() => Selecionar('F'));
        b2.onClick.AddListener(() => Selecionar('M'));
        b3.onClick.AddListener(() => Selecionar('S'));
        b4.onClick.AddListener(() => Selecionar('P'));
    }

    private void Selecionar(char lugar)
    {
        selec = lugar;
        // Aqui você pode colocar a lógica para fechar a seleção e continuar o fluxo,
        // mas como pediu só para seleção, deixei só o set da variável.
        // Exemplo:
        // gameObject.SetActive(false);
    }
}
