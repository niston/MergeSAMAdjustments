using System.ComponentModel;

// SAM Adjustment Merge Tool by niston

namespace MergeSAMAdjustments
{
    public static class BindingListMove
    {
        public static void Move<T>(this BindingList<T> list, int oldIndex, int newIndex)
        {
            var item = list[oldIndex];

            list.RemoveAt(oldIndex);

            list.Insert(newIndex, item);
        }
    }
}
