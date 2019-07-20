using UnityEngine;

public class AccelControl : MonoBehaviour {
	/*				
	 *				SCRIPT DESCRIPTION
	 * Gets attitude from gyroscope
	 * Calculates speed to side ways
	 * Sends speed to VehiclePhysics.cs
	 * 
	 *					CONSTANTS
	 * Feel free to change those for balance purposess
	 * 
	 * MAXACCEL:
	 * Type: float
	 * Definition: When phones tilt acceleration is more than
	 * MAXACCEL, script will send MAXSPEED as output
	 * 
	 * MINACCEL:
	 * Type: float
	 * Definition: When phones tilt is less than MINACCEL,
	 * script will send 0 speed as output (in Euler Angles)
	 * 
	 * MAXSPEED:
	 * Type: float
	 * Definition: The maximum speed output that the script can give
	 * 
	 */

	#region CONSTANTS

	[SerializeField]
	private const float MAXACCEL = 0.5f;
	[SerializeField]
	private const float MINACCEL = 0f;
	[SerializeField]
	private const float MAXSPEED = 30;

	#endregion

	[SerializeField]
	private VehiclePhysics vehiclePhysics;

	private float speed;

	private void Update () {
		// getting attitude
		float tiltAcceleration = Input.acceleration.x;

		// calculating speed
		if (tiltAcceleration > MAXACCEL || tiltAcceleration < -MAXACCEL)
			speed = MAXSPEED;
		else if (tiltAcceleration < MINACCEL && tiltAcceleration > -MINACCEL)
			speed = 0;
		else
			speed = (tiltAcceleration/MAXACCEL) * MAXSPEED;

		// sending speed output
		vehiclePhysics.setSideWaysSpeed(speed);
	}
}
