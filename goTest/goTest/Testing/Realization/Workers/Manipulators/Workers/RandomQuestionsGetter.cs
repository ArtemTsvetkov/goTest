﻿using goTest.Testing.Exceptions;
using goTest.Testing.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Testing.Interfaces.Manipulators.Workers
{
    class RandomQuestionsGetter
    {
        UnswerManipalatorI unswerManipalator;
        GoTestQueryConfiguratorI queryConfigurator;
        QuestionManipulatorI questionManipulator;

        public RandomQuestionsGetter(UnswerManipalatorI unswerManipalator,
            GoTestQueryConfiguratorI goTestQueryConfigurator,
            QuestionManipulatorI questionManipulator)
        {
            this.unswerManipalator = unswerManipalator;
            queryConfigurator = goTestQueryConfigurator;
            this.questionManipulator = questionManipulator;
        }

        public List<Question> get(int[] ids)
        {
            List<Question> questions = new List<Question>();

            for (int i = 0; i < ids.Length; i++)
            {
                questions.Add(questionManipulator.load(ids[i]));
            }
            return questions;
        }

        public List<Question> get(int[] ids, int count)
        {
            if(ids.Count()<count)
            {
                throw new NotEnoughQuestions();
            }
            List<Question> questions = new List<Question>();
            if (ids.Length == count)
            {
                for (int i = 0; i < ids.Length; i++)
                {
                    questions.Add(questionManipulator.load(ids[i]));
                }

                return questions;
            }

            Random rand = new Random();
            List<int> alreadyAddedList = new List<int>();
            for (int i=0; i<count; i++)
            {
                int a = rand.Next(0, (ids.Count()-1));
                bool alreadyAdded = false;
                for(int m=0; m<alreadyAddedList.Count; m++)
                {
                    if(alreadyAddedList.ElementAt(m)==a)
                    {
                        i--;
                        alreadyAdded = true;
                    }
                }
                if (!alreadyAdded)
                {
                    questions.Add(questionManipulator.load(ids[a]));
                    alreadyAddedList.Add(a);
                }
            }


            return questions;
        }
    }
}
