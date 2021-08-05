using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panels : MonoBehaviour
{
    [SerializeField] private GameObject panelLose;
    [SerializeField] private GameObject panelWin;

    /// <summary>
    /// Метод для отображения панели проигрыша или выиграша
    /// </summary>
    /// <param name="text">"Lose" или "Win"</param>
    public void ShowPanel(string text)
    {
        switch (text)
        {
            case "Lose":
                panelLose.SetActive(true);
                break;
            case "Win":
                panelWin.SetActive(true);
                break;
            default:
                break;
        }
    }
}
