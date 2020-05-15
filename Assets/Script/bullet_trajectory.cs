using UnityEngine;

public class bullet_trajectory : MonoBehaviour
{
	// Reference to the LineRenderer we will use to display the simulated path
	public LineRenderer sightLine;
 
	// Reference to the GameObject where the bullet will be Instantiated - we need the position and rotation of it
	public GameObject shootPoint;
 
	// Number of segments to calculate - more gives a smoother line
	public int segmentCount = 20;
 
	// Length scale for each segment
	public float segmentScale = 1;

	// Strength with which the bullet gets shot 
	private int fireStrength;

	private void Start()
	{
		fireStrength = gameObject.GetComponent<Cannon>().bulletSpeed;
	}
 
	void FixedUpdate()
	{
		simulatePath();
	}
 
	/// Simulate the path of a launched ball.
	/// Slight errors are inherent in the numerical method used.
	void simulatePath()
	{
		Vector3[] segments = new Vector3[segmentCount];
 
		// The first line point is wherever the player's cannon, etc is
		segments[0] = shootPoint.transform.position;
 
		// The initial velocity
		Vector3 segVelocity = shootPoint.transform.up * fireStrength * Time.deltaTime;

 
		for (int i = 1; i < segmentCount; i++)
		{
			// Time it takes to traverse one segment of length segScale (careful if velocity is zero)
			float segTime = (segVelocity.sqrMagnitude != 0) ? segmentScale / segVelocity.magnitude : 0;
 
			// Add velocity from gravity for this segment's timestep
			segVelocity = segVelocity + Physics.gravity * segTime;
 
			// Check to see if we're going to hit a physics object
			RaycastHit hit;
			if (Physics.Raycast(segments[i - 1], segVelocity, out hit, segmentScale))
			{
				// set next position to the position where we hit the physics object
				segments[i] = segments[i - 1] + segVelocity.normalized * hit.distance;
				// correct ending velocity, since we didn't actually travel an entire segment
				segVelocity = segVelocity - Physics.gravity * (segmentScale - hit.distance) / segVelocity.magnitude;
			}
			// If our raycast hit no objects, then set the next position to the last one plus v*t
			else
			{
				segments[i] = segments[i - 1] + segVelocity * segTime;
			}
		}
 
		// At the end, apply our simulations to the LineRenderer
		sightLine.positionCount = segmentCount;
		for (int i = 0; i < segmentCount; i++)
			sightLine.SetPosition(i, segments[i]);
	}
}