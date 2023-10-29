using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnEnemy : MonoBehaviour
{
    public Transform[] spawnPos;
    public Transform[] skySpawnPos;
    public List<GameObject> enemyList = new List<GameObject>();
    private List<GameObject> spawnedEnemies = new List<GameObject>();

    [Header("Timer")]
    public Text timerText;

    public int timer = 0;
    private float spawnCount = 1f;

   

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy_());
        StartCoroutine(TimerCoroution());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemy_()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnCount);
            Transform spawnPoint = spawnPos[Random.Range(0, 4)];
            int spawnNum1 = Random.Range(0, 2);

            if (timer <= 200)
            {
                GameObject newEnemy = Instantiate(enemyList[spawnNum1], spawnPoint.position, Quaternion.identity);
                newEnemy.GetComponent<EnemyOne>().MonsterRandomAnim();
                newEnemy.transform.SetParent(spawnPoint);
                spawnedEnemies.Add(newEnemy);
            }
            //else
            //{
            //    GameObject newEnemy = Instantiate(enemyList[1], skySpawnPoint.position, Quaternion.identity);
            //    newEnemy.transform.SetParent(skySpawnPoint);
            //    spawnedEnemies.Add(newEnemy);
            //}

        }
    }

    public void ApplyDamageToLastSpawnedEnemy(float damage)
    {
        if (spawnedEnemies.Count > 0)
        {
            GameObject lastEnemy = spawnedEnemies[spawnedEnemies.Count - 1];
            EnemyOne enemyScript = lastEnemy.GetComponent<EnemyOne>();
            if (enemyScript != null)
            {
                enemyScript.EnemyTakeDamage(damage);
            }
        }
    }

    IEnumerator TimerCoroution()
    {
        timer += 1;

        timerText.text = (timer / 60 % 60).ToString("D2") + ":" + (timer % 60).ToString("D2");

        yield return new WaitForSeconds(1f);

        StartCoroutine(TimerCoroution());
    }

}
