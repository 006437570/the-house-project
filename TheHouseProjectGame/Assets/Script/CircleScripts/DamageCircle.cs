using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCircle : MonoBehaviour
{
    //For future use
    //private static DamageCircle instance;

    //Circles
    private Transform circleTransform;
    [SerializeField] private Transform targetCircleTransform;

    //Current size/positon of circle
    [SerializeField] private float StartingCircleSize;
    [SerializeField] private float StartingTarCircleSize;
    [SerializeField] private Vector3 circleSize;
    [SerializeField] private Vector3 circlePosition;

    //Size to shrink to
    private Vector3 targetCircleSize;
    private Vector3 targetCirclePosition;

    //Speed and time for circle shrink
    [SerializeField] private float circleShrinkSpeed;
    [SerializeField] private float shrinkTimer;
    [SerializeField] private float maxTimer;

    private void Awake()
    {
        //instance = this;

        circleTransform = transform.Find("circle");

        //Set starting size and position
        SetCircleSize(new Vector3(0, 0), new Vector3(StartingCircleSize, StartingCircleSize));

        //Set first target circle's size and position
        SetTargetCircle(new Vector3(0, 0), new Vector3(StartingTarCircleSize, StartingTarCircleSize), shrinkTimer);
    }

    private void Update()
    {
        //Start timer
        shrinkTimer -= Time.deltaTime;

        //When to shrink
        if (shrinkTimer < 0)
        {

            //Calculate new size
            Vector3 sizeChangeVector = (targetCircleSize - circleSize).normalized;
            Vector3 newCircleSize = circleSize + sizeChangeVector * Time.deltaTime * circleShrinkSpeed;

            //Calculate new location
            Vector3 circleMoveDir = (targetCirclePosition - circlePosition).normalized;
            Vector3 newCirclePosition = circlePosition + circleMoveDir * Time.deltaTime * circleShrinkSpeed;

            //Shrink circle to new size and location
            SetCircleSize(newCirclePosition, newCircleSize);

            float distanceTestAmount = .1f;

            //If circle and target circle's sizes and position are near their target, shrink again
            if (Vector3.Distance(newCircleSize, targetCircleSize) < distanceTestAmount && Vector3.Distance(newCirclePosition, targetCirclePosition) < distanceTestAmount)
            {
                //Reduce max timer when ring closes
                maxTimer = maxTimer / 2;
                GenerateTargetCircle();
            }
        }
    }

    private void SetTargetCircle(Vector3 position, Vector3 size, float shrinkTimer)
    {
        this.shrinkTimer = shrinkTimer;

        //Set position and scale to target circle
        targetCircleTransform.position = position;
        targetCircleTransform.localScale = size;

        targetCirclePosition = position;
        targetCircleSize = size;
    }

    //Generate new circle-
    private void GenerateTargetCircle()
    {
        //RNG for size and postioon
        float shrinkSizeAmount = 5f;
        Vector3 generatedTargetCircleSize = circleSize - new Vector3(shrinkSizeAmount, shrinkSizeAmount);

        Vector3 generatedTargetCirclePosition = circlePosition + new Vector3(Random.Range(-shrinkSizeAmount, shrinkSizeAmount), 
            Random.Range(-shrinkSizeAmount, shrinkSizeAmount));
        //

        //Set to max timer
        shrinkTimer = maxTimer;

        SetTargetCircle(generatedTargetCirclePosition, generatedTargetCircleSize, shrinkTimer);
    }

    
    private void SetCircleSize(Vector3 position, Vector3 size)
    {
        circlePosition = position;
        circleSize = size;

        transform.position = position;
        circleTransform.localScale = size;

    }
}
