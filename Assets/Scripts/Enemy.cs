using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 2.0f;

    private Transform targetCamera;
    [SerializeField] private WorldMovement worldMovement;
    [SerializeField] private RockPaperScissorsEncounter encounter;

    private bool hasReachedCamera = false;

    void Start()
    {
        targetCamera = Camera.main.transform;
    }

    void Update()
    {
        if (hasReachedCamera)
            return;

        // go to camera's x and z position
        Vector3 targetPosition = new Vector3(
            targetCamera.position.x + 2.5f,
            transform.position.y,
            targetCamera.position.z
        );

        // move to camera's position
        float step = moveSpeed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPosition,
            step
        );

        // if we are close enough to the camera, trigger ReachedCamera()
        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            ReachedCamera();
        }
    }

    void ReachedCamera()
    {
        hasReachedCamera = true;

        Debug.Log("Enemy reached camera!");

        worldMovement.StopWorld();

        encounter.StartEncounter();
    }
}