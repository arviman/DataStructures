using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
	class Node
	{
		public int data { get; set; }
		public Node next { get; set; }

		public Node(int data)
		{
			this.data = data;
		}

		public Node Add(int nextVal)
		{
			Node nd = new Node(nextVal);
			this.next = nd;
			return nd;
		}

		public void Print()
		{
			Node cur = this;

			while (cur != null)
			{				
				Console.Write(cur.data + " ");
				cur = cur.next;
			}
			Console.WriteLine();
		}

		public Node Reverse()
		{
			Node prev = null;
			Node cur = this;	
			
			while (cur != null)
			{
				Node next = cur.next;
				cur.next = prev;
				prev = cur;
				cur = next;
			}
			return prev;
		}

		public Node ReverseK(int k)
		{
			Node prev = null;
			Node cur = this;
			Node start = cur;
			int times = 0;
			//1-2-3-4  p - null, c - 1 n - 2......p - 1 c - 2 n - 3....start - 1....
			while (cur != null && times < k)
			{
				Node next = cur.next;
				cur.next = prev;
				prev = cur;
				cur = next;
				++times;
			}

			if (times == k)
			{
				start.next = cur.ReverseK(k);
			}

			return prev;
		}
		
	}

	class Program
	{
		static void Main(string[] args)
		{

			int[] arr = new[] {1, 2, 3, 4, 5, 6, 7};

			Node head = new Node(arr[0]);
			Node cur = head;
			for (int i = 1; i < arr.Length; ++i)
			{
				cur = cur.Add(arr[i]);
			}
			head.Print();
			Node nd = head.ReverseK(3);
			nd.Print();

			Console.ReadLine();

		}

		
	}
}
