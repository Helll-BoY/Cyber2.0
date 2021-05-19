using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public GameObject[] RoadBlockPrefabs;
    public GameObject StartBlock;
    public List<GameObject> cars = new List<GameObject>();
    public float tick = 7f ;
    public float startblockxpos;
   public float blockxPos = 0;
   public int blocksCount = 7;
  public float blockLength = 0;
    int safe = 120;
    public Transform playertransform;
    List<GameObject> CurrentBlocks = new List<GameObject>();
    List<GameObject> CurrentCars = new List<GameObject>();
    public static bool spawncar = false;

    public int previously = -1;

    public float gamescore;

    public Vector3 pr;
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

    
    public void FixedUpdate()
    {
        gamescore += Time.deltaTime;
      
        if(tick < 0)
        {
       
            SpawnVenicle();
            if (7f - (gamescore * 0.1f) > 0.7f)
            {
                tick = 7f - (gamescore * 0.1f);
            }
            else { tick = 0.7f; }
            Debug.Log(tick);
        }
        tick = tick - Time.deltaTime;
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

        int a = Random.Range(0, RoadBlockPrefabs.Length);
        if(a == previously)
        {
           a = Random.Range(0, RoadBlockPrefabs.Length);
            if (a == previously)
            {
                a = Random.Range(0, RoadBlockPrefabs.Length);

            }
            else { previously = a; }
        }
        else { previously = a; }

        GameObject block = Instantiate(RoadBlockPrefabs[a], transform);
      if(CurrentBlocks.Count > 0)
        {
            blockpos = CurrentBlocks[CurrentBlocks.Count - 1].transform.position + new Vector3(blockLength , 0, 0);
        }
      else
        {
            blockpos = new Vector3(startblockxpos, 0, 0);
        }

        block.transform.position = blockpos;
      

        pr = blockpos;
        CurrentBlocks.Add(block);
    }
    public IEnumerator wait()
    {
       yield return new WaitForSeconds(1);
    }
    
    public void SpawnVenicle() {
        int a = Random.Range(0, 3);

        int b = Random.Range(1, 4);
                    if(b == 1)
                    {
                        int aa = Random.Range(0, 3);
            if (aa == 0)
            {
                GameObject car = Instantiate(cars[Random.Range(0, cars.Count)], new Vector3(pr.x, pr.y + 3, 3), Quaternion.identity);
                car.transform.rotation = new Quaternion(0, -180, 0, 0);
            }
            if (aa == 1)
            {
                GameObject car = Instantiate(cars[Random.Range(0, cars.Count)], new Vector3(pr.x, pr.y + 3, 0), Quaternion.identity);
                car.transform.rotation = new Quaternion(0, -180, 0, 0);
            }
            if (aa == 2)
            {
                GameObject car = Instantiate(cars[Random.Range(0, cars.Count)], new Vector3(pr.x, pr.y + 3, -3), Quaternion.identity);
                car.transform.rotation = new Quaternion(0, -180, 0, 0);
            }
          
                    }
                    
                    if(b == 2)
                    {
            int aa = Random.Range(0, 3);
            int aaa = Random.Range(0, 3);
            if (aa == 0)
            {
                GameObject car = Instantiate(cars[Random.Range(0, cars.Count)], new Vector3(pr.x, pr.y + 3, 3), Quaternion.identity);
               
                car.transform.rotation = new Quaternion(0, -180, 0, 0);
            }
            if (aaa == 0)
            {
                GameObject carr = Instantiate(cars[Random.Range(0, cars.Count)], new Vector3(pr.x + Random.Range(5, 24), pr.y + 3, 3), Quaternion.identity) ;

                carr.transform.rotation = new Quaternion(0, -180, 0, 0);
            }
            if (aa == 1)
            {
                GameObject car = Instantiate(cars[Random.Range(0, cars.Count)], new Vector3(pr.x, pr.y + 3, 0), Quaternion.identity);
                car.transform.rotation = new Quaternion(0, -180, 0, 0);
            }
            if (aaa == 1)
            {
                GameObject carr = Instantiate(cars[Random.Range(0, cars.Count)], new Vector3(pr.x + Random.Range(5, 24), pr.y + 3, 0), Quaternion.identity);

                carr.transform.rotation = new Quaternion(0, -180, 0, 0);
            }
            if (aa == 2)
            {
                GameObject car = Instantiate(cars[Random.Range(0, cars.Count)], new Vector3(pr.x, pr.y + 3, 3), Quaternion.identity);
                car.transform.rotation = new Quaternion(0, -180, 0, 0);
            }
            if (aaa == 2)
            {
                GameObject carr = Instantiate(cars[Random.Range(0, cars.Count)], new Vector3(pr.x + Random.Range(5, 24), pr.y + 3, 3), Quaternion.identity);

                carr.transform.rotation = new Quaternion(0, -180, 0, 0);
            }
            
                       
                    }
                    

                   if(b == 3)
                    {
            int aa = Random.Range(0, 3);
            int aaa = Random.Range(0, 3);
            int aaaa = Random.Range(0, 3);
            if (aa == 0)
            {
                GameObject car = Instantiate(cars[Random.Range(0, cars.Count)], new Vector3(pr.x, pr.y + 3, 3), Quaternion.identity);

                car.transform.rotation = new Quaternion(0, -180, 0, 0);
            }
            if (aaa == 0)
            {
                GameObject carr = Instantiate(cars[Random.Range(0, cars.Count)], new Vector3(pr.x + Random.Range(5, 24), pr.y + 3, 3), Quaternion.identity);

                carr.transform.rotation = new Quaternion(0, -180, 0, 0);
            }
            if (aaaa == 0)
            {
                GameObject carrr = Instantiate(cars[Random.Range(0, cars.Count)], new Vector3(pr.x + Random.Range(5, 24), pr.y + 3, 3), Quaternion.identity);

                carrr.transform.rotation = new Quaternion(0, -180, 0, 0);
            }
            if (aa == 1)
            {
                GameObject car = Instantiate(cars[Random.Range(0, cars.Count)], new Vector3(pr.x, pr.y + 3, 0), Quaternion.identity);
                car.transform.rotation = new Quaternion(0, -180, 0, 0);
            }
            if (aaa == 1)
            {
                GameObject carr = Instantiate(cars[Random.Range(0, cars.Count)], new Vector3(pr.x + Random.Range(5, 24), pr.y + 3, 0), Quaternion.identity);

                carr.transform.rotation = new Quaternion(0, -180, 0, 0);

            }
            if (aaaa == 1)
            {
                GameObject carr = Instantiate(cars[Random.Range(0, cars.Count)], new Vector3(pr.x + Random.Range(5, 24), pr.y + 3, 0), Quaternion.identity);

                carr.transform.rotation = new Quaternion(0, -180, 0, 0);
            }
            if (aa == 2)
            {
                GameObject car = Instantiate(cars[Random.Range(0, cars.Count)], new Vector3(pr.x, pr.y + 3, -3), Quaternion.identity);
                car.transform.rotation = new Quaternion(0, -180, 0, 0);
            }
            if (aaa == 2)
            {
                GameObject carr = Instantiate(cars[Random.Range(0, cars.Count)], new Vector3(pr.x + Random.Range(5, 24), pr.y + 3, -3), Quaternion.identity);

                carr.transform.rotation = new Quaternion(0, -180, 0, 0);
            }
            if (aaaa == 2)
            {
                GameObject carr = Instantiate(cars[Random.Range(0, cars.Count)], new Vector3(pr.x + Random.Range(5, 24), pr.y + 3, -3), Quaternion.identity);

                carr.transform.rotation = new Quaternion(0, -180, 0, 0);
            }

        }


        /*     case 1:
                  {
                      int b = 3;//Random.Range(1, 4);
                      if (b == 1)
                      {
                          GameObject car = Instantiate(cars[Random.Range(0, cars.Count)], new Vector3(pr.x, pr.y + 1, -3), Quaternion.identity);
                          car.transform.rotation = new Quaternion(0, -180, 0, 0);
                      }

                      if (b == 2)
                      {
                          GameObject car = Instantiate(cars[Random.Range(0, cars.Count)], new Vector3(pr.x, pr.y + 1, -3), Quaternion.identity);
                          car.transform.rotation = new Quaternion(0, -180, 0, 0);
                          GameObject carr = Instantiate(cars[Random.Range(0, cars.Count)], new Vector3(car.transform.position.x + Random.Range(1, 25), pr.y + 1, -3), Quaternion.identity);
                          carr.transform.rotation = new Quaternion(0, -180, 0, 0);
                      }


                      if (b == 3)
                      {
                          GameObject car = Instantiate(cars[Random.Range(0, cars.Count)], new Vector3(pr.x, pr.y + 1, -3), Quaternion.identity);
                          car.transform.rotation = new Quaternion(0, -180, 0, 0);
                          GameObject carr = Instantiate(cars[Random.Range(0, cars.Count)], new Vector3(car.transform.position.x + Random.Range(1, 25), pr.y + 1, -3), Quaternion.identity);
                          carr.transform.rotation = new Quaternion(0, -180, 0, 0);
                          GameObject carrr = Instantiate(cars[Random.Range(0, cars.Count)], new Vector3(car.transform.position.x + Random.Range(1, 25), pr.y + 1, -3), Quaternion.identity);
                          carrr.transform.rotation = new Quaternion(0, -180, 0, 0);
                      }

                      break;
                  }
              case 2:
                  {
                      int b = Random.Range(1, 4);
                      if (b == 1)
                      {
                          GameObject car = Instantiate(cars[Random.Range(0, cars.Count)], new Vector3(pr.x, pr.y + 1, -3), Quaternion.identity);
                          car.transform.rotation = new Quaternion(0, -180, 0, 0);
                      }

                      if (b == 2)
                      {
                          GameObject car = Instantiate(cars[Random.Range(0, cars.Count)], new Vector3(pr.x, pr.y + 1, -3), Quaternion.identity);
                          car.transform.rotation = new Quaternion(0, -180, 0, 0);
                          GameObject carr = Instantiate(cars[Random.Range(0, cars.Count)], new Vector3(car.transform.position.x + Random.Range(1, 25), pr.y + 1, -3), Quaternion.identity);
                          carr.transform.rotation = new Quaternion(0, -180, 0, 0);
                      }


                      if (b == 3)
                      {
                          GameObject car = Instantiate(cars[Random.Range(0, cars.Count)], new Vector3(pr.x, pr.y + 1, -3), Quaternion.identity);
                          car.transform.rotation = new Quaternion(0, -180, 0, 0);
                          GameObject carr = Instantiate(cars[Random.Range(0, cars.Count)], new Vector3(car.transform.position.x + Random.Range(1, 25), pr.y + 1, -3), Quaternion.identity);
                          carr.transform.rotation = new Quaternion(0, -180, 0, 0);
                          GameObject carrr = Instantiate(cars[Random.Range(0, cars.Count)], new Vector3(car.transform.position.x + Random.Range(1, 25), pr.y + 1, -3), Quaternion.identity);
                          carrr.transform.rotation = new Quaternion(0, -180, 0, 0);
                      }

                      break;
                  }*/


    }
    void DestroyBlock()
    {
        Destroy(CurrentBlocks[0]);
       
     
        CurrentBlocks.RemoveAt(0);
    }
}
