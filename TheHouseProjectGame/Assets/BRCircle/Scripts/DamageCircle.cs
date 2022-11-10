using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCircle : MonoBehaviour
{
    private static DamageCircle instance;

    [SerializeField] private Transform targetCircleTransform;

    private Transform circleTransform;

    private float circleShrinkSpeed;
    private float shrinkTimer;
    
    private Vector2 circleSize;
    private Vector2 circlePosition;

    private Vector2 targetCircleSize;
    private Vector2 targetCirclePosition;

    private void Awake() {
        instance = this;

        circleShrinkSpeed = 5f;
        circleTransform = transform.Find("circle");

        SetCircleSize(new Vector2(10,10), new Vector2(0,0));

        SetTargetCircle(new Vector2(10,10), new Vector2(0,0), 5f);
    }

    private void Update (){
        shrinkTimer -= Time.deltaTime;

        if (shrinkTimer < 0){
        Vector2 sizeChangeVector = (targetCircleSize - circleSize).normalized;
        Vector2 newCircleSize = circleSize + sizeChangeVector * Time.deltaTime * circleShrinkSpeed;
        
        Vector2 circleMoveDir = (targetCirclePosition - circlePosition).normalized;
        Vector2 newCirclePosition = circlePosition + circleMoveDir * Time.deltaTime * circleShrinkSpeed;       
        SetCircleSize(newCirclePosition,newCircleSize);

        float distanceTestAmount = .1f;
        if (Vector2.Distance(newCircleSize, targetCircleSize) < distanceTestAmount && Vector2.Distance(newCirclePosition,targetCirclePosition) < distanceTestAmount){
                GenerateTargetCircle();
            }
        }
    }

    private void GenerateTargetCircle(){
        float shrinkSizeAmount = Random.Range(5f,40f);
        Vector2 generatedTargetCircleSize = circleSize - new Vector2(shrinkSizeAmount, shrinkSizeAmount);

        Vector2 generatedTargetCirclePosition = circlePosition + 
            new Vector2(Random.Range(-shrinkSizeAmount,shrinkSizeAmount), Random.Range(-shrinkSizeAmount,shrinkSizeAmount));

            float shrinkTime = Random.Range(1f,6f);

            SetTargetCircle(generatedTargetCirclePosition, generatedTargetCircleSize, shrinkTime);

    }

    private void SetCircleSize(Vector2 position, Vector2 size){
        circlePosition = position;
        circleSize = size;

        circleTransform.localScale = size;
    }

    private void SetTargetCircle (Vector2 position, Vector2 size, float shrinkTimer){
        this.shrinkTimer = shrinkTimer;

        targetCircleTransform.position = position;
        targetCircleTransform.localScale = size;

        targetCircleSize = size;
        targetCirclePosition = position;

    }

    private bool IsOutsideCircle (Vector2 position) {
        return Vector2.Distance(position, circlePosition) > circleSize.x * .5f;
    }

    public static bool IsOutsideCircle_Static(Vector2 position){
        return instance.IsOutsideCircle(position);
    }

}
