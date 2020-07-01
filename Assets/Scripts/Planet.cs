using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField]
    private Transform _target;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveToTarget(float pT)
    {
        transform.localPosition = Vector3.Lerp(Vector3.zero, _target.position, pT);
    }
}
