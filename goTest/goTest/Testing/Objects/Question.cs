using goTest.CommonComponents.WorkWithData.Realization.WorkWithDataBase.SqlLite;
using goTest.Testing.Exceptions;
using goTest.Testing.Interfaces;
using goTest.Testing.Realization;
using goTest.Testing.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Testing.Objects
{
    class Question
    {
        private string questionsContent;
        private List<Unswer> unswers;
        private QuestionType questionsType;
        private int id;
        private bool isDeleted;

        public Question()
        {
            unswers = new List<Unswer>();
            IsDeleted = false;
        }

        public void isValid()
        {
            if (questionsContent == null)
            {
                throw new ObjectNotValid("Вопрос: " + id + " не содержит контент");
            }
            else
            {
                if (questionsContent.Equals(""))
                {
                    throw new ObjectNotValid("Ответ: " + id + " не содержит контент");
                }
            }
            if (questionsType == null)
            {
                throw new ObjectNotValid("Неизвестный тип вопроса у вопроса: " + questionsContent);
            }
            if (unswers.Count < 2)
            {
                throw new ObjectNotValid("Вопрос: " + questionsContent+" должен иметь хотя бы 2 "+
                    "варианта ответов");
            }
            int countOfRightUnswer = 0;
            for (int i = 0; i < unswers.Count; i++)
            {
                if(unswers.ElementAt(i).IsRight)
                {
                    countOfRightUnswer++;
                }
            }
            if(countOfRightUnswer<1)
            {
                throw new ObjectNotValid("Вопрос: " + questionsContent + " должен иметь хотя бы "+
                    "1 правильный ответ"); ;
            }
            for (int i = 0; i < unswers.Count; i++)
            {
                unswers.ElementAt(i).isValid();
            }
        }

        public int getUnswerIndex(int unswerId)
        {
            for(int i=0; i<unswers.Count; i++)
            {
                if (unswers.ElementAt(i).Id == unswerId)
                {
                    return i;
                }
            }

            throw new GoTestObjectNotFound();
        }

        public string QuestionsContent
        {
            get
            {
                return questionsContent;
            }

            set
            {
                questionsContent = value;
            }
        }

        public bool compare(Question question)
        {
            if(!question.questionsContent.Equals(questionsContent))
            {
                return false;
            }
            if (!question.questionsType.getType().Equals(questionsType.getType()))
            {
                return false;
            }
            for(int i=0; i<unswers.Count; i++)
            {
                if(!unswers.ElementAt(i).compare(question.unswers.ElementAt(i)))
                {
                    return false;
                }
            }

           return true;
        }

        public Question copy()
        {
            Question copy = new Question();
            copy.id = id;
            copy.questionsContent = questionsContent;
            copy.questionsType = questionsType;
            for(int i=0; i<unswers.Count; i++)
            {
                copy.unswers.Add(unswers.ElementAt(i).copy());
            }
            copy.isDeleted = isDeleted;
            
            return copy;
        }

        internal QuestionType QuestionsType
        {
            get
            {
                return questionsType;
            }

            set
            {
                questionsType = value;
            }
        }

        internal List<Unswer> Unswers
        {
            get
            {
                return unswers;
            }

            set
            {
                unswers = value;
            }
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public bool IsDeleted
        {
            get
            {
                return isDeleted;
            }

            set
            {
                isDeleted = value;
            }
        }

        public void delete()
        {
            for(int i=0; i<unswers.Count; i++)
            {
                unswers.ElementAt(i).delete();
            }
            deleteSelf();
        }

        private void deleteSelf()
        {
            GoTestQueryConfiguratorI queryConfigurator = new GoTestQueryConfigurator();
            SqlLiteSimpleExecute.execute(queryConfigurator.deleteObjectReferences(id));
            SqlLiteSimpleExecute.execute(queryConfigurator.deleteObjectParameters(id));
            SqlLiteSimpleExecute.execute(queryConfigurator.deleteObjectFromObjectsTable(id));
        }
    }
}
