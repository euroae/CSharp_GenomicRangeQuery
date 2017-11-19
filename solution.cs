using System;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution {
    public int[] solution(string S, int[] P, int[] Q) {
        // write your code in C# 6.0 with .NET 4.5 (Mono)
        int[][] sums = new int[S.Length][];
        int[] vals = new int[S.Length]; 
        //Console.WriteLine("SIZE IS " + S.Length);
        int[] answer = new int[P.Length];
        
        //sums[0] = new int[4]; 
        
        for(int x = 0; x < S.Length; x++)
        {
            sums[x] = new int[4];  
            if (x!=0)
            {
                sums[x][0] = sums[x-1][0];
                sums[x][1] = sums[x-1][1];
                sums[x][2] = sums[x-1][2];
                sums[x][3] = sums[x-1][3];
            }
            
            switch (S[x]) {
                case ('A'):
                    sums[x][0] += 1;
                    vals[x] = 1;
                    break;
                case ('C'):
                    sums[x][1] += 1;
                    vals[x] = 2;
                    break;
                case ('G'):
                    sums[x][2] += 1;
                    vals[x] = 3;
                    break;
                case ('T'):
                    sums[x][3] += 1;
                    vals[x] = 4;
                    break;
            }
                //Console.WriteLine(vals[x-1]);
        
                //Console.WriteLine("sums @ "+ x + " is " + string.Join(", ", sums[x]));
        }
        // zero out the first items
        sums[0][0] = 0;
        sums[0][1] = 0;
        sums[0][2] = 0;
        sums[0][3] = 0;
        
        for(int x = 0; x < P.Length; x++)
        {
            //Console.WriteLine("sums @ "+ x );
            if (P[x] == Q[x])
            {
                answer[x] = vals[P[x]];
                continue;
            } else if( P[x] > 0){
                P[x]--;
            } 
            
            if ( (sums[Q[x]][0] - sums[P[x]][0]) > 0)
            {
                answer[x] = 1;
            } else if ( (sums[Q[x]][1] - sums[P[x]][1]) > 0)
            {
                answer[x] = 2;
            } else if ( (sums[Q[x]][2] - sums[P[x]][2]) > 0)
            {
                answer[x] = 3;
            } else
            {
                answer[x] = 4;
            }
            //Console.WriteLine("sums @ "+ x + " is " + string.Join(", ", sums[Q[x]]));
        }
        
        return answer;
    }
}
