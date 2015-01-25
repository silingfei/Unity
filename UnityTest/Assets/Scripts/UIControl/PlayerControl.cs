using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
    public GameObject playerRoot;
    public int playerCount;
    void Awake()
    {
        if (playerRoot == null)
        {
            playerRoot = GameObject.Find("PlayerRoot");
            if (playerRoot == null)
            {
                throw new UnityException("the hierarchy is not PlayerRoot");
            }
        }
        playerCount = playerCount <= 0 ? 5 : playerCount;
    }

    void Start()
    {
        InstancePlayer();
    }


    private void InstancePlayer()
    {
        int xCount = playerCount / 2;
        int yCount = playerCount % 2 == 0 ? playerCount / 2 : (playerCount - playerCount / 2);
        for (int i = 0; i < xCount; i++)
        {
            for (int j = 0; j < yCount; j++)
            {
                GameObject go = Instantiate(GetRandomPlayer()) as GameObject;
                go.transform.parent = playerRoot.transform;
                go.transform.localPosition = new Vector3(i * 3, 0, j * 3);
            }
        }
    }

    private GameObject GetRandomPlayer()
    {
        string[] paths = { 
                        AssetMgr.MagmaDemon_Blue,AssetMgr.MagmaDemon_Green,AssetMgr.MagmaDemon_Orange,AssetMgr.MagmaDemon_Purple,
                        AssetMgr.FlowerMonster_Blue,AssetMgr.FlowerMonster_Brown,AssetMgr.FlowerMonster_Purple,AssetMgr.FlowerMonster_Red
                         };
        return Resources.Load(paths[Random.Range(0, paths.Length - 1)]) as GameObject;
    }
}
