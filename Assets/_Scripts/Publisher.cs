using System.Collections.Generic;
using UnityEngine;

public abstract class Publisher : MonoBehaviour{

    protected List<Subscriber> subs = new List<Subscriber>();

    public void Add(Subscriber sub)
    { subs.Add(sub); }

    public void Remove(Subscriber sub)
    { subs.Remove(sub); }

    public void UpdateSubs() {
        foreach (Subscriber sub in subs)
        {
            sub.UpdateSelf();
        }
    }
}
