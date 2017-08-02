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

        double[] serviceTimeCumulativeBaker = new double[300];
        double[] serviceTimeCumulativeAble = new double[300];
        double[] interarrivalTimeCumulative = new double[300];
        double[] bakerserviceProp = new double[300];
        double[] ableserviceProp = new double[300];
        double[] interArrivalProp = new double[300];

           
        int[] bakerserviceDur = new int[300];
        int[] ableserviceDur = new int[300];
        int[] customerNumber = new int[300];
        int[] interarrivalTime = new int[300];
        int[] arrivalTime = new int[300];
        int[] serverIndex = new int[300];
        int[] timeServiceBegins = new int[300];
        int[] serviceDuration = new int[300];
        int[] timeServiceEnd = new int[300];
        int[] totalDelay = new int[300];
        int[] interArrivalDis = new int[300];
        int[] customerWait = new int[300];
        int[] ableCust = new int[300];
        int[] bakerCust = new int[300];



        int indexBaker, indexAble, index, AbleTotal, BakerTotal, timesAbleWork,
            timesBakerWork, sumAbleWork, sumBakerWork, timesWaiting, sumWaiting,
            maxLength, totalIdleTimeAble, totalIdleTimeBaker,ableNumCust,bakerNumCust;

        double rand_num, rand_num_two, ableAVG, bakerAVG, waitingAVG, probabilityOfWait, probabilityOfAbleIdle, probabilityOfBakerIdle,
               probabilityOfIdletime, avgServerTime;

        //bta5od el Service Time distribution le able w bttcheck lw el probabilities akbr mn 1
        public bool serviceTimeAble(int num, double probability)
        {
            serviceTimeCumulativeAble[0] = ableserviceProp[0];


            if (indexAble != 0)
            {
                double temp = serviceTimeCumulativeAble[indexAble - 1] + probability;


                if (temp > 1)
                {

                    return false;
                }
            }

            probability = Math.Round(probability, 3);
           

            if (indexAble != 0)
            {
                serviceTimeCumulativeAble[indexAble] = Math.Round(serviceTimeCumulativeAble[indexAble - 1] + probability,3);
            }

            ableserviceDur[indexAble] = num;
            ableserviceProp[indexAble] = probability;
            indexAble++;

           
            return true;
        }


        //bta5od el Service Time distribution  le baker w bttcheck lw el probabilities akbr mn 1
        public  bool serviceTimeBaker(int num,double probability)
        {
            serviceTimeCumulativeBaker[0] = bakerserviceProp[0];

            if (indexBaker != 0)
            {
                double temp = serviceTimeCumulativeBaker[indexBaker - 1] + probability;

                if (temp > 1)
                {

                    return false;
                }
            }
            probability = Math.Round(probability, 3);
          

            if (indexBaker != 0)
            {
                serviceTimeCumulativeBaker[indexBaker] = Math.Round(serviceTimeCumulativeBaker[indexBaker - 1] + probability,3);
            }


            bakerserviceDur[indexBaker] = num;
            bakerserviceProp[indexBaker] =  probability;
            indexBaker++;
           
            return true;
        }


        //bta5od el Interarrival Distribution of calls w bttcheck lw el probabilities akbr mn 1
        public  bool interArrivalTime(int num, double probability)
        {
            interarrivalTimeCumulative[0] = interArrivalProp[0];
            probability = Math.Round(probability, 3);

            if (index != 0)
            {
                double temp = interarrivalTimeCumulative[index - 1] + probability;

                if (temp > 1)
                {

                    return false;
                }
            }

            if (index != 0)
            {
                interarrivalTimeCumulative[index] = Math.Round(interarrivalTimeCumulative[index - 1] + probability,3);
            }

            interArrivalDis[index] = num;
            interArrivalProp[index] = probability;
            index++;
           
            return true;
        }


        //bet-initalize awel row ely mo3zamo zeroes
        void initializeFirstRow()
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
            serviceDuration[0] = getAbleServiceDuration();
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


        //btgeb ay rakam random mn .0 to 1 w tshuf hwa fe anhy range mn el Service Time distribution bta3et able w tedeny service duration
        int getAbleServiceDuration()
        {

            rand_num_two = rnd.NextDouble();
            rand_num_two = Math.Round(rand_num_two, 3);

            for (int k = 0; k < indexAble; k++)
            {
                if (rand_num_two <= serviceTimeCumulativeAble[k])
                {
                    return ableserviceDur[k];

                }
                else
                {
                    continue;
                }
            }
            return 0;
        }


        //btgeb ay rakam random mn .0 to 1 w tshuf hwa fe anhy range mn el Interarrival Distribution w tedeny service duration
        int getInterArrivaltime()
        {

            rand_num = rnd.NextDouble();
            rand_num = Math.Round(rand_num, 3);

            for (int k = 0; k < index; k++)
            {
                if (rand_num <= interarrivalTimeCumulative[k])
                {
                    return interArrivalDis[k];

                }
                else
                {
                    continue;
                }
            }
            return 0;
        }


        //btgeb ay rakam random mn .0 to 1 w tshuf hwa fe anhy range mn el Service Time distribution bta3et baker w tedeny service duration
        int getBakerServiceDuration()
        {

            rand_num_two = rnd.NextDouble();
            rand_num_two = Math.Round(rand_num_two, 3);

            for (int k = 0; k < indexBaker; k++)
            {
                if (rand_num_two <= serviceTimeCumulativeBaker[k])
                {
                    return bakerserviceDur[k];

                }
                else
                {
                    continue;
                }
            }
            return 0;
        }


        //bt3mel simulation lel server mn awel ma bada2 lel a5er w bageb mnha el max length lel queue
        void QueueSimulation(int endTime, int numberOfcustomers)
        {
            int customersWait;
                
                for(int i =0; i<endTime;i++)
                {
                    customersWait = 0;  
                    for(int j =1 ; j<numberOfcustomers;j++)
                    {

                        if (timeServiceBegins[j] >= i && arrivalTime[j]<i )
                        {
                            customersWait++;



                            
                        }
                        if (customersWait > maxLength)
                            maxLength = customersWait;
                          
                    }
                }
            
            
           
       }


        //bt-assign el sevice le able w btset el information lel service de w le able 
        void assignAble(int i)
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

            serviceDuration[i] = getAbleServiceDuration();

            AbleTotal += serviceDuration[i];

            timeServiceEnd[i] = timeServiceBegins[i] + serviceDuration[i];
            timesAbleWork++;
            sumAbleWork += serviceDuration[i];
            totalDelay[i] = timeServiceBegins[i] - arrivalTime[i];

            ableCust[ableNumCust] = i;
            ableNumCust++;
           
        }

        //bt-assign el sevice le baker w btset el information lel service de w le baker
        void assignBaker(int i)
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
           
            serviceDuration[i] = getBakerServiceDuration();
            BakerTotal += serviceDuration[i];
            timeServiceEnd[i] = timeServiceBegins[i] + serviceDuration[i];
            timesBakerWork++;
            sumBakerWork += serviceDuration[i];
            totalDelay[i] = timeServiceBegins[i] - arrivalTime[i];
            bakerCust[bakerNumCust] = i;
            bakerNumCust++;
         
        }

  
        //btshuf hatedy el service le min 3la asas el lowest Method -meen 2a2al 7ad eshta3'al-
        void lowestMethod(int i)
        {


            customerNumber[i] = i + 1;

            interarrivalTime[i] = getInterArrivaltime();

            arrivalTime[i] = interarrivalTime[i] + arrivalTime[i - 1];
            if (bakerNumCust == 0)
            {
                assignBaker(i);
            }
            else if ((timeServiceEnd[bakerCust[bakerNumCust - 1]] <= arrivalTime[i] && timeServiceEnd[ableCust[ableNumCust - 1]] <= arrivalTime[i]) ||

                (timeServiceEnd[bakerCust[bakerNumCust - 1]] > arrivalTime[i] && timeServiceEnd[ableCust[ableNumCust - 1]] > arrivalTime[i]))
            {
                if (AbleTotal <= BakerTotal)
                {
                    assignAble(i);
                }
                else
                {
                    assignBaker(i);
                }

            }
            else if (timeServiceEnd[ableCust[ableNumCust - 1]] <= arrivalTime[i])
            {
                assignAble(i);
            }
            else
            {
               assignBaker(i);
            }

            plotTable.simulate(customerNumber[i], rand_num, interarrivalTime[i], arrivalTime[i], serverIndex[i], timeServiceBegins[i], rand_num_two, serviceDuration[i], timeServiceEnd[i], totalDelay[i]);
            plotTable.Show();
        }


        //btshuf hatedy el service le min 3la asas el priority el a3la -ely dayman btkon le able-
        void priorityMethod(int i)
        {
            customerNumber[i] = i + 1;

            interarrivalTime[i] = getInterArrivaltime();

            arrivalTime[i] = interarrivalTime[i] + arrivalTime[i - 1];
           
            if (timeServiceEnd[ableCust[ableNumCust - 1]] < arrivalTime[i])
                
            {
                assignAble(i);
            }
            else if (bakerNumCust == 0 || timeServiceEnd[bakerCust[bakerNumCust - 1]] < arrivalTime[i])
            {
                assignBaker(i);
            }
            else if((timeServiceEnd[ableCust[ableNumCust - 1]] - arrivalTime[i] <= timeServiceEnd[bakerCust[bakerNumCust - 1]] - arrivalTime[i]))
            {
                assignAble(i);
            }
            else
            {
                assignBaker(i);
            }
            plotTable.simulate(customerNumber[i], rand_num, interarrivalTime[i], arrivalTime[i], serverIndex[i], timeServiceBegins[i], rand_num_two, serviceDuration[i], timeServiceEnd[i], totalDelay[i]);
            plotTable.Show();
        }


        //btedy el service le ay random number tetala3o - ya 1 ya 2-
        void randomMethod(int i)
        {
            customerNumber[i] = i + 1;

            interarrivalTime[i] = getInterArrivaltime();

            arrivalTime[i] = interarrivalTime[i] + arrivalTime[i - 1];

            serverIndex[i] = rnd.Next(1, 100);

            if (serverIndex[i] == 1)
            {
                assignAble(i);
            }

            else
            {
                assignBaker(i);
            }
            plotTable.simulate(customerNumber[i], rand_num, interarrivalTime[i], arrivalTime[i], serverIndex[i], timeServiceBegins[i], rand_num_two, serviceDuration[i], timeServiceEnd[i], totalDelay[i]);
            plotTable.Show();
        }


        //Calculate the Measures of Performance
       public void Calculations(int sumofcustomers,int endTime)
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
     public void singleServerAllCustomers(int numOfCustomers)
        {
            initializeFirstRow();

            for (int i = 1; i < numOfCustomers; i++)
            {
                customerNumber[i] = i + 1;

                interarrivalTime[i] = getInterArrivaltime();

                arrivalTime[i] = interarrivalTime[i] + arrivalTime[i - 1];

                serverIndex[i] = 1;

                assignAble(i);

                plotTable.simulate(customerNumber[i], rand_num, interarrivalTime[i], arrivalTime[i], serverIndex[i], timeServiceBegins[i], rand_num_two, serviceDuration[i], timeServiceEnd[i], totalDelay[i]);
                plotTable.Show();
            }


            plotAndCalculate(numOfCustomers, "single");
        }



     //bt-set kol el inforamtion bta3et el service le single server w el user me5tar en el sever y-stop lma awsal lel time ely medeholy
     public void singleServerEndOfTime(int endOfTime)
      {

        int i = 0;
        initializeFirstRow();
        while(timeServiceEnd[i] < endOfTime)
            {
                i++;

                customerNumber[i] = i + 1;

                interarrivalTime[i] = getInterArrivaltime();

                arrivalTime[i] = interarrivalTime[i] + arrivalTime[i - 1];

                serverIndex[i] = 1;

                assignAble(i);

                plotTable.simulate(customerNumber[i], rand_num, interarrivalTime[i], arrivalTime[i], serverIndex[i], timeServiceBegins[i], rand_num_two, serviceDuration[i], timeServiceEnd[i], totalDelay[i]);
                plotTable.Show();
          }
        i++;
        plotAndCalculate(i, "single");


    }


     /*bt-set kol el inforamtion bta3et el service le multi servers 3la 
      7asam el method ely el user me5tarha w el simulation y-stop lma awsal lel time ely medeholy el user*/
     public void multiServerQueueEndOfTime(string method,int endOfTime)
     {
         int i =0;

         initializeFirstRow();

       
            if (method == "lowest utilization")
            {
                while (timeServiceEnd[i] < endOfTime)
                {
                    i++;

                    lowestMethod(i);
                }
            }

            else if (method == "highest priority")
            {
                 while (timeServiceEnd[i] < endOfTime)
                {
                    i++;

                   priorityMethod(i);
                }
            }
            else
            {
                 while (timeServiceEnd[i] < endOfTime)
                {
                    i++;

                  randomMethod(i);
                }
            }
            i++;
            plotAndCalculate(i, "multi");

      }



     /*bt-set kol el inforamtion bta3et el service le multi servers 3la 
      7asam el method ely el user me5tarha w el simulation y-stop lma 3add el customers ely el user medeholy*/
     public void multiServerQueueAllCustomers(string method,int numOfCustomers)
      {
          initializeFirstRow();

          if (method == "lowest utilization")
          {

              for (int i = 1; i < numOfCustomers; i++)
              {
                  lowestMethod(i);
              }

          }

          else if (method == "highest priority")
          {

              for (int i = 1; i < numOfCustomers; i++)
              {
                  priorityMethod(i);
              }
          }

          else
          {
              for (int i = 1; i < numOfCustomers; i++)
              {
                  randomMethod(i);
              }


          }


          plotAndCalculate(numOfCustomers, "multi");
     
      }

    }
}
