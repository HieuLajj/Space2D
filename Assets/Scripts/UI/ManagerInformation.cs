using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerInformation : Singleton<ManagerInformation>, IListener
{   
    private int scoregame = 0;
    public int Scoregame{
        set{
            scoregame = value;
            ManagerUI.Instance.gameInUI.SetScore(scoregame);
        }
        get{
            return scoregame;
        }
    }
    private void Awake() {
        GameController.Instance.ListtenerAll.Add(this);
    }
    void IListener.IGameOver()
    {
        ManagerUI.Instance.gameInUI.gameObject.SetActive(false);
        Scoregame = 0;
    }

    void IListener.IPlay()
    {
        ManagerUI.Instance.gameInUI.gameObject.SetActive(true);
    }

    void IListener.IStart()
    {
        ManagerUI.Instance.gameInUI.gameObject.SetActive(false);
    }
}
