using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public float mobSpeed = 0;
    public Vector2 StartPosition;

    private void OnEnable()
    {
        transform.position = StartPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * mobSpeed);

        if(transform.position.x < -13)
        {
            gameObject.SetActive(false);
        }
    }
}
