using UnityEngine;

public class PointThang : MonoBehaviour {
	/*				
	 *				SCRIPT DESCRIPTION
	 * Keeps score in SCORE (static int)
	 * Handles PointThang collision
	 * 
	 *					CONSTANTS
	 * Feel free to change those for balance purposess
	 * 
	 * SCOREINC:
	 * Type: int
	 * Definition: When vehicle collides with a PointThang
	 * SCORE is increased by SCOREINC
	 * 
	 */
	
	private static int SCORE = 0;

	#region CONSTANTS

	[SerializeField]
	private const int SCOREINC = 100;

	#endregion


	void OnTriggerEnter (Collider other) {
		if (other.tag == "Player") {
			SCORE += SCOREINC;
            Debug.Log(SCORE);
			Destroy(gameObject);
		}

	}
}
