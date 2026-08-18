using UnityEngine;

public class Penguin : MonoBehaviour
{
    private float velocity;
    private float mass;


    public Rigidbody2D theRB;
    private Vector3 flyDirection;
    private Vector3 flySource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
    }
    private void OnEnable()
    {
        velocity = Cannon.instance.velocity;
        mass = Cannon.instance.mass;
        theRB.mass = mass;

        Fly();
    }

    // Update is called once per frame
    void Update()
    {


    }
    public void Fly()
    {
        flySource = Cannon.instance.transform.position;
        flyDirection = transform.position - flySource;
        theRB.AddForce(flyDirection * velocity, ForceMode2D.Impulse);
    }

}
