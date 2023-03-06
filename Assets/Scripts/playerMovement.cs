using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using TextMeshProUGUI;

public class playerMovement : MonoBehaviour
{
//public GameObject textBox; // Attach your GameObject you'd like to active/deactive in the inspector
public Animator anim;
public float hf = 0.0f;
public float vf = 0.0f;

//public GameObject textBox;
bool keyGet = false;
public float movementSpeed = 1f;
public Vector2 movement;           //Movement Axis
public Rigidbody2D rigidbody;      //Player Rigidbody Component

void Start()
{
    rigidbody = this.GetComponent<Rigidbody2D>();
    anim = this.GetComponent<Animator>();

}

// Update is called once per frame
void Update() 
{
    movement.x = Input.GetAxisRaw("Horizontal");
    movement.y = Input.GetAxisRaw("Vertical");

     movement.x = Input.GetAxisRaw("Horizontal");
    movement.y = Input.GetAxisRaw("Vertical");

    hf = movement.x > 0.01f ? movement.x : movement.x < -0.01f ? 1 : 0;
    vf = movement.y > 0.01f ? movement.y : movement.y < -0.01f ? 1 : 0;
    if (movement.x < -0.01f)
    {
        this.gameObject.transform.localScale = new Vector3(-1, 1, 1);
    } else
    {
        this.gameObject.transform.localScale = new Vector3(1, 1, 1);
    }

    anim.SetFloat("Horizontal", hf);
    anim.SetFloat("Vertical", movement.y);
    anim.SetFloat("Speed", vf);
}
private void FixedUpdate()
{
    rigidbody.MovePosition(rigidbody.position + movement * movementSpeed * Time.fixedDeltaTime);
}

private void OnCollisionEnter2D(Collision2D collision){
   Debug.Log("ah");
      // if(collision.gameObject.name == "NPC_orange"){
      //    //textBox.Component.GetComponent<SpriteRenderer>().enabled = false;
      //    //isRendererEnabled = false;
      //    if(keyGet == true){
      //       textBox.SetActive(true);
      //       textBox.GetComponentinChildren<TextMeshProUGUI>().text = "Great. My friend will tell you how to escape this place";
      //    }
      // }

     if(collision.gameObject.tag == "Key")
     {
        Destroy(collision.collider.gameObject);
        keyGet = true;
     }
     if(collision.gameObject.tag == "Door" && keyGet == true)
     {
        Object.Destroy(collision.gameObject);
     }
 }

}