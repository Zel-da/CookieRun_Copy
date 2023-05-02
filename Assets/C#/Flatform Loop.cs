using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlatformLoop : MonoBehaviour
{
    private float width; // 배경의 가로 길이

    private void Awake()
    {
        //BoxColider2D 컴포넌트의 Size 필드의 x 값을 가로 길이로 사용
        BoxCollider2D flatformGroundCollider = GetComponent<BoxCollider2D>();
        width = flatformGroundCollider.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        //현재 위치가 원점에서 왼쪽으로 width 이상 이동했을 때 위치를 재배치
        if (transform.position.x <= -width)
        {
            Reposition();
        }
    }

    private void Reposition()
    {
        //현재 위치에서 오른쪽으로 가로 길이 * 2만큼 이동
        Vector2 offset = new Vector2(width * 2f, 0);
        transform.position = (Vector2)transform.position + offset;
    }
}
