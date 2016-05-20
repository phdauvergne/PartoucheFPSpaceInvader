using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
    // Firerate
    public float fireRate = 0.5F;
    public float fireSpeed = 15.0f;
    private float nextFire = 0.0F;

    // Shot
    public GameObject shot;
    public Transform shotSpawn;

    private GameController gameController;
    
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


    void Update()
    {
       //if (Input.GetButton("Fire1") && Time.time > nextFire && !gameController.getGameOver())
       //{
       //
       //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
       //    RaycastHit hit;
       //
       //    if (Physics.Raycast(ray, out hit, 5000))
       //    {
       //        // pause between to shots
       //        nextFire = Time.time + fireRate;
       //
       //        // instantiation of the shot and shotspawn position
       //        GameObject projectile = (GameObject)Instantiate(shot, shotSpawn.position, Quaternion.identity);
       //
       //        // direction of the shot
       //        projectile.transform.LookAt(hit.point);
       //        // speed of shot
       //        projectile.GetComponent<Rigidbody>().velocity = projectile.transform.forward.normalized * fireSpeed;
       //
       //    }
       //}

        if (Input.GetButton("Fire1") && Time.time > nextFire && !gameController.getGameOver())
        {
            float x = Input.mousePosition.x;
            float y = Input.mousePosition.y;
            Vector3 dir = new Vector3(x, y, -10.0f);

            // pause between to shots
            nextFire = Time.time + fireRate;

            // instantiation of the shot and shotspawn position
            GameObject projectile = (GameObject)Instantiate(shot, shotSpawn.position, Quaternion.identity);

            // direction of the shot
            projectile.transform.LookAt(dir);
            
            // Vector3 fwd = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset - new Vector3(0, 0, -Distance);
            // speed of shot
            projectile.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * fireSpeed;
        }

    }

}
