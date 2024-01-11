using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleEnemie : Enemie
{
    [SerializeField]
    private Enemie miniGoblin;
    public override void Die()
    {
        Vector3 pos = transform.position+ new Vector3(-1, 0, 0);
        Instantiate(miniGoblin, pos, Quaternion.identity);

        pos = transform.position + new Vector3(1, 0, 0);
        Instantiate(miniGoblin, pos, Quaternion.identity);
        base.Die();
    }
}
