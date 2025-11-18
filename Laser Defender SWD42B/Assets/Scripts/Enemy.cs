using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] int health = 10;

    [SerializeField] float minimumTimeBetweenShots = 0.2f;
    [SerializeField] float maximumTimeBetweenShots = 3f;
    [SerializeField] float shotCounter;

    //visual effects
    [SerializeField] GameObject deathParticles;
    [SerializeField] float particleDuration = 1f;

    [SerializeField] GameObject laserPrefab;

    [SerializeField] AudioClip deathSound;
    [SerializeField] [Range(0, 1)] float deathSoundVolume = 0.75f;
    [SerializeField] AudioClip shootSound;
    [SerializeField][Range(0, 1)] float shootSoundVolume = 0.25f;

    void GenerateRandomTime()
    {
        shotCounter = Random.Range(minimumTimeBetweenShots, maximumTimeBetweenShots);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //get the DamageDealer component from the colliding object
        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
        //reduce health by the damage amount
        health -= damageDealer.GetDamage();
        damageDealer.Hit();

        if (health <= 0)
        {
            Destroy(gameObject);
            //spawn death particles
            GameObject explosion = Instantiate(deathParticles, transform.position, Quaternion.identity);
            Destroy(explosion, particleDuration);
            //play death sound
            AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);

        }
    }

    void CountdownAndShoot()
    {
        //when the shot counter reaches zero, fire
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            EnemyFire();
            //reset the shot counter to a new random time
            GenerateRandomTime();
        }
    }

    void EnemyFire()
    {
        //spawn a laser projectile that moves downwards
        GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);
        //move the laser downward
        laser.GetComponent<Rigidbody2D>().linearVelocityY = -3f;
        // Optionally, destroy the laser after a certain time to avoid clutter
        Destroy(laser, 5f);

        //play shoot sound
        AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //as soon as the enemy is created, generate a random time for the shot counter
        GenerateRandomTime();
    }

    // Update is called once per frame
    void Update()
    {
        CountdownAndShoot();
    }
}
