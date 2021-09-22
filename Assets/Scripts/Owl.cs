using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Owl : Bird
{
    [SerializeField]
    public float _explosionRange;
    public float _explosionForce;
    public LayerMask _affectedLayer;

    void explode()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, _explosionRange, _affectedLayer);
     
            foreach (Collider2D obj in objects)
            {
                Vector2 direction = obj.transform.position - transform.position;
                obj.GetComponent<Rigidbody2D>().AddForce(direction * _explosionForce);
            }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        explode();
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _explosionRange);
    }
}
