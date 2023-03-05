using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
public float movementSpeed = 1f;
public Vector2 movement;           //Movement Axis
public Rigidbody2D rigidbody;      //Player Rigidbody Component

void Start()
{
    rigidbody = this.GetComponent<Rigidbody2D>();
}

// Update is called once per frame
void Update() 
{
    movement.x = Input.GetAxisRaw("Horizontal");
    movement.y = Input.GetAxisRaw("Vertical");
}
private void FixedUpdate()
{
    rigidbody.MovePosition(rigidbody.position + movement * movementSpeed * Time.fixedDeltaTime);
}

void OnCollisionEnter2D(Collision2D col)
{
	Debug.Log("OnCollisionEnter2D");
}

}