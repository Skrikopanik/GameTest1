using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class enemyGrafix : MonoBehaviour
{
    public AIPath aiPath;


    void Update()
    {
        if (aiPath.desiredVelocity.x <= -0.01F)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);

        }else if (aiPath.desiredVelocity.x >= 0.01)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        
    }
}
