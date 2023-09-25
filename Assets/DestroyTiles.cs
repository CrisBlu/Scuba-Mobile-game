using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DestroyTiles : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    public GameObject tilemapGameObject;
    public Tilemap tilemap;


    void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("touch");
        Vector2 hitPosition = Vector3.zero;
        if (tilemap != null && tilemapGameObject == collision.gameObject)
        {
            
            Debug.Log("touches");
            foreach (ContactPoint2D hit in collision.contacts)
            {
                hitPosition.x = transform.position.x; //+ playerStats.DashDirection.x;
                hitPosition.y = transform.position.y; // + playerStats.DashDirection.y;
                Debug.Log(hitPosition);
                tilemap.SetTile(tilemap.WorldToCell(hitPosition), null);
            }
        }
    }
    
}
