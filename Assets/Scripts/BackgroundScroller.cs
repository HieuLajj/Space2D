using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour ,IListener
{
    
    public float scrollSpeed = 0.2f;
    private float offset;
    private Material mat;
    private void Awake() {
        GameController.Instance.ListtenerAll.Add(this);
    }

    void IListener.IGameOver()
    {
       scrollSpeed = 0.2f;
    }

    void IListener.IPlay()
    {
        scrollSpeed = 0.2f;
    }

    void IListener.IStart()
    {
       scrollSpeed = 3;
    }

    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        offset += (Time.deltaTime * scrollSpeed) /10f;
        mat.SetTextureOffset("_MainTex", new Vector2(0,offset));
    }
}
