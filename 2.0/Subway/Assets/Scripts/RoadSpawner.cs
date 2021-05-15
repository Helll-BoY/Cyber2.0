using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public GameObject[] RoadBlockPrefabs;
    public GameObject StartBlock;
    public List<GameObject> cars = new List<GameObject>();

    public float startblockxpos;
   public float blockxPos = 0;
   public int blocksCount = 7;
  public float blockLength = 0;
    int safe = 120;
    public Transform playertransform;
    List<GameObject> CurrentBlocks = new List<GameObject>();
    List<GameObject> CurrentCars = new List<GameObject>();
    public static bool spawncar = false;
    void Start()
    {
        blockxPos = StartBlock.transform.position.x;
      //  blockLength = 90;
        
        startblockxpos = playertransform.transform.position.x + 40;
        for(int i = 0; i < blocksCount; i++)
        {
            SpawnBlock();

        }
        
    }

    
    void LateUpdate()
    {
        Check();
    }

    void Check()
    {
        if(CurrentBlocks[0].transform.position.x - playertransform.position.x < -70)
        {
            SpawnBlock();
            DestroyBlock();
        }
    }
    void SpawnBlock() {

        Vector3 blockpos;
        GameObject block = Instantiate(RoadBlockPrefabs[Random.Range(0,RoadBlockPrefabs.Length)], transform);
      if(CurrentBlocks.Count > 0)
        {
            blockpos = CurrentBlocks[CurrentBlocks.Count - 1].transform.position + new Vector3(blockLength , 0, 0);
        }
      else
        {
            blockpos = new Vector3(startblockxpos, 0, 0);
        }

        block.transform.position = blockpos;
        int a = Random.Range(0, 3);
        switch (a)
        {
            case 0: 
                {
                    
                    GameObject car = Instantiate(cars[Random.Range(0, cars.Count)], new Vector3(blockpos.x,blockpos.y + 1,-3),Quaternion.identity);
                     car.transform.rotation = new Quaternion(0, -180, 0, 0);
                    CurrentCars.Add(car);

                    GameObject carr = Instantiate(cars[Random.Range(0, cars.Count)], new Vector3(car.transform.position.x + Random.Range(1,17), blockpos.y + 1, -3), Quaternion.identity);
                    carr.transform.rotation = new Quaternion(0, -180, 0, 0);
                    CurrentCars.Add(carr);
                    break;
                }
            case 1:
                {
                    GameObject car = Instantiate(cars[Random.Range(0, cars.Count)], new Vector3(blockpos.x, blockpos.y + 1, 0),Quaternion.identity);
                    car.transform.rotation = new Quaternion(0,-180,0,0);
                    CurrentCars.Add(car);

                    GameObject carr = Instantiate(cars[Random.Range(0, cars.Count)], new Vector3(car.transform.position.x + Random.Range(1, 17), blockpos.y + 1, -3), Quaternion.identity);
                    carr.transform.rotation = new Quaternion(0, -180, 0, 0);
                    CurrentCars.Add(carr);
                    break;
                }
            case 2:
                {
                    GameObject car = Instantiate(cars[Random.Range(0, cars.Count)], new Vector3(blockpos.x, blockpos.y + 1, 3), Quaternion.identity) ;
                    car.transform.rotation = new Quaternion(0, -180, 0, 0);
                    CurrentCars.Add(car);
                    GameObject carr = Instantiate(cars[Random.Range(0, cars.Count)], new Vector3(car.transform.position.x + Random.Range(1, 17), blockpos.y + 1, -3), Quaternion.identity);
                    carr.transform.rotation = new Quaternion(0, -180, 0, 0);
                    CurrentCars.Add(carr);
                    break;
                }
                
        }
     
        CurrentBlocks.Add(block);
    }
    public IEnumerator wait()
    {
       yield return new WaitForSeconds(1);
    }
    void DestroyBlock()
    {
        Destroy(CurrentBlocks[0]);
        Destroy(CurrentCars[0]);
        CurrentCars.RemoveAt(0);
        CurrentBlocks.RemoveAt(0);
    }
}
