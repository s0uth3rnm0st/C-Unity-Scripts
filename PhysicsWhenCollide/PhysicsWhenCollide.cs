using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsWhenCollide : MonoBehaviour
{
    private bool flag=false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.flag == false)
        {
            gameObject.GetComponent<Rigidbody2D>().Sleep();
        }
        else
        {
            gameObject.GetComponent<Rigidbody2D>().WakeUp();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            this.flag = true;
        }
    }
}
