using LinkList;
using System;

namespace BaseCode
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 线性表
            LinkListDemo linkListDemo = new LinkListDemo();
            //linkListDemo.GetArrayValue();

            //MySingleLinkedList<int>.MySingleLinkedListTest();
            MyDoubleLinkedList<int>.MyDoubleLinkedListTest();
            #endregion
        }
    }
}
