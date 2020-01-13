using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject platform_prefab;
    private Vector3 last_position;
    private float size;
    [SerializeField]
    private BallController ball_controller;


    [Header("pickable game object")]
    [SerializeField]
    private GameObject diamond_prefab;

    public void Start()
    {
        last_position = platform_prefab.transform.position;
        size = platform_prefab.transform.localScale.x;
        for (int i = 0; i < 10; i++)
        {
            spawnPlatforms();
        }

        InvokeRepeating("spawnPlatforms",2f,0.2f);

    }

    public void spawnPlatforms()
    {
        if(ball_controller.is_gameOver)
        {
            CancelInvoke("spawnPlatforms");
            return;
        }




        float ran = Random.Range(0f, 1f);
        if(ran>0.5f)
        {
            spawnZ();
        }
        else
        {
            spawnX();
        }
       

    }



    public void spawnX()
    {

        Vector3 temp_position = last_position;
        temp_position.x = temp_position.x + size;
        Instantiate(platform_prefab,temp_position,Quaternion.identity);
        diamondGenerate(temp_position);
        last_position = temp_position;

    }
    public void spawnZ()
    {

        Vector3 temp_position = last_position;
        temp_position.z = temp_position.z + size;
        Instantiate(platform_prefab, temp_position, Quaternion.identity);
        diamondGenerate(temp_position);
        last_position = temp_position;
    }

    public void diamondGenerate(Vector3 position)
    {

        float diamond_probability = Random.Range(0f,1f);
        if(diamond_probability>=0.80f)
        {
            Instantiate(diamond_prefab, new Vector3(position.x, position.y + .5f, position.z),Quaternion.identity);

        }
        else
        {
            return;
        }

    }



}//platform spawner class
