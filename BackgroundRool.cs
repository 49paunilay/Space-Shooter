using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRool : MonoBehaviour
{
    public float scroolSpeed=0.1f;
    private MeshRenderer mesh_Render;
    private float Scroolbg;
    void Awake()
    {
        mesh_Render=GetComponent<MeshRenderer>();
        
    }


    void Update()
    {
        Scrool();
        
    }
    void Scrool(){
        Scroolbg = Time.time * scroolSpeed;
        Vector2 Offset = new Vector2(Scroolbg,0f);
        mesh_Render.sharedMaterial.SetTextureOffset("_MainTex",Offset);
        

    }
}
