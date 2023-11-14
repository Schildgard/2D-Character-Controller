using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UIElements;

public class PlatformMoveScript : MonoBehaviour
{

    [SerializeField] private Transform point01;
    [SerializeField] private Transform point02;
    [SerializeField] private Transform point03;
    [SerializeField] private float traveldistance;
    [SerializeField] private List<Transform> waypoints;
    private float tolerance = 0.0001f;
    public bool moveToFirstPoint = true;

    private int destinationIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {


        transform.position = Vector2.MoveTowards(transform.position, waypoints[destinationIndex].position, traveldistance * Time.deltaTime);
       
        if (ApproximiateVectorPosition(transform.position, waypoints[destinationIndex].position, tolerance))
        {
            destinationIndex++;
            if (destinationIndex >= waypoints.Count)
            {
                destinationIndex = 0;
                waypoints.Reverse();
            }
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, point01.position);
        Gizmos.DrawLine(transform.position, point02.position);
        Gizmos.DrawLine(transform.position, point03.position);
    }


    public bool ApproximiateVectorPosition(Vector2 _vector01, Vector2 _vector02, float _tolerance) // Ceck if the Item is rougly on the destinationPosition
    {
        if (_vector01.x < _vector02.x + _tolerance && _vector01.x > _vector02.x - _tolerance)
        {
            if (_vector01.y < _vector02.y + _tolerance && _vector01.y > _vector02.y - _tolerance)
            {
                return true;                                                                        // return of true indicates a change of Direction
            }
        }
        return false;                                                                               // return of false indicates to continue the process
    }
}
