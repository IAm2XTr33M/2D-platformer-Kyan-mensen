using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public playerController manager;

    public float speed;
    bool right = true;

    private void Start()
    {
        manager = FindObjectOfType<playerController>();
        right = manager.Right;
    }

    private void Update()
    {
        float xAdd = -speed;
        if (right)
        {
            xAdd = speed;
        }
        transform.position += new Vector3(xAdd * Time.deltaTime, 0, 0);
    }
}
