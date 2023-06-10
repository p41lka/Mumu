using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Puppy : MonoBehaviour
{
    [SerializeField] private Transform player;
    [Range(0f, 1f)] [SerializeField] private float woofChance = 0.1f;
    [SerializeField] private float woofPeriodInSec = 1.5f;
    private NavMeshAgent nav;
    private bool alive = true;
    

    // Start is called before the first frame update
    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        //player = FindObjectOfType<StarterAssets.FirstPersonController>().transform;
    }

    private void Start()
    {
        StartCoroutine(Woof());
    }

    private void Update()
    {
        if(alive)
            nav.SetDestination(player.position);
        
    }

    IEnumerator Woof()
    {
        while (alive)
        {
            if (Random.Range(0f, 1f) <= woofChance)
            {
                GetComponent<AudioSource>().Play();
            }
            yield return new WaitForSeconds(woofPeriodInSec);

        }
    }


    public void Kill()
    {
        alive = false;
        Destroy(GetComponent<NavMeshAgent>());
        
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, -90f);
    }

}


