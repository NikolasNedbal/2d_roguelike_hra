using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enMov : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent agent;
    private Vector3 targetPosition;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        SetRandomTarget();
        StartCoroutine(FiveSeconds());
    }

    private IEnumerator FiveSeconds()
    {
        while (true)
        {
            SetRandomTarget();
            yield return new WaitForSeconds(5f);
        }
    }

    void Update()
    {
        
    }

    void SetRandomTarget()
    {
        Vector3 randomPoint = Random.insideUnitSphere * 10f;
        randomPoint += transform.position;
        UnityEngine.AI.NavMeshHit hit;
        UnityEngine.AI.NavMesh.SamplePosition(randomPoint, out hit, 10f, UnityEngine.AI.NavMesh.AllAreas);
        targetPosition = hit.position;

        if(targetPosition.x > gameObject.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        agent.SetDestination(targetPosition);
    }
}
