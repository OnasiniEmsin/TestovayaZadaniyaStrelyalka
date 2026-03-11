using System;

[Serializable]
public class SlotData
{
    public int[] blocked;

    public SlotData()
    {
        blocked=new int[30]{0,0,0,0,0,0,0,0,0,0,
                            0,0,0,0,0,1,1,1,1,1,
                            1,1,1,1,1,1,1,1,1,1};
    }
}
