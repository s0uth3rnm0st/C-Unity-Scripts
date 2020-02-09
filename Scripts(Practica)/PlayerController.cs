using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool canJump;

    // Start is called before the first frame update
    void Start()
    {
        //mueve el obj 5 unidades respecto al eje x de la ESCENA
        //gameObject.GetComponent<Transform>().position = new Vector3 (5,0,0);
        
        //mueve el obj 5 unidades a SU derecha
        gameObject.GetComponent<Transform>().position = new Vector3
            (gameObject.transform.position.x + 5, gameObject.transform.position.y, gameObject.transform.position.z);

    }

    // Update is called once per frame
    void Update()
    {
        /*gameObject.GetComponent<Transform>().position = new Vector3
            (gameObject.transform.position.x + 0.5f * Time.deltaTime, gameObject.transform.position.y, gameObject.transform.position.z);*/

        if(Input.GetKey("right"))
        {
            //sin fisicas:       gameObject.transform.Translate(1f * Time.deltaTime, 0, 0);
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(400f * Time.deltaTime, 0));
            gameObject.GetComponent<Animator>().SetBool("Moving", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        if (Input.GetKey("left"))
        {
            //sin fisicas:       gameObject.transform.Translate(-1f * Time.deltaTime, 0, 0);
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-400f * Time.deltaTime, 0));
            gameObject.GetComponent<Animator>().SetBool("Moving", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        if (!Input.GetKey("right") && !Input.GetKey("left"))
        {
            gameObject.GetComponent<Animator>().SetBool("Moving", false);
        }

        ManageJump();
    }

    void ManageJump()
    {
        if(Input.GetKeyDown("up") && canJump == true)
        {
            canJump = false;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 150f));//sin deltaTime porque se aplica en un unico frame
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "piso")
        {
            canJump = true;
        }
    }
}
