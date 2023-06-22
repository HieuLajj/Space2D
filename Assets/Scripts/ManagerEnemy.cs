using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ManagerEnemy : Singleton<ManagerEnemy>
{
    public GameObject Enemy;
    public GameObject BoundsEnemy;
    int numEnemies = 16;
    float distance = 0.8f;

    public Transform spawnPosition;
    public Transform Bounds;
    public Transform[,] arrayBounds = new Transform[6, 9];
    public List<Vector2> diamondlists = new List<Vector2>();
    public List<Vector2> vuonglists = new List<Vector2>();
    public List<Vector2> deulists = new List<Vector2>();
    public List<Vector2> nhatlists = new List<Vector2>();
    private List<Enemy> enemyList = new List<Enemy>();
    private void Awake() {
        SpawnBounds();
        SpawnEnemy();
    }
    private void Start()
    {
    }

    public void StartEnemy(){
        //ResetEnemy();
        WaveEnemy();
    }

    void SpawnBounds(){
        for (int j = 0; j < 6; j++)
        {
            for (int i = 0; i < 9; i++)
            {
             
                GameObject b = Instantiate(BoundsEnemy, transform.position, transform.rotation, Bounds) as GameObject;
                Vector3 v = new Vector3(transform.position.x + i * b.transform.localScale.x, transform.position.y - j * b.transform.localScale.y, transform.position.z);
                b.transform.localPosition = v;
                arrayBounds[j,i] = b.transform;
                
            }
        }
    }

    void SpawnEnemy(){
        for (int j = 0; j < 16; j++)
        {
            GameObject enemy = Instantiate(Enemy, spawnPosition.transform.position, Quaternion.identity);
            enemyList.Add(enemy.GetComponent<Enemy>());
            enemy.SetActive(false);
        }
    }
    void WaveEnemy(){
        Vuong();
    }

    void Vuong(){
        //vuong
        if(vuonglists.Count!=0){
            for(int i=0; i < vuonglists.Count; i++){
                Vector2 position2 = arrayBounds[(int)vuonglists[i].x,(int)vuonglists[i].y].position;
                enemyList[i]._PositionEnemy = position2;
                enemyList[i].MoveEnemy();      
            }
        }else{
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Vector2 position2 = arrayBounds[i,j+3].position;

                    vuonglists.Add(new Vector2(i,j+3));

                    enemyList[4*i+j]._PositionEnemy = position2;
                    enemyList[4*i+j].MoveEnemy();
                }
            }
        }
        Invoke ("Thoi", 6);
    }

    void Thoi(){
        //thoi
        for(int i=0; i < diamondlists.Count; i++){
            Vector2 b = new Vector2(0,0);
            if(i==0 || i== diamondlists.Count-1){

            }else if((int)diamondlists[i].y<=3){
                b = new Vector2(0.2f,0);
            }else if((int)diamondlists[i].y>=5){
                b = new Vector2(-0.2f,0);
            }
            Vector2 position2 = arrayBounds[(int)diamondlists[i].x,(int)diamondlists[i].y].position;
            position2+=b;
            enemyList[i]._PositionEnemy = position2;
            enemyList[i].MoveEnemy();      
        }
        Invoke ("Deu", 6);
    }

    void Deu(){
        //tam giac deu
        if(deulists.Count!=0){
            for(int i=0; i < deulists.Count; i++){
                Vector2 position2 = arrayBounds[(int)deulists[i].x,(int)deulists[i].y].position;
                enemyList[i]._PositionEnemy = position2;
                enemyList[i].MoveEnemy();      
            }
        }else{
            int m=0;
            for (int i = 1; i <= 5; i++)
            {
                for (int j = 1; j < 2*5; j++)
                {
                    if(Math.Abs(5 - j) == i - 1 || i == 5)
                    {
                        // float x =  i ;
                        // float y =  j ;
                        Vector2 position2 = arrayBounds[i-1,j-1].position;

                        deulists.Add(new Vector2(i-1,j-1));

                        enemyList[m]._PositionEnemy = position2;
                        enemyList[m].MoveEnemy();   
                        m++;
                    }
                }
            }
        }
        Invoke ("Nhat", 6);
    }

    void Nhat(){
        //chunhat
         if(nhatlists.Count!=0){
            for(int i=0; i < nhatlists.Count; i++){
                Vector2 position2 = arrayBounds[(int)nhatlists[i].x,(int)nhatlists[i].y].position;
                enemyList[i]._PositionEnemy = position2;
                enemyList[i].MoveEnemy();      
            }
        }else{
            int m=0;
            for (int i = 1; i <= 3; i++)
            {
                for (int j = 1; j <= 7; j++)
                {
                    if(i == 1 || i == 3 || j == 1 || j == 7)
                    {
                        Vector2 position2 = arrayBounds[i,j].position;
                        
                        nhatlists.Add(new Vector2(i,j));

                        enemyList[m]._PositionEnemy = position2;
                        enemyList[m].MoveEnemy();   
                        m++;
                    }
                }         
            }
        }
        Invoke ("StartPlay", 2);
    }
    void StartPlay(){
        GameController.Instance.StartPlay();
    }

    public bool CheckEnemy(){
        for(int i=0 ; i<enemyList.Count ; i++){
            if(enemyList[i].gameObject.activeInHierarchy){
                return false;
            }
        }
        return true;
    }

    // public void ResetEnemy(){
    //     for(int i=0; i< enemyList.Count; i++){
    //         enemyList[i].transform.position = spawnPosition.position;
    //         enemyList[i].gameObject.SetActive(true);
    //     }
    // }

}
