//https://leetcode.cn/problems/insert-delete-getrandom-o1/?envType=study-plan-v2&envId=top-interview-150

// special case, which could not implate as a lesson

namespace Exercise;
public class L380_insert_delete_getrandom_o1
{

}

public class RandomizedSet
{
    HashSet<int> hs;
    Random random = new Random();

    public RandomizedSet()
    {
        hs = new HashSet<int>();
    }

    public bool Insert(int val)
    {
        return hs.Add(val);
    }

    public bool Remove(int val)
    {
        return hs.Remove(val);
    }

    public int GetRandom()
    {
        return hs.ElementAt(random.Next(0,hs.Count));
    }
}