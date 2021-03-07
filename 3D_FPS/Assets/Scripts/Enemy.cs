using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private Transform player;

    private NavMeshAgent nav;

    [Header("Moving Speed"), Range(0, 30)]
    public float speed = 2.5f;
    [Header("Attack Range"), Range(2, 100)]
    public float rangeAttack = 5f;

    private void Awake()
    {
        player = GameObject.Find("玩家").transform;
        nav = GetComponent<NavMeshAgent>();
        nav.speed = speed;
        nav.stoppingDistance = rangeAttack;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawSphere(transform.position, rangeAttack);
    }

    private void Update()
    {
        Track();
    }

    private void Track()
    {
        nav.SetDestination(player.position);
    }
}
