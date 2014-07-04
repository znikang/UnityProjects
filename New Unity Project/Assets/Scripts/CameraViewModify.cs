using UnityEngine;
using System.Collections;

public class CameraViewModify : MonoBehaviour
{
	public float m_Width = 16.0f; //畫面寬
    public float m_Height = 9.0f; //畫面高
    private float m_TargetAspect; //畫面的寬高比
	private int m_PreWidth, m_PreHeight; //上一次的視窗寬和高

	// Use this for initialization
	void Start()
	{

	}
	
	// Update is called once per frame
    void FixedUpdate()
	{
		if (m_PreWidth != Screen.width || m_PreHeight != Screen.height) { //如果目前的畫面寬或高和上一次的不一樣就執行
			m_PreWidth = Screen.width; //把目前的寬記起來
			m_PreHeight = Screen.height; //把目前的高記起來

			float windowAspect = (float)Screen.width / (float)Screen.height; //算出目前的畫面寬高比

            m_TargetAspect = m_Width / m_Height; //算出設定的寬高比

            float ScaleHeight = windowAspect / m_TargetAspect;  //以畫面的寬為主, 計算出高的縮放倍數
		
			Camera camera = GetComponent<Camera>(); //取得攝影機的Component
		
			if (ScaleHeight < 1.0f) { //如果高不大於一
				Rect rect = camera.rect;
			
				rect.width = 1.0f;
				rect.height = ScaleHeight;
				rect.x = 0;
				rect.y = (1.0f - ScaleHeight) / 2.0f; //除以2得到黑邊的高
			
				camera.rect = rect; //重設攝影機的ViewPort
			} else { 
				float ScaleWidth = 1.0f / ScaleHeight; //如果畫面寬度過寬, 高大於一, 就縮放寬
			
				Rect rect = camera.rect;
			
				rect.width = ScaleWidth;
				rect.height = 1.0f;
				rect.x = (1.0f - ScaleWidth) / 2.0f; //除以2得到黑邊的寬
				rect.y = 0;
			
				camera.rect = rect;
			}
		}
	}
}
