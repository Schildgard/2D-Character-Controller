using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoveScript : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float changeDirectionTimer;
    [SerializeField]
    private float directionValue;
    [SerializeField]
    private float changeDirection;

    private Rigidbody2D rg;

    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        rg.velocity = Vector2.right * directionValue * moveSpeed;
        changeDirectionTimer += 1 * Time.deltaTime;

        if (changeDirectionTimer >= changeDirection) 
        {
            directionValue *= -1;
            changeDirectionTimer = 0;
        }


    }
}
