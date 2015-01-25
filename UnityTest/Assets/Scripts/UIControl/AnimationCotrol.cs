using UnityEngine;
using System.Collections;

public class AnimationCotrol : MonoBehaviour {

    private Animation target;
    public int id;

    public int speed = 10;
    public float range = 1f;
    private Vector2 mrota = Vector2.zero;
    private Vector2 degrees = new Vector2(5f, 3f);
    private bool isDrag = false;

    Transform mTrans;
    Quaternion mQuater;

    void Start()
    {
        mTrans = transform;
        mQuater = mTrans.localRotation;
    }
    public void Init(int id)
    {
        this.id = id;
    }

    void OnMouseDown()
    {
        AssetMgr.OpenAnimationState(id, this.gameObject);
    }
    void OnMouseDrag()
    {
        //this.gameObject.transform.localRotation = Quaternion.Euler(0f, -0.5f * speed, 0f) * this.gameObject.transform.localRotation;
        mTrans.localRotation = Quaternion.Euler(0f, -0.5f * speed, 0f) * mTrans.localRotation;
    }

    void Update()
    {
        if (isDrag)
        {
            float delta = RealTime.deltaTime;
            Vector3 pos = Input.mousePosition;

            float halfWidth = Screen.width * 0.5f;
            float halfHeight = Screen.height * 0.5f;
            if (range < 0.1f) { range = 0.1f; }
            float x = Mathf.Clamp((pos.x - halfWidth) / halfWidth / range, -1f, 1f);
            float y = Mathf.Clamp((pos.y - halfHeight) / halfHeight / range, -1f, 1f);
            mrota = Vector2.Lerp(mrota, new Vector2(x, y), delta * 50f);
            mTrans.localRotation = mQuater * Quaternion.Euler(-mrota.y * degrees.y, mrota.x * degrees.x, 0f);
        }
    }
}
