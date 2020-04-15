using System;
using System.Collections.Generic;
using System.Text;

namespace LinkList
{
    /// <summary>
    /// 单链表
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MySingleLinkedList<T>
    {
        #region 链表
        //链表就是有N个节点连接而成的线性表，若节点中包含一个指针域就是单链表，有两个就是双向链表
        private int count;//长度
        private Node<T> head;//头结点

        public MySingleLinkedList()
        {
            this.count = 0;
            this.head = null;
        }

        public int Count
        {
            get { return this.count; }
        }
        public T this[int index]
        {
            get
            {
                return GetNodeByIndex(index).Item;
            }
            set
            {
                this.GetNodeByIndex(index).Item = value;
            }
        }
        /// <summary>
        /// 根据索引获取节点
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private Node<T> GetNodeByIndex(int index)
        {
            if (index < 0 || index >= this.count)
            {
                throw new ArgumentOutOfRangeException("index", "索引超出范围");
            }
            Node<T> node = this.head;//索引为0为头指针
            for (int i = 0; i < index; i++)
            {
                node = node.Next;
            }
            return node;
        }
        /// <summary>
        /// 在结尾插入新节点
        /// </summary>
        /// <param name="value"></param>
        public void Add(T value)
        {
            Node<T> node = new Node<T>(value);
            if (this.head == null)
            {
                this.head = node;
            }
            else
            {
                Node<T> lastNode = GetNodeByIndex(this.count - 1);//获取最后一个节点
                lastNode.Next = node;
            }
            this.count++;
        }
        /// <summary>
        /// 移除指定位置的节点
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            //移除头指针
            if (index == 0)
            {
                this.head = this.head.Next;
            }
            else
            {
                Node<T> preNode = GetNodeByIndex(index - 1);//获取指定位置指针的前一个节点
                if (preNode == null)
                {
                    throw new ArgumentOutOfRangeException("index", "索引超出范围");
                }
                Node<T> delNode = preNode.Next;
                preNode.Next = delNode?.Next;
            }
            this.count--;
        }
        /// <summary>
        /// 在指定位置插入
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void Insert(int index, T value)
        {
            Node<T> currNode = new Node<T>(value);
            if (index < 0 || index > this.count)
            {
                throw new ArgumentOutOfRangeException("index", "索引超出范围");
            }
            else if (index == 0)
            {
                if (this.head == null)
                {
                    this.head = currNode;
                }
                else
                {
                    currNode.Next = this.head;
                    this.head = currNode;
                }
            }
            else
            {
                Node<T> preNode = GetNodeByIndex(index - 1);
                currNode.Next = preNode.Next;
                preNode.Next = currNode;
            }
            this.count++;
        }
        #endregion

        #region 测试
        public static void MySingleLinkedListTest()
        {
            MySingleLinkedList<int> linkedList = new MySingleLinkedList<int>();
            // Test1:顺序插入4个节点
            linkedList.Add(0);
            linkedList.Add(1);
            linkedList.Add(2);
            linkedList.Add(3);

            Console.WriteLine("The nodes in the linkedList:");
            for (int i = 0; i < linkedList.Count; i++)
            {
                Console.WriteLine(linkedList[i]);
            }
            Console.WriteLine("----------------------------");

            // Test2.1:在索引为0(即第1个节点)的位置插入单个节点
            linkedList.Insert(0, 10);
            Console.WriteLine("After insert 10 in index of 0:");
            for (int i = 0; i < linkedList.Count; i++)
            {
                Console.WriteLine(linkedList[i]);
            }
            // Test2.2:在索引为2(即第3个节点)的位置插入单个节点
            linkedList.Insert(2, 20);
            Console.WriteLine("After insert 20 in index of 2:");
            for (int i = 0; i < linkedList.Count; i++)
            {
                Console.WriteLine(linkedList[i]);
            }
            // Test2.3:在索引为5（即最后一个节点）的位置插入单个节点
            linkedList.Insert(5, 30);
            Console.WriteLine("After insert 30 in index of 5:");
            for (int i = 0; i < linkedList.Count; i++)
            {
                Console.WriteLine(linkedList[i]);
            }
            Console.WriteLine("----------------------------");

            // Test3.1:移除索引为5（即最后一个节点）的节点
            linkedList.RemoveAt(5);
            Console.WriteLine("After remove an node in index of 5:");
            for (int i = 0; i < linkedList.Count; i++)
            {
                Console.WriteLine(linkedList[i]);
            }
            // Test3.2:移除索引为0（即第一个节点）的节点
            linkedList.RemoveAt(0);
            Console.WriteLine("After remove an node in index of 0:");
            for (int i = 0; i < linkedList.Count; i++)
            {
                Console.WriteLine(linkedList[i]);
            }
            // Test3.3:移除索引为2（即第三个节点）的节点
            linkedList.RemoveAt(2);
            Console.WriteLine("After remove an node in index of 2:");
            for (int i = 0; i < linkedList.Count; i++)
            {
                Console.WriteLine(linkedList[i]);
            }
            Console.WriteLine("----------------------------");
        }
        #endregion
    }
    /// <summary>
    /// 节点
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class Node<T>
    {
        /// <summary>
        /// 数据域
        /// </summary>
        public T Item { get; set; }
        /// <summary>
        /// 指针域
        /// </summary>
        public Node<T> Next { get; set; }
        public Node()
        {
        }
        public Node(T item)
        {
            Item = item;
        }
    }
}
