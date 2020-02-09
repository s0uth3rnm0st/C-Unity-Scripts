using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //lo desactiva
        //gameObject.SetActive(false);

        ScoreManager.scoreManager.RaiseScore(1);

        //lo destruye
        Destroy(transform.parent.gameObject);
    }
}
