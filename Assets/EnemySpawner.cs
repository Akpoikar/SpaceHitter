using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] Enemies;
    public GameObject SpawnEffect;
    public float _minTimeRange = 1;
    public float _maxTimeRange = 10;
    private float OverallTime = 0;
    public float _accelerationTime = 10f;
    public GameObject Player;
    float _currTime;

    IEnumerator tmp;


    IEnumerator ItemsSpawner(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        int itemIndex = Random.Range(0, Enemies.Length);
        float x = Random.Range(1, 14);
        float z = Random.Range(-1, -14);

        var obj = Instantiate(Enemies[itemIndex],this.transform);

        obj.transform.position = new Vector3(x, obj.transform.position.y, z);

        obj.GetComponent<Animator>().SetTrigger("Float");
        Instantiate(SpawnEffect,obj.transform);
        tmp = null;
    }


    void Update()
    {
        if (Player.GetComponent<PlayerMovement>().endGame == true) return;
        _currTime -= Time.deltaTime;
        if (_currTime <= 0)
        {
            _currTime = _accelerationTime;
        }
        OverallTime += Time.deltaTime;
        if (OverallTime % 60 == 0 && _accelerationTime > 3) _accelerationTime--;

        if (tmp == null)
        {
            Spawn();
        }
    }

    void Spawn()
    {
        float waitTime = Random.Range(_minTimeRange, _maxTimeRange);
        tmp = ItemsSpawner(waitTime);
        StartCoroutine(tmp);
    }
}
