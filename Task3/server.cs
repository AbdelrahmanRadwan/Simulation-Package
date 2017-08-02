using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SimulationTask1
{
    class server
    {

     
        tableAndCharts plotTable = new tableAndCharts();
        Random rnd = new Random();
        measuresOfperformance measure = new measuresOfperformance();
        serversChart idleCharts = new serversChart();

        double[] interarrivalTime = new double[300];
        double[] ableserviceDur = new double[300];
        double[] bakerserviceDur = new double[300];
        double[] arrivalTime = new double[300];


        double[] timeServiceBegins = new double[300];
        double[] serviceDuration = new double[300];
        double[] timeServiceEnd = new double[300];
        double[] totalDelay = new double[300];

        int[] customerNumber = new int[300];
        int[] ableCust = new int[300];
        int[] bakerCust = new int[300];
        int[] serverIndex = new int[300];
        int[] customerWait = new int[300];
      
        int indexBaker, indexAble, index, ableNumCust, bakerNumCust;

        double rand_num, rand_num_two, ableAVG, BakerTotal, timesAbleWork, AbleTotal, 
            timesBakerWork, sumAbleWork, sumBakerWork, timesWaiting, sumWaiting, maxLength,
            bakerAVG, waitingAVG, probabilityOfWait, probabilityOfAbleIdle,probabilityOfBakerIdle,
            totalIdleTimeAble, totalIdleTimeBaker,probabilityOfIdletime, avgServerTime;


        //bet-initalize awel row ely mo3zamo zeroes
        void initializeFirstRow(double Beta)
        {
            ableNumCust = 0;
            ableCust[ableNumCust] = 0;
            ableNumCust++;
            bakerNumCust = 0;
            totalIdleTimeAble = 0;
            totalIdleTimeBaker = 0;
            customerWait[0] = 0;
            maxLength = 0;
            timesAbleWork = 0;
            timesBakerWork = 0;
            timesWaiting = 0;
            sumWaiting = 0;
            sumAbleWork = 0;
            sumBakerWork = 0;
            customerNumber[0] = 0;
            AbleTotal = 0;
            BakerTotal = 0;
            arrivalTime[0] = 0;
            serverIndex[0] = 1;
            timeServiceBegins[0] = 0;
            serviceDuration[0] = getAbleServiceDuration(Beta);
            AbleTotal += serviceDuration[0];
            timeServiceEnd[0] = timeServiceBegins[0] + serviceDuration[0];
            timesAbleWork += 1;
            sumAbleWork += serviceDuration[0];
            interarrivalTime[0] = 0;
            arrivalTime[0] = 0;
            totalDelay[0] = 0;
            plotTable.simulate(customerNumber[0], 0, interarrivalTime[0], arrivalTime[0], serverIndex[0], timeServiceBegins[0], rand_num_two, serviceDuration[0], timeServiceEnd[0], totalDelay[0]);
            plotTable.Show();
           
        }

      
        double getInterArrivaltime(double Beta)
        {

            rand_num = rnd.NextDouble();
            rand_num = Math.Round(rand_num, 3);

            Beta *= -1;
            double temp = Math.Log(rand_num);
            interarrivalTime[index] = Math.Round(Beta * temp,3);

            return interarrivalTime[index];
        }

        double getAbleServiceDuration(double Beta)
        {

            rand_num_two = rnd.NextDouble();
            rand_num_two = Math.Round(rand_num_two, 3);
            Beta *= -1;
            double temp = Math.Log(rand_num_two);
            ableserviceDur[index] = Math.Round(Beta * temp,3);
            return ableserviceDur[index];
        }


        double getBakerServiceDuration(double Beta)
        {

            rand_num_two = rnd.NextDouble();
            rand_num_two = Math.Round(rand_num_two, 3);
            
            Beta *= -1;
            double temp = Math.Log(rand_num_two);
            bakerserviceDur[index] = Math.Round(Beta * temp,3);

            return bakerserviceDur[index];
        }


        //bt3mel simulation lel server mn awel ma bada2 lel a5er w bageb mnha el max length lel queue
        void QueueSimulation(double endTime, int numberOfcustomers)
        {
            int customersWait;
                
                for(double i =0; i<endTime;i+=0.1)
                {
                    customersWait = 0;  
                    for(int j =1 ; j<numberOfcustomers;j++)
                    {

                        if (timeServiceBegins[j] >= i && arrivalTime[j]<i)
                        {
                            customersWait++;
                        }
                        if (customersWait > maxLength)
                            maxLength = customersWait;
                          
                    }
                }
            
        }


        //bt-assign el sevice le able w btset el information lel service de w le able 
        void assignAble(int i,double Beta)
        {
            serverIndex[i] = 1;
            if (timeServiceEnd[ableCust[ableNumCust-1]] <= arrivalTime[i])
            {
               
                timeServiceBegins[i] = arrivalTime[i];
                totalIdleTimeAble += (arrivalTime[i] - timeServiceEnd[ableCust[ableNumCust-1]]);
                 
            }
            else
            {
                timeServiceBegins[i] = timeServiceEnd[ableCust[ableNumCust-1]];
                timesWaiting++;
                sumWaiting += timeServiceBegins[i] - arrivalTime[i];
            }

            serviceDuration[i] = getAbleServiceDuration(Beta);

            AbleTotal += serviceDuration[i];

            timeServiceEnd[i] = timeServiceBegins[i] + serviceDuration[i];
            timesAbleWork++;
            sumAbleWork += serviceDuration[i];
            totalDelay[i] = Math.Round(timeServiceBegins[i] - arrivalTime[i],3);

            ableCust[ableNumCust] = i;
            ableNumCust++;
           
        }

        //bt-assign el sevice le baker w btset el information lel service de w le baker
        void assignBaker(int i,double Beta)
        {
            serverIndex[i] = 2;
            if (bakerNumCust == 0 || timeServiceEnd[bakerCust[bakerNumCust-1]] <= arrivalTime[i])
            {

                if (bakerNumCust == 0)
                {
                    totalIdleTimeBaker += arrivalTime[i];
                }
                else
                {
                    totalIdleTimeBaker += (arrivalTime[i] - timeServiceEnd[bakerCust[bakerNumCust - 1]]);
                }

                timeServiceBegins[i] = arrivalTime[i];
                
            }
            else
            {
                timeServiceBegins[i] = timeServiceEnd[bakerCust[bakerNumCust-1]];
                timesWaiting++;
                sumWaiting += timeServiceBegins[i] - arrivalTime[i];
            }
           
            serviceDuration[i] = getBakerServiceDuration(Beta);
            BakerTotal += serviceDuration[i];
            timeServiceEnd[i] = timeServiceBegins[i] + serviceDuration[i];
            timesBakerWork++;
            sumBakerWork += serviceDuration[i];
            totalDelay[i] = timeServiceBegins[i] - arrivalTime[i];
            bakerCust[bakerNumCust] = i;
            bakerNumCust++;
         
        }

  
        //btshuf hatedy el service le min 3la asas el lowest Method -meen 2a2al 7ad eshta3'al-
        void lowestMethod(int i,double AbleBeta,double BakerBeta,double interarrivalBeta)
        {


            customerNumber[i] = i + 1;

            interarrivalTime[i] = getInterArrivaltime(interarrivalBeta);

            arrivalTime[i] = interarrivalTime[i] + arrivalTime[i - 1];
            if (bakerNumCust == 0)
            {
                assignBaker(i,BakerBeta);
            }
            else if ((timeServiceEnd[bakerCust[bakerNumCust - 1]] <= arrivalTime[i] && timeServiceEnd[ableCust[ableNumCust - 1]] <= arrivalTime[i]) ||

                (timeServiceEnd[bakerCust[bakerNumCust - 1]] > arrivalTime[i] && timeServiceEnd[ableCust[ableNumCust - 1]] > arrivalTime[i]))
            {
                if (AbleTotal <= BakerTotal)
                {
                    assignAble(i,AbleBeta);
                }
                else
                {
                    assignBaker(i,BakerBeta);
                }

            }
            else if (timeServiceEnd[ableCust[ableNumCust - 1]] <= arrivalTime[i])
            {
                assignAble(i,AbleBeta);
            }
            else
            {
               assignBaker(i,BakerBeta);
            }

            plotTable.simulate(customerNumber[i], rand_num, interarrivalTime[i], arrivalTime[i], serverIndex[i], timeServiceBegins[i], rand_num_two, serviceDuration[i], timeServiceEnd[i], totalDelay[i]);
            plotTable.Show();
        }


        //btshuf hatedy el service le min 3la asas el priority el a3la -ely dayman btkon le able-
        void priorityMethod(int i,double AbleBeta,double BakerBeta,double interarrivalBeta)
        {
            customerNumber[i] = i + 1;

            interarrivalTime[i] = getInterArrivaltime(interarrivalBeta);

            arrivalTime[i] = interarrivalTime[i] + arrivalTime[i - 1];
           
            if (timeServiceEnd[ableCust[ableNumCust - 1]] < arrivalTime[i])
                
            {
                assignAble(i,AbleBeta);
            }
            else if (bakerNumCust == 0 || timeServiceEnd[bakerCust[bakerNumCust - 1]] < arrivalTime[i])
            {
                assignBaker(i,BakerBeta);
            }
            else if((timeServiceEnd[ableCust[ableNumCust - 1]] - arrivalTime[i] <= timeServiceEnd[bakerCust[bakerNumCust - 1]] - arrivalTime[i]))
            {
                assignAble(i,AbleBeta);
            }
            else
            {
                assignBaker(i,BakerTotal);
            }
            plotTable.simulate(customerNumber[i], rand_num, interarrivalTime[i], arrivalTime[i], serverIndex[i], timeServiceBegins[i], rand_num_two, serviceDuration[i], timeServiceEnd[i], totalDelay[i]);
            plotTable.Show();
        }


        //btedy el service le ay random number tetala3o - ya 1 ya 2- lma el etnin ykono fadyeen
        void randomMethod(int i,double AbleBeta,double BakerBeta,double interarrivalBeta)
        {
            customerNumber[i] = i + 1;

            interarrivalTime[i] = getInterArrivaltime(interarrivalBeta);

            arrivalTime[i] = interarrivalTime[i] + arrivalTime[i - 1];

            timeServiceEnd[bakerCust[0]] = 0;
            bakerNumCust++;
           
            if ((timeServiceEnd[ableCust[ableNumCust - 1]] <= arrivalTime[i]) && (timeServiceEnd[bakerCust[bakerNumCust - 1]] <= arrivalTime[i]))
            {
                serverIndex[i] = rnd.Next(1, 2);

                if (serverIndex[i] == 1)
                {
                    assignAble(i,AbleBeta);
                }

                else
                {
                    assignBaker(i,BakerTotal);
                }
            }
            else if(timeServiceEnd[ableCust[ableNumCust - 1]] <= arrivalTime[i])
            {
                assignAble(i,AbleBeta);
            }
            else
            {
                assignBaker(i,BakerBeta);
            }

          
            plotTable.simulate(customerNumber[i], rand_num, interarrivalTime[i], arrivalTime[i], serverIndex[i], timeServiceBegins[i], rand_num_two, serviceDuration[i], timeServiceEnd[i], totalDelay[i]);
            plotTable.Show();
        }


        //Calculate the Measures of Performance
       public void Calculations(double sumofcustomers,double endTime)
        {

            if (timesAbleWork != 0)
                ableAVG = sumAbleWork / (double)timesAbleWork;
           

            if (timesBakerWork != 0)
                bakerAVG = sumBakerWork / (double)timesBakerWork;
           

            if (sumofcustomers  != 0)
                waitingAVG = sumWaiting / (double)sumofcustomers;

            if (sumofcustomers != 0)
                probabilityOfWait = timesWaiting / (double)sumofcustomers;


            if (endTime != 0)
                probabilityOfAbleIdle = totalIdleTimeAble / (double)endTime;


            if (endTime != 0)
                probabilityOfBakerIdle = totalIdleTimeBaker / (double)endTime;


            measure.measurePerformance(Math.Round(ableAVG,3),Math.Round(bakerAVG,3), Math.Round(waitingAVG,3), maxLength,
                Math.Round(probabilityOfWait,3),Math.Round(probabilityOfAbleIdle,3), Math.Round(probabilityOfBakerIdle,3));
            measure.Show();
        }


        //bt-plot el table w el charts 3la 7asab hwa single server or multi -2 server-
        void plotAndCalculate(int numOfCustomers,string status)
       {
          

           QueueSimulation(timeServiceEnd[numOfCustomers - 1],customerNumber[numOfCustomers-1]);
          
          
           plotTable.plotChart(timeServiceEnd[numOfCustomers - 1],timeServiceBegins, arrivalTime, numOfCustomers);
           plotTable.plotDelayChart(numOfCustomers, totalDelay);
           plotTable.Show();

           idleCharts.plotChartAble(ableCust, ableNumCust, timeServiceBegins, timeServiceEnd, numOfCustomers - 1);
           idleCharts.plotChartBaker(bakerCust, bakerNumCust, timeServiceBegins, timeServiceEnd, numOfCustomers - 1);
           idleCharts.Show();

           Calculations(customerNumber[numOfCustomers - 1], timeServiceEnd[numOfCustomers - 1]);

         
       }

     //bt-set kol el inforamtion bta3et el service le single server w el user me5tar en el sever y-stop lma 3add kol el customers ely medeholy y5las
     public void singleServerAllCustomers(int numOfCustomers,double interarrivalBeta,double AbleBeta)
        {
            initializeFirstRow(interarrivalBeta);

            for (int i = 1; i < numOfCustomers; i++)
            {
                customerNumber[i] = i + 1;

                interarrivalTime[i] = getInterArrivaltime(interarrivalBeta);

                arrivalTime[i] = interarrivalTime[i] + arrivalTime[i - 1];

                serverIndex[i] = 1;

                assignAble(i,AbleBeta);

                plotTable.simulate(customerNumber[i], rand_num, interarrivalTime[i], arrivalTime[i], serverIndex[i], timeServiceBegins[i], rand_num_two, serviceDuration[i], timeServiceEnd[i], totalDelay[i]);
                plotTable.Show();
            }


            plotAndCalculate(numOfCustomers, "single");
        }



     //bt-set kol el inforamtion bta3et el service le single server w el user me5tar en el sever y-stop lma awsal lel time ely medeholy
     public void singleServerEndOfTime(int endOfTime,double interarrivalBeta,double AbleBeta)
      {

        int i = 0;
        initializeFirstRow(interarrivalBeta);
        while(timeServiceEnd[i] < endOfTime)
            {
                i++;

                customerNumber[i] = i + 1;

                interarrivalTime[i] = getInterArrivaltime(interarrivalBeta);

                arrivalTime[i] = interarrivalTime[i] + arrivalTime[i - 1];

                serverIndex[i] = 1;

                assignAble(i,AbleBeta);

                plotTable.simulate(customerNumber[i], rand_num, interarrivalTime[i], arrivalTime[i], serverIndex[i], timeServiceBegins[i], rand_num_two, serviceDuration[i], timeServiceEnd[i], totalDelay[i]);
                plotTable.Show();
          }
        i++;
        plotAndCalculate(i, "single");


    }


     /*bt-set kol el inforamtion bta3et el service le multi servers 3la 
      7asam el method ely el user me5tarha w el simulation y-stop lma awsal lel time ely medeholy el user*/
     public void multiServerQueueEndOfTime(string method, int endOfTime, double interarrivalBeta, double AbleBeta,double BakerBeta)
     {
         int i =0;

         initializeFirstRow(interarrivalBeta);

       
            if (method == "lowest utilization")
            {
                while (timeServiceEnd[i] < endOfTime)
                {
                    i++;

                    lowestMethod(i,AbleBeta,BakerBeta,interarrivalBeta);
                }
            }

            else if (method == "highest priority")
            {
                 while (timeServiceEnd[i] < endOfTime)
                {
                    i++;

                    priorityMethod(i, AbleBeta, BakerBeta, interarrivalBeta);
                }
            }
            else
            {
                 while (timeServiceEnd[i] < endOfTime)
                {
                    i++;

                    randomMethod(i, AbleBeta, BakerBeta, interarrivalBeta);
                }
            }
            i++;
            plotAndCalculate(i, "multi");

      }



     /*bt-set kol el inforamtion bta3et el service le multi servers 3la 
      7asam el method ely el user me5tarha w el simulation y-stop lma 3add el customers ely el user medeholy*/
     public void multiServerQueueAllCustomers(string method,int numOfCustomers,double interarrivalBeta,double AbleBeta,double BakerBeta)
      {
          initializeFirstRow(interarrivalBeta);

          if (method == "lowest utilization")
          {

              for (int i = 1; i < numOfCustomers; i++)
              {
                  lowestMethod(i, AbleBeta, BakerBeta, interarrivalBeta);
              }

          }

          else if (method == "highest priority")
          {

              for (int i = 1; i < numOfCustomers; i++)
              {
                  priorityMethod(i, AbleBeta, BakerBeta, interarrivalBeta);
              }
          }

          else
          {
              for (int i = 1; i < numOfCustomers; i++)
              {
                  randomMethod(i, AbleBeta, BakerBeta, interarrivalBeta);
              }


          }


          plotAndCalculate(numOfCustomers, "multi");
     
      }

    }
}
