using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class script : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private GameObject character;
    private Vector2 mapSize;

    // Start is called before the first frame update
    void Start()
    {
        mapSize = new Vector2(tilemap.size.x, tilemap.size.y);
        Debug.Log(character.transform.position.x + ", " + character.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            int x = (int)Input.mousePosition.x;
            int y = (int)Input.mousePosition.y;
            Vector2 destination = new Vector2(x, y);
        }
    }

    private int distanceHeuristic(Vector2 pos1, Vector2 pos2, Vector2 dest)
    {
        float dist1 = Mathf.Sqrt(Mathf.Pow((pos1.x - dest.x), 2) + (Mathf.Pow((pos1.y - dest.y), 2)));
        float dist2 = Mathf.Sqrt(Mathf.Pow((pos2.x - dest.x), 2) + (Mathf.Pow((pos2.y - dest.y), 2)));
        return dist1 > dist2 ? 1 : -1;
    }

    private void a_star(Vector2 origin, Vector2 dest) 
    {

    }
}
