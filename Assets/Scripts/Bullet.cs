using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 direction = new Vector2(0,1);
    private float speed = 5;
    void Start()
    {
        BulletPooling.Instance.PoolBullet.Add(this.gameObject);
    }
    private void OnEnable() {
        StartCoroutine(DeactiveBullet(2));   
    }

    // Update is called once per frame
    private void FixedUpdate() {
        Vector2 _dis = transform.position;
        _dis+=direction*speed*Time.fixedDeltaTime;
        transform.position = _dis;
    }

    private IEnumerator DeactiveBullet(float timewait){
        yield return new WaitForSeconds(timewait);
        gameObject.SetActive(false);
    }
}
