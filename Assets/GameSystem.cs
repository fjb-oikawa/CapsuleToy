using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour {
    public GameObject target;
    public GameObject mBoll;
    float mRotTime = -1;
    float limit = 2.0f;
    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            Vector3 v = mBoll.transform.position;
            v.x += Random.value* limit - limit*0.5f;
            v.y += Random.value * limit - limit * 0.5f;
            v.z += Random.value * limit - limit * 0.5f;
            Instantiate(mBoll, v, Quaternion.identity);
        }

    }

    float minAngle = 0.0F;
    float maxAngle = 90.0F;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            mRotTime = Time.time;
        }
        if(mRotTime >= 0.0f)
        {
            float t = Time.time - mRotTime;
            float angle = Mathf.LerpAngle(minAngle, maxAngle, t);
            target.transform.eulerAngles = new Vector3(-90, angle, 0);
            if (t > 1.0f)
                mRotTime = -1;
        }

    }
}
