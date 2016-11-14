using UnityEngine;
using System.Collections;

public class ImageWWW : MonoBehaviour {

 
	public string url = "http://static.wixstatic.com/media/43be81_9316e0f433a1410fa305a86e749389f2.png_srz_1060_610_85_22_0.50_1.20_0.00_png_srz";
    IEnumerator Start() {
        WWW www = new WWW(url);
        yield return www;
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = www.texture;
    }
}
