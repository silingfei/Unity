using UnityEngine;
using System.Collections;

public class BtnAnimationClick : MonoBehaviour {

    private GameObject target;
    private string clipName;
    public void Init(GameObject target, string clipName)
    {
        this.target = target;
        this.clipName = clipName;
        this.GetComponentInChildren<UILabel>().text = clipName;
    }
    void OnClick()
    {
        target.GetComponent<Animation>().Play(clipName);
    }
}
