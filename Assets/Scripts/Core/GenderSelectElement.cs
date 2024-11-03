using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GenderSelectElement : MonoBehaviour
{
    public Button maleButton;
    public Button femaleButton;
    public Button confirmButton;

    public UnityEvent<string> OnGenderSelected;

    public GameObject maleDialogueBox;
    public GameObject femaleDialogueBox;

    public GameObject nameInput; // Referência à interface do seletor de nome

    public GameObject player; // Referencia ao GameObject do jogador

    public Sprite maleSprite; // Sprite para personagem masculino
    public Sprite femaleSprite; // Sprite para personagem feminino

    private string selectedGender;
    private bool genderSelected = false;

    private void Start()
    {
        // Adiciona listeners aos botões
        maleButton.onClick.AddListener(() => SelectGender("Male"));
        femaleButton.onClick.AddListener(() => SelectGender("Female"));
        confirmButton.onClick.AddListener(ConfirmGender);

        // Carrega sprites para personagem feminino e masculino
        maleSprite = Resources.Load<Sprite>("MaleSprite"); // Ajusta o caminho para a localização do Sprite
        femaleSprite = Resources.Load<Sprite>("FemaleSprite"); // Ajusta o caminho para a localização do Sprite
    }
    private void SelectGender(string gender)
    {
        Debug.Log("Selected gender: " + gender);
        // Se a seleção de gênero for confirmada fazer nada
        if (genderSelected)
            return;

        // Atualiza o gênero selecionado
        selectedGender = gender;

        // Destacar o botão de gênero selecionado(opcional)
        if (gender == "Male")
        {
            maleButton.interactable = false;
            femaleButton.interactable = true; // Tira a seleção do botão feminino
        }
        else if (gender == "Female")
        {
            maleButton.interactable = true; // Tira a seleção do botão masculino
            femaleButton.interactable = false;
        }
        Debug.Log("Selected gender: " + gender);
    }

    private void ConfirmGender()
    {
        if (!genderSelected && selectedGender != null)
        {
            genderSelected = true;
            Debug.Log("Gender confirmed: " + selectedGender);

            // Invoca o evento com o gênero selecionado
            OnGenderSelected.Invoke(selectedGender);

            //Passa o gênero selecionado ao GameManager
            GameManager.Instance.selectedGender = selectedGender;

            // Ativa a caixa de dialogo correspondente no GameManager
            GameManager.Instance.selectedDialogueBox = selectedGender == "Male" ? maleDialogueBox : femaleDialogueBox;

            // Seleciona as referencias do Sprite no GameManager baseado no gênero selecionado  
            GameManager.Instance.playerSprite = (selectedGender == "Male") ? maleSprite : femaleSprite;

            // Desativa os elementos de UI de seleção de gênero, após confirmar
            maleButton.gameObject.SetActive(false);
            femaleButton.gameObject.SetActive(false);

            // Remove o listener do botão confirmar
            confirmButton.onClick.RemoveListener(ConfirmGender);

            // Ativa a próxima interface (inserir o nome)
            nameInput.SetActive(true);
        }  
        else if(!genderSelected && selectedGender == null)
        {
            Debug.Log("No gender selected yet.");
        }
        else
        {
            Debug.Log("Gender is selected.");
        }
    }
}
