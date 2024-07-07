using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordChecker : MonoBehaviour
{
    public GameData currentGameData;

    private string _word;

    private int _assignedPoints = 0;
    private int _completedWords = 0;
    private Ray _rayUp, _rayDown;
    private Ray _rayLeft, _rayRight;
    private Ray _rayDiagonalLeftUp, _rayDiagonalLeftDown;
    private Ray _rayDiagonalRightUp, _rayDiagonalRightDown;
    private Ray _currentRay = new Ray();
    private Vector3 _rayStartPosition;
    private List<int> _correctSquareList = new List<int>();

    private void OnEnable()
    {
        GameEvents.OnCheckSquare += SquareSelected;
        GameEvents.OnClearSelection += ClearSelection;
    }

    private void OnDisable()
    {
        GameEvents.OnCheckSquare -= SquareSelected;
        GameEvents.OnClearSelection -= ClearSelection;
    }

    void Start()
    {
        _assignedPoints = 0;
        _completedWords = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(_assignedPoints > 0)
        {
            Debug.DrawRay(_rayUp.origin, _rayUp.direction * 4);
            Debug.DrawRay(_rayDown.origin, _rayDown.direction * 4);
            Debug.DrawRay(_rayLeft.origin, _rayLeft.direction * 4);
            Debug.DrawRay(_rayRight.origin, _rayRight.direction * 4);
            Debug.DrawRay(_rayDiagonalLeftUp.origin, _rayDiagonalLeftUp.direction * 4);
            Debug.DrawRay(_rayDiagonalLeftDown.origin, _rayDiagonalLeftDown.direction * 4);
            Debug.DrawRay(_rayDiagonalRightUp.origin, _rayDiagonalRightUp.direction * 4);
            Debug.DrawRay(_rayDiagonalRightDown.origin, _rayDiagonalRightDown.direction * 4);
        }
    }

    private void SquareSelected(string letter, Vector3 squarePosition, int squareIndex)
    {
        if(_assignedPoints == 0)
        {
            _rayStartPosition = squarePosition;
            _correctSquareList.Add(squareIndex);
            _word += letter;

            _rayUp = new Ray(new Vector2(squarePosition.x, squarePosition.y), new Vector2(0f,1));
            _rayDown = new Ray(new Vector2(squarePosition.x, squarePosition.y), new Vector2(0f, -1));
            _rayLeft = new Ray(new Vector2(squarePosition.x, squarePosition.y), new Vector2(-1, 0f));
            _rayRight = new Ray(new Vector2(squarePosition.x, squarePosition.y), new Vector2(1, 0f));
            _rayDiagonalLeftUp = new Ray(new Vector2(squarePosition.x, squarePosition.y), new Vector2(-1, 1));
            _rayDiagonalLeftDown = new Ray(new Vector2(squarePosition.x, squarePosition.y), new Vector2(-1, -1));
            _rayDiagonalRightUp = new Ray(new Vector2(squarePosition.x, squarePosition.y), new Vector2(1, 1));
            _rayDiagonalRightDown = new Ray(new Vector2(squarePosition.x, squarePosition.y), new Vector2(1, -1));
        }

        else if (_assignedPoints == 1)
        {
            _correctSquareList.Add(squareIndex);
            _currentRay = SelectRay(_rayStartPosition, squarePosition);
            GameEvents.SelectSquareMethod(squarePosition);
            _word += letter;
            CheckWord();
        }

        else
        {
            if(IsPointOnTheRay(_currentRay, squarePosition))
            {
                _correctSquareList.Add(squareIndex);
                GameEvents.SelectSquareMethod(squarePosition);
                _word += letter;
                CheckWord();
            }
        }

        _assignedPoints++;
    }

    private void CheckWord()
    {
        foreach(var searchingWord in currentGameData.selectedBoardData.SearchWords)
        {
            if(_word == searchingWord.Word)
            {
                GameEvents.CorrectWordMethod(_word, _correctSquareList);
                _word = string.Empty;
                _correctSquareList.Clear();
                return;
            }
        }
    }

    private bool IsPointOnTheRay(Ray currentRay, Vector3 point)
    {
        var hits = Physics.RaycastAll(currentRay, 100.0f);

        for(int i = 0; i < hits.Length; i++) 
        {
            if (hits[i].transform.position == point)
            {
                return true;
            }
        }

        return false;
    }

    private Ray SelectRay(Vector2 firstPosition, Vector2 secondPosition)
    {
        var direction = (secondPosition - firstPosition).normalized;
        float tolerance = 0.01f;


        if(Math.Abs(direction.x) < tolerance && Math.Abs(direction.y - 1f) < tolerance)
        {
            return _rayUp;
        }
        if (Math.Abs(direction.x) < tolerance && Math.Abs(direction.y - (-1f)) < tolerance)
        {
            return _rayDown;
        }
        if (Math.Abs(direction.x - (-1f)) < tolerance && Math.Abs(direction.y) < tolerance)
        {
            return _rayLeft;
        }
        if (Math.Abs(direction.x - 1f) < tolerance && Math.Abs(direction.y) < tolerance)
        {
            return _rayRight;
        }
        if (direction.x < 0f && direction.y > 0f)
        {
            return _rayDiagonalLeftUp;
        }
        if (direction.x < 0f && direction.y < 0f)
        {
            return _rayDiagonalLeftDown;
        }
        if (direction.x > 0f && direction.y > 0f)
        {
            return _rayDiagonalRightUp;
        }
        if (direction.x > 0f && direction.y < 0f)
        {
            return _rayDiagonalRightDown;
        }

        return _rayDown;
    }

    private void ClearSelection()
    {
        _assignedPoints = 0;
        _correctSquareList.Clear();
        _word = string.Empty;
    }
}
