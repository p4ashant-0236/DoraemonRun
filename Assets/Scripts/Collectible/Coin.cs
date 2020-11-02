using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour,Collectible
{
    [SerializeField]
    private AnimationCurve curve;

    public void Collect()
    {
        Destroy(transform.gameObject);
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y+curve.Evaluate(Time.time), transform.position.z);    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Collect();
        }
    }
}
