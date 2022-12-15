using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform Player;

    public Vector3 OffSet;

    public float minX, maxX;

    public List<Vector3> StoredPositions = new List<Vector3>();

    bool waiting = true;
    float timer;

    public float Delay;

    private void FixedUpdate()
    {
        if(Player.position.x > minX)
        {
            StoredPositions.Add(new Vector3(Player.position.x, transform.position.y,Player.position.z)+ OffSet);
        }
        else
        {
            StoredPositions.Add(new Vector3(minX, transform.position.y, Player.position.z) + OffSet);
        }

        if (!waiting)
        {
            transform.position = StoredPositions[0];
            StoredPositions.RemoveAt(0);
        }
        else if(timer > Delay && waiting)
        {
            waiting = false;
        }
        else if (waiting)
        {
            timer += Time.fixedDeltaTime;
        }
        
    }
}
