using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Collections;
using System;

namespace CTDL_Project
{
	public class Student
	{
		private int id;
		private string name;
		private int age;
		private float math;
		private float physc;
		private float chem;
		private float avg;
		public Student(int id, string name, int age, float math, float physc, float chem)
		{
			this.id = id;
			this.name = name;
			this.age = age;
			this.math = math;
			this.physc = physc;
			this.chem = chem;
			this.avg = (math + physc + chem) / 3;
		}
		
		

		public string getFirstName()
        {
			string[] fname = name.Split(" ");
			return fname[fname.Length - 1];
        }

		public double getNum(int option)
        {
			if (option == 1) return id;
			if (option == 3) return age;
			if (option == 4) return math;
			if (option == 5) return physc;
			if (option == 6) return chem;
			if (option == 7) return avg;
			return -1;

		}
		public override string ToString()
        {
            return "\n----------\n"+id + " : " + name + "-" + age + "\n" + "Math: " + math + "\nPhysic: " + physc + "\nChemistry: " + chem + "\nAVG: " + avg+"\n----------\n";
        }
    }
}