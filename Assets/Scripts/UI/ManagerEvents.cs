using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerEvents : MonoBehaviour
{
    public void StartGame(){
        ManagerUI.Instance.MenuUI.SetActive(false);
        GameController.Instance.StartGame();
    }
    public void RestartGame(){
        ManagerUI.Instance.RestartUI.SetActive(false);
        GameController.Instance.StartGame();
    }
}
