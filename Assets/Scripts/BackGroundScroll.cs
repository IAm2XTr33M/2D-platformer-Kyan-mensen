using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScroll : MonoBehaviour
{
    public Transform player;

    public float offsetY;

    float minX = 36.23314f;

    public float ScrollMultiplier;

    float LastX = 0;

    private void Start()
    {
        LastX = player.position.y;
    }

    private void FixedUpdate()
    {
        float X = player.position.x;

        float difX = LastX - X;


        float calcX = transform.position.x + (difX * ScrollMultiplier);
        if (calcX < minX)
        {
            transform.position = new Vector3(minX, 0, 10);
        }
        else
        {
            transform.position = new Vector3(calcX, 0, 10);
            LastX = X;
        }
    }
}
