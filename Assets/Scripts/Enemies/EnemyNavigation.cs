using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Text;
using TMPro;

public class EnemyNavigation : MonoBehaviour
{
    //public GameObject[] paths;
    Vector3 destination;
    public NavMeshAgent Enemy;
    public Animator animator;
    public Transform target;

    public TextMeshProUGUI Gold;
    public TextMeshProUGUI healthText;

    private int gold = 0;
    public int Health = 100;
    int isDyingHash;

    // Start is called before the first frame update
    void Start()
    {
        Enemy = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        isDyingHash = Animator.StringToHash("IsDying");

        destination = Enemy.destination;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(destination, target.position) > 1f)
        {
            destination = target.position;
            Enemy.destination = destination;
        }
        //bool IsDying = animator.GetBool(isDyingHash);

        if (Health <= 0) 
        {
           if (animator != null)
           {
                animator.SetBool(isDyingHash, true);
                gold++;
                Gold.SetText("Gold: "+ gold);
                Destroy(gameObject);
            }
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        Health--;
    }
}
