using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.UI;

public class MissionWaypoint : GameUnit
{
    public Image Img;
    public Character Target;
    public Transform TargetPos;
    public Vector3 offset;
    //public Camera MainCamera;
    public Image ArrowImage;
    public GameObject Arrow;
    public TextMeshProUGUI LevelText;
    public TextMeshProUGUI CharNameText;
    private void Update()
    {
        float minX = Img.GetPixelAdjustedRect().width / 2 + 50;
        float maxX = Screen.width - minX - 50;

        float minY = (Img.GetPixelAdjustedRect().height / 2) + 50;
        float maxY = Screen.height - minY - 50;

        Vector3 pos = Camera.main.WorldToScreenPoint(TargetPos.position + offset);

        if (pos.z < 0)
        {
            pos.y = Screen.height - pos.y;
            pos.x = Screen.width - pos.x;
        }

        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        

      
        pos.z = 0;
        Img.transform.position = pos;

        MoveArrow(pos.x, pos.y);
        MoveText(pos.x, pos.y);
    }
    public override void OnInit()
    {
        base.OnInit();
        Img.color = Target.Ren.material.color;
        ArrowImage.color = Target.Ren.material.color;
    }
    public void MoveArrow(float x, float y)
    {
        float minX = Img.GetPixelAdjustedRect().width / 2 + 50;
        float maxX = Screen.width - minX - 50;

        float minY = (Img.GetPixelAdjustedRect().height / 2) + 50;
        float maxY = Screen.height - minY - 50;

        Vector2 pos = new Vector2(x, y);
        Vector2 MiddlePosition = new Vector2(Screen.width, Screen.height);

        //Debug.Log("max x is: " + maxX);
        //Debug.Log("max y is: " + maxY);
        //Debug.Log("min y is: " + minY);
        //Debug.Log("min x is: " + minX);

        if (x > minX && x < maxX && y < maxY && y > minY)
        {
            ArrowImage.gameObject.SetActive(false);
        }
        else
        {
            ArrowImage.gameObject.SetActive(true);
        }
        //Debug.Log("camera is: " + MiddlePosition);
        Vector2 pos2 = new Vector2(pos.x - MiddlePosition.x/2, pos.y - MiddlePosition.y/2);
        Vector2 fromPostion2 = new Vector2(0, 1);
        float angle = Vector3.Angle(fromPostion2, pos2);
        //Debug.Log("angle is: " + angle);

        Vector3 cross = Vector3.Cross(fromPostion2, pos2);
        if (cross.z < 0) angle = -angle;
        Arrow.transform.localEulerAngles = new Vector3(0, 0, angle);
    }
    
    public void MoveText(float x, float y)
    {
        float minX = Img.GetPixelAdjustedRect().width / 2 + 50;
        float maxX = Screen.width - minX - 50;

        float minY = (Img.GetPixelAdjustedRect().height / 2) + 50;
        float maxY = Screen.height - minY - 50;

        Vector2 pos = new Vector2(x, y);
        Vector2 MiddlePosition = new Vector2(Screen.width, Screen.height);

        if (x > minX && x < maxX && y < maxY && y > minY)
        {
            CharNameText.gameObject.SetActive(true);
        }
        else
        {
            CharNameText.gameObject.SetActive(false);
        }

    }

    public void ChangeLevel(int level)
    {
        LevelText.text = Convert.ToString(level);
    }

}
