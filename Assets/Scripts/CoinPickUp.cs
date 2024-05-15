using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour
{
    [SerializeField] AudioClip pickupSound;
    [SerializeField] int pointToAdd = 100;
    bool hasCollected = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && !hasCollected)
        {
            hasCollected = true;
            FindObjectOfType<GameSession>().ProcessScore(pointToAdd);
            AudioSource.PlayClipAtPoint(pickupSound, Camera.main.transform.position);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
