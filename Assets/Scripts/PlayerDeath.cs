using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private Scoreing score;
    public GameObject deathParticles;
    private PlayerMoment playerMoment;
    private PlayerShoot playerShoot;
    private AsteroidSpawner spawner;

    private void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<AsteroidSpawner>();
        playerMoment = GetComponent<PlayerMoment>();
        playerShoot = GetComponent<PlayerShoot>();
        score = GameObject.FindGameObjectWithTag("GameScorel").GetComponent<Scoreing>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision != null)
        {
            if (collision.gameObject.CompareTag("Asteroid"))
            {
                Debug.Log("death");
                score.SendMessage("LoadHighScore");
                StartCoroutine(death());

            }
        }
    }

    private IEnumerator death()
    {
        playerMoment.SendMessage("DisableControls");
        playerShoot.SendMessage("DisableControls");
        GetComponent<SpriteRenderer>().enabled = false;
        Destroy(spawner.gameObject);
        Instantiate(deathParticles, transform.position, transform.rotation);
        yield return new WaitForSeconds(2f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Start");
    }
}
