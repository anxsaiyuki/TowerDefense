using UnityEngine;

public class Enemy : MonoBehaviour
{
  public float speed = 10f;

  private Transform target;
  private int wavepointIndex = 0;

  void Start () {
    SetTargetWaypoint();
  }

  void Update () {
    Vector3 dir = target.position - transform.position;
    // The delta time is used to not depend on frame rate. It is according to the time
    // Normalized will make it a ration * the speed
    // Relative to world space
    transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

    if (Vector3.Distance(transform.position, target.position) <= 0.2f) {
      GetNextWaypoint();
    }
  }

  void SetTargetWaypoint () {
    target = Waypoints.points[wavepointIndex];
  }

  void GetNextWaypoint () {
    if (wavepointIndex >= Waypoints.points.Length - 1) {
      Destroy(gameObject);
      return;
    }
    wavepointIndex++;
    SetTargetWaypoint();
  }
}
