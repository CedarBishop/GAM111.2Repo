using UnityEngine;

public class FightersMoveToTarget : MonoBehaviour
{
    public string targetName;
    Transform target;
    public float speed = 0.01f;

    private void Start()
    {
        target = GameObject.Find(targetName).GetComponent<Transform>();
    }
    void Update()
    {
        if (Vector3.Distance(transform.position, target.position) > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position,target.position, speed);
        }
    }
}
