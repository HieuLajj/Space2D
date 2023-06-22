using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPooling : Singleton<BulletPooling>
{
    public List<GameObject>PoolBullet;
    // Start is called before the first frame update
    private void Awake() {
        PoolBullet = new List<GameObject>();
    }
    public GameObject GetBullet(){
        int count = PoolBullet.Count;
        for(int i=0; i<count; i++){
            if(!PoolBullet[i].activeInHierarchy){
                return PoolBullet[i];
            }
        }
        return null;
    }
}
