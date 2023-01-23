using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mobSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy());
    }

    // Update is called once per frame
    public Transform Enemy;
    public Transform Enemy_little;
    public int mustBe = 6;
    int amount = 0;
    IEnumerator spawnEnemy()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(1, 4));
            if(Random.Range(0,100) > 75 || mustBe == amount)
            {
                PathologicalGames.SpawnPool p = PathologicalGames.PoolManager.Pools["testPool"];
                p.Spawn("Enemy", new Vector3(Random.Range(-10, 10), Enemy.position.y, Enemy.position.z), Quaternion.identity, null);
                amount = 0;
                //Instantiate(Enemy, new Vector3(Random.Range(-10, 10), Enemy.position.y, Enemy.position.z), Quaternion.identity);
            }
            else
            {
                amount += 1;
                Instantiate(Enemy_little, new Vector3(Random.Range(-10, 10), Enemy_little.position.y, Enemy_little.position.z), Quaternion.identity);
            }
            if(playerControl.isAlive != true)
            {
                yield break;
            }
        }
    }
}
