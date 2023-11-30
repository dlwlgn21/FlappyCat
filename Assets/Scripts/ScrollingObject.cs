using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    private Rigidbody2D mRB2d;

    // Start is called before the first frame update
    void Start()
    {
        mRB2d = GetComponent<Rigidbody2D>();
        Debug.Assert(mRB2d != null);
        mRB2d.velocity = new Vector2(GameManager.Instance.ScrollSpeed, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.bIsGameOver)
        {
            mRB2d.velocity = Vector2.zero;
            return;
        }
    }
}
