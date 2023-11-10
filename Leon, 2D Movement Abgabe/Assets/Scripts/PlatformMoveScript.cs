using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UIElements;

public class PlatformMoveScript : MonoBehaviour
{

    [SerializeField] private Transform point01;
    [SerializeField] private Transform point02;

    private int transformValue = 1;
    public int movespeed;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, point01.position);
        Gizmos.DrawLine(transform.position, point02.position);
    }
}
