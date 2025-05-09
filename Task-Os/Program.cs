using System;

class DiskScheduling
{
    static void FCFS(int[] arr, int head)
    {
        int total = 0;
        Console.WriteLine("\nFCFS Order:");
        foreach (int request in arr)
        {
            Console.Write(request + " ");
            total += Math.Abs(head - request);
            head = request;
        }
        Console.WriteLine("\nTotal Head Movement = " + total);
    }

    static void SCAN(int[] arr, int head, int maxCylinder)
    {
        int total = 0;
        var left = new System.Collections.Generic.List<int>();
        var right = new System.Collections.Generic.List<int>();

        foreach (int request in arr)
        {
            if (request < head)
                left.Add(request);
            else
                right.Add(request);
        }

        left.Sort();     // Ascending
        left.Reverse();  // Descending
        right.Sort();    // Ascending

        Console.WriteLine("\nSCAN Order:");
        foreach (int request in right)
        {
            Console.Write(request + " ");
            total += Math.Abs(head - request);
            head = request;
        }

        if (left.Count > 0)
        {
            total += Math.Abs(head - (maxCylinder - 1));
            head = maxCylinder - 1;
            total += Math.Abs(head - left[0]);
            head = left[0];

            for (int i = 0; i < left.Count; i++)
            {
                Console.Write(left[i] + " ");
                if (i != 0)
                {
                    total += Math.Abs(head - left[i]);
                    head = left[i];
                }
            }
        }

        Console.WriteLine("\nTotal Head Movement = " + total);
    }

    static void C_SCAN(int[] arr, int head, int maxCylinder)
    {
        int total = 0;
        var left = new System.Collections.Generic.List<int>();
        var right = new System.Collections.Generic.List<int>();

        foreach (int request in arr)
        {
            if (request < head)
                left.Add(request);
            else
                right.Add(request);
        }

        right.Sort(); // Ascending
        left.Sort();  // Ascending

        Console.WriteLine("\nC-SCAN Order:");
        foreach (int request in right)
        {
            Console.Write(request + " ");
            total += Math.Abs(head - request);
            head = request;
        }

        if (left.Count > 0)
        {
            total += Math.Abs(head - (maxCylinder - 1));
            total += maxCylinder - 1; // From end to 0
            head = 0;

            foreach (int request in left)
            {
                Console.Write(request + " ");
                total += Math.Abs(head - request);
                head = request;
            }
        }

        Console.WriteLine("\nTotal Head Movement = " + total);
    }

    static void Main()
    {
        Console.Write("Enter number of disk requests: ");
        int n = int.Parse(Console.ReadLine());

        int[] queue = new int[n];
        Console.WriteLine("Enter disk request queue:");
        for (int i = 0; i < n; i++)
            queue[i] = int.Parse(Console.ReadLine());

        Console.Write("Enter initial head position: ");
        int head = int.Parse(Console.ReadLine());

        int maxCylinder = 5000;

        FCFS(queue, head);
        SCAN(queue, head, maxCylinder);
        C_SCAN(queue, head, maxCylinder);
    }
}
