using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters;
namespace augmented_system_soultion
{
    internal class Program
    {
        static void printmatrix(float[,] matrix, int rows, int colmens)
        {
            Console.WriteLine("here is the matrix in it's reduced form");
            int ii = 1;
            foreach (int i in Enumerable.Range(0, rows))
            {
                int jj = 1;
                foreach (int j in Enumerable.Range(0, colmens))
                {
                    if (j == colmens - 1)
                    {
                        Console.Write("= " + matrix[i, j] + "b" + "(" + Convert.ToString(jj) + Convert.ToString(ii) + ")");
                    }
                    else
                    {
                        if (j == 0)
                        {
                            Console.Write(matrix[i, j] + "a" + "(" + Convert.ToString(jj) + Convert.ToString(ii) + ")" + " ");
                        }
                        else
                        {
                            Console.Write("+ " + matrix[i, j] + "a" + "(" + Convert.ToString(jj) + Convert.ToString(ii) + ")" + " ");
                        }
                    }
                    Convert.ToInt16(jj);
                    jj++;
                }
                Console.WriteLine();
                Convert.ToInt16(ii);
                ii++;
            }
        }
        static int reduce(float[,] matrix , int rows)
        {
            int i,j,k = 0 , c, eror = 0;
            for ( i = 0; i < rows; i++)
            {
                if (matrix[i,i]==0)
                {
                    c = 1;
                    while ((i+c)<rows && matrix[i+c, i] ==0)
                    {
                        c++;
                    }
                    if (c+i == rows)
                    {
                        eror = 1;
                        break;
                    }
                    for ( j = i, k = 0; k<= rows ; k++)
                    {
                        float temperory_storge = matrix[j + c, k];
                        matrix[j + c, k] = matrix[j, k];
                        matrix[j,k] = temperory_storge;
                    }
                }
                for (j = 0; j < rows; j++)
                {
                    if (i != j)
                    {
                        float equelizer = matrix[j, i] / matrix[i, i];
                        for (k = 0; k <= rows; k++)
                        {
                            matrix[j,k] = matrix[j,k] - (matrix[i,k]) * equelizer;
                        }
                    }
                }
            }
            return eror;
        }
        static void ask_for_erorr(float[,] matrix, int rows, int colmens)
        {
            while (true)
            {
                Console.WriteLine("is the following matrix correct?please answer with a y for yes or an n for no ");
                int ii = 1;
                foreach (int i in Enumerable.Range(0, rows))
                {
                    int jj = 1;
                    foreach (int j in Enumerable.Range(0, colmens))
                    {
                        if (j == colmens - 1)
                        {
                            Console.Write("= " + matrix[i, j] + "b" + "(" + Convert.ToString(jj) + Convert.ToString(ii) + ")");
                        }
                        else
                        {
                            if (j == 0)
                            {
                                Console.Write(matrix[i, j] + "a" + "(" + Convert.ToString(jj) + Convert.ToString(ii) + ")" + " ");
                            }
                            else
                            {
                                Console.Write("+ " + matrix[i, j] + "a" + "(" + Convert.ToString(jj) + Convert.ToString(ii) + ")" + " ");
                            }
                        }
                        Convert.ToInt16(jj);
                        jj++;
                    }
                    Console.WriteLine();
                    Convert.ToInt16(ii);
                    ii++;
                }
                char a = Convert.ToChar(Console.ReadLine());
                if (a == 'y')
                {
                    break;
                }
                Console.WriteLine("please input the index of the false varible ");
                int s = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("please input the acutal true value");
                float ss = Convert.ToSingle(Console.ReadLine());
                matrix[((s % 10) - 1), ((s / 10) - 1)] = ss;
            }
        }
        static int checksilotions(float[,] matrix, int rows,int eror)
        {
            int i, j;
            float sumation;
            eror = 3;
            for (i = 0; i < rows; i++) 
            {
                sumation = 0;
                for ( j = 0; j < rows; j++)
                {
                    sumation = sumation + matrix[i, j];

                }
                if (sumation == matrix[i,j])
                {
                    eror = 2;
                }
            }
            return eror;
        }
        static void print_result(float[,] matrix , int rows, int colmens , int eror)
        {
            Console.WriteLine("the result is");
            if (eror == 2)
            {
                Console.WriteLine("infinte sultions");
            }
            else if(eror == 3)    
            {
                Console.WriteLine("null");
            }
            else
            {
                for (int i = 0; i < rows; i++)
                {
                    Console.WriteLine("a"+ Convert.ToString(i+1) + "=" + matrix[i,rows] / matrix[i,i]);
                }
            }
        }
        static void Main(string[] args)
        {
           
            Console.WriteLine("please input the number of variables in one equation" );
            Console.WriteLine("should at least have 3 varibels and two eqations");
            int colmens = int.Parse(Console.ReadLine());
            Console.WriteLine("please input the number equation");
            int rows = int.Parse(Console.ReadLine());
            float[,] matrix = new float[rows, colmens];
            int ii = 1;
            int jj = 1;
            //a for loop to store the elements in the array
            foreach (int i  in Enumerable.Range(0,rows))
            {
                 jj = 1;
                foreach (int j in Enumerable.Range(0, colmens))
                {                   
                    Console.WriteLine("please enter the value of A" +Convert.ToString(jj) + Convert.ToString(ii));
                    matrix[i, j] = float.Parse(Console.ReadLine());
                    Convert.ToInt16(jj);
                    jj++;
                }
                Convert.ToInt16(ii);
                ii++;
            }
            ask_for_erorr(matrix, rows, colmens);
            int eror = reduce(matrix, rows);
            printmatrix(matrix, rows, colmens);
            if (eror == 1)
            {
                eror = checksilotions(matrix, rows, eror);
            }
            Console.ReadKey();
            print_result(matrix, rows, colmens,eror);
            Console.ReadKey();
            //float equalizer;
            //for (int i = 0; i < rows -1; i++)
            //{
            //    if (matrix[i, i] == 0)
            //    {
            //        for (int j = 0; j < colmens-1; j++)
            //        {
            //            matrix[i, j] += 1;
            //        }
            //    }
            //    equalizer = 1 /matrix[i,i];
            //    for (int j = 0; j < colmens-1; j++)
            //    {

            //        matrix[i,j] = matrix[i,j] * equalizer;
            //    }
            //    for (int j = 0; j < colmens-1; j++)
            //    {
            //        if (i + 1 == rows)
            //        {
            //            continue;
            //        }
            //        float ss =  -(matrix[i+1, j]);
            //        for (int k = 0; k < rows-1; k++)
            //        {
            //            if (k+ 1 == rows)
            //            {
            //                continue;
            //            }
            //            
            //            matrix[k+1, j] = matrix[k+1, j] * ss ;

            //        }

            //    }
            //}


            //a for loop to make the leaden equal to 1 
            //float[] matrix2 = new float[colmens];
            //float negative_of_the_non_leading;
            //foreach (int i in Enumerable.Range(0, rows ))
            //{

            //    //make an if for the condtion that the value is equal to zero

            //    float ss = matrix[i, i];

            //    foreach (var c in Enumerable.Range(1,rows-1))
            //    {
            //        if (c != rows)
            //        {
            //            negative_of_the_non_leading = matrix[c, i] * (-1);
            //            foreach (int iritation in Enumerable.Range(0, colmens))
            //            {
            //                matrix2[iritation] = 0;
            //            }
            //            foreach (int j in Enumerable.Range(0, colmens))
            //            {
            //                if (matrix[i, j] * (1 / ss) == 1 && j == i)
            //                {

            //                    foreach (var sh in Enumerable.Range(0, colmens))
            //                    {
            //                        matrix[i, sh] = matrix[i, sh] * (1 / ss);
            //                    }





            //                }
            //                matrix2[j] = matrix[i, j] * negative_of_the_non_leading;
            //                matrix[c, j] = matrix[c, j] + matrix2[j];


            //            }
            //        }
            //        else
            //        {
            //            foreach (int iritation in Enumerable.Range(0, colmens))
            //            {
            //                matrix2[iritation] = 0;
            //            }
            //            foreach (int j in Enumerable.Range(0, colmens))
            //            {
            //                if (matrix[i, j] * (1 / ss) == 1 && j == i)
            //                {

            //                    foreach (var sh in Enumerable.Range(0, colmens))
            //                    {
            //                        matrix[i, sh] = matrix[i, sh] * (1 / ss);
            //                    }





            //                }



            //            }
            //        }



            //    }





            //}
            //while (true)
            //{
            //    Console.WriteLine("is the following matrix correct?please answer with a y for yes or an n for no ");
            //    ii = 1;
            //    foreach (int i in Enumerable.Range(0, rows))
            //    {
            //        jj = 1;
            //        foreach (int j in Enumerable.Range(0, colmens))
            //        {
            //            if (j == colmens - 1)
            //            {

            //                Console.Write("= " + matrix[i, j] + "b" + "(" + Convert.ToString(jj) + Convert.ToString(ii) + ")");
            //            }
            //            else
            //            {
            //                if (j == 0)
            //                {
            //                    Console.Write(matrix[i, j] + "a" + "(" + Convert.ToString(jj) + Convert.ToString(ii) + ")" + " ");
            //                }
            //                else
            //                {
            //                    Console.Write("+ " + matrix[i, j] + "a" + "(" + Convert.ToString(jj) + Convert.ToString(ii) + ")" + " ");
            //                }


            //            }
            //            Convert.ToInt16(jj);
            //            jj++;
            //        }
            //        Console.WriteLine();
            //        Convert.ToInt16(ii);
            //        ii++;
            //    }
            //    char a = Convert.ToChar(Console.ReadLine());
            //    if (a == 'y')
            //    {
            //        break;
            //    }
            //    Console.WriteLine("please input the index of the false varible ");
            //    int s = Convert.ToInt16(Console.ReadLine());
            //    Console.WriteLine("please input the acutal true value");
            //    float ss = Convert.ToSingle(Console.ReadLine());
            //    matrix[((s % 10) - 1), ((s / 10) - 1)] = ss;
            //}



        }
    }
}
