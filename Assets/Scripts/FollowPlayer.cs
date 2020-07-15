using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour 
{

	public Transform target;
    public Vector3 targetPosition;
	public Vector3 relativePosition;

	// Use this for initialization
	void Start () 
	{
        relativePosition = new Vector3(0, (target.transform.position.y - transform.position.y), 0); //target.transform.position - transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = target.transform.position - relativePosition;       
        
	}
	
	public void SetTarget(GameObject targetObject, Vector3 offset)
	{
        target = targetObject.transform;     
        
        relativePosition = (targetObject.transform.position + offset);
	}
}

