using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour
{
  private Transform target;

  [Header("Attributes")]
  public float range = 15f;
    // Fire Mechanism
  public float fireRate = 1f;
  private float fireCountDown = 0f;

  [Header("Setup Fields")]
  public Transform partToRotate;
  public Transform firePoint;
  public GameObject bulletPrefab;
  public string enemyTag = "Enemy";
  public float turnSpeed = 10f;


  // Used for initilization
  void Start() {
    InvokeRepeating("UpdateTarget", 0f, 0.5f);
  }

  // Update is called once per frame
  void Update () {
    if (target != null) {
      Vector3 direction = target.position - transform.position;
      // Quaternion for rotation
      Quaternion lookRotation = Quaternion.LookRotation(direction);
      // EulerAngles is converting Quaternion to the xyz rotations
      Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
      partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

      if (fireCountDown <= 0) {
        //Shoot bullet
        Shoot();
        fireCountDown = 1f / fireRate;
      }
      fireCountDown -= Time.deltaTime;
    }
  }

  void Shoot () {
    GameObject bulletGameObject = (GameObject) Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    Bullet bullet = bulletGameObject.GetComponent<Bullet>();

    if (bullet != null) {
      bullet.SetTarget(target);
    }
  }

  // Find the target and the closest one
  void UpdateTarget () {
    GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
    float shortestDistance = Mathf.Infinity;
    GameObject nearestEnemy = null;

    foreach ( GameObject enemy in enemies) {
      float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
      if (distanceToEnemy < shortestDistance) {
        shortestDistance = distanceToEnemy;
        nearestEnemy = enemy;
      }
    }

    if (nearestEnemy != null && shortestDistance <= range) {
      target = nearestEnemy.transform;
    } else {
      target = null;
    }
  }
  
  // Used to see the range 
  void OnDrawGizmosSelected () {
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(transform.position, range);
  }
}
