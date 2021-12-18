using System;
using System.Collections.Generic;

namespace CTDL_Project
{
    public class Node
    {
        public Node LeftNode { get; set; }
        public Node RightNode { get; set; }
        
        public Student Data { get; set; }
    }


    public class BinarySearchTree
    {
        public Node Root { get; set; }
        public int CheckNull(Node parent)
        {
            if (parent == null)
            {
                return 1;
            }
            else return 0;
        }

        // TÌM CHUỖI NHỎ HƠN

        public bool IsLower(string a,string b)
        {
            char[] fname = a.ToCharArray();
            char[] fname1 = b.ToCharArray();
            bool check = true;
            int i = 0;
            while(i < fname1.Length && i< fname.Length)
            {
                if(fname[i] < fname1[i])
                {
                    check = true;
                    break;
                }
                if(fname[i] > fname1[i])
                {
                    check = false;
                    break;
                }
                if(fname[i]==fname1[i])
                {
                    i++;
                }    
            }    
            return check;
        }

        // CHÈN GIÁ TRỊ VÀO CÂY
       

        public bool Insert(Student value, int option)
        {
            Node before = null, after = this.Root;
            if (option == 2)
            {
                while (after != null)
                {

                    before = after;
                    if (IsLower(value.getFirstName(), after.Data.getFirstName()) == true) //left? 
                        after = after.LeftNode;
                    else if (IsLower(value.getFirstName(), after.Data.getFirstName()) == false) //right?
                        after = after.RightNode;
                    else
                        return false;
                }

                Node newNode = new Node();
                newNode.Data = value;
                if (this.Root == null)//empty?
                    this.Root = newNode;
                else
                {
                    if (IsLower(value.getFirstName(), before.Data.getFirstName()) == true)
                        before.LeftNode = newNode;
                    else
                        before.RightNode = newNode;
                }
                return true;
            }
            else
            {
                

                while (after != null)
                {
                   
                    before = after;
                    if (value.getNum(option) <= after.Data.getNum(option)) //left? 
                        after = after.LeftNode;
                    else if (value.getNum(option) > after.Data.getNum(option)) //right?
                        after = after.RightNode;
                    else
                        return false;
                }


                Node newNode = new Node();
                newNode.Data = value;
                if (this.Root == null)//empty?
                    this.Root = newNode;
                else
                {                                      
                    if (value.getNum(option) <= before.Data.getNum(option))
                        before.LeftNode = newNode;
                    else
                        before.RightNode = newNode;
                }
                return true;
            }
        }
        /*------------ DUYỆT CÂY --------------*/

        //Duyệt trung thứ tự
        public void TraverseInOrder(Node parent)
        {
            if (parent != null)
            {
                
                TraverseInOrder(parent.LeftNode);
                Console.Write(parent.Data + " ");
                TraverseInOrder(parent.RightNode);
            }
        }

        // Duyệt tiền thứ tự
        public void TraversePreOrder(Node parent)
        {
            if (parent != null)
            {
                Console.Write(parent.Data + " ");
                TraversePreOrder(parent.LeftNode);
                TraversePreOrder(parent.RightNode);
            }
        }

        //Duyệt hậu thứ tự
        public void TraversePostOrder(Node parent)
        {
            if (parent != null)
            {
                TraversePostOrder(parent.LeftNode);
                TraversePostOrder(parent.RightNode);
                Console.Write(parent.Data + " ");
            }
        }

        public void TreeTraverals(Node parent)
        {
            Console.WriteLine("---Chọn phương thức duyệt cây---");
            Console.WriteLine("1. Tiền thứ tự");
            Console.WriteLine("2. Trung thứ tự");
            Console.WriteLine("3. Hậu thứ tự");
            int n = int.Parse(Console.ReadLine());
            switch(n)
            {
                case 1: TraversePreOrder(parent);
                    break;
                case 2:
                    TraverseInOrder(parent);
                    break;
                case 3:
                    TraversePostOrder(parent);
                    break;
            }    
        }

        /*============== CÁC THUẬT TOÁN TÌM KIẾM ==============*/
        
        // Tìm kiếm tên
        public void SearchName(string key, Node root)
        {
            Node current = Root;
            bool exist = true;
            while (current.Data.getFirstName() != key)
            {
                if (IsLower(key, current.Data.getFirstName()) == true)
                {
                    if (current.LeftNode != null)
                    {
                        current = current.LeftNode;
                    }
                    else
                    {
                        Console.WriteLine("Không có giá trị phù hợp");
                        exist = false;
                        break;
                    }

                }
                else if (IsLower(key, current.Data.getFirstName()) == false)
                {
                    if (current.RightNode != null)
                    {
                        current = current.RightNode;
                    }
                    else
                    {
                        Console.WriteLine("Không có giá trị phù hợp");
                        exist = false;

                        break;
                    }


                }
            }
            if(exist)
            {
                Console.WriteLine(current.Data);
                while (current.LeftNode != null)
                {
                    if (current.LeftNode.Data.getFirstName() == current.Data.getFirstName())
                    {
                        Console.WriteLine(current.LeftNode.Data);

                    }
                    current = current.LeftNode;

                }
            }    
            
        }

        //Tìm kiếm số
        public void SearchNum(double key,Node root,int option)
        {
            Node current = Root;
            bool exist = true;

            while (current.Data.getNum(option) != key)
            {
                if (key < current.Data.getNum(option))
                {
                    if (current.LeftNode != null)
                    {
                        current = current.LeftNode;
                    }
                    else
                    {
                        Console.WriteLine("Không có giá trị phù hợp");
                        exist = false;
                        break;
                    }

                }
                else if(key > current.Data.getNum(option))
                {
                    if (current.RightNode != null)
                    {
                        current = current.RightNode;
                    }
                    else
                    {
                        Console.WriteLine("Không có giá trị phù hợp");
                        exist = false;

                        break;
                    }


                }

            }
            if(exist)
            {
                Console.WriteLine(current.Data);
                while (current.LeftNode != null)
                {
                    if (current.LeftNode.Data.getNum(option) == current.Data.getNum(option))
                    {
                        Console.WriteLine(current.LeftNode.Data);


                    }
                    current = current.LeftNode;

                }
            }    
            
        }

        

        /*================== MỘT SỐ HÀM TÌM KIẾM KHÁC ==================*/


        // TOP ĐIỂM THẤP
        static int count = 0;
        public static Node kthSmallest(Node root, int k)
        {
            
            if (root == null)
                return null;
                        
            Node left = kthSmallest(root.LeftNode, k);
                        
            if (left != null)
                return left;

            count++;
            if (count == k)
                return root;
                        
            return kthSmallest(root.RightNode, k);
        }

        
        public void printKthSmallest(Node root,
                                            int k)
        {
            
            count = 0;

            Node res = kthSmallest(root, k);

            if (res != null)
                Console.WriteLine(res.Data);
            else
                Console.WriteLine("Not found!");
        }

        public void TopSmallest(Node root)
        {
            Console.WriteLine("TOP?");
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine("Top {0} smallest:",num);
            for (int i=1; i<=num; i++)
            {
                
                printKthSmallest(root, i);
            }    
        }



        // TOP ĐIỂM CAO
        static int count1 = 0;
        public static Node kthLargest(Node root, int k)
        {
            
            if (root == null)
                return null;
                        
            Node right = kthLargest(root.RightNode, k);

            if (right != null)
                return right;

            count1++;
            if (count1 == k)
                return root;

            return kthLargest(root.LeftNode, k);
        }

        
        public void printkthLargest(Node root,
                                            int k)
        {
            
            count1 = 0;

            Node res = kthLargest(root, k);

            if (res != null)
                Console.WriteLine(res.Data);
            else
                Console.WriteLine("Not found!");
        }

        public void TopLargest(Node root)
        {
            Console.WriteLine("TOP?");
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine("Top {0} largest:", num);
            for (int i = 1; i <= num; i++)
            {

                printkthLargest(root, i);
            }
        }

        public void SearchInRange(Node parent,int option, double key_a, double key_b)
        {
            if (parent != null)
            {

                if (parent.Data.getNum(option) >= key_a && parent.Data.getNum(option) <= key_b)
                {
                    Console.WriteLine(parent.Data);
                }
                SearchInRange(parent.LeftNode,option, key_a, key_b);
                SearchInRange(parent.RightNode,option, key_a, key_b);
            }
        }

        //  THỐNG KÊ
        public void Rank(Node parent,int option)
        {
            if (parent != null)
            {
                Console.WriteLine(parent.Data);
                Console.WriteLine("Điểm của SV: {0}", parent.Data.getNum(option));
                if (parent.Data.getNum(option) >= 8)
                    Console.WriteLine("Điểm SV xếp loại: Giỏi");
                else if (parent.Data.getNum(option) < 8 && parent.Data.getNum(option) >= 6.5)
                    Console.WriteLine("Điểm SV xếp loại: Khá");
                else if (parent.Data.getNum(option) < 6.5 && parent.Data.getNum(option) >= 5)
                    Console.WriteLine("Điểm SV xếp loại: Trung Bình");
                else if (parent.Data.getNum(option) < 5 )
                    Console.WriteLine("Điểm SV xếp loại: Yếu");
                
                Console.WriteLine("*********************************");
                Rank(parent.LeftNode,option);
                Rank(parent.RightNode,option);
            }
        }


        public void Count(Node parent,int option, ref int G, ref int K, ref int TB, ref int Y)
        {

            if (parent != null)
            {
                if (parent.Data.getNum(option) < 5)
                {
                    Y++;
                }
                else if (parent.Data.getNum(option) >= 5 && parent.Data.getNum(option) < 6.5)
                {
                    TB++;
                }
                else if (parent.Data.getNum(option) >= 6.5 && parent.Data.getNum(option) < 8)
                {
                    K++;
                }
                else G++;
                Count(parent.LeftNode,option, ref G, ref K, ref TB, ref Y);
                Count(parent.RightNode,option, ref G, ref K, ref TB, ref Y);



            }

        }

        public void Categorize(Node parent,int option)
        {
            Rank(parent, option);
            int G = 0, K = 0, TB = 0, Y = 0;
            Console.WriteLine("---TỔNG KẾT---");
            Count(parent,option, ref G, ref K, ref TB, ref Y);
            Console.WriteLine("Giỏi: "+G);
            Console.WriteLine("Khá: " + K);
            Console.WriteLine("Trung bình: " + TB);
            Console.WriteLine("Yếu: " + Y);

        }

        public int CountNode(Node current)
        {


            if (current == null)
                return 0;
            else
            {
                int a = CountNode(current.RightNode);
                int b = CountNode(current.LeftNode);
                return a + b + 1;
            }


        }
        public double Sum(Node current,int option)
        {

            if (current != null)
            {
                double a = Sum(current.LeftNode,option);
                double b = Sum(current.RightNode,option);
                return a + b + current.Data.getNum(option);

            }
            return 0;
        }

        
        public void Var(Node parent, int option, ref double temp,ref double mean)
        {
            
            if (parent != null)
            {
                temp = temp + Math.Pow(parent.Data.getNum(option) - mean, 2);
                Var(parent.LeftNode, option,ref temp,ref mean);
                Var(parent.RightNode, option,ref temp,ref mean);
            }

        }
        public void Describe(Node parent, int option)
        {
            double mean = Sum(parent, option) / CountNode(parent);
            double temp = 0;
            int n = CountNode(parent);
            Var(parent, option, ref temp, ref mean);
            double var = temp / n;
            double std = Math.Pow(var, 0.5);
            Console.WriteLine("N = " + n);
            Console.WriteLine("Sum = " + Math.Round(Sum(parent, option),2));
            Console.WriteLine("Mean = " + Math.Round(mean,2));
            Console.WriteLine("Var = " + Math.Round(var,2));
            Console.WriteLine("Standard error = " + Math.Round(std,2));
            Console.WriteLine();
        }
    }


}