using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class BombScript : MonoBehaviour
{

    [SerializeField]public float rotateSpeed;
    Rigidbody2D rb2d;
    [SerializeField]GameObject Effect;
    [SerializeField] public Vector3 vector;
    [SerializeField] float ExplosionSecond;
    // Start is called before the first frame update
    async void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.AddForce(vector, ForceMode2D.Impulse);

        await UniTask.Delay((int)( ExplosionSecond*1000));
        Instantiate(Effect, this.transform.position, Quaternion.identity);
        GameObject.Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Transform transform = this.transform;
        transform.Rotate(0, 0, rotateSpeed);
    }
}
