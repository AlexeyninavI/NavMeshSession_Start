﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSpawnBlocks : MonoBehaviour
{
    // blocks
    public List<IceBlockObject> blocks = new List<IceBlockObject>();
    private static int N = 4;

    // default spawn block
    public int defaultSpawnBlock = 6;

    // Update
    private int updateCount = 0;
    private int updateTarget = 60 * 4; // 60 fps

    // Percent active block
    public int percent = 10;

    private bool isGenerated = false;

    public void AddCube(IceBlockObject obj)
    {
        blocks.Add(obj);
    }

    public void RemoveCube(IceBlockObject obj)
    {
        // TODO: add check block
        blocks.Remove(obj);
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("generateBlocks", 3, 3);
        isGenerated = true;
    }

    public void generateBlocks()
    {
        //Сначала заспавните нужные блоки
        int i = Random.Range(0, blocks.Count);
           // if (i == defaultSpawnBlock)
          //  {
           //     continue;
          //  }
            IceBlockObject targetBlock = blocks[i];
            int r = Random.Range(0, 101);

            // loh
            if (r >= percent)
            {
                List<IceBlockObject> list = GetConnectedBlocksInRadius(targetBlock, 30);
                if (list.Count > 1)
                {
                    targetBlock.setSwimming();
                    //targetBlock.unityObject.SetActive(false);
                }
                
            }
            else
            {
                
                List<IceBlockObject> list = GetConnectedBlocksInRadius(targetBlock, 30);
                {
                    targetBlock.setUp();
                  // targetBlock.unityObject.SetActive(true);
                }
            }
        

        // Проверьте одиночные блоки
        for (int j = 0; i < blocks.Count; i++)
        {
            targetBlock = blocks[j];
            List<IceBlockObject> list = GetConnectedBlocksInRadius(targetBlock, 30);
            if (list.Count == 0)
            {
                targetBlock.checkerSwim(false);
               //targetBlock.unityObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1) // Если игра не на паузе, то делай то, что делал...
        {
            updateCount++;
            if (updateCount >= updateTarget)
            {
                generateBlocks();
                updateCount = 0;
                return;
            }
        }
    }

    List<IceBlockObject> GetConnectedBlocksInRadius(IceBlockObject obj, float rangeSqr)
    {
        List<IceBlockObject> list = new List<IceBlockObject>();
        foreach (IceBlockObject ibo in blocks)
        {
            float distanceSqr = (obj.unityObject.transform.position - ibo.unityObject.transform.position).sqrMagnitude;
            if ((distanceSqr > 0) && (distanceSqr < rangeSqr))
            {
                if (ibo.isSwimming())
                {
                    list.Add(ibo);
                }
            }
        }
        return list;
    }
}
