using UnityEngine;
using Unity.Mathematics;
using UnityEngine.SceneManagement;
public class TargetLine : MonoBehaviour
{
    public static TargetLine instance;
    [SerializeField] private int simulatedViews;
    [SerializeField] private float width;
    private LineRenderer lr;
    private Scene simulatedScene;
    private PhysicsScene2D phisicsScene;

    public Transform indestructibleObjects;



    private void Start()
    {
        instance = this;
        lr = GetComponent<LineRenderer>();
        lr.material = new Material(Shader.Find("Sprites/Default"));
        PhiciscSimulationSceneCreator();
    }
    private void Update()
    {

    }
    void PhiciscSimulationSceneCreator()
    {
        simulatedScene = SceneManager.CreateScene("SimuScene", new CreateSceneParameters(LocalPhysicsMode.Physics2D));
        phisicsScene = simulatedScene.GetPhysicsScene2D();

        foreach (Transform obsticle in indestructibleObjects)
        {
            var tempObsticle = Instantiate(obsticle.gameObject, obsticle.position, obsticle.rotation);
            tempObsticle.GetComponent<Renderer>().enabled = false;
            SceneManager.MoveGameObjectToScene(tempObsticle, simulatedScene);
        }


    }
    public void PhisicsSimulation(GameObject body, Vector3 positoin, Transform barrel)
    {
        var tempObject = Instantiate(body.gameObject, positoin, barrel.transform.rotation);
        SceneManager.MoveGameObjectToScene(tempObject.gameObject, simulatedScene);

        lr.positionCount = simulatedViews;

        for (var i = 0; i < simulatedViews; i++)
        {
            phisicsScene.Simulate(Time.fixedDeltaTime*3);
            lr.SetPosition(i, tempObject.transform.position);
        }
        lr.widthMultiplier = width;
        Destroy(tempObject.gameObject);
    }


}


