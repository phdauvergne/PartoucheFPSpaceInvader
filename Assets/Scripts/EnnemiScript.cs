using UnityEngine;
using System.Collections;

public class EnnemiScript : MonoBehaviour
{

    public GameObject explosion;
    private GameController gameController;
    public int scoreValue = 1;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }

        if (other.tag == "Ship")
        {
            gameController.loseHitPoint();

            Destroy(gameObject);
        } 
        
        if (other.tag == "Player")
        {
            gameController.loseHitPoint();

            Destroy(gameObject);
        }

        if (other.tag == "Shot")
        {
            gameController.addScore(scoreValue); 
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        Instantiate(explosion, transform.position, transform.rotation);
    }

    public Object getExplosion()
    {
        return explosion;
    }
}
