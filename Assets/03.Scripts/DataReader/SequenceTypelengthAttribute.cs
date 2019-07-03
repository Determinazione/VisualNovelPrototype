using System;
using System.Collections;
using System.Collections.Generic;

public class SequenceTypelengthAttribute : Attribute
{
    private int mLength;

    public SequenceTypelengthAttribute(int length)
    {
        mLength = length;
    }

    public virtual int Length
    {
        get { return mLength; }
    }
}
