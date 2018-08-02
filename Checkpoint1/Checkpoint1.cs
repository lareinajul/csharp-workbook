using System;

namespace Checkpoint1
{
    class Program
    {
        int count = 0;
        static void Main(string[] args)
        {
            
        }

        void NumberCheck()
        {
            for(var i=1; i<101;i++)
            {
                var r = i%3;
                var checkResult=RemainderCheck(r);

                if(checkResult)
                {
                    count = count++;
                }
               
               Console.WriteLine(count);

            }
        }


        bool RemainderCheck(int  r)
        {
            //return r==0 ? true : false;
            if (r==0)
            {
                return true;
            }
            else {
                return false;
            }
        }

    }
}
