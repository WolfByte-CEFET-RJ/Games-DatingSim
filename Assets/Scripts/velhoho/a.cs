using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class a : MonoBehaviour
{

    public TextCreator dialogmanager;
    public TextMeshProUGUI dialogtext;
    public TextMeshProUGUI textname2;
    public Image dialogimage;

    public Button next, previous;
    public float typingSpeed = 0.05f;
    

    void Button()
    {
        Showdialog(dialogmanager.GetCurrentDialog());
        next.onClick.AddListener(Onnextbuttonclick);
        previous.onClick.AddListener(Onbackbuttonclick);
        UpdateButtonState();
    }

    private void Showdialog(Dialog dialog){

        if (dialog != null){
            StopAllCoroutines();
            StartCoroutine(TypeText(dialog.text));
            dialogimage.sprite = dialog.image;
            textname2.text = dialog.textname;
        }
        else{
            Debug.Log("no found dialog");
        }

    }

    private IEnumerator TypeText(string text)
    {
        dialogtext.text = "";
        foreach (char letter in text.ToCharArray()){
            dialogtext.text += letter;
            yield return new WaitForSeconds(typingSpeed);

        }
    }

    private void UpdateButtonState(){
        next.interactable = dialogmanager.CanMoveNext();
        previous.interactable = dialogmanager.CanMoveNext();
    }

    private void Onnextbuttonclick(){
        if (dialogmanager.MoveNext()){
            Showdialog(dialogmanager.GetCurrentDialog());

        }
        UpdateButtonState();
    }

    private void Onbackbuttonclick(){
        if (dialogmanager.MovePrevious()){
            Showdialog(dialogmanager.GetCurrentDialog());

        }
        UpdateButtonState();
    }

}
