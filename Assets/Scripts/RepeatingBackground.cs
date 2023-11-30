using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    private BoxCollider2D mBoxColider;
    private float mGroundHrizontalLength;
    // Start is called before the first frame update
    void Start()
    {
        mBoxColider = GetComponent<BoxCollider2D>();
        mGroundHrizontalLength = mBoxColider.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -mGroundHrizontalLength)
        {
            repositionBackground();
        }
    }

    private void repositionBackground()
    {
        Vector2 groundOffset = new Vector2(mGroundHrizontalLength * 2f, 0.0f);
        transform.position = (Vector2)transform.position + groundOffset;
    }
}
