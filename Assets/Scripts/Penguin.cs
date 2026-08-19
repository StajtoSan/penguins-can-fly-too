using UnityEngine;

public class Penguin : MonoBehaviour
{
    [SerializeField] GameObject body;
    private float velocity;
    private float mass;


    public Rigidbody2D theRB;

    private void OnEnable()
    {
        velocity = Cannon.instance.velocity;
        mass = Cannon.instance.mass;
        theRB.mass = mass;

        Fly();
    }

    private Vector3 flyDirection;
    private Vector3 flySource;
    public void Fly()
    {
        flySource = Cannon.instance.transform.position;
        flyDirection = transform.position - flySource;
        theRB.AddForce(flyDirection * velocity, ForceMode2D.Impulse);

        for (int i = 0; i < 4; i++)
        {

        }
    }

}
