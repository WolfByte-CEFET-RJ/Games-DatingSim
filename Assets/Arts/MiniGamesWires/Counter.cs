using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Counter : MonoBehaviour
{
    static public Counter Instance;
    public int activeLightsCount = 0;
    public int wiresConnectedCount = 0;
    public Text messageText;
    public Text previousText;
    public Button ActiveButton;
    public int numTentativas= 10;
    public bool EndGame = false;
    public GameObject eletricidade;
    bool isAllWiresColliding = false;
    private RandomizeChildren randomizeChildren;

    private void Awake()
    {
        Instance = this;
        messageText.text = "Atualize e Veja a quantidade de fios Corretos ";
        previousText.text = string.Empty;
    }
    private void Start()
    {
        // Encontra o GameObject que possui o script RandomizeChildren
        GameObject randomizeChildrenObject = GameObject.Find("Left");

        if (randomizeChildrenObject != null)
        {
            // Obtém a referência ao script RandomizeChildren
            randomizeChildren = randomizeChildrenObject.GetComponent<RandomizeChildren>();
        }
        else
        {
            Debug.LogError("GameObject com RandomizeChildren não encontrado!");
        }
    }
    public void OnButtonClick()
    {
            // Chame o Coroutine para desativar o botão por 5 segundos
            StartCoroutine(DisableButtonForSeconds(ActiveButton));
    }

    public void CountActiveLights(int point)
    {
        activeLightsCount = activeLightsCount + point;
        Debug.Log("Número: " + activeLightsCount);
    }

    IEnumerator DisableButtonForSeconds(Button button)
    {
        // Desativa o botão
        button.interactable = false;

        if (isAllWiresColliding)
        {
            randomizeChildren.DisableWires();
            numTentativas--;
            StartCoroutine(BlinkCoroutine(eletricidade));
            // Aguarda 5 segundos
            yield return new WaitForSeconds(3f);

            SeeActiveLights();

            if (numTentativas > 0 && activeLightsCount != 4)
                // Reativa o botão
                button.interactable = true;
            randomizeChildren.EnableWires();
        }
        else
        {
            previousText.text = messageText.text;
            messageText.text = messageText.text + "\n\n Conecte todos os fios antes de tentar!";
            yield return new WaitForSeconds(2f);
            messageText.text = previousText.text;
            button.interactable = true;
        }

       
    }

    private IEnumerator BlinkCoroutine(GameObject image)
    {
        image.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        image.SetActive(false);

        yield return new WaitForSeconds(2f);


        Vector3 newRotation = image.transform.eulerAngles + new Vector3(0, 180f, 0);

        // Aplica a nova rotação ao objeto
        image.transform.eulerAngles = newRotation;
        image.SetActive(true);
        yield return new WaitForSeconds(0.03f);
        

        newRotation = image.transform.eulerAngles + new Vector3(0, 180f, 0);
        image.transform.eulerAngles = newRotation;
        yield return new WaitForSeconds(0.03f);
        newRotation = image.transform.eulerAngles + new Vector3(180f, 180f, 0);
        image.transform.eulerAngles = newRotation;
        yield return new WaitForSeconds(0.03f);
        newRotation = image.transform.eulerAngles + new Vector3(180f, 180f, 0);
        image.transform.eulerAngles = newRotation;

        yield return new WaitForSeconds(0.03f);
        image.SetActive(false);
    }


    public void SeeActiveLights()
    {
        
        Debug.Log("Número de Lights ativos: " + activeLightsCount);
        if (activeLightsCount == 4 && numTentativas >= 0)
        {
            messageText.text = "Fios Corretos: \n" + activeLightsCount.ToString() + "\n\n Você Conseguiu!!!";
            Main.Instance.ShowWinText();
            EndGame = true;
        }
        else if (activeLightsCount < 4 && numTentativas != 0)
        {
            messageText.text = "Fios Corretos: \n" + activeLightsCount.ToString() +"\n\nVocê ainda tem\n" + numTentativas + "\ntentativas";
        }
        else
        {
            messageText.text = "Suas tentativas acabaram! :( \n\n Você perdeu";
            EndGame = true;
        }
    }

    public void wiresConnected(int point)
    {
        wiresConnectedCount = wiresConnectedCount + point;
        if(wiresConnectedCount == 4)
        {
            isAllWiresColliding = true;
        }
        else
        {
            isAllWiresColliding = false;
        }
    }
}
