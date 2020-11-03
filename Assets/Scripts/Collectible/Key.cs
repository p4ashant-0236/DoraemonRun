using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, Collectible
{
    [SerializeField]
    private AnimationCurve curve;

    public void Collect()
    {
        Destroy(transform.gameObject);
        GameObject.FindGameObjectWithTag("CompleteDoor").GetComponent<CompleteDoor>().UnlockDoor();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + curve.Evaluate(Time.time), transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Collect();
        }
    }
}
