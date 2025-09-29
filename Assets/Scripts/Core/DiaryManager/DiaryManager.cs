using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DiaryManager : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject diaryPanel;
    public Button openCloseButton;
    public Text openCloseButtonText;
    public GameObject pageContainer;
    public GameObject entryViewPanel;
    public Image entryImage;
    public Button backButton;
    public Button nextPageButton;
    public Button previousPageButton;

    [Header("Diary Pages")]
    public List<GameObject> pages;
    public List<Button> entryButtons;

    [Header("Entry Content")]
    public List<Sprite> entryImages;

    private int currentPageIndex = 0;
    private bool isDiaryOpen = false;

    void Start()
    {
        openCloseButton.onClick.AddListener(ToggleDiary);
        nextPageButton.onClick.AddListener(NextPage);
        previousPageButton.onClick.AddListener(PreviousPage);
        backButton.onClick.AddListener(CloseEntryView);

        // Configura os botões de entry
        for (int i = 0; i < entryButtons.Count; i++)
        {
            int entryId = i; // Variável local para evitar problema de escopo
            entryButtons[i].onClick.AddListener(() => OnEntryButtonClick(entryId));
        }

        UpdatePageButtons();
        UpdateEntryButtons();
    }

    public void ToggleDiary()
    {
        isDiaryOpen = !isDiaryOpen;
        diaryPanel.SetActive(isDiaryOpen);

        if (isDiaryOpen)
            openCloseButtonText.text = "Fechar Diário";
        else
            openCloseButtonText.text = "Abrir Diário";
    }

    void NextPage()
    {
        if (currentPageIndex < pages.Count - 1)
        {
            pages[currentPageIndex].SetActive(false);
            currentPageIndex++;
            pages[currentPageIndex].SetActive(true);
            UpdatePageButtons();
        }
    }

    void PreviousPage()
    {
        if (currentPageIndex > 0)
        {
            pages[currentPageIndex].SetActive(false);
            currentPageIndex--;
            pages[currentPageIndex].SetActive(true);
            UpdatePageButtons();
        }
    }

    void UpdatePageButtons()
    {
        previousPageButton.interactable = (currentPageIndex > 0);
        nextPageButton.interactable = (currentPageIndex < pages.Count - 1);
    }

    public void UnlockEntry(int entryId)
    {
        if (entryId >= 0 && entryId < entryButtons.Count)
        {
            PlayerPrefs.SetInt("Entry_" + entryId, 1); // Salva o estado da entry
            UpdateEntryButtons();
        }
    }

    void UpdateEntryButtons()
    {
        for (int i = 0; i < entryButtons.Count; i++)
        {
            if (PlayerPrefs.GetInt("Entry_" + i, 0) == 1)
            {
                entryButtons[i].interactable = true;
                entryButtons[i].GetComponent<Image>().color = Color.white; // Cor de botão desbloqueado
            }
            else
            {
                entryButtons[i].interactable = false;
                entryButtons[i].GetComponent<Image>().color = Color.black; // Cor de botão bloqueado (dá pra trocar pra passar por parâmetro dps)
            }
        }
    }

    void OnEntryButtonClick(int entryId)
    {
        if (entryId >= 0 && entryId < entryImages.Count)
        {
            entryImage.sprite = entryImages[entryId];
            pageContainer.SetActive(false);
            entryViewPanel.SetActive(true);
        }
    }

    void CloseEntryView()
    {
        entryViewPanel.SetActive(false);
        pageContainer.SetActive(true);
    }
}