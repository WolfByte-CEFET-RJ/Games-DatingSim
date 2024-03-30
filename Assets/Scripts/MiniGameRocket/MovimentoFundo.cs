using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MovimentoFundo : MonoBehaviour
{
    public MeshRenderer mr;
    public float speed;
    private float timer = 0f;
    private float updateTime = 0.9f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mr.material.mainTextureOffset += new Vector2(speed *Time.deltaTime, 0);
        timer += Time.deltaTime;

        if (timer >= updateTime)
        {
            timer -= updateTime;
            if (speed > -3)
            {
                speed = (speed - 0.1f);
            }
        }
    }
}
