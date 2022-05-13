using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodukuEaminer
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new System.IO.StreamReader(@args[0]))
            {
                int[,] sodoku = new int[9, 9];
                int k = 0;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    for(int i = 0; i < 9; i++)
                    {
                        sodoku[k, i] = Int32.Parse(values[i]); 
                    }
                    k++;
                }
                // showing the matrix
                for(int i = 0; i < 9; i++)
                {
                    for(int j = 0; j < 9; j++)
                    {
                        Console.Write(sodoku[i, j]);
                    }
                    Console.WriteLine("");
                }

                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        
                        
                        if(checkColumn(j,i, sodoku[i, j], sodoku)||
                            checkRow(i,j, sodoku[i, j], sodoku)||
                            checkSmallRectangle(i, j, sodoku))
                        {
                            Console.WriteLine("False");
                            Console.ReadLine();
                            return;
                           
                        }
                    }
                   
                }
                Console.WriteLine("True");

                Console.ReadLine();
            }
        }
        public static bool checkSmallRectangle(int row,int column,int[,] A)
        {
            
            

            int r = (int)Math.Floor((double)row/3);
            int c = (int)Math.Floor((double)column / 3);
            
            
            for(int i = r*3 ; i < r*3 + 3; i++)


            {
                for(int j = c*3 ; j < c*3 +3; j++)
                {
                    if(row==i&& column==j)
                    {
                        continue;
                    }
                    if (A[row, column] == A[i, j] && i != row && j != column)
                    {
                        return true;
                        
                    }
                }
            }

            return false;
        }
        public static bool checkRow(int row,int currentColumn,int a,int[,] A)
        {
            for(int i = 0; i < 9; i++)
            {
                if (i == currentColumn)
                {
                    continue;
                }
                if (A[row, i] == a)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool checkColumn(int column,int currentRow,int a, int[,] A)
        {
            for (int i = 0; i < 9; i++)
            {
                if (i == currentRow)
                {
                    continue;
                }
                if (A[i, column] == a)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
