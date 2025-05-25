using System.Collections;
using System.Collections.Generic;
using UnityEngine;  
using TMPro;

[System.Serializable]
public class Dialog
{
    public string text;
    public string textname; ////////tratados da mesma forma
    public Sprite image; ///////
    public Question choicebox;

    
}

public class TextCreator : MonoBehaviour
{
    public Dialog[] dialogs;
    private int currentIndex = 0;



    public Dialog GetCurrentDialog()
    {
        if (currentIndex >= 0 && currentIndex < dialogs.Length)
        {
            return dialogs[currentIndex];
        }
        return null;
    }

    public void SetDialogueIndex(int index){
        this.currentIndex = index;
    }

    public bool MoveNext(){
        if (currentIndex < dialogs.Length - 1)
        {
            currentIndex++;
            return true;
        
        }
        return false;
    }

    public bool MovePrevious(){
        if (currentIndex>0){
            currentIndex--;
            return true;
        }
        return false;
    }

    public bool CanMoveNext(){
        return currentIndex < dialogs.Length - 1;
    }

    public bool CanMovePrevious(){
        return currentIndex > 0;

    }

}