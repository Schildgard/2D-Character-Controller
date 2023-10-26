using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheckScript : MonoBehaviour
{
    public PlayerMoveScript _playerMoveScript;
    
    // Start is called before the first frame update
    void Start()
    {
        //& _playerMoveScript = GetComponent<PlayerMoveScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Debug.Log("isGrounded");
            _playerMoveScript.isGrounded = true;
            _playerMoveScript.jumpCharges = _playerMoveScript.maxJumpCharges;
            _playerMoveScript.jumpButton = false;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        _playerMoveScript.isGrounded = false;
    }
}
