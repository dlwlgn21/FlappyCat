using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    public float UpForce = 200.0f;

    private bool mbIsDead = false;
    private Rigidbody2D mRB2d;
    private Animator mAnimator;
    // Start is called before the first frame update
    void Start()
    {
        mAnimator = GetComponent<Animator>();
        mRB2d = GetComponent<Rigidbody2D>();
        Debug.Assert(mRB2d != null & mAnimator != null);
    }

    // Update is called once per frame
    void Update()
    {
        if (mbIsDead) { return; }

        if (Input.GetMouseButtonDown(0))
        {
            mRB2d.velocity = Vector2.zero;
            mRB2d.AddForce(new Vector2(0.0f, UpForce));
            mAnimator.SetTrigger("IsJump");
        }
    }
    private void GameOver()
    {
        mRB2d.velocity = Vector2.zero;
        mbIsDead = true;
        mAnimator.SetTrigger("IsDead");
        GameManager.Instance.CatDied();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Column>() != null)
        {
            return;
        }
        GameOver();
    }
}
