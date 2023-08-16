using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTank : Singleton<EnemyTank>
{

    public void Move()
    {
        Debug.Log("EnemyTank moving!");
    }
}
