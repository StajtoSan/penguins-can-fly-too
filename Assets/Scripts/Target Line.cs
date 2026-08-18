using UnityEngine;
using Unity.Mathematics;
public class TargetLine : MonoBehaviour
{
    public float width = 1.0f;
    public int positionCount;
    private float force;
    private float mass;
    private float cannonAngle;
    private float velocity;


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
        force = Cannon.instance.velocity;
        mass = Cannon.instance.mass;
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
        velocity = (force * 0.01f) / mass;

        startingPoint.x = Cannon.instance.cannonBarrelExit.transform.position.x;
        startingPoint.y = Cannon.instance.cannonBarrelExit.transform.position.y;

        //this stiil is not working - needs adjustment
        Vector3[] positions = new Vector3[positionCount];
        positions[0] = startingPoint;
        for (int i = 1; i < positionCount; i++)
        {
            //calculating x position in time 
            float positionX = velocity * (Mathf.Cos(cannonAngle)) * i/3f;
            //calculating y position in time
            float positionY = (velocity * (Mathf.Sin(cannonAngle)) * i/3f)-(0.5f* (Physics.gravity.y) * math.pow((i/3f),2));
            Vector3 position = new(positionX, positionY, 0.0f);
            Debug.Log("X " +  positionX);
            Debug.Log("Y " + positionY);
            positions[i] = position;

        }

       
        lr.SetPositions(positions);
        AnimationCurve curve = new AnimationCurve();


        lr.widthMultiplier = width;
    }
}
