using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using static GameEvents;

public class GridSquare : MonoBehaviour
{
    public int SquareIndex { get; set; }

    private AlphabethData.LetterData _normalLetterData;
    private AlphabethData.LetterData _selectedLetterData;
    private AlphabethData.LetterData _correctLetterData;

    private SpriteRenderer displayedImage;

    private bool _selected;
    private bool _clicked;
    private int _index = -1;
    private bool _correct;

    public void SetIndex(int index)
    {
        _index = index;
    }

    public int GetIndex()
    {
        return _index;
    }

    void Start()
    {
        _selected = false;
        _clicked = false;
        _correct = false;
        displayedImage = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        GameEvents.OnEnableSquareSelection += OnEnableSquareSelection;
        GameEvents.OnDisableSquareSelection += OnDisableSquareSelection;
        GameEvents.OnSelectSquare += SelectSquare;
        GameEvents.OnCorrectWord += CorrectWord;

    }

    private void OnDisable()
    {
        GameEvents.OnEnableSquareSelection -= OnEnableSquareSelection;
        GameEvents.OnDisableSquareSelection -= OnDisableSquareSelection;
        GameEvents.OnSelectSquare -= SelectSquare;
        GameEvents.OnCorrectWord -= CorrectWord;
    }

    private void CorrectWord(string word, List<int> squareIndexes)
    {
        if(_selected && squareIndexes.Contains(_index))
        {
            _correct = true;
            displayedImage.sprite = _correctLetterData.image;
            Shake();
        }

        _selected = false;
        _clicked = false;
    }

    public void OnEnableSquareSelection()
    {
        _clicked = true;
        _selected = false;
    }

    public void OnDisableSquareSelection()
    {
        if (_correct == true)
        {
            displayedImage.sprite = _correctLetterData.image;

        }
        else if(_selected == true && _correct == false)
        {
            displayedImage.sprite = _normalLetterData.image;
            Shake();
        }

        _selected = false;
        _clicked = false;
    }

    private void SelectSquare(Vector3 position)
    {
        if (this.gameObject.transform.position == position)
        {
            displayedImage.sprite = _selectedLetterData.image;
            _selected = true;
        }
    }

    public void SetSprite(AlphabethData.LetterData normalLetterData, AlphabethData.LetterData selectedLetterData, AlphabethData.LetterData correctLetterData)
    {
        _normalLetterData = normalLetterData;
        _selectedLetterData = selectedLetterData;
        _correctLetterData = correctLetterData;

        GetComponent<SpriteRenderer>().sprite = _normalLetterData.image;
    }

    private void OnMouseDown()
    {
        OnEnableSquareSelection();
        GameEvents.EnableSquareSelectionMethod();
        CheckSquare();
        displayedImage.sprite = _selectedLetterData.image;
        _selected = true;
    }

    private void OnMouseEnter()
    {
        CheckSquare();
    }

    private void OnMouseUp()
    {
        GameEvents.ClearSelectionMethod();
        GameEvents.DisableSquareSelectionMethod();
    }

    public void CheckSquare()
    {
        if(_selected == false && _clicked == true)
        {
           // _selected = true;
            GameEvents.CheckSquareMethod(_normalLetterData.letter, gameObject.transform.position, _index);
        }
    }
    public void Shake()
    {
        StartCoroutine(ShakeCoroutine());
    }

    IEnumerator ShakeCoroutine()
    {
        float elapsedTime = 0f;
        float rotateDuration = 0.5f;  // Duração da rotação em segundos
        float rotateSpeed = 360f / rotateDuration;  // Velocidade de rotação em graus por segundo

        Quaternion originalRotation = gameObject.transform.localRotation;

        while (elapsedTime < rotateDuration)
        {
            // Calcula a rotação incremental baseada no tempo e na velocidade
            float angle = rotateSpeed * elapsedTime;
            Quaternion rotationAmount = Quaternion.Euler(0f, angle, 0f);  // Ajuste o eixo de acordo com a orientação desejada

            // Aplica a nova rotação ao transform do objeto
            transform.localRotation = originalRotation * rotationAmount;

            // Aguarda um frame
            yield return null;

            elapsedTime += Time.deltaTime;
        }

        // Retorna à rotação original quando a rotação termina
        transform.localRotation = originalRotation;
    }
}
