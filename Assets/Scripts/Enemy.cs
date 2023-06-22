using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IListener
{
    private int hp;
    public int hpmax=5;
    public Vector2 _PositionEnemy;
    // Start is called before the first frame update
    private bool checkfire = false;
    private void Awake() {
        GameController.Instance.ListtenerAll.Add(this);
    }
    public void MoveEnemy(){
        if(!gameObject.activeInHierarchy)return;
        StartCoroutine(MoveToDestination());
    }
    IEnumerator MoveToDestination() {
        while (new Vector2(transform.position.x, transform.position.y) != _PositionEnemy) {
            transform.position = Vector2.MoveTowards(transform.position, _PositionEnemy, 2 * Time.deltaTime);
            yield return null;
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("bullet")){
            if(!checkfire){
                return;
            }
            other.gameObject.SetActive(false);
            hp--;
            if(hp <= 0){
                ManagerInformation.Instance.Scoregame++;
                DeActiveObject();
            }
        }
    }
    private void DeActiveObject(){
        gameObject.SetActive(false);
        GameController.Instance.CheckWin();
    }

    void IListener.IPlay()
    {
        checkfire = true;
    }

    void IListener.IGameOver()
    {
       
    }

    public void IStart()
    {
        hp = hpmax;
        gameObject.SetActive(true);
        transform.position = ManagerEnemy.Instance.spawnPosition.position;
    }
}
