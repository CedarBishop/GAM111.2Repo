using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    Vector3 target;
    void Start()
    {
        transform.position = GameManager.instance.RetrievePosition();
        Debug.Log(transform.position);
        navMeshAgent = GetComponent<NavMeshAgent>();
        target = transform.position;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                target = hit.point;
            }
        }
        if (Vector3.Distance(transform.position, target) > Mathf.Epsilon)
        {
            navMeshAgent.SetDestination(target);
        }          
    }
}
