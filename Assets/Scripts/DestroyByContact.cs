using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
    private GameController gameController;

    public GameObject explostion;
    public GameObject playerExplostion;
    public int score;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if(gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if(gameController == null)
        {
            Debug.Log("Cannot find 'Game Controller' script.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Boundary" || other.tag == "Enemy")
        {
            return;
        }
        if (explostion != null)
        {
            Instantiate(explostion, transform.position, transform.rotation);
        }
        if (other.tag == "Player")
        {
            Instantiate(playerExplostion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }
        gameController.AddScore(score);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }


}
