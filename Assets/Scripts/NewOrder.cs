using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewOrder : IComparer<User>
{
    public int Compare(User x, User y)
    {
        int compare = x.Name.CompareTo(y.Name);
        if (x.Name == y.Name)
        {
            return x.Age.CompareTo(y.Age);
        }
        return compare;
    }
}
