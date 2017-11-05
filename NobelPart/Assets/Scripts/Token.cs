using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Unity2DScriptを組む上での便利メソッド集の予定です
public class Token : MonoBehaviour {
    

    // プレハブ取得
    // プレハブは必ず”Resources/Prefabs/”に配置すること
    // ??はnull判定 nullの時??の右側を返す
    // asはキャスト演算子(GameObject)を変数の前に着けるのと一緒
    public static GameObject GetPrefab (GameObject prefab, string name)
    {
        return prefab ?? (prefab = Resources.Load("Prefabs/" + name) as GameObject);
    } 
   
    // インスタンスを生成してスクリプトを返す
    // where で指定した基底クラスを(この場合はToken)を実装しているクラスしか使えないよって意味だといいな
    public static Type CreateInstance<Type> (GameObject prefab, Vector3 p, float direction = 0.0f, float speed = 0.0f) where Type : Token
    {
        GameObject g = Instantiate(prefab, p, Quaternion.identity) as GameObject;
        Type obj = g.GetComponent<Type>();
        obj.SetVelocity(direction, speed);
        return obj;
    }

    public static Type CreateInstance2<Type> (GameObject prefab, float x, float y, float direction = 0.0f, float speed = 0.0f) where Type : Token
    {
        Vector3 pos = new Vector3(x, y, 0);
        return CreateInstance<Type>(prefab, pos, direction, speed);
    }

    //X座標
    public float X
    {
        get { return transform.position.x; }
        set
        {
            Vector3 pos = transform.position;
            pos.x = value;
            transform.position = pos;
        }
    }

    //Y座標
    public float Y
    {
        get { return transform.position.y; }
        set
        {
            Vector3 pos = transform.position;
            pos.y = value;
            transform.position = pos;
        }
    }

    //コンポーネントのX座標加速度
    public float VX
    {
        get { return GetComponent<Rigidbody2D>().velocity.x; }
        set
        {
            Vector2 v = GetComponent<Rigidbody2D>().velocity;
            v.x = value;
            GetComponent<Rigidbody2D>().velocity = v;
        }
    }

    //コンポーネントのy座標加速度
    public float VY
    {
        get { return GetComponent<Rigidbody2D>().velocity.y; }
        set
        {
            Vector2 v = GetComponent<Rigidbody2D>().velocity;
            v.y = value;
            GetComponent<Rigidbody2D>().velocity = v;
        }
    }

    //スケール値(X)
    public float ScaleX
    {
        get { return transform.localScale.x; }
        set
        {
            Vector3 scale = transform.localScale;
            scale.x = value;
            transform.localScale = scale;
        }
    }
    //スケール値(Y)
    public float ScaleY
    {
        get { return transform.localScale.y; }
        set
        {
            Vector3 scale = transform.localScale;
            scale.y = value;
            transform.localScale = scale;
        }
    }

    //スケール値を加算する
    public void AddScale (float d)
    {
        Vector3 scale = transform.localScale;
        scale.x += d;
        scale.y += d;
        transform.localScale = scale;
    }

    //スケール値を乗算する
    public void MulScale(float d)
    {
        transform.localScale *= d;
    }

    //コンポーネントに移動量を与える
    public void SetVelocity(float direction, float speed)
    {
        Vector2 v;
        v.x = Mathf.Cos(Mathf.Deg2Rad * direction) * speed;
        v.y = Mathf.Sin(Mathf.Deg2Rad * direction) * speed;
        GetComponent<Rigidbody2D>().velocity = v;
    }

    //移動量を乗算する
    public void MulVelocity (float d)
    {
        GetComponent<Rigidbody2D>().velocity *= d;
    }

    //画面の左下の座標を取得する
    public Vector2 GetWorldMin()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(Vector2.zero);
        return min;
    }

    //画面の右上の座標を取得する
    public Vector2 GetWorldMax()
    {
        Vector2 max = Camera.main.ViewportToWorldPoint(Vector2.one);
        return max;
    }

    //画面内に収めるようにする
    public void ClampScreen()
    {
        Vector2 min = GetWorldMin();
        Vector2 max = GetWorldMax();
        Vector2 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        transform.position = pos;

    }
}
