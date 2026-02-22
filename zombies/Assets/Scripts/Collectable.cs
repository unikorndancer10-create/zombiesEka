using System;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class Collectable : MonoBehaviour
{
    private int scoreValue = 1;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindWithTag("Audio").GetComponent<AudioManager>();

    }
    private void OnTriggerEnter(Collider other)
    {
        Gamemanager.Instance.CollectItem(scoreValue);
        Debug.Log("Trigger with: " + other.name);

        audioManager.PlaySFX(audioManager.collect);
        Destroy(gameObject);
    }
}
