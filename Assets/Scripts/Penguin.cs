using UnityEngine;

public class Penguin : MonoBehaviour
{
    [SerializeField] public float velocity;
    [SerializeField] public float mass;


    public Rigidbody2D theRB;
    private Vector3 flyDirection;
    private Vector3 flySource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
    }
    private void OnEnable()
    {
        mass = 10f;
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
