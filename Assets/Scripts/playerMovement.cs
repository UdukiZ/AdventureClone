using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
//public GameObject textBox; // Attach your GameObject you'd like to active/deactive in the inspector
public Animator anim;
public float hf = 0.0f;
public float vf = 0.0f;
public GameObject NPC_orange;
public GameObject NPC_blue;
public GameObject textBox;
public GameObject textBox1;

bool keyGet = false;
public float movementSpeed = 1f;
public Vector2 movement;           //Movement Axis
public Rigidbody2D rigidbody;      //Player Rigidbody Component

public static string[] npcTexts = new string[3]
        {
            "I think I dropped the key somewhere east of here",
            "Great. My friend will tell you how to escape this place",
            "The exit is north of here, hidden behind a tree."
        };

void Start()
{
    rigidbody = this.GetComponent<Rigidbody2D>();
    anim = this.GetComponent<Animator>();
    textBox.SetActive(false);
    textBox1.SetActive(false);

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
   
      if(collision.gameObject.name == "NPC_orange" ){
         if (keyGet)
            {
               textBox.SetActive(true);
               textBox.GetComponentInChildren<TextMeshProUGUI>().text = npcTexts[1];
            }else{   
               textBox.SetActive(true);
               textBox.GetComponentInChildren<TextMeshProUGUI>().text = npcTexts[0];
                 
            }
      }else if(collision.gameObject.name == "NPC_blue" ){
         textBox1.SetActive(true);
         textBox1.GetComponentInChildren<TextMeshProUGUI>().text = npcTexts[2];
      }
         

     if(collision.gameObject.tag == "Key")
     {
        Object.Destroy(collision.gameObject);
        keyGet = true;
     }
     if(collision.gameObject.tag == "Door" && keyGet == true)
     {
        Object.Destroy(collision.gameObject);
     }
     if (collision.gameObject.tag == "Exit"){
         textBox.SetActive(false);
         SceneManager.LoadScene("StartScreen");
      }

}
   private void OnCollisionExit2D(Collision2D collision){
      textBox.SetActive(false);
      textBox1.SetActive(false);
   }
}