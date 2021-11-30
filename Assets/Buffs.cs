using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buffs : MonoBehaviour
{
    public float _minTimeRange = 1;
    public float _maxTimeRange = 10;
    public GameObject Player;
    float _currTime;
    public float _accelerationTime = 10f;
    private float OverallTime = 0;
    public GameObject[] Buff;
    public GameObject SpawnEffect;

    IEnumerator tmp;
    IEnumerator ItemsSpawner(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        int itemIndex = Random.Range(0, Buff.Length);
        float x = Random.Range(1, 14);
        float z = Random.Range(-1, -14);

        var obj = Instantiate(Buff[itemIndex],this.transform);

        obj.transform.position = new Vector3(x, obj.transform.position.y, z);

        Instantiate(SpawnEffect, obj.transform);
        tmp = null;
    }

    // Update is called once per frame
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

        if (tmp == null && Player.GetComponentInChildren<PlayerInterraction>().WantToDie == true && this.transform.childCount < 1)
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
