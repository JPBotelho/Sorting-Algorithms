using System.Collections.Generic;
using System;
using UnityEngine;

public static class Sorting
{
	public static void Swap<T>(ref T src, ref T dst) where T : IComparable
	{
		T temp = dst;
		dst = src;
		src = temp;
	}
		
	public static T[] CombSort<T>(float shrinkFactor, params T[] source) where T : IComparable
	{
		bool sorted = false;

		int gap = source.Length;

		for(int iteration = 0; iteration <= source.Length * source.Length; iteration++) //Worst case is n^2
		{
			bool swapped = false;
			for(int i = 0; i + gap < source.Length; i++)
			{
				if(source[i].CompareTo(source[i+gap]) == 1)
				{
					SortingHelper.Swap(ref source[i], ref source[i+gap]);
					swapped = true;
				}
			}

			gap = Mathf.FloorToInt(gap / shrinkFactor);
			gap = Mathf.Clamp(gap, 1, source.Length);
			
			if(!swapped && gap == 1) //Gap must be 1(regular bubble sort) to make sure everything was sorted
			{
				sorted = true;
				break;
			}

		}

		if(!sorted) //MaxIterations were hit
			throw new ArgumentException("Too few iterations to sort array.");

		return source;
	} 

	public static T[] BubbleSort<T>(params T[] source) where T : IComparable
	{
		bool sorted = false;

		for(int iteration = 0; iteration <= source.Length * source.Length; iteration++) //Worst case is n^2
		{
			bool swapped = false;
			for(int i = 0; i < source.Length - 1; i++)
			{
				if(source[i].CompareTo(source[i+1]) == 1)
				{
					SortingHelper.Swap(ref source[i], ref source[i+1]);
					swapped = true;
				}
			}

			if(!swapped)
			{
				sorted = true;
				Debug.Log(iteration);
				break;
			}

		}

		if(!sorted)
			throw new ArgumentException("Too few iterations to sort array.");

		return source;
	} 

	public static T[] InsertionSort<T>(params T[] source) where T : IComparable
	{
		for(int iteration = 1; iteration < source.Length; iteration++)
		{
			int currentIndex = iteration;
			while(currentIndex > 0 && source[currentIndex-1].CompareTo(source[currentIndex]) == 1) //X.CompareTo(Y) returns: -1 smaller, 0 equal, 1 bigger.
			{
				Swap(ref source[currentIndex], ref source[currentIndex-1]);
				currentIndex--;
			}
		}

		return source;
	} 
}