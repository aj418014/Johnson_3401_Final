using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentMotor : MonoBehaviour
{
    public float speed = 5.0f;
    Vector3 _target;
    NavMeshAgent _agent;
    public Transform targetObject;
    public Transform origin;
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();  
    }

    // Update is called once per frame
    void Update()
    {
        _agent.speed = speed;
        _agent.SetDestination(_target);
        if(Input.GetMouseButtonDown(0))
        {
            Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(cameraRay, out hit))
            {
                origin.position = transform.position;
                Debug.Log(hit.point);
                _target = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                targetObject.transform.position = _target;
            }
        }

    }
}
