using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorManager : MonoBehaviour
{
    public static SelectorManager Instance;
    [SerializeField] private GameObject minimapSelector;
    [SerializeField] private GameObject[] selectors;
    [SerializeField] private int firstSelectorPosition;
    
    public List<GameObject> AvailablePositions = new List<GameObject>();
    private int currentPosition = 0;

    private bool isOnMinimap;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);
    }

    private void Start()
    {
        minimapSelector.SetActive(false);
        DisableSelectors();
    }

    private void Update()
    {
        if(CameraManager.Instance.IsOnMinimap && !LevelManager.Instance.HasLose) MovePosition();
    }

    public void EnableSelectorPosition(int position)
    {
        AvailablePositions.Add(selectors[position]);
        if (CameraManager.Instance.IsOnMinimap && AvailablePositions.Count == 1) selectors[firstSelectorPosition].SetActive(true);
    }

    private void MovePosition()
    {
        if (AvailablePositions.Count > 0)
        {
            int positionsCount = AvailablePositions.Count - 1;
            
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                AudioManager.Instance.Seleccionalga();
                if (currentPosition == 0)
                {
                    AvailablePositions[currentPosition].SetActive(false);
                    currentPosition = positionsCount;
                    AvailablePositions[currentPosition].SetActive(true);
                }
                else if (AvailablePositions.Count > 1)
                {
                    AvailablePositions[currentPosition].SetActive(false);
                    currentPosition--;
                    AvailablePositions[currentPosition].SetActive(true);
                }
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                AudioManager.Instance.Seleccionalga();
                if (currentPosition == positionsCount)
                {
                    AvailablePositions[currentPosition].SetActive(false);
                    currentPosition = 0;
                    AvailablePositions[currentPosition].SetActive(true);
                }
                else if (AvailablePositions.Count > 1)
                {
                    AvailablePositions[currentPosition].SetActive(false);
                    currentPosition++;
                    AvailablePositions[currentPosition].SetActive(true);
                } 
            }
        }

        if (AvailablePositions.Count == 1 && LevelManager.Instance.CurrentLevel == 1) currentPosition = 1;
    }
    
    public void EnableMinimapSelector() { minimapSelector.SetActive(true); }
    public void DisableMinimapSelector() { minimapSelector.SetActive(false); }
    public void EnableSelectors() { selectors[currentPosition].SetActive(true); }
    public void DisableSelectors() { foreach (var selector in selectors) selector.SetActive(false); }
}
