using UnityEngine;

public class AsteroidGenerator : MonoBehaviour
{
    private MeshFilter meshFilter;

    private float cubeSize = 5.0f;

    public void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();

        meshFilter.mesh = Generate();
    }

    // Use this for initialization
    public void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {

    }

    private Mesh Generate()
    {
        var mesh = new Mesh();

        mesh.vertices = new Vector3[8]
        {
            new Vector3(-cubeSize / 2, -cubeSize / 2, cubeSize / 2),
            new Vector3(-cubeSize / 2, cubeSize / 2, cubeSize / 2),
            new Vector3(cubeSize / 2, cubeSize / 2, cubeSize / 2),
            new Vector3(cubeSize / 2, -cubeSize / 2, cubeSize / 2),

            new Vector3(-cubeSize / 2, -cubeSize / 2, -cubeSize / 2),
            new Vector3(-cubeSize / 2, cubeSize / 2, -cubeSize / 2),
            new Vector3(cubeSize / 2, cubeSize / 2, -cubeSize / 2),
            new Vector3(cubeSize / 2, -cubeSize / 2, -cubeSize / 2),
        };

        mesh.triangles = new int[36]
        {
            2, 1, 0,
            0, 3, 2,

            4, 5, 6,
            6, 7, 4,

            6, 2, 3,
            3, 7, 6,

            0, 1, 5,
            5, 4, 0,

            5, 1, 2,
            2, 6, 5,
            
            7, 3, 0, 
            0, 4, 7,
        };

        return mesh;
    }
}
