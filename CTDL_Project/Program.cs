using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Collections;
using System;
using System.IO;

namespace CTDL_Project
{
    
    class Program
    {
        // XÂY CÂY
        static void BST(string path, int option, BinarySearchTree myclass)
        {

            string line;
            string[] words;
            StreamReader inFile;
            inFile = File.OpenText(path);
            while (inFile.Peek() != -1)
            {
                line = inFile.ReadLine();
                words = line.Split(';');
                Student st = new Student(int.Parse(words[0]), words[1], int.Parse(words[2]), float.Parse(words[3]), float.Parse(words[4]), float.Parse(words[5]));
                myclass.Insert(st, option);
            }
            inFile.Close();
        }

        //Menu chính
        static void Menu(string path)
        {

            BinarySearchTree myclass = new BinarySearchTree();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("**************************");

            Console.WriteLine("1: Id");
            Console.WriteLine("2: Name");
            Console.WriteLine("3: Age");
            Console.WriteLine("4: Math");
            Console.WriteLine("5: Physic");
            Console.WriteLine("6: Chem");
            Console.WriteLine("7: AVG");
            
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("Nhập lựa chọn của bạn: ");
            int option = int.Parse(Console.ReadLine());

            BST(path, option, myclass);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            
            Console.WriteLine("**************************");
            string[] menu = { "ID", "Name", "Age", "Math", "Physic", "Chem", "AVG" };
            Console.WriteLine("Cây dữ liệu: " + menu[option - 1]);
               
                  
            switch (option)
            {
                
                case 1: Menu_Id(path,myclass, option);
                    break;
                case 2: Menu_Name(path, myclass);
                    break;
                case 3:
                    Menu_Age(path, myclass, option);
                    break;
                case 4:
                    Menu_Math(path, myclass, option);
                    break;
                case 5:
                    Menu_Physc(path, myclass, option);
                    break;
                case 6:
                    Menu_Chem(path, myclass, option);
                    break;
                case 7:
                    Menu_AVG(path, myclass, option);
                    break;
            }
            
        }


        //Menu phụ
        static void Menu_Id(string path, BinarySearchTree myclass, int option)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("=== CHỌN THAO TÁC BẠN MUỐN THỰC HIỆN ===");
            Console.WriteLine("1: Duyệt cây.");
            Console.WriteLine("2: Tìm kiếm sinh viên có ID.");
            Console.WriteLine("0: Về lại Menu");
            int option1 = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            switch (option1)
            {
                case 0:
                    Menu(path);
                    break;
                case 1:
                    myclass.TreeTraverals(myclass.Root);
                    Menu_Id(path,myclass, option);
                    break;
                case 2:
                    Console.WriteLine("Nhập ID muốn tìm kiếm:");
                    int key = int.Parse(Console.ReadLine());
                    myclass.SearchNum(key, myclass.Root, option);
                    Console.WriteLine();
                    Menu_Id(path, myclass, option);
                    break;
            }
        }

        static void Menu_Name(string path, BinarySearchTree myclass)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("=== CHỌN THAO TÁC BẠN MUỐN THỰC HIỆN ===");
            Console.WriteLine("1: Duyệt cây.");
            Console.WriteLine("2: Tìm kiếm sinh viên có tên.");
            Console.WriteLine("0: Về lại Menu");
            int option = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            switch (option)
            {
                case 0:
                    Menu(path);
                    break;
                case 1:
                    myclass.TreeTraverals(myclass.Root);
                    Menu_Name(path, myclass);
                    break;
                case 2:
                    Console.WriteLine("Nhập tên muốn tìm kiếm:");
                    string key = Console.ReadLine();
                    myclass.SearchName(key, myclass.Root);
                    Console.WriteLine();
                    Menu_Name(path, myclass);
                    break;
            }
        }

        static void Menu_Age(string path, BinarySearchTree myclass,int option)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("=== CHỌN THAO TÁC BẠN MUỐN THỰC HIỆN ===");
            Console.WriteLine("1: Duyệt cây.");
            Console.WriteLine("2: Tìm kiếm sinh viên có tuổi.");
            Console.WriteLine("0: Về lại Menu");
            int option1 = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            switch (option1)
            {
                case 0:
                    Menu(path);
                    break;
                case 1:
                    myclass.TreeTraverals(myclass.Root);
                    Menu_Age(path, myclass, option);
                    break;
                case 2:
                    Console.WriteLine("Nhập tuổi muốn tìm kiếm:");
                    int key = int.Parse(Console.ReadLine());
                    myclass.SearchNum(key, myclass.Root, option);
                    Console.WriteLine();
                    Menu_Age(path, myclass, option);
                    break;
            }
        }
        static void Menu_Math(string path, BinarySearchTree myclass,int option)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("=== CHỌN THAO TÁC BẠN MUỐN THỰC HIỆN ===");
            Console.WriteLine("1: Duyệt cây.");
            Console.WriteLine("2: Tìm kiếm sinh viên có điểm.");
            Console.WriteLine("3: Tìm kiếm sinh viên có điểm trong khoảng.");
            Console.WriteLine("4: Tìm kiếm top n sinh viên có điểm cao nhất.");
            Console.WriteLine("5: Tìm kiếm top n sinh viên có điểm thấp nhất.");
            Console.WriteLine("6: Thống kê sinh viên theo loại.");
            Console.WriteLine("7: Thống kê.");

            Console.WriteLine("0: Về lại Menu");
            int option1 = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            switch (option1)
            {
                case 0:
                    Menu(path);
                    break;
                case 1:
                    myclass.TreeTraverals(myclass.Root);
                    Menu_Math(path, myclass, option);
                    break;
                case 2:
                    Console.WriteLine("Nhập điểm muốn tìm kiếm:");
                    double key = double.Parse(Console.ReadLine());
                    myclass.SearchNum(key, myclass.Root, option);
                    Console.WriteLine();
                    Menu_Math(path, myclass, option);
                    break;
                case 3:
                    Console.WriteLine("a<= điểm <= b");
                    Console.WriteLine("Nhập lần lượt a,b: ");
                    double a = double.Parse(Console.ReadLine());
                    double b = double.Parse(Console.ReadLine());
                    myclass.SearchInRange(myclass.Root, option,a,b);
                    Menu_Math(path, myclass, option);
                    break;
                case 4:
                    myclass.TopLargest(myclass.Root);
                    Menu_Math(path, myclass, option);
                    break;
                case 5:
                    myclass.TopSmallest(myclass.Root);
                    Menu_Math(path, myclass, option);
                    break;
                case 6:
                    Console.WriteLine("--Thống kê môn TOÁN--");
                    myclass.Categorize(myclass.Root, option);
                    Menu_Math(path, myclass, option);
                    break;
                case 7:
                    Console.WriteLine("--Statistic--");
                    myclass.Describe(myclass.Root, option);
                    Menu_Math(path, myclass, option);
                    break;
            }
        }

        static void Menu_Physc(string path, BinarySearchTree myclass,int option)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("=== CHỌN THAO TÁC BẠN MUỐN THỰC HIỆN ===");
            Console.WriteLine("1: Duyệt cây.");
            Console.WriteLine("2: Tìm kiếm sinh viên có điểm.");
            Console.WriteLine("3: Tìm kiếm sinh viên có điểm trong khoảng.");
            Console.WriteLine("4: Tìm kiếm top n sinh viên có điểm cao nhất.");
            Console.WriteLine("5: Tìm kiếm top n sinh viên có điểm thấp nhất.");
            Console.WriteLine("6: Thống kê sinh viên theo loại.");
            Console.WriteLine("7: Thống kê.");

            Console.WriteLine("0: Về lại Menu");
            int option1 = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            switch (option1)
            {
                case 0:
                    Menu(path);
                    break;
                case 1:
                    myclass.TreeTraverals(myclass.Root);
                    Menu_Physc(path, myclass, option);
                    break;
                case 2:
                    Console.WriteLine("Nhập điểm muốn tìm kiếm:");
                    double key = double.Parse(Console.ReadLine());
                    myclass.SearchNum(key, myclass.Root, option);
                    Console.WriteLine();
                    Menu_Physc(path, myclass, option);
                    break;
                case 3:
                    Console.WriteLine("a<= điểm <= b");
                    Console.WriteLine("Nhập lần lượt a,b: ");
                    double a = double.Parse(Console.ReadLine());
                    double b = double.Parse(Console.ReadLine());
                    myclass.SearchInRange(myclass.Root, option, a, b);
                    Menu_Physc(path, myclass, option);
                    break;
                case 4:
                    myclass.TopLargest(myclass.Root);
                    Menu_Physc(path, myclass, option);
                    break;
                case 5:
                    myclass.TopSmallest(myclass.Root);
                    Menu_Physc(path, myclass, option);
                    break;
                case 6:
                    Console.WriteLine("--Thống kê môn LÝ--");
                    myclass.Categorize(myclass.Root, option);
                    Menu_Physc(path, myclass, option);
                    break;
                case 7:
                    Console.WriteLine("--Statistic--");
                    myclass.Describe(myclass.Root, option);
                    Menu_Physc(path, myclass, option);
                    break;
            }
        }

        static void Menu_Chem(string path, BinarySearchTree myclass,int option)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("=== CHỌN THAO TÁC BẠN MUỐN THỰC HIỆN ===");
            Console.WriteLine("1: Duyệt cây.");
            Console.WriteLine("2: Tìm kiếm sinh viên có điểm.");
            Console.WriteLine("3: Tìm kiếm sinh viên có điểm trong khoảng.");
            Console.WriteLine("4: Tìm kiếm top n sinh viên có điểm cao nhất.");
            Console.WriteLine("5: Tìm kiếm top n sinh viên có điểm thấp nhất.");
            Console.WriteLine("6: Thống kê sinh viên theo loại.");
            Console.WriteLine("7: Thống kê.");

            Console.WriteLine("0: Về lại Menu");
            int option1 = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            switch (option1)
            {
                case 0:
                    Menu(path);
                    break;
                case 1:
                    myclass.TreeTraverals(myclass.Root);
                    Menu_Chem(path, myclass, option);
                    break;
                case 2:
                    Console.WriteLine("Nhập điểm muốn tìm kiếm:");
                    double key = double.Parse(Console.ReadLine());
                    myclass.SearchNum(key, myclass.Root, option);
                    Console.WriteLine();
                    Menu_Chem(path, myclass, option);
                    break;
                case 3:
                    Console.WriteLine("a<= điểm <= b");
                    Console.WriteLine("Nhập lần lượt a,b: ");
                    double a = double.Parse(Console.ReadLine());
                    double b = double.Parse(Console.ReadLine());
                    myclass.SearchInRange(myclass.Root, option, a, b);
                    Menu_Chem(path, myclass, option);
                    break;
                case 4:
                    myclass.TopLargest(myclass.Root);
                    Menu_Chem(path, myclass, option);
                    break;
                case 5:
                    myclass.TopSmallest(myclass.Root);
                    Menu_Chem(path, myclass, option);
                    break;
                case 6:
                    Console.WriteLine("--Thống kê môn HÓA--");
                    myclass.Categorize(myclass.Root, option);
                    Menu_Chem(path, myclass, option);
                    break;
                case 7:
                    Console.WriteLine("--Statistic--");
                    myclass.Describe(myclass.Root, option);
                    Menu_Chem(path, myclass, option);
                    break;

            }
        }
        static void Menu_AVG(string path, BinarySearchTree myclass,int option)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("=== CHỌN THAO TÁC BẠN MUỐN THỰC HIỆN ===");
            Console.WriteLine("1: Duyệt cây.");
            Console.WriteLine("2: Tìm kiếm sinh viên có điểm.");
            Console.WriteLine("3: Tìm kiếm sinh viên có điểm trong khoảng.");
            Console.WriteLine("4: Tìm kiếm top n sinh viên có điểm cao nhất.");
            Console.WriteLine("5: Tìm kiếm top n sinh viên có điểm thấp nhất.");
            Console.WriteLine("6: Thống kê sinh viên theo loại.");
            Console.WriteLine("7: Thống kê.");
            Console.WriteLine("0: Về lại Menu");
            int option1 = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            switch (option1)
            {
                case 0:
                    Menu(path);
                    break;
                case 1:
                    myclass.TreeTraverals(myclass.Root);
                    Menu_AVG(path, myclass, option);
                    break;
                case 2:
                    Console.WriteLine("Nhập điểm muốn tìm kiếm:");
                    double key = double.Parse(Console.ReadLine());
                    myclass.SearchNum(key, myclass.Root,option);
                    Console.WriteLine();
                    Menu_AVG(path, myclass, option);
                    break;
                case 3:
                    Console.WriteLine("a<= điểm <= b");
                    Console.WriteLine("Nhập lần lượt a,b: ");
                    double a = double.Parse(Console.ReadLine());
                    double b = double.Parse(Console.ReadLine());
                    myclass.SearchInRange(myclass.Root, option, a, b);
                    Menu_AVG(path, myclass, option);
                    break;
                case 4:
                    myclass.TopLargest(myclass.Root);
                    Menu_AVG(path, myclass, option);
                    break;
                case 5:
                    myclass.TopSmallest(myclass.Root);
                    Menu_AVG(path, myclass, option);
                    break;
                case 6:
                    Console.WriteLine("--Thống kê điểm trung bình--");
                    myclass.Categorize(myclass.Root,option);
                    Menu_AVG(path, myclass, option);
                    break;
                case 7:
                    Console.WriteLine("--Statistic--");
                    myclass.Describe(myclass.Root, option);
                    Menu_AVG(path, myclass, option);
                    break;
            }
        }
        
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("********** ĐỒ ÁN CẤU TRÚC DỮ LIỆU VÀ GIẢI THUẬT **********");
            Console.WriteLine("           ************** NHÓM 1 **************");
            Console.WriteLine("1. Bùi Thành Công");
            Console.WriteLine("2. Lê Đức Dũng");
            Console.WriteLine("3. Phạm Nhật Hải");
            Console.WriteLine("4. Lê Trung Nguyên");
            Console.WriteLine("5. Trần Mạnh Tường");

            //BÀI LÀM
            Console.Title = "Đồ án Cấu trúc dữ liệu và giải thuật";
            Menu("C:/Users/User/source/repos/CTDL_Project/CTDL_Project/Data1.txt");
            
        }
    }
}
