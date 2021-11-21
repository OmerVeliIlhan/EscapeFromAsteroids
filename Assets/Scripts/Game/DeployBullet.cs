using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployBullet : MonoBehaviour
{
    public GameObject bulletDiamond;
    public GameObject bulletNine;
    public GameObject bulletHexagon;
    public GameObject healthShot;
    public float respawnTime = 4.0f;
    public float healthRespawn = 5.0f;
    public GameObject leftPosition;
    public GameObject rightPosition;
    //public Transform DeploymentArea;
    private Vector2 screenBounds;
    // Start is called before the first frame update

    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * -1, Screen.height * -1, Camera.main.transform.position.z * -1));
        StartCoroutine(bulletWave());
        StartCoroutine(shotHealth());
    }
    private void spawnEnemy()
    {
        GameObject a = Instantiate(bulletDiamond) as GameObject;
        // a.transform.position = new Vector2(Random.Range(-DeploymentArea.position.x, DeploymentArea.position.x,0);
        a.transform.position = new Vector2(Random.Range(leftPosition.transform.position.x,rightPosition.transform.position.x), screenBounds.y * -0.5f);
    }
    private void spawnHealth()
    {
        GameObject b = Instantiate(healthShot) as GameObject;
        b.transform.position = new Vector2(Random.Range(leftPosition.transform.position.x, rightPosition.transform.position.x), screenBounds.y * -0.5f);
    }
      
    IEnumerator bulletWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();

        }
    }

    IEnumerator shotHealth()
    {
        
        while (true)
        {
            if(HealthHandler.instance.health < 3)
            {
                
                spawnHealth();
            }
            yield return new WaitForSeconds(healthRespawn);
            
            

        }
    }
}
