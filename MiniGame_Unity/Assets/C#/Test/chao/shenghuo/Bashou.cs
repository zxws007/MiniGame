using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bashou : MonoBehaviour {

	//private Animate animate; // 动画对象，用于捕捉动画状态
	private Vector3 originPos; // 起始位置
	private Vector3 originBoxColliderPos; // 碰撞体起始位置
	private SpriteRenderer renderer;
	private BoxCollider2D boxCollider2D; // 二维碰撞体
	private float[] frameDeltaXs;
	private bool isQte = false; // 是否正在QTE
	private bool isPulling = false; // 是否正在拉动
	private Vector3 mouseDownPos; // 拉动时的点击位置
	private int currFrameIdx = 0;
	private int prevFrameIdx = 0;
	private float currentPoints = 0; // 当前分数

	public Image best;
	public Image good;
	public Image normal;
	private int currLevel = 0; // 当前评价等级 0, 1, 2, 3
	public Sprite[] frameSprites;
	public float pullDeltaDis = 50; // 每次拉动变换帧数时的位移量
	public float pointsPerFrame = 1; // 每换一帧改变的分数值
	public float totalPoints = 200; // 总分数
	public float pointToDropPerSecond = 20; // 每秒掉的分数
	private float prevFlameIdx = 0; // 上一帧的idx
	public GameObject smallFire; // 小火
	public GameObject middleFire; // 中火
	public GameObject largeFire; // 大火
	public GameObject qteBlock; // qte滑块
	private SpriteRenderer qteBlockRenderer;
	public Sprite qteBlockStopSprite;
	public GameObject huohouText; // 火候
	public GameObject succeedButton; // 成功按钮
	public Transform[] qtePositions; // qte 的开始、中间、结束位置
	public Transform[] levelPositions; // 评分位置, 小、中、大火分割点
	private bool fireOn = false;
	private bool isOver = false; // 生火完成
	public static int totalScore = 0;

	// 设置每一帧应该所处的位置
	private void SetupFrameDetalXs()
    {
		originPos = transform.position;
		frameDeltaXs = new float[frameSprites.Length];
		frameDeltaXs[0] = 0;
		frameDeltaXs[1] = 0.23f;
		frameDeltaXs[2] = 0.625f;
		frameDeltaXs[3] = 0.885f;
		frameDeltaXs[4] = 1.135f;
		frameDeltaXs[5] = 1.270f;
    }

	// Use this for initialization
	void Start () {
		boxCollider2D = GetComponent<BoxCollider2D>();
		SetupFrameDetalXs();
		originBoxColliderPos = boxCollider2D.transform.position;
		renderer = GetComponent<SpriteRenderer>();
		qteBlockRenderer = qteBlock.GetComponent<SpriteRenderer>();
		SetFrame(0);
		best.enabled = false;
		good.enabled = false;
		normal.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!isOver)
		{
			if (isQte)
			{
				float pointsToUpdate = -pointToDropPerSecond * Time.deltaTime;
				if (currFrameIdx < prevFlameIdx)
				{
					pointsToUpdate += (prevFlameIdx - currFrameIdx) * pointsPerFrame;
					prevFlameIdx = currFrameIdx;
				}
				currentPoints += pointsToUpdate;
				bool isOver = false;
				if (currentPoints < 0)
				{
					fireOn = false;
					currentPoints = 0;
				}
				else if (currentPoints >= totalPoints)
				{
					currentPoints = totalPoints;
					isOver = true;
				}
				fireOn = true;
				UpdateFireStatus();
				qteBlock.transform.position = GetQteBlockPosition(currentPoints / totalPoints, qtePositions[0].position, qtePositions[1].position);

				// 完成生火
				if (isOver)
				{
					OverShenghuo();
				}
			}
		}
	}

	void OverShenghuo()
    {
		isOver = true;
		succeedButton.SetActive(true);
    }

	private void OnMouseDrag()
    {
		if (!isOver)
		{
			if (!isQte && !isPulling)
			{
				mouseDownPos = Input.mousePosition;
				isPulling = true;
			}
			else if (!isQte)
			{
				var currMousePos = Input.mousePosition;
				var currFrameIdx = (int)((currMousePos.x - mouseDownPos.x) / pullDeltaDis);
				if (currFrameIdx < 0) currFrameIdx = 0;
				else if (currFrameIdx >= frameSprites.Length) currFrameIdx = frameSprites.Length - 1;
				SetFrame(currFrameIdx);
				if (currFrameIdx == frameSprites.Length - 1)
				{
					SetIntoQTE();
				}
			}
			else
			{
				var currMousePos = Input.mousePosition;
				var currFrameIdx = (int)((currMousePos.x - mouseDownPos.x) / pullDeltaDis);
				if (currFrameIdx < 0) currFrameIdx = 0;
				else if (currFrameIdx >= frameSprites.Length) currFrameIdx = frameSprites.Length - 1;
				SetFrame(currFrameIdx);

			}
		}
    }

	private void OnMouseUp()
    {
		if (!isOver)
        {
			isPulling = false;
			qteBlockRenderer.sprite = qteBlockStopSprite;
			OverShenghuo();
			ShowLevel();
        } 
    }

	// 设置帧
	void SetFrame(int idx)
    {
		if (idx != currFrameIdx)
        {
			prevFlameIdx = currFrameIdx;
			currFrameIdx = idx;
        }
		transform.position = new Vector3(originPos.x + frameDeltaXs[idx], originPos.y, originPos.z);
		boxCollider2D.transform.position = new Vector3(originBoxColliderPos.x + frameDeltaXs[idx], originBoxColliderPos.y, originBoxColliderPos.z);
		renderer.sprite = frameSprites[idx];
    }

	// 开始qte
	void SetIntoQTE()
    {
		isQte = true;
        qteBlock.SetActive(true); // qte滑块
        huohouText.SetActive(true); // 火候
    }
    public static Vector3 GetQteBlockPosition(float t, Vector3 start, Vector3 end)
    {
		return new Vector3(t * (end.x - start.x) + start.x, start.y, start.z);
    }
	
	void UpdateFireStatus()
    {
		var currQteBlockPosX = qteBlock.transform.position.x;
        if (currQteBlockPosX < levelPositions[0].position.x)
        {
            if (fireOn)
                smallFire.SetActive(true);
            else
                smallFire.SetActive(false);
            middleFire.SetActive(false);
            largeFire.SetActive(false);
        }
        else if (currQteBlockPosX > levelPositions[0].position.x && currQteBlockPosX < levelPositions[1].position.x)
        {
            smallFire.SetActive(false);
            if (fireOn)
                middleFire.SetActive(true);
            else
                middleFire.SetActive(false);
            largeFire.SetActive(false);
        }
        else if (currQteBlockPosX > levelPositions[1].position.x)
        {
            smallFire.SetActive(false);
            middleFire.SetActive(false);
            if (fireOn)
                largeFire.SetActive(true);
            else
                largeFire.SetActive(false);
        }
    }

	// 显示评级
	void ShowLevel()
    {
		Image imgToShow = null;
		var currQteBlockPosX = qteBlock.transform.position.x;
		if (currQteBlockPosX < levelPositions[0].position.x)
        {
			imgToShow = normal;
			totalScore = 5;
        } else if (currQteBlockPosX > levelPositions[0].position.x && currQteBlockPosX < levelPositions[1].position.x)
        {
			imgToShow = good;
			totalScore = 8;
        } else if (currQteBlockPosX > levelPositions[1].position.x)
        {
			imgToShow = best;
			totalScore = 10;
        }
		imgToShow.enabled = true;
    }
}
