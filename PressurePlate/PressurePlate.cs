using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class PressurePlate : MonoBehaviour
{
    bool canPush = true;

    [SerializeField] private GameObject m_Obstacle;
    [SerializeField] private int m_DistanceY;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && canPush == true)
        {
            gameObject.GetComponent<Transform>().position = new Vector3
                (gameObject.transform.position.x, gameObject.transform.position.y-0.1f, gameObject.transform.position.z);

            canPush = false;

            m_Obstacle.GetComponent<Transform>().position = new Vector3
                (m_Obstacle.transform.position.x, (m_Obstacle.transform.position.y + m_DistanceY) * Time.deltaTime, m_Obstacle.transform.position.z);
        }
    }
}
