using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDExamples
{
    public class MaxScoreService
    {
        public int GetMaximumScore(int[] numbers, int allowedSteps)
        {
            int score = 0;
            int currentStep = 0;
            int stepsTaken = 0;
            int maxValue = 0;
            if(numbers.Any())
            {

                maxValue = numbers.Max();
                score = numbers[currentStep];
                
                for (int i = 1; i < numbers.Length; i++)
                {
                    stepsTaken = 0;
                    if (numbers[i] < numbers[currentStep])
                    {
                        if(numbers[i] == maxValue)
                        {
                            if (CanTakeStep(allowedSteps, stepsTaken))
                            { 
                                currentStep = i;
                                stepsTaken++;
                            }
                        }
                        continue;
                    }
                    else if (numbers[i] >= numbers[currentStep])
                    {
                        if (CanTakeStep(allowedSteps, stepsTaken))
                        { 
                            currentStep = i;
                            stepsTaken++;
                            score = numbers[i] + score;
                        }
                        
                        
                    }
                }
            }
            else
            {
                return 0;
            }

            var finalScore = score > numbers[currentStep] ? score : numbers[currentStep];

            return finalScore;
        }

        private bool CanTakeStep(int maxStep, int stepsTaken)
        {
            return stepsTaken < maxStep;
        }
    }
}
