using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Latch : MonoBehaviour
{
    [SerializeField] private Text _textTimeSecond; // текст для отображения времени 
    [SerializeField] private float _timeSecond; // время

    [SerializeField] private Text[] _pins; // текст для пинов
    [SerializeField] private int[] _numberPins; // пины

    private string _needNumber = "555"; // выигрышное число

    private Panels panels;

    private void Start()
    {
        ShowPins();
        panels = GetComponent<Panels>();
    }

    private void Update()
    {
        StopWhatch();
        _textTimeSecond.text = Mathf.Round(_timeSecond).ToString(); // округляем в целое число


    }

    private void StopWhatch()
    {
        if (_timeSecond > 0)
        {
            _timeSecond -= Time.deltaTime;
        }
        else
        {
            _timeSecond = 0;
            panels.ShowPanel("Lose");
        }
    }

    public void ChrckingNumbers(string a)
    {
        //a = "555";
        Debug.Log(a);

        if (a == _needNumber)
        {
            Debug.Log("Вы выиграли");
            panels.ShowPanel("Win");
        }
    }

    /// <summary>
    /// Выводит на экран цыфры пинов
    /// </summary>
    private void ShowPins()
    {
        for (int i = 0; i < _pins.Length; i++)
        {
            _pins[i].text = _numberPins[i].ToString();
        }
    }

    /// <summary>
    /// Этот медод для бодбора инструмента. Каждое число меняет пин в игре
    /// </summary>
    /// <param name="numberOne">Первый пин</param>
    /// <param name="numberTwo">Второй пин</param>
    /// <param name="numberThree">Третий пин</param>
    private void Tool(int numberOne, int numberTwo, int numberThree)
    {
        _numberPins[0] += numberOne;
        _numberPins[1] += numberTwo;
        _numberPins[2] += numberThree;

        if (_numberPins[0] > 10 || _numberPins[1] > 10 || _numberPins[2] > 10)
        {
            Debug.Log("Вы проиграли");
            panels.ShowPanel("Lose");
        }

        if (_numberPins[0] < 0 || _numberPins[1] < 0 || _numberPins[2] < 0)
        {
            Debug.Log("Вы проиграли");
            panels.ShowPanel("Lose");
        }

        ShowPins();

        string t = _numberPins[0].ToString() + _numberPins[1].ToString() + _numberPins[2].ToString();
        ChrckingNumbers(t);
    }

    #region MethodForButtons
    public void Drill()
    {
        Tool(+1, -1, 0);
    }

    public void Hammer()
    {
        Tool(-1, +2, -1);
    }

    public void MasterKey()
    {
        Tool(+2, +2, -2);
    }


    #endregion

}
