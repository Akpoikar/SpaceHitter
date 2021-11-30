using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Vector3 _originalPos;
    public Transform lastPos;
    [SerializeField]
    public bool shake = false;
    public float speed = 2f;
    [SerializeField] [Range(0f, 4f)] float stepPos, stepRot = 2f, stepLRot = 5f;
    IEnumerator enumerator;
    bool flag = false;
    void Awake()
    {
        _originalPos = transform.localPosition;
    }

    public void Starter()
    {
        flag = true;

    }

    private void Update()
    {
        if (flag == true)
        {
            transform.position = Vector3.Lerp(transform.position, lastPos.position, stepPos * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, lastPos.rotation, stepRot * Time.deltaTime);
            if  (Quaternion.Angle(transform.rotation, lastPos.transform.rotation) <= 0.01f)
            {
                flag = false;
            }

            stepPos += 0.02f;
            stepRot += 0.02f;
            stepLRot += 0.1f;
        }
        if (shake == true)
        {
            ShakeIt();
            shake = false;
        }
    }

    public void ShakeIt()
    {
        Shake(.2f, .1f);
    }
    public void Shake(float duration, float amount)
    {
        enumerator = cShake(duration, amount);
        StartCoroutine(enumerator);
    }

    public IEnumerator cShake(float duration, float amount)
    {
        float endTime = Time.time + duration;

        while (Time.time < endTime)
        {
            transform.localPosition = _originalPos + Random.insideUnitSphere * amount;

            duration -= Time.deltaTime;

            yield return null;
        }

        transform.localPosition = _originalPos;
    }
}
