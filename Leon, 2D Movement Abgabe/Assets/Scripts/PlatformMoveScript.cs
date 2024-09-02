using System.Collections.Generic;
using UnityEngine;

public class PlatformMoveScript : MonoBehaviour
{
    [Header("Destination Points")]
    [SerializeField] private Transform point01;
    [SerializeField] private Transform point02;
    [SerializeField] private Transform point03;
    [SerializeField] private List<Transform> waypoints;

    [Header("Travel Parameter")]
    [SerializeField] private float traveldistance;
    private float tolerance = 0.0001f;
    private bool moveToFirstPoint = true;
    private int destinationIndex = 0;

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoints[destinationIndex].position, traveldistance * Time.deltaTime);
        if (CheckApproximiateVectorPosition(transform.position, waypoints[destinationIndex].position, tolerance))
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

    public bool CheckApproximiateVectorPosition(Vector2 _vector01, Vector2 _vector02, float _tolerance) // Ceck if the Item is rougly on the destinationPosition
    {
        if (_vector01.x < _vector02.x + _tolerance && _vector01.x > _vector02.x - _tolerance)
        {
            if (_vector01.y < _vector02.y + _tolerance && _vector01.y > _vector02.y - _tolerance)
            {
                return true; 
            }
        }
        return false;
    }
}
