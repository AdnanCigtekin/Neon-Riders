using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehiclePhysics : MonoBehaviour {

    [SerializeField]
    [Tooltip("Put motorcycle model here!")]
    private Transform Graphics;

    private float curSideWaysSpeed;
    private float curForwardSpeed;

    [Header("Test Variables")]

    [Tooltip("Don't need to touch here if you are already manipulating speed values via other scripts. DEAFULT : 0")]
    [SerializeField]
    private float newSideWaysSpeed;
    [Tooltip("Don't need to touch here if you are already manipulating speed values via other scripts. DEAFULT : 0")]
    [SerializeField]
    private float newForwardSpeed;

    private float curRotation;
    private float newRotation;
    private Rigidbody rig;

    [Header("Acceleration Variables")]
    [SerializeField]
    private float SideWaysAcceleration;
    [SerializeField]
    private float ForwardAcceleration;
    [Tooltip("RECOMMENDED: Make this value higher than the 'Side Ways Acceleration' variable")]
    [SerializeField]
    private float RotationalAcceleration;
    [Space(10)]
    [Tooltip("Amount of maximum speed when the vehicle hits the wall and explodes, MIN: 0")]
    [SerializeField]
    private float OnImpactExplosionThreshold;
    [Header("Particles")]
    [SerializeField]
    private ParticleSystem[] Sparks;
    [SerializeField]
    private ParticleSystem ExplosionParticle;
    [SerializeField]
    private Datas dT;
    private void Start()
    {
        rig = GetComponent<Rigidbody>();
        dT = GameObject.Find("GlobalDataHolder").GetComponent<Datas>();
    }


    private void Update()
    {

        #region SPEED HANDLING

        curSideWaysSpeed = Mathf.Lerp(curSideWaysSpeed, newSideWaysSpeed, Time.deltaTime * SideWaysAcceleration);
        curForwardSpeed = Mathf.Lerp(curForwardSpeed, newForwardSpeed, Time.deltaTime * ForwardAcceleration);

        #endregion

        #region ROTATION HANDLING

        newRotation = -newSideWaysSpeed;//Might change this value in the final build
        curRotation = Mathf.Lerp(curRotation, newRotation, Time.deltaTime * RotationalAcceleration);
        curRotation = Mathf.Clamp(curRotation, -1, 1);
        Graphics.transform.rotation = Quaternion.AngleAxis(curRotation * 10, Graphics.forward);

        #endregion


    }
    private bool FoundWall = false;
    private void FixedUpdate()
    {
        rig.velocity = new Vector3(curSideWaysSpeed, rig.velocity.y, curForwardSpeed);
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.forward, out hit) && hit.collider.gameObject.tag == "Wall" && hit.distance < 5)
        {
            FoundWall = true;
        }
        else
        {
            FoundWall = false;
        }
        

    }

    private void OnCollisionStay(Collision col)
    {
        if(col.gameObject.tag == "Wall")
        {
            if (Mathf.Abs(curSideWaysSpeed) > OnImpactExplosionThreshold)
                DestroyMe();
            else if (FoundWall)
            {
                DestroyMe();
            }
            else
                StartEmittingSparks(col.transform);


        }
        rig.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionY;
    }


    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Wall")
        {
            StopEmittingSparks(col.transform);

        }
    }


    private void StopEmittingSparks(Transform reff)
    {
        float x = reff.position.x - transform.position.x;

        if (x < 0)//Wall is on the left
        {
            Sparks[0].Stop(true, ParticleSystemStopBehavior.StopEmitting);
            return;
        }
        //Wall is on the right
        Sparks[1].Stop(true, ParticleSystemStopBehavior.StopEmitting);
    }



    private void StartEmittingSparks(Transform reff)
    {
        float x = reff.position.x - transform.position.x;

        if (x < 0)//Wall is on the left
        {
            Sparks[0].Play();
            return;
        }
        //Wall is on the right
        Sparks[1].Play();
    }


    public void DestroyMe()
    {
        if (gameObject.name == "Player") dT.Player = null;
        Instantiate(ExplosionParticle, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }


    public void setForwardSpeed(float newSpeed)
    {
        newForwardSpeed = newSpeed;
    }

    public void setSideWaysSpeed(float newSpeed)
    {
        newSideWaysSpeed = newSpeed;
    }

    public float getForwardSpeed()
    {
        return newForwardSpeed;
    }

    public float getSidewaysSpeed()
    {
        return newSideWaysSpeed;
    }


}
