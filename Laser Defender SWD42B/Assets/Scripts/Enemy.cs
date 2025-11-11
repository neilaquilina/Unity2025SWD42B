using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] int health = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //get the DamageDealer component from the colliding object
        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
        //reduce health by the damage amount
        health -= damageDealer.GetDamage();

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
