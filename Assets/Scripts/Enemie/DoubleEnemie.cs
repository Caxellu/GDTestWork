using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleEnemie : Enemie
{
    [SerializeField]
    private GameObject miniGoblin;

    private GameObject goblin1, goblin2;
    public override void SpawnEnemiesUnit()
    {
        Vector3 pos = transform.position + new Vector3(-1, 0, 0);
        goblin1 = Instantiate(miniGoblin, pos, Quaternion.identity);
        goblin1.SetActive(false);

        pos = transform.position + new Vector3(1, 0, 0);
        goblin2 = Instantiate(miniGoblin, pos, Quaternion.identity);
        goblin2.SetActive(false);
    }
    public override void Die()
    {
        goblin1.transform.position = transform.position+ new Vector3(-1, 0, 0);
        goblin2.transform.position = transform.position + new Vector3(1, 0, 0);
        goblin1.SetActive(true);
        goblin1.GetComponent<Enemie>().Init();

        goblin2.SetActive(true);
        goblin2.GetComponent<Enemie>().Init();
        base.Die();
    }
}
