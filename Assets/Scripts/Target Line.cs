using UnityEngine;

public class TargetLine : MonoBehaviour
{
    private float force;
    private float mass;

    private float cannonAngle;
    public float width = 1.0f;

    private LineRenderer lr;

    private Vector3 startingPoint;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.material = new Material(Shader.Find("Sprites/Default"));
        Debug.Log(Physics2D.gravity);

    }
    // Update is called once per frame
    void Update()
    {
        // setting variables to calculate flight trajectory
        force = GetComponent<Penguin>().velocity;
        mass = GetComponent<Penguin>().mass;
        cannonAngle = Cannon.instance.cannonBarrel.transform.rotation.z;
        /*
         * **** useful phisics formulas ****
         * 
         * Fly speed
         *      v = (F*t)/m
         * Placement in x axis
         *      x = v*cos(a)*t
         * Placement in y axis
         *      y = (v*sin(a)*t)-(0.5*g*t^2)
         */

        startingPoint.x = Cannon.instance.cannonBarrelExit.transform.position.x;
        startingPoint.y = Cannon.instance.cannonBarrelExit.transform.position.y;

        //this I may make with for loop
        Vector3[] positions = new Vector3[3];
        positions[0] = new Vector3(startingPoint.x, startingPoint.y, 0.0f);
        positions[1] = new Vector3(0.0f, 2.0f, 0.0f);
        positions[2] = new Vector3(2.0f, -2.0f, 0.0f);
        lr.positionCount = positions.Length;
        lr.SetPositions(positions);
        AnimationCurve curve = new AnimationCurve();


        lr.widthMultiplier = width;
    }
}
