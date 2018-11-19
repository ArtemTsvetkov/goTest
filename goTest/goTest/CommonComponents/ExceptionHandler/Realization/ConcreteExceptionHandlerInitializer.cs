using goTest.CommonComponents.DataConverters.Exceptions;
using goTest.CommonComponents.ExceptionHandler.Interfaces;
using goTest.CommonComponents.Exceptions;
using goTest.CommonComponents.WorkWithData.Exceptions.DataBasesExceptions;
using goTest.Navigator.Exceptions;
using goTest.SecurityComponent.Encryption.Realization.Exceptions;
using goTest.SecurityComponent.Exceptions;
using goTest.Testing.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.CommonComponents.ExceptionHandler.Realization
{
    class ConcreteExceptionHandlerInitializer
    {
        public static void initThisExceptionHandler(ExceptionHandlerInterface handler)
        {
            try
            {
                handler.addException(new СonversionError());
                handler.addException(new InsufficientPermissionsException());
                handler.addException(new IncorrectOldPassword());
                handler.addException(new IncorrectUserData());
                handler.addException(new ViewAlreadyAddedException());
                handler.addException(new NoConfigurationSpecified());
                handler.addException(new NotFoundView());
                handler.addException(new ViewsHistoryIsEmtptyException());
                handler.addException(new NoDataBaseConnection());
                handler.addException(new DatabaseQueryError());
                handler.addException(new NotSupportKeysLength());
                handler.addException(new NotEnoughTablesExeption());
                handler.addException(new AdminIsNotExist());
                handler.addException(new BadCheckedPasswords());
                handler.addException(new GoTestObjectNotFound());
                handler.addException(new QuestionTypeException());
                handler.addException(new NotEnoughQuestions());
                handler.addException(new EqualsQuestionsExceptions());
                handler.addException(new ParamsTypesExceptions());
            }
            catch (Exception ex)
            {
                ExceptionHandler.getInstance().processing(ex);
            }
        }
    }
}
