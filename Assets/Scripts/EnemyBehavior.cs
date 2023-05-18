using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    public Transform player;
    public Transform patrolRoute;
    public List<Transform> locations;

    private int locationIndex = 0;
    private NavMeshAgent agent;
    private SphereCollider col;
    private GameBehavior _gameManager;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        col = GetComponent<SphereCollider>();
        player = GameObject.Find("Player").transform;
        _gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
        InitializePatrolRoute();
        MoveToNextPatrolLocation();
    }

    void Update()
    {
        if (agent.remainingDistance < 0.2f && !agent.pathPending)
        {
            MoveToNextPatrolLocation();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            agent.destination = player.position;
            agent.speed = agent.speed + 2f;
            col.radius = col.radius + 1f;
            Debug.Log("Player detected - attack!");
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            agent.speed = agent.speed - 2f;
            col.radius = col.radius - 1f;

            Debug.Log("Player out of range, resume patrol");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Bullet(Clone)")
        {
            _gameManager.E_HP -= 1;
            Debug.LogFormat("Critical hit!");
            if (_gameManager.E_HP == 0)
            {
                Destroy(this.gameObject);
                Debug.Log("Enemy down.");
            }
        }
        
        if (collision.gameObject.name == "Sphere(Clone)")
        {
            _gameManager.E_HP -= 2;
            Debug.LogFormat("Super Critical hit!");
            if (_gameManager.E_HP <= 0)
            {
                Destroy(this.gameObject);
                Debug.Log("Enemy down.");
            }
        }

    }

    void InitializePatrolRoute()
    {
        foreach (Transform child in patrolRoute)
        {
            locations.Add(child);
        }
    }
    
    void MoveToNextPatrolLocation()
    {
        if (locations.Count == 0)
            return;
        agent.destination = locations[locationIndex].position;
        locationIndex = (locationIndex + 1) % locations.Count;
    }

}