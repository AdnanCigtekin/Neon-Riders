using UnityEngine;

public class FlareControl : MonoBehaviour {
	/*
	 *	  SCRIPT DESCRIPTION
	 * Handles flare collission
	 * 
	 */

	private TrailRenderer trail;
	[SerializeField]
	private GameObject flareCollider;
	[SerializeField]
	private GameObject enemy;
    [SerializeField]
    private bool isPlayer = false;
    [SerializeField]
    private Datas dT;
	private void Start () {
		trail = GetComponent<TrailRenderer>();
        if (!isPlayer)
        {
            enemy = GameObject.Find("Player");
            flareCollider = GameObject.Find("FlareColliderEnemy");
        }
        dT = GameObject.Find("GlobalDataHolder").GetComponent<Datas>();
	}

	private void Update () {
		Vector3[] positions = new Vector3[1000];
		int size = trail.GetPositions(positions);

		int index = 0;
		float min = float.MaxValue;
		for (int i = 0;i < size;++i) {
            float distance = 0;
            if (!isPlayer && dT.Player != null)
                distance = Vector3.Distance(positions[i], enemy.transform.position);
			if (distance < min) {
				index = i;
				min = distance;
			}
		}

		flareCollider.transform.position = positions[index];
	}
}
