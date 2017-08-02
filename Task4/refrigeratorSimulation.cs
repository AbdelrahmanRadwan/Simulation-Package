using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taskSimulation4
{
    class refrigeratorSimulation
    {
        double[] DemandCumulative = new double [200];
        double[] DemandProp = new double[200];
        int[] DemandDis = new int[200];

        int[,] arrOfZ = new int[200,200];

        Random rnd = new Random();
        showOutput newShow = new showOutput();

        int[,] day = new int [200,200];
        int[,] cycle = new int[200, 200];
        int[,] dayWithinCycle = new int[200, 200];
        int[,] beginingInventory = new int[200, 200];
        int[,] randomDemand = new int[200, 200];
        int[,] DemandVar = new int[200, 200];
        int[,] endingInventory = new int[200, 200];

        int[,] Shortage = new int[200, 200];
        int[,] orderQunat = new int[200, 200];
        int[,] randomLead = new int[200, 200];
        int[,] LeadTime = new int[200, 200];
        int[,] daysUntilArrive = new int[200, 200];
        int rand_num, rand_num2, rand_z0;


        double[] leadCumulative = new double[200];
        double[] leadProp = new double[200];
        int[] leadDis = new int[200];

        double[] EndingInventoryAverage = new double[200];
        double[] ShortageQuantityAverage = new double[200];
        double EndingInventoryAverageAll = 0.0;
        double ShortageQuantityAverageAll = 0.0;



        int quantTemp = 0;
        int indexDemand = 0;
        int indexLead = 0;
       
        void LCG(int numOfTrial,int a, int c, int m, int numDays)
        {

            
            rand_z0 = (int)(rnd.NextDouble()*(numOfTrial+1));

            arrOfZ[numOfTrial,0] = rand_z0;

            for (int i = 1; i < numDays; i++)
            {
                arrOfZ[numOfTrial,i] = (a * arrOfZ[numOfTrial,i - 1]);
                arrOfZ[numOfTrial,i] = arrOfZ[numOfTrial,i] + c;
                arrOfZ[numOfTrial,i] = arrOfZ[numOfTrial,i] % m;
             
            }
          
        }

        public bool Demand(int num, double probability)
        {
            probability = Math.Round(probability, 2);
            probability = probability * 100;

            if (indexDemand == 0)
            {
                DemandCumulative[0] = probability;
            }
            if (indexDemand != 0)
            {
                double temp = DemandCumulative[indexDemand - 1] + probability;

                if (temp > 100)
                {

                    return false;
                }
            }

            if (indexDemand != 0)
            {
                DemandCumulative[indexDemand] = DemandCumulative[indexDemand - 1] + probability;
            }

            DemandDis[indexDemand] = num;
            DemandProp[indexDemand] = probability;
            indexDemand++;

            return true;
        }

        public bool leadTime(int num, double probability)
        {
            probability = Math.Round(probability, 2);
            probability = probability * 100;

            if (indexLead == 0)
            {
                leadCumulative[0] = probability;
            }
            if (indexLead != 0)
            {
                double temp = leadCumulative[indexLead - 1] + probability;

                if (temp > 100)
                {

                    return false;
                }
            }

            if (indexLead != 0)
            {
                leadCumulative[indexLead] = leadCumulative[indexLead - 1] + probability;
            }

            leadDis[indexLead] = num;
            leadProp[indexLead] = probability;
            indexLead++;

            return true;
        }


        int getDemand(int T,int index)
        {

            rand_num = arrOfZ[T,index];
            

            for (int k = 0; k < indexDemand; k++)
            {
                if (rand_num <= DemandCumulative[k])
                {
                    return DemandDis[k];

                }
                else
                {
                    continue;
                }
            }
            return 0;
        }

        int getLeadTime(int T,int index)
        {

            rand_num2 = arrOfZ[T,index];
      

            for (int k = 0; k < indexLead; k++)
            {
                if (rand_num2 <= leadCumulative[k])
                {
                    return leadDis[k];

                }
                else
                {
                    continue;
                }
            }
            return 0;
        }

        public void simulateTrials(int numTrials,int numOfDays, int M, int N, int a, int c, int m)
        {
            for (int k = 0; k < numTrials; k++)
            {
                calculate(k, numOfDays, M, N, a, c, m);

                newShow.simulate(day, cycle, dayWithinCycle, beginingInventory, randomDemand,
                     DemandVar, endingInventory, Shortage, orderQunat, randomLead, LeadTime,
                     daysUntilArrive, numOfDays);

                newShow.outputAverageAll(EndingInventoryAverageAll / (double)numTrials, ShortageQuantityAverageAll / (double)numTrials);
                newShow.Show();
            }
            
        }

       
        void setDay0Cycle0(int T,int startLevel)
        {
            EndingInventoryAverage[T] = 0.0;
            ShortageQuantityAverage[T] = 0.0;

            cycle[T,0] = 1;
            day[T,0] = 1;
            dayWithinCycle[T,0] = 1; 
            beginingInventory[T,0] = startLevel;

            DemandVar[T,0] = getDemand(T,0);
            randomDemand[T,0] = rand_num;

            LeadTime[T,0] = getLeadTime(T,0);
            randomLead[T,0] = rand_num2;

            daysUntilArrive[T,0] = getLeadTime(T,0);

            if (DemandVar[T,0] > startLevel)
            {
                Shortage[T,0] = DemandVar[T,0] - startLevel;
                endingInventory[T,0] = 0;
            }
            else
            {
                endingInventory[T,0] = startLevel - DemandVar[T,0];
                
                Shortage[T,0] = 0;
            }

            EndingInventoryAverage[T] += endingInventory[T,0];
            ShortageQuantityAverage[T] += Shortage[T,0];

          
        }

        void calculate(int T, int numOfDays, int M, int N, int a, int c, int m)
        {
            int i = 0;

            LCG(T, a, c, m, numOfDays);

            setDay0Cycle0(T, M);

            for (int l = 1; l < numOfDays; l++)
            {

                if (l % N == 0)
                {
                    cycle[T,l] = cycle[T,l - 1] + 1;
                    i = 0;

                }
                else
                {
                    cycle[T,l] = cycle[T,l - 1];
                    i++;
                }

                dayWithinCycle[T,l] = i + 1;
                day[T,l] = l + 1;

                DemandVar[T,l] = getDemand(T, l);
                randomDemand[T,l] = rand_num;

                if (daysUntilArrive[T,l - 1] == 0 && (l-2) == -1 || daysUntilArrive[T,l - 1] == 0 && daysUntilArrive[T,l - 2] != 0)
                {
                    beginingInventory[T,l] = quantTemp + endingInventory[T,l - 1];

                    if (DemandVar[T, l] <= beginingInventory[T, l])
                    {
                        endingInventory[T,l] = beginingInventory[T,l] - DemandVar[T,l];
                    
                        endingInventory[T, l] = endingInventory[T, l] - Shortage[T, l - 1];
                        Shortage[T, l] = 0;
                    }
                    else
                    {
                        Shortage[T, l] = DemandVar[T, l] - beginingInventory[T, l];
                        endingInventory[T, l] = 0;
                    }

                }
                else
                {
                    beginingInventory[T,l] = endingInventory[T,l - 1];

                    if (DemandVar[T,l] <= endingInventory[T,l - 1])
                    {
                        endingInventory[T, l] = endingInventory[T, l - 1] - DemandVar[T, l];
                    }
                    else
                    {
                        Shortage[T, l] = DemandVar[T, l] - endingInventory[T, l - 1];
                        Shortage[T, l] = Shortage[T, l - 1] + Shortage[T, l];
                        endingInventory[T, l] = 0;
                    }
                }

                if ((l + 1) % N == 0)
                {
                    if (Shortage[T,l] != 0)
                    {
                        orderQunat[T,l] = M + Shortage[T,l];
                    }
                    else
                    {
                        orderQunat[T,l] = M - endingInventory[T,l];
                    }
                    quantTemp = orderQunat[T,l];

                    LeadTime[T,l] = getLeadTime(T, cycle[T,l]);
                    randomLead[T,l] = rand_num2;
                    daysUntilArrive[T,l] = LeadTime[T,l];
                }
                else
                {

                    daysUntilArrive[T,l] = daysUntilArrive[T,l - 1] - 1;
                    if (daysUntilArrive[T,l] < 0)
                        daysUntilArrive[T,l] = 0;
                }

                EndingInventoryAverage[T] += endingInventory[T,l];
                ShortageQuantityAverage[T] += Shortage[T,l];

            }

            double temp1, temp2;
            temp1 = (EndingInventoryAverage[T] / (double)numOfDays);
            temp2 = (ShortageQuantityAverage[T] / (double)numOfDays);
            newShow.outputAverage(temp1,temp2);

            EndingInventoryAverageAll += temp1;
            ShortageQuantityAverageAll += temp2;

        }


    }
}
