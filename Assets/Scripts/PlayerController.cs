using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IListener
{
    // Start is called before the first frame update
    [SerializeField]private float speed = 10f;
    [SerializeField]private float timeBullet = 0.1f;
    private float _timeBullet;
    public Transform BulletSpawn;
    public GameObject BulletPrefab;
    [SerializeField] private Transform BulletContainer;
    private bool checkfire = false;
    private void Awake() {
        GameController.Instance.ListtenerAll.Add(this);
    }
    void Start()
    {
        _timeBullet = timeBullet;
    }

    // Update is called once per frame
    void Update()
    {
        _timeBullet-=Time.deltaTime;
        if(_timeBullet<=0 && checkfire){
            _timeBullet = 0.1f;
            GameObject bullet = BulletPooling.Instance.GetBullet();
            if(bullet == null){
                Instantiate(BulletPrefab, BulletSpawn.transform.position, Quaternion.identity, BulletContainer);
            }else{
                bullet.transform.position = BulletSpawn.transform.position;
                bullet.SetActive(true);
            }
        }
        PlayerMovement();
    }

    void PlayerMovement(){
        float xPos = Input.GetAxis("Horizontal");
        transform.Translate(new Vector2(xPos, 0) * speed * Time.deltaTime);
    }
    void IListener.IPlay()
    {
        checkfire = true;
    }

    void IListener.IGameOver()
    {
       checkfire = false;
    }

    public void IStart()
    {
        
    }
}
