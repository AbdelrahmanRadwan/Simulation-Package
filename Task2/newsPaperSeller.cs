using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace simulationTask2
{

    class newsPaperSeller
    {
        Output plotOutput = new Output();

        static double totalRevenue = 0.0;
        static double totalCost = 0.0;
        static double totalLostProfit = 0.0;
        static double totalSalvage = 0.0;
        static double netProfit = 0.0;
        static int numDaysExcess = 0;
        static int numDaysUnsold = 0;

        double randomType;
        string DayType;
        Random rnd = new Random();

        static int index = 0;
        static int indexType = 0;
        
        string[] DayName = new string[3];
        double[] comulativeProbabilityOfDays = new double[10];

        int[] DemandArray = new int[100];
        int[] DemandOfDay = new int[100];

   
        double[] GoodDemandCumulative = new double[10];
        double[] FairDemandCumulative = new double[10];
        double[] PoorDemandCumulative = new double[10];

        double[] revenue = new double[100];
        double[] lostProfit = new double[100];
        double[] salvage = new double[100];
        double[] dailyProfit = new double[100];

       public void initialize()
        {
            
            comulativeProbabilityOfDays[0] = 0;
            GoodDemandCumulative[0] = 0;
            FairDemandCumulative[0] = 0;
            PoorDemandCumulative[0] = 0;

        }
     public  bool probabilitiesOfTypes(string Type,double dayProb)
        {
           
           dayProb = Math.Round(dayProb, 2);

           if(Type == "Good")
           {
               DayName[indexType] = "Good";
               indexType++;
           }
           else if (Type == "Fair")
           {
               DayName[indexType] = "Fair";
               indexType++;
           }
           else if (Type == "Poor")
           {
               DayName[indexType] = "Poor";
               indexType++;
           }
                double temp = comulativeProbabilityOfDays[indexType-1] + dayProb;

                if (temp > 1)
                {

                    return false;
                }
                comulativeProbabilityOfDays[indexType] = Math.Round(comulativeProbabilityOfDays[indexType-1] + dayProb, 2);

                
            return true;
        }

    public bool DistributionOfDemand( double GoodDayProb,double FairDayProb,double PoorDayProb,int Demand)
       {

           DemandArray[index] = Demand;
           GoodDayProb = Math.Round(GoodDayProb, 2);
           FairDayProb = Math.Round(FairDayProb, 2);
           PoorDayProb = Math.Round(PoorDayProb, 2);
           index++;

                  double temp = GoodDemandCumulative[index-1] + GoodDayProb;

                  GoodDemandCumulative[index] = Math.Round(GoodDemandCumulative[index-1] + GoodDayProb, 2);

                   temp = FairDemandCumulative[index ] + FairDayProb;

                   FairDemandCumulative[index] = Math.Round(FairDemandCumulative[index-1] + FairDayProb, 2);
                 
                  temp = PoorDemandCumulative[index] + PoorDayProb;

                  PoorDemandCumulative[index] = Math.Round(PoorDemandCumulative[index-1] + PoorDayProb, 2);

           return true;

       }

      public void simulateTable(int numDays,double purchasePrice, double sellPrice, double scarpValue, double papersPurchased)
       {

            double rnd1,rnd2;
            for(int i=0;i<numDays;i++)
            {
                
            randomType = Math.Round(rnd.NextDouble(), 2);
               
                  for(int j =0 ;j <3;j++)
                  {
                      if (randomType <= comulativeProbabilityOfDays[j+1])
                      {
                          DayType = DayName[j];
                          break;
                      }
                  }
                  rnd1 = randomType * 100;
             randomType = Math.Round(rnd.NextDouble(), 2);
                
                if(DayType == "Good")
                {
                    for(int g=0;g<GoodDemandCumulative.Length-1;g++)
                    {
                        if (randomType <= GoodDemandCumulative[g+1])
                        {
                            DemandOfDay[i] = DemandArray[g];
                            break;
                        }
                    }
                }
                else if(DayType == "Fair")
                {
                    for (int f = 0; f < FairDemandCumulative.Length-1; f++)
                    {
                        if (randomType <= FairDemandCumulative[f+1])
                        {
                            DemandOfDay[i] = DemandArray[f];
                            break;
                        }
                    }
                }
                else
                {
                    for (int p = 0; p < PoorDemandCumulative.Length-1; p++)
                    {
                        if (randomType <= PoorDemandCumulative[p+1])
                        {
                            DemandOfDay[i] = DemandArray[p];
                            break;
                        }
                    }
                }

              if(DemandOfDay[i] > papersPurchased)
              {
                         revenue[i] = papersPurchased * sellPrice;
                         lostProfit[i] = (DemandOfDay[i] - papersPurchased)*(sellPrice - purchasePrice);
                         salvage[i] =0;
              }
            else
              {
                         revenue[i] = DemandOfDay[i] * sellPrice;
                         salvage[i] = (papersPurchased-DemandOfDay[i])*scarpValue;
                         lostProfit[i]=0;
              }

              dailyProfit[i] = revenue[i] - (papersPurchased * purchasePrice);


              if (DemandOfDay[i] > papersPurchased)
              {
                  dailyProfit[i] -= lostProfit[i];
                  numDaysExcess++;
              }
              else
              {
                  dailyProfit[i] += salvage[i];

                  if (papersPurchased > DemandOfDay[i])
                  numDaysUnsold++;
              }
              rnd2 = randomType * 100;

              totalRevenue += revenue[i];
              totalLostProfit += lostProfit[i];
              totalCost = papersPurchased * purchasePrice;
              totalSalvage += salvage[i];
              netProfit += dailyProfit[i];


           plotOutput.simulate(i+1, rnd1, DayType, rnd2, DemandOfDay[i], revenue[i],lostProfit[i], salvage[i], dailyProfit[i]);
         
            }
            plotOutput.calculations(totalRevenue, totalCost, totalLostProfit, totalSalvage,
            netProfit, numDaysExcess, numDaysUnsold);
            plotOutput.Show();
       }

    }
}
