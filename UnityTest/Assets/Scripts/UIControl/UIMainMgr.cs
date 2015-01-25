using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIMainMgr : MonoBehaviour
{
    public GameObject animaTarget;
    public GameObject rightAnimationCotrol;
    public UITable table;

    void Awake()
    {

    }
    void OnEnable()
    {
        AssetMgr.OpenAnimationStateHandler += AssetMgr_OpenAnimationStateHandler;
    }

    bool AssetMgr_OpenAnimationStateHandler(int id, GameObject target)
    {
        if (rightAnimationCotrol.activeSelf == false)
        {
            rightAnimationCotrol.SetActive(true);
        }
        if (table.GetChildList().Count > 0)
        {
            foreach (var item in table.GetChildList())
            {
                Destroy(item.gameObject);
            }
        }
        foreach (AnimationState item in target.GetComponent<Animation>())
        {
            GameObject go = Resources.Load(AssetMgr.AnimationStatePath) as GameObject;
            GameObject obj = NGUITools.AddChild(table.gameObject, go);
            obj.GetComponent<BtnAnimationClick>().Init(target, item.clip.name);
        }

        if (table != null) { table.repositionNow = true; }
        if (table.transform.parent.GetComponent<UIScrollView>() != null)
        {
            table.transform.parent.GetComponent<UIScrollView>().ResetPosition();
        }

        return false;
    }
    void OnDisable()
    {
        AssetMgr.OpenAnimationStateHandler -= AssetMgr_OpenAnimationStateHandler;
    }
    public void RandomPlayClip()
    {
        List<string> clips = new List<string>();
        foreach (AnimationState item in animaTarget.GetComponent<Animation>())
        {
            clips.Add(item.name);
        }
        animaTarget.GetComponent<Animation>().Play(clips[Random.Range(0, clips.Count - 1)]);
    }
}
