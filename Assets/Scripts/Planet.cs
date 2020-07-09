using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField]
    private Transform _target;

    public float Value;

    public Light Light;

    public bool Up;

    private float test, test2;



    public void MoveToTarget(float pT, bool sun)
    {
       if(pT == 0 && name == "Moon")
        {
            test2 = test;

        }
        test = pT;

        float lerp = 0;
        if(Up)
        {
            if (sun)
            {
                lerp = Mathf.Lerp(0, 1, (pT - 0.19f) / 0.31f);
            }
            else
            {
           
                lerp = Mathf.Lerp(0, 1, (pT - 0.83f + test2) * 1.8f / 0.31f);

            }
        }
        else
        {
            if (sun)
            {
                lerp = Mathf.Lerp(1, 0, (pT - 0.51f) * 1.5f / 0.5f);
            }
            else
            {
                lerp = Mathf.Lerp(1, 0, (pT - 0.09f) * 2.6f / 0.31f);
                Debug.Log(lerp + " " + pT);
            }
        }

        //Debug.Log(pT + "  " + lerp);
        if (Up && lerp > 0)
        {
            transform.localPosition = Vector3.Lerp(Vector3.zero, _target.localPosition, lerp);
            if(lerp == 1 & Up)
            {
                Up = !Up;
            }
        }
        else if(!Up && lerp < 1)
        {
            transform.localPosition = Vector3.Lerp(Vector3.zero, _target.localPosition, lerp);
            if(lerp == 0 && name == "Moon")
            {
                Up = true;
                test = test2 = 0;
            }
        }
        Value = lerp;
    }
}
