using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTextController : MonoBehaviour
{

    [SerializeField]int Speed=250;
    [SerializeField] float FeedTime=0.7f;

    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector3(0, Speed, 0));
        StartCoroutine(DestroyObject());
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(DestroyObject());
    }

    private IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(FeedTime);
        Destroy(this.gameObject);
    }
}
