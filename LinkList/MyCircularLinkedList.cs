using System;
using System.Collections.Generic;
using System.Text;

namespace LinkList
{
    /// <summary>
    /// 单向循环列表
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MyCircularLinkedList<T>
    {
        private int count;
        private CirNode<T> tail;//尾指针
        private CirNode<T> currPrev;//当前指针的前驱指针
        public int Count { get { return count; } }
        /// <summary>
        /// 获取当前指针的值
        /// </summary>
        public T CurrItem { get { return currPrev.Next.Item; } }

        public MyCircularLinkedList()
        {
            count = 0;
            tail = null;
        }
        /// <summary>
        /// 判断当前链表是否为空
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return tail == null;
        }
        /// <summary>
        /// 根据索引获取节点
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private CirNode<T> GetNodeByIndex(int index)
        {
            if (index < 0 || index > count)
            {
                throw new ArgumentOutOfRangeException("index", "索引超出范围");
            }
            CirNode<T> cirNode = tail;
            for (int i = 0; i <= index; i++)
            {
                cirNode = cirNode.Next;
            }
            return cirNode;
        }
        /// <summary>
        /// 添加节点
        /// </summary>
        /// <param name="value"></param>
        public void Add(T value) 
        {
            CirNode<T> cirNode = new CirNode<T>(value);
            if (tail == null)
            {
                tail = cirNode;
                tail.Next = tail;
                currPrev = cirNode;
            }
            else
            {
                cirNode.Next = tail.Next;
                tail.Next = cirNode;
                if (currPrev == tail)
                {
                    currPrev = cirNode;
                }
                tail = cirNode;
            }
            count++;
        }
        /// <summary>
        /// 移除当前节点
        /// </summary>
        public void Remove() 
        {
            if (tail == null)
            {
                throw new NullReferenceException("链表中没有元素");
            }
            else if (count == 1)
            {
                tail = null;
                currPrev = null;
            }
            else
            {
                if (currPrev.Next == tail)
                {
                    tail = currPrev;
                }
                //移除当前节点
                currPrev.Next = currPrev.Next.Next;
            }
            count--;
        }
        /// <summary>
        /// 获取所有节点信息
        /// </summary>
        /// <returns></returns>
        public string GetAllNodes() 
        {
            if (count == 0)
            {
                throw new NullReferenceException("该链表中无数据");
            }
            else
            {
                CirNode<T> head = tail.Next;
                string result = "";
                for (int i = 0; i < count; i++)
                {
                    //result += GetNodeByIndex(i).Item + " ";
                    result += head.Item + " ";
                    head = head.Next;
                }
                return result;
            }
        }
        /// <summary>
        /// 移动
        /// </summary>
        /// <param name="step"></param>
        public void Move(int step) 
        {
            if (step < 1)
            {
                throw new ArgumentOutOfRangeException("step", "步数不能小于1");
            }
            for (int i = 1; i < step; i++)
            {
                currPrev = currPrev.Next;
            }
        }
        #region 测试
        public static void MyCircularLinkedListTest()
        {
            MyCircularLinkedList<int> linkedList = new MyCircularLinkedList<int>();
            // 顺序插入5个节点
            linkedList.Add(1);
            linkedList.Add(2);
            linkedList.Add(3);
            linkedList.Add(4);
            linkedList.Add(5);

            Console.WriteLine("All nodes in the circular linked list:");
            Console.WriteLine(linkedList.GetAllNodes());
            Console.WriteLine("--------------------------------------");
            // 当前节点：第一个节点
            Console.WriteLine("Current node in the circular linked list:");
            Console.WriteLine(linkedList.CurrItem);
            Console.WriteLine("--------------------------------------");
            // 移除当前节点(第一个节点)
            linkedList.Remove();
            Console.WriteLine("After remove the current node:");
            Console.WriteLine(linkedList.GetAllNodes());
            Console.WriteLine("Current node in the circular linked list:");
            Console.WriteLine(linkedList.CurrItem);
            // 移除当前节点(第二个节点)
            linkedList.Remove();
            Console.WriteLine("After remove the current node:");
            Console.WriteLine(linkedList.GetAllNodes());
            Console.WriteLine("Current node in the circular linked list:");
            Console.WriteLine(linkedList.CurrItem);
            Console.WriteLine("--------------------------------------");

            Console.WriteLine();
        }
        #endregion
        #region Josephus问题
        public static void JosephusTest()
        {
            MyCircularLinkedList<int> linkedList = new MyCircularLinkedList<int>();
            string result = string.Empty;

            Console.WriteLine("Step1:请输入人数N");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Step2:请输入数字M");
            int m = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Step3:报数游戏开始");
            // 添加参与人员元素
            for (int i = 1; i <= n; i++)
            {
                linkedList.Add(i);
            }
            // 打印所有参与人员
            Console.Write("所有参与人员：{0}", linkedList.GetAllNodes());
            Console.WriteLine("\r\n" + "-------------------------------------");
            result = string.Empty;

            while (linkedList.Count > 1)
            {
                // 依次报数：移动
                linkedList.Move(m);
                // 记录出队人员
                result += linkedList.CurrItem + " ";
                // 移除人员出队
                linkedList.Remove();
                Console.WriteLine();
                Console.Write("剩余报数人员：{0}", linkedList.GetAllNodes());
                Console.Write("  开始报数人员：{0}", linkedList.CurrItem);
            }
            Console.WriteLine("\r\n" + "Step4:报数游戏结束");
            Console.WriteLine("出队人员顺序：{0}", result + linkedList.CurrItem);
        }
        public static LinkedList<Person> InitPersonList(int count)
        {
            LinkedList<Person> personList = new LinkedList<Person>();
            for (int i = 1; i <= count; i++)
            {
                Person person = new Person();
                person.Id = i;
                person.Name = "Counter-" + i.ToString();

                personList.AddLast(person);
            }

            return personList;
        }
        public static void JosephusTestWithLinkedList()
        {
            Console.WriteLine("请输入人数N");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("请输入数字M");
            int m = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("-------------------------------------");

            LinkedList<Person> linkedList = InitPersonList(n);

            LinkedListNode<Person> startNode = linkedList.First;
            LinkedListNode<Person> removeNode;

            while (linkedList.Count >= 1)
            {
                for (int i = 1; i < m; i++)
                {
                    if (startNode != linkedList.Last)
                    {
                        startNode = startNode.Next;
                    }
                    else
                    {
                        startNode = linkedList.First;
                    }
                }
                // 记录出队人员节点
                removeNode = startNode;
                // 打印出队人员ID号
                Console.Write(removeNode.Value.Id + " ");
                // 确定下一个开始报数人员
                if (startNode == linkedList.Last)
                {
                    startNode = linkedList.First;
                }
                else
                {
                    startNode = startNode.Next;
                }
                // 移除出队人员节点
                linkedList.Remove(removeNode);
            }
            Console.WriteLine();
        }
        #endregion
    }
    class CirNode<T>
    {
        public T Item { get; set; }
        public CirNode<T> Next { get; set; }

        public CirNode()
        {
        }

        public CirNode(T item)
        {
            Item = item;
        }
    }
    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
