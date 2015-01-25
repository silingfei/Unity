using UnityEngine;
using System.Collections;

public class AnimationCotrol : MonoBehaviour {

    private Animation target;
    public int id;
    public void Init(int id)
    {
        this.id = id;
    }

    void OnMouseDown()
    {
        AssetMgr.OpenAnimationState(id, this.gameObject);
    }
}
