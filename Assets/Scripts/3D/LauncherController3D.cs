using UnityEngine;

public class LauncherController3D : MonoBehaviour
{
    [SerializeField] private GameObject proyectilePrefab;
    [SerializeField] private float launchModifier;
    [SerializeField] private Transform launchPoint;
    [SerializeField] private GameObject point;
    private GameObject[] pointsList;
    [SerializeField] private int pointsCount;
    [SerializeField] private float spaceBetween;
    private Vector3 direction;
    private Camera mainCamera;

    private void Start()
    {
        pointsList = new GameObject[pointsCount];
        for (int i = 0; i < pointsCount; i++)
        {
            pointsList[i] = Instantiate(point, launchPoint.position, Quaternion.identity);
        }
        mainCamera = Camera.main;
    }

    private void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 mousePosition = hit.point;
            Vector3 launchPosition = transform.position;
            direction = mousePosition - launchPosition;
            transform.LookAt(mousePosition);

            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
            }

            for (int i = 0; i < pointsCount; i++)
            {
                pointsList[i].transform.position = CurrentPosition(i * spaceBetween);
            }
        }
    }

    private void Shoot()
    {
        GameObject proyectile = Instantiate(proyectilePrefab, launchPoint.position, Quaternion.identity);
        proyectile.GetComponent<Rigidbody>().velocity = direction.normalized * launchModifier;
    }

    private Vector3 CurrentPosition(float t)
    {
        return launchPoint.position + (direction.normalized * launchModifier * t) + (0.5f * Physics.gravity * (t * t));
    }
}
