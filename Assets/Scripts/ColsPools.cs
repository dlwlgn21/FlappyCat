using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColsPools : MonoBehaviour
{
    public uint ColsPoolsSize = 5;
    public GameObject ColPrefab;
    public float SpawnTime = 4.0f;
    public float colMinYPos = -2.0f;
    public float colMaxYPos = 4.5f;

    private Vector2 mObjectPoolPos = new Vector2(-15.0f, -25.0f);
    private GameObject[] mCols;
    private float mSinceLastSpawnTimer;
    private const float SPWAN_X_POS = 10.0f;
    private uint currentColIdx = 0;
    void Start()
    {
        mCols = new GameObject[ColsPoolsSize];
        for (uint i = 0; i < ColsPoolsSize; ++i)
        {
            mCols[i] = Instantiate(ColPrefab, mObjectPoolPos, Quaternion.identity); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        mSinceLastSpawnTimer += Time.deltaTime;
        if (!GameManager.Instance.bIsGameOver && mSinceLastSpawnTimer >= SpawnTime)
        {
            mSinceLastSpawnTimer = 0.0f;
            float spawnYPos = Random.Range(colMinYPos, colMaxYPos);
            mCols[currentColIdx].transform.position = new Vector2(SPWAN_X_POS, spawnYPos);
            ++currentColIdx;
            if (currentColIdx >= ColsPoolsSize)
            {
                currentColIdx = 0;
            }
        }



    }
}
