using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlapController : MonoBehaviour
{
    [SerializeField] private float rad;
    [SerializeField] private LayerMask layerM;

    void Start()
    {
        Collider[] colls = Physics.OverlapSphere(transform.position, rad, layerM);

        foreach(Collider coll in colls)
        {
            Destroy(coll.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
