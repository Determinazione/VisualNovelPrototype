using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;

[Serializable]
public class SetValueByYourself
{
    public bool CalculateAmountOfUnitByHand;
    public int AmountOfUnit;
}

public class SetValueByHandAttribute : PropertyAttribute
{
    public readonly int Minimum;
    public readonly int Maximum;

    public SetValueByHandAttribute (int minimum, int maximum)
    {
        Minimum = minimum;
        Maximum = maximum;
    }
}

[RequireComponent(typeof(ScrollRect))]
public class CircularScroll : MonoBehaviour
{
    [SetValueByHand(0, 30)]
    public SetValueByYourself CalculateByYourself;
    private RectTransform mScrollRectTransform;
    private ScrollRect mScrollRectComponent;
    [SerializeField]
    private VerticalLayoutGroup mLayoutGroupOfContent;
    [SerializeField]
    private RectTransform mContentRectTransform;
    [SerializeField]
    private RectTransform mUnitPrototype;
    private int mAmount;

    private void CalculateHowManyUnitShouldBeInstantiated()
    {
        if (CalculateByYourself.CalculateAmountOfUnitByHand)
        {
            mAmount = (int) (mContentRectTransform.rect.height / (mUnitPrototype.rect.height + mLayoutGroupOfContent.spacing));
        }
        else
        {
            mAmount = CalculateByYourself.AmountOfUnit;
        }
    }

    /// <summary>
    /// Instantiate a unit to the proper position in the hierachy.
    /// </summary>
    private void InstantiateUnit()
    {
        GameObject newUnit = Instantiate(mUnitPrototype.gameObject);
        newUnit.transform.SetParent(mContentRectTransform.transform);
    }

    private void ChangeUnitPosition()
    {

    }

    private void ChangeUnitShowingData()
    {

    }

    private void MoveSpecificUnitToCentre(int whichOne)
    {

    }
}
