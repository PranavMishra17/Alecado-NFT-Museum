using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Threading.Tasks;

public class LoadNfts : MonoBehaviour
{
    public Image YourRawImage;

    RawImage img;

    public Sprite nftImg;

    public int ID;

    public string imgUrl; //

    public Texture imgTex; //

    public Material imgMat;

    public float texRatio = 0.0f; //

    public float imgWidth, imgHeight;
    public UnityEngine.Networking.UnityWebRequest.Result result;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DownloadImage(imgUrl));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DownloadImage(string MediaUrl)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
            Debug.Log(request.error);
        else
        {
            Debug.Log("Great Success");
            Qw();
        }

    }

    private async Task Qw()
    {
        CreateMaterials(await GetRemoteTexture(imgUrl));
    }

    public void CreateMaterials(Texture t)
    {

        Debug.Log("Creating material from: " + t);
        Debug.Log("Width " + t.width);
        Debug.Log("Height " + t.height);
        imgTex = t;

        //gameObject.GetComponent<RectTransform>().rect.size = imgWidth;
        // gameObject.rectTransform.sizeDelta = new Vector2(250, texRatio * 250);

        texRatio = (float)(t.height) / (float)(t.width);
        Debug.Log("Tex ratio " + texRatio);

        gameObject.GetComponent<MeshRenderer>().material.mainTexture = imgTex;

        if (texRatio >= 1) //portrait
        {
            gameObject.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f * texRatio);
        }
        else //landscape
        {
            gameObject.transform.localScale = new Vector3(0.5f, 0.25f, 0.5f * texRatio);
        }

    }

    public async Task<Texture2D> GetRemoteTexture(string url)
    {
        using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(url))
        {
            // begin request:
            var asyncOp = www.SendWebRequest();

            // await until it's done: 
            while (asyncOp.isDone == false)
                await Task.Delay(1000 / 30);//30 hertz
            Debug.Log("in getRT");
            // read results:
            if (www.isNetworkError || www.isHttpError)
            // if( www.result!=UnityWebRequest.Result.Success )// for Unity >= 2020.1
            {
                // log error:
#if DEBUG
                Debug.Log($"{www.error}, URL:{www.url}");
#endif

                // nothing to return on error:
                return null;
                Debug.Log("returning null");
            }
            else
            {
                // return valid results:
                return DownloadHandlerTexture.GetContent(www);
                Debug.Log("returning downloaded");
            }
        }
    }
}
