using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool canJump;
    private float force;
    Quaternion defaultRotation = new Quaternion(0, 0, 0, 0);

    void Start()
    {

    }

    void Update()
    {
        //print(gameObject.GetComponent<Transform>().rotation.z);
        if(gameObject.GetComponent<Transform>().rotation.z > -0.75f && gameObject.GetComponent<Transform>().rotation.z < 0.75f)
        {
            if(Input.GetKey("right"))
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(force * Time.deltaTime, 0));
                gameObject.GetComponent<Animator>().SetBool("moving", true);
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            if (Input.GetKey("left"))
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-force * Time.deltaTime, 0));
                gameObject.GetComponent<Animator>().SetBool("moving", true);
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
            if (!Input.GetKey("right") && !Input.GetKey("left"))
            {
                gameObject.GetComponent<Animator>().SetBool("moving", false);
            }

            ManageJump();
        }
        else
        {
            if (Input.GetKey("space"))
            {
                gameObject.GetComponent<Transform>().rotation = defaultRotation;
            }
        }

        
    }

    private void ManageJump()
    {
        if(Input.GetKeyDown("up") && canJump == true)
        {
            canJump = false;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 40f));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Ground")
        {
            canJump = true;

            float rotation = collision.transform.rotation.z;
            //print(rotation);

            //Depending on the rotation, the player will apply more or less force
            //(should use FOR to calculate/map rotation and the force)
            if (rotation > 0.05f || rotation < -0.05f)
            {
                this.force = 190f;
            }
            else
            {
                this.force = 130;
            }
        }
    }
}
