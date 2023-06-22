using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController>
{
    public List<IListener> ListtenerAll = new List<IListener>();
    public void CheckWin(){
        if(ManagerEnemy.Instance.CheckEnemy()){
            ManagerUI.Instance.RestartUI.SetActive(true);
            GameOver();
        }
        
    }
    public void StartGame(){
        foreach(var item in ListtenerAll){
            item.IStart();
        }
        ManagerEnemy.Instance.StartEnemy();
    }

    public void StartPlay(){
        foreach(var item in ListtenerAll){
            item.IPlay();
        }
    }

    public void GameOver(){
        foreach(var item in ListtenerAll){
            item.IGameOver();
        }
    }

}
