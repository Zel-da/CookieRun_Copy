using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float speed = 10f;

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.isGameover)
        {
            // 초당 speed의 속도로 왼쪽으로 평행이동
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
}
