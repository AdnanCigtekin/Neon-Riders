using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class SmoothFollow : MonoBehaviour
{

    public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    public Transform target;
    [SerializeField]
    private Datas dT;
    // Update is called once per frame


    void LateUpdate()
    {
        if (target)
        {
            Vector3 point = GetComponent<Camera>().WorldToViewportPoint(target.position);
            Vector3 delta = target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));

            Vector3 destination = new Vector3(target.position.x, target.position.y + 3, target.position.z - 5);
            if (dT.curEnemy != null && dT.curEnemy.position.z < target.position.z)
            {
                float dist = target.position.z - dT.curEnemy.position.z;
                destination = new Vector3((target.position.x + dT.curEnemy.position.x) / 2, target.position.y + 15, target.position.z - dist - 5);
            }
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
            //transform.position = new Vector3(transform.position.x, transform.position.y, destination.z);
            transform.LookAt(new Vector3(target.position.x, target.position.y + 1, target.position.z));
        }

    }


}