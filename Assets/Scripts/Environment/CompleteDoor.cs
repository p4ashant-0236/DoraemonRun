using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteDoor : MonoBehaviour
{
    private bool isUnlock;

    [SerializeField]
    private Sprite unlockedDoor;

    void Start()
    {
        isUnlock = false;
    }

    public void UnlockDoor()
    {
        transform.GetComponent<SpriteRenderer>().sprite = unlockedDoor;
        isUnlock = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && isUnlock)
        {
            Debug.Log("Complete");
        }
    }
}
