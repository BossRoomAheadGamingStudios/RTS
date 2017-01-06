using UnityEngine;
using System.Collections;

public class BasicNavigation : MonoBehaviour
{

    public Transform victim;
    public bool facingRight = false;

    private NavMeshAgent navComponent;

    // Use this for initialization
    void Start()
    {
        navComponent = GetComponent<NavMeshAgent>();
        navComponent.updateRotation = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (victim)
        {
            navComponent.SetDestination(victim.position);
            float h = navComponent.velocity.x;

            if (h > 0 && !facingRight)
                Flip();
            else if (h < 0 && facingRight)
                Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
