using UnityEngine;
using System.Collections;

public class Enemy_Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies;
    private float[] arrPosX = {-2.2f, -1.1f, 0f, 1.1f, 2.2f};
    private float spawnInterval = 1.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartEnemyRoutine();
    }

    void StartEnemyRoutine() {
        StartCoroutine("EnemyRoutine");
    }

    IEnumerator EnemyRoutine(){
        yield return new WaitForSeconds(2f);

        while(true){
            int indexPos = Random.Range(0, arrPosX.Length);
            int indexEnemy = Random.Range(0, enemies.Length);
            SpawnEnemy(arrPosX[indexPos], indexEnemy);

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    // Update is called once per frame
    void SpawnEnemy(float posX, int index)
    {
        Vector3 spawnPos = new Vector3(posX, transform.position.y, transform.position.z);
        Instantiate(enemies[index], spawnPos, Quaternion.identity);
    }
}
