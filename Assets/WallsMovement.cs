using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsMovement : MonoBehaviour
{
    public float endPos = 0, startPos = 0;
    public float speed = 0;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < endPos) transform.position = new Vector3(startPos, transform.position.y, transform.position.z);
       
        transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
    }
}
