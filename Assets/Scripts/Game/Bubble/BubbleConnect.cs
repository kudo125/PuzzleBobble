using UnityEngine;

public class BubbleConnect : MonoBehaviour
{
    private BubblePlaced _bubblePlaced = default;

    private BubblePosition _bubblePosition = default;

    /// <summary>
    /// 配列のゲームオーバーの境界位置
    /// </summary>
    private const int UPPER_LIMIT = 11;

    private float _xMove = default;

    private float _yMove = default;

    private bool _bubbleCollisionReady = default;

    /// <summary>
    /// 当たった先のオブジェクトの列が偶数（0）か奇数（1）
    /// </summary>
    private int EvenOdd = default;

    private void Start()
    {
        _bubblePlaced = GetComponent<BubblePlaced>();
        _bubblePosition = GetComponent<BubblePosition>();

        _xMove = CalculationVariables._xMove / 2;
        _yMove = CalculationVariables._yMove;

        _bubbleCollisionReady = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody bubuleRig = GetComponent<Rigidbody>();
        bubuleRig.velocity = new Vector3(0, 0, 0);

        float colX = collision.transform.GetComponent<Transform>().position.x;
        float colY = collision.transform.GetComponent<Transform>().position.y;

        BubblePosition colBubblePosition = collision.transform.GetComponent<BubblePosition>();

        int colBubblePositionI = colBubblePosition.GetBubblePositionI();
        int colBubblePositionJ = colBubblePosition.GetBubblePositionJ();



        int FrontBack = default;



        //当たった先のオブジェクトの横の配列位置が奇数の時
        if (colBubblePositionI % 2 != 0)
        {
            EvenOdd = 1;

            //当たった先のオブジェクトの縦の配列位置が右端の時
            if (colBubblePositionJ == 8)
            {
                FrontBack = 1;
            }
        }
        //当たった先のオブジェクトの横の配列位置が偶数の時
        else
        {
            EvenOdd = 0;

            //当たった先のオブジェクトの縦の配列位置が右端の時
            if (colBubblePositionJ == 7)
            {
                FrontBack = 1;
            }
        }

        //当たった先のオブジェクトの縦の配列位置が左端の時
        if (colBubblePositionJ == 1)
        {
            FrontBack = 2;
        }

        //配置済みのバブルに当たった時
        if (collision.transform.tag == Tags.PlACED && _bubbleCollisionReady)
        {
            //一度当たったらそれ以上は動かない
            _bubbleCollisionReady = false;

            _bubblePlaced.Placed();

            Vector3 upperLeftVec = new Vector3(colX - _xMove, colY + _yMove);
            Vector3 upperRightVec = new Vector3(colX + _xMove, colY + _yMove);
            Vector3 leftVec = new Vector3(colX - 2 * _xMove, colY);
            Vector3 rightVec = new Vector3(colX + 2 * _xMove, colY);
            Vector3 LowerLeftVec = new Vector3(colX - _xMove, colY - _yMove);
            Vector3 LowerRightVec = new Vector3(colX + _xMove, colY - _yMove);

            float upperLeft = AdjacentSellPosition(upperLeftVec);
            float upperRight = AdjacentSellPosition(upperRightVec);
            float left = AdjacentSellPosition(leftVec);
            float right = AdjacentSellPosition(rightVec);
            float LowerLeft = AdjacentSellPosition(LowerLeftVec);
            float LowerRight = AdjacentSellPosition(LowerRightVec);

            float minDistance = Mathf.Min(upperLeft, upperRight, left, right, LowerLeft, LowerRight);

            int bubblePosiI = default;

            //その値を見てくっつく場所を制御する
            //くっついたバブルの配列位置をこの下で決める
            if (upperLeft == minDistance)
            {
                if (EvenOdd == 0)
                {
                    transform.position = upperLeftVec;
                    _bubblePosition.SetBubblePosition(colBubblePositionI - 1, colBubblePositionJ);
                    bubblePosiI = colBubblePositionI - 1;
                }

                if (EvenOdd == 1 && FrontBack == 0 || EvenOdd == 1 && FrontBack == 1)
                {
                    transform.position = upperLeftVec;
                    _bubblePosition.SetBubblePosition(colBubblePositionI - 1, colBubblePositionJ - 1);
                    bubblePosiI = colBubblePositionI - 1;
                }
                else if (EvenOdd == 1 && FrontBack == 2)
                {
                    transform.position = upperRightVec;
                    _bubblePosition.SetBubblePosition(colBubblePositionI - 1, colBubblePositionJ);
                    bubblePosiI = colBubblePositionI - 1;
                }
            }
            else if (upperRight == minDistance)
            {
                if (EvenOdd == 0)
                {
                    transform.position = upperRightVec;
                    _bubblePosition.SetBubblePosition(colBubblePositionI - 1, colBubblePositionJ + 1);
                    bubblePosiI = colBubblePositionI - 1;
                }


                if (EvenOdd == 1 && FrontBack == 0 || EvenOdd == 1 && FrontBack == 2)
                {
                    transform.position = upperRightVec;
                    _bubblePosition.SetBubblePosition(colBubblePositionI - 1, colBubblePositionJ + 1);
                    bubblePosiI = colBubblePositionI - 1;
                }
                else if (EvenOdd == 1 && FrontBack == 1)
                {
                    transform.position = upperLeftVec;
                    _bubblePosition.SetBubblePosition(colBubblePositionI - 1, colBubblePositionJ);
                    bubblePosiI = colBubblePositionI - 1;
                }
            }
            else if (left == minDistance)
            {
                if (FrontBack != 2)
                {
                    transform.position = leftVec;
                    _bubblePosition.SetBubblePosition(colBubblePositionI, colBubblePositionJ - 1);
                    bubblePosiI = colBubblePositionI;
                }
            }
            else if (right == minDistance)
            {
                if (FrontBack != 1)
                {
                    transform.position = rightVec;
                    _bubblePosition.SetBubblePosition(colBubblePositionI, colBubblePositionJ + 1);
                    bubblePosiI = colBubblePositionI;
                }
            }
            else if (LowerLeft == minDistance)
            {
                if (EvenOdd == 0)
                {
                    transform.position = LowerLeftVec;
                    _bubblePosition.SetBubblePosition(colBubblePositionI + 1, colBubblePositionJ);
                    bubblePosiI = colBubblePositionI + 1;
                }


                if (EvenOdd == 1 && FrontBack == 0 || EvenOdd == 1 && FrontBack == 1)
                {
                    transform.position = LowerLeftVec;
                    _bubblePosition.SetBubblePosition(colBubblePositionI + 1, colBubblePositionJ - 1);
                    bubblePosiI = colBubblePositionI + 1;
                }
                else if (EvenOdd == 1 && FrontBack == 2)
                {
                    transform.position = LowerRightVec;
                    _bubblePosition.SetBubblePosition(colBubblePositionI + 1, colBubblePositionJ);
                    bubblePosiI = colBubblePositionI + 1;
                }
            }
            else
            {
                if (EvenOdd == 0)
                {
                    transform.position = LowerRightVec;
                    _bubblePosition.SetBubblePosition(colBubblePositionI + 1, colBubblePositionJ + 1);
                    bubblePosiI = colBubblePositionI + 1;
                }


                if (EvenOdd == 1 && FrontBack == 0 || EvenOdd == 1 && FrontBack == 2)
                {
                    transform.position = LowerRightVec;
                    _bubblePosition.SetBubblePosition(colBubblePositionI + 1, colBubblePositionJ);
                    bubblePosiI = colBubblePositionI + 1;
                }
                else if (EvenOdd == 1 && FrontBack == 1)
                {
                    transform.position = LowerLeftVec;
                    _bubblePosition.SetBubblePosition(colBubblePositionI + 1, colBubblePositionJ - 1);
                    bubblePosiI = colBubblePositionI + 1;
                }
            }
            GameStatus.GameStatusReactivePropety.Value = GameStatusEnum.ConnectionCheck;
        }
    }

    private float AdjacentSellPosition(Vector3 adjacentSellPosition)
    {
        return Vector3.Distance(this.transform.position, adjacentSellPosition);
    }

}
